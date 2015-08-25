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
using Rss;

namespace ZmaRssReader
{

    /// <summary>
    /// this is the main entry point of the plugin
    /// </summary>
    public class Plugin : IPlugin
    {
        Thread readerThread = null;
        bool enabled = true;
        String description = "ZMA RSS Reader";
        String startupPath = ""; // it gets filled automatically
        IMinecraftHandler mc;
        //IServer server;
        volatile bool readerEnabled = false;

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
            //this.mc = mc;
            //if (Enabled)
            //{
            //    if (readerThread == null && !readerEnabled)
            //    {
            //        readerThread = new Thread(new ThreadStart(ReaderThread));
            //    }
            //    ReadFeed();
            //}
        }

        public void OnPluginUnloaded()
        {
            
        }

        private void InitReader()
        {

        }

        //private void ReaderThread()
        //{
        //    //readerEnabled = true;
        //    //InitReader();
        //    //while (readerEnabled)
        //    //{
        //    //    Thread.Sleep(1000);
        //    //}
        //    //readerEnabled = false;
        //}

        /// <summary>
        /// The plugin name you see in the list later
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return description + " " + GetAssemblyFileVersionAttribute(this.GetType().Assembly);
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

        public void OnServerLoaded(IMinecraftHandler mc, IServer server)
        {
           
        }

        private void ReadFeed()
        {
            //RssReader reader = new RssReader("http://notch.tumblr.com/rss");
            //reader.Read();
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
