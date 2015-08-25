using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Vitt.Andre.XML;
using Zicore.MinecraftAdmin.Commands;
using Zicore.MinecraftAdmin.Admins;
using Vitt.Andre.Tunnel;
using MinecraftWrapper.AddonInterface;
using MinecraftWrapper.ExternalComponents;
using MinecraftWrapper.Blocks;
using Zicore.MinecraftAdmin.IO;
using MinecraftWrapper.WebInterface;
using MinecraftWrapper.Tunnel;

namespace Zicore.MinecraftAdmin
{
    public class MinecraftHandler : IMinecraftHandler
    {
        public MinecraftHandler(String rules, String kits, String banlist, String playerlist, String adminlist, String config)
        {
            _strRulesList = rules;
            _strBanList = banlist;
            _strPlayerList = playerlist;
            try
            {
                Config = XObject<Config>.Load(Config.ConfigFolder + Config.ConfigFile);
            }
            catch
            {
                Config = new Config();
            }
            try
            {
                PricedBlocks = BlockCollection.Load(Config.ConfigFolder + BlockCollection.PricedBlocksFile);
                if (PricedBlocks == null)
                {
                    PricedBlocks = new BlockCollection();
                }
            }
            catch
            {
                PricedBlocks = new BlockCollection();
            }
            String badBlocksFile = Path.Combine(Config.ConfigFolder,BlockCollection.BadBlocksFile);
            if (!File.Exists(badBlocksFile))
            {
                new BlockCollection().Save(badBlocksFile);
            }

            Plugins = AddonLoader.GetInstance(this).Plugins;
            timerCommandReader.Interval = 1000;
            timerCommandReader.Enabled = true;
        }

        Dictionary<String, ClientNpc> npcs = new Dictionary<string, ClientNpc>();

        public Dictionary<String, ClientNpc> Npcs
        {
            get { return npcs; }
            set { npcs = value; }
        }

        public void ReloadPlugins()
        {
            AddonLoader loader = AddonLoader.GetInstance(this);
            loader.Plugins.Clear();
            loader.LoadAddons(this);
        }

        public void UnloadAllPlugins()
        {
            DeactivateAllPlugins();
            Plugins.Clear();
        }

        System.Windows.Forms.Timer timerCommandReader = new System.Windows.Forms.Timer();

        public System.Windows.Forms.Timer TimerCommandReader
        {
            get { return timerCommandReader; }
            set { timerCommandReader = value; }
        }

        public void DeactivateAllPlugins()
        {
            CommandManager cm = CommandManager.GetInstance(this);
            cm.ResetCommands();
            foreach (IPlugin p in this.Plugins)
            {
                p.Enabled = false;
                try
                {
                    p.OnPluginUnloaded();
                }
                catch (Exception ex)
                {
                    Log.AppendText(ex.Message, Log.PluginLog);
                }
            }            
        }

        public void ActivateAllPlugins()
        {
            CommandManager cm = CommandManager.GetInstance(this);
            foreach (IPlugin p in this.Plugins)
            {
                p.Enabled = true;
                p.OnPluginLoaded(cm, this);
            }
        }

        string version = "";

        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        public delegate void OnOutputDataReceived(object sender, DataReceivedEventArgs e);
        public event OnOutputDataReceived OutputDataReceived;

        public delegate void OnServerExited(object sender);
        public event OnServerExited ServerExited;

        public delegate void OnPlayerjoined(object sender, String player);
        public event OnPlayerjoined PlayerJoined;

        public delegate void OnPlayerLeft(object sender, String player);
        public event OnPlayerLeft PlayerLeft;

        public delegate void OnPlayerKicked(object sender, String player, String message);
        public event OnPlayerKicked PlayerKicked;

        public delegate void OnBackupCommand(object sender, int minutes);
        public event OnBackupCommand BackupCommand;

        public delegate void OnBackupCommandStringDelegate(object sender, int minutes, string name);
        public event OnBackupCommandStringDelegate BackupNamedCommand;

        public delegate void OnSaveCompletedDelegate(object sender);
        public event OnSaveCompletedDelegate SaveCompleted;

        public void ExecuteBackup(int minutes)
        {
            if (BackupCommand != null)
            {
                BackupCommand(this,minutes);
            }
        }

        public void ExecuteBackup(int minutes, String name)
        {
            if (BackupNamedCommand != null)
            {
                BackupNamedCommand(this, minutes, name);
            }
        }

        UserCollection onlineUsers = new UserCollection();

        public UserCollection OnlineUsers
        {
            get { return onlineUsers; }
            set { onlineUsers = value; }
        }

        int secondsOnline = 0;

        public int SecondsOnline
        {
            get { return secondsOnline; }
            set { secondsOnline = value; }
        }

        public void ExecuteBackup()
        {
            ExecuteBackup(0);
        }

        BlockCollection _pricedBlocks = new BlockCollection();

        public BlockCollection PricedBlocks
        {
            get { return _pricedBlocks; }
            set { _pricedBlocks = value; }
        }

        Process _process;
        string _strRulesList = "rules.txt";

        Config _config;

        public Config Config
        {
            get { return _config; }
            set { _config = value; }
        }

        public Process[] FindJavaProcess()
        {
            return Process.GetProcessesByName("java");
        }

        public string StrRulesList
        {
            get { return _strRulesList; }
            set { _strRulesList = value; }
        }

        TimeSpan timeUntilBackup;

        public TimeSpan TimeUntilBackup
        {
            get { return timeUntilBackup; }
            set { timeUntilBackup = value; }
        }

        bool restartActivated = false;

        public bool RestartActivated
        {
            get { return restartActivated; }
            set { restartActivated = value; }
        }

        string _strBanList = "banned-players.txt";

        public string StrBanList
        {
            get { return _strBanList; }
            set { _strBanList = value; }
        }
        string _strPlayerList = "player.txt";

        public string StrPlayerList
        {
            get { return _strPlayerList; }
            set { _strPlayerList = value; }
        }
        
        bool _started = false;

        public bool Started
        {
            get { return _started; }
            set { _started = value; }
        }

        //public void SetExternalHandle(Process p)
        //{
        //    _mineCraftServer = p;
        //    // This ensures that you get the output from the DOS application
        //    _mineCraftServer.StartInfo.RedirectStandardOutput = true;
        //    _mineCraftServer.StartInfo.RedirectStandardInput = true;
        //    _mineCraftServer.StartInfo.RedirectStandardError = true;
            


        //    _mineCraftServer.EnableRaisingEvents = true;

        //    _mineCraftServer.OutputDataReceived += new DataReceivedEventHandler(_mineCraftServer_OutputDataReceived);
        //    _mineCraftServer.ErrorDataReceived += new DataReceivedEventHandler(_mineCraftServer_ErrorDataReceived);
        //    _mineCraftServer.Exited += new EventHandler(_mineCraftServer_Exited);

        //    //_mineCraftServer.Start();
        //    //_mineCraftServer.BeginOutputReadLine();
        //    //_mineCraftServer.BeginErrorReadLine();
        //    _started = true;
        //}

        ItemDictonary items = ItemDictonary.GetInstance();

        public ItemDictonary Items
        {
            get { return items; }
            set { items = value; }
        }

        public event EventHandler ServerStopped;

        public event EventHandler ServerStarted;

        public void RaiseStarted()
        {
            if (ServerStarted != null)
                ServerStarted(this, new EventArgs());
        }

        public void RaiseStopped()
        {
            if(ServerStopped != null)
                ServerStopped(this, new EventArgs());
        }

        public void Restart()
        {
            ExecuteCommand("stop");
            
            ServerExited += new OnServerExited(MinecraftHandler_ServerExited);
        }

        void MinecraftHandler_ServerExited(object sender)
        {
            Thread.Sleep(500);
            RaiseStarted();
            ServerExited -= new OnServerExited(MinecraftHandler_ServerExited);
        }

        public void Start()
        {
            try
            {
                if (!_started)
                {
                    ClearPlayerList();

                    string ApplicationPath = Config.Java;
                    string ApplicationArguments = string.Format("{0} {1} nogui", Config.Startparameters, Config.Minecraft);

                    // Create a new process object

                    _process = new Process();

                    _process.EnableRaisingEvents = true;
                    // StartInfo contains the startup information of
                    // the new process
                    _process.StartInfo.FileName = ApplicationPath;
                    _process.StartInfo.Arguments = ApplicationArguments;

                    // These two optional flags ensure that no DOS window
                    // appears
                    _process.StartInfo.UseShellExecute = false;
                    _process.StartInfo.CreateNoWindow = true;

                    // If this option is set the DOS window appears again :-/
                    // _mineCraftServer.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    // This ensures that you get the output from the DOS application
                    _process.StartInfo.RedirectStandardOutput = true;
                    _process.StartInfo.RedirectStandardInput = true;
                    _process.StartInfo.RedirectStandardError = true;

                    _process.OutputDataReceived += new DataReceivedEventHandler(_mineCraftServer_OutputDataReceived);
                    _process.ErrorDataReceived += new DataReceivedEventHandler(_mineCraftServer_ErrorDataReceived);
                    _process.Exited += new EventHandler(_mineCraftServer_Exited);

                    _process.Start();
                    _process.BeginErrorReadLine();
                    _process.BeginOutputReadLine();

                    _started = true;                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Try to relocate the Java path in the configuration!");
                Log.AppendText(ex.Message, Log.ExceptionsLog);
            }
        }

        public StreamWriter Input
        {
            get
            {
                try
                {
                    return _process.StandardInput;
                }
                catch 
                {
                    return null;
                }
            }
        }

        void _mineCraftServer_Exited(object sender, EventArgs e)
        {
            _started = false;
            if (ServerExited != null)
            {
                ServerExited(sender);
            }
            _process.CancelErrorRead();
            _process.CancelOutputRead();            
        }

        void _mineCraftServer_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            String data = e.Data;
            if (data != null)
            {
                //Console.WriteLine(e.Data);
                if (data.Contains("[INFO]"))
                {
                    CommandHandlerWrapper(data);
                }
                if (OutputDataReceived != null)
                {
                    OutputDataReceived(sender, e);
                }
            }
        }

        void _mineCraftServer_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            String data = e.Data;
            if (data != null)
            {
                //Console.WriteLine(data);
                if (data.Contains("[INFO]"))
                {
                    CommandHandlerWrapper(data);
                }
                if (OutputDataReceived != null)
                {
                    OutputDataReceived(sender, e);
                }
            }
        }

        public void ExecuteSay(string text)
        {
            ExecuteCommand("say", text);
        }

        bool useLamaCraft = false;

        public bool UseLamaCraft
        {
            get { return useLamaCraft; }
            set { useLamaCraft = value; }
        }

        public void UpdatePlayer(String player, int isOnline)
        {
            //ZmaSQLConnection sql = new ZmaSQLConnection();
            //sql.UpdatePlayer(this, player, isOnline);
        }

        public delegate void OnExecuteMODT(String[] lines, string text);
        public event OnExecuteMODT ExecuteMODT;

        public void ExecuteMOTD(String[] lines,string player)
        {
            //try
            //{
            //    if (lines != null)
            //    {
            //        foreach (String str in lines)
            //        {
            //            ExecuteSay(string.Format(str, text));
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            if (ExecuteMODT != null)
            {
                ExecuteMODT(lines, player);
            }
        }

        public void ExecuteTeleport(String name1, String name2)
        {
            try
            {
                ExecuteCommand("tp", name1, name2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        bool _connectionTimedOut = false;

        public bool ConnectionTimedOut
        {
            get { return _connectionTimedOut; }
            set { _connectionTimedOut = value; }
        }

        bool _isTunneled = false;

        public bool IsTunneled
        {
            get { return _isTunneled; }
            set { _isTunneled = value; }
        }

        public void CommandHandlerWrapper(String cmd)
        {
            //String strExclamationPattern = @"\[INFO\] <[^>]+> (?<exclamation>!)who";
            List<String> admins = new List<string>();
            try
            {
                string cantConnectPattern = @"[\[/0-9.:\]]+ Took too long to log in";

                Regex cantConnectRegex = new Regex(cantConnectPattern);
                Match match = cantConnectRegex.Match(cmd);
                if (match.Success)
                {
                    _connectionTimedOut = true;
                }
                string strSaveCompletedPattern = @"[0-9]+-[0-9]+-[0-9]+ [0-9]+:[0-9]+:[0-9]+ \[INFO\] CONSOLE: Save complete.";
                string strQuitPattern = @"\[INFO\] (?<username>[^ ]+) lost connection";
                string strJoinedPattern = @"\[INFO\] (?<username>[^>]+) \[[^\]]+\] logged in with entity id (?<id>[0-9]+)";
                //if (useLamaCraft)
                //{
                //    strQuitPattern = @"\[INFO\] <§[0-9a-z](?<username>[^>]+)§[0-9a-z]> lost connection";
                //    //strJoinedPattern = @"\[INFO\] <§[0-9a-z](?<username>[^>]+)§[0-9a-z]> \[[^\]]+\] logged in";
                    
                //}
                //else
                //{
                //    strQuitPattern = @"\[INFO\] (?<username>[^ ]+) lost connection";
                //    strJoinedPattern = @"\[INFO\] (?<username>[^>]+) \[[^\]]+\] logged in";
                //}

                Regex regJoined = new Regex(strJoinedPattern);

                Match joinedMatch = regJoined.Match(cmd);
                if (joinedMatch.Success)
                {
                    String player = joinedMatch.Groups["username"].Value;

                    if (!String.IsNullOrEmpty(player))
                    {
                        if (Config.WhiteListMode)
                        {
                            List<String> list = GetListFromFile(Config.ConfigFolder + Config.WhiteListFile);
                            if (!IsStringInList(player, list))
                            {
                                ExecuteKick(player, "Console");
                                return;
                            }
                        }
                        Int32 id = -1;
                        Int32.TryParse(joinedMatch.Groups["id"].Value,out id);

                        AddPlayer(player, id);
                        ExecuteMOTD(Config.Modt,player);

                        if (PlayerJoined != null)
                        {
                            PlayerJoined(this, player);
                        }
                        return;
                    }
                    if (player == "")
                    {
                        ExecuteKick("","Console");
                    }



                    return;
                }

                Regex regQuit = new Regex(strQuitPattern);

                Match quitMatch = regQuit.Match(cmd);
                if (quitMatch.Success)
                {
                    String player = quitMatch.Groups["username"].Value;
                    if (!String.IsNullOrEmpty(player))
                    {
                        //RemovePlayerFromList(Play,player, _strPlayerList);
                        RemovePlayer(player);
                        return;
                    }
                    if (PlayerLeft != null)
                    {
                        PlayerLeft(this, player);
                    }
                }

                Regex regSaveAllFinished = new Regex(strSaveCompletedPattern);

                Match saveMatch = regSaveAllFinished.Match(cmd);
                if (saveMatch.Success)
                {
                    if (SaveCompleted != null)
                    {
                        SaveCompleted(this);
                    }
                    return;
                }

                string strUserPattern = string.Format(@"\[INFO\] <(?<username>[^>]+)> {0}(?<cmd>[a-zA-Z]+) ?(?<arg1>.+)?",Config.CommandChar);
                if (useLamaCraft)
                {
                    strUserPattern = string.Format(@"\[INFO\] <§[0-9a-zA-Z](?<username>[^>]+)§[0-9a-zA-Z]> {0}(?<cmd>[a-zA-Z]+) ?(?<arg1>.+)?",Config.CommandChar);
                }
                else
                {
                    strUserPattern = string.Format(@"\[INFO\] <(?<username>[^>]+)> {0}(?<cmd>[a-zA-Z]+) ?(?<arg1>.+)?",Config.CommandChar);
                }

                string regCommand = "";
                string regUserName = "";
                string regArg1 = "";
                //string regArg2 = "";

                Regex commandPattern = new Regex(strUserPattern);

                match = commandPattern.Match(cmd);
                if (match.Success)
                {
                    regUserName = match.Groups["username"].Value;
                    regCommand = match.Groups["cmd"].Value;
                    regArg1 = match.Groups["arg1"].Value;
                    if (!IsTunneled)
                    {
                        CommandHandlerExternal(regUserName, regCommand,regArg1,null,null);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public CommandResult CommandHandlerExternal(String userName, String command, String args,ClientSocket client,ServerSocket server)
        {
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(command))
            {
                return null;
            }

            string username = userName;

            try
            {
                CommandManager helper = CommandManager.GetInstance(this);

                String commandMatch = EasyGuess.GetMatchedCommand(helper, command);
                if (String.IsNullOrEmpty(commandMatch))
                {
                    return null;
                }

                Command c = helper.Items[commandMatch];
                if (c != null)
                {
                    UserCollectionSingletone userCollection = UserCollectionSingletone.GetInstance();
                    User user = userCollection.GetUserByName(userName);
                    if (user == null)
                    {
                        user = new User(userName);
                    }

                    if (user != null && user.Level.IsCommandInList(commandMatch))
                    {
                        string arg1 = "", arg2 = "", arg3 = "";
                        GetArgs(args, out arg1, out arg2, out arg3);
                        c.ClientUser = user;
                        c.RegArg = args;
                        c.Client = client;
                        c.Server = server;
                        c.TriggerPlayer = userName;
                        CommandResult result;

                        if(arg1.Length>0&&arg1[0]=='?')
                            result = c.ExecuteHelp();
                        else
                            result = c.Execute(arg1, arg2, arg3, userName);

                        return result;
                    }
                }
            }
            catch 
            {}
            return new CommandResult();
        }

        public void ExecuteCommands(User user)
        {
            try
            {
                Group g = user.Level;

                StringBuilder builder = new StringBuilder();

                foreach (String str in user.Level.Commands)
                {
                    builder.AppendFormat("<{0}> ",str);
                }

                ExecuteCommand("say", builder.ToString());
            }
            catch
            {

            }
        }

        PluginCollection plugins = new PluginCollection();

        public PluginCollection Plugins
        {
            get { return plugins; }
            set { plugins = value; }
        }

        public void ExecuteKits(User user)
        {
            StringBuilder builder = new StringBuilder();

            List<Kit> kitlist = KitReader.GetKitlist(Config.ConfigFolder + KitReader.File);

            foreach (Kit kit in kitlist)
            {
                
                 builder.AppendFormat("<{0}> ", kit.Name);
                
            }

            ExecuteCommand("say", builder.ToString());
        }

        public static void GetArgs(string regArg1, out string arg1, out string arg2, out string arg3)
        {
            arg1 = string.Empty;
            arg2 = string.Empty;
            arg3 = string.Empty;

            string[] args = regArg1.Split(' ');
            if (args != null)
            {
                if (args.Length >= 1 && args[0] != null)
                {
                    arg1 = args[0];
                }

                if (args.Length >= 2 && args[1] != null)
                {
                    arg2 = args[1];
                }

                if (args.Length >= 3 && args[2] != null)
                {
                    arg3 = args[2];
                }
            }
        }

        public void ExecuteKit(Kit kit, string username, string admin)
        {
            try
            {
                foreach (KitItem item in kit.Items)
                {
                    if (!String.IsNullOrEmpty(username))
                    {
                        ExecuteGive(username, item.Id, item.Amount.ToString());
                    }
                    else
                    {
                        ExecuteGive(admin, item.Id, item.Amount.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ExecuteBan(string regArg1, string admin)
        {
            try
            {
                //ExecuteCommand("say", string.Format("<{0}> banned by {1}", regArg1, admin));
                //AddToPlayerList(regArg1, _strBanList);
                //CheckBanlist(regArg1);
                ExecuteCommand("ban", regArg1);
                if (PlayerKicked != null)
                {
                    PlayerKicked(this, regArg1, admin);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ExecuteRemove(string regArg1, string admin)
        {
            try
            {
                ExecuteCommand("say", string.Format("<{0}> unbanned by {1}", regArg1, admin));
                ExecuteCommand("pardon", regArg1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //public void ExecuteKick(string username)
        //{
        //    ExecuteKick(username, null);            
        //}

        public void ExecuteKick(string username, string admin)
        {
            try
            {
                //if (admin != null && admin != "")
                //{
                //    ExecuteCommand("say", String.Format("<{0}> kicked by <{1}>", username, admin));
                //}
                //ExecuteCommand("kick", username);
                if (PlayerKicked != null)
                {
                    PlayerKicked(this, username, String.Format("<{0}> kicked by <{1}>", username, admin));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ExecuteGive(string username, string id)
        {
            ExecuteGive(username, id, "8");
        }

        public void ExecuteGive(string username, string id, string num)
        {
            try
            {
                int count = int.Parse(num);
                if (count >= Config.GiveLimit)
                {
                    count = Config.GiveLimit;
                }

                int cycles = count / 64;
                int lastCount = count - ((int)(count / 64) * 64);
                for (int i = 0; i < cycles; i++)
                {
                    ExecuteCommand("give", username, id,"64");
                }
                if (lastCount > 0)
                {
                    ExecuteCommand("give", username, id, lastCount.ToString());
                }
            }
            catch
            {
                //Console.WriteLine(ex);
            }
        }

        public void ExecuteWho()
        {
            List<String> playerList = Player;
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("Online: {0} ", playerList.Count);

            foreach (String player in playerList)
            {
                builder.AppendFormat("<{0}> ", player);
            }

            String result = builder.ToString();
            ExecuteCommand("say", result);
        }

        public bool IsStringInList(String entry, List<String> list)
        {
            if (list != null && entry != null)
            {
                foreach (String str in list)
                {
                    if (str.ToLower() == entry.ToLower())
                        return true;
                }
            }
            return false;
        }

        public void AddPlayer(String player, int entityId)
        {
            if (!IsStringInList(player, Player))
            {
                Player.Add(player);
                UpdatePlayer(player, 1);

                foreach (IPlugin plugin in Plugins)
                {
                    try
                    {
                        if (plugin.Enabled)
                        {
                            plugin.OnPlayerJoined(this, player);
                        }
                    }
                    catch
                    {
                        Log.AppendText("Error Executing Plugin OnPlayerJoined()", Log.PluginLog);
                    }
                }

                try
                {
                    UserCollectionSingletone users = UserCollectionSingletone.GetInstance();
                    User user = users.GetUserByName(player);
                    user.LastEntityId = entityId;
                    OnlineUsers.Add(user);
                }
                catch
                {
                    Log.AppendText("Error Adding user at OnlineUsers OnPlayerJoined()", Log.ExceptionsLog);
                }
            }
        }

        public void RemovePlayer(String player)
        {
            if (IsStringInList(player, Player))
            {
                Player.Remove(player);
                UpdatePlayer(player, 0);

                foreach (IPlugin plugin in Plugins)
                {
                    try
                    {
                        if (plugin.Enabled)
                        {
                            plugin.OnPlayerLeft(this, player);
                        }
                    }
                    catch
                    {
                        Log.AppendText("Error Executing Plugin OnPlayerLeft()", Log.PluginLog);
                    }
                }

                try
                {
                    UserCollectionSingletone users = UserCollectionSingletone.GetInstance();
                    OnlineUsers.Remove(users.GetUserByName(player));
                }
                catch
                {
                    Log.AppendText("Error Removing user at OnlineUsers OnPlayerLeft()", Log.ExceptionsLog);
                }
            }
        }

        public void ExecuteCommand(String command, string arg1, string arg2, string arg3)
        {
            try
            {
                if (String.IsNullOrEmpty(arg1) && String.IsNullOrEmpty(arg2))
                {
                    _process.StandardInput.WriteLine(string.Format("{0}", command));
                }
                else if (!String.IsNullOrEmpty(arg1) && String.IsNullOrEmpty(arg2))
                {
                    _process.StandardInput.WriteLine(string.Format("{0} {1}", command, arg1));
                }
                else if (!String.IsNullOrEmpty(arg1) && !String.IsNullOrEmpty(arg2) && String.IsNullOrEmpty(arg3))
                {
                    _process.StandardInput.WriteLine(string.Format("{0} {1} {2}", command, arg1, arg2));
                }
                else if (!String.IsNullOrEmpty(arg1) && !String.IsNullOrEmpty(arg2) && !String.IsNullOrEmpty(arg3))
                {
                    _process.StandardInput.WriteLine(string.Format("{0} {1} {2} {3}", command, arg1, arg2, arg3));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ExecuteCommand(String command, string arg1, string arg2)
        {
            ExecuteCommand(command, arg1, arg2, "");
        }

        public void ExecuteCommand(String command, string arg1)
        {
            ExecuteCommand(command, arg1, "","");
        }

        public void ExecuteCommand(String command)
        {
            ExecuteCommand(command, "", "", "");
        }

        public void AddToPlayerList(List<String> list, String player, String file)
        {
            try
            {
                List<String> playersList = list;
                if (!IsStringInList(player.ToLower(), playersList))
                {
                    playersList.Add(player);
                    SaveListToFile(file, playersList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RemovePlayerFromList(List<String> list, String player, String file)
        {
            List<String> playersList = list;
            playersList.Remove(player);
            SaveListToFile(file, playersList);
        }

        LockFreeQueue<String> playerQueue = new LockFreeQueue<string>();

        public LockFreeQueue<String> PlayerQueue
        {
            get { return playerQueue; }
            set { playerQueue = value; }
        }

        volatile List<String> player = new List<string>();

        public List<String> Player
        {
            get { return player; }
            set { player = value; }
        }

        public List<String> GetListFromFile(String file)
        {
            List<String> list = new List<string>();
            try
            {                
                if (File.Exists(file))
                {
                    using (StreamReader sr = new StreamReader(file))
                    {

                        while (!sr.EndOfStream)
                        {
                            String line = sr.ReadLine();
                            //# for comment
                            if (!String.IsNullOrEmpty(line))
                            {
                                list.Add(line.Trim());
                            }
                        }

                        sr.Close();
                    }
                }
                else
                {

                }
                return list;
            }
            catch (FileNotFoundException)
            {
                
            }
            catch (Exception)
            {
                
            }
            return list;
        }

        public Dictionary<String, String> GetConfig(String file)
        {
            try
            {
                Dictionary<String, String> list = new Dictionary<String, String>();
                StreamReader sr = new StreamReader(file);

                while (!sr.EndOfStream)
                {
                    String line = sr.ReadLine();
                    //# for comment
                    if (!String.IsNullOrEmpty(line))
                    {
                        try
                        {
                            string[] args = line.Split('=');
                            string arg1 = args[0];
                            string arg2 = args[1];
                            list.Add(arg1, arg2);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                sr.Close();
                return list;
            }
            catch
            {
                throw;
            }
        }

        public void SaveListToFile(String file, List<String> list)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {

                    foreach (String str in list)
                    {
                        sw.WriteLine(str);
                    }

                    sw.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ClearPlayerList()
        {
            try
            {
                List<String> playersList = Player;
                playersList.Clear();
                SaveListToFile(_strPlayerList, playersList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
