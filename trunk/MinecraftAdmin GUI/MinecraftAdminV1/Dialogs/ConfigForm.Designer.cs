namespace Zicore.MinecraftAdmin
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.btOK = new System.Windows.Forms.Button();
            this.tabConfig = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkUsingAlternateGive = new System.Windows.Forms.CheckBox();
            this.chkAutomatedStartServer = new System.Windows.Forms.CheckBox();
            this.chkChannelBasedChat = new System.Windows.Forms.CheckBox();
            this.chkWhitelist = new System.Windows.Forms.CheckBox();
            this.chkForceSaveAndExit = new System.Windows.Forms.CheckBox();
            this.chkCommandResponse = new System.Windows.Forms.CheckBox();
            this.chkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.chkForwardUnkown = new System.Windows.Forms.CheckBox();
            this.chkSendUnkownCommand = new System.Windows.Forms.CheckBox();
            this.btSetBackupPath = new System.Windows.Forms.Button();
            this.btSetJavaPath = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.tbBackupFolder = new System.Windows.Forms.TextBox();
            this.chkStreamToServerlist = new System.Windows.Forms.CheckBox();
            this.lbServerName = new System.Windows.Forms.Label();
            this.tbServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericGiveLimit = new System.Windows.Forms.NumericUpDown();
            this.tbChatDateTimeFormatString = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCommandChar = new System.Windows.Forms.TextBox();
            this.tbWhitelistFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMinecraftExecutable = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbStartparamters = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbJavaPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btGenerateGuid = new System.Windows.Forms.Button();
            this.lbGuid = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.comboSecondChatLine = new System.Windows.Forms.ComboBox();
            this.comboFirstChatLine = new System.Windows.Forms.ComboBox();
            this.comboBoxPrivateMessageColor = new System.Windows.Forms.ComboBox();
            this.comboBoxServerMessageColor = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbResponsePrefix = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRules = new System.Windows.Forms.TextBox();
            this.tbMODT = new System.Windows.Forms.TextBox();
            this.tabCurrency = new System.Windows.Forms.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.numInitialAmount = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.tbCycleMessage = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbCurrencySymbol = new System.Windows.Forms.TextBox();
            this.chkCurrencyEnabled = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.numericMoneyAmount = new System.Windows.Forms.NumericUpDown();
            this.numericMoneyCycle = new System.Windows.Forms.NumericUpDown();
            this.tabWebinterface = new System.Windows.Forms.TabPage();
            this.numDatabasePort = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.tbDatabaseHost = new System.Windows.Forms.TextBox();
            this.btTestConnection = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.tbDatabasePassword = new System.Windows.Forms.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbDatabaseUser = new System.Windows.Forms.TextBox();
            this.btCreateTable = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tbWorldFolder = new System.Windows.Forms.TextBox();
            this.btSelectWorldPath = new System.Windows.Forms.Button();
            this.tabConfig.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGiveLimit)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabCurrency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMoneyAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMoneyCycle)).BeginInit();
            this.tabWebinterface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDatabasePort)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Location = new System.Drawing.Point(14, 530);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(648, 23);
            this.btOK.TabIndex = 8;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // tabConfig
            // 
            this.tabConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabConfig.Controls.Add(this.tabPage1);
            this.tabConfig.Controls.Add(this.tabPage2);
            this.tabConfig.Controls.Add(this.tabCurrency);
            this.tabConfig.Controls.Add(this.tabWebinterface);
            this.tabConfig.Location = new System.Drawing.Point(1, 1);
            this.tabConfig.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.SelectedIndex = 0;
            this.tabConfig.Size = new System.Drawing.Size(661, 520);
            this.tabConfig.TabIndex = 39;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btSelectWorldPath);
            this.tabPage1.Controls.Add(this.tbWorldFolder);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.btSetBackupPath);
            this.tabPage1.Controls.Add(this.btSetJavaPath);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.tbBackupFolder);
            this.tabPage1.Controls.Add(this.chkStreamToServerlist);
            this.tabPage1.Controls.Add(this.lbServerName);
            this.tabPage1.Controls.Add(this.tbServerName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.numericGiveLimit);
            this.tabPage1.Controls.Add(this.tbChatDateTimeFormatString);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.tbCommandChar);
            this.tabPage1.Controls.Add(this.tbWhitelistFile);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbMinecraftExecutable);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.tbStartparamters);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tbJavaPath);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(653, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.chkUsingAlternateGive);
            this.panel1.Controls.Add(this.chkAutomatedStartServer);
            this.panel1.Controls.Add(this.chkChannelBasedChat);
            this.panel1.Controls.Add(this.chkWhitelist);
            this.panel1.Controls.Add(this.chkForceSaveAndExit);
            this.panel1.Controls.Add(this.chkCommandResponse);
            this.panel1.Controls.Add(this.chkAutoUpdate);
            this.panel1.Controls.Add(this.chkForwardUnkown);
            this.panel1.Controls.Add(this.chkSendUnkownCommand);
            this.panel1.Location = new System.Drawing.Point(9, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 213);
            this.panel1.TabIndex = 58;
            // 
            // chkUsingAlternateGive
            // 
            this.chkUsingAlternateGive.AutoSize = true;
            this.chkUsingAlternateGive.Location = new System.Drawing.Point(3, 190);
            this.chkUsingAlternateGive.Name = "chkUsingAlternateGive";
            this.chkUsingAlternateGive.Size = new System.Drawing.Size(178, 17);
            this.chkUsingAlternateGive.TabIndex = 58;
            this.chkUsingAlternateGive.Text = "Use alternatetive give command";
            this.chkUsingAlternateGive.UseVisualStyleBackColor = true;
            this.chkUsingAlternateGive.CheckedChanged += new System.EventHandler(this.chkUsingBukkit_CheckedChanged);
            // 
            // chkAutomatedStartServer
            // 
            this.chkAutomatedStartServer.AutoSize = true;
            this.chkAutomatedStartServer.Location = new System.Drawing.Point(3, 3);
            this.chkAutomatedStartServer.Name = "chkAutomatedStartServer";
            this.chkAutomatedStartServer.Size = new System.Drawing.Size(134, 17);
            this.chkAutomatedStartServer.TabIndex = 21;
            this.chkAutomatedStartServer.Text = "Automated Server start";
            this.chkAutomatedStartServer.UseVisualStyleBackColor = true;
            this.chkAutomatedStartServer.CheckedChanged += new System.EventHandler(this.chkAutomatedStartServer_CheckedChanged);
            // 
            // chkChannelBasedChat
            // 
            this.chkChannelBasedChat.AutoSize = true;
            this.chkChannelBasedChat.Checked = true;
            this.chkChannelBasedChat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChannelBasedChat.Location = new System.Drawing.Point(3, 167);
            this.chkChannelBasedChat.Name = "chkChannelBasedChat";
            this.chkChannelBasedChat.Size = new System.Drawing.Size(251, 17);
            this.chkChannelBasedChat.TabIndex = 57;
            this.chkChannelBasedChat.Text = "Channel based chat (use !join !leave and !cinfo)";
            this.chkChannelBasedChat.UseVisualStyleBackColor = true;
            this.chkChannelBasedChat.CheckedChanged += new System.EventHandler(this.chkChannelBasedChat_CheckedChanged);
            // 
            // chkWhitelist
            // 
            this.chkWhitelist.AutoSize = true;
            this.chkWhitelist.Location = new System.Drawing.Point(3, 52);
            this.chkWhitelist.Name = "chkWhitelist";
            this.chkWhitelist.Size = new System.Drawing.Size(96, 17);
            this.chkWhitelist.TabIndex = 7;
            this.chkWhitelist.Text = "Whitelist Mode";
            this.chkWhitelist.UseVisualStyleBackColor = true;
            this.chkWhitelist.CheckedChanged += new System.EventHandler(this.chkWhitelist_CheckedChanged);
            // 
            // chkForceSaveAndExit
            // 
            this.chkForceSaveAndExit.AutoSize = true;
            this.chkForceSaveAndExit.Location = new System.Drawing.Point(3, 75);
            this.chkForceSaveAndExit.Name = "chkForceSaveAndExit";
            this.chkForceSaveAndExit.Size = new System.Drawing.Size(274, 17);
            this.chkForceSaveAndExit.TabIndex = 20;
            this.chkForceSaveAndExit.Text = "Force Save and Exit (avoids MessageBox at closing)";
            this.chkForceSaveAndExit.UseVisualStyleBackColor = true;
            this.chkForceSaveAndExit.CheckedChanged += new System.EventHandler(this.chkForceSaveAndExit_CheckedChanged);
            // 
            // chkCommandResponse
            // 
            this.chkCommandResponse.AutoSize = true;
            this.chkCommandResponse.Location = new System.Drawing.Point(3, 98);
            this.chkCommandResponse.Name = "chkCommandResponse";
            this.chkCommandResponse.Size = new System.Drawing.Size(356, 17);
            this.chkCommandResponse.TabIndex = 22;
            this.chkCommandResponse.Text = "Command Response (gives response when a command got executed)";
            this.chkCommandResponse.UseVisualStyleBackColor = true;
            this.chkCommandResponse.CheckedChanged += new System.EventHandler(this.chkCommandResponse_CheckedChanged);
            // 
            // chkAutoUpdate
            // 
            this.chkAutoUpdate.AutoSize = true;
            this.chkAutoUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoUpdate.Location = new System.Drawing.Point(3, 29);
            this.chkAutoUpdate.Name = "chkAutoUpdate";
            this.chkAutoUpdate.Size = new System.Drawing.Size(137, 17);
            this.chkAutoUpdate.TabIndex = 38;
            this.chkAutoUpdate.Text = "Automated Updates";
            this.chkAutoUpdate.UseVisualStyleBackColor = true;
            this.chkAutoUpdate.CheckedChanged += new System.EventHandler(this.chkAutoUpdate_CheckedChanged);
            // 
            // chkForwardUnkown
            // 
            this.chkForwardUnkown.AutoSize = true;
            this.chkForwardUnkown.Location = new System.Drawing.Point(3, 121);
            this.chkForwardUnkown.Name = "chkForwardUnkown";
            this.chkForwardUnkown.Size = new System.Drawing.Size(161, 17);
            this.chkForwardUnkown.TabIndex = 51;
            this.chkForwardUnkown.Text = "Forward Unkown commands";
            this.chkForwardUnkown.UseVisualStyleBackColor = true;
            this.chkForwardUnkown.CheckedChanged += new System.EventHandler(this.chkForwardUnkown_CheckedChanged);
            // 
            // chkSendUnkownCommand
            // 
            this.chkSendUnkownCommand.AutoSize = true;
            this.chkSendUnkownCommand.Location = new System.Drawing.Point(3, 144);
            this.chkSendUnkownCommand.Name = "chkSendUnkownCommand";
            this.chkSendUnkownCommand.Size = new System.Drawing.Size(232, 17);
            this.chkSendUnkownCommand.TabIndex = 52;
            this.chkSendUnkownCommand.Text = "Send unkown command response to clients";
            this.chkSendUnkownCommand.UseVisualStyleBackColor = true;
            this.chkSendUnkownCommand.CheckedChanged += new System.EventHandler(this.chkSendUnkownCommand_CheckedChanged);
            // 
            // btSetBackupPath
            // 
            this.btSetBackupPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSetBackupPath.Location = new System.Drawing.Point(423, 137);
            this.btSetBackupPath.Name = "btSetBackupPath";
            this.btSetBackupPath.Size = new System.Drawing.Size(32, 23);
            this.btSetBackupPath.TabIndex = 56;
            this.btSetBackupPath.Text = "...";
            this.btSetBackupPath.UseVisualStyleBackColor = true;
            this.btSetBackupPath.Click += new System.EventHandler(this.btSetBackupPath_Click);
            // 
            // btSetJavaPath
            // 
            this.btSetJavaPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSetJavaPath.Location = new System.Drawing.Point(422, 31);
            this.btSetJavaPath.Name = "btSetJavaPath";
            this.btSetJavaPath.Size = new System.Drawing.Size(32, 23);
            this.btSetJavaPath.TabIndex = 55;
            this.btSetJavaPath.Text = "...";
            this.btSetJavaPath.UseVisualStyleBackColor = true;
            this.btSetJavaPath.Click += new System.EventHandler(this.btSetJavaPath_Click);
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(461, 142);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(73, 13);
            this.label26.TabIndex = 50;
            this.label26.Text = "Backup folder";
            // 
            // tbBackupFolder
            // 
            this.tbBackupFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBackupFolder.Location = new System.Drawing.Point(9, 139);
            this.tbBackupFolder.Name = "tbBackupFolder";
            this.tbBackupFolder.Size = new System.Drawing.Size(407, 20);
            this.tbBackupFolder.TabIndex = 49;
            this.tbBackupFolder.TextChanged += new System.EventHandler(this.tbBackupFolder_TextChanged);
            this.tbBackupFolder.DoubleClick += new System.EventHandler(this.tbBackupFolder_DoubleClick);
            // 
            // chkStreamToServerlist
            // 
            this.chkStreamToServerlist.AutoSize = true;
            this.chkStreamToServerlist.Location = new System.Drawing.Point(464, 471);
            this.chkStreamToServerlist.Name = "chkStreamToServerlist";
            this.chkStreamToServerlist.Size = new System.Drawing.Size(105, 17);
            this.chkStreamToServerlist.TabIndex = 54;
            this.chkStreamToServerlist.Text = "Serverlist Stream";
            this.chkStreamToServerlist.UseVisualStyleBackColor = true;
            this.chkStreamToServerlist.Visible = false;
            this.chkStreamToServerlist.CheckedChanged += new System.EventHandler(this.chkStreamToServerlist_CheckedChanged);
            // 
            // lbServerName
            // 
            this.lbServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbServerName.AutoSize = true;
            this.lbServerName.Location = new System.Drawing.Point(458, 11);
            this.lbServerName.Name = "lbServerName";
            this.lbServerName.Size = new System.Drawing.Size(69, 13);
            this.lbServerName.TabIndex = 48;
            this.lbServerName.Text = "Server Name";
            // 
            // tbServerName
            // 
            this.tbServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServerName.Location = new System.Drawing.Point(9, 8);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.Size = new System.Drawing.Size(445, 20);
            this.tbServerName.TabIndex = 47;
            this.tbServerName.Text = "\r\nZMA powered Minecraft Server";
            this.tbServerName.TextChanged += new System.EventHandler(this.tbServerName_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Give Limit";
            // 
            // numericGiveLimit
            // 
            this.numericGiveLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numericGiveLimit.Location = new System.Drawing.Point(9, 249);
            this.numericGiveLimit.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericGiveLimit.Name = "numericGiveLimit";
            this.numericGiveLimit.Size = new System.Drawing.Size(445, 20);
            this.numericGiveLimit.TabIndex = 45;
            this.numericGiveLimit.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericGiveLimit.ValueChanged += new System.EventHandler(this.numericGiveLimit_ValueChanged);
            // 
            // tbChatDateTimeFormatString
            // 
            this.tbChatDateTimeFormatString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbChatDateTimeFormatString.Location = new System.Drawing.Point(9, 191);
            this.tbChatDateTimeFormatString.Name = "tbChatDateTimeFormatString";
            this.tbChatDateTimeFormatString.Size = new System.Drawing.Size(445, 20);
            this.tbChatDateTimeFormatString.TabIndex = 18;
            this.tbChatDateTimeFormatString.Text = "yyyy-MM-dd HH:mm:ss";
            this.tbChatDateTimeFormatString.TextChanged += new System.EventHandler(this.tbChatDateTimeFormatString_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "(commands will begin with it like !who)";
            // 
            // tbCommandChar
            // 
            this.tbCommandChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCommandChar.Location = new System.Drawing.Point(9, 218);
            this.tbCommandChar.MaxLength = 1;
            this.tbCommandChar.Name = "tbCommandChar";
            this.tbCommandChar.Size = new System.Drawing.Size(27, 26);
            this.tbCommandChar.TabIndex = 5;
            this.tbCommandChar.Text = "!";
            this.tbCommandChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCommandChar.TextChanged += new System.EventHandler(this.tbCommandChar_TextChanged);
            // 
            // tbWhitelistFile
            // 
            this.tbWhitelistFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWhitelistFile.Location = new System.Drawing.Point(9, 165);
            this.tbWhitelistFile.Name = "tbWhitelistFile";
            this.tbWhitelistFile.Size = new System.Drawing.Size(445, 20);
            this.tbWhitelistFile.TabIndex = 6;
            this.tbWhitelistFile.Text = "whitelist.txt";
            this.tbWhitelistFile.TextChanged += new System.EventHandler(this.tbWhitelistFile_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Startparameters";
            // 
            // tbMinecraftExecutable
            // 
            this.tbMinecraftExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMinecraftExecutable.Location = new System.Drawing.Point(9, 86);
            this.tbMinecraftExecutable.Name = "tbMinecraftExecutable";
            this.tbMinecraftExecutable.Size = new System.Drawing.Size(443, 20);
            this.tbMinecraftExecutable.TabIndex = 4;
            this.tbMinecraftExecutable.Text = "minecraft_server.jar";
            this.tbMinecraftExecutable.TextChanged += new System.EventHandler(this.tbMinecraftExecutable_TextChanged);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(461, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "World path (for backups)";
            // 
            // tbStartparamters
            // 
            this.tbStartparamters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStartparamters.Location = new System.Drawing.Point(9, 60);
            this.tbStartparamters.Name = "tbStartparamters";
            this.tbStartparamters.Size = new System.Drawing.Size(445, 20);
            this.tbStartparamters.TabIndex = 3;
            this.tbStartparamters.Text = " -Xmx1024M -Xms1024M -jar";
            this.tbStartparamters.TextChanged += new System.EventHandler(this.tbStartparamters_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Java Path (double click the text box)";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(458, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Minecraft Jar";
            // 
            // tbJavaPath
            // 
            this.tbJavaPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbJavaPath.Location = new System.Drawing.Point(9, 34);
            this.tbJavaPath.Name = "tbJavaPath";
            this.tbJavaPath.Size = new System.Drawing.Size(407, 20);
            this.tbJavaPath.TabIndex = 2;
            this.tbJavaPath.Text = "C:\\Program Files (x86)\\Java\\jre6\\bin\\java.exe";
            this.tbJavaPath.TextChanged += new System.EventHandler(this.tbJavaPath_TextChanged);
            this.tbJavaPath.DoubleClick += new System.EventHandler(this.tbJavaPath_DoubleClick);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(458, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Whitelist File (no path)";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(458, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Command Char";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(460, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Chat DateTime Format String(chat log)";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.btGenerateGuid);
            this.tabPage2.Controls.Add(this.lbGuid);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.comboSecondChatLine);
            this.tabPage2.Controls.Add(this.comboFirstChatLine);
            this.tabPage2.Controls.Add(this.comboBoxPrivateMessageColor);
            this.tabPage2.Controls.Add(this.comboBoxServerMessageColor);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.tbResponsePrefix);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.tbRules);
            this.tabPage2.Controls.Add(this.tbMODT);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(653, 494);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MOTD, Rules and More";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 406);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(442, 26);
            this.label28.TabIndex = 59;
            this.label28.Text = "Info: If you have Stream to serverlist enabled and your server doesn\'t appear in " +
                "the server list\r\nPress new GUID.";
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(353, 377);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(124, 13);
            this.label27.TabIndex = 58;
            this.label27.Text = "Server Guid for Serverlist";
            // 
            // btGenerateGuid
            // 
            this.btGenerateGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGenerateGuid.Location = new System.Drawing.Point(483, 372);
            this.btGenerateGuid.Name = "btGenerateGuid";
            this.btGenerateGuid.Size = new System.Drawing.Size(75, 23);
            this.btGenerateGuid.TabIndex = 57;
            this.btGenerateGuid.Text = "New GUID";
            this.btGenerateGuid.UseVisualStyleBackColor = true;
            this.btGenerateGuid.Click += new System.EventHandler(this.btGenerateGuid_Click);
            // 
            // lbGuid
            // 
            this.lbGuid.AutoSize = true;
            this.lbGuid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGuid.Location = new System.Drawing.Point(3, 379);
            this.lbGuid.Name = "lbGuid";
            this.lbGuid.Size = new System.Drawing.Size(11, 16);
            this.lbGuid.TabIndex = 56;
            this.lbGuid.Text = ".";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(140, 345);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(113, 13);
            this.label25.TabIndex = 55;
            this.label25.Text = "Second chat line color";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(140, 318);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(95, 13);
            this.label24.TabIndex = 54;
            this.label24.Text = "First chat line color";
            // 
            // comboSecondChatLine
            // 
            this.comboSecondChatLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSecondChatLine.FormattingEnabled = true;
            this.comboSecondChatLine.Location = new System.Drawing.Point(6, 342);
            this.comboSecondChatLine.Name = "comboSecondChatLine";
            this.comboSecondChatLine.Size = new System.Drawing.Size(121, 21);
            this.comboSecondChatLine.TabIndex = 53;
            this.comboSecondChatLine.SelectedIndexChanged += new System.EventHandler(this.comboSecondChatLine_SelectedIndexChanged);
            // 
            // comboFirstChatLine
            // 
            this.comboFirstChatLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFirstChatLine.FormattingEnabled = true;
            this.comboFirstChatLine.Location = new System.Drawing.Point(6, 315);
            this.comboFirstChatLine.Name = "comboFirstChatLine";
            this.comboFirstChatLine.Size = new System.Drawing.Size(121, 21);
            this.comboFirstChatLine.TabIndex = 52;
            this.comboFirstChatLine.SelectedIndexChanged += new System.EventHandler(this.comboFirstChatLine_SelectedIndexChanged);
            // 
            // comboBoxPrivateMessageColor
            // 
            this.comboBoxPrivateMessageColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrivateMessageColor.FormattingEnabled = true;
            this.comboBoxPrivateMessageColor.Location = new System.Drawing.Point(6, 244);
            this.comboBoxPrivateMessageColor.Name = "comboBoxPrivateMessageColor";
            this.comboBoxPrivateMessageColor.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPrivateMessageColor.TabIndex = 51;
            this.comboBoxPrivateMessageColor.SelectedIndexChanged += new System.EventHandler(this.comboBoxPrivateMessageColor_SelectedIndexChanged);
            // 
            // comboBoxServerMessageColor
            // 
            this.comboBoxServerMessageColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServerMessageColor.FormattingEnabled = true;
            this.comboBoxServerMessageColor.Location = new System.Drawing.Point(6, 276);
            this.comboBoxServerMessageColor.Name = "comboBoxServerMessageColor";
            this.comboBoxServerMessageColor.Size = new System.Drawing.Size(121, 21);
            this.comboBoxServerMessageColor.TabIndex = 50;
            this.comboBoxServerMessageColor.SelectedIndexChanged += new System.EventHandler(this.comboBoxServerMessageColor_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(140, 279);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(162, 13);
            this.label13.TabIndex = 49;
            this.label13.Text = "Server Broadcast Message Color";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(140, 247);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(162, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Response Server Message Color";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(564, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Response prefix";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 221);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(224, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "(such as Console: who successfully executed)";
            // 
            // tbResponsePrefix
            // 
            this.tbResponsePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResponsePrefix.Location = new System.Drawing.Point(6, 198);
            this.tbResponsePrefix.Name = "tbResponsePrefix";
            this.tbResponsePrefix.Size = new System.Drawing.Size(552, 20);
            this.tbResponsePrefix.TabIndex = 36;
            this.tbResponsePrefix.Text = "§cConsole:";
            this.tbResponsePrefix.TextChanged += new System.EventHandler(this.tbResponsePrefix_TextChanged);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(564, 179);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Rules";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(564, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "MOTD";
            // 
            // tbRules
            // 
            this.tbRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRules.Location = new System.Drawing.Point(6, 103);
            this.tbRules.Multiline = true;
            this.tbRules.Name = "tbRules";
            this.tbRules.Size = new System.Drawing.Size(552, 89);
            this.tbRules.TabIndex = 34;
            this.tbRules.Text = "Keep to the rules!:\r\nDon\'t grief anything\r\nTNT and Lava spam is strictly forbidde" +
                "n\r\nViolate the rules will result in kick/ban";
            this.tbRules.TextChanged += new System.EventHandler(this.tbRules_TextChanged);
            // 
            // tbMODT
            // 
            this.tbMODT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMODT.Location = new System.Drawing.Point(6, 6);
            this.tbMODT.Multiline = true;
            this.tbMODT.Name = "tbMODT";
            this.tbMODT.Size = new System.Drawing.Size(552, 91);
            this.tbMODT.TabIndex = 32;
            this.tbMODT.Text = "§fWelcome player §c{0}§f. Try §6!help§f and §6/help§f.\r\n§fRead and accept the §6!" +
                "rules§f.";
            this.tbMODT.TextChanged += new System.EventHandler(this.tbMODT_TextChanged);
            // 
            // tabCurrency
            // 
            this.tabCurrency.Controls.Add(this.label23);
            this.tabCurrency.Controls.Add(this.numInitialAmount);
            this.tabCurrency.Controls.Add(this.label19);
            this.tabCurrency.Controls.Add(this.tbCycleMessage);
            this.tabCurrency.Controls.Add(this.label18);
            this.tabCurrency.Controls.Add(this.tbCurrencySymbol);
            this.tabCurrency.Controls.Add(this.chkCurrencyEnabled);
            this.tabCurrency.Controls.Add(this.label16);
            this.tabCurrency.Controls.Add(this.label17);
            this.tabCurrency.Controls.Add(this.numericMoneyAmount);
            this.tabCurrency.Controls.Add(this.numericMoneyCycle);
            this.tabCurrency.Location = new System.Drawing.Point(4, 22);
            this.tabCurrency.Name = "tabCurrency";
            this.tabCurrency.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrency.Size = new System.Drawing.Size(653, 494);
            this.tabCurrency.TabIndex = 2;
            this.tabCurrency.Text = "Currency";
            this.tabCurrency.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(295, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 15);
            this.label23.TabIndex = 50;
            this.label23.Text = "Initial amount";
            // 
            // numInitialAmount
            // 
            this.numInitialAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numInitialAmount.Location = new System.Drawing.Point(9, 7);
            this.numInitialAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numInitialAmount.Name = "numInitialAmount";
            this.numInitialAmount.Size = new System.Drawing.Size(280, 20);
            this.numInitialAmount.TabIndex = 49;
            this.numInitialAmount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numInitialAmount.ValueChanged += new System.EventHandler(this.numInitialAmount_ValueChanged);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(295, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 13);
            this.label19.TabIndex = 48;
            this.label19.Text = "Cycle Message";
            // 
            // tbCycleMessage
            // 
            this.tbCycleMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCycleMessage.Location = new System.Drawing.Point(9, 111);
            this.tbCycleMessage.Name = "tbCycleMessage";
            this.tbCycleMessage.Size = new System.Drawing.Size(280, 20);
            this.tbCycleMessage.TabIndex = 47;
            this.tbCycleMessage.Text = "Time for cash $$$";
            this.tbCycleMessage.TextChanged += new System.EventHandler(this.tbCycleMessage_TextChanged);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(295, 88);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 13);
            this.label18.TabIndex = 46;
            this.label18.Text = "Currency Symbol";
            // 
            // tbCurrencySymbol
            // 
            this.tbCurrencySymbol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCurrencySymbol.Location = new System.Drawing.Point(9, 85);
            this.tbCurrencySymbol.Name = "tbCurrencySymbol";
            this.tbCurrencySymbol.Size = new System.Drawing.Size(280, 20);
            this.tbCurrencySymbol.TabIndex = 45;
            this.tbCurrencySymbol.Text = "$";
            this.tbCurrencySymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCurrencySymbol.TextChanged += new System.EventHandler(this.tbCurrencySymbol_TextChanged);
            // 
            // chkCurrencyEnabled
            // 
            this.chkCurrencyEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCurrencyEnabled.AutoSize = true;
            this.chkCurrencyEnabled.Checked = true;
            this.chkCurrencyEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCurrencyEnabled.Location = new System.Drawing.Point(509, 7);
            this.chkCurrencyEnabled.Name = "chkCurrencyEnabled";
            this.chkCurrencyEnabled.Size = new System.Drawing.Size(138, 17);
            this.chkCurrencyEnabled.TabIndex = 44;
            this.chkCurrencyEnabled.Text = "Currency Cycle enabled";
            this.chkCurrencyEnabled.UseVisualStyleBackColor = true;
            this.chkCurrencyEnabled.CheckedChanged += new System.EventHandler(this.chkCurrencyEnabled_CheckedChanged);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(295, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(155, 13);
            this.label16.TabIndex = 43;
            this.label16.Text = "Money Amount (amount in time)";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(295, 33);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(130, 15);
            this.label17.TabIndex = 42;
            this.label17.Text = "Money-cycle (minutes)";
            // 
            // numericMoneyAmount
            // 
            this.numericMoneyAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numericMoneyAmount.Location = new System.Drawing.Point(9, 59);
            this.numericMoneyAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericMoneyAmount.Name = "numericMoneyAmount";
            this.numericMoneyAmount.Size = new System.Drawing.Size(280, 20);
            this.numericMoneyAmount.TabIndex = 41;
            this.numericMoneyAmount.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericMoneyAmount.ValueChanged += new System.EventHandler(this.numericMoneyAmount_ValueChanged);
            // 
            // numericMoneyCycle
            // 
            this.numericMoneyCycle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numericMoneyCycle.Location = new System.Drawing.Point(9, 33);
            this.numericMoneyCycle.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericMoneyCycle.Name = "numericMoneyCycle";
            this.numericMoneyCycle.Size = new System.Drawing.Size(280, 20);
            this.numericMoneyCycle.TabIndex = 40;
            this.numericMoneyCycle.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericMoneyCycle.ValueChanged += new System.EventHandler(this.numericMoneyCycle_ValueChanged);
            // 
            // tabWebinterface
            // 
            this.tabWebinterface.Controls.Add(this.numDatabasePort);
            this.tabWebinterface.Controls.Add(this.label22);
            this.tabWebinterface.Controls.Add(this.tbDatabaseHost);
            this.tabWebinterface.Controls.Add(this.btTestConnection);
            this.tabWebinterface.Controls.Add(this.label21);
            this.tabWebinterface.Controls.Add(this.tbDatabasePassword);
            this.tabWebinterface.Controls.Add(this.label20);
            this.tabWebinterface.Controls.Add(this.tbDatabaseUser);
            this.tabWebinterface.Controls.Add(this.btCreateTable);
            this.tabWebinterface.Location = new System.Drawing.Point(4, 22);
            this.tabWebinterface.Name = "tabWebinterface";
            this.tabWebinterface.Padding = new System.Windows.Forms.Padding(3);
            this.tabWebinterface.Size = new System.Drawing.Size(653, 494);
            this.tabWebinterface.TabIndex = 3;
            this.tabWebinterface.Text = "Webinterface";
            this.tabWebinterface.UseVisualStyleBackColor = true;
            // 
            // numDatabasePort
            // 
            this.numDatabasePort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numDatabasePort.Location = new System.Drawing.Point(9, 32);
            this.numDatabasePort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numDatabasePort.Name = "numDatabasePort";
            this.numDatabasePort.Size = new System.Drawing.Size(341, 20);
            this.numDatabasePort.TabIndex = 8;
            this.numDatabasePort.Value = new decimal(new int[] {
            3306,
            0,
            0,
            0});
            this.numDatabasePort.ValueChanged += new System.EventHandler(this.numDatabasePort_ValueChanged);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(356, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 13);
            this.label22.TabIndex = 7;
            this.label22.Text = "Database Host";
            // 
            // tbDatabaseHost
            // 
            this.tbDatabaseHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDatabaseHost.Location = new System.Drawing.Point(9, 6);
            this.tbDatabaseHost.Name = "tbDatabaseHost";
            this.tbDatabaseHost.Size = new System.Drawing.Size(341, 20);
            this.tbDatabaseHost.TabIndex = 6;
            this.tbDatabaseHost.Text = "localhost";
            this.tbDatabaseHost.TextChanged += new System.EventHandler(this.tbDatabaseHost_TextChanged);
            // 
            // btTestConnection
            // 
            this.btTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btTestConnection.Location = new System.Drawing.Point(9, 126);
            this.btTestConnection.Name = "btTestConnection";
            this.btTestConnection.Size = new System.Drawing.Size(341, 23);
            this.btTestConnection.TabIndex = 5;
            this.btTestConnection.Text = "Test Connection";
            this.btTestConnection.UseVisualStyleBackColor = true;
            this.btTestConnection.Click += new System.EventHandler(this.btTestConnection_Click);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(356, 103);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(102, 13);
            this.label21.TabIndex = 4;
            this.label21.Text = "Database Password";
            // 
            // tbDatabasePassword
            // 
            this.tbDatabasePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDatabasePassword.Location = new System.Drawing.Point(9, 100);
            this.tbDatabasePassword.Name = "tbDatabasePassword";
            this.tbDatabasePassword.Size = new System.Drawing.Size(341, 20);
            this.tbDatabasePassword.TabIndex = 3;
            this.tbDatabasePassword.UseSystemPasswordChar = true;
            this.tbDatabasePassword.TextChanged += new System.EventHandler(this.tbDatabasePassword_TextChanged);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(356, 77);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Database User";
            // 
            // tbDatabaseUser
            // 
            this.tbDatabaseUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDatabaseUser.Location = new System.Drawing.Point(9, 74);
            this.tbDatabaseUser.Name = "tbDatabaseUser";
            this.tbDatabaseUser.Size = new System.Drawing.Size(341, 20);
            this.tbDatabaseUser.TabIndex = 1;
            this.tbDatabaseUser.Text = "root";
            this.tbDatabaseUser.TextChanged += new System.EventHandler(this.tbDatabaseUser_TextChanged);
            // 
            // btCreateTable
            // 
            this.btCreateTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreateTable.Location = new System.Drawing.Point(9, 155);
            this.btCreateTable.Name = "btCreateTable";
            this.btCreateTable.Size = new System.Drawing.Size(341, 23);
            this.btCreateTable.TabIndex = 0;
            this.btCreateTable.Text = "Create Tables";
            this.btCreateTable.UseVisualStyleBackColor = true;
            this.btCreateTable.Click += new System.EventHandler(this.btCreateTable_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "java.exe";
            this.openFileDialog.Filter = "All Files|*.*";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // tbWorldFolder
            // 
            this.tbWorldFolder.Location = new System.Drawing.Point(9, 112);
            this.tbWorldFolder.Name = "tbWorldFolder";
            this.tbWorldFolder.Size = new System.Drawing.Size(407, 20);
            this.tbWorldFolder.TabIndex = 59;
            this.tbWorldFolder.TextChanged += new System.EventHandler(this.tbWorldFolder_TextChanged);
            // 
            // btSelectWorldPath
            // 
            this.btSelectWorldPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSelectWorldPath.Location = new System.Drawing.Point(423, 110);
            this.btSelectWorldPath.Name = "btSelectWorldPath";
            this.btSelectWorldPath.Size = new System.Drawing.Size(32, 23);
            this.btSelectWorldPath.TabIndex = 60;
            this.btSelectWorldPath.Text = "...";
            this.btSelectWorldPath.UseVisualStyleBackColor = true;
            this.btSelectWorldPath.Click += new System.EventHandler(this.btSelectWorldPath_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 565);
            this.Controls.Add(this.tabConfig);
            this.Controls.Add(this.btOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(442, 462);
            this.Name = "ConfigForm";
            this.Text = "Zicore\'s Minecraft Admintool - Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.tabConfig.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGiveLimit)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabCurrency.ResumeLayout(false);
            this.tabCurrency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMoneyAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMoneyCycle)).EndInit();
            this.tabWebinterface.ResumeLayout(false);
            this.tabWebinterface.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDatabasePort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.TabControl tabConfig;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkAutoUpdate;
        private System.Windows.Forms.CheckBox chkCommandResponse;
        private System.Windows.Forms.CheckBox chkAutomatedStartServer;
        private System.Windows.Forms.CheckBox chkForceSaveAndExit;
        private System.Windows.Forms.TextBox tbChatDateTimeFormatString;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCommandChar;
        private System.Windows.Forms.TextBox tbWhitelistFile;
        private System.Windows.Forms.CheckBox chkWhitelist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMinecraftExecutable;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbStartparamters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbJavaPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRules;
        private System.Windows.Forms.TextBox tbMODT;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbResponsePrefix;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericGiveLimit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxPrivateMessageColor;
        private System.Windows.Forms.ComboBox comboBoxServerMessageColor;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage tabCurrency;
        private System.Windows.Forms.CheckBox chkCurrencyEnabled;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericMoneyAmount;
        private System.Windows.Forms.NumericUpDown numericMoneyCycle;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbCurrencySymbol;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbCycleMessage;
        private System.Windows.Forms.Label lbServerName;
        private System.Windows.Forms.TextBox tbServerName;
        private System.Windows.Forms.TabPage tabWebinterface;
        private System.Windows.Forms.Button btCreateTable;
        private System.Windows.Forms.NumericUpDown numDatabasePort;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbDatabaseHost;
        private System.Windows.Forms.Button btTestConnection;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.MaskedTextBox tbDatabasePassword;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbDatabaseUser;
        private System.Windows.Forms.NumericUpDown numInitialAmount;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox comboSecondChatLine;
        private System.Windows.Forms.ComboBox comboFirstChatLine;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tbBackupFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox chkSendUnkownCommand;
        private System.Windows.Forms.CheckBox chkForwardUnkown;
        private System.Windows.Forms.CheckBox chkStreamToServerlist;
        private System.Windows.Forms.Button btGenerateGuid;
        private System.Windows.Forms.Label lbGuid;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btSetJavaPath;
        private System.Windows.Forms.Button btSetBackupPath;
        private System.Windows.Forms.CheckBox chkChannelBasedChat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkUsingAlternateGive;
        private System.Windows.Forms.TextBox tbWorldFolder;
        private System.Windows.Forms.Button btSelectWorldPath;

    }
}