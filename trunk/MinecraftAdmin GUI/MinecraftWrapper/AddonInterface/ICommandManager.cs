using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin.Commands;

namespace MinecraftWrapper.AddonInterface
{
    public interface ICommandManager
    {
        /// <summary>
        /// registers a custom command
        /// </summary>
        /// <param name="name">the dictonary key</param>
        /// <param name="command">the command to register</param>
        void RegisterCommand(String name, ICommand command);
        void UnregisterCommand(String name);
    }
}
