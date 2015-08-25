using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandGet : Command
    {
        public CommandGet(IMinecraftHandler mc)
            :base(mc,"get")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            List<String> playerlist = MinecraftHandler.Player;
            string match = EasyGuess.GetMatchedString(playerlist, arg1);
            if (!String.IsNullOrEmpty(match))
            {
                if (!String.IsNullOrEmpty(TriggerPlayer))
                {
                    MinecraftHandler.ExecuteTeleport(match, TriggerPlayer);
                    return new CommandResult(true, string.Format("Player {0} has teleported player {1} to himself", TriggerPlayer,match));
                }
            }
            return new CommandResult();
        }
    }
}
