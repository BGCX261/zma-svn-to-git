using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;
using Zicore.MinecraftAdmin.Commands;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using Zicore.MinecraftAdmin.IO;
using Zicore.MinecraftAdmin;

namespace ZmaSamplePlugin
{

    /// <summary>
    /// this is the main entry point of the plugin
    /// </summary>
    public class Plugin : IPlugin
    {
        bool enabled = true;
        String description = "ZMA Example Plugin by Zicore 2010 with Iron Blocker";
        String startupPath = ""; // it gets filled automatically

        #region Properties
        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string StartUpPath
        {
            get
            {
                return startupPath;
            }
            set
            {
                startupPath = value;
            }
        } 
        #endregion
        
        public void OnChatMessage(IServer server, IClient client, string message, ref bool tunnelMessage)
        {
            // that makes no sense use a command for things like that, it just shows some possibilities
            //if (message == "!colors")
            //{
            //    tunnelMessage = false; // makes that the message not gets send to the server and to all clients then
            //    server.SendServerMessage("colors are 0-9 and A-F");// i know pretty useless
            //}
            if (message == "/iron")
            {
                tunnelMessage = false;
            }
        }
        
        public void OnPluginLoaded(ICommandManager CommandManager,IMinecraftHandler mc)
        {
            //CommandManager.RegisterCommand("teleport", new CommandTeleport(mc));
            CommandManager.RegisterCommand("color", new CommandColor(mc));
            CommandManager.RegisterCommand("group", new CommandGroup(mc)); // make sure the name is no duplicate :)
            CommandManager.RegisterCommand("groups", new CommandGroups(mc)); // make sure the name is no duplicate :)
        }

        public void OnPluginUnloaded()
        {
            
        }

        /// <summary>
        /// The plugin name you see in the list later
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "ZMA Sample Addon by Zicore " + GetAssemblyFileVersionAttribute(this.GetType().Assembly);
        }

        public static string GetAssemblyFileVersionAttribute(Assembly asm)
        {
            var attributes = asm.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
            if (attributes.Length > 0)
            {
                var atr = attributes[0] as AssemblyFileVersionAttribute;
                return atr.Version;
            }
            return "";
        }

        public void OnPlayerJoined(IMinecraftHandler mc, string username)
        {
            //Command cmd = new CommandKick(mc);
            //cmd.TriggerPlayer = "Console";
            //cmd.Execute(username,"","","");
        }

        public void OnPlayerLeft(IMinecraftHandler mc, string username)
        {
            
        }

        public void OnServerLoaded(IMinecraftHandler mc, IServer server)
        {
            
        }


        public void OnBlockPlacing(IServer server, IClient client, short blockId, ref bool tunnelPlacing)
        {
            
        }


        public void OnConfigDialog()
        {
            MessageBox.Show("There is actually no configuration");
        }


        public void OnPlayerMove(IServer server, IClient client, MinecraftWrapper.Player.XPosition position)
        {
            
        }
    }
}
