using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using Library.Forms;

namespace Zicore.MinecraftAdmin.Admins
{
    [XmlRootAttribute("UserCollection", Namespace = "", IsNullable = false)]
    public class UserCollection : SortableBindingList<User>
    {
        public bool IsInlist(String name)
        {
            foreach (User u in this)
            {
                if (u.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsInlist(User user)
        {
            foreach (User u in this)
            {
                if (u == user)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Login(String userName, String password, out User user)
        {
            foreach (User u in this.Items)
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
            foreach (User u in this)
            {
                if (u.Name == name)
                {
                    return u;
                }
            }
            return new User("<User>", true);
        }

        public User GetUserByLogin(String name)
        {
            foreach (User u in this)
            {
                if (u.WebUsername == name)
                {
                    return u;
                }
            }
            return new User("<User>", true);
        }
    }
}
