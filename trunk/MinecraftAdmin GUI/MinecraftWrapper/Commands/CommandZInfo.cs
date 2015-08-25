using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;
using MinecraftWrapper.Zones;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandZInfo : Command
    {
        public CommandZInfo(IMinecraftHandler mc)
            :base(mc,"zinfo")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            ZoneCollectionSingletone zones = ZoneCollectionSingletone.GetInstance();
            Zone zone = zones.GetZoneByPosition(Client.Position);
            if (zone != null)
            {
                Server.SendExecuteResponse(TriggerPlayer, string.Format("<{0}> is in zone <{1}> and the owner is <{2}>", TriggerPlayer, zone.Name, zone.Owner));
                Server.SendExecuteResponse(TriggerPlayer, String.Format("{0}",zone.Description));
                return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
            }

            return new CommandResult(true, string.Format("Player <{0}> is not in a zone", TriggerPlayer));
        }
    }
}
