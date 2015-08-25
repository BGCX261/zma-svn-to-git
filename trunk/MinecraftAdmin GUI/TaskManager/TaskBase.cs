using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Xml.Serialization;
using Zicore.TaskManagerLib.Tasks;

namespace Zicore.TaskManagerLib
{
    [XmlInclude(typeof(Backup))]
    public class TaskBase
    {
        public TaskBase()
        {
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
        }

        protected BackgroundWorker worker = new BackgroundWorker();

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Completed();
            if (TaskCompleted != null)
            {
                TaskCompleted(this, e);
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressChanged();
            if (TaskProgressChanged != null)
            {
                TaskProgressChanged(this, e);
            }
        }

        protected virtual void Completed()
        {
            this.Finished = true;
            this.Progress = 100;
        }

        protected virtual void ProgressChanged()
        {

        }

        protected virtual void Run()
        {

        }

        protected virtual void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (IsRunning)
            {
                if (Active)
                {
                    if (!Started)
                    {
                        DateTime dt = startedTime;
                        if (Repeat)
                        {
                            dt += RepeatTimeSpan;
                        }

                        if (dt <= DateTime.Now)
                        {
                            Started = true;
                        }
                    }
                    else
                    {
                        Run();
                        startedTime = DateTime.Now;
                        endTime = startedTime + RepeatTimeSpan;
                        Finished = true;
                        Started = false;
                        IsRunning = Repeat;
                    }
                }
                Thread.Sleep(1000);
            }
        }

        #region Public Methods

        public virtual void StartTask()
        {
            if (!IsRunning)
            {
                if (!Repeat)
                {
                    RepeatTimeSpan = TimeSpan.Zero;
                }
                startedTime = DateTime.Now;
                EndTime = startedTime + RepeatTimeSpan;
                Started = false;
                Finished = false;
                IsRunning = true;
                worker.RunWorkerAsync();
            }
        }

        public void Dispose()
        {
            try
            {
                isRunning = false;
                started = false;
                active = false;
                finished = true;
                worker.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cancel()
        {
            worker.CancelAsync();
        }

        #endregion

        #region EventHandler

        public event ProgressChangedEventHandler TaskProgressChanged;
        public event RunWorkerCompletedEventHandler TaskCompleted;

        #endregion

        #region Member

        String name = "";

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        String statusMessage = "";

        public String StatusMessage
        {
            get { return statusMessage; }
            set { statusMessage = value; }
        }

        bool started = false;

        [XmlIgnore]
        public bool Started
        {
            get { return started; }
            set { started = value; }
        }

        bool repeat = false;


        public bool Repeat
        {
            get { return repeat; }
            set { repeat = value; }
        }

        bool instant = false;

        [XmlIgnore]
        public bool Instant
        {
            get { return instant; }
            set { instant = value; }
        }

        bool finished = true;

        [XmlIgnore]
        public bool Finished
        {
            get { return finished; }
            set { finished = value; }
        }

        bool active = true;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        bool isRunning = false;

        [XmlIgnore]
        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }

        DateTime startedTime = DateTime.Now;

        [XmlIgnore]
        public DateTime StartedTime
        {
            get { return startedTime; }
            set { startedTime = value; }
        }

        DateTime endTime = DateTime.Now;

        [XmlIgnore]
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        TimeSpan repeatTimeSpan = TimeSpan.Zero;

        [XmlIgnore]
        public TimeSpan RepeatTimeSpan
        {
            get { return repeatTimeSpan; }
            set { repeatTimeSpan = value; }
        }

        public long RepeatTimeTicks
        {
            get { return RepeatTimeSpan.Ticks; }
            set { RepeatTimeSpan = new TimeSpan(value); }
        }

        int progress = 0;

        [XmlIgnore]
        public int Progress
        {
            get { return progress; }
            set { progress = value; }
        }

        #endregion
    }
}
