using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftWrapper.Chat
{
    public class ColorChar
    {
        public ColorChar(Char key, String name)
        {
            this.key = key;
            this.name = name;
        }

        char key = '0';
        String name = "Black";

        public char Key
        {
            get { return key; }
            set { key = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
