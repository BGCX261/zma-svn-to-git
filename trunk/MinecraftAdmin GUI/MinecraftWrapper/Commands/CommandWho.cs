using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin.Admins;
using MinecraftWrapper.AddonInterface;

namespace Zicore.MinecraftAdmin.Commands
{
    public  class CommandWho : Command
    {
        public CommandWho(IMinecraftHandler mc)
            :base(mc,"who")
        {
            
        }

        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            var mc = MinecraftHandler;
            List<String> playerList = MinecraftHandler.Player;
            StringBuilder builder = new StringBuilder();
            List<String> lines = new List<string>();

            builder.AppendFormat("Online: {0} ", playerList.Count);

            if (playerList.Count > 0)
            {
                for(int i = 0; i < playerList.Count; i ++)
                {
                    String player = playerList[i];
                    User u = UserCollectionSingletone.GetInstance().GetUserByName(player);
                    if (builder.Length + player.Length + mc.Config.ResponsePrefix.Length < 70)
                    {
                        builder.AppendFormat("§f<§{0}{1}§f> ", u.Level.GroupColor, player);
                    }
                    else
                    {
                        lines.Add(builder.ToString());
                        builder = new StringBuilder();
                        i--;
                    }
                }
            }
            if (builder.Length +  mc.Config.ResponsePrefix.Length <= 70)
            {
                lines.Add(builder.ToString());
            }

            //MinecraftHandler.ExecuteSay(result);
            foreach (String line in lines)
            {
                Server.SendExecuteResponse(TriggerPlayer, line);
            }

            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
