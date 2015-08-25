using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;
using Zicore.MinecraftAdmin.Commands;
using System.Reflection;
using Meebey.SmartIrc4net;
using System.Threading;
using System.IO;
using Zicore.MinecraftAdmin.IO;
using System.Text.RegularExpressions;
using Zicore.PluginConfig;

namespace ZmaIrcPlugin
{

    /// <summary>
    /// this is the main entry point of the plugin
    /// </summary>
    public class Plugin : IPlugin
    {
        bool enabled = true;
        String description = "ZMA IRC Plugin by Zicore 2010";
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

        IServer server;


        IrcClient ircClient = new IrcClient();
        IMinecraftHandler mc;
        ConfigPlugin config;
        
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
            else
            {
                if( message.Length > 0 && message[0].ToString() != mc.Config.CommandChar && !config.MuteIrc)
                {
                    String filteredMessage = Regex.Replace(message, "§[0-9A-Fa-f]", "");
                    String filteredClientName = Regex.Replace(client.Name, "§[0-9A-Fa-f]", "");
                    ircClient.SendMessage(SendType.Message, config.Channel, String.Format("<{0}> {1}", filteredClientName, filteredMessage));
                }                
            }
        }

        public void OnPluginLoaded(ICommandManager CommandManager,IMinecraftHandler mc)
        {
            ConfigPlugin.ConfigFolder = Path.GetDirectoryName(startupPath) + Path.DirectorySeparatorChar;
            config = ConfigPlugin.Load();

            if (config.ConnectOnStartup)
            {
                Reconnect(config);                
            }

            ircClient.OnQueryMessage -= new IrcEventHandler(ircClient_OnQueryMessage);
            ircClient.OnChannelMessage -= new IrcEventHandler(ircClient_OnChannelMessage);
            ircClient.OnQueryMessage += new IrcEventHandler(ircClient_OnQueryMessage);
            ircClient.OnChannelMessage += new IrcEventHandler(ircClient_OnChannelMessage);
        }

        private void Reconnect(ConfigPlugin config)
        {
            if (ircClient.IsConnected)
            {
                ircClient.Disconnect();
            }

            threadRunning = false;

            try
            {
                ircThread.Abort();
            }
            catch (Exception)
            {
                
            }
            

            ircClient.Connect(config.Host, config.Port);
            ircClient.Login(config.IrcNick, config.IrcNick);
            ircClient.RfcJoin(config.Channel);

            if (!threadRunning)
            {
                ircThread = new Thread(new ThreadStart(IrcThread));
            }
            threadRunning = true;
            ircThread.Start();
        }

        void ircClient_OnChannelMessage(object sender, IrcEventArgs e)
        {
            if (mc != null && server != null)
            {
                if (mc.Started && !config.MuteIngame)
                {
                    String filteredMessage = Regex.Replace(e.Data.Message, "§[0-9A-Fa-f]", "");
                    String filteredClientName = Regex.Replace(e.Data.Nick, "§[0-9A-Fa-f]", "");
                    server.SendServerMessage(String.Format("{0}{1}{2} {3}", config.NamePrefix, filteredClientName, config.NameSuffix, filteredMessage));
                }
            }
        }

        void ircClient_OnQueryMessage(object sender, IrcEventArgs e)
        {
            if (mc != null && server != null)
            {
                if (mc.Started && !config.MuteIngame)
                {
                    String filteredMessage = Regex.Replace(e.Data.Message, "§[0-9A-Fa-f]", "");
                    String filteredClientName = Regex.Replace(e.Data.Nick, "§[0-9A-Fa-f]", "");
                    server.SendServerMessage(String.Format("{0}{1}{2} {3}", config.NamePrefix, filteredClientName, config.NameSuffix, filteredMessage));
                }
            }
        }

        public void OnPluginUnloaded()
        {
            threadRunning = false;
            ircClient.Disconnect();   
        }

        Thread ircThread;
        bool threadRunning = false;

        private void IrcThread()
        {
            while (threadRunning)
            {
                ircClient.ListenOnce();
                Thread.Sleep(10);
            }
            if (IrcThreadDone != null)
            {
                IrcThreadDone();
            }
        }

        public delegate void IrcThreadDoneDelegate();
        public event IrcThreadDoneDelegate IrcThreadDone;

        /// <summary>
        /// The plugin name you see in the list later
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "ZMA IRC Addon by Zicore " + GetAssemblyFileVersionAttribute(this.GetType().Assembly);
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


        public void OnServerLoaded(IMinecraftHandler mc, IServer server)
        {
            this.server = server;
            this.mc = mc;
        }

        public void OnBlockPlacing(IServer server, IClient client, short blockId, ref bool tunnelPlacing)
        {
            
        }

        public void OnConfigDialog()
        {
            ConfigDialog c = new ConfigDialog();
            c.ConfigChanged += new ConfigDialog.ConfigChangedDelegate(ConfigDialog_ConfigChanged);
            c.Show();
        }

        void ConfigDialog_ConfigChanged(ConfigPlugin config)
        {
            this.config = config;
            try
            {
                Reconnect(config);
            }
            catch (Exception ex)
            {
                Log.Append(this, "Nickchanged " + ex.Message, Log.PluginLog);
            }
        }

        public void OnPlayerJoined(IMinecraftHandler mc, string username)
        {
            
        }

        public void OnPlayerLeft(IMinecraftHandler mc, string username)
        {
            
        }


        public void OnPlayerMove(IServer server, IClient client, MinecraftWrapper.Player.XPosition position)
        {
            
        }
    }
}
