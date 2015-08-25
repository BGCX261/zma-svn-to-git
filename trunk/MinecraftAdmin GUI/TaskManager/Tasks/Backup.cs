using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zicore.TaskManagerLib;
using System.IO;
using Zicore.MinecraftAdmin;
using System.Xml.Serialization;

namespace Zicore.TaskManagerLib.Tasks
{
    
    public class Backup : TaskBase
    {
        public Backup()
        {
            StartedTime = DateTime.Now;
        }

        public Backup(string name)
        {
            this.Name = name;
        }

        int actualFiles = 0;
        int countFiles = 0;
        float status = 0;

        String source = "";

        public String Source
        {
            get { return source; }
            set { source = value; }
        }

        String destination = "";

        public String Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        protected override void Completed()
        {
            StatusMessage = "Backup complete!";
            base.Completed();
        }

        public void StartBackup(String source, String destination)
        {
            if (!String.IsNullOrEmpty(source) && !String.IsNullOrEmpty(destination))
            {
                this.Source = source;
                this.destination = destination;
                StartTask();
            }
            else
            {
                throw new ArgumentException("Argument must not be null or empty");
            }
        }

        public override void StartTask()
        {
            if (String.IsNullOrEmpty(source) || String.IsNullOrEmpty(destination))
                throw new ArgumentNullException("Argument must not be null or empty");

            if (!Directory.Exists(Source))
                throw new DirectoryNotFoundException("Source not found");

            if (!Directory.Exists(Destination))
                throw new DirectoryNotFoundException("Destination not found");
            
            base.StartTask();
        }

        protected override void Run()
        {
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"world");
            countFiles = new DirectoryInfo(directory).GetFiles("*.*", SearchOption.AllDirectories).Length;
            actualFiles = 0;
            status = 0;
            //yyyy-MM-dd HH:mm:ss
            String path = Path.Combine(Destination, String.Format("{0}_{1:HHmmss_yyyyMMdd}",Name, DateTime.Now));
            CopyDirectory(Source, path);
        }
        protected override void ProgressChanged()
        {
            StatusMessage = String.Format("{0}%/100%",Progress);
            base.ProgressChanged();
        }

        public void CopyDirectory(string Src, string Dst)
        {
            String[] Files;
            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst)) Directory.CreateDirectory(Dst);
            Files = Directory.GetFileSystemEntries(Src);
            foreach (string Element in Files)
            {
                if (Directory.Exists(Element))
                {
                    CopyDirectory(Element, Dst + Path.GetFileName(Element));
                }
                else
                {
                    File.Copy(Element, Dst + Path.GetFileName(Element), true);
                }

                actualFiles++;
                status = actualFiles * 100.0f / countFiles;
                if (status >= 100)
                {
                    status = 100;
                }

                if (worker.WorkerReportsProgress)
                {
                    worker.ReportProgress((int)status);
                }
            }
        }
    }
}
