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
using MinecraftWrapper.AddonInterface.Actions;
using Zicore.PluginConfig;
using MinecraftWrapper.Protocoll;

namespace ZmaMapLimiter
{

    /// <summary>
    /// this is the main entry point of the plugin
    /// </summary>
    public class Plugin : IPlugin, IPlayerMove
    {
        bool enabled = true;
        String description = "ZMA Map Limiter Plugin by Zicore 2010";
        String startupPath = ""; // it gets filled automatically
        ConfigPlugin config = null;
        IMinecraftHandler mc;

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

        public void OnPluginLoaded(ICommandManager CommandManager, IMinecraftHandler mc)
        {
            MinecraftHandler myMc = mc as MinecraftHandler;
            if (myMc != null)
            {
                
            }
            CommandManager.RegisterCommand("setcenter",new CommandSetCenter(mc));
            CommandManager.RegisterCommand("distance", new CommandDistance(mc));
            ConfigPlugin.ConfigFolder = Path.GetDirectoryName(startupPath) + Path.DirectorySeparatorChar;
            config = ConfigPlugin.Load();
            config.Save();
            this.mc = mc;
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
            return description +" "+ GetAssemblyFileVersionAttribute(this.GetType().Assembly);
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
            player.Add(username, new ClientState());
        }

        public void OnPlayerLeft(IMinecraftHandler mc, string username)
        {
            player.Remove(username);
        }

        public void OnServerLoaded(IMinecraftHandler mc, IServer server)
        {

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
            config.Save();
        }

        Dictionary<String, ClientState> player = new Dictionary<string, ClientState>();


        public void OnPlayerMove(IServer server, IClient client, MinecraftWrapper.Player.XPosition position)
        {
            if(config.Enabled)
            {
                if (player.ContainsKey(client.Name))
                {
                    ClientState state = player[client.Name];
                    if (state != null)
                    {
                        if (++state.Ticker >= state.TickerMax)
                        {
                            state.Ticker = 0;
                            Vector3 spwanVector = config.SpawnPosition.ToVector3();
                            Vector3 playerVector = position.ToVector3();
                            if (config.IgnoreHeightAxis)
                            {
                                spwanVector.Y = 0.0; // radius without y
                                playerVector.Y = 0.0; // radius without y
                            }

                            double distance = playerVector.Distance(spwanVector);
                            if (!state.HasBeenWarned && distance >= config.WarningRadius)
                            {
                                server.SendExecuteResponse(client.Name,
                                    String.Format("Warning you're {0:0.0} units away from spawn, if you pass {1} you'll get teleported to home!",
                                    distance, config.HomeRadius));
                                state.HasBeenWarned = true;
                                state.HasBeenTeleported = false;
                            }
                            if (!state.HasBeenTeleported && distance >= config.HomeRadius)
                            {
                                client.SendMessage("/home");
                                server.SendExecuteResponse(client.Name,
                                    String.Format("You have been teleported to home, because you were to far away from spawn!"));
                                state.HasBeenWarned = false;
                                state.HasBeenTeleported = true;
                            }
                            if (distance < config.WarningRadius)
                            {
                                state.HasBeenWarned = false;

                            }
                        }
                    }
                }
            }            
        }
    }
}
