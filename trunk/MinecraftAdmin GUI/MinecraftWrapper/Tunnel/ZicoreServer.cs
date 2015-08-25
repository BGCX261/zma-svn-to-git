/*
    TCPComponents.NET
    Copyright (C) <2006>  <Mike Tyler>

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA 
*/

using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Vitt.Andre.TCPTunnelLib.Vitt.Andre.Tunnel;
using Vitt.Andre.TCPTunnelLib.Vitt.Andre.Tunnel.PacketResults;

namespace Vitt.Andre.Tunnel
{
    public class ZicoreServer
    {
        // Private properties
        private int port = 8888;
        private bool active = false;
        private static Thread mainThread;
        private static Hashtable stateObjectDictionary = new Hashtable();

        public readonly int InstanceID;
        private static int NextInstanceID = 0;
        private static long ClassInstanceCount = 0;

        // Delegates
        public delegate void OnConnectDelegate(Object sender, Socket socket);
        public delegate void OnDisconnectDelegate(Object sender, IPEndPoint peer);
        public delegate void OnDataSentDelegate(Object sender, Socket socket);
        public delegate void OnErrorDelegate(Object sender, string errorMessage);
        public delegate void OnByteDataAvailableDelegate(Object sender,Socket socket,PacketBytes id, byte[] data, int bytesRead);
        public delegate void OnStringReceivedDelegate(Object sender, Socket socket, String str, PacketBytes id, int size);
        //public delegate void OnUserLoginDelegate(Object sender, User user, ActionQuery aq);
        //public delegate void OnMessageReceiveDelegate(Object sender, User user, ActionQuery aq, String Message);
        //public delegate void OnClientKeyEventDelegate(Object sender, User user, String state);
        //public delegate void OnRegisterDelegate(Object sender, User user);
        //public delegate void OnFileAcceptDelegate(Object sender, User user, Boolean state);

        // Events
        public event OnConnectDelegate OnConnect;
        public event OnDisconnectDelegate OnDisconnect;
        public event OnDataSentDelegate OnDataSent;
        public event OnErrorDelegate OnError;
        public event OnByteDataAvailableDelegate OnByteDataAvailable;
        public event OnStringReceivedDelegate OnStringReceived;
        //public event OnUserLoginDelegate OnLogin;
        //public event OnMessageReceiveDelegate OnMessageReceive;
        //public event OnClientKeyEventDelegate OnClientKeyEvent;
        //public event OnRegisterDelegate OnRegister;
        //public event OnFileAcceptDelegate OnFileAccept;

        // Thread signal.
        public static ManualResetEvent mainDone = new ManualResetEvent(false);
        
        public ZicoreServer() {
            InstanceID = NextInstanceID++;
            ClassInstanceCount++;
        }

        ~ZicoreServer() {
            ClassInstanceCount--;
        }

        public static long InstanceCount
        {
            get { return ClassInstanceCount; }
        }

        public int Port
        {
            set { port = value; }
            get { return port; }
        }

        public bool Active
        {
            set {
                if (value == true)
                {
                    mainThread = new Thread(new ThreadStart(MainThread));
                    mainThread.IsBackground = true;
                    mainThread.Start();
                    active = value;
                }
                else
                {
                    active = value;
                    foreach (Socket socket in stateObjectDictionary.Values)
                    {
                        try
                        {
                            socket.Close();
                        }
                        catch (Exception e)
                        {
                            if (OnError != null)
                                OnError(this, e.ToString());
                            return;
                        }
                    }
                    stateObjectDictionary.Clear();
                }
            }
            get { return active; }
        }

        private void MainThread() {
            byte[] bytes = new Byte[1024];

            IPEndPoint localEndPoint = new IPEndPoint(0, this.port);

            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp );

            try {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (active) {
                    mainDone.Reset();

                    listener.BeginAccept(new AsyncCallback(AcceptCallback),listener);

                    while (active)
                        if (mainDone.WaitOne(100, true))
                            break;
                }
                listener.Close();

            } catch (Exception e) {
                if (OnError != null)
                    OnError(this, e.ToString());
            }
        }

        private void AcceptCallback(IAsyncResult ar) {
            mainDone.Set();

            Socket listener = (Socket) ar.AsyncState;
            Socket handler;
            try
            {
                handler = listener.EndAccept(ar);
            }
            catch { return; }

            if (OnConnect != null)
                OnConnect(this, handler);
            
            ServerState state = new ServerState();

            state.workSocket = handler;
            state.endPoint = (IPEndPoint) handler.RemoteEndPoint;
            stateObjectDictionary.Add(state, state.workSocket);
            try
            {                
                state.dynamicBuffer = new byte[state.bufferSize];
                handler.BeginReceive(state.dynamicBuffer, 0, state.bufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
            }
            catch (SocketException)
            {
            }
            catch (Exception ex)
            {
                if (OnError != null)
                    OnError(this, ex.ToString());
            }
        }

        public void ReadCallback(IAsyncResult ar) {
            String content = String.Empty;
            ServerState state = (ServerState) ar.AsyncState;
            Socket handler = state.workSocket;

            int bytesRead = 0;
            try
            {
                bytesRead = handler.EndReceive(ar);
            }
            catch (SocketException)
            {
                // Connection closed by peer
                if (OnDisconnect != null)
                    OnDisconnect(this, state.endPoint);
                return;
            }
            catch (ObjectDisposedException)
            {
                // Connection closed by client
                if (OnDisconnect != null)
                    OnDisconnect(this, state.endPoint);
                return;
            } 
            catch (Exception e)
            {
                if (OnError != null)
                    OnError(this, e.ToString());
                return;
            }

            if (bytesRead > 0) 
            {
                byte[] data = state.dynamicBuffer;
                PacketBytes firstByte = (PacketBytes)data[0];
                PacketSizes size = PacketSizes.Null;

                if (state.result == null)
                {
                    switch (firstByte)
                    {
                        case PacketBytes.KeepAlive_0x00:
                            size = PacketSizes.KeepAlive_0x00;
                            break;
                        case PacketBytes.Login_0x01:
                            size = PacketSizes.Login_0x01;
                            break;
                        case PacketBytes.Handshake_0x02:
                            size = PacketSizes.Handshake_0x02;
                            break;
                        case PacketBytes.Chat_0x03:
                            size = PacketSizes.Chat_0x03;
                            break;
                        case PacketBytes.UpdateTime_0x04:
                            size = PacketSizes.UpdateTime_0x04;
                            break;
                        case PacketBytes.Unkown01_0x0A:
                            size = PacketSizes.Unkown01_0x0A;
                            break;
                        case PacketBytes.PlayerPosition_0x0B:
                            size = PacketSizes.PlayerPosition_0x0B;
                            break;
                        case PacketBytes.PlayerLook_0x0C:
                            size = PacketSizes.PlayerLook_0x0C;
                            break;

                        case PacketBytes.PlayerMoveAndLook_0x0D:
                            size = PacketSizes.PlayerMoveAndLook_0x0D;
                            break;

                        case PacketBytes.PlaceBlock_0x0F:
                            size = PacketSizes.PlaceBlock_0x0F;
                            break;

                        case PacketBytes.BlockItemSwitch_0x10:
                            size = PacketSizes.BlockItemSwitch_0x10;
                            break;

                        case PacketBytes.AddToInventory_0x11:
                            size = PacketSizes.AddToInventory_0x11;
                            break;

                        case PacketBytes.ArmAnimation_0x12:
                            size = PacketSizes.ArmAnimation_0x12;
                            break;

                        case PacketBytes.EntitySpawnName_0x14:
                            size = PacketSizes.EntitySpawnName_0x14;
                            break;

                        case PacketBytes.EntitySpawn_0x15:
                            size = PacketSizes.EntitySpawn_0x15;
                            break;

                        case PacketBytes.CollectItem_0x16:
                            size = PacketSizes.CollectItem_0x16;
                            break;

                        case PacketBytes.Unkown02_0x17:
                            size = PacketSizes.Unkown02_0x17;
                            break;

                        case PacketBytes.MobSpawn_0x18:
                            size = PacketSizes.MobSpawn_0x18;
                            break;

                        case PacketBytes.DestroyEntity_0x1D:
                            size = PacketSizes.DestroyEntity_0x1D;
                            break;

                        case PacketBytes.Entity_0x1E:
                            size = PacketSizes.Entity_0x1E;
                            break;

                        case PacketBytes.RelativeEntityMove_0x1F:
                            size = PacketSizes.RelativeEntityMove_0x1F;
                            break;

                        case PacketBytes.EntityLook_0x20:
                            size = PacketSizes.EntityLook_0x20;
                            break;

                        case PacketBytes.RelativeEntityLookAndMove_0x21:
                            size = PacketSizes.RelativeEntityLookAndMove_0x21;
                            break;

                        case PacketBytes.EntityTeleport_0x22:
                            size = PacketSizes.EntityTeleport_0x22;
                            break;

                        case PacketBytes.ChunkPre_0x32:
                            size = PacketSizes.ChunkPre_0x32;
                            break;

                        case PacketBytes.ChunkMap_0x33:
                            size = PacketSizes.ChunkMap_0x33;
                            break;

                        case PacketBytes.MultiBlockChange_0x34:
                            size = PacketSizes.MultiBlockChange_0x34;
                            break;

                        case PacketBytes.BlockChange_0x35:
                            size = PacketSizes.BlockChange_0x35;
                            break;

                        case PacketBytes.Disconnect_0xFF:
                            size = PacketSizes.Disconnect_0xFF;
                            break;
                    }

                    if (size == PacketSizes.String)
                    {
                        if (state.result == null)
                        {
                            state.result = new StringResult(this, handler, state, firstByte, data,2);
                            state.result.Receive(); // erster einsprung
                        }
                        else
                        {
                            if (state.result.HasResult)
                            {
                                String result = (state.result as StringResult).ResultString;
                                state.result = null;
                            }
                            else
                            {
                                state.result.Receive(); // nächster einsprung
                            }
                        }
                    }

                    if (size == PacketSizes.String)
                    {
                        if (state.result == null)
                        {
                            state.result = new StringResult(this, handler, state, firstByte, data, bytesRead);
                            state.result.Receive(); // erster einsprung
                        }
                        else
                        {
                            if (state.result.HasResult)
                            {
                                String result = (state.result as StringResult).ResultString;
                                state.result = null;
                            }
                            else
                            {
                                state.result.Receive(); // nächster einsprung
                            }
                        }
                    }
                }                             

                if (OnByteDataAvailable != null)
                {
                    OnByteDataAvailable(this, handler,firstByte, data,bytesRead);
                }
            }
            else
            {
                // Connection closed by peer
                if (OnDisconnect != null)
                    OnDisconnect(this, state.endPoint);
            }
        }
        
        public void Send(Socket handler, byte[] data, int length)
        {
            try
            {
                byte[] byteData = data;
                handler.BeginSend(byteData, 0, length, 0,
                    new AsyncCallback(SendCallback), handler);
            }
            catch (Exception ex)
            {
                // Connection closed by client
                if (OnError != null)
                    OnError(this, ex.Message);
                return;
            }
        }

        public void Send(Socket handler, String data)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            Send(handler,byteData,byteData.Length);
        }

        private void SendCallback(IAsyncResult ar) {
            try {
                Socket handler = (Socket) ar.AsyncState;
                int bytesSent = handler.EndSend(ar);
                if (OnDataSent != null)
                    OnDataSent(this, handler);
            } catch (Exception e) {

                if (OnError != null)
                {
                    this.Active = false;
                    OnError(this, e.ToString());
                }
            }
        }
    }

    public class ServerState
    {
        public IPacketResult result = null;
        public PacketBytes lastId = PacketBytes.Null;
        public PacketSizes lastSize = PacketSizes.Null;
        public Socket workSocket = null;
        public StringBuilder sb = new StringBuilder();
        public IPEndPoint endPoint;
        public byte[] dynamicBuffer;
        public int bufferSize = 1;
    }
}
