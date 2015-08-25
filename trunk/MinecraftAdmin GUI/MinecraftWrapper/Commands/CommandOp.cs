using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandOp : Command
    {
        public CommandOp(IMinecraftHandler mc)
            :base(mc,"op")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            List<String> playerlist = MinecraftHandler.Player;
            string match = EasyGuess.GetMatchedString(playerlist, arg1);
            if (!String.IsNullOrEmpty(match))
            {
                MinecraftHandler.ExecuteCommand("op", match);
                return new CommandResult(true, string.Format("{0} made player {1} operator", TriggerPlayer, match));
            }
            return new CommandResult();
        }
    }
}
