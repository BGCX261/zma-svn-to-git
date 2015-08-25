﻿using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandTo : Command
    {
        public CommandTo(IMinecraftHandler mc)
            :base(mc,"to")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            List<String> playerlist = MinecraftHandler.Player;
            string match = EasyGuess.GetMatchedString(playerlist, arg1);
            if (!String.IsNullOrEmpty(match))
            {
                if (!String.IsNullOrEmpty(TriggerPlayer))
                {
                    MinecraftHandler.ExecuteTeleport(TriggerPlayer, match);
                    return new CommandResult(true, string.Format("{0} teleported to {1}", TriggerPlayer, match));
                }
            }
            return new CommandResult();
        }
    }
}
