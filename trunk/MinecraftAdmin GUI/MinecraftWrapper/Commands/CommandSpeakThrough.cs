using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin.Commands;
using Zicore.MinecraftAdmin;
using MinecraftWrapper.Player;
using MinecraftWrapper.AddonInterface;
using Zicore.MinecraftAdmin.Admins;
using Vitt.Andre.Tunnel;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandSpeakThrough : Command
    {
        public CommandSpeakThrough(IMinecraftHandler mc)
            :base(mc,"speakthrough")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            ServerSocket server = (ServerSocket)Server;
            String match = EasyGuess.GetMatchedString(MinecraftHandler.Player, arg1);
            if (!String.IsNullOrEmpty(match))
            {
                User user = UserCollectionSingletone.GetInstance().GetUserByName(match);
                IClient client = Server.FindPlayer(match);
                if (client != null)
                {

                    if (!user.Generated)
                    {
                        String message = RegArg.Substring(arg1.Length+1);
                        if (!String.IsNullOrEmpty(message))
                        {
                            char lineColor = 'f';
                            if (server.FirstLine)
                            {
                                lineColor = MinecraftHandler.Config.LineFirstColorKey;
                            }
                            else
                            {
                                lineColor = MinecraftHandler.Config.LineSecondColorKey;
                            }

                            server.FirstLine = !server.FirstLine;

                            if (MinecraftHandler.Config.ChannelModeChat)
                            {
                                server.SendChannelMessage(String.Format("§f<§{0}{1}§{2}> §{3}{4}", user.Level.GroupColor, user.Name, 'F', lineColor, message), (ClientSocket)client);
                            }
                            else
                            {
                                server.SendServerMessage(String.Format("§f<§{0}{1}§{2}> §{3}{4}", user.Level.GroupColor, user.Name, 'F', lineColor, message));
                            }
                        }
                    }
                }
            }

            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer),true);
        }
    }
}
