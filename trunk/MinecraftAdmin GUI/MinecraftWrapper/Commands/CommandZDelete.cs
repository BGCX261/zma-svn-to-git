using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.Zones;
using Zicore.MinecraftAdmin.Admins;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    class CommandZDelete : Command
    {
        public CommandZDelete(IMinecraftHandler mc)
            :base(mc,"zdelete")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            try
            {
                ZoneCollectionSingletone coll = ZoneCollectionSingletone.GetInstance();

                Zone zone = EasyGuess.GetMatchedZone(coll, arg1);
                if (zone != null)
                {
                    if (ClientUser.LevelID > zone.LevelID || TriggerPlayer == zone.Owner)
                    {
                        String name = zone.Name;
                        coll.Items.Remove(zone);
                        coll.Save();
                        return new CommandResult(true, String.Format("Zone {0} removed by {1}", name, TriggerPlayer));
                    }
                    else
                    {
                        return new CommandResult(true, String.Format("Insufficient permissions to delete a zone"));
                    }
                }
                else
                {
                    return new CommandResult(true, String.Format("Zone not found: {0}", arg1));
                }
            }
            catch
            {
                return new CommandResult(true, String.Format("Zone not found: {0}", arg1));
            }
        }
    }
    
}
