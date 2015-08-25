using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.ExternalComponents;
using Zicore.SQLUtils;
using System.Threading;

namespace MinecraftWrapper.MainClasses
{
    public class DatabaseWorker
    {
        public DatabaseWorker(bool start)
        {
            if (start)
            {
                Start();
            }
        }

        public void Start()
        {
            isRunning = true;
            workingThread = new Thread(new ThreadStart(WorkerThread));
            workingThread.Start();
        }

        public void Stop()
        {
            isRunning = false;
        }

        public void AddAction(DatabaseAction action)
        {
            statements.Enqueue(action);
        }

        LockFreeQueue<DatabaseAction> statements = new LockFreeQueue<DatabaseAction>();

        Thread workingThread;

        MySQLConnector sql = MySQLConnector.GetInstance();

        public MySQLConnector Sql
        {
            get { return sql; }
            set { sql = value; }
        }

        bool isRunning = false;

        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }

        public void WorkerThread()
        {
            while (isRunning)
            {
                if (statements.Count > 0)
                {
                    DatabaseAction action = null;
                    if (statements.Dequeue(out action))
                    {
                        action.Action.Invoke();
                    }
                    else
                    {
                        Thread.Sleep(10);
                    }
                }
                else
                {
                    Thread.Sleep(10);
                }
            }
        }
    }
}
