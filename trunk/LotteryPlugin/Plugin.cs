/*

Authors: GamAzz and Zicore © 2010
License: Creative Commons   http://creativecommons.org/licenses/by-sa/3.0/de/deed.en_GB


*/
using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;
using Zicore.MinecraftAdmin.Commands;
using System.Reflection;
using System.IO;
using System.Threading;
using Vitt.Andre.Tunnel;
using Zicore.MinecraftAdmin.Admins;
using System.Windows.Forms;

namespace ZmaGamAzzLottoPlugin
{
    /// <summary>
    /// this is the main entry point of the plugin
    /// </summary>
    public class Plugin : IPlugin
    {
        Random rnd = new Random();
        int zahl = 0;
        bool enabled = true;
        bool lottoEnabled = false;
        String description = "";
        String startupPath = ""; // it gets filled automatically
        ConfigLotto config;
        public Plugin()
        {
            description = "Zma Lotto Plugin by GamAzz " + GetAssemblyFileVersionAttribute(this.GetType().Assembly);
        }

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

        ~Plugin()
        {
            lottoEnabled = false;
        }

        IMinecraftHandler mc = null;
        UserCollectionSingletone users = null;
        public void OnPluginLoaded(ICommandManager CommandManager,IMinecraftHandler mc)
        {
            this.mc = mc;
            CommandManager.RegisterCommand("lotto", new CommandLotto(mc));
            CommandManager.RegisterCommand("jackpot", new CommandJackpot(mc));
            ConfigLotto.ConfigFolder = Path.GetDirectoryName(startupPath) + Path.DirectorySeparatorChar;

            LottoUserCollection.Load().Save();
            config = ConfigLotto.Load();
            config.Save();
            users = UserCollectionSingletone.GetInstance();
            lottoEnabled = true;
            lottoThread = new Thread(new ThreadStart(LottoThread));
            lottoThread.Start();
        }

        Thread lottoThread;

        int ticker = 0;

        public int Ticker
        {
            get { return ticker; }
            set { ticker = value; }
        }

        private void LottoThread()
        {
            while (lottoEnabled)
            {
                try
                {
                    if (server!= null && server.Tunnel.IsConnected && mc.Started)
                    {
                        if (ticker >= config.Ziehung * 60)
                        {
                            ticker = 0;
                            zahl = rnd.Next(config.Min, config.Max + 1);
                            LottoZiehung();                           
                        }
                        else
                        {
                            ticker++;
                        }
                    }
                    Thread.Sleep(1000);
                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }
        }

        private void LottoZiehung()
        {
            LottoUserCollection lottoUsers = LottoUserCollection.Load();
            if (lottoUsers.Users.Count > 0)
            {
                server.SendServerMessage(String.Format("§{0}Drawing of the lotto numbers!", mc.Config.ResponseColorChar));
                
                LottoUserCollection listWinners = new LottoUserCollection();
                zahl = rnd.Next(config.Min, config.Max + 1);
                server.SendServerMessage(String.Format("§{0}The winning number is §6{1}", mc.Config.ResponseColorChar, zahl));
                foreach (LottoUser lottoUser in lottoUsers)
                {
                    User user = users.GetUserByName(lottoUser.Name);
                    if (!user.Generated)
                    {
                        if (lottoUser.Zahl == zahl)
                        {
                            listWinners.Add(lottoUser);
                        }
                    }
                }
                if (listWinners.Users.Count > 0)
                {
                    StringBuilder builder = new StringBuilder();
                    int gewinn = lottoUsers.Jackpot / listWinners.Users.Count;

                    foreach (LottoUser lottoUser in listWinners)
                    {
                        builder.AppendFormat("<{0}> ", lottoUser.Name);
                        User user = users.GetUserByName(lottoUser.Name);
                        if (!user.Generated)
                        {
                            user.Balance += gewinn;
                        }
                    }
                    if (listWinners.Users.Count == 1)
                    {
                        server.SendServerMessage(String.Format("§{0}The Player {1}had won the lottery! §6{2} {3}", mc.Config.ResponseColorChar, builder.ToString(), gewinn, mc.Config.CurrencySymbol));
                    }
                    else
                    {
                        server.SendServerMessage(String.Format("§{0}The Players {1}had won the lottery! §6{2} {3}", mc.Config.ResponseColorChar, builder.ToString(), gewinn, mc.Config.CurrencySymbol));
                    }
                    lottoUsers.Jackpot -= gewinn*listWinners.Users.Count;
                }
                else
                {
                   server.SendServerMessage(String.Format("§{0}No one has won the lottery!",mc.Config.ResponseColorChar));
                   lottoUsers.Jackpot += config.Bonus;
                }
                lottoUsers.Users.Clear();
                lottoUsers.Save();
            }
        }

        public static string GetApplicationsPath()
        {
            FileInfo fi = new FileInfo(Assembly.GetEntryAssembly().Location);
            return fi.DirectoryName;
        } 


        public void OnPluginUnloaded()
        {
            lottoEnabled = false;
        }

        /// <summary>
        /// The plugin name you see in the list later
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Description;
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

        public LottoUserCollection XObject { get; set; }

        ServerSocket server;

        public void OnServerLoaded(IMinecraftHandler mc, IServer server)
        {
            this.server = server as ServerSocket;
        }

        public void OnBlockPlacing(IServer server, IClient client, short blockId, ref bool tunnelPlacing)
        {
            
        }


        public void OnPlayerJoined(IMinecraftHandler mc, string username)
        {
            
        }

        public void OnPlayerLeft(IMinecraftHandler mc, string username)
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
