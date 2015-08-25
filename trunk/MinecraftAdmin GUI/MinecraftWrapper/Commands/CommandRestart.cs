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
    public class CommandRestart : Command
    {
        public CommandRestart(IMinecraftHandler mc)
            :base(mc,"restart")
        {
            Help = "restart: restarts the server";
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            MinecraftHandler mc = MinecraftHandler as MinecraftHandler;
            mc.Restart();
            return new CommandResult(false,"",false);
        }
    }
}
