using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandTp : Command
    {
        public CommandTp(IMinecraftHandler mc)
            :base(mc,"tp")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            List<String> playerlist = MinecraftHandler.Player;
            string match = EasyGuess.GetMatchedString(playerlist, arg1);
            string match2 = EasyGuess.GetMatchedString(playerlist, arg2);

            if (!String.IsNullOrEmpty(match) && !String.IsNullOrEmpty(match2))
            {
                MinecraftHandler.ExecuteTeleport(match, match2);
                return new CommandResult(true, string.Format("{0} teleported {1} to {2}", TriggerPlayer, match, match2));
            }
            return new CommandResult();
        }
    }
}
