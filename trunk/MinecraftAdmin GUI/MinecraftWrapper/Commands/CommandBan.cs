using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;
namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandBan : Command
    {
        public CommandBan(IMinecraftHandler mc)
            :base(mc,"ban")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            List<String> playerlist = MinecraftHandler.Player;
            string match = EasyGuess.GetMatchedString(playerlist, arg1);
            if (!String.IsNullOrEmpty(match))
            {
                MinecraftHandler.ExecuteBan(match, TriggerPlayer);
                return new CommandResult(true, string.Format("{0} has banned {1}",TriggerPlayer, match));
            }
            return new CommandResult();
        }
    }
}
