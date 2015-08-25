using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandUnban : Command
    {
        public CommandUnban(IMinecraftHandler mc)
            :base(mc,"unban")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            MinecraftHandler mc = (MinecraftHandler)MinecraftHandler;
            List<String> bans = mc.GetListFromFile(mc.StrBanList);
            String match = EasyGuess.GetMatchedString(bans, arg1);
            if (!String.IsNullOrEmpty(match))
            {
                MinecraftHandler.ExecuteRemove(match, TriggerPlayer);
                return new CommandResult(true, string.Format("{0} unbanned {1}", TriggerPlayer, match));
            }
            return new CommandResult();
        }
    }
}
