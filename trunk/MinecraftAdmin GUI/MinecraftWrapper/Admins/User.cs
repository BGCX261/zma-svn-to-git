using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Vitt.Andre.XML;
using MinecraftWrapper.Chat;

namespace Zicore.MinecraftAdmin.Admins
{
    public class User
    {
        public User()
        {
            
        }

        public User(String name)
        {
            _name = name;
            try
            {
                Config cfg = XObject<Config>.Load(Config.ConfigFolder + Config.ConfigFile);
                balance = cfg.InitialCurrencyAmount;
            }
            catch
            {
                
            }
        }

        public User(String name, bool generated)
        {
            _name = name;
            this.Generated = generated;
            try
            {
                Config cfg = XObject<Config>.Load(Config.ConfigFolder + Config.ConfigFile);
                balance = cfg.InitialCurrencyAmount;
            }
            catch
            {

            }
        }

        private void InitChannel()
        {
            
        }

        Boolean allowChat = true;

        public Boolean AllowChat
        {
            get { return allowChat; }
            set { allowChat = value; }
        }

        Int32 lastEntityId = -1;

        public Int32 LastEntityId
        {
            get { return lastEntityId; }
            set { lastEntityId = value; }
        }

        bool generated = false;

        long balance = 500;

        public long Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        [XmlIgnore()]
        public bool Generated
        {
            get { return generated; }
            set { generated = value; }
        }

        String passwordHash = "";

        public String PasswordHash
        {
            get { return passwordHash; }
            set { passwordHash = value; }
        }

        Boolean hasWebAccess = false;

        public Boolean HasWebAccess
        {
            get { return hasWebAccess; }
            set { hasWebAccess = value; }
        }

        String webUsername = "";

        public String WebUsername
        {
            get { return webUsername; }
            set { webUsername = value; }
        }

        String _name = "User";

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _levelID = 0;

        public int LevelID
        {
            get { return _levelID; }
            set { _levelID = value; }
        }        

        [XmlIgnore()]
        public Group Level
        {
            get 
            {
                try
                {
                    GroupCollectionSingletone levels = GroupCollectionSingletone.GetInstance();
                    return levels.GetGroupByID(LevelID);
                }
                catch
                {
                    return new Group("Guests", 0);
                }
            }
            set
            {
                try
                {
                    GroupCollectionSingletone levels = GroupCollectionSingletone.GetInstance();
                    Group level = levels.GetGroupByID(LevelID);
                    level = value;
                }
                catch
                {
                }
            }
        }

        [XmlIgnore()]
        public String LevelName
        {
            get
            {
                return Level.Name;
            }
        }
    }
}
