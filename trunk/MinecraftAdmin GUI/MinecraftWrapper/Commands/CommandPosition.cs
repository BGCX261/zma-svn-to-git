using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandPosition : Command
    {
        public CommandPosition(IMinecraftHandler mc)
            :base(mc,"position")
        {
            
        }

        public override CommandResult Execute(String name, String arg2, String arg3, String arg4)
        {
            if (Client != null)
            {
                return new CommandResult(true, string.Format("Position of {0} is {1}", TriggerPlayer, Client.Position.ToString()));
            }
            return new CommandResult(true, string.Format("Client is null"));
        }
    }
}
