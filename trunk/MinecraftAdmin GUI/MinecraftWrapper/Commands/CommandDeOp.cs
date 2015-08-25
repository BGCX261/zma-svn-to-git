using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandDeOp : Command
    {
        public CommandDeOp(IMinecraftHandler mc)
            :base(mc,"deop")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            List<String> playerlist = MinecraftHandler.Player;
            string match = EasyGuess.GetMatchedString(playerlist, arg1);
            if (!String.IsNullOrEmpty(match))
            {
                MinecraftHandler.ExecuteCommand("deop", match);
                return new CommandResult(true, string.Format("{0} revoked player {1} operator {2}", Name, match, TriggerPlayer));
            }
            return new CommandResult();
        }
    }
}
