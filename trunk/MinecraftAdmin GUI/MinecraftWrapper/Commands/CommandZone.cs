using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.Zones;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandZone : Command
    {
        public CommandZone(IMinecraftHandler mc)
            :base(mc,"zone")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            ZoneCollectionSingletone coll = ZoneCollectionSingletone.GetInstance();
            coll.Load();
            if (arg2.ToLower() == "p1" || arg2.ToLower() == "p2")
            {
                Zone zone = EasyGuess.GetMatchedZone(coll, arg1);
                if (zone != null)
                {
                    if (arg2 == "p1")
                    {
                        zone.Position1 = new MinecraftWrapper.Player.XPosition((int)Client.Position.X, (int)Client.Position.Y, (int)Client.Position.Z, 0, 0, 0, false);
                        coll.Save();
                        return new CommandResult(true, string.Format("{0} set zone {1} position 1", TriggerPlayer, zone.Name));
                    }

                    if (arg2 == "p2")
                    {
                        zone.Position2 = new MinecraftWrapper.Player.XPosition((int)Client.Position.X, (int)Client.Position.Y, (int)Client.Position.Z, 0, 0, 0, false);
                        coll.Save();
                        return new CommandResult(true, string.Format("{0} set zone {1} position 2", TriggerPlayer, zone.Name));
                    }
                }
                else
                {
                    return new CommandResult(true, string.Format("{0} zone not found",arg1));
                }
            }
            else if (!String.IsNullOrEmpty(arg1))
            {
                Zone zone = ZoneCollectionSingletone.GetInstance().GetZoneByName(arg1);
                if (zone == null)
                {
                    zone = new Zone(arg1);
                    if (!MinecraftHandler.IsStringInList(TriggerPlayer, zone.Whitelist))
                    {
                        zone.Whitelist.Add(TriggerPlayer);
                    }
                    zone.LevelID = ClientUser.LevelID;
                    zone.Owner = TriggerPlayer;
                    zone.Position1 = new MinecraftWrapper.Player.XPosition((int)Client.Position.X, (int)Client.Position.Y, (int)Client.Position.Z, 0, 0, 0, false);
                    zone.Position2 = new MinecraftWrapper.Player.XPosition((int)Client.Position.X, (int)Client.Position.Y, (int)Client.Position.Z, 0, 0, 0, false);
                    coll.Add(zone);
                    coll.Save();
                    return new CommandResult(true, string.Format("{0} created zone {1}", TriggerPlayer, arg1));
                }
                else
                {
                    return new CommandResult(true, string.Format("Zone {0} is allready in use", zone.Name));
                }
            }

            return new CommandResult();
        }
    }
    
}
