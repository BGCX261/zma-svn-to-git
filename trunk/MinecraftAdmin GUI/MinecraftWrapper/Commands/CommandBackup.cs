using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin.Commands;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.Player;
using Vitt.Andre.Tunnel;
using MinecraftWrapper.Protocoll;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandBackup : Command
    {
        public CommandBackup(IMinecraftHandler mc)
            :base(mc,"backup")
        {
            Help = "Makes a backup";
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            return new CommandResult(false,"Not supported yet :/",false);
        }
    }
}
