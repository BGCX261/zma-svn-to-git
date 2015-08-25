using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin.Commands;

namespace MinecraftWrapper.AddonInterface
{
    public interface ICommand
    {
        CommandResult Execute(string arg1, string arg2, string arg3, string arg4);
        IServer Server { get; }
        IClient Client { get; }
        IMinecraftHandler MinecraftHandler { get; }

        String TriggerPlayer { get; }
    }
}
