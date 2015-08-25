using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandHi : Command
    {
        public CommandHi(IMinecraftHandler mc)
            :base(mc,"hi")
        {
            
        }

        public override CommandResult Execute(String name, String arg2, String arg3, String arg4)
        {
            List<String> playerlist = MinecraftHandler.Player;
            string match = EasyGuess.GetMatchedString(playerlist, name);
            if (!String.IsNullOrEmpty(match))
            {
                //MinecraftHandler.ExecuteCommand("tell", name, text);
                Server.SendServerMessage(String.Format("<{0}> Hi {1}", TriggerPlayer, match));
            }

            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
