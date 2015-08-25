using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using Zicore.MinecraftAdmin.Admins;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandPay : Command
    {
        public CommandPay(IMinecraftHandler mc)
            :base(mc,"pay")
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
                        return Pay(ClientUser, u, money);
                    }
                }
                else
                {
                    return new CommandResult(true, String.Format("User <{0}> not found",arg1));
                }
            }
            else
            {
                return new CommandResult(true, String.Format("You don't have an account"));
            }
            return new CommandResult(true,String.Format("{0} execute by {1}",Name, TriggerPlayer ));
        }

        public CommandResult Pay(User user1, User user2, long currency)
        {
            if (user2.LevelID != 0)
            {
                if (currency > 0)
                {
                    if (user1.Balance >= currency)
                    {
                        user1.Balance -= currency;
                        user2.Balance += currency;
                        return new CommandResult(true, String.Format("{0} has transferred §6{1} {2} §{3}to {4}.", user1.Name, currency, MinecraftHandler.Config.CurrencySymbol, MinecraftHandler.Config.ResponseColorChar, user2.Name));
                    }
                    else
                    {
                        return new CommandResult(true, String.Format("{0} has not enough money", user1.Name));
                    }
                }
                else
                {
                    return new CommandResult(true, String.Format("The amount must be over 0"));
                }
            }
            else
            {
                return new CommandResult(true, String.Format("{0} has no giro account", user2.Name));
            }
        }
    }
}
