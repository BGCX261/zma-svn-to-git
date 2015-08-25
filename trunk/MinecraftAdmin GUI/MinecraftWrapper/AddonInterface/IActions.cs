using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin.Commands;
using MinecraftWrapper.Player;

namespace MinecraftWrapper.AddonInterface
{
    public interface IActions
    {
        /// <summary>
        /// gets executed when a user sends a chat message
        /// </summary>
        /// <param name="server">server interface for access to send functions and more</param>
        /// <param name="client">client interface for some send functions and more</param>
        void OnChatMessage(IServer server,IClient client, String message, ref bool tunnelMessage);

        /// <summary>
        /// gets executed when a user sends a chat message
        /// </summary>
        /// <param name="server">server interface for access to send functions and more</param>
        /// <param name="client">client interface for some send functions and more</param>
        void OnBlockPlacing(IServer server, IClient client, short blockId, ref bool tunnelPlacing);


        
        /// <summary>
        /// use it to send messages to the server for example
        /// </summary>
        /// <param name="cmdManager">a helper class to get the server</param>
        void OnServerLoaded(IMinecraftHandler mc, IServer server);

        /// <summary>
        /// use it to register youre commands here
        /// </summary>
        /// <param name="cmdManager">a helper class to register commands</param>
        void OnPluginLoaded(ICommandManager CommandManager, IMinecraftHandler mc);

        /// <summary>
        /// gets executed when the plugins is unloaded
        /// </summary>
        void OnPluginUnloaded();

        /// <summary>
        /// gets executed when a player joins the game
        /// </summary>
        /// <param name="mc">the minecraft handler</param>
        /// <param name="username">the players username</param>
        void OnPlayerJoined(IMinecraftHandler mc, String username);

        /// <summary>
        /// gets executed when a player leaves the game
        /// </summary>
        /// <param name="mc">the minecraft handler</param>
        /// <param name="username">the players username</param>
        void OnPlayerLeft(IMinecraftHandler mc, String username);

        /// <summary>
        /// gets executed when someone opens the config for this plugin
        /// </summary>
        void OnConfigDialog();

        /// <summary>
        /// gets executed when a user moves
        /// </summary>
        /// <param name="server">server interface for access to send functions and more</param>
        /// <param name="client">client interface for some send functions and more</param>
        void OnPlayerMove(IServer server, IClient client, XPosition position);
    }
}
