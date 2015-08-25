using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.Zones;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandZGroup : Command
    {
        public CommandZGroup(IMinecraftHandler mc)
            :base(mc,"zgroup")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            ZoneCollectionSingletone coll = ZoneCollectionSingletone.GetInstance();
            
            Zone zone = EasyGuess.GetMatchedZone(coll,arg1);
            if (zone != null)
            {
                GroupCollectionSingletone groups = GroupCollectionSingletone.GetInstance();
                Group group = EasyGuess.GetMatchedGroup(groups, arg2);
                if (group != null)
                {
                    if (ClientUser.LevelID >= group.Id && ClientUser.LevelID >= zone.LevelID)
                    {
                        zone.LevelID = group.Id;
                        return new CommandResult(true, String.Format("{0} has set zone's {1} group to {2}",TriggerPlayer ,zone.Name, group.Name));
                    }
                    else
                    {
                        return new CommandResult(true, String.Format("Insufficient permissions to set the zone group"));
                    }
                }
                else
                {
                    return new CommandResult(true, String.Format("Group not found: {0}", arg2));
                }
            }
            else
            {
                return new CommandResult(true, String.Format("Zone not found: {0}",arg1));
            }
        }
    }
    
}
