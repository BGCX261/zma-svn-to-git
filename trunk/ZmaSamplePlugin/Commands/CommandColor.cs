using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    /// <summary>
    /// make sure it inherits the Command class
    /// </summary>
    public class CommandColor : Command
    {
        /// <summary>
        /// the string for the base class is the name of this command
        /// it gets executed with !color then, should be the same like the in the register method
        /// </summary>
        /// <param name="mc">The minecraft handler</param>
        public CommandColor(IMinecraftHandler mc)
            :base(mc,"color")
        {
            Help = "Prints a coloured text";
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
            // name is the name of this command
            // TriggerPlayer is the player who triggered this command
            Regex regex = new Regex("[0-9a-fA-F] (?<text>.+)");// Color char regex
            Match match = regex.Match(RegArg);
            if (match.Success)
            {
                String colorKey = arg1;
                String text = match.Groups["text"].Value;
                // do never send an empty string :-)
                if (!String.IsNullOrEmpty(text))
                {
                    this.Server.SendServerMessage(String.Format("§f<§{0}{1}§f> §{2}{3}", TriggerPlayer,ClientUser.Level.GroupColor, colorKey, text));
                }
                return new CommandResult(true, string.Format("{0} entered a coloured text", TriggerPlayer));
            }

            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
