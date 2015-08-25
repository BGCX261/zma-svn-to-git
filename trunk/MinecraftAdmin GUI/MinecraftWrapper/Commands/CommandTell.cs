using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandTell : Command
    {
        public CommandTell(IMinecraftHandler mc)
            :base(mc,"tell")
        {
            
        }

        public override CommandResult Execute(String name, String arg2, String arg3, String arg4)
        {
            List<String> playerlist = MinecraftHandler.Player;
            string match = EasyGuess.GetMatchedString(playerlist, name);
            string text = RegArg.Remove(0, name.Length+1);
            if (!String.IsNullOrEmpty(match))
            {
                //MinecraftHandler.ExecuteCommand("tell", match, text);
                Server.SendMessageToClient(match,string.Format("<{0}> {1}",TriggerPlayer,text),'7');
                Server.SendMessageToClient(TriggerPlayer, string.Format("whispers ({0}) to {1}", text, match), '7');
            }

            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
