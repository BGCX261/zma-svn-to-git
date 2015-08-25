using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandInfo : Command
    {
        public CommandInfo(IMinecraftHandler mc)
            :base(mc,"info")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            Server.SendExecuteResponse(TriggerPlayer, "Server Time: " + DateTime.Now.ToString("HH:mm:ss"));
            if (MinecraftHandler.RestartActivated)
            {
                TimeSpan ts = this.MinecraftHandler.TimeUntilBackup;
                string text = "";
                string restartOrBackup = "";

                if (MinecraftHandler.Config.MakeBackup)
                {
                    restartOrBackup = "backup";
                }
                else
                {
                    restartOrBackup = "restart";
                }
                
                if (ts.TotalHours > 1)
                {
                    int n = Convert.ToInt32(ts.TotalMinutes);
                    int m = Convert.ToInt32(ts.Minutes);
                    int s = Convert.ToInt32(ts.Seconds);
                    if (n == 1)
                    {
                        text = String.Format("Automated " + restartOrBackup + " in 1 minute");
                    }
                    else
                    {
                        text = String.Format("Automated " + restartOrBackup + " in {0:0} minutes and {1:00} seconds", n, s);
                    }
                }
                else
                {
                    if (ts.TotalMinutes < 1)
                    {
                        int n = Convert.ToInt32(ts.TotalSeconds);
                        if (n == 1)
                        {
                            text = String.Format("Automated " + restartOrBackup + " in 1 second", n);
                        }
                        else
                        {
                            text = String.Format("Automated " + restartOrBackup + " in {0:0} seconds", n);
                        }
                    }
                    else if (ts.TotalHours < 1)
                    {
                        int n = Convert.ToInt32(ts.TotalMinutes);
                        int m = Convert.ToInt32(ts.Minutes);
                        int s = Convert.ToInt32(ts.Seconds);
                        if (n == 1)
                        {
                            text = String.Format("Automated " + restartOrBackup + " in 1 minute");
                        }
                        else
                        {
                            text = String.Format("Automated " + restartOrBackup + " in {0:0} minutes and {1:00} seconds", m, s);
                        }
                    }
                }
                //MinecraftHandler.ExecuteSay(text);
                Server.SendExecuteResponse(TriggerPlayer, text);
            }
            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
