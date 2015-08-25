using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.AddonInterface;
using MinecraftWrapper.Tunnel;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandAddNPC : Command
    {
        public CommandAddNPC(IMinecraftHandler mc)
            :base(mc,"addnpc")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            try
            {
                MinecraftHandler mc = (MinecraftHandler)MinecraftHandler;
                if(!String.IsNullOrEmpty(arg1))
                {
                    if (!mc.IsStringInList(arg1, mc.Player))
                    {
                        if (!mc.Npcs.ContainsKey(arg1))
                        {
                            ClientNpc npc = new ClientNpc(mc, arg1,"",TriggerPlayer);
                            npc.Connect();                            
                        }
                    }
                }
            }
            catch 
            { 
                return new CommandResult(true,String.Format("Exception while executing CommandNPC"),true);
            }

            return new CommandResult(true, String.Format("{0} executed by {1}", Name, TriggerPlayer), true);
        }
    }
}
