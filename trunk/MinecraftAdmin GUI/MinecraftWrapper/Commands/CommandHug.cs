using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandHug : Command
    {
        public CommandHug(IMinecraftHandler mc)
            :base(mc,"hug")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            if( !String.IsNullOrEmpty (arg1))
            {
                MinecraftHandler.ExecuteSay(String.Format("<{0}> hugged <{1}>",TriggerPlayer, arg1));
                return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
            }
            return new CommandResult();
        }
    }
}
