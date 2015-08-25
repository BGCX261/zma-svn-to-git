using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.Zones;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandZOwner : Command
    {
        public CommandZOwner(IMinecraftHandler mc)
            : base(mc, "zowner")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            ZoneCollectionSingletone coll = ZoneCollectionSingletone.GetInstance();
            Zone zone = EasyGuess.GetMatchedZone(coll, arg1);
            if (zone != null)
            {                
                String match = EasyGuess.GetMatchedString(MinecraftHandler.Player, arg2);
                if (!String.IsNullOrEmpty(match))
                {
                    if (TriggerPlayer == ClientUser.Name || ClientUser.LevelID > zone.LevelID)
                    {
                        zone.Owner = match;
                        coll.Save();
                        return new CommandResult(true, String.Format("Zone-Owner of zone {0} is now {1}", zone.Name, match));
                    }
                    else
                    {
                        return new CommandResult(true, String.Format("Insufficient permissions to set the owner"));
                    }
                }
                else
                {
                    return new CommandResult(true, String.Format("User not found {0}", match));
                }
            }
            else
            {
                return new CommandResult(true, String.Format("Zone not found: {0}",arg1));
            }
        }
    }
    
}
