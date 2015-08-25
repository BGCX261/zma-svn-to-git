using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin.Commands;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.Player;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandSave : Command
    {
        public CommandSave(IMinecraftHandler mc)
            :base(mc,"save")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            MinecraftHandler.ExecuteCommand("save-all");
            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
