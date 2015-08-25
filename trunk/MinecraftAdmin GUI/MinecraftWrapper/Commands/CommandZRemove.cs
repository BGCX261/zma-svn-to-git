using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.Zones;
using Zicore.MinecraftAdmin.Admins;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandZRemove : Command
    {
        public CommandZRemove(IMinecraftHandler mc)
            :base(mc,"zremove")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            ZoneCollectionSingletone coll = ZoneCollectionSingletone.GetInstance();
            
            Zone zone = EasyGuess.GetMatchedZone(coll,arg1);
            if (zone != null)
            {
                String match = EasyGuess.GetMatchedString(MinecraftHandler.Player, arg2);
                User user = UserCollectionSingletone.GetInstance().GetUserByName(match);
                if (!user.Generated)
                {
                    if (ClientUser.LevelID >= zone.LevelID)
                    {
                        if (TriggerPlayer == zone.Owner || ClientUser.LevelID > zone.LevelID)
                        {
                            if (MinecraftHandler.IsStringInList(user.Name, zone.Whitelist))
                            {
                                zone.Whitelist.Remove(user.Name);
                                return new CommandResult(true, String.Format("{0} removed user {1} removed from zone {2}", TriggerPlayer, user.Name, zone.Name));
                            }
                            else
                            {
                                return new CommandResult(true, String.Format("User {0} is not in zone {1} whitelist", user.Name, zone.Name));
                            }
                        }
                        else
                        {
                            return new CommandResult(true, String.Format("You cannot whitelist, you need to be the owner or have an higher id"));
                        }
                    }
                    else
                    {
                        return new CommandResult(true, String.Format("Insufficient permissions to set remove a player from whitelist"));
                    }
                }
                else
                {
                    return new CommandResult(true, String.Format("User not found: {0}", arg1));
                }
            }
            else
            {
                return new CommandResult(true, String.Format("Zone not found: {0}",arg1));
            }
        }
    }
    
}
