using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using Vitt.Andre.XML;

namespace Zicore.MinecraftAdmin.Admins
{
    [XmlRootAttribute("UserCollection", Namespace = "", IsNullable = false)]
    public class UserCollectionSingletone
    {
        public static String File = "Users.xml";

        private static volatile UserCollectionSingletone instance = null;
        private static object m_lock = new object();

        private UserCollectionSingletone()
        {
            Load();
        }

        public static UserCollectionSingletone GetInstance()
        {
            // DoubleLock
            if (instance == null)
            {
                lock (m_lock)
                {
                    if (instance == null)
                    {
                        instance = new UserCollectionSingletone();
                    }
                }
            }
            return instance;
        }

        UserCollection items = new UserCollection();

        public UserCollection Items
        {
            get { return items; }
            set { items = value; }
        }        

        protected void Load(String path)
        {
            try
            {
                this.Items = XObject<UserCollection>.Load(path);
            }
            catch
            {
                this.Items = new UserCollection();
            }
        }

        protected void Save(String path)
        {
            try
            {
                XObject<UserCollection>.Save(this.Items, path);
            }
            catch
            {

            }
        }

        public void Save()
        {
            Save(Config.ConfigFolder + File);
        }

        public void Load()
        {
            Load(Config.ConfigFolder + File);
        }

        public bool IsInlist(String name)
        {
            foreach (User u in this.items)
            {
                if (u.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Login(String userName, String password, out User user)
        {
            foreach (User  u in this.Items)
            {
                if (u.HasWebAccess && u.WebUsername == userName && u.PasswordHash == password)
                {
                    user = u;
                    return true;
                }
            }
            user = null;
            return false;
        }

        public User GetUserByName(String name)
        {
            foreach (User u in this.items)
            {
                if (u.Name == name)
                {
                    return u;
                }
            }
            return new User("<User>",true);
        }


        /// <summary>
        /// Gets the user by name or a generated user, check with user.Generated
        /// </summary>
        /// <param name="name">Name of the WebUser</param>
        /// <returns>If the user was found, it returns the user else it returns a generated user</returns>
        public User GetUserByLogin(String name)
        {
            foreach (User u in this.items)
            {
                if (u.WebUsername == name)
                {
                    return u;
                }
            }
            return new User("<User>", true);
        }

        public void Add(User user)
        {
            if (!this.IsInlist(user.Name))
            {
                this.Items.Add(user);
            }
        }

        public void Remove(User user)
        {
            this.Items.Remove(user);
        }

        public void RemoveAt(int index)
        {
            this.Items.RemoveAt(index);
        }
    }
}
