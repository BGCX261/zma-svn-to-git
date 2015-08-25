using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;
namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandSay : Command
    {
        public CommandSay(IMinecraftHandler mc)
            :base(mc,"say")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            MinecraftHandler.ExecuteSay(RegArg);
            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
