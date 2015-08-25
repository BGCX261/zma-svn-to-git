using System;
using System.Collections.Generic;
using System.Text;

namespace Zicore.MinecraftAdmin
{
    public class Kit
    {
        bool _fixedGroup = false;

        public bool FixedGroup
        {
            get { return _fixedGroup; }
            set { _fixedGroup = value; }
        }

        int _level = 0;

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        string _name = "";

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        List<KitItem> _items = new List<KitItem>();

        public List<KitItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public override string ToString()
        {
            return string.Format("<{0}> GroupID:{1}",Name,this.Level);
        }
    }
}
