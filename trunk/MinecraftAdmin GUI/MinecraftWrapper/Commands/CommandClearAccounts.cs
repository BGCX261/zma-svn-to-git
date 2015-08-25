using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using Zicore.MinecraftAdmin.Admins;
using Zicore.MinecraftAdmin.IO;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandClearAccounts : Command
    {
        public CommandClearAccounts(IMinecraftHandler mc)
            :base(mc,"clearaccounts")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            try
            {
                int money = 500;
                try
                {
                    money = Convert.ToInt32(arg1);
                }
                catch
                {

                }
                UserCollectionSingletone userCollection = UserCollectionSingletone.GetInstance();
                foreach (User u in userCollection.Items)
                {
                    if (ClientUser.LevelID != 0)
                    {
                        u.Balance = money;
                    }
                }

                return new CommandResult(true, String.Format("{0} has reset the giro accounts to §6{1} {2}", TriggerPlayer, money, MinecraftHandler.Config.CurrencySymbol));
            }
            catch
            {
                Log.Append(this, "Exception while executing ClearCommands", Log.ExceptionsLog);
                return new CommandResult(true, String.Format("Exception while executing ClearCommands"));                
            }
        }
    }
}
