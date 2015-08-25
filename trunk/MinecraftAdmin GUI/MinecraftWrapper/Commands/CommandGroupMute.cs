using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;
using Zicore.MinecraftAdmin.Admins;
namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandMuteGroup : Command
    {
        public CommandMuteGroup(IMinecraftHandler mc)
            :base(mc,"mutegroup")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            GroupCollectionSingletone groups = GroupCollectionSingletone.GetInstance();
            if (!String.IsNullOrEmpty(arg1))
            {
                if (arg1[0] == '*')
                {
                    if (arg1 == "*true")
                    {
                        foreach (Group g in groups)
                        {
                            if (ClientUser.Level != g)
                            {
                                g.AllowChat = false;
                                
                            }
                        }
                        return new CommandResult(true, String.Format("Every group has been muted except {0}", ClientUser.Level.Name));
                    }
                    if (arg1 == "*false")
                    {
                        foreach (Group g in groups)
                        {
                            if (ClientUser.Level != g)
                            {
                                g.AllowChat = true;
                            }
                        }
                        return new CommandResult(true, String.Format("Every group has been unmuted except {0}", ClientUser.Level.Name));
                    }
                }
                else
                {
                    Group g = EasyGuess.GetMatchedGroup(groups, arg1);

                    if (g != null)
                    {
                        g.AllowChat = !g.AllowChat;
                        if (g.AllowChat)
                        {
                            groups.Save();
                            return new CommandResult(true, String.Format("Group {0} has been unmuted", g.Name));
                        }
                        else
                        {
                            groups.Save();
                            return new CommandResult(true, String.Format("Group {0} has been muted", g.Name));
                        }
                    }
                }
            }
            return new CommandResult(true, String.Format("Group {0} not found", arg1));
        }
    }
}
