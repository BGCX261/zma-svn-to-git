using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;
using MinecraftWrapper.Chat;
using Vitt.Andre.Tunnel;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandLeaveChannel : Command
    {
        public CommandLeaveChannel(IMinecraftHandler mc)
            :base(mc,"leave")
        {
            
        }

        public override CommandResult Execute(String chan,String arg2, String arg3, String arg4)
        {
            if (!String.IsNullOrEmpty(chan))
            {
                ServerSocket server = (ServerSocket)Server;
                if (chan.Length <= 12 && chan.Length >= 3 || chan.Length == 1 && chan[0] == '*')
                {
                    Channel channel = server.Channels.Find(chan);
                    if (channel != null)
                    {
                        channel.User.Remove(ClientUser);
                        if (channel.User.Count <= 0)
                        {
                            if (channel.Name != "*")
                            {
                                server.Channels.Remove(channel);
                            }
                        }
                        return new CommandResult(true, String.Format("{0} left channel {1}",TriggerPlayer, channel.Name));
                    }
                    else
                    {
                        return new CommandResult(true, String.Format("You're not in channel {0}", channel.Name), true);
                    }
                }
                else
                {
                    // channel name length must be between 3 and 12
                    return new CommandResult(true, String.Format("Channel name length must be between 3 and 12"), true);
                }
            }
            else
            {
                return new CommandResult(true, String.Format("Unknown Argument"), true);
            }
        }
    }
}
