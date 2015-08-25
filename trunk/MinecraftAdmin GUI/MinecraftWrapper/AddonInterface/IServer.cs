using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftWrapper.AddonInterface
{
    public interface IServer
    {
        /// <summary>
        /// indicates wether the time of day gets overrided or not
        /// </summary>
        bool OverrideTimeOfDay { get; set; }

        /// <summary>
        /// the time of day as a long
        /// 1 hour = 1000
        /// 6:00 = 0
        /// 12:00 = 6000
        /// </summary>
        long TimeOfDay { get; set; }

        /// <summary>
        /// the real time of day as a long
        /// 1 hour = 1000
        /// 6:00 = 0
        /// 12:00 = 6000
        /// </summary>
        long RealTimeOfDay { get; set; }

        /// <summary>
        /// Sends a string message to all clients
        /// </summary>
        /// <param name="msg">the message to send</param>
        void SendServerMessage(string msg);

        /// <summary>
        /// Sends a string message to a specified client by name
        /// don't send empty strings!
        /// </summary>
        /// <param name="playerName">the name of a player to send the string to</param>
        /// <param name="msg">the message to send</param>
        void SendMessageToClient(string playerName, string msg);
        void SendMessageToClient(string playerName, string msg, char colorCode);

        /// <summary>
        /// finds a connected client by the name
        /// </summary>
        /// <param name="name">name of a client</param>
        /// <returns>the client or null</returns>
        IClient FindPlayer(string name);

        /// <summary>
        /// sends a command response for commands like who or rules or help
        /// </summary>
        /// <param name="playerName">the player to send to</param>
        /// <param name="msg">the message to send</param>
        void SendExecuteResponse(String playerName, string msg);
    }
}
