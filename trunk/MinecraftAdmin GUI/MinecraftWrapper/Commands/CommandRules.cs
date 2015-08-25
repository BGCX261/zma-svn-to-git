using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin.IO;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandRules : Command
    {
        public CommandRules(IMinecraftHandler mc)
            :base(mc,"rules")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            //MinecraftHandler.ExecuteMOTD(MinecraftHandler.Config.Rules, TriggerPlayer);
            string[] lines = MinecraftHandler.Config.Rules;
            try
            {
                if (lines != null)
                {
                    foreach (String str in lines)
                    {
                        //ExecuteSay(string.Format(str, text));
                        Server.SendExecuteResponse(TriggerPlayer, str);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.AppendText(ex.Message + " CommandRules", "exceptions.txt");
            }

            return new CommandResult(true, string.Format("{0} executed by {1}",Name, TriggerPlayer));
        }
    }
}
