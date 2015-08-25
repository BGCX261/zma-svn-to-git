using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.Blocks;
using Vitt.Andre.XML;

namespace MinecraftWrapper.XML
{
    public abstract class XClass
    {
        public XClass()
        {

        }

        public static XClass Load(String path)
        {
            try
            {
                return XObject<XClass>.Load(path);
            }
            catch
            {

            }
            return null;
        }

        public virtual void Save(String path)
        {
            try
            {
                XObject<XClass>.Save(this, path);
            }
            catch
            {

            }
        }
    }
}
