using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.XML;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Vitt.Andre.XML;
using System.IO;

namespace Vitt.Andre.MinecraftAdmin
{
    [XmlRootAttribute("StartupActions", Namespace = "", IsNullable = false)]
    public class StartupActions
    {
        public StartupActions()
        {

        }

        bool updateGuid = false;

        public bool UpdateGuid
        {
            get { return updateGuid; }
            set { updateGuid = value; }
        }

        public void Execute(Config config)
        {
            if (UpdateGuid)
            {
                config.GuidString = Guid.NewGuid().ToString();
                config.Save();
                UpdateGuid = false;
                this.Save(Path.Combine(Config.ConfigFolder, StartupActions.File));
            }
        }

        public static string File = "StartupActions.xml";

        public static StartupActions Load(String path)
        {
            try
            {
                return XObject<StartupActions>.Load(path);
            }
            catch
            {

            }
            return null;
        }

        public virtual void Save(String path)
        {
            try
            {
                XObject<StartupActions>.Save(this, path);
            }
            catch
            {

            }
        }
    }
}
