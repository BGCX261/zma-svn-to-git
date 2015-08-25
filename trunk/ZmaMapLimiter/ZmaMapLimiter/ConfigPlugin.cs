using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Vitt.Andre.XML;
using System.Xml.Serialization;
using System.ComponentModel;
using MinecraftWrapper.Player;

namespace Zicore.PluginConfig
{
    [XmlRootAttribute("ConfigPlugin", Namespace = "", IsNullable = false)]
    public class ConfigPlugin
    {
        public static String ConfigFolder = "";
        public static String ConfigFile = "config.xml";

        bool enabled = false;

        [CategoryAttribute("State"), DescriptionAttribute("Enabled")]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        bool ignoreHeightAxis = true;

        public bool IgnoreHeightAxis
        {
            get { return ignoreHeightAxis; }
            set { ignoreHeightAxis = value; }
        }

        [CategoryAttribute("Spawn"), DescriptionAttribute("X")]
        public double X { get { return spawnPosition.X; } set { spawnPosition.X = value; } }

        [CategoryAttribute("Spawn"), DescriptionAttribute("Y")]
        public double Y { get { return spawnPosition.Y; } set { spawnPosition.Y = value; } }

        [CategoryAttribute("Spawn"), DescriptionAttribute("Z")]
        public double Z { get { return spawnPosition.Z; } set { spawnPosition.Z = value; } }

        XPosition spawnPosition = new XPosition();

        [Browsable(false)]
        public XPosition SpawnPosition
        {
            get { return spawnPosition; }
            set { spawnPosition = value; }
        }

        double warningRadius = 500;

        [CategoryAttribute("Radius"), DescriptionAttribute("Warning Radius")]
        public double WarningRadius
        {
            get { return warningRadius; }
            set { warningRadius = value; }
        }

        double homeRadius = 550;

        [CategoryAttribute("Radius"), DescriptionAttribute("Home Radius")]
        public double HomeRadius
        {
            get { return homeRadius; }
            set { homeRadius = value; }
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
