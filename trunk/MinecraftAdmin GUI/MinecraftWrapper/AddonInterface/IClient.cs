using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.Player;
using Vitt.Andre.TCPTunnelLib.Vitt.Andre.Tunnel;
using System.Net.Sockets;
using MinecraftWrapper.Chat;

namespace MinecraftWrapper.AddonInterface
{
    public interface IClient
    {
        /// <summary>
        /// the name of the client
        /// </summary>
        String Name { get; set; }

        /// <summary>
        /// the clients ip
        /// </summary>
        String Ip { get; set; }

        /// <summary>
        /// the actual clients position
        /// </summary>
        XPosition Position { get; set; }

        /// <summary>
        /// Sends packets to the client with a specified packet id
        /// Warning sending bad packets result into crash!
        /// </summary>
        /// <param name="packet_id">the first byte as packet id use the enum!</param>
        /// <param name="data">the byte data use the PacketGenerator class</param>
        void SendPacket(PacketBytes packet_id, byte[] data);

        /// <summary>
        /// the connected client socket, use it to send custom packets to it
        /// but use it wisely!
        /// </summary>
        Socket ExternalSock { get; set; }

        /// <summary>
        /// Disconnects a client carefully
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Disconnects a client carefully with a reason
        /// </summary>
        void Disconnect(String reason);

        /// <summary>
        /// Sends a message to the server
        /// </summary>
        /// <param name="msg">the message which gets send to the server</param>
        void SendMessage(string msg);
    }
}
