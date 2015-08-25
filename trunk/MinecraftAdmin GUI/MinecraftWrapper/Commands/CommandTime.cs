using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin.Commands;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.Player;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandTime : Command
    {
        public CommandTime(IMinecraftHandler mc)
            :base(mc,"time")
        {
            
        }

        private double GetSeconds(long ticks)
        {
            return (((ticks % 24000) + 6000) / 1000.0) * 60 * 60;
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            try
            {
                if (!String.IsNullOrEmpty(arg1))
                {
                    if (arg1.ToLower() != "off")
                    {
                         int time = 0;
                        if (Int32.TryParse(arg1, out time))
                        {
                            if (time >= 0 && time <= 24)
                            {
                                Server.OverrideTimeOfDay = true;
                                Server.TimeOfDay = (time - 6) * 1000L;
                                return new CommandResult(true, string.Format("{0} set time to {1}:00", TriggerPlayer, time.ToString()));
                            }
                            else
                            {
                                return new CommandResult(true, string.Format("{0} time must be between 0 and 24", TriggerPlayer));
                            }
                        }
                        else
                        {
                            return new CommandResult(true, string.Format("{0} entered a wrong time", TriggerPlayer));
                        }
                    }
                    else
                    {
                        Server.OverrideTimeOfDay = false;
                        return new CommandResult(true, string.Format("{0} disabled time of day override", TriggerPlayer));
                    }
                }
                else
                {
                    TimeSpan tsReal = new TimeSpan(0, 0, (int)GetSeconds(Server.RealTimeOfDay));
                    TimeSpan tsOverride = new TimeSpan(0, 0,(int)GetSeconds(Server.TimeOfDay));

                    if (Server.OverrideTimeOfDay)
                    {
                        Server.SendExecuteResponse(TriggerPlayer, String.Format("Time {0:dd HH:mm:ss} Override enabled", tsOverride));                       
                    }
                    else
                    {
                        Server.SendExecuteResponse(TriggerPlayer, String.Format("Time {0:dd HH:mm:ss} Override disabled", tsReal));                        
                    }

                    return new CommandResult(true, string.Format("{0} shows up the time", TriggerPlayer));
                }
            }
            catch 
            {
                return new CommandResult(true, string.Format("{0} entered a wrong time", TriggerPlayer));
            }
        }
    }
}
