using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin.Admins;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.Blocks;

namespace MinecraftWrapper.AddonInterface
{
    public interface IMinecraftHandler
    {
        /// <summary>
        /// indicates whether the minecraft process is running or not
        /// </summary>
        bool Started { get; set; }

        /// <summary>
        /// executes the say command
        /// </summary>
        /// <param name="text">message to say</param>
        void ExecuteSay(string text);

        /// <summary>
        /// executes the tp command
        /// teleports name1 to name2
        /// </summary>
        /// <param name="name1">name of player 1</param>
        /// <param name="name2">name of player 2</param>
        void ExecuteTeleport(String name1, String name2);

        /// <summary>
        /// executes commands which the use can execute in it's group
        /// </summary>
        /// <param name="user"></param>
        void ExecuteCommands(User user);

        /// <summary>
        /// kicks a specified player
        /// </summary>
        /// <param name="username">player to kick</param>
        /// <param name="admin">the admin who kicked him</param>
        void ExecuteKick(string username, string admin);

        /// <summary>
        /// executes a server command with 3 arguments
        /// </summary>
        /// <param name="command">command</param>
        /// <param name="arg1">arg1</param>
        /// <param name="arg2">arg2</param>
        /// <param name="arg3">arg3</param>
        void ExecuteCommand(String command, string arg1, string arg2, string arg3);
        void ExecuteCommand(String command, string arg1, string arg2);
        void ExecuteCommand(String command, string arg1);
        void ExecuteCommand(String command);

        /// <summary>
        /// executes give command
        /// </summary>
        /// <param name="username">gives this user the items</param>
        /// <param name="id">item id</param>
        /// <param name="num">amount of item</param>
        void ExecuteGive(string username, string id, string num);
        void ExecuteGive(string username, string id);

        /// <summary>
        /// executes the standard who command
        /// actually dumps the player to the chat
        /// </summary>
        void ExecuteWho();

        /// <summary>
        /// executes a ban
        /// </summary>
        /// <param name="user">the user who gets banned</param>
        /// <param name="admin">the admin who banned the user</param>
        void ExecuteBan(string user, string admin);

        /// <summary>
        /// executes remove from bannlist
        /// </summary>
        /// <param name="user">removes a user from the banlist</param>
        /// <param name="admin">the admin who banned the user</param>
        void ExecuteRemove(string user, string admin);

        /// <summary>
        /// starts a backup sequenze
        /// </summary>
        /// <param name="minutes">the minutes until start</param>
        void ExecuteBackup(int minutes);

        /// <summary>
        /// starts a backup sequenze
        /// </summary>
        /// <param name="minutes">the minutes until start</param>
        void ExecuteBackup(int minutes, String name);

        /// <summary>
        /// starts an instant backup sequenze
        /// </summary>
        void ExecuteBackup();

        /// <summary>
        /// executes the kit command
        /// </summary>
        /// <param name="kit">the kit</param>
        /// <param name="username">the user who gets the kit</param>
        /// <param name="admin">the admin who triggered this command</param>
        void  ExecuteKit(Kit kit, string username, string admin);

        /// <summary>
        /// indicates if a entry is in a string list
        /// </summary>
        /// <param name="entry">the entry to check</param>
        /// <param name="list">the list</param>
        /// <returns></returns>
        bool IsStringInList(String entry, List<String> list);

        /// <summary>
        /// dumps the kits the to the which the user can get
        /// </summary>
        /// <param name="user">the user</param>
        void ExecuteKits(User user);

        /// <summary>
        /// A list with connected players
        /// </summary>
        List<String> Player { get; set; }

        /// <summary>
        /// A collection with users who are currently online
        /// </summary>
        UserCollection OnlineUsers { get; set; }

        /// <summary>
        /// ZMA Version
        /// </summary>
        String Version { get; set; }

        /// <summary>
        /// indicates if a restart is initiated
        /// </summary>
        bool RestartActivated { get; set; }

        /// <summary>
        /// the minecraft config
        /// </summary>
        Config Config { get; set; }

        /// <summary>
        /// the time until the next backup/restart
        /// </summary>
        TimeSpan TimeUntilBackup { get; set; }

        /// <summary>
        /// the dictonary with available items, item name is the key id is the value
        /// </summary>
        ItemDictonary Items { get;set;}

        /// <summary>
        /// the list contains the actuall priced blocks
        /// </summary>
        BlockCollection PricedBlocks { get; set; }

    }
}
