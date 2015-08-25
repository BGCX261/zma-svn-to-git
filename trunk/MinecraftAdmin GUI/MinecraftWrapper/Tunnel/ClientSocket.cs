namespace Vitt.Andre.Tunnel
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using Zicore.MinecraftAdmin;
    using System.Text.RegularExpressions;
    using Zicore.MinecraftAdmin.Commands;
    using MinecraftWrapper.Blocks;
    using Zicore.MinecraftAdmin.Admins;
    using Vitt.Andre.XML;
    using MinecraftWrapper.Player;
    using MinecraftWrapper.Zones;
    using Zicore.MinecraftAdmin.IO;
    using MinecraftWrapper.Protocoll;
    using MinecraftWrapper.ExternalComponents;
    using Vitt.Andre.TCPTunnelLib.Vitt.Andre.Tunnel;
    using MinecraftWrapper.AddonInterface;
    using MinecraftWrapper.WebInterface;
    using MCAdmin;
    using MinecraftWrapper.MainClasses;

    public class ClientSocket : IClient
    {
        bool flyMode = false;

        public bool FlyMode
        {
            get { return flyMode; }
            set { flyMode = value; }
        }

        private byte[] extBuffer = new byte[0];
        private byte[] intBuffer = new byte[0];

        private LockFreeQueue<byte[]> packetQueueExt = new LockFreeQueue<byte[]>();
        private LockFreeQueue<byte[]> packetQueueInt = new LockFreeQueue<byte[]>();

        int positionCounter = 0;
        int positionCounterMax = 2;

        private bool connected = true;

        private Socket externalSock;

        public Socket ExternalSock
        {
            get { return externalSock; }
            set { externalSock = value; }
        }
        private Socket internalSock;

        public Socket InternalSock
        {
            get { return internalSock; }
            set { internalSock = value; }
        }

        private Thread externalThread;
        private Thread internalThread;
        private Thread pingThread;

        //bool idhasBeenSet = false;
        bool hasEnteredZone = false;
        bool nameSet = false;

        private ServerSocket serverSocket;

        private string ip;

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private string name = "";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        XPosition position = new XPosition();

        public XPosition Position
        {
            get { return position; }
            set { position = value; }
        }

        int ticker = 0;
        int tickerMax = 20;

        public ClientSocket(Socket clientSocket, ServerSocket serverSocket)
        {
            this.serverSocket = serverSocket;

            //this.databaseWorker = serverSocket.DatabaseWorker;
            if (clientSocket.RemoteEndPoint.AddressFamily == AddressFamily.InterNetwork)
            {
                isNpc = true;
            }

            externalSock = clientSocket;
            internalSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            ip = IPAddress.Parse(((IPEndPoint)this.externalSock.RemoteEndPoint).Address.ToString()).ToString();
            serverSocket.Clients.Add(this);

            internalSock.Connect("127.0.0.1", this.serverSocket.intport);

            internalSock.SendTimeout = 30000;
            internalSock.ReceiveTimeout = 30000;
            externalSock.SendTimeout = 30000;
            externalSock.ReceiveTimeout = 30000;

            internalThread = new Thread(new ThreadStart(this.InternalThread));
            externalThread = new Thread(new ThreadStart(this.ExternalThread));
            pingThread = new Thread(new ThreadStart(this.PingThread));

            //internalSock.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
            //externalSock.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
            
            internalThread.Start();
            externalThread.Start();
            pingThread.Start();

            this.serverSocket.Tunnel.MinecraftHandler.PlayerJoined += new MinecraftHandler.OnPlayerjoined(MinecraftHandler_PlayerJoined);
        }

        bool isNpc = false;

        //DatabaseWorker databaseWorker = null;

        //public DatabaseWorker DB
        //{
        //    get { return databaseWorker; }
        //    set { databaseWorker = value; }
        //}

        void MinecraftHandler_PlayerJoined(object sender, string player)
        {
            //serverSocket.Tunnel.MinecraftHandler.ExecuteCommand("");
        }

        public void AddAction(Object obj)
        {

        }

        public void Disconnect()
        {
            if (this.connected)
            {
                this.connected = false;
                try
                {
                    this.externalSock.Close();
                    Thread.Sleep(50);
                }
                catch
                {
                }
                try
                {
                    this.internalSock.Close();
                    Thread.Sleep(50);
                }
                catch
                {
                }
                try
                {
                    //serverSocket.Tunnel.MinecraftHandler.RemovePlayer(name);
                }
                catch
                {
                }
                try
                {
                    this.serverSocket.Clients.Remove(this);
                }
                catch
                {
                }
                try
                {
                    UserCollectionSingletone.GetInstance().Save();
                }
                catch
                {

                }
            }
        }

        public void Disconnect(string reason)
        {
            if (this.connected)
            {
                try
                {
                    this.SendPacket(0xff, ByteArythmetic.StoA(reason), this.externalSock, true);
                    this.SendPacket(0xff, ByteArythmetic.StoA(reason), this.internalSock, true);
                }
                catch
                {
                }
                Thread.Sleep(10);
                this.Disconnect();
                
            }
        }

        private void ExternalThread()
        {
            bool flag = false;
            byte[] buffer = new byte[0x100];
            while (this.internalSock.Connected && this.externalSock.Connected)
            {
                try
                {
                    if (!flag)
                    {
                        buffer = new byte[1];
                        if (this.externalSock.Receive(buffer) > 0)
                        {
                            string str;
                            byte fByte = buffer[0];
                            this.extBuffer = new byte[] { fByte };
                            //int bytes = -2;
                            // Client to server
                            PacketBytes firstByte = (PacketBytes)fByte;
                            PacketSizes bytes = PacketSizes.Minus_2;

                            bytes = MinecraftEnums.GetPacketSize(firstByte);


                            //if (bytes == PacketSizes.Minus_2)
                            //{
                            //    databaseWorker.AddAction(new DatabaseAction(() =>
                            //    {
                            //        Log.Append(this, "Unkown Packet logged " + ((int)firstByte).ToString(), Log.PacketsLog);
                            //    }));
                            //    bytes = PacketSizes.Minus_1;
                            //}

                            bool forwardPacket = true;
                            if (bytes != PacketSizes.String)
                            {
                                if ((int)bytes > 0)
                                {
                                    buffer = this.ReceiveBytes(this.externalSock, (int)bytes);
                                    switch (firstByte)
                                    {
                                        case PacketBytes._0x0E_BlockDig_0x0E:
                                            {
                                                //DB.AddAction(new DatabaseAction(() =>
                                                //{
                                                //    if (ChatMessageReceived != null)
                                                //    {
                                                //        ChatMessageReceived(this, this, "Digged Block");
                                                //    }
                                                //}));

                                                byte Status = ByteArythmetic.GetByte(this.extBuffer, 1);
                                                int X = ByteArythmetic.GetInt32(extBuffer, 2);
                                                byte Y = ByteArythmetic.GetByte(extBuffer, 6);
                                                int Z = ByteArythmetic.GetInt32(extBuffer, 7);
                                                byte Direction = ByteArythmetic.GetByte(extBuffer, 11);
                                                forwardPacket = true;
                                                try
                                                {
                                                    XPosition blockPos = new XPosition((double)X, (double)Y, (double)Z, 0, 0, 0, false);

                                                    ZoneCollectionSingletone zones = ZoneCollectionSingletone.GetInstance();
                                                    Zone zone = zones.GetZoneByPosition(blockPos);
                                                    UserCollectionSingletone userCollection = UserCollectionSingletone.GetInstance();
                                                    User user = userCollection.GetUserByName(name);
                                                    if (user == null)
                                                    {
                                                        user = new User();
                                                    }

                                                    MinecraftHandler mc = serverSocket.Tunnel.MinecraftHandler;
                                                   
                                                    //flag2 = user.Level.AllowDestroy;

                                                    if (zone != null)
                                                    {
                                                        if (zone.FixToGroup)
                                                        {
                                                            forwardPacket = zone.Owner == user.Name ||
                                                                user.LevelID == zone.LevelID && zone.AllowDestroy ||
                                                                mc.IsStringInList(user.Name, zone.Whitelist) ;
                                                        }
                                                        else
                                                        {
                                                            forwardPacket = zone.Owner == user.Name  ||
                                                                user.LevelID > zone.LevelID && zone.AllowDestroy ||
                                                                mc.IsStringInList(user.Name, zone.Whitelist) ;
                                                        }
                                                    }

                                                    forwardPacket = forwardPacket && user.Level.AllowDestroy;
                                                }
                                                catch
                                                {

                                                }

                                                //if (!flag2)
                                                //{
                                                //    int stat = 0;
                                                //    if (Status == 1 || Status == 3)
                                                //    {
                                                        
                                                //    }
                                                //    else
                                                //    {
                                                //        //stat = 2;
                                                //        //PacketGenerator p = new PacketGenerator();
                                                //        //p.Add((byte)firstByte);
                                                //        //p.Add((byte)stat);
                                                //        //p.Add(X);
                                                //        //p.Add(Y);
                                                //        //p.Add(Z);
                                                //        //p.Add(Direction);
                                                //        //byte[] instantDetroy = p.ToByteArray();
                                                //        //extBuffer = instantDetroy;
                                                //        //flag2 = true;
                                                //    }
                                                //}
                                                //else
                                                //{
                                                //    PacketGenerator p = new PacketGenerator();
                                                //    p.Add((byte)firstByte);
                                                //    p.Add((byte)0x00);
                                                //    p.Add(X);
                                                //    p.Add(Y);
                                                //    p.Add(Z);
                                                //    p.Add(Direction);
                                                //    byte[] instantDetroy = p.ToByteArray();
                                                //    extBuffer = instantDetroy;
                                                //    flag2 = true;
                                                //}
                                            }
                                            break;

                                        case PacketBytes._0x0B_PlayerPosition_0x0B://
                                            {
                                                position.X = ByteArythmetic.GetDouble(extBuffer, 1);
                                                position.Y = ByteArythmetic.GetDouble(extBuffer, 9);
                                                position.Stance = ByteArythmetic.GetDouble(extBuffer, 17);
                                                position.Z = ByteArythmetic.GetDouble(extBuffer, 25);
                                                position.Unkown = ByteArythmetic.GetBoolean(extBuffer, 33);

                                                positionCounter++;
                                                if (positionCounter >= positionCounterMax)
                                                {
                                                    positionCounter = 0;

                                                    XPosition pos = new XPosition(position.X, position.Y, position.Z, 0.0, 0.0f, 0.0f, false);
                                                    if (ticker >= tickerMax)
                                                    {
                                                        ZoneCollectionSingletone zones = ZoneCollectionSingletone.GetInstance();
                                                        Zone zone = zones.GetZoneByPosition(Position);

                                                        if (zone != null)
                                                        {
                                                            if (!hasEnteredZone)
                                                            {
                                                                if (!String.IsNullOrEmpty(zone.WelcomeMessage))
                                                                {
                                                                    serverSocket.SendMessageToClient(name, zone.WelcomeMessage);
                                                                }
                                                            }
                                                            hasEnteredZone = true;
                                                        }
                                                        else
                                                        {
                                                            hasEnteredZone = false;
                                                        }
                                                        ticker = 0;
                                                    }
                                                    ticker++;
                                                    MinecraftHandler mc = serverSocket.Tunnel.MinecraftHandler;

                                                    foreach (IPlugin plugin in mc.Plugins)
                                                    {
                                                        try
                                                        {
                                                            if (plugin.Enabled)
                                                            {
                                                                plugin.OnPlayerMove(serverSocket, this, pos);
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Log.AppendText("Error Executing Plugin OnPlayerMove() " + ex.Message, Log.PluginLog);
                                                        }
                                                    }

                                                }

                                                
                                                // 31 Bytes
                                            }
                                            break;

                                        case PacketBytes._0x0C_PlayerLook_0x0C:
                                            {
                                                position.Rotation = ByteArythmetic.GetFloat(extBuffer, 1);
                                                position.Pitch = ByteArythmetic.GetFloat(extBuffer, 5);
                                                position.Unkown = ByteArythmetic.GetBoolean(extBuffer, 9);
                                                // 31 Bytes
                                            }
                                            break;

                                        case PacketBytes._0x0D_PlayerMoveAndLook_0x0D:
                                            {
                                                position.X = Util.AtoD(buffer, 0);
                                                position.Stance = Util.AtoD(buffer, 8);
                                                position.Y = Util.AtoD(buffer, 16);
                                                position.Z = Util.AtoD(buffer, 24);
                                                position.Rotation = Util.AtoF(buffer, 32);
                                                position.Pitch = Util.AtoF(buffer, 36);
                                                //41
                                            }
                                            break;
                                    }
                                    buffer.CopyTo(this.extBuffer, 1);
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                switch (firstByte)
                                {
                                    case PacketBytes._0x01_Login_0x01:
                                        this.ReceiveBytes(this.externalSock, 4);
                                        this.name = this.ReceiveString(this.externalSock);

                                        if (!nameSet)
                                        {
                                            //serverSocket.Tunnel.MinecraftHandler.AddPlayer(name);
                                            nameSet = true;
                                            //serverSocket.Tunnel.MinecraftHandler.ExecuteMOTD(serverSocket.Tunnel.MinecraftHandler.Config.Modt, name);
                                        }
                                        Match m = new Regex("<§[0-9a-f](?<username>[^>]+)§[0-9a-f]>").Match(name);
                                        if (m.Success)
                                        {
                                            name = m.Groups["username"].Value;
                                        }

                                        if (!ByteArythmetic.ContainsInvalidChars(this.name, true)) 
                                        {
                                            //this.ReceiveString(this.externalSock); // Update 1.5 removed string
                                            //break;
                                        }
                                        else
                                        {
                                            this.Disconnect("Invalid Name");
                                            return;
                                        }

                                        //ReceiveBytes(this.externalSock, 8);
                                        //ReceiveBytes(this.externalSock, 1);
                                        break;

                                    case PacketBytes._0x02_Handshake_0x02:
                                        str = this.ReceiveString(this.externalSock);
                                        if (!(this.name != "") || !(str.ToLower() != this.name.ToLower()))
                                        {
                                            this.name = str;
                                        }
                                        else
                                        {
                                            this.Disconnect("Invalid Name");
                                            return;
                                        }
                                        break;

                                    case PacketBytes._0x03_Chat_0x03:
                                        {
                                            string chatMessage = this.ReceiveString(this.externalSock);
                                            MinecraftHandler mc = this.serverSocket.Tunnel.MinecraftHandler;
                                            bool unkownCommand = false;
                                            List<String> players = mc.Player;
                                            UserCollectionSingletone userCollection = UserCollectionSingletone.GetInstance();
                                            User user = userCollection.GetUserByName(name);

                                            if (chatMessage.Length > 0)
                                            {
                                                if (chatMessage[0] == mc.Config.CommandChar[0])
                                                {
                                                    string commandRegexPattern = String.Format(@"{0}(?<cmd>[a-zA-Z]+) ?(?<arg1>.+)?", mc.Config.CommandChar);
                                                    Regex commandRegex = new Regex(commandRegexPattern);
                                                    Match match = commandRegex.Match(chatMessage);

                                                    string commandName = "";
                                                    string arguments = "";

                                                    if (match.Success)
                                                    {
                                                        try
                                                        {
                                                            forwardPacket = false;
                                                            commandName = match.Groups["cmd"].Value;
                                                            arguments = match.Groups["arg1"].Value;

                                                            if (mc != null && mc.Started)
                                                            {
                                                                CommandResult cmdResult = mc.CommandHandlerExternal(name, commandName, arguments, this, serverSocket);
                                                                if (cmdResult != null && cmdResult.HasResult)
                                                                {
                                                                    if (mc.Config.CommandExecutedResponse)
                                                                    {

                                                                        if (user.Level.OwnExecuteResponse)
                                                                        {
                                                                            serverSocket.SendExecuteResponse(user.Name, cmdResult.Message);
                                                                        }

                                                                        if (!cmdResult.IsPrivate)
                                                                        {
                                                                            foreach (User u in userCollection.Items)
                                                                            {
                                                                                if (user != u)
                                                                                {
                                                                                    if (u.Level.OtherExecuteResponse)
                                                                                    {
                                                                                        if (mc.IsStringInList(u.Name, players))
                                                                                        {
                                                                                            serverSocket.SendExecuteResponse(u.Name, cmdResult.Message);
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    unkownCommand = true;
                                                                    if (mc.Config.SendUnkownCommandResponse)
                                                                    {
                                                                        serverSocket.SendExecuteResponse(name, String.Format("Unknown command {0}", chatMessage));
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            serverSocket.SendExecuteResponse(name, String.Format("Exception while executing", chatMessage));
                                                            Log.AppendText(ex.Message, Log.ExceptionsLog);
                                                        }
                                                    }
                                                }
                                            }
                                            bool tunnelMessage = true;
                                            foreach (IPlugin plugin in mc.Plugins)
                                            {
                                                try
                                                {
                                                    if (plugin.Enabled)
                                                    {
                                                        plugin.OnChatMessage(serverSocket, this, chatMessage, ref tunnelMessage);
                                                    }
                                                }
                                                catch
                                                {
                                                    Log.AppendText("Error Executing Plugin OnChatMessage()", Log.PluginLog);
                                                }
                                            }

                                            if (ChatMessageReceived != null)
                                            {
                                                ChatMessageReceived(this, this, chatMessage);
                                            }

                                            if (tunnelMessage)
                                            {
                                                if (!unkownCommand)
                                                {
                                                    if (forwardPacket && chatMessage[0] != '/')
                                                    {
                                                        forwardPacket = false;
                                                        char lineColor = 'f';
                                                        if (serverSocket.FirstLine)
                                                        {
                                                            lineColor = mc.Config.LineFirstColorKey;
                                                        }
                                                        else
                                                        {
                                                            lineColor = mc.Config.LineSecondColorKey;
                                                        }

                                                        serverSocket.FirstLine = !serverSocket.FirstLine;
                                                        if (user.Level.AllowChat && user.AllowChat)
                                                        {
                                                            if (mc.Config.ChannelModeChat)
                                                            {
                                                                serverSocket.SendChannelMessage(String.Format("§f<§{0}{1}§{2}> §{3}{4}", user.Level.GroupColor, name, 'F', lineColor, chatMessage),this);
                                                            }
                                                            else
                                                            {
                                                                serverSocket.SendServerMessage(String.Format("§f<§{0}{1}§{2}> §{3}{4}", user.Level.GroupColor, name, 'F', lineColor, chatMessage));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            serverSocket.SendExecuteResponse(name, "You have no permissions to chat");
                                                        }

                                                        //ZmaSQLConnection sql = new ZmaSQLConnection();
                                                        //sql.AddChatMessage(name, text, mc);
                                                    }
                                                }
                                                else
                                                {
                                                    if (mc.Config.ForwardUnkownCommands)
                                                    {
                                                        forwardPacket = true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                forwardPacket = false;
                                            }
                                        }
                                        break;
                                    //case PacketBytes._0x22_EntityTeleport_0x22:
                                    //    int uid = ByteArythmetic.GetInt32(buffer, 0);
                                    //    //int x = ByteArythmetic.GetInt32(buffer, 4);
                                    //    //int y = ByteArythmetic.GetInt32(buffer, 8);
                                    //    //int z = ByteArythmetic.GetInt32(buffer, 12);

                                    //    //byte rotation = ByteArythmetic.GetByte(buffer, 13);
                                    //    //byte pitch = ByteArythmetic.GetByte(buffer, 14);
                                    //    break;

                                        // 2010-01-13 Minecraft 1.2

                                    

                                    case PacketBytes._0x18_MobSpawn_0x18:
                                        {
                                            ReceiveBytes(externalSock, 19);
                                            HandleInsanity(externalSock);
                                        }
                                        break;

                                    case PacketBytes._0x19_NewPacket_0x19:
                                        {
                                            ReceiveBytes(externalSock, 4);
                                            ReceiveString(externalSock);
                                            ReceiveBytes(externalSock, 16);
                                        }
                                        break;

                                    case PacketBytes._0x28_NewPacket_0x28:
                                        {
                                            ReceiveBytes(externalSock, 4);
                                            HandleInsanity(externalSock);
                                        }
                                        break;

                                    case PacketBytes._0x3C_Explosion_0x3C:
                                        ReceiveBytes(externalSock, 28); //8 + 8 + 8 + 4
                                        ReceiveBytes(externalSock, Util.AtoI(ReceiveBytes(externalSock, 4), 0) * 3);
                                        break;

                                    case PacketBytes._0x64_OpenWindow_0x64:
                                        {
                                            this.ReceiveBytes(this.ExternalSock, 2);
                                            this.ReceiveStringUtf8(this.externalSock);
                                            this.ReceiveBytes(this.ExternalSock, 1);
                                        }
                                        break;


                                    case PacketBytes._0x66_WindowClick_0x66:
                                        {
                                            ReceiveBytes(externalSock, 7); // Update 1.5 + 1 bool
                                            if (Util.AtoN(ReceiveBytes(externalSock, 2), 0) >= 0) ReceiveBytes(externalSock, 3);
                                        }
                                        break;

                                    case PacketBytes._0x67_SetSlot_0x67:
                                        {
                                            ReceiveBytes(externalSock, 3);
                                            if (Util.AtoN(ReceiveBytes(externalSock, 2), 0) >= 0) ReceiveBytes(externalSock, 3);
                                        }
                                        break;

                                    case PacketBytes._0x68_WindowItems_0x68:
                                             short xmax = Util.AtoN(ReceiveBytes(externalSock, 3), 1);
                                            for (short cx = 0; cx < xmax; cx++)
                                            {
                                                if (Util.AtoN(ReceiveBytes(externalSock, 2), 0) >= 0)
                                                {
                                                    ReceiveBytes(externalSock, 3);
                                                }
                                            }
                                            break;

                                    case PacketBytes._0x82_UpdateSign_0x82:
                                        {
                                            ReceiveBytes(externalSock, 10);
                                            ReceiveString(externalSock);
                                            ReceiveString(externalSock);
                                            ReceiveString(externalSock);
                                            ReceiveString(externalSock);
                                        }
                                        break;

                                    case PacketBytes._0xFF_Disconnect_0xFF:
                                        this.Disconnect(this.ReceiveString(this.externalSock));
                                        break;

                                    case PacketBytes._0x0F_PlaceBlock_0x0F:
                                        {
                                            ReceiveBytes(externalSock, 10);
                                            if (Util.AtoN(ReceiveBytes(externalSock, 2), 0) >= 0) ReceiveBytes(externalSock, 3);

                                            BlockCollection badBlocks = BlockCollection.Load(Config.ConfigFolder + BlockCollection.BadBlocksFile);
                                            ItemDictonary items = ItemDictonary.GetInstance();


                                            int blockX = Util.AtoI(extBuffer, 1);
                                            byte blockY = ByteArythmetic.GetByte(extBuffer, 5);
                                            int blockZ = ByteArythmetic.GetInt32(extBuffer, 6);
                                            byte blockDirection = ByteArythmetic.GetByte(extBuffer, 10);
                                            short num4 = ByteArythmetic.GetInt16(extBuffer, 11);

                                            XPosition blockPos = new XPosition(blockX , blockY, blockZ, 0, 0, 0, false);

                                            UserCollectionSingletone userCollection = UserCollectionSingletone.GetInstance();
                                            User user = userCollection.GetUserByName(name);
                                            if (user == null)
                                            {
                                                user = new User();
                                            }
                                            BlockItem block = badBlocks.GetBlockById(num4);
                                            ZoneCollectionSingletone zones = ZoneCollectionSingletone.GetInstance();

                                            Zone zone = zones.GetZoneByPosition(blockPos);
                                            MinecraftHandler mc = serverSocket.Tunnel.MinecraftHandler;

                                            forwardPacket = (user.Level.BlockLevel == 0 && num4 != -1) && user.Level.AllowBuild;
                                            if (block != null)
                                            {
                                                forwardPacket = (user.Level.BlockLevel >= block.BlockLevel) && user.Level.AllowBuild;
                                                if (zone != null)
                                                {
                                                    if (zone.FixToGroup)
                                                    {
                                                        forwardPacket = user.LevelID == zone.LevelID && zone.BlockLevel >= block.BlockLevel && user.Level.BlockLevel >= block.BlockLevel && zone.AllowBuild ||
                                                            mc.IsStringInList(user.Name, zone.Whitelist) && user.Level.BlockLevel >= block.BlockLevel  ||
                                                                zone.Owner == user.Name && user.Level.BlockLevel >= block.BlockLevel;
                                                    }
                                                    else
                                                    {
                                                        forwardPacket = user.LevelID > zone.LevelID && zone.BlockLevel >= block.BlockLevel && user.Level.BlockLevel >= block.BlockLevel &&  zone.AllowBuild ||
                                                            mc.IsStringInList(user.Name, zone.Whitelist) && user.Level.BlockLevel >= block.BlockLevel ||
                                                            zone.Owner == user.Name && user.Level.BlockLevel >= block.BlockLevel;
                                                    }
                                                }
                                            }

                                            foreach (IPlugin plugin in serverSocket.Tunnel.MinecraftHandler.Plugins)
                                            {
                                                try
                                                {
                                                    if (plugin.Enabled)
                                                    {
                                                        plugin.OnBlockPlacing(serverSocket, this, num4, ref forwardPacket);
                                                    }
                                                }
                                                catch
                                                {
                                                    Log.AppendText("Error Executing Plugin OnBlockPlacing()", Log.PluginLog);
                                                }
                                            }

                                            if (!forwardPacket)
                                            {
                                                if (num4 != -1)
                                                {
                                                    string str4 = "";
                                                    KeyValuePair<String, String> item;
                                                    if (items.GetKeyValuePairByValue(out item, num4.ToString()))
                                                    {
                                                        str4 = String.Format("{0}", item.ToString());
                                                    }
                                                    else
                                                    {
                                                        str4 = String.Format("Unkown ID: {0}", item.Value);
                                                    }

                                                    if (mc.Config.CommandExecutedResponse)
                                                    {
                                                        //Log.Append(this, this.name + " tried to spawn illegal block " + str4, Log.ExceptionsLog);
                                                        //serverSocket.SendExecuteResponse(this.name, this.name + " tried to spawn illegal block " + str4);
                                                    }
                                                }
                                            }

                                            if (forwardPacket)
                                            {
                                                //ByteArythmetic.NinA(num4, buffer, 0);
                                            }
                                        }
                                        break;

                                    default:
                                        bytes = PacketSizes.Minus_2;
                                        break;
                                }
                            }

                            if (bytes == PacketSizes.Minus_2)
                            {
                                //this.fwl.parent.SendServerMessage("Client \"" + this.name + "\" (IP: " + this.ip + ") sent unknown packet. Disabled firewalling!!!", '4');
                                //this.fwl.parent.AddRTLine(Color.Orange, "Invalid packet ID: " + ((int)num2) + "\r\n", false);
                                this.internalSock.Send(this.extBuffer);
                                flag = true;
                                buffer = new byte[0x100];
                                continue;
                            }
                            if (forwardPacket)
                            {
                                this.internalSock.Send(this.extBuffer);
                            }

                            try
                            {
                                while (this.packetQueueInt.Count > 0)
                                {
                                    byte[] data;
                                    if (this.packetQueueInt.Dequeue(out data))
                                    {
                                        this.internalSock.Send(data);
                                    }
                                }
                                continue;
                            }
                            catch (SocketException)
                            {
                                this.Disconnect();
                                continue;
                            }
                            catch
                            {
                                continue;
                            }

                        }
                        Thread.Sleep(5);
                    }
                    else
                    {
                        int size = this.externalSock.Receive(buffer);
                        if (size > 0)
                        {
                            this.internalSock.Send(buffer, 0, size, SocketFlags.None);
                        }
                        else
                        {
                            Thread.Sleep(5);
                        }
                    }
                }
                catch (SocketException ex)
                {
                    this.Disconnect();
                    Log.AppendText("\nClientSocket 511\n" + ex.Message, Log.ExceptionsLog);
                }
                catch
                {
                }
            }

            this.Disconnect();
        }

        ~ClientSocket()
        {
            this.Disconnect();
            try
            {
                this.externalThread.Abort();
            }
            catch
            {
            }
            try
            {
                this.internalThread.Abort();
            }
            catch
            {
            }
            try
            {
                this.pingThread.Abort();
            }
            catch
            {
            }
        }



        public delegate void OnChatMessageReceivedDelegate(object sender, ClientSocket client, String message);
        public event OnChatMessageReceivedDelegate ChatMessageReceived;

        private void InternalThread()
        {
            bool flag = false;
            byte[] buffer = new byte[0x100];
            while (this.internalSock.Connected && this.externalSock.Connected)
            {
                try
                {
                    if (!flag)
                    {
                        buffer = new byte[1];
                        if (this.internalSock.Receive(buffer) > 0)
                        {
                            // server to client
                            byte fByte = buffer[0];
                            this.intBuffer = new byte[] { fByte };
                            PacketSizes bytes = PacketSizes.Minus_2;
                            PacketBytes firstByte = (PacketBytes)fByte;

                            bytes = MinecraftEnums.GetPacketSize(firstByte);
                            
                            
                            //if (bytes == PacketSizes.Minus_2)
                            //{
                            //    databaseWorker.AddAction(new DatabaseAction(() =>
                            //    {
                            //        Log.Append(this, "Unkown Packet logged " + ((int)firstByte).ToString(), Log.PacketsLog);
                            //    }));
                            //    bytes = PacketSizes.Minus_1;
                            //}

                            bool flag2 = true;
                            if (bytes == PacketSizes.Minus_1)
                            {
                                switch (firstByte)
                                {
                                    case PacketBytes._0x33_ChunkMap_0x33:
                                        this.ReceiveBytes(this.internalSock, 13);
                                        this.ReceiveBytes(this.internalSock, ByteArythmetic.GetInt32(this.ReceiveBytes(this.internalSock, 4), 0));
                                        break;
                                    case PacketBytes._0x34_MultiBlockChange_0x34:
                                        this.ReceiveBytes(this.internalSock, 8);
                                        this.ReceiveBytes(this.internalSock, ByteArythmetic.GetInt16(this.ReceiveBytes(this.internalSock, 2), 0) * 4);
                                        break;

                                    case PacketBytes._0xFF_Disconnect_0xFF:
                                        this.Disconnect(this.ReceiveString(this.internalSock));
                                        break;

                                    case PacketBytes._0x01_Login_0x01: 
                                        this.ReceiveBytes(this.internalSock, 4);
                                        this.ReceiveString(this.internalSock);
                                        // this.ReceiveString(this.internalSock);// Update 1.5 removed string
                                        this.ReceiveBytes(this.internalSock, 8);
                                        this.ReceiveBytes(this.internalSock, 1);
                                        break;

                                    case PacketBytes._0x02_Handshake_0x02:
                                        this.ReceiveString(this.internalSock);
                                        break;

                                    case PacketBytes._0x03_Chat_0x03:
                                        String chat = this.ReceiveString(this.internalSock);
                                        String playerJoinedString = String.Format("§e{0} joined the game.", name);
                                        if (chat == playerJoinedString)
                                        {
                                            flag2 = false;
                                        }

                                        break;
                                    case PacketBytes._0x04_UpdateTime_0x04:
                                        serverSocket.RealTimeOfDay = ByteArythmetic.GetInt64(buffer, 0);
                                        break;


                                        // 2010-01-13 Minecraft Beta 1.2
                                    case PacketBytes._0x18_MobSpawn_0x18:
                                        {
                                            ReceiveBytes(internalSock, 19);
                                            HandleInsanity(internalSock);
                                        }
                                        break;

                                    case PacketBytes._0x19_NewPacket_0x19:
                                        {
                                            ReceiveBytes(internalSock, 4);
                                            ReceiveString(internalSock);
                                            ReceiveBytes(internalSock, 16);
                                        }
                                        break;

                                    case PacketBytes._0x28_NewPacket_0x28:
                                        {
                                            ReceiveBytes(internalSock, 4);
                                            HandleInsanity(internalSock);
                                        }
                                        break;

                                    case PacketBytes._0x14_EntitySpawnName_0x14:
                                        this.ReceiveBytes(this.internalSock, 4);
                                        this.ReceiveString(this.internalSock);
                                        this.ReceiveBytes(this.internalSock, 0x10);
                                        break;

                                    case PacketBytes._0x64_OpenWindow_0x64:
                                        {
                                            this.ReceiveBytes(this.internalSock, 2);
                                            String str = this.ReceiveStringUtf8(this.internalSock);
                                            this.ReceiveBytes(this.internalSock, 1);
                                        }
                                        break;

                                    case PacketBytes._0x66_WindowClick_0x66:
                                        {
                                            ReceiveBytes(internalSock, 6);
                                            if (Util.AtoN(ReceiveBytes(internalSock, 2), 0) >= 0) ReceiveBytes(internalSock, 3);
                                        }
                                        break;

                                    case PacketBytes._0x67_SetSlot_0x67:
                                        {
                                            ReceiveBytes(internalSock, 3);
                                            if (Util.AtoN(ReceiveBytes(internalSock, 2), 0) >= 0) ReceiveBytes(internalSock, 3);
                                        }
                                        break;

                                    case PacketBytes._0x68_WindowItems_0x68:
                                        {
                                            ReceiveBytes(internalSock, 1);
                                            short xmax = Util.AtoN(ReceiveBytes(internalSock, 2), 0);
                                            for (short cx = 0; cx < xmax; cx++)
                                            {
                                                if (Util.AtoN(ReceiveBytes(internalSock, 2), 0) >= 0)
                                                {
                                                    ReceiveBytes(internalSock, 3);
                                                }
                                            }
                                        }
                                        break;

                                    case PacketBytes._0x82_UpdateSign_0x82:
                                        {
                                            this.ReceiveBytes(this.internalSock, 10);
                                            this.ReceiveString(this.internalSock);
                                            this.ReceiveString(this.internalSock);
                                            this.ReceiveString(this.internalSock);
                                            this.ReceiveString(this.internalSock);

                                        }
                                        break;

                                    case PacketBytes._0x3C_Explosion_0x3C:
                                        {
                                            ReceiveBytes(internalSock, 28); //8 + 8 + 8 + 4
                                            ReceiveBytes(internalSock, Util.AtoI(ReceiveBytes(internalSock, 4), 0) * 3);
                                        }
                                        break;


                                    case PacketBytes._0x17_AddObject_0x17:
                                        {
                                            ReceiveBytes(internalSock, 17);
                                            if (Util.AtoI(ReceiveBytes(internalSock, 4), 0) > 0)
                                            {
                                                ReceiveBytes(internalSock, 6);
                                            }
                                        }
                                        break;

                                    case PacketBytes._0x83_MapData_0x83:
                                        {
                                            ReceiveBytes(internalSock, 4);
                                            ReceiveBytes(internalSock, Util.AtoI(ReceiveBytes(internalSock, 1), 0));
                                        }
                                        break;

                                    case PacketBytes._0x0F_PlaceBlock_0x0F:
                                        {
                                            ReceiveBytes(internalSock, 10);
                                            if (Util.AtoN(ReceiveBytes(internalSock, 2), 0) >= 0) ReceiveBytes(internalSock, 3);
                                        }
                                        break;

                                    //case PacketBytes._0x3B_NewPacket_0x3B:
                                    //    {
                                    //        this.ReceiveBytes(this.internalSock, 10);
                                    //        this.ReceiveBytes(this.internalSock, ByteArythmetic.GetInt16(this.ReceiveBytes(this.internalSock, 2), 0));
                                    //    }
                                    //    break;
                                    // * removed*
                                    default:
                                        bytes = PacketSizes.Minus_2;
                                        break;
                                }
                            }
                            else if (bytes > 0)
                            {
                                buffer = this.ReceiveBytes(this.internalSock, (int)bytes);
                            }
                            //Label_0367:
                            if (bytes == PacketSizes.Minus_2)
                            {
                                //this.fwl.parent.AddRTLine(Color.Orange, "Invalid packet ID: " + ((int)num2) + "\r\n", false);
                                this.ReceiveBytes(this.internalSock, 0x400);
                                flag = true;
                            }

                            if (firstByte == PacketBytes._0x04_UpdateTime_0x04)
                            {
                                if (serverSocket.OverrideTimeOfDay)
                                {
                                    PacketGenerator p = new PacketGenerator();
                                    p.Add(serverSocket.TimeOfDay);
                                    byte[] time = p.ToByteArray();
                                    Buffer.BlockCopy(time, 0, this.intBuffer, this.intBuffer.Length - 8, 8);
                                }
                            }

                            if (flag2)
                            {
                                this.externalSock.Send(this.intBuffer);
                            }

                            try
                            {
                                while (this.packetQueueExt.Count > 0)
                                {
                                    byte[] data;
                                    if (this.packetQueueExt.Dequeue(out data))
                                    {
                                        this.externalSock.Send(data);
                                    }
                                }
                                continue;
                            }
                            catch (SocketException)
                            {
                                this.Disconnect();
                                continue;
                            }
                            catch
                            {
                                continue;
                            }

                        }
                        Thread.Sleep(5);
                    }
                    else
                    {
                        int size = this.internalSock.Receive(buffer);
                        if (size > 0)
                        {
                            this.externalSock.Send(buffer, 0, size, SocketFlags.None);
                        }
                        else
                        {
                            Thread.Sleep(5);
                        }
                    }
                }
                catch (SocketException)
                {
                    this.Disconnect();
                }
                catch
                {
                    this.Disconnect();
                }
            }
            this.Disconnect();
        }

        public void HandleInsanity(Socket sock)
        {
            byte i = ReceiveBytes(sock, 1)[0];
            while (i != 127)
            {
                switch ((i & 0xE0) >> 5)
                {
                    case 0:
                        ReceiveBytes(sock, 1); //1
                        break;
                    case 1:
                        ReceiveBytes(sock, 2); //2
                        break;
                    case 2:
                    case 3:
                        ReceiveBytes(sock, 4); //4
                        break;
                    case 4:
                        ReceiveString(sock); //S
                        break;
                    case 5:
                        ReceiveBytes(sock, 5); //2 + 1 + 2
                        break;
                }
                i = ReceiveBytes(sock, 1)[0];
            }
        }

        private void PingSocket(Socket sock)
        {
            this.SendPacket(0, new byte[0], sock);
        }

        private void PingThread()
        {
            while (this.externalSock.Connected && this.internalSock.Connected)
            {
                this.PingSocket(this.externalSock);
                this.PingSocket(this.internalSock);
                Thread.Sleep(0x1388);
            }
            this.Disconnect();
        }

        private byte[] ReceiveBytes(Socket sock, int bytes)
        {
            byte[] buffer = new byte[bytes];
            int size = bytes;
            int offset = 0;
            while (size > 0)
            {
                int num3 = sock.Receive(buffer, offset, size, SocketFlags.None);
                offset += num3;
                size -= num3;
            }
            if (sock == this.externalSock)
            {
                byte[] array = new byte[this.extBuffer.Length + bytes];
                this.extBuffer.CopyTo(array, 0);
                buffer.CopyTo(array, this.extBuffer.Length);
                this.extBuffer = array;
                return buffer;
            }
            if (sock == this.internalSock)
            {
                byte[] buffer3 = new byte[this.intBuffer.Length + bytes];
                this.intBuffer.CopyTo(buffer3, 0);
                buffer.CopyTo(buffer3, this.intBuffer.Length);
                this.intBuffer = buffer3;
            }
            return buffer;
        }

        private string ReceiveString(Socket sock)
        {
            int size = ByteArythmetic.GetInt16(this.ReceiveBytes(sock, 2), 0) * 2;
            return ByteArythmetic.EncodingUtf16.GetString(this.ReceiveBytes(sock, size));
        }

        private string ReceiveStringUtf8(Socket sock)
        {
            return ByteArythmetic.EncodingUtf8.GetString(this.ReceiveBytes(sock, ByteArythmetic.GetInt16(this.ReceiveBytes(sock, 2), 0)));
        }

        public void SendMessage(string msg)
        {
            //SendPacket(3, ByteArythmetic.StoA(string.Concat(new object[] { msg })), internalSock);
        }

        public void SendPacket(PacketBytes packet_id, byte[] data)
        {
            byte id = (byte)packet_id;
            this.SendPacket(id, data, this.externalSock);
        }

        public void SendPacket(byte packet_id, byte[] data)
        {
            this.SendPacket(packet_id, data, this.externalSock);
        }

        public void SendPacket(byte packet_id, byte[] data, Socket sock)
        {
            this.SendPacket(packet_id, data, sock, false);
        }

        public void SendPacket(byte packet_id, byte[] data, Socket sock, bool forcenow)
        {
            byte[] array = new byte[data.Length + 1];
            array[0] = packet_id;
            data.CopyTo(array, 1);
            if (forcenow)
            {
                sock.Send(array);
            }
            else if (sock == this.externalSock)
            {
                this.packetQueueExt.Enqueue(array);
            }
            else if (sock == this.internalSock)
            {
                this.packetQueueInt.Enqueue(array);
            }
            else
            {
                sock.Send(array);
            }
        }
    }
}

