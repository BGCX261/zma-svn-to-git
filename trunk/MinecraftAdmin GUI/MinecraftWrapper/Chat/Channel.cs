using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zicore.MinecraftAdmin.Admins;

namespace MinecraftWrapper.Chat
{
    public class Channel
    {
        public Channel(String name, String password)
        {
            this.name = name;
            this.password = password;
            requiresPassword = true;
        }

        UserCollection user = new UserCollection();

        public UserCollection User
        {
            get { return user; }
            set { user = value; }
        }

        public Channel(String name)
        {
            this.name = name;
        }

        public Channel()
        {

        }

        String name = "*";

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        String password = "";

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        bool requiresPassword = false;

        public bool RequiresPassword
        {
            get { return requiresPassword; }
            set { requiresPassword = value; }
        }
    }
}
