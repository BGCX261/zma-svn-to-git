using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.AddonInterface;
using System.IO;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandManager : ICommandManager
    {
        private static object m_lock = new object();
        public static volatile CommandManager instance = null;

        private CommandManager(MinecraftHandler mc)
        {
            this.mc = mc;
            ResetCommands();
        }

        MinecraftHandler mc = null;

        public void ResetCommands()
        {
            this._cmds.Clear();
            _cmds.Add("who", new CommandWho(mc));
            _cmds.Add("say", new CommandSay(mc));
            _cmds.Add("kick", new CommandKick(mc));
            _cmds.Add("ban", new CommandBan(mc));
            _cmds.Add("give", new CommandGive(mc));
            _cmds.Add("rules", new CommandRules(mc));
            _cmds.Add("tp", new CommandTp(mc));
            _cmds.Add("to", new CommandTo(mc));
            _cmds.Add("get", new CommandGet(mc));
            _cmds.Add("kit", new CommandKit(mc));
            _cmds.Add("op", new CommandOp(mc));
            _cmds.Add("deop", new CommandDeOp(mc));
            _cmds.Add("unban", new CommandUnban(mc));
            _cmds.Add("kits", new CommandKits(mc));
            _cmds.Add("hug", new CommandHug(mc));
            _cmds.Add("copyright", new CommandCopyright(mc));
            _cmds.Add("help", new CommandHelp(mc));
            _cmds.Add("info", new CommandInfo(mc));
            _cmds.Add("save", new CommandSave(mc));
            _cmds.Add("backup", new CommandBackup(mc));
            _cmds.Add("zone", new CommandZone(mc));
            _cmds.Add("zones", new CommandZones(mc));
            _cmds.Add("tell", new CommandTell(mc));
            _cmds.Add("hi", new CommandHi(mc));
            _cmds.Add("time", new CommandTime(mc));
            _cmds.Add("balance", new CommandBalance(mc));
            _cmds.Add("pay", new CommandPay(mc));
            _cmds.Add("position", new CommandPosition(mc));
            _cmds.Add("steal", new CommandSteal(mc));
            _cmds.Add("givemoney", new CommandGiveMoney(mc));
            _cmds.Add("price", new CommandPrice(mc));
            _cmds.Add("buy", new CommandBuy(mc));
            _cmds.Add("clearaccounts", new CommandClearAccounts(mc));
            _cmds.Add("zgroup", new CommandZGroup(mc));
            _cmds.Add("zmessage", new CommandZMessage(mc));
            _cmds.Add("zadd", new CommandZAdd(mc));
            _cmds.Add("zremove", new CommandZRemove(mc));
            _cmds.Add("zdelete", new CommandZDelete(mc));
            _cmds.Add("zlist", new CommandZList(mc));
            _cmds.Add("zowner", new CommandZOwner(mc));
            _cmds.Add("zblocklevel", new CommandZBlocklevel(mc));
            _cmds.Add("zinfo", new CommandZInfo(mc));
            _cmds.Add("zdescription", new CommandZDescription(mc));
            _cmds.Add("mute", new CommandMute(mc));
            _cmds.Add("mutegroup", new CommandMuteGroup(mc));
            _cmds.Add("join", new CommandJoinChannel(mc));
            _cmds.Add("leave", new CommandLeaveChannel(mc));
            _cmds.Add("cinfo", new CommandChannelInfo(mc));
            _cmds.Add("npc", new CommandNPC(mc));
            _cmds.Add("addnpc", new CommandAddNPC(mc));
            _cmds.Add("speakthrough", new CommandSpeakThrough(mc));
            //_cmds.Add("restart", new CommandRestart(mc));
            //_cmds.Add("teleport", new CommandTeleport(mc));

            ReadCommandHelp();
        }

        public static CommandManager GetInstance(MinecraftHandler mc)
        {
            // DoubleLock
            if (instance == null)
            {
                lock (m_lock)
                {
                    if (instance == null)
                    {
                        instance = new CommandManager(mc);
                    }
                }
            } 
            return instance;
        }

        /// <summary>
        /// registers a command to the command list
        /// </summary>
        /// <param name="name">the name of the command, should be the same like the internal name example: color</param>
        /// <param name="command">the command class to register</param>
        public void RegisterCommand(String name, ICommand command)
        {
            try
            {
                _cmds.Add(name, command as Command);
            }
            catch
            {

            }
        }

        public void UnregisterCommand(String name)
        {
            _cmds.Remove(name);
        }

        private SortedDictionary<String, Command> _cmds = new SortedDictionary<string, Command>();

        public SortedDictionary<String, Command> Items
        {
            get { return _cmds; }
            set { _cmds = value; }
        }

        public void ReadCommandHelp()
        {
            String helpFile = Path.Combine(Config.ConfigFolder, "CommandsHelp.txt");
            Dictionary<String, String> help = new Dictionary<string, string>();

            using (StreamReader sr = new StreamReader(helpFile))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        String str = sr.ReadLine();
                        var strSplit = str.Split('=');
                        help.Add(strSplit[0], strSplit[1]);
                    }
                    catch
                    {

                    }
                }
                sr.Close();
            }

            foreach (var item in Items)
            {
                try
                {
                    item.Value.Help = help[item.Key];
                }
                catch
                {

                }
            }
            
        }

        public List<String> CommandList
        {
            get
            {
                List<String> list = new List<string>();

                try
                {
                    foreach (KeyValuePair<String, Command> c in Items)
                    {
                        list.Add(c.Key);
                    }
                }
                catch
                {

                }

                return list;
            }
        }
    }
}
