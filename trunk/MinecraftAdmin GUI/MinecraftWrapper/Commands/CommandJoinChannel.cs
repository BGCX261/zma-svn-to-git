using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;
using Vitt.Andre.Tunnel;
using Zicore.MinecraftAdmin.Admins;
using MinecraftWrapper.Chat;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandJoinChannel : Command
    {
        public CommandJoinChannel(IMinecraftHandler mc)
            :base(mc,"join")
        {
            
        }

        public override CommandResult Execute(String chan,String pw, String arg3, String arg4)
        {
            if (!String.IsNullOrEmpty(chan))
            {
                if (chan.Length <= 12 && chan.Length >= 3 || chan.Length == 1 && chan[0] == '*')
                {
                    ServerSocket server = (ServerSocket)Server;
                    if (ClientUser.Generated)
                    {
                        ClientUser = new User(TriggerPlayer, false);
                        UserCollectionSingletone.GetInstance().Add(ClientUser);
                        UserCollectionSingletone.GetInstance().Save();
                    }

                    Channel channel = server.Channels.Find(chan); // check if a channel exists or creates a new
                    if (channel == null)
                    {
                        if (String.IsNullOrEmpty(pw)) // if has a password creates a channel with password :)
                        {
                            channel = new Channel(chan);
                            // create new without password
                        }
                        else
                        {
                            channel = new Channel(chan, pw);
                            // create with password
                        } 
                        server.Channels.AddChannel(channel);
                        // add user to channel
                    }

                    if (channel.User.IsInlist(ClientUser))
                    {
                        return new CommandResult(false, String.Format("You're already in this channel", TriggerPlayer, channel.Name), true);
                    }
                    
                    if (channel.RequiresPassword)
                    {
                        if (String.IsNullOrEmpty(pw))
                        {
                            return new CommandResult(true, String.Format("{0} requires a password", channel.Name),true);
                            // no pw as argument so we are out here :)
                        }
                        else
                        {
                            // we have a password lets check it
                            if (channel.Password == pw)
                            {
                                channel.User.Add(ClientUser);
                                return new CommandResult(true, String.Format("{0} joined channel {1}", TriggerPlayer, channel.Name));
                            }
                            else
                            {
                                // password is wrong :(
                                return new CommandResult(true, String.Format("Password for channel {0} is wrong", channel.Name), true);
                            }
                        }
                    }
                    else
                    {
                        // no pw so we are ok
                        //ClientUser.Channels.AddChannel(channel);

                        if (!channel.User.IsInlist(ClientUser))
                        {
                            channel.User.Add(ClientUser);
                            return new CommandResult(true, String.Format("{0} joined channel {1}", TriggerPlayer, channel.Name));
                        }
                        else
                        {
                            return new CommandResult(true, String.Format("You're already in this channel", TriggerPlayer, channel.Name), true);
                            //return new CommandResult(true, null);
                        }
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
