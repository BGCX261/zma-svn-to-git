using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MinecraftWrapper.AddonInterface;
using Zicore.PluginConfig;
using MinecraftWrapper.Player;
using Zicore.MinecraftAdmin.IO;

namespace Zicore.MinecraftAdmin.Commands
{
    /// <summary>
    /// make sure it inherits the Command class
    /// </summary>
    public class CommandSetCenter : Command
    {
        /// <summary>
        /// the string for the base class is the name of this command
        /// it gets executed with !color then, should be the same like the in the register method
        /// </summary>
        /// <param name="mc">The minecraft handler</param>
        public CommandSetCenter(IMinecraftHandler mc)
            :base(mc,"setcenter")
        {
            
        }

        /// <summary>
        /// this is the execution method which gets executed later
        /// to get more arguments use the internal regArgs variable
        /// </summary>
        /// <param name="arg1">first argument after the command in the string</param>
        /// <param name="arg2">second argument after the command in the string</param>
        /// <param name="arg3">third argument after the command in the string</param>
        /// <param name="arg4">fourth argument after the command in the string</param>
        /// <returns>remember to set the command result in every return case</returns>
        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            try
            {
                ConfigPlugin config = ConfigPlugin.Load();
                config.SpawnPosition = new XPosition(Client.Position.X, Client.Position.Y, Client.Position.Z, 0.0, 0.0f, 0.0f, false);
                config.Save();
            }
            catch (Exception ex )
            {
                Log.Append(this, "SetCenter failed " + ex.Message, Log.PluginLog);
            }
            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
