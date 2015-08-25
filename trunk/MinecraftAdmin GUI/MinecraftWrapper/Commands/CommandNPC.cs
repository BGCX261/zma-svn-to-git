using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.AddonInterface;
using MinecraftWrapper.Tunnel;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandNPC : Command
    {
        public CommandNPC(IMinecraftHandler mc)
            :base(mc,"npc")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            try
            {
                MinecraftHandler mc = (MinecraftHandler)MinecraftHandler;
                int amount = Convert.ToInt32(arg3);

                ClientNpc npc = mc.Npcs[arg1];
                if(npc != null)
                {
                    if (arg2 == "x")
                    {
                        npc.Position.X += amount;
                    }
                    if (arg2 == "y")
                    {
                        npc.Position.Y += amount;
                    }
                    if (arg2 == "z")
                    {
                        npc.Position.Z += amount;
                    }
                }
            }
            catch 
            { 
                return new CommandResult(true,String.Format("Exception while executing CommandNPC"),true);
            }

            return new CommandResult(true, String.Format("{0} execute by {1}", Name, TriggerPlayer), true);
        }
    }
}
