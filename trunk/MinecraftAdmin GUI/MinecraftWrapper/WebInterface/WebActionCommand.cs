using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using Zicore.MinecraftAdmin.Admins;

namespace MinecraftWrapper.WebInterface
{

    public enum WebActionType
    {
        None = 0,
        Chat = 1,
        Kick = 2
    }

    public class WebActionCommand
    {
        WebActionType type = WebActionType.None;

        public WebActionType Type
        {
            get { return type; }
            set { type = value; }
        }

        String message = "";

        public String Message
        {
          get { return message; }
          set { message = value; }
        }

        int id = -1;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        User user = new User();

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public WebActionCommand(int id, WebActionType type, String message,User user, ZmaSQLConnection sql)
	    {
            this.Id = id;
            this.Type = type;
            this.Message = message;
            this.User = user;
	    }
    }
}
