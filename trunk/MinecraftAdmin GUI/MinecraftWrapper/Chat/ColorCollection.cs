using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MinecraftWrapper.Chat
{
    public class ColorCollection
    {
        public ColorCollection()
        {
            items.Add(new ColorChar('0', "Black"));
            items.Add(new ColorChar('1', "Royal Blue"));
            items.Add(new ColorChar('2', "Green"));
            items.Add(new ColorChar('3', "Dark Teal"));
            items.Add(new ColorChar('4', "Dark Red"));
            items.Add(new ColorChar('5', "Purple"));
            items.Add(new ColorChar('6', "Orange"));
            items.Add(new ColorChar('7', "Gray"));
            items.Add(new ColorChar('8', "Dark Gray"));
            items.Add(new ColorChar('9', "Blue"));
            items.Add(new ColorChar('A', "Light Green"));
            items.Add(new ColorChar('B', "Teal"));
            items.Add(new ColorChar('C', "Red"));
            items.Add(new ColorChar('D', "Pink"));
            items.Add(new ColorChar('E', "Yellow"));
            items.Add(new ColorChar('F', "White"));
        }

        public BindingList<ColorChar> GetBindingList()
        {
            BindingList<ColorChar> list = new BindingList<ColorChar>();
            foreach (ColorChar c in this.Items)
            {
                list.Add(c);
            }
            return list;
        }

        private static volatile ColorCollection instance = null;

        public static ColorCollection GetInstance()
        {
            if (instance == null)
            {
                lock (m_lock)
                {
                    if (instance == null)
                    {
                        instance = new ColorCollection();
                    }
                }
            }
            return instance;
        }
        private static object m_lock = new object();

        BindingList<ColorChar> items = new BindingList<ColorChar>();

        public BindingList<ColorChar> Items
        {
            get { return items; }
            set { items = value; }
        }
    }
}
