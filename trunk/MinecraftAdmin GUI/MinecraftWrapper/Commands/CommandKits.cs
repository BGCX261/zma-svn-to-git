using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandKits : Command
    {
        public CommandKits(IMinecraftHandler mc)
            :base(mc,"kits")
        {
            
        }

        public override CommandResult Execute(String name, String arg2, String arg3, String arg4)
        {
            //MinecraftHandler.ExecuteKits(User);

            StringBuilder builder = new StringBuilder();

            List<Kit> kitlist = KitReader.GetKitlist(Config.ConfigFolder + KitReader.File);
            if (kitlist != null && kitlist.Count > 0)
            {
                foreach (Kit kit in kitlist)
                {
                    if (ClientUser.Level.Id >= kit.Level & !kit.FixedGroup || ClientUser.Level.Id == kit.Level & kit.FixedGroup)
                    {
                        builder.AppendFormat("<{0}> ", kit.Name);
                    }
                }

                Server.SendExecuteResponse(TriggerPlayer, builder.ToString());
            }

            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
