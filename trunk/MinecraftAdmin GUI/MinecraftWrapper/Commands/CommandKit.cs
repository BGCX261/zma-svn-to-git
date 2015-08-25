using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandKit : Command
    {
        public CommandKit(IMinecraftHandler mc)
            :base(mc,"kit")
        {
            
        }

        public override CommandResult Execute(String name, String arg2, String arg3, String arg4)
        {
            //Kit kit = KitReader.GetKitFromName(Config.ConfigFolder + KitReader.File ,name);
            List<Kit> kitlist = KitReader.GetKitlist(Config.ConfigFolder + KitReader.File);
            Kit kit = EasyGuess.GetMatchedKit(kitlist, name);
            if (kit != null)
            {
                if (ClientUser.Level.Id >= kit.Level & !kit.FixedGroup || ClientUser.Level.Id == kit.Level & kit.FixedGroup)
                {
                    MinecraftHandler.ExecuteKit(kit, arg2, TriggerPlayer);
                    return new CommandResult(true, string.Format("{0} {1} executed by {2}", Name, kit.Name , TriggerPlayer));
                }
            }
            return new CommandResult();
        }
    }
}
