using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.AddonInterface;
using Vitt.Andre.TCPTunnelLib.Vitt.Andre.Tunnel;
using Zicore.MinecraftAdmin.IO;
using MinecraftWrapper.WebInterface;
using MinecraftWrapper.ExternalComponents;
using Zicore.MinecraftAdmin.Admins;
using Zicore.MinecraftAdmin.Commands;
using MinecraftWrapper.MainClasses;
using MinecraftWrapper.Chat;

namespace Vitt.Andre.Tunnel
{
    public class ServerSocket : IServer
    {
        long timeOfDay = 0;

        public long TimeOfDay
        {
            get { return timeOfDay; }
            set { timeOfDay = value; }
        }

        long realTimeOfDay = 0;

        public long RealTimeOfDay
        {
            get { return realTimeOfDay; }
            set { realTimeOfDay = value; }
        }

        bool firstLine = false;

        public bool FirstLine
        {
            get { return firstLine; }
            set { firstLine = value; }
        }

        bool overrideTimeOfDay = false;

        public bool OverrideTimeOfDay
        {
            get { return overrideTimeOfDay; }
            set { overrideTimeOfDay = value; }
        }

        private Thread serverThread;

        public Thread ServerThread
        {
            get { return serverThread; }
            set { serverThread = value; }
        }
        private TcpListener externalListener;

        public TcpListener ExternalListener
        {
            get { return externalListener; }
            set { externalListener = value; }
        }


        public int intport;
        private List<ClientSocket> clients = new List<ClientSocket>();

        public List<ClientSocket> Clients
        {
            get { return clients; }
            set { clients = value; }
        }

        public static string GetServerIP(String url)
        {
            using (WebClient client = new WebClient())
            {
                string ip = client.DownloadString(url);
                return ip;
            }
        }


        ChannelCollection channels = new ChannelCollection();

        public ChannelCollection Channels
        {
            get { return channels; }
            set { channels = value; }
        }
        //public delegate void OnServerLoaded(IMinecraftHandler mc, IServer server);
        //public event OnServerLoaded OnServerLoaded;
        DatabaseWorker databaseWorker = new DatabaseWorker(false);

        public DatabaseWorker DatabaseWorker
        {
            get { return databaseWorker; }
            set { databaseWorker = value; }
        }

        public void StartServer()
        {
            try
            {
                string internalIp = Tunnel.MinecraftHandler.Config.ServerIp;

                int port = tunnel.ServerPort;
                this.intport = tunnel.ClientPort;
                if (externalListener == null)
                {
                    //this.externalListener = new TcpListener(IPAddress.Parse(internalIp), port);
                    this.externalListener = new TcpListener(IPAddress.Any, port);
                }
                

                this.externalListener.Server.SendTimeout = 1000;
                this.externalListener.Server.ReceiveTimeout = 1000;
                try
                {
                    this.externalListener.Start(5);
                }
                catch
                {

                }
                

                this.serverThread = new Thread(new ThreadStart(this.ServerMainThread));
                this.serverThread.Start();

                //databaseWorker.Start();
                //Tunnel.MinecraftHandler.TimerCommandReader.Tick += new EventHandler(TimerCommandReader_Tick);

                foreach (IPlugin p in this.Tunnel.MinecraftHandler.Plugins)
                {
                    p.OnServerLoaded(Tunnel.MinecraftHandler, this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nMaybe try to stop the server, deactivate tunnel, start the server and start the tunnel");
            }
        }

        public ServerSocket(TcpTunnelServer tunnel)
        {
            this.Tunnel = tunnel;

            Tunnel.MinecraftHandler.PlayerKicked += new MinecraftHandler.OnPlayerKicked(MinecraftHandler_PlayerKicked);
            Tunnel.MinecraftHandler.TimerCommandReader.Tick += new EventHandler(TimerCommandReader_Tick);
            Tunnel.MinecraftHandler.ExecuteMODT += new MinecraftHandler.OnExecuteMODT(MinecraftHandler_ExecuteMODT);
            Tunnel.MinecraftHandler.PlayerJoined += new MinecraftHandler.OnPlayerjoined(MinecraftHandler_PlayerJoined);

            Channels.AddChannel(defaultChannel);
        }

        Channel defaultChannel = new Channel("*");

        void MinecraftHandler_PlayerJoined(object sender, string player)
        {
            User user = UserCollectionSingletone.GetInstance().GetUserByName(player);
            if (user.Generated)
            {
                user = new User(player, false);
                user.LevelID = 0;
                UserCollectionSingletone.GetInstance().Add(user);
                UserCollectionSingletone.GetInstance().Save();
            }

            List<Channel> channels = Channels.FindAll(x => x.User.IsInlist(player));
            if (channels.Count <= 0)
            {
                defaultChannel.User.Add(user);
                if (Tunnel.MinecraftHandler.Config.ChannelModeChat)
                {
                    SendExecuteResponse(player, "You joined the default channel");
                }
            }
        }

        void MinecraftHandler_ExecuteMODT(string[] lines, string text)
        {
            Command cmd = new CommandMODT(Tunnel.MinecraftHandler);
            cmd.TriggerPlayer = text;
            cmd.Server = this;
            
            cmd.Execute(text, "", "", "");
        }

        LockFreeQueue<WebActionCommand> webCommands = new LockFreeQueue<WebActionCommand>();

        public LockFreeQueue<WebActionCommand> WebCommands
        {
            get { return webCommands; }
            set { webCommands = value; }
        }

        void TimerCommandReader_Tick(object sender, EventArgs e)
        {
            //try
            //{

            //        ZmaSQLConnection sql = new ZmaSQLConnection();
            //        sql.GetCommands(Tunnel.MinecraftHandler, webCommands);
                
            //}
            //catch
            //{
            //    Log.Append(this, "SQL Connection", Log.ExceptionsLog);
            //}

            //try
            //{
            //    WebActionCommand cmd;
            //    while (WebCommands.Dequeue(out cmd))
            //    {
            //        ActionCommand(cmd.Message, cmd.User, "Web");
            //    }
            //}
            //catch
            //{

            //}
        }

        public CommandResult ActionCommand(String message, User user, String remoteName)
        {
            bool tunnelMessage = true;
            string text = message;
            MinecraftHandler mc = Tunnel.MinecraftHandler;
            String name = user.Name;
            List<String> players = mc.Player;
            UserCollectionSingletone userCollection = UserCollectionSingletone.GetInstance();
            CommandResult cmdResult = new CommandResult(false, "");
            if (text.Length > 0)
            {
                if (text[0] == mc.Config.CommandChar[0])
                {
                    string commandRegexPattern = String.Format(@"{0}(?<cmd>[a-zA-Z]+) ?(?<arg1>.+)?", mc.Config.CommandChar);
                    Regex commandRegex = new Regex(commandRegexPattern);
                    Match match = commandRegex.Match(text);

                    string regCommand = "";
                    string regArg1 = "";

                    if (match.Success)
                    {
                        try
                        {
                            tunnelMessage = false;
                            regCommand = match.Groups["cmd"].Value;
                            regArg1 = match.Groups["arg1"].Value;

                            if (mc != null && mc.Started)
                            {
                                cmdResult = mc.CommandHandlerExternal(name, regCommand, regArg1, null, this);
                                if (cmdResult != null && cmdResult.HasResult)
                                {
                                    if (mc.Config.CommandExecutedResponse)
                                    {
                                        if (user.Level.OwnExecuteResponse)
                                        {
                                            SendExecuteResponse(user.Name, cmdResult.Message);
                                        }
                                        foreach (User u in userCollection.Items)
                                        {
                                            if (user != u)
                                            {
                                                if (u.Level.OtherExecuteResponse)
                                                {
                                                    if (mc.IsStringInList(u.Name, players))
                                                    {
                                                        SendExecuteResponse(u.Name, cmdResult.Message);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    SendExecuteResponse(name, String.Format("Unknown command {0}", text));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            SendExecuteResponse(name, String.Format("Exception while executing ask Zicore :)", text));
                            Log.AppendText(ex.Message, Log.ExceptionsLog);
                        }
                    }
                }
                
            }

            if (tunnelMessage && text[0] != '/')
            {
                tunnelMessage = false;
                char lineColor = 'f';
                if (FirstLine)
                {
                    lineColor = mc.Config.LineFirstColorKey;
                }
                else
                {
                    lineColor = mc.Config.LineSecondColorKey;
                }

                FirstLine = !FirstLine;

                SendServerMessage(String.Format("§f<§{0}{1}§{2} [§6{3}§f]> §{4}{5}", user.Level.GroupColor, name, 'F', remoteName, lineColor, text));

                //ZmaSQLConnection sql = new ZmaSQLConnection();
                //sql.AddChatMessage(name, text, mc);
            }
            return cmdResult;
        }

        void MinecraftHandler_PlayerKicked(object sender, string player, string message)
        {
            IClient client = FindPlayer(player);
            if (client != null)
            {
                client.Disconnect(message);
            }
        }

        private void RaiseChatmessage(String msg)
        {
            if (ChatMessageReceived != null)
            {
                ChatMessageReceived(this, null, msg);
            }
        }

        TcpTunnelServer tunnel;

        public TcpTunnelServer Tunnel
        {
            get { return tunnel; }
            set { tunnel = value; }
        }

        //ClientSocket clientBot = null;

        private void ServerMainThread()
        {
            while (Tunnel.IsConnected)
            {
                try
                {
                    if (this.externalListener.Pending())
                    {
                        ClientSocket client = new ClientSocket(this.externalListener.AcceptSocket(), this);
                        client.ChatMessageReceived -= new ClientSocket.OnChatMessageReceivedDelegate(client_ChatMessageReceived);
                        client.ChatMessageReceived += new ClientSocket.OnChatMessageReceivedDelegate(client_ChatMessageReceived);
                    }
                }
                catch
                {
                   // RaiseChatmessage(ex.Message);
                }
                //if (clientBot == null)
                //{
                    
                //}
                Thread.Sleep(150);
            }
        }

        void client_ChatMessageReceived(object sender, ClientSocket client, string message)
        {
            ChatMessageReceived(this, client, message);
        }

        public delegate void OnChatMessageReceived(object sender, ClientSocket client, string message);
        public event OnChatMessageReceived ChatMessageReceived;

        public void Dispose()
        {
            databaseWorker.Stop();
            try
            {
                List<ClientSocket> list = new List<ClientSocket>(this.clients);
                foreach (ClientSocket player in list)
                {
                    try
                    {
                        player.Disconnect();
                        continue;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            catch
            {
            }
            try
            {
                externalListener.Stop();
            }
            catch
            {
            }

            try
            {
                this.serverThread.Abort();
            }
            catch
            {
            }
            
        }

        ~ServerSocket()
        {
            this.Dispose();
            
        }

        public void SendMessageToClient(string playerName, string msg)
        {
            this.SendMessageToClient(playerName, msg, 'a');
        }

        public void SendExecuteResponse(String playerName, string msg)
        {
            MinecraftHandler mc = Tunnel.MinecraftHandler;
            String text = String.Format("{0} \x00c2\x00a7{1}{2}", mc.Config.ResponsePrefix, mc.Config.ResponseColorChar, msg);
            this.SendMessageToClient(playerName, text, mc.Config.ResponseColorChar);
        }

        public void SendPacketToClient(PacketBytes packet, String playerName, Byte[] data)
        {
            ClientSocket player = this.FindPlayer(playerName) as ClientSocket;
            if (player != null)
            {
                player.SendPacket(packet, data);
            }
        }

        public void SendMessageToClient(string playerName, string msg, char colorCode)
        {
            ClientSocket player = this.FindPlayer(playerName) as ClientSocket;
            if (player == null)
            {
                this.SendServerMessage(msg, colorCode);
            }
            else
            {
                String message = string.Concat(new object[] { "\x00c2\x00a7" + colorCode, msg });
                foreach (var item in CreateList(message, 119))
                {
                    player.SendPacket(3, ByteArythmetic.StoA(item));
                }
            }
        }

        public void SendServerMessage(string msg)
        {
            MinecraftHandler mc = Tunnel.MinecraftHandler;
            this.SendServerMessage(msg, mc.Config.ServerBroadcastColorChar);
        }

        public List<String> CreateList(String str, int max)
        {
            List<string> list = new List<string>();

            int parts = str.Length / max;
            int lastSize = str.Length % max;
            if (lastSize != 0)
                parts++;
            int offset = 0;
            for (int i = 0; i < parts; i++)
            {
                if (i + 1 != parts && parts != 1)
                {
                    list.Add(str.Substring(offset, max));
                    offset += max;
                }
                else if (parts == 1 && lastSize == 0)
                {
                    list.Add(str.Substring(offset, max));
                    offset += max;
                }
                else
                {
                    list.Add(str.Substring(offset, lastSize));
                    offset += lastSize;
                }
            }

            return list;
        }

        public void SendServerMessage(string msg, char colorCode)
        {
            foreach (ClientSocket player in this.Clients)
            {
                String message = string.Concat(new object[] { "§" + colorCode, msg });

                foreach (var item in CreateList(message,119))
                {
                    player.SendPacket(3, ByteArythmetic.StoA(item));    
                }
            }
        }

        public void SendChannelMessage(string msg, ClientSocket sender)
        {
            MinecraftHandler mc = Tunnel.MinecraftHandler;
            char colorCode = mc.Config.ServerBroadcastColorChar;
            List<Channel> channels = Channels.FindAll(x => x.User.IsInlist(sender.Name));
            UserCollection users = new UserCollection();

            foreach (Channel c in channels)
            {
                foreach (User u in c.User)
                {
                    if (mc.IsStringInList(u.Name, mc.Player))
                    {
                        if (!users.IsInlist(u))
                        {
                            users.Add(u);
                        }
                    }
                }
            }

            foreach (User player in users)
            {
                ClientSocket client = (ClientSocket)FindPlayer(player.Name);
                if (client != null)
                {
                    String message = string.Concat(new object[] { "§" + colorCode, msg });
                    foreach (var item in CreateList(message, 119))
                    {
                        client.SendPacket(3, ByteArythmetic.StoA(item));
                    }
                }
            }
        }

        public void SendInternalPacket(PacketBytes byteId, byte[] data, ClientSocket player)
        {
            player.SendPacket((byte)byteId, data, player.InternalSock, false);
        }

        //public void SendServerMessage(string msg)
        //{
        //    MinecraftHandler mc = Tunnel.MinecraftHandler;
        //    this.SendServerMessage(msg, '1');
        //}

        //public void SendServerMessage(string msg, char colorCode)
        //{
        //    foreach (ClientSocket player in this.Clients)
        //    {
        //        player.SendPacket((byte)PacketBytes._0x03_Chat_0x03, ByteArythmetic.StoA(msg), player.InternalSock, false);
        //    }
        //}

        //public ClientSocket FindPlayer(string name)
        //{
        //    foreach (ClientSocket player in this.clients)
        //    {
        //        if (player.Name.ToLower() == name.ToLower())
        //        {
        //            return player;
        //        }
        //    }
        //    return null;
        //}

        public IClient FindPlayer(string name)
        {
            foreach (IClient player in this.clients)
            {
                if (player.Name.ToLower() == name.ToLower())
                {
                    return player;
                }
            }
            return null;
        }
    }
}

