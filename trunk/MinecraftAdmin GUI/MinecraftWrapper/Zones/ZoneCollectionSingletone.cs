using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using MinecraftWrapper.Blocks;
using Vitt.Andre.XML;
using MinecraftWrapper.Player;
using Zicore.MinecraftAdmin;

namespace MinecraftWrapper.Zones
{
    public sealed class ZoneCollectionSingletone
    {
        private ZoneCollectionSingletone()
        {
            Load();
        }

        private static volatile ZoneCollectionSingletone instance = null;
        private static object m_lock = new object();

        public static ZoneCollectionSingletone GetInstance()
        {
            // DoubleLock
            if (instance == null)
            {
                lock (m_lock)
                {
                    if (instance == null)
                    {
                        instance = new ZoneCollectionSingletone();
                    }
                }
            }
            return instance;
        }


        public void Add(Zone zone)
        {
            this.Items.Add(zone);
        }

        public void RemoveAt(int index)
        {
            this.Items.RemoveAt(index);
        }

        public  static String File = "Zones.xml";

        ZoneCollection items = new ZoneCollection();

        
        public ZoneCollection Items
        {
            get { return items; }
            set { items = value; }
        }

        public bool ContainsZone(String id)
        {
            foreach (Zone b in this.Items)
            {
                if (b.Name == id)
                    return true;
            }
            return false;
        }

        public Zone GetZoneByName(String id)
        {
            foreach (Zone b in this.Items)
            {
                if (b.Name == id)
                    return b;
            }
            return null;
        }
        
        public Zone GetZoneByPosition(XPosition x)
        {
            foreach (Zone z in this.Items)
            {
                if(z.ZonePointIntersection(z.Position1,z.Position2,x))
                    return z;
            }
            return null;
        }

        private void Load(String path)
        {
            try
            {
                this.Items = XObject<ZoneCollection>.Load(path);
            }
            catch
            {

            }
        }

        private void Save(String path)
        {
            try
            {
                XObject<ZoneCollection>.Save(this.Items, path);
            }
            catch
            {

            }
        }

        public void Save()
        {
            Save(Config.ConfigFolder + File);
        }

        public void Load()
        {
            Load(Config.ConfigFolder + File);
        }
    }
}
