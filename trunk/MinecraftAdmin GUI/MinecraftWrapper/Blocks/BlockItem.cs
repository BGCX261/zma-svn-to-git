using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;

namespace MinecraftWrapper.Blocks
{
    public class BlockItem
    {
        public BlockItem()
        {

        }

        int price = 100;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        int blockLevel = 1;

        public int BlockLevel
        {
            get { return blockLevel; }
            set { blockLevel = value; }
        }

        public BlockItem(int id)
        {
            this.Id = id;
        }

        int _id = 0;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Name
        {
            get { return GetName(); }
        }

        public override string ToString()
        {
            ItemDictonary items = ItemDictonary.GetInstance();
            KeyValuePair<String,String> kvp;
            if (items.GetKeyValuePairByValue(out kvp, Id.ToString()))
            {
                return string.Format("[{0}, {1}]", kvp.Key, kvp.Value);
            }
            else
            {
                return string.Format("[{0}, {1}]", "<not in list>", Id.ToString());
            }
        }

        private String GetName()
        {
            ItemDictonary items = ItemDictonary.GetInstance();
            KeyValuePair<String, String> kvp;
            if (items.GetKeyValuePairByValue(out kvp, Id.ToString()))
            {
                return string.Format("{0}", kvp.Key, kvp.Value);
            }
            else
            {
                return string.Format("{0}", "<not in list>");
            }
        }
    }
}
