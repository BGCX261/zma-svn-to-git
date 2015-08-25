using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.Zones;
using Zicore.MinecraftAdmin.Admins;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    class CommandZList : Command
    {
        public CommandZList(IMinecraftHandler mc)
            :base(mc,"zlist")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            ZoneCollectionSingletone coll = ZoneCollectionSingletone.GetInstance();
            
            Zone zone = EasyGuess.GetMatchedZone(coll,arg1);
            if (zone != null)
            {
                StringBuilder builder = new StringBuilder();

                if (zone.Whitelist.Count > 0)
                {
                    builder.AppendFormat("Whitelist: ",zone.Name);
                    foreach (String player in zone.Whitelist)
                    {
                        User u = UserCollectionSingletone.GetInstance().GetUserByName(player);
                        builder.AppendFormat("§f<§{0}{1}§f> ", u.Level.GroupColor, player);
                    }

                    String result = builder.ToString();
                    if (!String.IsNullOrEmpty(result))
                    {
                        Server.SendExecuteResponse(TriggerPlayer, result);
                    }
                    coll.Save();
                }

                return new CommandResult(true, String.Format("Zone Whitelist executed by {0}", TriggerPlayer));
            }
            else
            {
                return new CommandResult(true, String.Format("Zone not found: {0}",arg1));
            }
        }
    }
    
}
