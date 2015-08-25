using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Zicore.MinecraftAdmin.Admins;
using Zicore.MinecraftAdmin.IO;
using Vitt.Andre.Tunnel;
using MinecraftWrapper.ExternalComponents;
using ICSharpCode.SharpZipLib.Zip;
using Zicore.MinecraftAdmin.Dialogs;
using updateSystemDotNet.Core.Types;
using Vitt.Andre.AddonManagerLib;
using MinecraftWrapper.AddonInterface;
using Zicore.MinecraftAdmin.Commands;
using MinecraftWrapper.WebInterface;
using System.Net;
using FolderZipper;
using Zicore.SQLUtils;
using Vitt.Andre.MinecraftAdmin.Dialogs;
using MinecraftWrapper.MainClasses;
using Vitt.Andre.MinecraftAdmin;
using System.Threading;
using Zicore.TaskManagerLib;
using System.Diagnostics;
using Library.Forms;
using Zicore.TaskManagerLib.Tasks;
using System.Reflection;
using MinecraftWrapper.Tunnel;

namespace Zicore.MinecraftAdmin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            mc = new MinecraftHandler("rules.txt", "kits.xml", "banned-players.txt", "player.txt", "admins.txt", "MineCraftAdmin.cfg");
            Tunnel = new TcpTunnelServer(mc);
            mc.ServerStarted += new EventHandler(mc_ServerStarted);
            mc.ServerStopped += new EventHandler(mc_ServerStopped);

            mc.PlayerJoined += new MinecraftHandler.OnPlayerjoined(mc_PlayerJoined);
            mc.PlayerLeft += new MinecraftHandler.OnPlayerLeft(mc_PlayerLeft);

            mc.OutputDataReceived += new MinecraftHandler.OnOutputDataReceived(mc_OutputDataReceived);
            mc.ServerExited += new MinecraftHandler.OnServerExited(mc_ServerExited);
            LoadModules();
            ReadFromConfig();
            //CheckIfRestartOrBackup();
            this.Text = "Zicore's Minecraft Admintool - © 2010-2011 - v" + Application.ProductVersion;
            mc.Version = Application.ProductVersion;
            restart = new Restart(mc);

            this.listLoadedPlugins.DataSource = mc.Plugins;
            //mc.SaveCompleted += new MinecraftHandler.OnSaveCompletedDelegate(mc_SaveCompleted);
            web = new WebHandler(mc, Tunnel);
            web.Start();
            GenerateTaskColumns();
        }

        void mc_PlayerLeft(object sender, string player)
        {
            RefreshNpcs();
        }

        void mc_PlayerJoined(object sender, string player)
        {
            RefreshNpcs();
        }

        //Restart restart;

        void mc_ServerStopped(object sender, EventArgs e)
        {
            StopServer();
        }

        void mc_ServerStarted(object sender, EventArgs e)
        {
            StartServer();
        }

        WebHandler web = null;

        private void CheckStartupActions()
        {
            StartupActions actions = StartupActions.Load(Path.Combine(Config.ConfigFolder, StartupActions.File));
            if (actions != null)
            {
                actions.Execute(mc.Config);
            }
            else
            {
                actions = new StartupActions();
                actions.Save(Path.Combine(Config.ConfigFolder, StartupActions.File));
            }
        }

        //bool backupPlanned = false;

        public static String GetExternalIp()
        {
            try
            {
                System.Net.WebClient myWebClient = new System.Net.WebClient();
                myWebClient.Proxy = null;
                System.IO.Stream myStream = myWebClient.OpenRead("http://www.whatismyip.org/");

                System.IO.StreamReader myStreamReader = new System.IO.StreamReader(myStream);

                string myIP = myStreamReader.ReadToEnd();

                return myIP;
            }
            catch
            {
                return null;
            }
        }

        private void LoadModules()
        {
            TabPage tab;

            tab = new TabPage("Playerlist");
            tab.Controls.Add(new Playerlist(mc));
            tabNpcs.TabPages.Add(tab);

            tab = new TabPage("Whitelist");
            tab.Controls.Add(new WhiteList(mc));
            tabNpcs.TabPages.Add(tab);

            tab = new TabPage("Banlist");
            tab.Controls.Add(new Banlist(mc));
            tabNpcs.TabPages.Add(tab);

            tab = new TabPage("Group Editor");
            tab.Controls.Add(new GroupEditor(mc));
            tabNpcs.TabPages.Add(tab);

            tab = new TabPage("User Editor");
            tab.Controls.Add(new UserForm(mc));
            tabNpcs.TabPages.Add(tab);

            tab = new TabPage("Kit Editor");
            tab.Controls.Add(new KitEditor(mc));
            tabNpcs.TabPages.Add(tab);

            tab = new TabPage("Zones");
            tab.Controls.Add(new ZoneForm(mc));
            tabNpcs.TabPages.Add(tab);

            tab = new TabPage("Bad Blocks");
            tab.Controls.Add(new BadBlocksForm(mc));
            tabNpcs.TabPages.Add(tab);

            tab = new TabPage("Priced Blocks");
            tab.Controls.Add(new PricesBlocksForm(mc));
            tabNpcs.TabPages.Add(tab);

            //tab = new TabPage("Remote");
            //tab.Controls.Add(new RemoteControl(mc,Tunnel));
            //tabControl.TabPages.Add(tab);
        }

        LockFreeQueue<String> messageQueue = new LockFreeQueue<string>();

        void MainForm_Load(object sender, EventArgs e)
        {
            if (mc.Config.AutomatedServerStart)
            {
                StartServer();
            }

            CheckForUpdates();
        }

        private void CheckForUpdates()
        {
            if (mc.Config.AutomatedUpdates)
            {
                try
                {
                    //Updatesuche
                    updateController.checkForUpdatesCompleted -= new updateSystemDotNet.checkForUpdatesCompletedEventHandler(updateController1_checkForUpdatesCompleted);
                    updateController.checkForUpdatesCompleted += new updateSystemDotNet.checkForUpdatesCompletedEventHandler(updateController1_checkForUpdatesCompleted);

                    updateController.updateFound -= new updateSystemDotNet.updateFoundEventHandler(updateController1_updateFound);
                    updateController.updateFound += new updateSystemDotNet.updateFoundEventHandler(updateController1_updateFound);
                    //Updatedownload
                    updateController.downloadUpdatesCompleted -= new updateSystemDotNet.downloadUpdatesCompletedEventHandler(updateController1_downloadUpdatesCompleted);
                    updateController.downloadUpdatesCompleted += new updateSystemDotNet.downloadUpdatesCompletedEventHandler(updateController1_downloadUpdatesCompleted);

                    updateController.downloadUpdatesProgressChanged -= new updateSystemDotNet.downloadUpdatesProgressChangedEventHandler(updateController1_downloadUpdatesProgressChanged);
                    updateController.downloadUpdatesProgressChanged += new updateSystemDotNet.downloadUpdatesProgressChangedEventHandler(updateController1_downloadUpdatesProgressChanged);
                    lblStatusBar.Text = "checking for new updates...";
                    updateController.checkForUpdatesAsync();
                }
                catch
                {

                }
            }
        }

        private void ReadFromConfig()
        {
            //chkMakeBackup.Checked = mc.Config.MakeBackup;

            numericInternalPort.Value = mc.Config.InternalPort;
            numericExternalPort.Value = mc.Config.ExternalPort;
            this.Size = mc.Config.MainFormSize;
            this.Location = mc.Config.MainFormStartPosition;
            this.tabNpcs.SelectedIndex = mc.Config.SelectedTabIndex;
            this.chkChatScroll.Checked = mc.Config.ChatListScroll;
            this.numericSeconds.Value = mc.Config.TaskSeconds;
            this.numericMinutes.Value = mc.Config.TaskMinutes;
            this.numericHours.Value = mc.Config.TaskHours;
            this.tbTaskName.Text = mc.Config.BackupPrefix;
            try
            {
                taskConfig.Load();
            }
            catch
            {

            }
            //this.chkTunnelActive.Checked = mc.Config.ServerTunnelActive;
            //split.SplitterDistance = mc.Config.SplitterDistance;
        }

        private void SaveToConfig()
        {
            //mc.Config.MakeBackup = chkMakeBackup.Checked;
            mc.Config.InternalPort = (int)numericInternalPort.Value;
            mc.Config.ExternalPort = (int)numericExternalPort.Value;
            //mc.Config.SplitterDistance = split.SplitterDistance;
            mc.Config.MainFormSize = this.Size;
            mc.Config.MainFormStartPosition = this.Location;
            mc.Config.SelectedTabIndex = this.tabNpcs.SelectedIndex;
            mc.Config.ChatListScroll = this.chkChatScroll.Checked;
            mc.Config.ServerTunnelActive = this.chkTunnelActive.Checked;
            mc.Config.Save();
            UserCollectionSingletone.GetInstance().Save();
            taskConfig.Save();

            try
            {
                Log.AppendText(rtbConsole.Text, Log.ConsoleLogFile);
            }
            catch { }
            try
            {
                Log.AppendText(rtbServerClient.Text, Log.ChatMessageLogFile);
            }
            catch { }
        }

        MinecraftHandler mc;

        private void btStart_Click(object sender, EventArgs e)
        {
            mc.Start();
        }

        void mc_ServerExited(object sender)
        {
            AppendOutput("server offline" + Environment.NewLine);
            if (timerElapsed)
            {
                timerElapsed = false;
            }
        }

        void mc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            AppendOutput(e.Data + Environment.NewLine);
        }

        private void AppendOutput(string str)
        {
            messageQueue.Enqueue(str);
        }

        public delegate void AppendOutputDelegate(string str);

        private void btExit_Click(object sender, EventArgs e)
        {
            mc.ExecuteCommand("stop");
        }

        private void tbInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mc.ExecuteCommand(tbInput.Text);
                tbInput.Clear();
            }
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void btPlayerlist_Click(object sender, EventArgs e)
        {
            Playerlist p = new Playerlist(mc);
            p.Show();
        }

        private void btBanlist_Click(object sender, EventArgs e)
        {
            Banlist p = new Banlist(mc);
            p.Show();
        }

        private void btKits_Click(object sender, EventArgs e)
        {
            KitEditor editor = new KitEditor(mc);
            editor.Show();
        }

        private void ScrollToCarret(RichTextBox rtb)
        {
            if (chkScroll.Checked)
            {
                rtb.SelectionStart = rtb.Text.Length;
                rtb.ScrollToCaret();
            }
        }

        bool overrideSaveDialog = false;

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToConfig();
            if (mc.Started)
            {
                if (mc.Config.ForceSaveAndExit || overrideSaveDialog)
                {
                    Tunnel.IsConnected = false;
                    mc.ExecuteCommand("stop");
                    mc.UnloadAllPlugins();
                    web.Stop();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Save and Exit ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        Tunnel.IsConnected = false;
                        mc.ExecuteCommand("stop");
                        mc.UnloadAllPlugins();
                        web.Stop();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                Tunnel.IsConnected = false;
                mc.UnloadAllPlugins();
                web.Stop();
            }
        }

        bool timerElapsed = false;
        DateTime dtBackupTime = DateTime.Now;

        private void btLevelEditor_Click(object sender, EventArgs e)
        {
            GroupEditor l = new GroupEditor(mc);
            l.Show();
        }

        private void btConfig_Click(object sender, EventArgs e)
        {
            ConfigForm c = new ConfigForm(mc);
            c.Show();
        }

        private void btUserEditor_Click(object sender, EventArgs e)
        {
            UserForm u = new UserForm(mc);
            u.Show();
        }

        private void rtbConsole_TextChanged(object sender, EventArgs e)
        {
            if (rtbConsole.Lines.Length > 500)
            {
                try
                {
                    Log.AppendText(rtbConsole.Text, Log.ConsoleLogFile);
                    rtbConsole.Clear();
                }
                catch
                {

                }
            }
        }

        private void btWhitelist_Click(object sender, EventArgs e)
        {
            WhiteList w = new WhiteList(mc);
            w.Show();
        }

        Restart restart;

        public void Restart()
        {
            restart.Repeat = false;
            restart.StartTask();
        }

        private void btRestart_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void chkOnlyRestart_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btStreamFlush_Click(object sender, EventArgs e)
        {
            mc.Input.Flush();
        }

        TcpTunnelServer Tunnel;

        private void chkServerActive_CheckedChanged(object sender, EventArgs e)
        {
            CheckTunnel();
        }
        private void CheckTunnel()
        {
            mc.IsTunneled = chkTunnelActive.Checked;
            Tunnel.ClientPort = (int)numericInternalPort.Value;
            Tunnel.ServerPort = (int)numericExternalPort.Value;
            Tunnel.IsConnected = chkTunnelActive.Checked;
            Tunnel.ChatMessageReceived -= new TcpTunnelServer.OnChatMessageReceived(Tunnel_ChatMessageReceived);
            Tunnel.ChatMessageReceived += new TcpTunnelServer.OnChatMessageReceived(Tunnel_ChatMessageReceived);
        }

        void Tunnel_ChatMessageReceived(ClientSocket client, string message)
        {
            String dateTimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                dateTimeString = DateTime.Now.ToString(mc.Config.ChatDateTimeFormat);
            }
            catch { }
            if (client != null)
            {
                String chatMessage = String.Format("{0} {1}: {2}", dateTimeString, client.Name, message);
                Utils.ExecuteThreadSafe(rtbServerClient, chatMessage);
            }
            else
            {
                String chatMessage = String.Format("{0} {1}: {2}", dateTimeString, "Debug", message);
                Utils.ExecuteThreadSafe(rtbServerClient, chatMessage);
            }
        }

        private void rtbServerClient_TextChanged(object sender, EventArgs e)
        {
            if (chkChatScroll.Checked)
            {
                ScrollToCarret(rtbServerClient);
            }

            if (rtbServerClient.Lines.Length > 500)
            {
                try
                {
                    Log.AppendText(rtbServerClient.Text, Log.ChatMessageLogFile);
                    rtbServerClient.Clear();
                }
                catch
                {

                }
            }
        }

        private void btBadBlocks_Click(object sender, EventArgs e)
        {
            BadBlocksForm b = new BadBlocksForm(mc);
            b.Show();
        }

        private void btSendTP_Click(object sender, EventArgs e)
        {
            Vector3 vec = new Vector3(100, 100, 100);
        }

        private void chkShutdown_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btZones_Click(object sender, EventArgs e)
        {
            ZoneForm z = new ZoneForm(mc);
            z.Show();
        }

        //Dieses Event wird nur aufgerufen wenn ein Update gefunden wurde.
        void updateController1_updateFound(object sender, updateSystemDotNet.appEventArgs.updateFoundEventArgs e)
        {
            //Ueber e.Result kann auf die Updateinformationen zugegriffen werden.
            UpdateDialog ud = new UpdateDialog(e.Result, mc.Version);
            //if (MessageBox.Show(string.Format("An update is available!\r\nUpdate available: {0}\r\nWould you like to install the update now?", e.Result.newUpdatePackages[e.Result.newUpdatePackages.Count - 1].Version),
            //    "Update available",
            //    MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Information) == DialogResult.Yes)
            if (ud.ShowDialog() == DialogResult.Yes)
            {
                //Diese Methode startet den asynchronen Updatedownload
                updateController.downloadUpdates();
                lblStatusBar.Text = "downloading update...";
            }
        }

        //Dieses Event wird immer aufgerufen wenn die Updatesuche beendet wurde.
        void updateController1_checkForUpdatesCompleted(object sender, updateSystemDotNet.appEventArgs.checkForUpdatesCompletedEventArgs e)
        {
            //Ob waehrend der Updatesuche ein Fehler aufgetreten ist,
            //kann der Variablen e.Error entnommen werden (e.Error != null)
            if (e.Error != null)
            {
                lblStatusBar.Text = "an error occurred while searcing for updates:\r\n" + e.Error.Message;
                TimedRemoveText(5000);
            }
            else
            {
                lblStatusBar.Text = "you already have the newest version " + mc.Version;
                TimedRemoveText(5000);
            }
        }

        //Dieses Event wird aufgerufen wenn sich der Downloadstatus aendert.
        void updateController1_downloadUpdatesProgressChanged(object sender, updateSystemDotNet.appEventArgs.downloadUpdatesProgressChangedEventArgs e)
        {
            //Ueber e.ProgressPercentage kann der aktuelle Fortschritt in Prozent abgefragt,
            //und beispielsweise an eine ProgressBar uebergeben werden
            progressBar.Value = e.ProgressPercentage;
        }

        //Dieses Event wird aufgerufen, wenn der Updatedownload abgeschlossen wurde.
        void updateController1_downloadUpdatesCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Wenn der Download erfolgreich war, ist e.Error == null und e.Cancelled == false
            if (e.Error == null && !e.Cancelled)
            {
                //Update anwenden
                updateController.applyUpdate();
            }
            else if (e.Error != null) //Ueberprueft ob ein Fehler aufgetreten ist und zeigt diesen an
            {
                lblStatusBar.Text = "an error occurred while downloading update:\r\n" + e.Error.Message;

                TimedRemoveText(5000);
            }
        }

        private void updateController_updateInstallerStarted(object sender, updateSystemDotNet.appEventArgs.updateInstallerStartedEventArgs e)
        {
            overrideSaveDialog = true;
            this.Close();
        }

        private void TimedRemoveText(int delay)
        {
            timerUpdates.Interval = delay;
            timerUpdates.Start();
        }

        private void timerUpdates_Tick(object sender, EventArgs e)
        {
            lblStatusBar.Text = "";
            progressBar.Value = 0;
            timerUpdates.Stop();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            try
            {
                Utils.ExecuteThreadSafe(statusStrip1, progressBar, e.ProgressPercentage);
            }
            catch
            {

            }
        }

        private void timerMessages_Tick(object sender, EventArgs e)
        {
            string message = "";
            if (messageQueue.Dequeue(out message))
            {
                rtbConsole.AppendText(message);
                ScrollToCarret(rtbConsole);
            }
        }

        private void dayTimeTimer_Tick(object sender, EventArgs e)
        {
            if (Tunnel.ServerSocket != null)
            {
                if (Tunnel.ServerSocket.TimeOfDay >= 24000)
                {
                    Tunnel.ServerSocket.TimeOfDay = 0;
                }
                //Tunnel.ServerSocket.TimeOfDay += (int)numTimeElapse.Value;
                Tunnel.ServerSocket.TimeOfDay += (int)20;
            }
        }

        private void btPlugins_Click(object sender, EventArgs e)
        {
            AddonForm a = new AddonForm(mc.Plugins);
            a.Show();
        }

        private void btReloadPlugins_Click(object sender, EventArgs e)
        {
            mc.ReloadPlugins();
            this.listLoadedPlugins.DataSource = null;
            this.listLoadedPlugins.DataSource = mc.Plugins;
        }

        private void btDeactivateAll_Click(object sender, EventArgs e)
        {
            mc.DeactivateAllPlugins();
            this.listLoadedPlugins.DataSource = null;
            this.listLoadedPlugins.DataSource = mc.Plugins;
        }

        private void btActivateAll_Click(object sender, EventArgs e)
        {
            mc.ActivateAllPlugins();
        }

        private void btUnloadAllPlugins_Click(object sender, EventArgs e)
        {
            mc.UnloadAllPlugins();
            this.listLoadedPlugins.DataSource = null;
            this.listLoadedPlugins.DataSource = mc.Plugins;
        }

        private void numTimeElapse_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numUpdateRate_ValueChanged(object sender, EventArgs e)
        {
            //dayTimeTimer.Interval = (int)numUpdateRate.Value;
            dayTimeTimer.Interval = (int)1000;
        }

        int currencyTicker = 0;

        private void timerCurrency_Tick(object sender, EventArgs e)
        {
            if (mc.Config.CurrencySystemEnabled)
            {
                if (currencyTicker >= mc.Config.CurrencyCycleMinutes * 60)
                {
                    currencyTicker = 0;
                    UserCollectionSingletone users = UserCollectionSingletone.GetInstance();
                    int amount = mc.Config.CurrencyAmountInCycle;
                    if (Tunnel.IsConnected)
                    {
                        Tunnel.ServerSocket.SendServerMessage("§" + mc.Config.ResponseColorChar + mc.Config.ResponsePrefix + " " + mc.Config.CurrencyCycleMessage + " (" + amount + mc.Config.CurrencySymbol + ")");
                    }
                    //mc.ExecuteSay();
                    foreach (User u in users.Items)
                    {
                        if (u.LevelID != 0)
                        {
                            if (mc.IsStringInList(u.Name, mc.Player))
                            {
                                u.Balance += amount;
                            }
                        }
                    }
                }
                currencyTicker++;
            }
        }

        private void btPrices_Click(object sender, EventArgs e)
        {
            PricesBlocksForm prices = new PricesBlocksForm(mc);
            prices.Show();
        }

        private void btCheckForUpdates_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        bool startTunnel = false;
        int tunnelTicker = 0;
        int tunnelMax = 5;

        //int heartbeatTicker = 0;
        //int heartbeatMax = 10;
        private void timerTicker_Tick(object sender, EventArgs e)
        {
            if (mc.Started)
            {
                mc.SecondsOnline++;
            }
            else
            {
                mc.SecondsOnline = 0;
            }

            if (startTunnel)
            {
                if (tunnelTicker++ >= tunnelMax)
                {
                    chkTunnelActive.Checked = true;
                    tunnelTicker = 0;
                    startTunnel = false;
                }
            }

            //if (heartbeatTicker >= heartbeatMax)
            //{
            //    heartbeatTicker = 0;                
            //    mc.Config.ExternalIp = GetExternalIp();
            //    if (mc.Config.ExternalIp != null)
            //    {
            //        ExecuteHeartbeat();
            //    }
            //}
            //heartbeatTicker++;
            lblTimeStatus.Text = String.Format("Time: {0:hh:MM:ss}", DateTime.Now);
            if (mc.Started)
            {
                lblServerStatus.Text = String.Format("Server: active");
                lblServerStatus.ForeColor = Color.Green;
            }
            else
            {
                lblServerStatus.Text = String.Format("Server: inactive");
                lblServerStatus.ForeColor = Color.Red;
            }

            if (chkTunnelActive.Checked)
            {
                lblTunnelStatus.Text = String.Format("Tunnel: active");
                lblTunnelStatus.ForeColor = Color.Green;
            }
            else
            {
                lblTunnelStatus.Text = String.Format("Tunnel: inactive");
                lblTunnelStatus.ForeColor = Color.Red;
            }
        }

        private void btConfigPlugin_Click(object sender, EventArgs e)
        {
            IPlugin p = listLoadedPlugins.SelectedItem as IPlugin;
            if (p != null)
            {
                p.OnConfigDialog();
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mc.RaiseStarted();
        }

        private void StopServer()
        {
            try
            {
                mc.ExecuteCommand("stop");

                chkTunnelActive.Checked = false;
                Tunnel.ServerSocket.ExternalListener.Stop();
            }
            catch
            {

            }
        }

        private void StartServer()
        {

            chkTunnelActive.Checked = true;
            mc.Start();
            CheckServerProperties();
            Thread.Sleep(2000);
            CheckTunnel();
        }

        private void CheckServerProperties()
        {
            try
            {
                bool overwrite = false;
                ServerPropertiesDictonary dict = ServerPropertiesParser.Load(Path.Combine(Application.StartupPath, "server.properties"));
                if (dict.ContainsKey("server-ip"))
                {
                    if (dict["server-ip"] != "127.0.0.1")
                    {
                        DialogResult result = MessageBox.Show("ZMA has detected that the server internaly doesn't run with the local IP: 127.0.0.1" +
                            "\nShould ZMA correct the IP ?\nNote that this will overwrite the server.properties!",
                            "\nCorrect Internal IP and overwrite server.properties ?",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question
                            );
                        if (result == DialogResult.Yes)
                        {
                            dict["server-ip"] = "127.0.0.1";
                            overwrite = true;
                        }
                    }

                    if (dict["server-port"] != numericInternalPort.Value.ToString())
                    {
                        DialogResult result = MessageBox.Show("ZMA has detected that the server internaly doesn't run with the internal port: "
                            + numericInternalPort.Value.ToString() +
                            "\nShould ZMA correct the internal Port ?\nNote that this will overwrite the server.properties!",
                            "\nCorrect Internal Port and overwrite server.properties ?",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question
                            );
                        if (result == DialogResult.Yes)
                        {
                            dict["server-port"] = numericInternalPort.Value.ToString();
                            overwrite = true;
                        }
                    }
                    if (overwrite)
                    {
                        dict.Save(Path.Combine(Application.StartupPath, "server.properties"));
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Append(this, "Write server.properties " + ex.Message, Log.ExceptionsLog);
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mc.RaiseStopped();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm c = new ConfigForm(mc);
            c.Show();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //HelpDialog h = new HelpDialog();
            //h.Show();

            try
            {
                String helpViewerPath = Path.Combine(Path.Combine(Application.StartupPath, "Help"), "Zicores Help Viewer.exe");
                Process.Start(helpViewerPath);
            }
            catch
            {

            }
        }

        private void downloadServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to (re)download the actual minecraft_server.jar ?", "Download Server file ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (saveDownload.ShowDialog() == DialogResult.OK)
                {
                    WebClient client = new WebClient();
                    lblStatusBar.Text = "Download started";
                    client.DownloadFileAsync(new Uri("http://www.minecraft.net/download/minecraft_server.jar"), saveDownload.FileName);
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                }
            }
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            progressBar.Value = 0;
            lblStatusBar.Text = "Download completed";
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            int value = e.ProgressPercentage;
            if (value > 100)
                value = 100;
            progressBar.Value = value;
        }

        private void toggleTunnelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chkTunnelActive.Checked = !chkTunnelActive.Checked;
        }

        private void tbChatTunnel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void tbChatTunnel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (mc.Started && Tunnel.IsConnected)
                {
                    String dateTimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    try
                    {
                        dateTimeString = DateTime.Now.ToString(mc.Config.ChatDateTimeFormat);
                    }
                    catch { }

                    Tunnel.ServerSocket.SendServerMessage(mc.Config.ResponsePrefix + " " + tbChatTunnel.Text);
                    String chatMessage = String.Format("{0} {1} {2}", dateTimeString, mc.Config.ResponsePrefix, tbChatTunnel.Text);
                    Utils.ExecuteThreadSafe(rtbServerClient, chatMessage);
                }
                tbChatTunnel.Clear();
            }
        }

        private void numericExternalPort_ValueChanged(object sender, EventArgs e)
        {
            String message = String.Format("Remember: Connect with port {0}", numericExternalPort.Value);
            UpdateQuickHelp(message);
            mc.Config.ExternalPort = (int)numericExternalPort.Value;
        }

        private void UpdateQuickHelp(String message)
        {
            lbQuickhelp.Text = message;
        }

        SortableBindingList<TaskBase> tasks = null;
        TaskConfig taskConfig = new TaskConfig();

        private void GenerateTaskColumns()
        {
            dataGridTasks.AutoGenerateColumns = false;

            tasks = new SortableBindingList<TaskBase>(taskConfig.Tasks);

            DataGridViewColumn c = new DataGridViewTextBoxColumn();
            c.ReadOnly = true;
            c.HeaderText = "Backup name";
            c.DataPropertyName = "Name";
            dataGridTasks.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.ReadOnly = true;
            c.HeaderText = "Status";
            c.DataPropertyName = "StatusMessage";
            dataGridTasks.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.ReadOnly = true;
            c.HeaderText = "Repeat timespan";
            c.DataPropertyName = "RepeatTimeSpan";
            dataGridTasks.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.ReadOnly = true;
            c.HeaderText = "Start time";
            c.DataPropertyName = "StartedTime";
            dataGridTasks.Columns.Add(c);

            c = new DataGridViewTextBoxColumn();
            c.ReadOnly = true;
            c.HeaderText = "End time";
            c.DataPropertyName = "EndTime";
            dataGridTasks.Columns.Add(c);

            c = new DataGridViewCheckBoxColumn();
            c.ReadOnly = true;
            c.HeaderText = "Finished";
            c.DataPropertyName = "Finished";
            dataGridTasks.Columns.Add(c);

            c = new DataGridViewCheckBoxColumn();
            //c.ReadOnly = true;
            c.HeaderText = "Active";
            c.DataPropertyName = "Active";
            dataGridTasks.Columns.Add(c);

            dataGridTasks.DataSource = tasks;
        }

        private void btAddTask_Click(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan((int)numericHours.Value, (int)numericMinutes.Value, (int)numericSeconds.Value - 1);
            if (ts.TotalSeconds <= 5)
            {
                MessageBox.Show("The timespan must be over 5 seconds");
            }
            else
            {
                Backup backup = new Backup(tbTaskName.Text);

                backup.TaskProgressChanged += new ProgressChangedEventHandler(backup_ProgressChanged);
                backup.TaskCompleted += new RunWorkerCompletedEventHandler(backup_TaskCompleted);

                backup.Repeat = chkRepeatTask.Checked;
                backup.RepeatTimeSpan = ts;
                backup.Source = mc.Config.WorldPath;
                backup.Destination = mc.Config.BackupFolder;
                backup.StartTask();
                tasks.Add(backup);
                tasks.ResetBindings();
            }
        }

        void backup_TaskCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tasks.ResetBindings();
        }

        private void backup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //tasks.ResetBindings();
        }

        private void btRemoveTask_Click(object sender, EventArgs e)
        {
            if (dataGridTasks.SelectedCells.Count > 0)
            {
                DataGridViewRow row = dataGridTasks.Rows[dataGridTasks.SelectedCells[0].RowIndex];
                TaskBase task = (TaskBase)row.DataBoundItem;
                if (task != null)
                {
                    task.Dispose();
                    tasks.Remove(task);
                }
            }
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            if (dataGridTasks.SelectedCells.Count > 0)
            {
                DataGridViewRow row = dataGridTasks.Rows[dataGridTasks.SelectedCells[0].RowIndex];
                Backup task = (Backup)row.DataBoundItem;
                if (task != null)
                {
                    TimeSpan ts = new TimeSpan((int)numericHours.Value, (int)numericMinutes.Value, (int)numericSeconds.Value - 1);
                    if (ts.TotalSeconds <= 5)
                    {
                        MessageBox.Show("The timespan must be over 5 seconds");
                    }
                    else
                    {
                        task.Repeat = chkRepeatTask.Checked;
                        task.RepeatTimeSpan = ts;
                        task.Source = mc.Config.WorldPath;
                        task.Destination = mc.Config.BackupFolder;
                        task.StartTask();
                    }
                }
            }
        }


        private void numericHours_ValueChanged(object sender, EventArgs e)
        {
            mc.Config.TaskHours = numericHours.Value;
        }

        private void numericMinutes_ValueChanged(object sender, EventArgs e)
        {
            mc.Config.TaskMinutes = numericMinutes.Value;
        }

        private void numericSeconds_ValueChanged(object sender, EventArgs e)
        {
            mc.Config.TaskSeconds = numericSeconds.Value;
        }

        private void tbTaskName_TextChanged(object sender, EventArgs e)
        {
            mc.Config.BackupPrefix = tbTaskName.Text;
        }

        private void btClearTasks_Click(object sender, EventArgs e)
        {
            foreach (var item in tasks)
            {
                item.Cancel();
                item.Dispose();
            }

            tasks.Clear();
            tasks.ResetBindings();
        }

        private void numericInternalPort_ValueChanged(object sender, EventArgs e)
        {
            mc.Config.InternalPort = (int)numericInternalPort.Value;
        }

        void npc_ClientException(object sender, MinecraftWrapper.WrapperEventArgs.ClientExceptionEventArgs e)
        {
            if (e.Exception != null)
            {
                messageQueue.Enqueue(String.Format(e.Exception.Message + Environment.NewLine));
            }
            if (e.Message != null)
            {
                messageQueue.Enqueue(e.Message + Environment.NewLine);
            }
        }

        private void btAddNpc_Click(object sender, EventArgs e)
        {
            ClientNpc npc = new ClientNpc(mc, tbNpcName.Text, tbPassword.Text);

            npc.ClientException -= new EventHandler<MinecraftWrapper.WrapperEventArgs.ClientExceptionEventArgs>(npc_ClientException);
            npc.ClientException += new EventHandler<MinecraftWrapper.WrapperEventArgs.ClientExceptionEventArgs>(npc_ClientException);
            npc.Connect();

            RefreshNpcs();
        }

        private void RefreshNpcs()
        {
            //listNpcs.DisplayMember = "";
            listNpcs.DataSource = null;

            listNpcs.DataSource = new List<ClientNpc>(mc.Npcs.Values);
        }

        private void btDisconnectNpc_Click(object sender, EventArgs e)
        {
            ClientNpc npc = listNpcs.SelectedItem as ClientNpc;
            if (npc != null)
            {
                npc.Disconnect();
                mc.Npcs.Remove(npc.Name);
            }
        }

        private void btRefreshNpcs_Click(object sender, EventArgs e)
        {
            RefreshNpcs();
        }

        private void SpeakThrough()
        {
            ClientNpc npc = listNpcs.SelectedItem as ClientNpc;
            if (npc != null)
            {
                npc.SpeakThrough(tbSpeakThrough.Text);
            }
            tbSpeakThrough.Text = "";
        }

        private void tbSpeakThrough_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SpeakThrough();
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            SpeakThrough();
        }

        private void tbSpeakThrough_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
