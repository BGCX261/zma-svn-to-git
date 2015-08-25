using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;
using MinecraftWrapper.Zones;
using Vitt.Andre.XML;

namespace Zicore.MinecraftAdmin
{
    public sealed class GroupCollectionSingletone
    {
        private GroupCollectionSingletone()
        {
            Load();
        }

        private static volatile GroupCollectionSingletone instance = null;
        private static object m_lock = new object();

        public static GroupCollectionSingletone GetInstance()
        {
            // DoubleLock
            if (instance == null)
            {
                lock (m_lock)
                {
                    if (instance == null)
                    {
                        instance = new GroupCollectionSingletone();
                    }
                }
            }
            return instance;
        }

        public static String File = "Groups.xml";


        GroupCollection items = new GroupCollection();

        public GroupCollection Items
        {
            get { return items; }
            set { items = value; }
        }

        public IEnumerator<Group> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        public  Group GetGroupByID(int id)
        {
            foreach(Group lv in this){
                if (lv.Id == id)
                    return lv;
            }
            return new Group("Guests", 0);
        }

        public Group GetGroupByName(string name)
        {
            foreach (Group lv in this)
            {
                if (lv.Name == name)
                    return lv;
            }
            return new Group("Guests", 0);
        }

        //public Zone GetZoneByPosition(ZoneCollectionSingletone collection, XPosition x)
        //{
        //    foreach (Zone z in collection)
        //    {
        //        if (z.ZonePointIntersection(z.Position1, z.Position2, x))
        //            return z;
        //    }
        //    return null;
        //}

        private void Load(String path)
        {
            try
            {
                this.Items = XObject<GroupCollection>.Load(path);
            }
            catch
            {

            }
        }

        private void Save(String path)
        {
            try
            {
                XObject<GroupCollection>.Save(this.Items, path);
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

        public void Add(Group zone)
        {
            this.Items.Add(zone);
        }

        public void RemoveAt(int index)
        {
            this.Items.RemoveAt(index);
        }
    }
}
