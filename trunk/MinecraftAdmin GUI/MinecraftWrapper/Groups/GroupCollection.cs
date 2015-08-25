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
using Library.Forms;

namespace Zicore.MinecraftAdmin
{
    [XmlRootAttribute("GroupCollection", Namespace = "", IsNullable = false)]
    public class GroupCollection : SortableBindingList<Group>
    {

    }
}
