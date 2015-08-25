using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MinecraftWrapper.AddonInterface;
using Zicore.MinecraftAdmin.Admins;

namespace Zicore.MinecraftAdmin.Commands
{
    /// <summary>
    /// make sure it inherits the Command class
    /// </summary>
    public class CommandGroups : Command
    {
        /// <summary>
        /// the string for the base class is the name of this command
        /// it gets executed with !color then, should be the same like the in the register method
        /// </summary>
        /// <param name="mc">The minecraft handler</param>
        public CommandGroups(IMinecraftHandler mc)
            :base(mc,"groups")
        {
            Help = "Lists all groups";
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
            var mc = MinecraftHandler;

            GroupCollectionSingletone groups = GroupCollectionSingletone.GetInstance();
            StringBuilder builder = new StringBuilder();
            List<String> lines = new List<string>();

            builder.AppendFormat("Groups: {0} ", groups.Items.Count);

            if (groups.Items.Count > 0)
            {
                for (int i = 0; i < groups.Items.Count; i++)
                {
                    Group g = groups.Items[i];
                    if (builder.Length + g.Name.Length + mc.Config.ResponsePrefix.Length < 70)
                    {
                        builder.AppendFormat("§f<§{0}{1}§f> ", g.GroupColor, g.Name);
                    }
                    else
                    {
                        lines.Add(builder.ToString());
                        builder = new StringBuilder();
                        i--;
                    }
                }
            }
            if (builder.Length + mc.Config.ResponsePrefix.Length <= 70)
            {
                lines.Add(builder.ToString());
            }

            //MinecraftHandler.ExecuteSay(result);
            foreach (String line in lines)
            {
                Server.SendExecuteResponse(TriggerPlayer, line);
            }


            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
