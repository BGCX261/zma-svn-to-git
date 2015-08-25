using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.Zones;
using Zicore.MinecraftAdmin.Admins;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    class CommandZAdd : Command
    {
        public CommandZAdd(IMinecraftHandler mc)
            :base(mc,"zadd")
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
                if (user.Generated)
                {
                    user = new User(TriggerPlayer, false);
                    user.LevelID = 0;
                    UserCollectionSingletone.GetInstance().Add(user);
                    UserCollectionSingletone.GetInstance().Save();
                }
                if (TriggerPlayer == zone.Owner || ClientUser.LevelID > zone.LevelID)
                {
                    if (!MinecraftHandler.IsStringInList(user.Name, zone.Whitelist))
                    {
                        zone.Whitelist.Add(user.Name);
                        return new CommandResult(true, String.Format("{0} has added user {1} to Zone {2}", TriggerPlayer, user.Name, zone.Name));
                    }
                    else
                    {
                        return new CommandResult(true, String.Format("User {0} is allready in Zone {1}", user.Name, zone.Name));
                    }
                }
                else
                {
                    return new CommandResult(true, String.Format("You cannot whitelist, you need to be the owner or have an higher id"));
                }
            }
            else
            {
                return new CommandResult(true, String.Format("Zone not found: {0}",arg1));
            }
        }
    }
    
}
