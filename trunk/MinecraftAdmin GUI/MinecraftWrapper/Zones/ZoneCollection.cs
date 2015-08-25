using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using MinecraftWrapper.Blocks;
using Vitt.Andre.XML;
using MinecraftWrapper.Player;
using Library.Forms;

namespace MinecraftWrapper.Zones
{
    [XmlRootAttribute("ZoneCollection", Namespace = "", IsNullable = false)]
    public class ZoneCollection : SortableBindingList<Zone>
    {
        
    }
}
