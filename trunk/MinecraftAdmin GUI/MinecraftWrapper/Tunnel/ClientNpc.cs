using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Net.Sockets;
using Zicore.MinecraftAdmin;
using Vitt.Andre.Tunnel;
using MinecraftWrapper.WrapperEventArgs;
using MinecraftWrapper.Protocoll;
using Vitt.Andre.TCPTunnelLib.Vitt.Andre.Tunnel;
using MCAdmin;
using MinecraftWrapper.Player;
using Zicore.MinecraftAdmin.Commands;
using System.Net;
using System.Collections.Specialized;

namespace MinecraftWrapper.Tunnel
{
    public class ClientNpc
    {
        public ClientNpc(MinecraftHandler mc, String name, String password, String nameTo)
        {
            this.name = name;
            this.password = password;
            this.mc = mc;

            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            mc.Npcs[name] = this;
            teleportTo = nameTo;
        }

        private void Authenticate()
        {
            WebClient client = new WebClient();
            client.Proxy = null;
            NameValueCollection values = new NameValueCollection();
            values.Add("user", Name);
            values.Add("password", password);
            values.Add("version", "12");
            byte[] request = client.UploadValues("http://www.minecraft.net/game/getversion.jsp", "POST", values);
            String requestString = Encoding.ASCII.GetString(request);

            String[] array = requestString.Split(':');
            currentVersion = array[0];
            downloadTicker = array[1];
            username = array[2];
            sessionId = array[3];

            HttpWebRequest r =  Util.GetHttpWebRequest(String.Format("http://www.minecraft.net/game/joinserver.jsp?user={0}&sessionId={1}&serverId={2}", Name, sessionId, serverHash));
            WebResponse response = r.GetResponse();
            HttpWebRequest r2 = Util.GetHttpWebRequest(String.Format("http://www.minecraft.net/game/checkserver.jsp?user={0}&serverId={1}", Name, serverHash));
            response = r2.GetResponse();
        }

        public ClientNpc(MinecraftHandler mc, String name, String password)
            :this(mc,name,password,null)
        {

        }

        public override string ToString()
        {
            return String.Format("{0} {1}",Name, Position.ToString());
        }


        public void Move(int amount)
        {
            if (isConnected)
            {
                PacketGenerator gen = new PacketGenerator();
                gen.Add(PacketBytes._0x0D_PlayerMoveAndLook_0x0D);
                gen.Add((double)(position.X+amount));
                gen.Add(position.Stance);
                gen.Add(position.Y);                
                gen.Add(position.Z);
                gen.Add(position.Rotation);
                gen.Add(position.Pitch);
                gen.Add(position.Unkown);
                SendPackets(gen.ToByteArray());
            }
        }

        private void SendPackets(Byte[] data)
        {
            client.Client.Send(data);
        }

        String name = "Bot";

        public String Name
        {
            get { return name; }
        }

        String password = "";

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        String currentVersion = "";
        String downloadTicker = "";
        String username = "";
        String sessionId = "";

        bool teleported = false;
        MinecraftHandler mc;
        //TcpTunnelServer tcpTunnel;
        TcpClient client;
        BackgroundWorker worker = new BackgroundWorker();
        volatile bool isRunning = false;
        public event EventHandler<ClientExceptionEventArgs> ClientException;
        String teleportTo;
        byte[] extBuffer = new byte[500];
        bool handShakeSendToServer = false;
        bool handShakeReceived = false;
        bool loginRequestSend = false;
        bool loginRequestReceived = false;
        XPosition position = new XPosition();

        public XPosition Position
        {
            get { return position; }
            set { position = value; }
        }
        bool moveAndLookReceived = false;

        String serverHash = "";
        int entityId = -1;
        long mapSeed = -1;
        byte dimension = 0;

        public void Connect()
        {
            if (!worker.IsBusy)
            {
                IsRunning = true;
                worker.RunWorkerAsync();
            }
        }

        public void Disconnect()
        {
            IsConnected = false;
            try
            {
                client.Client.Disconnect(false);
            }
            catch (Exception ex)
            {
                AddOutput(ex.Message);
            }
            try
            {
                client.Client.Close();
            }
            catch (Exception ex)
            {
                AddOutput(ex.Message);
            }

            try
            {
                client.Close();
            }
            catch
            {
                
            }
            handShakeSendToServer = false;
            handShakeReceived = false;
            loginRequestSend = false;
            loginRequestReceived = false;

            mc.Npcs.Remove(name);

            worker.CancelAsync();           
        }

        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }

        volatile bool isConnected = false;

        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }

        volatile bool isClientSocketConnected = true;

        public bool IsClientSocketConnected
        {
            get { return isClientSocketConnected; }
            set { isClientSocketConnected = value; }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }


        private void AddOutput(String message)
        {
            if (ClientException != null)
            {
                ClientException(this, new ClientExceptionEventArgs(message));
            }
        }

        private void Handshake()
        {
            serverHash = ReceiveString(client.Client);
            AddOutput(String.Format("Serverhash: {0}", serverHash));
            if (serverHash == "+")
            {
                PacketGenerator gen = new PacketGenerator();
                gen.Add(PacketBytes._0x01_Login_0x01);
                gen.Add(11); //protocol version
                gen.Add(Name);
                gen.Add((long)0);
                gen.Add((byte)0);
                client.Client.Send(gen.ToByteArray());
                handShakeSendToServer = true;
                loginRequestSend = true;
            }
            else if (serverHash == "-")
            {
                PacketGenerator gen = new PacketGenerator();
                gen.Add(PacketBytes._0x01_Login_0x01);
                gen.Add(11); //protocol version
                gen.Add(Name);
                gen.Add((long)0);
                gen.Add((byte)0);
                client.Client.Send(gen.ToByteArray());
                handShakeSendToServer = true;
                loginRequestSend = true;
            }
            else
            {
                Authenticate();

                PacketGenerator gen = new PacketGenerator();
                gen.Add(PacketBytes._0x01_Login_0x01);
                gen.Add(11); //protocol version
                gen.Add(Name);
                gen.Add((long)0);
                gen.Add((byte)0);
                client.Client.Send(gen.ToByteArray());
                handShakeSendToServer = true;
                loginRequestSend = true;
            }
            handShakeReceived = true;
        }

        private void LoginRequest()
        {
            entityId = ByteArythmetic.GetInt32(ReceiveBytes(4), 0);
            ReceiveString(client.Client); // not used yet
            mapSeed = ByteArythmetic.GetInt64(ReceiveBytes(8), 0);
            dimension = ByteArythmetic.GetByte(ReceiveBytes(1), 0);

            AddOutput("EntityID: " + entityId);
            AddOutput("Map Seed: " + mapSeed);
            AddOutput("Dimension: " + dimension);
            loginRequestReceived = true;
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

        private void Receive()
        {
            if (!handShakeSendToServer)
            {
                PacketGenerator gen = new PacketGenerator();
                gen.Add((byte)PacketBytes._0x02_Handshake_0x02);
                gen.Add(Name);
                client.Client.Send(gen.ToByteArray());
                handShakeSendToServer = true;
            }

            extBuffer = ReceiveBytes(client.Client, 1);
            
            PacketBytes firstByte = (PacketBytes)extBuffer[0];
            PacketSizes size = MinecraftEnums.GetPacketSize(firstByte);
            if (size != PacketSizes.Minus_1)
            {
                if (firstByte == PacketBytes._0x0D_PlayerMoveAndLook_0x0D)
                {
                    size = PacketSizes.Minus_1;
                }
                if (firstByte == PacketBytes._0x03_Chat_0x03)
                {
                    size = PacketSizes.Minus_1;
                }

                if (size != PacketSizes.Minus_1)
                {
                    ReceiveBytes((int)size);
                }
            }
            
            if(size == PacketSizes.Minus_1)
            {
                switch (firstByte)
                {
                    case PacketBytes.Minues_1:
                        break;
                    case PacketBytes._0x00_KeepAlive_0x00:
                        break;
                    case PacketBytes._0x01_Login_0x01:
                        if (!loginRequestReceived)
                        {
                            LoginRequest();
                        }
                        break;
                    case PacketBytes._0x02_Handshake_0x02:
                        if (!handShakeReceived)
                        {
                            Handshake();
                        }
                        break;
                    case PacketBytes._0x03_Chat_0x03:
                        String chat = ReceiveString(client.Client);
                        AddOutput("Chat: " + chat);
                        break;
                    case PacketBytes._0x04_UpdateTime_0x04:
                        ReceiveInt64();
                        break;
                    case PacketBytes._0x05_EntityEquipment_01_0x05:
                        ReceiveInt32();
                        ReceiveInt16();
                        ReceiveInt16();
                        ReceiveInt16();
                        break;
                    case PacketBytes._0x06_SpawnPosition_02_0x06:
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveInt32();
                        break;
                    case PacketBytes._0x07_Use_Entity_0x07:
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveBoolean();
                        break;
                    case PacketBytes._0x08_Health_0x08:
                        short health = ReceiveInt16();
                        if (health <= 0)
                        {
                            PacketGenerator gen = new PacketGenerator();
                            gen.Add(PacketBytes._0x08_Health_0x08);
                            client.Client.Send(gen.ToByteArray());
                        }
                        break;
                    case PacketBytes._0x09_Respawn_0x09:
                        break;
                    case PacketBytes._0x0A_Player_0x0A:
                        break;
                    case PacketBytes._0x0B_PlayerPosition_0x0B:
                        break;
                    case PacketBytes._0x0C_PlayerLook_0x0C:

                        break;
                    case PacketBytes._0x0D_PlayerMoveAndLook_0x0D:
                        position.X = Util.AtoD(ReceiveBytes(8), 0);
                        position.Y = Util.AtoD(ReceiveBytes(8), 0);
                        position.Stance = Util.AtoD(ReceiveBytes(8), 0);
                        position.Z = Util.AtoD(ReceiveBytes(8), 0);
                        position.Rotation = Util.AtoF(ReceiveBytes(4), 0);
                        position.Pitch = Util.AtoF(ReceiveBytes(4), 0);
                        position.Unkown = ByteArythmetic.GetBoolean(ReceiveBytes(1), 0);
                        moveAndLookReceived = true;
                        Move(0);
                        break;
                    case PacketBytes._0x0E_BlockDig_0x0E:
                        break;
                    case PacketBytes._0x0F_PlaceBlock_0x0F:
                        break;
                    case PacketBytes._0x10_BlockItemSwitch_0x10:
                        ReceiveBytes(2);
                        break;
                    case PacketBytes._0x11_UseBed_0x11:
                        ReceiveInt32();
                        ReceiveByte();
                        ReceiveInt32();
                        ReceiveByte();
                        ReceiveInt32();
                        break;
                    case PacketBytes._0x12_ArmAnimation_0x12:
                        ReceiveInt32();
                        ReceiveByte();
                        break;
                    case PacketBytes._0x13_NewPacket_0x13:
                        ReceiveBytes(5);
                        break;
                    case PacketBytes._0x14_EntitySpawnName_0x14:
                        ReceiveInt32();
                        ReceiveString(client.Client);
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveByte();
                        ReceiveByte();
                        ReceiveInt16();
                        break;
                    case PacketBytes._0x15_EntitySpawn_0x15:
                        ReceiveInt32();
                        ReceiveInt16();
                        ReceiveByte();
                        ReceiveInt16();
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveByte();
                        ReceiveByte();
                        ReceiveByte();
                        break;
                    case PacketBytes._0x16_CollectItem_0x16:
                        ReceiveInt32();
                        ReceiveInt32();
                        break;
                    case PacketBytes._0x17_AddObject_0x17:
                        ReceiveBytes(client.Client, 17);
                        if (Util.AtoI(ReceiveBytes(client.Client, 4), 0) > 0)
                        {
                            ReceiveBytes(client.Client, 6);
                        }
                        break;
                    case PacketBytes._0x18_MobSpawn_0x18:
                        ReceiveInt32();
                        ReceiveByte();
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveByte();
                        ReceiveByte();
                        HandleInsanity(client.Client);
                        break;
                    case PacketBytes._0x1B_NewPacket:
                        ReceiveFloat();
                        ReceiveFloat();
                        ReceiveFloat();
                        ReceiveFloat();
                        ReceiveBoolean();
                        ReceiveBoolean();
                        break;
                    case PacketBytes._0x1C_EntityVelocity_0x1C:
                        ReceiveInt32();
                        ReceiveInt16();
                        ReceiveInt16();
                        ReceiveInt16();
                        break;
                    case PacketBytes._0x1D_DestroyEntity_0x1D:
                        ReceiveInt32();
                        break;
                    case PacketBytes._0x1E_Entity_0x1E:
                        ReceiveInt32();
                        break;
                    case PacketBytes._0x1F_RelativeEntityMove_0x1F:
                        ReceiveInt32();
                        ReceiveByte();
                        ReceiveByte();
                        ReceiveByte();
                        break;
                    case PacketBytes._0x19_NewPacket_0x19:
                        ReceiveInt32();
                        ReceiveString(client.Client);
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveInt32();
                        break;
                    case PacketBytes._0x20_EntityLook_0x20:
                        ReceiveInt32();
                        ReceiveByte();
                        ReceiveByte();
                        break;
                    case PacketBytes._0x21_RelativeEntityLookAndMove_0x21:
                        ReceiveInt32();
                        ReceiveByte();
                        ReceiveByte();
                        ReceiveByte();
                        ReceiveByte();
                        ReceiveByte();
                        break;
                    case PacketBytes._0x22_EntityTeleport_0x22:
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveByte();
                        ReceiveByte();
                        break;
                    case PacketBytes._0x26_HitEntity_0x26:
                        ReceiveInt32();
                        ReceiveByte();
                        break;
                    case PacketBytes._0x27_AttachEntity_0x27:
                        ReceiveInt32();
                        ReceiveInt32();
                        break;
                    case PacketBytes._0x28_NewPacket_0x28:
                        ReceiveInt32();
                        HandleInsanity(client.Client);
                        break;
                    case PacketBytes._0x32_ChunkPre_0x32:
                        ReceiveInt32();
                        ReceiveInt32();
                        ReceiveBoolean();
                        break;
                    case PacketBytes._0x33_ChunkMap_0x33:
                        ReceiveInt32();
                        ReceiveInt16();
                        ReceiveInt32();
                        ReceiveByte();
                        ReceiveByte();
                        ReceiveByte();
                        int chunkSize = ReceiveInt32();
                        ReceiveBytes(chunkSize);
                        break;
                    case PacketBytes._0x34_MultiBlockChange_0x34:
                        this.ReceiveBytes(8);
                        this.ReceiveBytes(ByteArythmetic.GetInt16(this.ReceiveBytes(2), 0) * 4);
                        break;
                    case PacketBytes._0x35_BlockChange_0x35:
                        ReceiveBytes(11);
                        break;
                    case PacketBytes._0x36_BlockAction_0x36:
                        ReceiveBytes(12);
                        break;
                    case PacketBytes._0x3C_Explosion_0x3C:
                        ReceiveBytes(28); //8 + 8 + 8 + 4
                        ReceiveBytes(ByteArythmetic.GetInt32(ReceiveBytes(4), 0) * 3);
                        break;
                    case PacketBytes._0x46_InvalidBed_0x46:
                        ReceiveByte();
                        break;
                    case PacketBytes._0x47_Weather_0x47:
                        ReceiveBytes(17);
                        break;
                    case PacketBytes._0x64_OpenWindow_0x64:
                        ReceiveBytes(2);
                        ReceiveStringUtf8(client.Client); // UTF8
                        ReceiveBytes(1);
                        break;
                    case PacketBytes._0x65_CloseWindow_0x65:
                        ReceiveBytes(1);
                        break;
                    case PacketBytes._0x66_WindowClick_0x66:
                        ReceiveBytes(7); // Update 1.5 + 1 bool
                        if (Util.AtoN(ReceiveBytes(2), 0) >= 0) ReceiveBytes(3);
                        break;
                    case PacketBytes._0x67_SetSlot_0x67:
                        ReceiveBytes(3);
                        if (Util.AtoN(ReceiveBytes(2), 0) >= 0) ReceiveBytes(3);
                        break;
                    case PacketBytes._0x68_WindowItems_0x68:
                        short xmax = Util.AtoN(ReceiveBytes(3), 1);
                        for (short cx = 0; cx < xmax; cx++)
                        {
                            if (Util.AtoN(ReceiveBytes(2), 0) >= 0)
                            {
                                ReceiveBytes(3);
                            }
                        }
                        break;
                    case PacketBytes._0x69_UpdateProgressBar_0x69:
                        ReceiveBytes(5);
                        break;
                    case PacketBytes._0x6A_Transaction_0x6A:
                        ReceiveBytes(4);
                        break;
                    case PacketBytes._0x82_UpdateSign_0x82:
                        ReceiveBytes(10);
                        ReceiveString(client.Client);
                        ReceiveString(client.Client);
                        ReceiveString(client.Client);
                        ReceiveString(client.Client);
                        break;
                    case PacketBytes._0x83_MapData_0x83:
                        {
                            ReceiveBytes(client.Client, 4);
                            ReceiveBytes(client.Client, Util.AtoI(ReceiveBytes(client.Client, 1), 0));
                        }
                        break;
                    case PacketBytes._0xC8_IncrementStatistics_0xC8:
                        ReceiveBytes(5);
                        break;
                    case PacketBytes._0xFF_Disconnect_0xFF:
                        String str =ReceiveString(client.Client);
                        AddOutput("NPC Disconnected: " + str);
                        break;
                    default:
                        break;
                }
            }
        }

        private short ReceiveInt16()
        {
            return ByteArythmetic.GetInt16(ReceiveBytes(2), 0);
        }

        private int ReceiveInt32()
        {
            return ByteArythmetic.GetInt32(ReceiveBytes(4),0);
        }

        private long ReceiveInt64()
        {
            return ByteArythmetic.GetInt64(ReceiveBytes(8), 0);
        }

        private double ReceiveDouble()
        {
            return ByteArythmetic.GetDouble(ReceiveBytes(8), 0);
        }

        private float ReceiveFloat()
        {
            return ByteArythmetic.GetFloat(ReceiveBytes(4), 0);
        }

        private bool ReceiveBoolean()
        {
            return ByteArythmetic.GetBoolean(ReceiveBytes(1), 0);
        }

        private byte ReceiveByte()
        {
            return ByteArythmetic.GetByte(ReceiveBytes(1), 0);
        }

        private byte[] ReceiveBytes(int bytes)
        {
            return ReceiveBytes(client.Client, bytes);
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
            if (sock == this.client.Client)
            {
                byte[] array = new byte[this.extBuffer.Length + bytes];
                this.extBuffer.CopyTo(array, 0);
                buffer.CopyTo(array, this.extBuffer.Length);
                this.extBuffer = array;
                return buffer;
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

        public void SpeakThrough(String message)
        {
            if (IsConnected)
            {
                PacketGenerator gen = new PacketGenerator();
                gen.Add(PacketBytes._0x03_Chat_0x03);
                gen.Add(message);
                SendPackets(gen.ToByteArray());
            }
        }

        int ticker = 0;
        int tickerMax = 1000;
        int tickerMovement = 0;
        int tickerMovementMax = 50;

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (IsRunning)
            {
                if (!IsConnected)
                {
                    client = new TcpClient();
                    client.ReceiveTimeout = 10000;
                    client.SendTimeout = 10000;

                    try
                    {
                        client.Connect("localhost", mc.Config.ExternalPort);
                        IsConnected = true;
                    }
                    catch (Exception ex)
                    {
                        if (ClientException != null)
                        {
                            ClientException(this, new ClientExceptionEventArgs(ex));
                            Disconnect();
                            break;
                        }
                    }
                }
                else
                {
                    try
                    {
                        Receive();
                        if (ticker >= tickerMax)
                        {
                            PacketGenerator gen = new PacketGenerator();
                            gen.Add(PacketBytes._0x00_KeepAlive_0x00);
                            client.Client.Send(gen.ToByteArray());

                            if (moveAndLookReceived && !teleported)
                            {
                                teleported = true;
                                if (teleportTo != null)
                                {
                                    CommandTo cmd = new CommandTo(mc);
                                    cmd.TriggerPlayer = Name;
                                    cmd.Execute(teleportTo, "", "", "");
                                }
                            }

                            ticker = 0;
                        }
                        ticker++;
                        if (tickerMovement >= tickerMovementMax)
                        {
                            Move(0);

                            tickerMovement = 0;                            
                        }
                        tickerMovement++;                        
                    }
                    catch (Exception ex)
                    {
                        if (ClientException != null)
                        {
                            ClientException(this, new ClientExceptionEventArgs(ex));
                        }
                        try
                        {
                            Disconnect();
                            break;
                        }
                        catch (Exception ex2)
                        {
                            if (ClientException != null)
                            {
                                ClientException(this, new ClientExceptionEventArgs(ex2));
                            }
                        }
                    }
                }
                if (worker.CancellationPending)
                {
                    Disconnect();
                    break;
                }
                Thread.Sleep(1);
            }
            IsConnected = false;
        }
    }
}
