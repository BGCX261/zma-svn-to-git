using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zicore.Xml;
using System.IO;
using Zicore.MinecraftAdmin;
using System.Xml.Serialization;

namespace Zicore.TaskManagerLib
{
    public class TaskConfig : XmlSerializable
    {
        public TaskConfig()
        {

        }

        [XmlIgnore]
        public static String TasksFile = "Tasks.xml";

        TaskCollection tasks = new TaskCollection();

        public TaskCollection Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }

        public override void Save()
        {
            String path = Path.Combine(Config.ConfigFolder, TasksFile);
            SaveAs(path);
        }

        public override void Load()
        {
            String path =  Path.Combine(Config.ConfigFolder,TasksFile);
            LoadFrom(path);
            Initialize();
        }

        public void Initialize()
        {
            foreach (var item in Tasks)
            {
                if (item.Repeat)
                {
                    item.StartTask();
                }
            }
        }
    }
}
