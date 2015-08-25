using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin;
using Zicore.MinecraftAdmin.Commands;
using MinecraftWrapper.Zones;
using MinecraftWrapper.Chat;

namespace Zicore.MinecraftAdmin
{
    public class EasyGuess
    {
        public static string GetMatchedString(List<String> list, string guess)
        {
            int matches = 0;
            string firstmatch = "";
            foreach (String str in list)
            {
                if (str.ToLower() == guess)
                {
                    return str;
                }
                if (str.ToLower().Contains(guess.ToLower()))
                {
                    if (matches == 0)
                    {
                        firstmatch = str;
                    }
                    matches++;                    
                }
            }
            if (matches == 1)
                return firstmatch;
            else return "";
        }


        public static KeyValuePair<String, String> GetMatchedKeyValuePair(Dictionary<String, String> dict, string guess)
        {
            int matches = 0;
            KeyValuePair<String, String> firstMatch = new KeyValuePair<string, string>("", "");
            foreach (KeyValuePair<String, String> kvp in dict)
            {
                if (kvp.Key.ToLower() == guess.ToLower())
                {
                    return kvp;
                }
                if (kvp.Key.ToLower().Contains(guess.ToLower()))
                {
                    if (matches == 0)
                    {
                        firstMatch = kvp;
                    }
                    matches++;
                }
            }

            return firstMatch;
        }

        public static Channel GetMatchedChannel(List<Channel> channels, string guess)
        {
            int matches = 0;
            Channel firstmatch = null;
            foreach (Channel item in channels)
            {
                if (item.Name.ToLower() == guess)
                {
                    return item;
                }
                if (item.Name.ToLower().Contains(guess.ToLower()))
                {
                    if (matches == 0)
                    {
                        firstmatch = item;
                    }
                    matches++;
                }
            }
            if (matches == 1)
                return firstmatch;
            else return null;
        }

        public static Kit GetMatchedKit(List<Kit> kitlist, string guess)
        {
            int matches = 0;
            Kit firstmatch = null;
            foreach (Kit kit in kitlist)
            {
                if (kit.Name.ToLower() == guess)
                {
                    return kit;
                }
                if (kit.Name.ToLower().Contains(guess.ToLower()))
                {
                    if (matches == 0)
                    {
                        firstmatch = kit;
                    }
                    matches++;
                }
            }
            if (matches == 1)
                return firstmatch;
            else return null;
        }

        public static Zone GetMatchedZone(ZoneCollectionSingletone zones, string guess)
        {
            int matches = 0;
            Zone firstmatch = null;
            foreach (Zone zone in zones.Items)
            {
                if (zone.Name.ToLower() == guess)
                {
                    return zone;
                }
                if (zone.Name.ToLower().Contains(guess.ToLower()))
                {
                    if (matches == 0)
                    {
                        firstmatch = zone;
                    }
                    matches++;
                }
            }
            if (matches == 1)
                return firstmatch;
            else return null;
        }

        public static Group GetMatchedGroup(GroupCollectionSingletone groups, string guess)
        {
            int matches = 0;
            Group firstmatch = null;
            foreach (Group group in groups.Items)
            {
                if (group.Name.ToLower() == guess)
                {
                    return group;
                }
                if (group.Name.ToLower().Contains(guess.ToLower()))
                {
                    if (matches == 0)
                    {
                        firstmatch = group;
                    }
                    matches++;
                }
            }
            if (matches == 1)
                return firstmatch;
            else return null;
        }

        public static string GetMatchedCommand(CommandManager helper, String guess)
        {
            int matches = 0;
            KeyValuePair<String, Command> firstMatch = new KeyValuePair<string, Command>();
            foreach (KeyValuePair<String, Command> kvp in helper.Items)
            {
                if (kvp.Key.ToLower() == guess.ToLower())
                {
                    return kvp.Key;
                }
                if (kvp.Key.ToLower().Contains(guess.ToLower()))
                {
                    if (matches == 0)
                    {
                        firstMatch = kvp;
                    }
                    matches++;
                }
            }

            if (matches == 1)
                return firstMatch.Key;
            else return "";
        }
    }
}
