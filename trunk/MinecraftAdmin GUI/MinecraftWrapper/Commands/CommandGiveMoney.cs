using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin.Admins;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandGiveMoney : Command
    {
        public CommandGiveMoney(IMinecraftHandler mc)
            :base(mc,"givemoney")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            if (ClientUser.LevelID != 0)
            {
                List<String> playerlist = MinecraftHandler.Player;
                string match = EasyGuess.GetMatchedString(playerlist, arg1);
                if (!String.IsNullOrEmpty(match))
                {
                    long balance = ClientUser.Balance;

                    long money = 0;
                    try
                    {
                        money = Convert.ToInt64(arg2);
                    }
                    catch { }

                    UserCollectionSingletone users = UserCollectionSingletone.GetInstance();
                    User u = users.GetUserByName(match);
                    if (u != null)
                    {
                        return GiveMoney( u, money);
                    }
                }
                else
                {
                    return new CommandResult(true, String.Format("User <{0}> not found", arg1));
                }
            }
            else
            {
                return new CommandResult(true, String.Format("You don't have an account"));
            }
            return new CommandResult(true, String.Format("{0} execute by {1}", Name, TriggerPlayer));
        }

        private CommandResult GiveMoney(User u, long money)
        {
            if (u.LevelID != 0)
            {
                u.Balance += money;
                return new CommandResult(true, String.Format("{0} has given {1} §6{2} {3}.", TriggerPlayer,u.Name, money, MinecraftHandler.Config.CurrencySymbol));
            }
            return new CommandResult(true, String.Format("{0} execute by {1}", Name, TriggerPlayer));
        }
    }
}
