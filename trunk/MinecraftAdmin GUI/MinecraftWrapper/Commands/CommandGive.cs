using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandGive : Command
    {
        public CommandGive(IMinecraftHandler mc)
            :base(mc,"give")
        {
            
        }

        public override CommandResult Execute(String id, String amount, String user, String admin)
        {
            int result = 0;
            bool IsNumber = int.TryParse(id, out result);

            List<String> playerlist = MinecraftHandler.Player;
            string match = EasyGuess.GetMatchedString(playerlist, user);

            MinecraftHandler mc = (MinecraftHandler)MinecraftHandler;

            
            string itemName = "";
            string idValue = "";
            if (!IsNumber)
            {
                id = id.Replace('_', ' ');
                KeyValuePair<String,String> kvp = EasyGuess.GetMatchedKeyValuePair(MinecraftHandler.Items, id);
                idValue = kvp.Value;
                itemName = kvp.Key;
            }
            else
            {
                idValue = id;
            }
                

            if (String.IsNullOrEmpty(id))
            {
                return new CommandResult();
            }
            string playerMatch = "";
            if (String.IsNullOrEmpty(amount))
            {
                if (String.IsNullOrEmpty(match))
                {
                    playerMatch = admin;
                    mc.ExecuteGive(admin, idValue);
                }
                else
                {
                    playerMatch = match;
                    mc.ExecuteGive(match, idValue);
                }
            }
            else
            {
                if (String.IsNullOrEmpty(match))
                {
                    playerMatch = admin;

                    mc.ExecuteGive(admin, idValue, amount);                    
                }
                else
                {
                    playerMatch = match;

                    mc.ExecuteGive(match, idValue, amount);                    
                }                
            }
            if (String.IsNullOrEmpty(itemName))
            {
                return new CommandResult(true, string.Format("{0} has given player {1} {2} by amount {3}", TriggerPlayer, playerMatch, idValue, amount));
            }
            else
            {
                return new CommandResult(true, string.Format("{0} has given player {1} {2}[{3}] by amount {4}", TriggerPlayer, playerMatch, itemName, idValue, amount));
            }
        }
    }
}
