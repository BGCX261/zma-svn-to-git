using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Vitt.Andre.XML;

namespace MinecraftWrapper.Blocks
{
    [XmlRootAttribute("BlockCollection", Namespace = "", IsNullable = false)]
    public class BlockCollection : List<BlockItem>
    {
        public BlockCollection()
        {

        }

        public bool ContainsId(int id)
        {
            foreach (BlockItem b in this)
            {
                if (b.Id == id)
                    return true;
            }
            return false;
        }

        public BlockItem GetBlockById(int id)
        {
            foreach (BlockItem b in this)
            {
                if (b.Id == id)
                    return b;
            }
            return new BlockItem(1);
        }

        public BlockItem GetBlockById(string id)
        {
            foreach (BlockItem b in this)
            {
                if (b.Id.ToString() == id)
                    return b;
            }
            return null;
        }

        public static BlockCollection Load(String path)
        {
            try
            {
                return XObject<BlockCollection>.Load(path);
            }
            catch
            {

            }
            return null;
        }

        public void Save(String path)
        {
            try
            {
                XObject<BlockCollection>.Save(this, path);
            }
            catch
            {
                
            }
        }

        public static string PricedBlocksFile = "PricedBlocks.xml";
        public static string BadBlocksFile = "BadBlocks.xml";
        public static string GiveBlockList = "giveblocklist.xml";
    }
}
