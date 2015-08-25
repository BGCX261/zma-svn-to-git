using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.Zones;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandZBlocklevel : Command
    {
        public CommandZBlocklevel(IMinecraftHandler mc)
            : base(mc, "zblocklevel")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            ZoneCollectionSingletone coll = ZoneCollectionSingletone.GetInstance();
            Zone zone = EasyGuess.GetMatchedZone(coll, arg1);
            if (zone != null)
            {
                int level = 0;
                if (int.TryParse(arg2,out level))
                {
                    if (TriggerPlayer == ClientUser.Name || ClientUser.LevelID > zone.LevelID)
                    {
                        int setLevel = 0;
                        if (ClientUser.Level.BlockLevel < level || level < 0)
                        {
                            setLevel = ClientUser.Level.BlockLevel;
                        }
                        else
                        {
                            setLevel = level;
                        }
                        coll.Save();
                        return new CommandResult(true, String.Format("Zone-Level of zone {0} is now {1}", zone.Name, setLevel));
                    }
                    else
                    {
                        return new CommandResult(true, String.Format("Insufficient permissions to set the blocklevel"));
                    }
                }
                else
                {
                    return new CommandResult(true, String.Format("Invalid blocklevel {0}", arg2));
                }
            }
            else
            {
                return new CommandResult(true, String.Format("Zone not found: {0}",arg1));
            }
        }
    }
    
}
