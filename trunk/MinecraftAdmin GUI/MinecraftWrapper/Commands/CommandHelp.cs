using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandHelp : Command
    {
        public CommandHelp(IMinecraftHandler mc)
            :base(mc,"help")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {

            if (!String.IsNullOrEmpty(arg1))
            {
                CommandManager c = CommandManager.GetInstance((MinecraftHandler)MinecraftHandler);
                String match = EasyGuess.GetMatchedCommand(c, arg1);
                if (!String.IsNullOrEmpty(match))
                {
                    Command cmd = c.Items[match];

                    if (cmd != null)
                        Server.SendExecuteResponse(TriggerPlayer, cmd.Help);
                    else
                        Server.SendExecuteResponse(TriggerPlayer, "Command not found");
                }
                else
                {
                    Server.SendExecuteResponse(TriggerPlayer, "Command not found");
                }
            }
            else
            {
                //MinecraftHandler.ExecuteCommands(User);
                Group g = ClientUser.Level;

                StringBuilder builder = new StringBuilder();

                foreach (String str in ClientUser.Level.Commands)
                {
                    builder.AppendFormat(MinecraftHandler.Config.CommandChar + "{0}, ", str);
                }

                Server.SendExecuteResponse(TriggerPlayer, builder.ToString());

                //ExecuteCommand("say", builder.ToString());
            }

            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
