using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin.Admins;
using Vitt.Andre.Tunnel;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public class Command : ICommand
    {
        public Command(MinecraftHandler mc, String name)
        {
            this.mc = mc;
            this.Name = name;
        }

        public Command(IMinecraftHandler mc, String name)
        {
            this.mc = mc as MinecraftHandler;
            this.Name = name;
        }

        ServerSocket _server = null;

        public IServer Server
        {
            get { return _server; }
            set { _server = value as ServerSocket; }
        }

        ClientSocket _client = null;

        public IClient Client
        {
            get { return _client; }
            set { _client = value as ClientSocket; }
        }

        String _name = "";

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        MinecraftHandler mc;

        public IMinecraftHandler MinecraftHandler
        {
            get { return mc; }
        }

        String regArg;

        public String RegArg
        {
            get { return regArg; }
            set { regArg = value; }
        }

        User user;

        public User ClientUser
        {
            get { return user; }
            set { user = value; }
        }

        String triggerPlayer = "";

        public String TriggerPlayer
        {
            get { return triggerPlayer; }
            set { triggerPlayer = value; }
        }

        string help = "No help for this command yet";

        public virtual String Help
        {
            get { return help; }
            set { help = value; }
        }

        public virtual CommandResult Execute(string arg1, string arg2, string arg3, string arg4) 
        {
            if (arg1.Length > 0 && arg1[0] == '?')
                return ExecuteHelp();
            else
                return new CommandResult(); 
        }

        public virtual CommandResult ExecuteHelp()
        {
            return new CommandResult(true, Help, true);
        }
    }
}
