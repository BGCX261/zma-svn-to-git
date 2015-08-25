using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.Zones;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandZMessage : Command
    {
        public CommandZMessage(IMinecraftHandler mc)
            :base(mc,"zmessage")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            ZoneCollectionSingletone coll = ZoneCollectionSingletone.GetInstance();
            Zone zone = EasyGuess.GetMatchedZone(coll, arg1);
            if (zone != null)
            {
                if (!String.IsNullOrEmpty(arg1))
                {
                    if (TriggerPlayer == ClientUser.Name || ClientUser.LevelID > zone.LevelID)
                    {
                        String message = RegArg.Substring(arg1.Length).Trim();
                        zone.WelcomeMessage = message;
                        coll.Save();
                        return new CommandResult(true, String.Format("Zone-Message of zone {0} is now {1}", zone.Name, message));
                    }
                    else
                    {
                        return new CommandResult(true, String.Format("Insufficient permissions to set the message"));
                    }
                }
                else
                {
                    return new CommandResult(true, String.Format("Zone-Message is empty"));
                }
            }
            else
            {
                return new CommandResult(true, String.Format("Zone not found: {0}",arg1));
            }
        }
    }
    
}
