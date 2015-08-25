using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandBalance : Command
    {
        public CommandBalance(IMinecraftHandler mc)
            :base(mc,"balance")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            if (ClientUser.LevelID != 0)
            {
                Server.SendExecuteResponse(TriggerPlayer, String.Format("Your current balance is §6{0} {1}", ClientUser.Balance, MinecraftHandler.Config.CurrencySymbol));
            }
            else
            {
                return new CommandResult(true, String.Format("You don't have an account"));
            }
            return new CommandResult(true,String.Format("{0} execute by {1}",Name, TriggerPlayer ));
        }
    }
}
