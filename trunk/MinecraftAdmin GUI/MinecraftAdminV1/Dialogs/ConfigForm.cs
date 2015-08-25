using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vitt.Andre.XML;
using System.IO;
using Vitt.Andre.Tunnel;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using MinecraftWrapper.Chat;
using Zicore.SQLUtils;
using MinecraftWrapper.WebInterface;
using System.Collections.ObjectModel;

namespace Zicore.MinecraftAdmin
{
    public partial class ConfigForm : Form
    {
        public ConfigForm(MinecraftHandler mc)
        {
            InitializeComponent();
            InitComboBoxes();
            this.Load += new EventHandler(ConfigForm_Load);
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            //comboBoxSelectedDevice.DataSource = interfaces;
            //comboBoxSelectedDevice.DisplayMember = "Name";
            
            this.mc = mc;
            this.numericGiveLimit.Value = mc.Config.GiveLimit;
            this.tbJavaPath.Text = mc.Config.Java;
            this.tbMODT.Lines = mc.Config.Modt;
            this.tbRules.Lines = mc.Config.Rules;
            this.tbStartparamters.Text = mc.Config.Startparameters;
            this.tbMinecraftExecutable.Text = mc.Config.Minecraft;
            this.tbWhitelistFile.Text = mc.Config.WhiteListFile;
            this.chkWhitelist.Checked = mc.Config.WhiteListMode;
            this.tbCommandChar.Text = mc.Config.CommandChar;
            this.chkAutomatedStartServer.Checked = mc.Config.AutomatedServerStart;
            this.chkForceSaveAndExit.Checked = mc.Config.ForceSaveAndExit;
            this.chkCommandResponse.Checked = mc.Config.CommandExecutedResponse;
            this.tbResponsePrefix.Text = mc.Config.ResponsePrefix;
            this.comboBoxPrivateMessageColor.SelectedValue = mc.Config.ResponseColorChar;
            this.comboBoxServerMessageColor.SelectedValue = mc.Config.ServerBroadcastColorChar;
            this.comboFirstChatLine.SelectedValue = mc.Config.LineFirstColorKey;
            this.comboSecondChatLine.SelectedValue = mc.Config.LineSecondColorKey;
            this.chkAutoUpdate.Checked = mc.Config.AutomatedUpdates;
            this.tbChatDateTimeFormatString.Text = mc.Config.ChatDateTimeFormat;

            this.chkCurrencyEnabled.Checked = mc.Config.CurrencySystemEnabled;
            this.numericMoneyAmount.Value = mc.Config.CurrencyAmountInCycle;
            this.numericMoneyCycle.Value = mc.Config.CurrencyCycleMinutes;
            this.tbCurrencySymbol.Text = mc.Config.CurrencySymbol;
            this.tbCycleMessage.Text = mc.Config.CurrencyCycleMessage;

            this.tbServerName.Text = mc.Config.ServerName;
            //this.chkStreamToServerlist.Checked = mc.Config.StreamEnabled;

            this.tbDatabaseHost.Text = mc.Config.DatabaseHost;
            this.numDatabasePort.Value = mc.Config.DatabasePort;
            this.tbDatabaseUser.Text = mc.Config.DatabaseUser;
            this.tbDatabasePassword.Text = mc.Config.DatabasePassword;
            this.numInitialAmount.Value = mc.Config.InitialCurrencyAmount;

            this.tbBackupFolder.Text = mc.Config.BackupFolder;
            this.chkForwardUnkown.Checked = mc.Config.ForwardUnkownCommands;
            this.chkSendUnkownCommand.Checked = mc.Config.SendUnkownCommandResponse;
            this.chkChannelBasedChat.Checked = mc.Config.ChannelModeChat;
            this.chkUsingAlternateGive.Checked = mc.Config.UsingAlternateGive;
            this.tbWorldFolder.Text = mc.Config.WorldPath;

            this.lbGuid.Text = mc.Config.GuidString;
        }

        private void CheckNetWorkDevice()
        {

        }

        private void InitComboBoxes()
        {
            ColorCollection colors = ColorCollection.GetInstance();
            comboBoxServerMessageColor.DisplayMember = "Name";
            comboBoxServerMessageColor.ValueMember = "Key";
            comboBoxServerMessageColor.DataSource = colors.GetBindingList();

            comboBoxPrivateMessageColor.DisplayMember = "Name";
            comboBoxPrivateMessageColor.ValueMember = "Key";
            comboBoxPrivateMessageColor.DataSource = colors.GetBindingList();

            comboFirstChatLine.DisplayMember = "Name";
            comboFirstChatLine.ValueMember = "Key";
            comboFirstChatLine.DataSource = colors.GetBindingList();

            comboSecondChatLine.DisplayMember = "Name";
            comboSecondChatLine.ValueMember = "Key";
            comboSecondChatLine.DataSource = colors.GetBindingList();
        }

        void ConfigForm_Load(object sender, EventArgs e)
        {
            //this.comboBoxSelectedIp.Text = mc.Config.ServerIp;
        }

        MinecraftHandler mc;

        private void numericGiveLimit_ValueChanged(object sender, EventArgs e)
        {
            mc.Config.GiveLimit = (int)numericGiveLimit.Value;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            //if (mc.Config.ServerIp == "127.0.0.1" || mc.Config.ServerIp == "localhost" )
            //{
            //    MessageBox.Show("ZMA has detected that you run ZMA with 127.0.0.1 (localhost)\nYou need to bind it to the router ip or the external ip if you don't have a router,\n"+
            //        "if you want that other people can join");
            //}

            mc.Config.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tbMODT_TextChanged(object sender, EventArgs e)
        {
            mc.Config.Modt = this.tbMODT.Lines;
        }

        private void tbJavaPath_TextChanged(object sender, EventArgs e)
        {
            mc.Config.Java = this.tbJavaPath.Text;
        }

        private void tbStartparamters_TextChanged(object sender, EventArgs e)
        {
            mc.Config.Startparameters = tbStartparamters.Text;
        }

        private void tbMinecraftExecutable_TextChanged(object sender, EventArgs e)
        {
            mc.Config.Minecraft = tbMinecraftExecutable.Text;
        }

        private void tbWhitelistFile_TextChanged(object sender, EventArgs e)
        {
            mc.Config.WhiteListFile = tbWhitelistFile.Text;
        }

        private void chkWhitelist_CheckedChanged(object sender, EventArgs e)
        {
            mc.Config.WhiteListMode = chkWhitelist.Checked;
        }

        private void tbCommandChar_TextChanged(object sender, EventArgs e)
        {
            mc.Config.CommandChar = tbCommandChar.Text;
        }

        private void chkForceSaveAndExit_CheckedChanged(object sender, EventArgs e)
        {
            mc.Config.ForceSaveAndExit = chkForceSaveAndExit.Checked;
        }

        private void chkAutomatedStartServer_CheckedChanged(object sender, EventArgs e)
        {
            mc.Config.AutomatedServerStart = chkAutomatedStartServer.Checked;
        }

        private void chkCommandResponse_CheckedChanged(object sender, EventArgs e)
        {
            mc.Config.CommandExecutedResponse = chkCommandResponse.Checked;
        }

        private void tbResponsePrefix_TextChanged(object sender, EventArgs e)
        {
            mc.Config.ResponsePrefix = tbResponsePrefix.Text;
        }

        private void tbRules_TextChanged(object sender, EventArgs e)
        {
            mc.Config.Rules = this.tbRules.Lines;
        }

        private void tbIP_TextChanged(object sender, EventArgs e)
        {
            //mc.Config.ServerIp = comboBoxSelectedDevice.Text;
        }

        /// <summary>
        /// Gets IP addresses of the local computer
        /// </summary>
        public Collection<String> GetLocalIPs()
        {
            Collection<String> list = new Collection<string>();

            // Resolves a host name or IP address to an IPHostEntry instance.
            // IPHostEntry - Provides a container class for Internet host address information. 
            System.Net.IPHostEntry _IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());

            // IPAddress class contains the address of a computer on an IP network. 
            foreach (System.Net.IPAddress _IPAddress in _IPHostEntry.AddressList)
            {
                // InterNetwork indicates that an IP version 4 address is expected 
                // when a Socket connects to an endpoint
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    if (_IPAddress.ToString().StartsWith("192."))
                    {
                        list.Add(_IPAddress.ToString());
                    }
                }
            }
            return list;
        }

        private void comboBoxSelectedDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    NetworkInterface adapter = comboBoxSelectedDevice.SelectedValue as NetworkInterface;
            //    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
            //    UnicastIPAddressInformationCollection uniCast = adapterProperties.UnicastAddresses;
            //    comboBoxSelectedIp.DataSource = new BindingSource(uniCast, null);
            //    comboBoxSelectedIp.DisplayMember = "Address";
            //}
            //catch
            //{
            //    //MessageBox.Show(ex.Message + "\nTry to manually type in you're LAN IP");
            //}
        }

        private void comboBoxSelectedIp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    mc.Config.ServerIp = comboBoxSelectedIp.Text;
            //}
            //catch { }
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    mc.Config.ServerIp = comboBoxSelectedIp.Text;
            //}
            //catch { }
        }

        private void chkAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            mc.Config.AutomatedUpdates = chkAutoUpdate.Checked;
        }

        private void comboBoxPrivateMessageColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.Config.ResponseColorChar = (char)comboBoxPrivateMessageColor.SelectedValue;
            }
            catch
            {
                
            }
        }

        private void comboBoxServerMessageColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.Config.ServerBroadcastColorChar = (char)comboBoxServerMessageColor.SelectedValue;
            }
            catch
            {
                
            }
        }

        private void tbChatDateTimeFormatString_TextChanged(object sender, EventArgs e)
        {
            mc.Config.ChatDateTimeFormat = tbChatDateTimeFormatString.Text;
        }

        private void tbJavaPath_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbJavaPath.Text = openFileDialog.FileName;
                mc.Config.Java = this.tbJavaPath.Text;
            }
        }

        private void tbCurrencySymbol_TextChanged(object sender, EventArgs e)
        {
            mc.Config.CurrencySymbol = tbCurrencySymbol.Text;
        }

        private void numericMoneyCycle_ValueChanged(object sender, EventArgs e)
        {
            mc.Config.CurrencyCycleMinutes = (int)numericMoneyCycle.Value;
        }

        private void numericMoneyAmount_ValueChanged(object sender, EventArgs e)
        {
            mc.Config.CurrencyAmountInCycle = (int)numericMoneyAmount.Value;
        }

        private void chkCurrencyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            mc.Config.CurrencySystemEnabled = chkCurrencyEnabled.Checked;
        }

        private void tbCycleMessage_TextChanged(object sender, EventArgs e)
        {
            mc.Config.CurrencyCycleMessage = tbCycleMessage.Text;
        }

        private void tbServerName_TextChanged(object sender, EventArgs e)
        {
            mc.Config.ServerName = tbServerName.Text;
        }

        private void chkStreamToServerlist_CheckedChanged(object sender, EventArgs e)
        {
            mc.Config.StreamEnabled = chkStreamToServerlist.Checked;
        }

        private void btTestConnection_Click(object sender, EventArgs e)
        {
            MySQLConnector con = MySQLConnector.GetInstance();
            if (con.Open(mc.Config.DatabaseHost, mc.Config.Database, mc.Config.DatabaseUser, mc.Config.DatabasePassword))
            {
                MessageBox.Show("Connection successfull");
            }
            else
            {
                MessageBox.Show("Connection failed");
            }
            con.Close();
        }

        private void tbDatabaseHost_TextChanged(object sender, EventArgs e)
        {
            mc.Config.DatabaseHost = tbDatabaseHost.Text;
        }

        private void numDatabasePort_ValueChanged(object sender, EventArgs e)
        {
            mc.Config.DatabasePort = (int)numDatabasePort.Value;
        }

        private void tbDatabaseUser_TextChanged(object sender, EventArgs e)
        {
            mc.Config.DatabaseUser = tbDatabaseUser.Text;
        }

        private void btCreateTable_Click(object sender, EventArgs e)
        {
            MySQLConnector con = MySQLConnector.GetInstance();
            bool connected = con.Open(mc.Config.DatabaseHost, mc.Config.Database, mc.Config.DatabaseUser,mc.Config.DatabasePassword);
            if (con.State == ConnectionState.Open)
            {
                try
                {
                    QueryResult result = con.TableExists(mc.Config.TableAdmin);
                    if (!result.HasError && !result.HasResult)
                    {
                        result = con.ExecuteSQL(String.Format(
                         " CREATE TABLE `{0}` ( " +
                         " `id` int(11) NOT NULL AUTO_INCREMENT, " +
                         " `name` varchar(100) DEFAULT NULL, " +
                         " `is_online` int(11) DEFAULT NULL, " +
                         " `seconds_online` int(11) DEFAULT NULL, " +
                         " `players_max` int(11) DEFAULT NULL, " +
                         " `players_online` int(11) DEFAULT NULL, " +
                         " `date_last_online` datetime DEFAULT NULL, " +
                         " `ip` varchar(100) DEFAULT NULL, " +
                         " `port` int(11) DEFAULT NULL, " +
                         " `guid` varchar(100) DEFAULT NULL, " +
                         " `country` varchar(150) DEFAULT NULL, " +
                         " `version` varchar(100) DEFAULT NULL, " +
                         " PRIMARY KEY (`id`) " +
                         " ) ENGINE=InnoDB AUTO_INCREMENT=435 DEFAULT CHARSET=latin1;"
                         ,
                         mc.Config.TableServer
                         ));
                        if (result.HasError)
                        {
                            MessageBox.Show(result.Exception.Message);
                        }
                        else
                        {
                            if (result.HasResult)
                            {
                                MessageBox.Show("Tables successfully created");
                            }
                        }
                    }
                    else
                    {
                        if (result.HasError)
                        {
                            MessageBox.Show(result.Exception.Message);
                        }
                        if (result.HasResult)
                        {
                            MessageBox.Show("Tables are allready created!");
                        }
                    }

                    //int result = con.Insert("web_admins", new String[] { "login", "password", "minecraft_name", "group_id" }, new Object[] { "Zic", "hldx", "Zicore", 0 });
                }
                catch
                {

                }

                Object[][] data = con.SelectDataSet("SELECT * FROM web_admins");
            }
        }

        private void tbDatabasePassword_TextChanged(object sender, EventArgs e)
        {
            mc.Config.DatabasePassword = tbDatabasePassword.Text;
        }

        private void numInitialAmount_ValueChanged(object sender, EventArgs e)
        {
            mc.Config.InitialCurrencyAmount = (int)numInitialAmount.Value;
        }

        private void comboFirstChatLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.Config.LineFirstColorKey = (char)comboFirstChatLine.SelectedValue;
            }
            catch
            {

            }
        }

        private void comboSecondChatLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.Config.LineSecondColorKey = (char)comboSecondChatLine.SelectedValue;
            }
            catch
            {

            }
        }

        private void tbBackupFolder_TextChanged(object sender, EventArgs e)
        {
            mc.Config.BackupFolder = tbBackupFolder.Text;
            try
            {
                folderBrowserDialog.SelectedPath = mc.Config.BackupFolder;
            }
            catch
            {

            }
        }

        private void tbBackupFolder_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    tbBackupFolder.Text = folderBrowserDialog.SelectedPath;
                    mc.Config.BackupFolder = tbBackupFolder.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkForwardUnkown_CheckedChanged(object sender, EventArgs e)
        {
            mc.Config.ForwardUnkownCommands = chkForwardUnkown.Checked;
        }

        private void chkSendUnkownCommand_CheckedChanged(object sender, EventArgs e)
        {
            mc.Config.SendUnkownCommandResponse = chkSendUnkownCommand.Checked;
        }

        private void btGetIp_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This will give you a list with IPv4 IP's select the right one :-)");
            //try
            //{
            //    comboBoxSelectedIp.DataSource = null;
            //    comboBoxSelectedIp.DataSource = GetLocalIPs();
            //}
            //catch
            //{

            //}
        }

        private void comboBoxSelectedIp_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    mc.Config.ServerIp = comboBoxSelectedIp.Text;
            //}
            //catch
            //{

            //}
        }

        private void btGenerateGuid_Click(object sender, EventArgs e)
        {
            mc.Config.GuidString = Guid.NewGuid().ToString();
            lbGuid.Text = mc.Config.GuidString;
        }

        private void btSetJavaPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbJavaPath.Text = openFileDialog.FileName;
                mc.Config.Java = this.tbJavaPath.Text;
            }
        }

        private void btSetBackupPath_Click(object sender, EventArgs e)
        {
            try
            {
                //folderBrowserDialog.Description = "set a folder for backups";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    tbBackupFolder.Text = folderBrowserDialog.SelectedPath;
                    mc.Config.BackupFolder = tbBackupFolder.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkChannelBasedChat_CheckedChanged(object sender, EventArgs e)
        {
            mc.Config.ChannelModeChat = this.chkChannelBasedChat.Checked;
        }

        private void chkUsingBukkit_CheckedChanged(object sender, EventArgs e)
        {
            mc.Config.UsingAlternateGive = this.chkUsingAlternateGive.Checked;
        }

        private void btSelectWorldPath_Click(object sender, EventArgs e)
        {
            try
            {
                //folderBrowserDialog.Description = "set a folder for backups";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    tbWorldFolder.Text = folderBrowserDialog.SelectedPath;
                    mc.Config.WorldPath = tbWorldFolder.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbWorldFolder_TextChanged(object sender, EventArgs e)
        {
            mc.Config.WorldPath = tbWorldFolder.Text;
            try
            {
                folderBrowserDialog.SelectedPath = mc.Config.WorldPath;
            }
            catch
            {

            }
        }
    }
}
