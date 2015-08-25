using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Vitt.Andre.XML;
using System.Xml.Serialization;
using System.ComponentModel;

namespace Zicore.PluginConfig
{
    [XmlRootAttribute("ConfigPlugin", Namespace = "", IsNullable = false)]
    public class ConfigPlugin
    {
        public static String ConfigFolder = "";
        public static String ConfigFile = "config.xml";

        //String[] channelList = { "#main" };

        //[CategoryAttribute("IRC Settings"), DescriptionAttribute("Channel list")]
        //public String[] ChannelList
        //{
        //    get { return channelList; }
        //    set { channelList = value; }
        //}

        bool muteIngame = false;

        [CategoryAttribute("General"), DescriptionAttribute("Mute Ingame")]
        public bool MuteIngame
        {
            get { return muteIngame; }
            set { muteIngame = value; }
        }

        bool muteIrc = false;

        [CategoryAttribute("General"), DescriptionAttribute("Mute IRC")]
        public bool MuteIrc
        {
            get { return muteIrc; }
            set { muteIrc = value; }
        }

        String channel = "#main";

        [CategoryAttribute("Channel Settings"), DescriptionAttribute("Channel")]
        public String Channel
        {
            get { return channel; }
            set { channel = value; }
        }

        bool connectOnStartup = false;

        [CategoryAttribute("Connection"), DescriptionAttribute("Connect on Startup")]
        public bool ConnectOnStartup
        {
            get { return connectOnStartup; }
            set { connectOnStartup = value; }
        }

        String host = "yourehost.com";

        [CategoryAttribute("Connection"), DescriptionAttribute("Host of connection")]
        public String Host
        {
            get { return host; }
            set { host = value; }
        }

        int port = 6690;

        [CategoryAttribute("Connection"), DescriptionAttribute("Port of connection")]
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        String namePrefix = "§f<§c";

        [CategoryAttribute("Name"), DescriptionAttribute("Prefix of the name")]
        public String NamePrefix
        {
            get { return namePrefix; }
            set { namePrefix = value; }
        }

        String nameSuffix = " §f[§6irc§f]>";

        [CategoryAttribute("Name"), DescriptionAttribute("Suffix of the name")]
        public String NameSuffix
        {
            get { return nameSuffix; }
            set { nameSuffix = value; }
        }

        String ircNick = "ZMA";

        [CategoryAttribute("Name"), DescriptionAttribute("Name of the client")]
        public String IrcNick
        {
            get { return ircNick; }
            set { ircNick = value; }
        }

       

        public void Save()
        {
            try
            {
                if (Directory.Exists(ConfigPlugin.ConfigFolder))
                {
                    XObject<ConfigPlugin>.Save(this, ConfigPlugin.ConfigFolder + ConfigPlugin.ConfigFile);
                }
                else
                {
                    Directory.CreateDirectory(ConfigPlugin.ConfigFolder);
                    XObject<ConfigPlugin>.Save(this, ConfigPlugin.ConfigFolder + ConfigPlugin.ConfigFile);
                }
            }
            catch
            {

            }
        }

        public static ConfigPlugin Load()
        {
            try
            {
                return XObject<ConfigPlugin>.Load(ConfigPlugin.ConfigFolder + ConfigPlugin.ConfigFile);
            }
            catch (Exception)
            {
                return new ConfigPlugin();
            }
        }
    }
}
