using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Vitt.Andre.XML;
using System.Drawing;
using System.Xml.Serialization;

namespace Zicore.MinecraftAdmin
{
    public class Config
    {
        public Config()
        {

        }

        Decimal taskHours = 0;

        public Decimal TaskHours
        {
            get { return taskHours; }
            set { taskHours = value; }
        }

        Decimal taskMinutes = 0;

        public Decimal TaskMinutes
        {
            get { return taskMinutes; }
            set { taskMinutes = value; }
        }

        Decimal taskSeconds = 0;

        public Decimal TaskSeconds
        {
            get { return taskSeconds; }
            set { taskSeconds = value; }
        }

        String worldPath = "";

        public String WorldPath
        {
            get { return worldPath; }
            set { worldPath = value; }
        }

        bool usingAlternateGive = false;

        public bool UsingAlternateGive
        {
            get { return usingAlternateGive; }
            set { usingAlternateGive = value; }
        }

        bool channelModeChat = true;

        public bool ChannelModeChat
        {
            get { return channelModeChat; }
            set { channelModeChat = value; }
        }

        bool sendModtToEveryone = false;

        public bool SendModtToEveryone
        {
            get { return sendModtToEveryone; }
            set { sendModtToEveryone = value; }
        }

        bool sendUnkownCommandResponse = true;

        public bool SendUnkownCommandResponse
        {
            get { return sendUnkownCommandResponse; }
            set { sendUnkownCommandResponse = value; }
        }

        bool forwardUnkownCommands = true;

        public bool ForwardUnkownCommands
        {
            get { return forwardUnkownCommands; }
            set { forwardUnkownCommands = value; }
        }

        String backupFolder = "";

        public String BackupFolder
        {
            get { return backupFolder; }
            set { backupFolder = value; }
        }

        int databasePort = 3306;

        public int DatabasePort
        {
            get { return databasePort; }
            set { databasePort = value; }
        }

        String databaseHost = "localhost";

        public String DatabaseHost
        {
            get { return databaseHost; }
            set { databaseHost = value; }
        }

        String databaseUser = "root";

        public String DatabaseUser
        {
            get { return databaseUser; }
            set { databaseUser = value; }
        }

        String databasePassword = "";

        public String DatabasePassword
        {
            get { return databasePassword; }
            set { databasePassword = value; }
        }

        String database = "";

        public String Database
        {
            get { return database; }
            set { database = value; }
        }

        String tableServer = "";

        public String TableServer
        {
            get { return tableServer; }
            set { tableServer = value; }
        }

        String tableAdmin = "";

        public String TableAdmin
        {
            get { return tableAdmin; }
            set { tableAdmin = value; }
        }

        Boolean streamEnabled = false;

        public Boolean StreamEnabled
        {
            get { return streamEnabled; }
            set { streamEnabled = value; }
        }

        String externalIp = "";

        public String ExternalIp
        {
            get { return externalIp; }
            set { externalIp = value; }
        }

        bool generateNewGuid = false;

        public bool GenerateNewGuid
        {
            get { return generateNewGuid; }
            set { generateNewGuid = value; }
        }

        String guid = Guid.NewGuid().ToString();

        public String GuidString
        {
            get { return guid; }
            set 
            {
                if (generateNewGuid)
                {
                    generateNewGuid = false;
                    guid = Guid.NewGuid().ToString();
                }
                else
                {
                    guid = value;
                }
            }
        }

        String serverName = "ZMA powered Minecraft Server";

        public String ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }

        int initialCurrencyAmount = 1000;

        public int InitialCurrencyAmount
        {
            get { return initialCurrencyAmount; }
            set { initialCurrencyAmount = value; }
        }

        String currencyCycleMessage = "Time for cash $$$";

        public String CurrencyCycleMessage
        {
            get { return currencyCycleMessage; }
            set { currencyCycleMessage = value; }
        }

        bool currencySystemEnabled = true;

        public bool CurrencySystemEnabled
        {
            get { return currencySystemEnabled; }
            set { currencySystemEnabled = value; }
        }

        int currencyAmountInCycle = 12;

        public int CurrencyAmountInCycle
        {
            get { return currencyAmountInCycle; }
            set { currencyAmountInCycle = value; }
        }

        int currencyCycleMinutes = 10;

        public int CurrencyCycleMinutes
        {
            get { return currencyCycleMinutes; }
            set { currencyCycleMinutes = value; }
        }

        string currencySymbol = "$";

        public string CurrencySymbol
        {
            get { return currencySymbol; }
            set { currencySymbol = value; }
        }

        bool backupOnly = true;

        public bool BackupOnly
        {
            get { return backupOnly; }
            set { backupOnly = value; }
        }

        bool restartOnly = false;

        public bool RestartOnly
        {
            get { return restartOnly; }
            set { restartOnly = value; }
        }

        bool restartAndBackup = false;

        public bool RestartAndBackup
        {
            get { return restartAndBackup; }
            set { restartAndBackup = value; }
        }

        char lineFirstColorKey = 'f';
        char lineSecondColorKey = '7';

        public char LineFirstColorKey
        {
            get { return lineFirstColorKey; }
            set { lineFirstColorKey = value; }
        }

        public char LineSecondColorKey
        {
            get { return lineSecondColorKey; }
            set { lineSecondColorKey = value; }
        }

        bool automatedUpdates = true;

        public bool AutomatedUpdates
        {
            get { return automatedUpdates; }
            set { automatedUpdates = value; }
        }

        bool automatedShutdown = false;

        public bool AutomatedShutdown
        {
            get { return automatedShutdown; }
            set { automatedShutdown = value; }
        }

        bool serverTunnelActive = false;

        public bool ServerTunnelActive
        {
            get { return serverTunnelActive; }
            set { serverTunnelActive = value; }
        }

        private string serverIp = "127.0.0.1";

        public string ServerIp
        {
            get { return serverIp; }
            set { serverIp = value; }
        }

        string responsePrefix = "§cConsole:";

        public string ResponsePrefix
        {
            get { return responsePrefix; }
            set { responsePrefix = value; }
        }

        char serverBroadcastColorChar = 'c';

        public char ServerBroadcastColorChar
        {
            get { return serverBroadcastColorChar; }
            set { serverBroadcastColorChar = value; }
        }

        char responseColorChar = 'c';

        public char ResponseColorChar
        {
            get { return responseColorChar; }
            set { responseColorChar = value; }
        }

        bool commandExecutedResponse = true;

        public bool CommandExecutedResponse
        {
            get { return commandExecutedResponse; }
            set { commandExecutedResponse = value; }
        }

        bool chatListScroll = false;

        public bool ChatListScroll
        {
            get { return chatListScroll; }
            set { chatListScroll = value; }
        }

        bool forceSaveAndExit = false;

        public bool ForceSaveAndExit
        {
            get { return forceSaveAndExit; }
            set { forceSaveAndExit = value; }
        }

        bool automatedStart = false;

        public bool AutomatedServerStart
        {
            get { return automatedStart; }
            set { automatedStart = value; }
        }

        int selectedTabIndex = 0;

        public int SelectedTabIndex
        {
            get { return selectedTabIndex; }
            set { selectedTabIndex = value; }
        }

        Point mainFormStartPosition = new Point(0, 0);

        public Point MainFormStartPosition
        {
            get { return mainFormStartPosition; }
            set
            {
                if (value.X > 1920 || value.Y > 1200 || value.X < 0 || value.Y < 0)
                {
                    this.mainFormStartPosition = new Point(0, 0);
                }
                else
                {
                    mainFormStartPosition = value;  
                }                          
            }
        }

        Size mainFormSize = new Size(760, 600);

        public Size MainFormSize
        {
            get { return mainFormSize; }
            set { mainFormSize = value; }            
        }

        int splitterDistance = 200;

        public int SplitterDistance
        {
            get { return splitterDistance; }
            set { splitterDistance = value; }
        }

        int internalPort = 8890;

        public int InternalPort
        {
            get { return internalPort; }
            set { internalPort = value; }
        }

        int externalPort = 25565;

        public int ExternalPort
        {
            get { return externalPort; }
            set { externalPort = value; }
        }

        bool automatedRestart = false;

        public bool AutomatedRestart
        {
            get { return automatedRestart; }
            set { automatedRestart = value; }
        }


        public static String ConfigFolder = Application.StartupPath + Path.DirectorySeparatorChar + "Settings" + Path.DirectorySeparatorChar;
        public static String ConfigFile = "MineCraftAdmin.xml";
        public static String PluginFolder = Application.StartupPath + Path.DirectorySeparatorChar + "Plugins" + Path.DirectorySeparatorChar;


        String chatDateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public String ChatDateTimeFormat
        {
            get { return chatDateTimeFormat; }
            set { chatDateTimeFormat = value; }
        }

        string commandChar = "!";

        public string CommandChar
        {
            get { return commandChar; }
            set { commandChar = value; }
        }

        String[] _modt = new String[]
        {
            "§fWelcome player §c{0}§f. Try §6!help§f and §6/help§f.",
            "§fRead and accept the §6!rules§f."
        };

        public String[] Modt
        {
            get { return _modt; }
            set { _modt = value; }
        }

        String[] _rules = new String[]
        {
            "Keep to the rules!:",
            "Don't grief anything",
            "TNT and Lava spam is strictly forbidden",
            "Violate the rules will result in kick/ban"
        };

        public String[] Rules
        {
            get { return _rules; }
            set { _rules = value; }
        }

        String _java = @"C:\Program Files (x86)\Java\jre6\bin\java.exe";

        public String Java
        {
            get { return _java; }
            set { _java = value; }
        }

        String _minecraft = "minecraft_server.jar";

        public String Minecraft
        {
            get { return _minecraft; }
            set { _minecraft = value; }
        }

        private String _startparameters = "-Xmx1024M -Xms1024M -jar";

        public String Startparameters
        {
            get { return _startparameters; }
            set { _startparameters = value; }
        }

        int _giveLimit = 256;

        public int GiveLimit
        {
            get { return _giveLimit; }
            set { _giveLimit = value; }
        }

        string _backupPrefix = "backup";

        public string BackupPrefix
        {
            get { return _backupPrefix; }
            set { _backupPrefix = value; }
        }

        string _whiteListFile = "whitelist.txt";

        public string WhiteListFile
        {
            get { return _whiteListFile; }
            set { _whiteListFile = value; }
        }

        bool _whiteListMode = false;

        public bool WhiteListMode
        {
            get { return _whiteListMode; }
            set { _whiteListMode = value; }
        }

        bool _makeBackup = false;

        public bool MakeBackup
        {
            get { return _makeBackup; }
            set { _makeBackup = value; }
        }

        public void Save()
        {
            try
            {
                if (Directory.Exists(Config.ConfigFolder))
                {
                    XObject<Config>.Save(this, Config.ConfigFolder + Config.ConfigFile);
                }
                else
                {
                    Directory.CreateDirectory(Config.ConfigFolder);
                    XObject<Config>.Save(this, Config.ConfigFolder + Config.ConfigFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "couldn't save config");
            }
        }
    }
}
