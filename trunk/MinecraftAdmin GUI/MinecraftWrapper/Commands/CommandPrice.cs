using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.Blocks;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandPrice : Command
    {
        public CommandPrice(IMinecraftHandler mc)
            :base(mc,"price")
        {
            
        }

        public override CommandResult Execute(String id, String amount, String user, String admin)
        {
            try
            {
                int result = 0;
                bool IsNumber = int.TryParse(id, out result);

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

                if (String.IsNullOrEmpty(id) || (String.IsNullOrEmpty(itemName)&& !IsNumber ))
                {
                    return new CommandResult(true, string.Format("Invalid ID!"));
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

                if (!String.IsNullOrEmpty(itemName))
                {
                    BlockItem block = MinecraftHandler.PricedBlocks.GetBlockById(idValue);
                    if (block == null)
                    {
                        return new CommandResult(true, String.Format("Item is not for sale {0}[{1}]", itemName,idValue));
                    }
                    int price = block.Price * amountInt;
                    return new CommandResult(true, String.Format("Price for {0}[{1}] in an amount of {2} is §6{3} {4}.", itemName, idValue, amountInt, price, MinecraftHandler.Config.CurrencySymbol));
                }
                else
                {
                    BlockItem block = MinecraftHandler.PricedBlocks.GetBlockById(idValue);
                    if (block == null)
                    {
                        return new CommandResult(true, String.Format("Item is not for sale {0}",id));
                    }
                    int price = block.Price * amountInt;
                    return new CommandResult(true, String.Format("Price for [{1}] in an amount of {2} is §6{3} {4}.", itemName, idValue, amountInt, price, MinecraftHandler.Config.CurrencySymbol));
                }
            }
            catch
            {
                return new CommandResult(true, String.Format("Something went wrong while executing price ;-)"));
            }
        }
    }
}
