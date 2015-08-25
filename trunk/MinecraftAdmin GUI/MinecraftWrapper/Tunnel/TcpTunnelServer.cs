using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;

namespace Vitt.Andre.Tunnel
{
    public class TcpTunnelServer
    {
        public TcpTunnelServer(MinecraftHandler mc)
        {            
            minecraftHandler = mc;
            serverSocket = new ServerSocket(this);
        }

        ServerSocket serverSocket;
        MinecraftHandler minecraftHandler;

        public MinecraftHandler MinecraftHandler
        {
            get { return minecraftHandler; }
            set { minecraftHandler = value; }
        }

        public ServerSocket ServerSocket
        {
            get { return serverSocket; }
            set { serverSocket = value; }
        }

        public delegate void OnChatMessageReceived(ClientSocket client, String message);
        public event OnChatMessageReceived ChatMessageReceived;


        private bool _isConnected = false;
        public Boolean IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                if (value)
                {
                    if (!_isConnected)
                    {
                        serverSocket.StartServer();
                        serverSocket.ChatMessageReceived -= new ServerSocket.OnChatMessageReceived(serverSocket_ChatMessageReceived);
                        serverSocket.ChatMessageReceived += new ServerSocket.OnChatMessageReceived(serverSocket_ChatMessageReceived);
                    }
                }
                else
                {
                    if (serverSocket != null)
                    {
                        serverSocket.Dispose();
                    }
                }
                _isConnected = value;
            }
        }

        void serverSocket_ChatMessageReceived(object sender, ClientSocket client, string message)
        {
            if (ChatMessageReceived != null)
            {
                ChatMessageReceived(client, message);
            }
        }

        int clientPort = 0; 
        int serverPort = 0;

        public int ClientPort
        {
            get { return clientPort; }
            set { clientPort = value; }
        }        

        public int ServerPort
        {
            get { return serverPort; }
            set { serverPort = value; }
        }
    }
}
