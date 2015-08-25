using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftWrapper.Chat
{
    public class ChannelCollection : List<Channel>
    {


        public bool AddChannel(Channel c)
        {
            if (!Exists(c.Name))
            {
                this.Add(c);
                return true;
            }
            return false;
        }

        public bool Exists(String name)
        {
            foreach (Channel c in this)
            {
                if (c.Name.ToLower() == name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public Channel Find(String name)
        {
            foreach (Channel c in this)
            {
                if (c.Name.ToLower() == name.ToLower())
                {
                    return c;
                }
            }
            return null;
        }

        public bool ExistsMainChannel()
        {
            return Exists("*");
        }
    }
}
