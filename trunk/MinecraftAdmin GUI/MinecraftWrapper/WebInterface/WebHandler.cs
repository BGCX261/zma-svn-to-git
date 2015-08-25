using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Zicore.MinecraftAdmin;
using Vitt.Andre.Tunnel;
using Zicore.SQLUtils;
using System.Net;
using Zicore.MinecraftAdmin.IO;

namespace MinecraftWrapper.WebInterface
{
    public class WebHandler
    {
        public WebHandler(MinecraftHandler mc, TcpTunnelServer tunnel)
        {
            this.tunnel = tunnel;
            this.mc = mc;
            string host = mc.Config.DatabaseHost;
            string user = mc.Config.DatabaseUser;
            string pass = mc.Config.DatabasePassword;
            string database = mc.Config.Database;
            int port = mc.Config.DatabasePort;

            sql = MySQLConnector.GetInstance();
            zma = new ZmaSQLConnection();            
        }

        const int SLEEP_TIME = 60000;

        ZmaSQLConnection zma;
        MySQLConnector sql;

        public void Start()
        {
            if (!isRunning && hasEnded)
            {
                isRunning = true;
                hasEnded = false;
                heartbeatThread = new Thread(new ThreadStart(HeartbeatThread));
                heartbeatThread.Start();
            }
        }

        public void Stop()
        {
            if (isRunning)
            {
                heartbeatThread.Interrupt();
                isRunning = false;
            }
        }

        public void Abort()
        {
            if (isRunning)
            {
                heartbeatThread.Interrupt();
                heartbeatThread.Abort();
            }
        }

        MinecraftHandler mc = null;
        TcpTunnelServer tunnel = null;

        Thread heartbeatThread;
        bool isRunning = false;
        bool hasEnded = true;

        private void HeartbeatThread()
        {
            while (isRunning)
            {
                if (mc.Config.StreamEnabled)
                {
                    mc.Config.ExternalIp = GetExternalIp();                
                    zma.Open();
                    zma.UpdateServer(mc, 1);
                    zma.UpdatePlayers(mc);
                    zma.Close();
                }
                try
                {
                    Thread.Sleep(SLEEP_TIME);
                }
                catch(ThreadInterruptedException)
                {
                    isRunning = false;
                }
            }
            hasEnded = true;
        }

        public string GetExternalIp()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Proxy = null;
                    return client.DownloadString("http://whatismyip.org");
                }
            }
            catch (Exception ex)
            {
                Log.Append(this,"GetExternalIp " + ex.Message, Log.ExceptionsLog);
                return "";
            }
        }
    }
}
