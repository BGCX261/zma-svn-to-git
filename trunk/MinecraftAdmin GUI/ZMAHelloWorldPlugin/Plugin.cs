using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinecraftWrapper.AddonInterface;
using System.Threading;

namespace ZMAHelloWorldPlugin
{
    public class Plugin : IPlugin
    {
        IMinecraftHandler mc;
        private string _startUpPath;
                
        public void OnServerLoaded(IMinecraftHandler mc, IServer server)
        {
            this.mc = mc; // get the minecraft handler
            ThreadPool.QueueUserWorkItem(PluginThread, null);
        }

        private void PluginThread(Object state)
        {
            while (mc.Started) // you should run your thread loop as long as the server is running :)
            {
                Thread.Sleep(1000); // this should be ok
            }
            // Clear used ressources here if needed
        }

        #region IPluginMember        
        bool enabled = true;
        private String _description;
        public string StartUpPath
        {
            get { return _startUpPath; }
            set { _startUpPath = value; }
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion


        public void OnChatMessage(IServer server, IClient client, string message, ref bool tunnelMessage)
        {

        }

        public void OnBlockPlacing(IServer server, IClient client, short blockId, ref bool tunnelPlacing)
        {

        }

        public void OnPluginLoaded(ICommandManager CommandManager, IMinecraftHandler mc)
        {
            
        }

        public void OnPluginUnloaded()
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
            
        }

        public void OnPlayerMove(IServer server, IClient client, MinecraftWrapper.Player.XPosition position)
        {
            
        }
    }
}
