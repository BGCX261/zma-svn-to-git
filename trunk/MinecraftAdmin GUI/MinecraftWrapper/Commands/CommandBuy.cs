using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.Blocks;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandBuy : Command
    {
        public CommandBuy(IMinecraftHandler mc)
            :base(mc,"buy")
        {
            
        }

        public override CommandResult Execute(String id, String amount, String user, String admin)
        {
            try
            {
                int result = 0;
                bool IsNumber = int.TryParse(id, out result);

                List<String> playerlist = MinecraftHandler.Player;
                string match = EasyGuess.GetMatchedString(playerlist, user);

                string itemName = "";
                string idValue = "";
                if (!IsNumber)
                {
                    id = id.Replace('_', ' ');
                    KeyValuePair<String, String> kvp = EasyGuess.GetMatchedKeyValuePair(MinecraftHandler.Items, id);
                    idValue = kvp.Value;
                    itemName = kvp.Key;
                }
                else
                {
                    idValue = id;
                }

                int amountInt = 0;
                if (!String.IsNullOrEmpty(amount))
                {
                    amountInt = Convert.ToInt32(amount);
                }
                else
                {
                    amountInt = 1;
                }

                if (!String.IsNullOrEmpty(amount))
                {
                    if (amountInt <= 0 || amountInt >= int.MaxValue)
                    {
                        return new CommandResult(true, string.Format("Invalid amount!"));
                    }
                }


                if (String.IsNullOrEmpty(id))
                {
                    return new CommandResult();
                }
                string playerMatch = "";
                if (String.IsNullOrEmpty(amount))
                {
                    BlockItem block = MinecraftHandler.PricedBlocks.GetBlockById(idValue);
                    if (block == null)
                    {
                        return new CommandResult(true, String.Format("Item is not for sale {0}", id));
                    }
                    int price = block.Price * amountInt;

                    if (String.IsNullOrEmpty(match))
                    {
                        playerMatch = admin;

                        if (ClientUser.Balance >= block.Price)
                        {
                            ClientUser.Balance -= price;
                            SendTransferre(price, amountInt, ClientUser.Balance);
                            MinecraftHandler.ExecuteGive(admin, idValue, "1");
                        }
                        else
                        {
                            return new CommandResult(true, string.Format("You have not enough money"));
                        }
                    }
                    else
                    {
                        playerMatch = match;
                        
                        if (ClientUser.Balance >= block.Price)
                        {
                            ClientUser.Balance -= price;
                            SendTransferre(price, amountInt, ClientUser.Balance);
                            MinecraftHandler.ExecuteGive(match, idValue,"1");
                        }
                        else
                        {
                            return new CommandResult(true, string.Format("You have not enough money"));
                        }
                    }
                }
                else
                {
                    BlockItem block = MinecraftHandler.PricedBlocks.GetBlockById(idValue);
                    if (block == null)
                    {
                        return new CommandResult(true, String.Format("Item is not for sale {0}", id));
                    }
                    int price = block.Price * amountInt;

                    if (amountInt <= 0 || amountInt >= int.MaxValue)
                    {
                        return new CommandResult(true, string.Format("Invalid amount!"));
                    }

                    if (String.IsNullOrEmpty(match))
                    {
                        playerMatch = admin;

                        if (ClientUser.Balance >= price)
                        {
                            ClientUser.Balance -= price;
                            SendTransferre(price, amountInt, ClientUser.Balance);
                            MinecraftHandler.ExecuteGive(admin, idValue, amount);
                        }
                        else
                        {
                            return new CommandResult(true, string.Format("You have not enough money"));
                        }
                    }
                    else
                    {
                        playerMatch = match;
                        if (ClientUser.Balance >= price)
                        {
                            ClientUser.Balance -= price;
                            SendTransferre(price, amountInt, ClientUser.Balance);
                            MinecraftHandler.ExecuteGive(match, idValue, amount);
                        }
                        else
                        {
                            return new CommandResult(true, string.Format("You have not enough money"));
                        }
                    }
                }
                if (String.IsNullOrEmpty(itemName))
                {
                    return new CommandResult(true, string.Format("{0} has bought player {1} {2} by amount {3}", TriggerPlayer, playerMatch, idValue, amount));
                }
                else
                {
                    
                    return new CommandResult(true, string.Format("{0} has bought player {1} {2}[{3}] by amount {4}", TriggerPlayer, playerMatch, itemName, idValue, amount));
                }
            }
            catch
            {
                return new CommandResult(true, String.Format("Something went wrong while executing price ;-)"));
            }
        }

        private void SendTransferre(int price, int amount, long balance)
        {
            Server.SendExecuteResponse(TriggerPlayer,String.Format( "Youre balance is now §6{0} {1}.",ClientUser.Balance, MinecraftHandler.Config.CurrencySymbol));
        }
    }
}
