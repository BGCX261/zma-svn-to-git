using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.Zones;
using Zicore.MinecraftAdmin.Admins;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandZones : Command
    {
        public CommandZones(IMinecraftHandler mc)
            : base(mc, "zones")
        {

        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            var mc = MinecraftHandler;
            ZoneCollectionSingletone coll = ZoneCollectionSingletone.GetInstance();

            StringBuilder builder = new StringBuilder();
            List<String> lines = new List<string>();

            if (coll.Items.Count > 0)
            {
                builder.AppendFormat("Zones: ");
                for (int i = 0; i < coll.Items.Count; i++)
                {
                    Zone zone = coll.Items[i];
                    String name = zone.Name.Trim();

                    if (!String.IsNullOrEmpty(name))
                    {
                        if (builder.Length + name.Length + mc.Config.ResponsePrefix.Length <= 70)
                        {
                            builder.AppendFormat("§f<§{0}{1}§f> ", zone.Level.GroupColor, name);
                        }
                        else
                        {
                            lines.Add(builder.ToString());
                            builder = new StringBuilder();
                            i--;
                        }
                    }
                }

                if (builder.Length + mc.Config.ResponsePrefix.Length <= 70)
                {
                    lines.Add(builder.ToString());
                }

                //MinecraftHandler.ExecuteSay(result);
                foreach (String line in lines)
                {
                    Server.SendExecuteResponse(TriggerPlayer, line);
                }
            }

            return new CommandResult(true, String.Format("Zones executed by {0}", TriggerPlayer));

        }
    }

}
