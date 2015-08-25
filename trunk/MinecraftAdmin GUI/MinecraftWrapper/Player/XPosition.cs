using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Vitt.Andre.XML;

namespace MinecraftWrapper.Player
{
    [XmlRootAttribute("XPosition", Namespace = "", IsNullable = false)]
    public class XPosition
    {
        public XPosition()
        {

        }

        public XPosition(Vector3 vec,double stance,float rotation, float pitch, bool unkown)
            : this(vec.X, vec.Y, vec.Z, stance, rotation,pitch,unkown)
        {
            
        }

        public Vector3 ToVector3()
        {
            return new Vector3(x, y, z);
        }

        public XPosition(double x, double y, double z, double stance, float rotation, float pitch, bool unkown)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.stance = stance;
        }

        double x = 0.0, y = 0.0, z = 0.0, stance = 0.0;
        float rotation = 0.0f, pitch = 0.0f;

        bool unkown = false;

        int uniqueID = -1;

        public int UniqueID
        {
            get { return uniqueID; }
            set { uniqueID = value; }
        }

        public bool Unkown
        {
            get { return unkown; }
            set { unkown = value; }
        }

        public float Pitch
        {
            get { return pitch; }
            set { pitch = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public double Stance
        {
            get { return stance; }
            set { stance = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public static XPosition Load(String path)
        {
            try
            {
                return XObject<XPosition>.Load(path);
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
                XObject<XPosition>.Save(this, path);
            }
            catch
            {

            }
        }

        public override string ToString()
        {
            int x = Convert.ToInt32(this.X);
            int y = Convert.ToInt32(this.Y);
            int z = Convert.ToInt32(this.Z);
            return String.Format("X({0}) Y({1}) Z({2})",x,y,z);
        }
    }
}
