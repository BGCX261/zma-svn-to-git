namespace Zicore.MinecraftAdmin
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerUpdates = new System.Windows.Forms.Timer(this.components);
            this.timerMessages = new System.Windows.Forms.Timer(this.components);
            this.dayTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.timerCurrency = new System.Windows.Forms.Timer(this.components);
            this.timerTicker = new System.Windows.Forms.Timer(this.components);
            this.tabNpcs = new System.Windows.Forms.TabControl();
            this.tabInOutput = new System.Windows.Forms.TabPage();
            this.groupInputOutput = new System.Windows.Forms.GroupBox();
            this.lbQuickhelp = new System.Windows.Forms.Label();
            this.chkScroll = new System.Windows.Forms.CheckBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.tabTunnel = new System.Windows.Forms.TabPage();
            this.groupTesting = new System.Windows.Forms.GroupBox();
            this.tbChatTunnel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkChatScroll = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericExternalPort = new System.Windows.Forms.NumericUpDown();
            this.numericInternalPort = new System.Windows.Forms.NumericUpDown();
            this.rtbServerClient = new System.Windows.Forms.RichTextBox();
            this.chkTunnelActive = new System.Windows.Forms.CheckBox();
            this.tabRestartBackup = new System.Windows.Forms.TabPage();
            this.groupBackup = new System.Windows.Forms.GroupBox();
            this.btClearTasks = new System.Windows.Forms.Button();
            this.btApply = new System.Windows.Forms.Button();
            this.btRemoveTask = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericHours = new System.Windows.Forms.NumericUpDown();
            this.numericSeconds = new System.Windows.Forms.NumericUpDown();
            this.numericMinutes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTaskName = new System.Windows.Forms.TextBox();
            this.chkRepeatTask = new System.Windows.Forms.CheckBox();
            this.btAddTask = new System.Windows.Forms.Button();
            this.dataGridTasks = new System.Windows.Forms.DataGridView();
            this.tabPlugins = new System.Windows.Forms.TabPage();
            this.groupPlugins = new System.Windows.Forms.GroupBox();
            this.btConfigPlugin = new System.Windows.Forms.Button();
            this.btUnloadAllPlugins = new System.Windows.Forms.Button();
            this.btActivateAll = new System.Windows.Forms.Button();
            this.btDeactivateAll = new System.Windows.Forms.Button();
            this.btReloadPlugins = new System.Windows.Forms.Button();
            this.listLoadedPlugins = new System.Windows.Forms.ListBox();
            this.btPlugins = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPassword = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btSend = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbSpeakThrough = new System.Windows.Forms.TextBox();
            this.btRefreshNpcs = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.tbNpcName = new System.Windows.Forms.TextBox();
            this.btDisconnectNpc = new System.Windows.Forms.Button();
            this.btAddNpc = new System.Windows.Forms.Button();
            this.listNpcs = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTunnelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTimeStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleTunnelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.downloadServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDownload = new System.Windows.Forms.SaveFileDialog();
            this.updateController = new updateSystemDotNet.updateController();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabNpcs.SuspendLayout();
            this.tabInOutput.SuspendLayout();
            this.groupInputOutput.SuspendLayout();
            this.tabTunnel.SuspendLayout();
            this.groupTesting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericExternalPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInternalPort)).BeginInit();
            this.tabRestartBackup.SuspendLayout();
            this.groupBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTasks)).BeginInit();
            this.tabPlugins.SuspendLayout();
            this.groupPlugins.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerUpdates
            // 
            this.timerUpdates.Interval = 10000;
            this.timerUpdates.Tick += new System.EventHandler(this.timerUpdates_Tick);
            // 
            // timerMessages
            // 
            this.timerMessages.Enabled = true;
            this.timerMessages.Interval = 50;
            this.timerMessages.Tick += new System.EventHandler(this.timerMessages_Tick);
            // 
            // dayTimeTimer
            // 
            this.dayTimeTimer.Enabled = true;
            this.dayTimeTimer.Interval = 1000;
            this.dayTimeTimer.Tick += new System.EventHandler(this.dayTimeTimer_Tick);
            // 
            // timerCurrency
            // 
            this.timerCurrency.Enabled = true;
            this.timerCurrency.Interval = 1000;
            this.timerCurrency.Tick += new System.EventHandler(this.timerCurrency_Tick);
            // 
            // timerTicker
            // 
            this.timerTicker.Enabled = true;
            this.timerTicker.Interval = 1000;
            this.timerTicker.Tick += new System.EventHandler(this.timerTicker_Tick);
            // 
            // tabNpcs
            // 
            this.tabNpcs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabNpcs.Controls.Add(this.tabInOutput);
            this.tabNpcs.Controls.Add(this.tabTunnel);
            this.tabNpcs.Controls.Add(this.tabRestartBackup);
            this.tabNpcs.Controls.Add(this.tabPlugins);
            this.tabNpcs.Controls.Add(this.tabPage1);
            this.tabNpcs.Location = new System.Drawing.Point(0, 27);
            this.tabNpcs.Multiline = true;
            this.tabNpcs.Name = "tabNpcs";
            this.tabNpcs.SelectedIndex = 0;
            this.tabNpcs.Size = new System.Drawing.Size(759, 510);
            this.tabNpcs.TabIndex = 4;
            // 
            // tabInOutput
            // 
            this.tabInOutput.Controls.Add(this.groupInputOutput);
            this.tabInOutput.Location = new System.Drawing.Point(4, 22);
            this.tabInOutput.Name = "tabInOutput";
            this.tabInOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabInOutput.Size = new System.Drawing.Size(751, 484);
            this.tabInOutput.TabIndex = 4;
            this.tabInOutput.Text = "Input/Output";
            this.tabInOutput.UseVisualStyleBackColor = true;
            // 
            // groupInputOutput
            // 
            this.groupInputOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupInputOutput.Controls.Add(this.lbQuickhelp);
            this.groupInputOutput.Controls.Add(this.chkScroll);
            this.groupInputOutput.Controls.Add(this.tbInput);
            this.groupInputOutput.Controls.Add(this.rtbConsole);
            this.groupInputOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupInputOutput.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupInputOutput.Location = new System.Drawing.Point(6, 6);
            this.groupInputOutput.Name = "groupInputOutput";
            this.groupInputOutput.Size = new System.Drawing.Size(737, 472);
            this.groupInputOutput.TabIndex = 1;
            this.groupInputOutput.TabStop = false;
            this.groupInputOutput.Text = "Input/Output";
            // 
            // lbQuickhelp
            // 
            this.lbQuickhelp.AutoSize = true;
            this.lbQuickhelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuickhelp.ForeColor = System.Drawing.Color.Black;
            this.lbQuickhelp.Location = new System.Drawing.Point(6, 23);
            this.lbQuickhelp.Name = "lbQuickhelp";
            this.lbQuickhelp.Size = new System.Drawing.Size(253, 16);
            this.lbQuickhelp.TabIndex = 9;
            this.lbQuickhelp.Text = "Remember: Connect with port 25565";
            // 
            // chkScroll
            // 
            this.chkScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkScroll.AutoSize = true;
            this.chkScroll.Checked = true;
            this.chkScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkScroll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkScroll.Location = new System.Drawing.Point(660, 19);
            this.chkScroll.Name = "chkScroll";
            this.chkScroll.Size = new System.Drawing.Size(71, 17);
            this.chkScroll.TabIndex = 8;
            this.chkScroll.Text = "List Scroll";
            this.chkScroll.UseVisualStyleBackColor = true;
            // 
            // tbInput
            // 
            this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(6, 446);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(725, 20);
            this.tbInput.TabIndex = 1;
            this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyDown);
            this.tbInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyUp);
            // 
            // rtbConsole
            // 
            this.rtbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbConsole.Location = new System.Drawing.Point(6, 42);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.Size = new System.Drawing.Size(725, 398);
            this.rtbConsole.TabIndex = 0;
            this.rtbConsole.Text = "";
            this.rtbConsole.TextChanged += new System.EventHandler(this.rtbConsole_TextChanged);
            // 
            // tabTunnel
            // 
            this.tabTunnel.Controls.Add(this.groupTesting);
            this.tabTunnel.Location = new System.Drawing.Point(4, 22);
            this.tabTunnel.Name = "tabTunnel";
            this.tabTunnel.Padding = new System.Windows.Forms.Padding(3);
            this.tabTunnel.Size = new System.Drawing.Size(751, 484);
            this.tabTunnel.TabIndex = 2;
            this.tabTunnel.Text = "Tunneling";
            this.tabTunnel.UseVisualStyleBackColor = true;
            // 
            // groupTesting
            // 
            this.groupTesting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTesting.Controls.Add(this.tbChatTunnel);
            this.groupTesting.Controls.Add(this.label5);
            this.groupTesting.Controls.Add(this.chkChatScroll);
            this.groupTesting.Controls.Add(this.label4);
            this.groupTesting.Controls.Add(this.label3);
            this.groupTesting.Controls.Add(this.numericExternalPort);
            this.groupTesting.Controls.Add(this.numericInternalPort);
            this.groupTesting.Controls.Add(this.rtbServerClient);
            this.groupTesting.Controls.Add(this.chkTunnelActive);
            this.groupTesting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupTesting.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupTesting.Location = new System.Drawing.Point(6, 6);
            this.groupTesting.Name = "groupTesting";
            this.groupTesting.Size = new System.Drawing.Size(717, 472);
            this.groupTesting.TabIndex = 0;
            this.groupTesting.TabStop = false;
            this.groupTesting.Text = "Server Client Tunnel && Chat Messages";
            // 
            // tbChatTunnel
            // 
            this.tbChatTunnel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbChatTunnel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChatTunnel.Location = new System.Drawing.Point(6, 446);
            this.tbChatTunnel.Name = "tbChatTunnel";
            this.tbChatTunnel.Size = new System.Drawing.Size(705, 20);
            this.tbChatTunnel.TabIndex = 9;
            this.tbChatTunnel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbChatTunnel_KeyDown);
            this.tbChatTunnel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbChatTunnel_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Messages";
            // 
            // chkChatScroll
            // 
            this.chkChatScroll.AutoSize = true;
            this.chkChatScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChatScroll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkChatScroll.Location = new System.Drawing.Point(495, 20);
            this.chkChatScroll.Name = "chkChatScroll";
            this.chkChatScroll.Size = new System.Drawing.Size(123, 17);
            this.chkChatScroll.TabIndex = 7;
            this.chkChatScroll.Text = "Chat Message Scroll";
            this.chkChatScroll.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(299, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "public port\r\n(players will connect to this port)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(90, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "server.properties port";
            // 
            // numericExternalPort
            // 
            this.numericExternalPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericExternalPort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numericExternalPort.Location = new System.Drawing.Point(215, 21);
            this.numericExternalPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericExternalPort.Name = "numericExternalPort";
            this.numericExternalPort.Size = new System.Drawing.Size(78, 20);
            this.numericExternalPort.TabIndex = 4;
            this.numericExternalPort.Value = new decimal(new int[] {
            25565,
            0,
            0,
            0});
            this.numericExternalPort.ValueChanged += new System.EventHandler(this.numericExternalPort_ValueChanged);
            // 
            // numericInternalPort
            // 
            this.numericInternalPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericInternalPort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numericInternalPort.Location = new System.Drawing.Point(6, 21);
            this.numericInternalPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericInternalPort.Name = "numericInternalPort";
            this.numericInternalPort.Size = new System.Drawing.Size(78, 20);
            this.numericInternalPort.TabIndex = 3;
            this.numericInternalPort.Value = new decimal(new int[] {
            8890,
            0,
            0,
            0});
            this.numericInternalPort.ValueChanged += new System.EventHandler(this.numericInternalPort_ValueChanged);
            // 
            // rtbServerClient
            // 
            this.rtbServerClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbServerClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbServerClient.Location = new System.Drawing.Point(6, 63);
            this.rtbServerClient.Name = "rtbServerClient";
            this.rtbServerClient.Size = new System.Drawing.Size(705, 377);
            this.rtbServerClient.TabIndex = 2;
            this.rtbServerClient.Text = "";
            this.rtbServerClient.TextChanged += new System.EventHandler(this.rtbServerClient_TextChanged);
            // 
            // chkTunnelActive
            // 
            this.chkTunnelActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTunnelActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTunnelActive.ForeColor = System.Drawing.Color.Black;
            this.chkTunnelActive.Location = new System.Drawing.Point(634, 21);
            this.chkTunnelActive.Name = "chkTunnelActive";
            this.chkTunnelActive.Size = new System.Drawing.Size(77, 26);
            this.chkTunnelActive.TabIndex = 0;
            this.chkTunnelActive.Text = "Active";
            this.chkTunnelActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTunnelActive.UseVisualStyleBackColor = true;
            this.chkTunnelActive.Visible = false;
            this.chkTunnelActive.CheckedChanged += new System.EventHandler(this.chkServerActive_CheckedChanged);
            // 
            // tabRestartBackup
            // 
            this.tabRestartBackup.Controls.Add(this.groupBackup);
            this.tabRestartBackup.Location = new System.Drawing.Point(4, 22);
            this.tabRestartBackup.Name = "tabRestartBackup";
            this.tabRestartBackup.Padding = new System.Windows.Forms.Padding(3);
            this.tabRestartBackup.Size = new System.Drawing.Size(751, 484);
            this.tabRestartBackup.TabIndex = 1;
            this.tabRestartBackup.Text = "Restart/Backup";
            this.tabRestartBackup.UseVisualStyleBackColor = true;
            // 
            // groupBackup
            // 
            this.groupBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBackup.Controls.Add(this.btClearTasks);
            this.groupBackup.Controls.Add(this.btApply);
            this.groupBackup.Controls.Add(this.btRemoveTask);
            this.groupBackup.Controls.Add(this.label9);
            this.groupBackup.Controls.Add(this.label8);
            this.groupBackup.Controls.Add(this.label7);
            this.groupBackup.Controls.Add(this.label6);
            this.groupBackup.Controls.Add(this.label2);
            this.groupBackup.Controls.Add(this.numericHours);
            this.groupBackup.Controls.Add(this.numericSeconds);
            this.groupBackup.Controls.Add(this.numericMinutes);
            this.groupBackup.Controls.Add(this.label1);
            this.groupBackup.Controls.Add(this.tbTaskName);
            this.groupBackup.Controls.Add(this.chkRepeatTask);
            this.groupBackup.Controls.Add(this.btAddTask);
            this.groupBackup.Controls.Add(this.dataGridTasks);
            this.groupBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBackup.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBackup.Location = new System.Drawing.Point(6, 6);
            this.groupBackup.Name = "groupBackup";
            this.groupBackup.Size = new System.Drawing.Size(739, 472);
            this.groupBackup.TabIndex = 28;
            this.groupBackup.TabStop = false;
            this.groupBackup.Text = "Taskmanager";
            // 
            // btClearTasks
            // 
            this.btClearTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClearTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClearTasks.ForeColor = System.Drawing.Color.Red;
            this.btClearTasks.Location = new System.Drawing.Point(573, 424);
            this.btClearTasks.Name = "btClearTasks";
            this.btClearTasks.Size = new System.Drawing.Size(38, 42);
            this.btClearTasks.TabIndex = 50;
            this.btClearTasks.Text = "X";
            this.toolTip.SetToolTip(this.btClearTasks, "Removes all tasks instantly");
            this.btClearTasks.UseVisualStyleBackColor = true;
            this.btClearTasks.Click += new System.EventHandler(this.btClearTasks_Click);
            // 
            // btApply
            // 
            this.btApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btApply.Font = new System.Drawing.Font("Moire ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btApply.ForeColor = System.Drawing.Color.Blue;
            this.btApply.Location = new System.Drawing.Point(617, 424);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(52, 42);
            this.btApply.TabIndex = 49;
            this.btApply.Text = "=>";
            this.toolTip.SetToolTip(this.btApply, "Applies the task informations");
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // btRemoveTask
            // 
            this.btRemoveTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemoveTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRemoveTask.ForeColor = System.Drawing.Color.Red;
            this.btRemoveTask.Location = new System.Drawing.Point(675, 424);
            this.btRemoveTask.Name = "btRemoveTask";
            this.btRemoveTask.Size = new System.Drawing.Size(26, 42);
            this.btRemoveTask.TabIndex = 48;
            this.btRemoveTask.Text = "-";
            this.toolTip.SetToolTip(this.btRemoveTask, "Removes the selected task");
            this.btRemoveTask.UseVisualStyleBackColor = true;
            this.btRemoveTask.Click += new System.EventHandler(this.btRemoveTask_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(444, 423);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Seconds";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(372, 423);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Minutes";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(300, 423);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Hours";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(356, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 18);
            this.label6.TabIndex = 44;
            this.label6.Text = ":";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(428, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 18);
            this.label2.TabIndex = 43;
            this.label2.Text = ":";
            // 
            // numericHours
            // 
            this.numericHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericHours.Location = new System.Drawing.Point(303, 440);
            this.numericHours.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericHours.Name = "numericHours";
            this.numericHours.Size = new System.Drawing.Size(47, 20);
            this.numericHours.TabIndex = 42;
            this.numericHours.ValueChanged += new System.EventHandler(this.numericHours_ValueChanged);
            // 
            // numericSeconds
            // 
            this.numericSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericSeconds.Location = new System.Drawing.Point(447, 440);
            this.numericSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericSeconds.Name = "numericSeconds";
            this.numericSeconds.Size = new System.Drawing.Size(47, 20);
            this.numericSeconds.TabIndex = 41;
            this.numericSeconds.ValueChanged += new System.EventHandler(this.numericSeconds_ValueChanged);
            // 
            // numericMinutes
            // 
            this.numericMinutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericMinutes.Location = new System.Drawing.Point(375, 440);
            this.numericMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericMinutes.Name = "numericMinutes";
            this.numericMinutes.Size = new System.Drawing.Size(47, 20);
            this.numericMinutes.TabIndex = 40;
            this.numericMinutes.ValueChanged += new System.EventHandler(this.numericMinutes_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Task name";
            // 
            // tbTaskName
            // 
            this.tbTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTaskName.Location = new System.Drawing.Point(9, 440);
            this.tbTaskName.Name = "tbTaskName";
            this.tbTaskName.Size = new System.Drawing.Size(153, 20);
            this.tbTaskName.TabIndex = 38;
            this.tbTaskName.Text = "backup";
            this.tbTaskName.TextChanged += new System.EventHandler(this.tbTaskName_TextChanged);
            // 
            // chkRepeatTask
            // 
            this.chkRepeatTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRepeatTask.AutoSize = true;
            this.chkRepeatTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRepeatTask.ForeColor = System.Drawing.Color.Black;
            this.chkRepeatTask.Location = new System.Drawing.Point(168, 442);
            this.chkRepeatTask.Name = "chkRepeatTask";
            this.chkRepeatTask.Size = new System.Drawing.Size(108, 17);
            this.chkRepeatTask.TabIndex = 37;
            this.chkRepeatTask.Text = "Repeat task after";
            this.toolTip.SetToolTip(this.chkRepeatTask, "Activates the repeat for this thread.\r\nThe task will repeat after the specified p" +
        "eriod of time when selected.\r\nIf not selected, the task will start instantly.");
            this.chkRepeatTask.UseVisualStyleBackColor = true;
            // 
            // btAddTask
            // 
            this.btAddTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddTask.ForeColor = System.Drawing.Color.Green;
            this.btAddTask.Location = new System.Drawing.Point(707, 424);
            this.btAddTask.Name = "btAddTask";
            this.btAddTask.Size = new System.Drawing.Size(26, 42);
            this.btAddTask.TabIndex = 36;
            this.btAddTask.Text = "+";
            this.toolTip.SetToolTip(this.btAddTask, "Adds a new task with the specified informations");
            this.btAddTask.UseVisualStyleBackColor = true;
            this.btAddTask.Click += new System.EventHandler(this.btAddTask_Click);
            // 
            // dataGridTasks
            // 
            this.dataGridTasks.AllowUserToAddRows = false;
            this.dataGridTasks.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridTasks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTasks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridTasks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridTasks.Location = new System.Drawing.Point(9, 21);
            this.dataGridTasks.Name = "dataGridTasks";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTasks.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridTasks.RowHeadersWidth = 30;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTasks.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridTasks.Size = new System.Drawing.Size(724, 397);
            this.dataGridTasks.TabIndex = 35;
            // 
            // tabPlugins
            // 
            this.tabPlugins.Controls.Add(this.groupPlugins);
            this.tabPlugins.Location = new System.Drawing.Point(4, 22);
            this.tabPlugins.Name = "tabPlugins";
            this.tabPlugins.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlugins.Size = new System.Drawing.Size(751, 484);
            this.tabPlugins.TabIndex = 3;
            this.tabPlugins.Text = "Plugins";
            this.tabPlugins.UseVisualStyleBackColor = true;
            // 
            // groupPlugins
            // 
            this.groupPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPlugins.Controls.Add(this.btConfigPlugin);
            this.groupPlugins.Controls.Add(this.btUnloadAllPlugins);
            this.groupPlugins.Controls.Add(this.btActivateAll);
            this.groupPlugins.Controls.Add(this.btDeactivateAll);
            this.groupPlugins.Controls.Add(this.btReloadPlugins);
            this.groupPlugins.Controls.Add(this.listLoadedPlugins);
            this.groupPlugins.Controls.Add(this.btPlugins);
            this.groupPlugins.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPlugins.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupPlugins.Location = new System.Drawing.Point(6, 6);
            this.groupPlugins.Name = "groupPlugins";
            this.groupPlugins.Size = new System.Drawing.Size(719, 472);
            this.groupPlugins.TabIndex = 1;
            this.groupPlugins.TabStop = false;
            this.groupPlugins.Text = "Plugins";
            // 
            // btConfigPlugin
            // 
            this.btConfigPlugin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfigPlugin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btConfigPlugin.Location = new System.Drawing.Point(100, 79);
            this.btConfigPlugin.Name = "btConfigPlugin";
            this.btConfigPlugin.Size = new System.Drawing.Size(88, 23);
            this.btConfigPlugin.TabIndex = 38;
            this.btConfigPlugin.Text = "Config";
            this.btConfigPlugin.UseVisualStyleBackColor = true;
            this.btConfigPlugin.Click += new System.EventHandler(this.btConfigPlugin_Click);
            // 
            // btUnloadAllPlugins
            // 
            this.btUnloadAllPlugins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUnloadAllPlugins.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btUnloadAllPlugins.Location = new System.Drawing.Point(6, 108);
            this.btUnloadAllPlugins.Name = "btUnloadAllPlugins";
            this.btUnloadAllPlugins.Size = new System.Drawing.Size(88, 23);
            this.btUnloadAllPlugins.TabIndex = 37;
            this.btUnloadAllPlugins.Text = "Unload Plugins";
            this.btUnloadAllPlugins.UseVisualStyleBackColor = true;
            this.btUnloadAllPlugins.Visible = false;
            this.btUnloadAllPlugins.Click += new System.EventHandler(this.btUnloadAllPlugins_Click);
            // 
            // btActivateAll
            // 
            this.btActivateAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActivateAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btActivateAll.Location = new System.Drawing.Point(6, 50);
            this.btActivateAll.Name = "btActivateAll";
            this.btActivateAll.Size = new System.Drawing.Size(88, 23);
            this.btActivateAll.TabIndex = 36;
            this.btActivateAll.Text = "Activate All";
            this.btActivateAll.UseVisualStyleBackColor = true;
            this.btActivateAll.Click += new System.EventHandler(this.btActivateAll_Click);
            // 
            // btDeactivateAll
            // 
            this.btDeactivateAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeactivateAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btDeactivateAll.Location = new System.Drawing.Point(100, 50);
            this.btDeactivateAll.Name = "btDeactivateAll";
            this.btDeactivateAll.Size = new System.Drawing.Size(88, 23);
            this.btDeactivateAll.TabIndex = 35;
            this.btDeactivateAll.Text = "Deactivate All";
            this.btDeactivateAll.UseVisualStyleBackColor = true;
            this.btDeactivateAll.Click += new System.EventHandler(this.btDeactivateAll_Click);
            // 
            // btReloadPlugins
            // 
            this.btReloadPlugins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReloadPlugins.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btReloadPlugins.Location = new System.Drawing.Point(6, 79);
            this.btReloadPlugins.Name = "btReloadPlugins";
            this.btReloadPlugins.Size = new System.Drawing.Size(88, 23);
            this.btReloadPlugins.TabIndex = 34;
            this.btReloadPlugins.Text = "Reload Plugins";
            this.btReloadPlugins.UseVisualStyleBackColor = true;
            this.btReloadPlugins.Click += new System.EventHandler(this.btReloadPlugins_Click);
            // 
            // listLoadedPlugins
            // 
            this.listLoadedPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listLoadedPlugins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLoadedPlugins.FormattingEnabled = true;
            this.listLoadedPlugins.Location = new System.Drawing.Point(194, 21);
            this.listLoadedPlugins.Name = "listLoadedPlugins";
            this.listLoadedPlugins.Size = new System.Drawing.Size(519, 407);
            this.listLoadedPlugins.TabIndex = 33;
            // 
            // btPlugins
            // 
            this.btPlugins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPlugins.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btPlugins.Location = new System.Drawing.Point(6, 21);
            this.btPlugins.Name = "btPlugins";
            this.btPlugins.Size = new System.Drawing.Size(182, 23);
            this.btPlugins.TabIndex = 32;
            this.btPlugins.Text = "Plugins";
            this.btPlugins.UseVisualStyleBackColor = true;
            this.btPlugins.Click += new System.EventHandler(this.btPlugins_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(751, 484);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "NPC\'s";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btSend);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbSpeakThrough);
            this.groupBox1.Controls.Add(this.btRefreshNpcs);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Controls.Add(this.tbNpcName);
            this.groupBox1.Controls.Add(this.btDisconnectNpc);
            this.groupBox1.Controls.Add(this.btAddNpc);
            this.groupBox1.Controls.Add(this.listNpcs);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 472);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NPC\'s";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(528, 25);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(122, 22);
            this.tbPassword.TabIndex = 14;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(451, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "Password:";
            // 
            // btSend
            // 
            this.btSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSend.Location = new System.Drawing.Point(656, 443);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 11;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 447);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "Speak through";
            // 
            // tbSpeakThrough
            // 
            this.tbSpeakThrough.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSpeakThrough.Location = new System.Drawing.Point(110, 444);
            this.tbSpeakThrough.Name = "tbSpeakThrough";
            this.tbSpeakThrough.Size = new System.Drawing.Size(540, 22);
            this.tbSpeakThrough.TabIndex = 9;
            this.tbSpeakThrough.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSpeakThrough_KeyDown);
            this.tbSpeakThrough.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSpeakThrough_KeyUp);
            // 
            // btRefreshNpcs
            // 
            this.btRefreshNpcs.Location = new System.Drawing.Point(6, 24);
            this.btRefreshNpcs.Name = "btRefreshNpcs";
            this.btRefreshNpcs.Size = new System.Drawing.Size(98, 23);
            this.btRefreshNpcs.TabIndex = 8;
            this.btRefreshNpcs.Text = "Refresh";
            this.btRefreshNpcs.UseVisualStyleBackColor = true;
            this.btRefreshNpcs.Click += new System.EventHandler(this.btRefreshNpcs_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(261, 27);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(45, 16);
            this.lbName.TabIndex = 7;
            this.lbName.Text = "Name";
            // 
            // tbNpcName
            // 
            this.tbNpcName.Location = new System.Drawing.Point(312, 25);
            this.tbNpcName.Name = "tbNpcName";
            this.tbNpcName.Size = new System.Drawing.Size(133, 22);
            this.tbNpcName.TabIndex = 6;
            // 
            // btDisconnectNpc
            // 
            this.btDisconnectNpc.Location = new System.Drawing.Point(110, 24);
            this.btDisconnectNpc.Name = "btDisconnectNpc";
            this.btDisconnectNpc.Size = new System.Drawing.Size(145, 23);
            this.btDisconnectNpc.TabIndex = 5;
            this.btDisconnectNpc.Text = "Disconnect selected";
            this.btDisconnectNpc.UseVisualStyleBackColor = true;
            this.btDisconnectNpc.Click += new System.EventHandler(this.btDisconnectNpc_Click);
            // 
            // btAddNpc
            // 
            this.btAddNpc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddNpc.Location = new System.Drawing.Point(656, 24);
            this.btAddNpc.Name = "btAddNpc";
            this.btAddNpc.Size = new System.Drawing.Size(75, 23);
            this.btAddNpc.TabIndex = 4;
            this.btAddNpc.Text = "Add";
            this.btAddNpc.UseVisualStyleBackColor = true;
            this.btAddNpc.Click += new System.EventHandler(this.btAddNpc_Click);
            // 
            // listNpcs
            // 
            this.listNpcs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listNpcs.FormattingEnabled = true;
            this.listNpcs.ItemHeight = 16;
            this.listNpcs.Location = new System.Drawing.Point(6, 53);
            this.listNpcs.Name = "listNpcs";
            this.listNpcs.Size = new System.Drawing.Size(725, 388);
            this.listNpcs.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.lblStatusBar,
            this.toolStripStatusLabel1,
            this.lblServerStatus,
            this.lblTunnelStatus,
            this.lblTimeStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(759, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 20);
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(0, 21);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(512, 21);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(10, 21);
            this.lblServerStatus.Text = ".";
            // 
            // lblTunnelStatus
            // 
            this.lblTunnelStatus.Name = "lblTunnelStatus";
            this.lblTunnelStatus.Size = new System.Drawing.Size(10, 21);
            this.lblTunnelStatus.Text = ".";
            // 
            // lblTimeStatus
            // 
            this.lblTimeStatus.Name = "lblTimeStatus";
            this.lblTimeStatus.Size = new System.Drawing.Size(10, 21);
            this.lblTimeStatus.Text = ".";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.modifyToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(759, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator4,
            this.toggleTunnelToolStripMenuItem,
            this.toolStripSeparator1,
            this.downloadServerToolStripMenuItem,
            this.toolStripSeparator3,
            this.quitToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.startToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(287, 6);
            // 
            // toggleTunnelToolStripMenuItem
            // 
            this.toggleTunnelToolStripMenuItem.Name = "toggleTunnelToolStripMenuItem";
            this.toggleTunnelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.toggleTunnelToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.toggleTunnelToolStripMenuItem.Text = "Toggle Tunnel";
            this.toggleTunnelToolStripMenuItem.Click += new System.EventHandler(this.toggleTunnelToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(287, 6);
            // 
            // downloadServerToolStripMenuItem
            // 
            this.downloadServerToolStripMenuItem.Name = "downloadServerToolStripMenuItem";
            this.downloadServerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.downloadServerToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.downloadServerToolStripMenuItem.Text = "Download Server";
            this.downloadServerToolStripMenuItem.Click += new System.EventHandler(this.downloadServerToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(287, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.modifyToolStripMenuItem.Text = "Settings";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.configToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdatesToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for &Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(215, 22);
            this.helpToolStripMenuItem1.Text = "&Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // saveDownload
            // 
            this.saveDownload.FileName = "minecraft_server.jar";
            this.saveDownload.Filter = "Java jar files|*.jar";
            // 
            // updateController
            // 
            this.updateController.applicationLocation = "";
            this.updateController.authenticationMode = updateSystemDotNet.authenticationModes.Credentials;
            this.updateController.authenticationPassword = "hldC0Xra";
            this.updateController.authenticationUsername = "zma";
            this.updateController.projectId = "432818bd-bf54-4e43-b1c6-afee97713f8e";
            this.updateController.proxyPassword = null;
            this.updateController.proxyUrl = null;
            this.updateController.proxyUsername = null;
            this.updateController.publicKey = resources.GetString("updateController.publicKey");
            this.updateController.releaseFilter.checkForAlpha = false;
            this.updateController.releaseFilter.checkForBeta = false;
            this.updateController.releaseFilter.checkForFinal = true;
            this.updateController.releaseInfo.Version = "";
            this.updateController.requestElevation = true;
            this.updateController.restartApplication = true;
            this.updateController.updateUrl = "http://www.zicore.de/zma2/";
            this.updateController.updateInstallerStarted += new updateSystemDotNet.updateInstallerStartedEventHandler(this.updateController_updateInstallerStarted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 562);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabNpcs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(750, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Zicore\'s Minecraft Admintool - © 2010-2011";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabNpcs.ResumeLayout(false);
            this.tabInOutput.ResumeLayout(false);
            this.groupInputOutput.ResumeLayout(false);
            this.groupInputOutput.PerformLayout();
            this.tabTunnel.ResumeLayout(false);
            this.groupTesting.ResumeLayout(false);
            this.groupTesting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericExternalPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInternalPort)).EndInit();
            this.tabRestartBackup.ResumeLayout(false);
            this.groupBackup.ResumeLayout(false);
            this.groupBackup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTasks)).EndInit();
            this.tabPlugins.ResumeLayout(false);
            this.groupPlugins.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupInputOutput;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.TabControl tabNpcs;
        private System.Windows.Forms.CheckBox chkScroll;
        private System.Windows.Forms.TabPage tabRestartBackup;
        private System.Windows.Forms.GroupBox groupBackup;
        private System.Windows.Forms.TabPage tabTunnel;
        private System.Windows.Forms.GroupBox groupTesting;
        private System.Windows.Forms.CheckBox chkTunnelActive;
        private System.Windows.Forms.RichTextBox rtbServerClient;
        private System.Windows.Forms.NumericUpDown numericExternalPort;
        private System.Windows.Forms.NumericUpDown numericInternalPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkChatScroll;
        private System.Windows.Forms.Label label5;
        private updateSystemDotNet.updateController updateController;
        private System.Windows.Forms.Timer timerUpdates;
        private System.Windows.Forms.Timer timerMessages;
        private System.Windows.Forms.Timer dayTimeTimer;
        private System.Windows.Forms.TabPage tabPlugins;
        private System.Windows.Forms.GroupBox groupPlugins;
        private System.Windows.Forms.Button btPlugins;
        private System.Windows.Forms.ListBox listLoadedPlugins;
        private System.Windows.Forms.Button btReloadPlugins;
        private System.Windows.Forms.Button btActivateAll;
        private System.Windows.Forms.Button btDeactivateAll;
        private System.Windows.Forms.Button btUnloadAllPlugins;
        private System.Windows.Forms.Timer timerCurrency;
        private System.Windows.Forms.Timer timerTicker;
        private System.Windows.Forms.Button btConfigPlugin;
        private System.Windows.Forms.TabPage tabInOutput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem downloadServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.SaveFileDialog saveDownload;
        private System.Windows.Forms.ToolStripStatusLabel lblTimeStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblServerStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblTunnelStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toggleTunnelToolStripMenuItem;
        private System.Windows.Forms.TextBox tbChatTunnel;
        private System.Windows.Forms.Label lbQuickhelp;
        private System.Windows.Forms.DataGridView dataGridTasks;
        private System.Windows.Forms.Button btAddTask;
        private System.Windows.Forms.CheckBox chkRepeatTask;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericHours;
        private System.Windows.Forms.NumericUpDown numericSeconds;
        private System.Windows.Forms.NumericUpDown numericMinutes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTaskName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btRemoveTask;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.Button btClearTasks;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listNpcs;
        private System.Windows.Forms.Button btAddNpc;
        private System.Windows.Forms.Button btDisconnectNpc;
        private System.Windows.Forms.TextBox tbNpcName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btRefreshNpcs;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbSpeakThrough;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox tbPassword;
    }
}