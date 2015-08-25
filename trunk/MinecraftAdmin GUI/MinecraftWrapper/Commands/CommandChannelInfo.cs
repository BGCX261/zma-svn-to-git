using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;
using Vitt.Andre.Tunnel;
using Zicore.MinecraftAdmin.Admins;
using MinecraftWrapper.Chat;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandChannelInfo : Command
    {
        public CommandChannelInfo(IMinecraftHandler mc)
            :base(mc,"cinfo")
        {
            
        }

        public override CommandResult Execute(String chan,String pw, String arg3, String arg4)
        {
            if (!String.IsNullOrEmpty(chan))
            {
                Channel channel = EasyGuess.GetMatchedChannel(((ServerSocket)Server).Channels, chan);
                if (channel != null)
                {
                    String str = "";
                    UserCollection usersOnline = new UserCollection();

                    foreach (User u in channel.User)
                    {
                        if (MinecraftHandler.IsStringInList(u.Name, MinecraftHandler.Player))
                        {
                            usersOnline.Add(u);
                        }
                    }

                    Server.SendExecuteResponse(TriggerPlayer, String.Format("Users in channel {0} ({1}): ", chan, usersOnline.Count));


                    foreach (User u in usersOnline)
                    {
                        str += u.Name + ", ";
                    }
                    if (!String.IsNullOrEmpty(str))
                    {
                        Server.SendExecuteResponse(TriggerPlayer, String.Format("{0}", str));
                    }
                    return new CommandResult(true, String.Format("{0} executed cinfo",TriggerPlayer));
                }
                return new CommandResult(true, String.Format("Channel not found"), true);
            }
            else
            {
                List<Channel> channels = ((ServerSocket)Server).Channels.FindAll(x => x.User.IsInlist(TriggerPlayer));
                

                Server.SendExecuteResponse(TriggerPlayer, String.Format("You're in the following channels: "));
                String str = "";
                foreach (Channel c in channels)
                {
                    UserCollection usersOnline = new UserCollection();
                    foreach (User u in c.User)
                    {
                        if (MinecraftHandler.IsStringInList(u.Name, MinecraftHandler.Player))
                        {
                            usersOnline.Add(u);
                        }
                    }

                    str += String.Format("{0} ({1}), ", c.Name, usersOnline.Count);
                }
                if (!String.IsNullOrEmpty(str))
                {
                    Server.SendExecuteResponse(TriggerPlayer, String.Format("{0}", str));
                }
                return new CommandResult(true, String.Format("{0} executed cinfo", TriggerPlayer));
            }
        }
    }
}
