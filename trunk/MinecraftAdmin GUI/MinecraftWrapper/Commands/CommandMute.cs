using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;
using Zicore.MinecraftAdmin.Admins;
namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandMute : Command
    {
        public CommandMute(IMinecraftHandler mc)
            :base(mc,"mute")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            if (!String.IsNullOrEmpty(arg1))
            {
                UserCollectionSingletone userlist = UserCollectionSingletone.GetInstance();
                if (arg1[0] == '*')
                {
                    if (arg1 == "*true")
                    {
                        foreach (User u in userlist.Items)
                        {
                            if (ClientUser != u)
                            {
                                u.AllowChat = false;
                                
                            }
                        }
                        Server.SendServerMessage(String.Format("Every player has been muted except {0}", TriggerPlayer));
                    }
                    if (arg1 == "*false")
                    {
                        foreach (User u in userlist.Items)
                        {
                            if (ClientUser != u)
                            {
                                u.AllowChat = true;
                                
                            }
                        }
                        Server.SendServerMessage(String.Format("Every player has been unmuted except {0}", TriggerPlayer));
                    }
                }
                else
                {
                    
                    List<String> playerlist = MinecraftHandler.Player;
                    string match = EasyGuess.GetMatchedString(playerlist, arg1);
                    if (!String.IsNullOrEmpty(match))
                    {
                        User user = userlist.GetUserByName(match);
                        if (user.Generated)
                        {
                            user.Generated = false;
                            userlist.Add(user);
                            user.AllowChat = false;
                            userlist.Save();
                            return new CommandResult(true, string.Format("{0} has muted {1}", TriggerPlayer, match));
                        }
                        else
                        {
                            user.AllowChat = !user.AllowChat;
                            userlist.Save();
                            if (user.AllowChat)
                            {
                                return new CommandResult(true, string.Format("{0} has unmuted {1}", TriggerPlayer, match));
                            }
                            else
                            {
                                return new CommandResult(true, string.Format("{0} has muted {1}", TriggerPlayer, match));
                            }
                        }
                    }
                }
            }
            return new CommandResult(true, string.Format("user not found {0}", arg1));
        }
    }
}
