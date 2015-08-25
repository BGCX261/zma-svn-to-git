using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.AddonInterface;
using Zicore.MinecraftAdmin.Admins;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandMODT : Command
    {
        public CommandMODT(IMinecraftHandler mc)
            :base(mc,"modt")
        {
            
        }

        public override CommandResult Execute(String name, String arg2, String arg3, String arg4)
        {
            try
            {
                if (MinecraftHandler.Config.SendModtToEveryone)
                {
                    foreach (String str in MinecraftHandler.Player)
                    {
                        foreach (String motdItem in MinecraftHandler.Config.Modt)
                        {
                            if (!String.IsNullOrEmpty(motdItem))
                            {
                                Server.SendExecuteResponse(str, String.Format(motdItem, name));
                            }
                        }
                    }
                }
                else
                {
                    foreach (String motdItem in MinecraftHandler.Config.Modt)
                    {
                        //String bla = Client.Name;
                        if (!String.IsNullOrEmpty(motdItem))
                        {
                            Server.SendExecuteResponse(TriggerPlayer, String.Format(motdItem, name));
                        }
                    }
                }
            }
            catch
            {
                return new CommandResult(true, string.Format("Exception while executing MOTD", Name, TriggerPlayer));
            }
            
            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
