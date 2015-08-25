using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MinecraftWrapper.AddonInterface;
using Zicore.MinecraftAdmin.Admins;

namespace Zicore.MinecraftAdmin.Commands
{
    /// <summary>
    /// make sure it inherits the Command class
    /// </summary>
    public class CommandGroup : Command
    {
        /// <summary>
        /// the string for the base class is the name of this command
        /// it gets executed with !color then, should be the same like the in the register method
        /// </summary>
        /// <param name="mc">The minecraft handler</param>
        public CommandGroup(IMinecraftHandler mc)
            :base(mc,"group")
        {
            Help = "Sets a player to a group";
        }

        /// <summary>
        /// this is the execution method which gets executed later
        /// to get more arguments use the internal regArgs variable
        /// </summary>
        /// <param name="arg1">first argument after the command in the string</param>
        /// <param name="arg2">second argument after the command in the string</param>
        /// <param name="arg3">third argument after the command in the string</param>
        /// <param name="arg4">fourth argument after the command in the string</param>
        /// <returns>remember to set the command result in every return case</returns>
        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            if (!String.IsNullOrEmpty(arg1))
            {
                IMinecraftHandler mc = MinecraftHandler;
                String match = EasyGuess.GetMatchedString(mc.Player, arg1);
                if (!String.IsNullOrEmpty(match))
                {
                    UserCollectionSingletone userCollection = UserCollectionSingletone.GetInstance();
                    User matchedPlayer = userCollection.GetUserByName(match);
                    if (matchedPlayer != null)
                    {
                        GroupCollectionSingletone groups = GroupCollectionSingletone.GetInstance();
                        Group group = EasyGuess.GetMatchedGroup(groups, arg2);
                        if (group != null)
                        {
                            if (ClientUser.LevelID >= matchedPlayer.LevelID && ClientUser.LevelID >= group.Id) // checks if the triggered user has a higher group level
                            {
                                matchedPlayer.LevelID = group.Id; // sets the rank to the user :)
                                if (matchedPlayer.Generated)
                                {
                                    matchedPlayer.Name = match;
                                    if (!userCollection.IsInlist(match))
                                    {
                                        userCollection.Add(matchedPlayer);
                                        userCollection.Save();
                                    }
                                }
                                return new CommandResult(true, string.Format("player {0} set to group {1}", matchedPlayer.Name, group.Name));
                            }
                            else
                            {
                                return new CommandResult(true, string.Format("group level is too low {0} ID:{1}", ClientUser.Level.Name,ClientUser.LevelID));
                            }
                        }
                        else
                        {
                            return new CommandResult(true, string.Format("couldn't find group {0}", arg2)); // give as much informations as you can
                        }
                    }
                    else
                    {
                        return new CommandResult(true, string.Format("couldn't find the user {0}", match)); // give as much informations as you can
                    }
                }
                else
                {
                    return new CommandResult(true, string.Format("couldn't find the user {0}", match)); // give as much informations as you can
                }
            }
            else
            {
                return new CommandResult(true, string.Format("couldn't find player {0}", arg1));
            }
        }
    }
}
