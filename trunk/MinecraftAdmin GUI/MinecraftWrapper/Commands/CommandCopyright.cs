using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandCopyright : Command
    {
        public CommandCopyright(IMinecraftHandler mc)
            :base(mc,"copyright")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            Server.SendServerMessage(string.Format("§cZMA {0} by <Zicore>", MinecraftHandler.Version));
            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
