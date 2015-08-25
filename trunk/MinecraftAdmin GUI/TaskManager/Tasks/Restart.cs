using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zicore.TaskManagerLib;
using System.IO;
using Zicore.MinecraftAdmin;
using System.Xml.Serialization;
using System.Threading;

namespace Zicore.TaskManagerLib.Tasks
{    
    public class Restart : TaskBase
    {
        public Restart()
        {
            StartedTime = DateTime.Now;
        }

        MinecraftHandler mc;

        public Restart(MinecraftHandler mc)
        {
            this.mc = mc;
        }

        protected override void Completed()
        {
            StatusMessage = "Restart complete!";
            base.Completed();
        }

        public override void StartTask()
        {
            base.StartTask();
        }

        protected override void Run()
        {
            mc.RaiseStopped();           
            mc.ServerExited += new MinecraftHandler.OnServerExited(mc_ServerExited);
        }

        void mc_ServerExited(object sender)
        {
            if (!mc.Started)
            {
                Thread.Sleep(500);
                mc.RaiseStarted();
            }
            mc.ServerExited -= new MinecraftHandler.OnServerExited(mc_ServerExited);
        }

        protected override void ProgressChanged()
        {
            StatusMessage = String.Format("{0}%/100%",Progress);
            base.ProgressChanged();
        }
    }
}
