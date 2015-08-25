using System;
using System.Collections.Generic;
using System.Text;

namespace Zicore.MinecraftAdmin
{
    public class KitItem
    {
        string _id = "1";

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        int _amount = 1;

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public KitItem(string id, int amount)
        {
            _id = id;
            _amount = amount;
        }

        public override string ToString()
        {
            return string.Format("ID: {0} Amount:{1}",Id,Amount);
        }
    }
}
