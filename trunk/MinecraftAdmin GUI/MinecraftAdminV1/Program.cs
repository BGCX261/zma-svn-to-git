using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Zicore.MinecraftAdmin;

namespace Zicore.MinecraftAdmin
{
    class Program
    {
        static string strRulesList = "rules.txt";
        //static string strKitList = "kits.xml";
        static string strBanList = "blacklist.txt";
        static string strPlayerList = "player.txt";
        static string strAdminList = "admins.txt";
        static bool restart = true;
        static bool running = false;
        static Process ProcessObj;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static void Init()
        {
            try
            {
                while (restart)
                {
                    restart = false;
                    Dictionary<String, String> config = GetConfig("MineCraftAdmin.cfg");
                    ClearPlayerList();
                    // This snippet needs the "System.Diagnostics" library
                    if (!config.ContainsKey("java"))
                    {
                        Console.WriteLine("01 Java nicht gefunden...Exit");
                        Thread.Sleep(3000);
                        return;
                    }

                    if (!config.ContainsKey("minecraft"))
                    {
                        Console.WriteLine("02 Minecraft nicht gefunden...Exit");
                        Thread.Sleep(3000);
                        return;
                    }
                    // Application path and command line arguments
                    string javaFolder = config["java"];
                    string minecraftExecutable = config["minecraft"];
                    string minecraftFolder = @"F:\Minecraft Testserver\";
                    //string minecraftBat = "minecraft.bat";
                    string ApplicationPath = string.Format("{0}", javaFolder, minecraftFolder, minecraftExecutable);
                    string ApplicationArguments = string.Format("-Xmx1024M -Xms1024M -jar {2} nogui", javaFolder, minecraftFolder, minecraftExecutable);
                    // Create a new process object
                    ProcessObj = new Process();

                    // StartInfo contains the startup information of
                    // the new process
                    ProcessObj.StartInfo.FileName = ApplicationPath;
                    ProcessObj.StartInfo.Arguments = ApplicationArguments;

                    // These two optional flags ensure that no DOS window
                    // appears
                    ProcessObj.StartInfo.UseShellExecute = false;
                    ProcessObj.StartInfo.CreateNoWindow = true;

                    // If this option is set the DOS window appears again :-/
                    // ProcessObj.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    // This ensures that you get the output from the DOS application
                    ProcessObj.StartInfo.RedirectStandardOutput = true;
                    ProcessObj.StartInfo.RedirectStandardInput = true;
                    ProcessObj.StartInfo.RedirectStandardError = true;

                    ProcessObj.OutputDataReceived += new DataReceivedEventHandler(ProcessObj_OutputDataReceived);
                    ProcessObj.ErrorDataReceived += new DataReceivedEventHandler(ProcessObj_ErrorDataReceived);


                    // Start the process

                    ProcessObj.Start();
                    ProcessObj.BeginOutputReadLine();
                    ProcessObj.BeginErrorReadLine();

                    Console.WriteLine("Start hooking...");
                    Console.WriteLine("hooking accomplished");
                    ExecuteCommand("say", "Server started - MinecraftAdmin by Zicore");
                    running = true;
                    while (running)
                    {
                        String cmd = Console.ReadLine();
                        switch (cmd)
                        {
                            case "stop": running = false;
                                break;
                            case "exit": running = false;
                                break;
                            case "restart":
                                restart = true;
                                running = false;
                                break;
                            default: ProcessObj.StandardInput.WriteLine(cmd); break;
                        }
                    }

                    ExecuteCommand("stop");
                    ProcessObj.WaitForExit();
                    ClearPlayerList();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }

        //never used
        static void ExecuteRestart()
        {
            restart = true;
            running = false;
            SendKeys.Send("{Enter}");
        }

        //never used
        static void ExecuteStop()
        {
            running = false;
        }

        static void ProcessObj_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            //if the server is running it will receive error data as normal text
            String data = e.Data;
            if (data != null)
            {
                Console.WriteLine(e.Data);
                if (data.Contains("[INFO]"))
                {
                    CommandHandler(data);
                }
            }
        }

        static void ProcessObj_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            String data = e.Data;
            if (data != null)
            {
                Console.WriteLine(data);
                if (data.Contains("[INFO]"))
                {
                    CommandHandler(data);
                }
            }
        }

        public static void CommandHandler(String cmd)
        {
            List<String> admins = new List<string>();
            try
            {
                //pattern for player joined and quit
                //wont work everytime don't know why... maybe double left and double join
                string strQuitPattern = @"\[INFO\] (?<username>[^ ]+) lost connection";
                string strJoinedPattern = @"\[INFO\] (?<username>[^>]+) \[[^\]]+\] logged in";
                Regex regJoined = new Regex(strJoinedPattern);

                Match joinedMatch = regJoined.Match(cmd);
                if (joinedMatch.Success)
                {
                    String player = joinedMatch.Groups["username"].Value;
                    if (!String.IsNullOrEmpty(player))
                    {
                        ExecuteCommand("say", string.Format("Welcome player <{0}> ", player));
                        AddToPlayerList(player, strPlayerList);
                        CheckBanlist();
                        return;
                    }
                }

                Regex regQuit = new Regex(strQuitPattern);

                Match quitMatch = regQuit.Match(cmd);
                if (quitMatch.Success)
                {
                    String player = quitMatch.Groups["username"].Value;
                    if (!String.IsNullOrEmpty(player))
                    {
                        RemovePlayerFromList(player, strPlayerList);
                        return;
                    }
                }

                admins = GetListFromFile(strAdminList);

                // this is the pattern to get the username, the command and the text after it
                string strUserPattern = @"\[INFO\] <(?<username>[^>]+)> !(?<cmd>[a-z]+) ?(?<arg1>.+)?";
                string regCommand = "";
                string regUserName = "";
                string regArg1 = "";

                Regex commandPattern = new Regex(strUserPattern);

                Match match = commandPattern.Match(cmd);
                if (match.Success)
                {
                    regUserName = match.Groups["username"].Value;
                    regCommand = match.Groups["cmd"].Value;
                    regArg1 = match.Groups["arg1"].Value;

                    if (String.IsNullOrEmpty(regUserName) || String.IsNullOrEmpty(regCommand))
                    {
                        return;
                    }

                    if (IsStringInList(regUserName, admins)) // Admin Zweig
                    {
                        string admin = regUserName;
                        if (admin == regUserName)
                        {
                            if (regCommand == "say")
                            {
                                ExecuteCommand("say", regArg1);
                                //break;
                            }

                            else if (regCommand == "who")
                            {
                                ExecuteWho();
                            }

                            else if (regCommand == "give")
                            {
                                if (!String.IsNullOrEmpty(regArg1))
                                {
                                    string arg1 = "", arg2 = "", arg3 ="";
                                    GetArgs(regArg1, out arg1, out arg2,out arg3);

                                    if (arg1 != "" && arg2 == "")
                                    {
                                        ExecuteGive(arg1, regUserName);
                                    }

                                    if (arg1 != "" && arg2 != "" && arg3 == "")
                                    {
                                        ExecuteGive(arg1, arg2, regUserName);
                                    }
                                    
                                    if (arg1 != "" && arg2 != "" && arg3 != "")
                                    {
                                        ExecuteGive(arg1, arg2, arg3);
                                    }
                                }
                            }
                            else if (regCommand == "kick")
                            {
                                if (!String.IsNullOrEmpty(regArg1))
                                {
                                    ExecuteKick(regArg1, admin);
                                }
                            }
                            else if (regCommand == "ban")
                            {
                                if (!String.IsNullOrEmpty(regArg1))
                                {
                                    ExecuteBan(regArg1, admin);
                                }
                            }

                            else if (regCommand == "remove")
                            {
                                if (!String.IsNullOrEmpty(regArg1))
                                {
                                    ExecuteRemove(regArg1, admin);
                                }
                            }

                            else if (regCommand == "kit")
                            {
                                //string arg1 = "", arg2 = "", arg3 = "";
                                //GetArgs(regArg1, out arg1, out arg2, out arg3);
                                //if (!String.IsNullOrEmpty(arg1))
                                //{
                                //    Kit k = KitReader.GetKitFromName(strKitList, arg1);
                                //    if (k != null)
                                //    {
                                //        ExecuteKit(k, arg2, admin);
                                //    }
                                //}
                            }

                            else if (regCommand == "rules")
                            {
                                ExecuteRules();
                            }

                            else if (regCommand == "copyright")
                            {
                                ExecuteCommand("say", "MinecraftAdmin by <Zicore>");
                            }
                        }
                    }
                    else // Public Zweig
                    {
                        if (regCommand == "kit")
                        {
                            //string arg1 = "", arg2 = "", arg3 ="";
                            //GetArgs(regArg1, out arg1, out arg2,out arg3);
                            //if (!String.IsNullOrEmpty(arg1))
                            //{
                            //    Kit k = KitReader.GetKitFromName(strKitList, arg1);
                            //    //if (k != null && k.IsPublic)
                            //    //{
                            //    //    ExecuteKit(k, arg2, regUserName);
                            //    //}
                            //}
                        }

                        else if (regCommand == "who")
                        {
                            ExecuteWho();
                        }

                        else if (regCommand == "rules")
                        {
                            ExecuteRules();
                        }

                        else if (regCommand == "copyright")
                        {
                            ExecuteCommand("say", "MinecraftAdmin by <Zicore>");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
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

        public static void ExecuteKit(Kit kit, string username, string admin)
        {
            try
            {
                foreach (KitItem item in kit.Items)
                {
                    if (String.IsNullOrEmpty(username))
                    {
                        ExecuteGive(item.Id, item.Amount.ToString(), admin);
                    }
                    else
                    {
                        ExecuteGive(item.Id, item.Amount.ToString(), username);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void ExecuteBan(string regArg1, string admin)
        {
            try
            {
                ExecuteCommand("say", string.Format("<{0}> banned by {1}", regArg1, admin));
                AddToPlayerList(regArg1, strBanList);
                CheckBanlist();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void ExecuteRemove(string regArg1, string admin)
        {
            try
            {
                ExecuteCommand("say", string.Format("<{0}> unbanned by {1}", regArg1, admin));
                RemovePlayerFromList(regArg1, strBanList);
                CheckBanlist();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void CheckBanlist()
        {
            try
            {
                List<String> banList = GetListFromFile(strBanList);

                foreach (String s in banList)
                {
                    //ExecuteCommand("say", string.Format("<{0}> banned by {1}", s, admin));
                    ExecuteKick(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void ExecuteKick(string username)
        {
            ExecuteKick(username, null);
        }

        private static void ExecuteKick(string username, string admin)
        {
            try
            {
                if (admin != null && admin != "")
                {
                    ExecuteCommand("say", String.Format("<{0}> kicked by <{1}>", username, admin));
                }
                ExecuteCommand("kick", username);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void ExecuteGive(string id, string num, string username)
        {
            try
            {
                int count = int.Parse(num);
                for (int i = 0; i < count; i++)
                {
                    if (i >= 20)
                        break;
                    ExecuteCommand("give", username, id);
                    //Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void ExecuteRules()
        {
            try
            {
                List<String> rules = GetListFromFile(strRulesList);
                StringBuilder builder = new StringBuilder();

                foreach (String ruleLine in rules)
                {
                    ExecuteCommand("say", ruleLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void ExecuteGive(string id, string username)
        {
            ExecuteGive(id, "1", username);
        }

        public static void ExecuteWho()
        {
            List<String> playerList = GetListFromFile(strPlayerList);
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("Online: {0} ", playerList.Count);

            foreach (String player in playerList)
            {
                builder.AppendFormat("<{0}> ", player);
            }

            String result = builder.ToString();
            ExecuteCommand("say", result);
        }

        public static bool IsStringInList(String entry, List<String> list)
        {
            foreach (String str in list)
            {
                if (str.ToLower() == entry.ToLower())
                    return true;
            }
            return false;
        }

        public static void ExecuteCommand(String command, string arg1, string arg2)
        {
            try
            {
                if (String.IsNullOrEmpty(arg1) && String.IsNullOrEmpty(arg2))
                {
                    ProcessObj.StandardInput.WriteLine(string.Format("{0}", command));
                }
                else if (!String.IsNullOrEmpty(arg1) && String.IsNullOrEmpty(arg2))
                {
                    ProcessObj.StandardInput.WriteLine(string.Format("{0} {1}", command, arg1));
                }
                else if (!String.IsNullOrEmpty(arg1) && !String.IsNullOrEmpty(arg2))
                {
                    ProcessObj.StandardInput.WriteLine(string.Format("{0} {1} {2}", command, arg1, arg2));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void ExecuteCommand(String command, string arg1)
        {
            ExecuteCommand(command, arg1, "");
        }

        public static void ExecuteCommand(String command)
        {
            ExecuteCommand(command, "", "");
        }

        public static void AddToPlayerList(String player, String file)
        {
            try
            {
                List<String> playersList = GetListFromFile(file);
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

        public static void RemovePlayerFromList(String player, String file)
        {
            List<String> playersList = GetListFromFile(file);
            playersList.Remove(player);
            SaveListToFile(file, playersList);
        }

        public static List<String> GetListFromFile(String file)
        {
            try
            {
                List<String> list = new List<string>();
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
                    AddToPlayerList("", file);
                }
                return list;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Dictionary<String, String> GetConfig(String file)
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

        public static void SaveListToFile(String file, List<String> list)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file);

                foreach (String str in list)
                {
                    sw.WriteLine(str);
                }

                sw.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ClearPlayerList()
        {
            try
            {
                List<String> playersList = GetListFromFile(strPlayerList);
                playersList.Clear();
                SaveListToFile(strPlayerList, playersList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
