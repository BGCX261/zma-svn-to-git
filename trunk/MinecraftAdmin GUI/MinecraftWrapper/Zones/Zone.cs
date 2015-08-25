using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.Player;
using Zicore.MinecraftAdmin;
using System.Xml.Serialization;
using Vitt.Andre.XML;
using System.Drawing;

namespace MinecraftWrapper.Zones
{
    public class Zone
    {
        public double X1
        {
            get { return position1.X; }
            set { position1.X = value; }
        }

        public double Y1
        {
            get { return position1.Y; }
            set { position1.Y = value; }
        }

        public double Z1
        {
            get { return position1.Z; }
            set { position1.Z = value; }
        }


        public double X2
        {
            get { return position2.X; }
            set { position2.X = value; }
        }

        public double Y2
        {
            get { return position2.Y; }
            set { position2.Y = value; }
        }

        public double Z2
        {
            get { return position2.Z; }
            set { position2.Z = value; }
        }

        [XmlIgnore()]
        public Double Width
        {
            get
            {
                return Math.Abs(Position1.Z - Position2.Z);
            }
        }

        [XmlIgnore()]
        public Double Height
        {
            get
            {
                return Math.Abs(Position1.X - Position2.X);
            }
        }

        bool isWhiteZone = false;

        public bool IsWhiteZone
        {
            get { return isWhiteZone; }
            set { isWhiteZone = value; }
        }

        bool fixToGroup = false;

        public bool FixToGroup
        {
            get { return fixToGroup; }
            set { fixToGroup = value; }
        }

        List<String> whitelist = new List<string>();

        public List<String> Whitelist
        {
            get { return whitelist; }
            set { whitelist = value; }
        }

        public bool ZonePointIntersection(XPosition p1, XPosition p2, XPosition value)
        {
            if (p1.X > p2.X)
            {
                double temp = p1.X;
                p1.X = p2.X;
                p2.X = temp;
            }

            if (p1.Y > p2.Y)
            {
                double temp = p1.Y;
                p1.Y = p2.Y;
                p2.Y = temp;
            }

            if (p1.Z > p2.Z)
            {
                double temp = p1.Z;
                p1.Z = p2.Z;
                p2.Z = temp;
            }
            //ZoneSwapPos(ref p1,ref p2);

            double width = p1.X - p2.X;
            double height = p1.Z - p2.Z;

            if (value.X > p1.X && value.X < p2.X)
            {
                if (value.Z > p1.Z && value.Z < p2.Z)
                    if (value.Y > p1.Y && value.Y < p2.Y)
                    return true;
            }

            return false;
        }

        public void ZoneSwapPos(ref XPosition p1,ref XPosition p2)
        {
            double temp;
            if (p1.X > p2.X)
            {
                temp = p1.X;
                p1.X = p2.X;
                p2.X = temp;
            }
            if (p1.Y > p2.Y)
            {
                temp = p1.Y;
                p1.X = p2.Y;
                p2.Y = temp;
            }
            if (p1.Z > p2.Z)
            {
                temp = p1.Z;
                p1.Z = p2.Z;
                p2.Z = temp;
            }
        }

        string description = "Description!";

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        string welcomeMessage = "Welcome!";

        public string WelcomeMessage
        {
            get { return welcomeMessage; }
            set { welcomeMessage = value; }
        }

        string owner = "";

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        string name = "rename";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        XPosition position1 = new XPosition();

        public XPosition Position1
        {
            get { return position1; }
            set { position1 = value; }
        }

        XPosition position2 = new XPosition();

        public XPosition Position2
        {
            get { return position2; }
            set { position2 = value; }
        }

        public void SetPoint(double x, double y, double z)
        {
            position1 = new XPosition(x, y, z, 0.0, 0.0f, 0.0f, false);
        }

        public Zone()
        {

        }

        public Zone(String name)
        {
            this.Name = name;
        }

        private int _levelID = 0;

        public int LevelID
        {
            get { return _levelID; }
            set { _levelID = value; }
        }

        int blockLevel = 1;

        public int BlockLevel
        {
            get { return blockLevel; }
            set { blockLevel = value; }
        }

        bool allowDestroy = true;

        public bool AllowDestroy
        {
            get { return allowDestroy; }
            set { allowDestroy = value; }
        }

        bool allowBuild = true;

        public bool AllowBuild
        {
            get { return allowBuild; }
            set { allowBuild = value; }
        }

        [XmlIgnore()]
        public Group Level
        {
            get
            {
                try
                {
                    GroupCollectionSingletone levels = GroupCollectionSingletone.GetInstance();
                    return levels.GetGroupByID(LevelID);
                }
                catch
                {
                    return new Group("Guests", 0);
                }
            }
            set
            {
                try
                {
                    GroupCollectionSingletone levels = GroupCollectionSingletone.GetInstance();
                    Group level = levels.GetGroupByID(LevelID);
                    level = value;
                }
                catch
                {
                }
            }
        }

        [XmlIgnore()]
        public String LevelName
        {
            get
            {
                return Level.Name;
            }
        }
    }
}
