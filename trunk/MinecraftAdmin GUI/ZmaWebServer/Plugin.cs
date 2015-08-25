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
using System.Threading;
using HttpServer.Authentication;
using HttpServer;
using Vitt.Andre.Tunnel;
using Zicore.MinecraftAdmin.Admins;
using MinecraftWrapper;

namespace ZmaSamplePlugin
{

    /// <summary>
    /// this is the main entry point of the plugin
    /// </summary>
    public class Plugin : IPlugin
    {
        bool enabled = true;
        String description = "ZMA WebServer Alpha";
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
            
        }
        
        public void OnPluginLoaded(ICommandManager CommandManager,IMinecraftHandler mc)
        {
            
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
            return description + GetAssemblyFileVersionAttribute(this.GetType().Assembly);
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
            
        }

        public void OnPlayerLeft(IMinecraftHandler mc, string username)
        {
            
        }

        ServerSocket server = null;

        public ServerSocket Server
        {
            get { return server; }
            set { server = value; }
        }

        MinecraftHandler mc = null;

        public MinecraftHandler Mc
        {
            get { return mc; }
            set { mc = value; }
        }

        public void OnServerLoaded(IMinecraftHandler mc, IServer server)
        {
            this.server = (ServerSocket)server;
            this.mc = (MinecraftHandler)mc;
            ThreadPool.QueueUserWorkItem(PluginThread, null);
        }

        HttpServer.HttpServer _server;

        private void PluginThread(Object state)
        {
            if (_server == null)
            {
                _server = new HttpServer.HttpServer();
                // Let's reuse our module from previous tutorial to handle pages.
                _server.Add(new ZmaWebServer.Modules.MyModule(this));

                // and start the server.
                _server.Start(System.Net.IPAddress.Any, 8080);
            }
            while (mc.Started)
            {
                Thread.Sleep(100);
            }
            _server.Stop(); // stop the web server
            _server = null; // set null or else its impossible to restart it :)
        }

        class User
        {
            public int id;
            public string userName;
            public User(int id, string userName)
            {
                this.id = id;
                this.userName = userName;
            }
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
