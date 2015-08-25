using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Zicore.MinecraftAdmin.IO
{
    public class Log
    {
        public static void AppendText(String text, String fileName)
        {
            try
            {
                if (!Directory.Exists(Config.ConfigFolder))
                {   
                    DirectoryInfo di = Directory.CreateDirectory(Config.ConfigFolder);
                }
            }
            catch
            {

            }
            try
            {
                File.AppendAllText(Config.ConfigFolder + fileName,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + text + Environment.NewLine);
            }
            catch
            {

            }
        }

        public static void Append(object obj,String text, String fileName)
        {
            try
            {
                if (!Directory.Exists(Config.ConfigFolder))
                {
                    DirectoryInfo di = Directory.CreateDirectory(Config.ConfigFolder);
                }
            }
            catch
            {

            }
            try
            {
                String type = "Static Type";
                if (obj != null)
                {
                    type = obj.GetType().FullName;
                }
                File.AppendAllText(Config.ConfigFolder + fileName, String.Format("[{0}] [{1}] {2}{3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), type, text, Environment.NewLine));
            }
            catch
            {

            }
        }

        public static string ChatMessageLogFile = "ChatMessageLog.txt";
        public static string ConsoleLogFile = "MinecraftAdminLog.txt";
        public static string PluginLog = "Plugins.log";
        public static string ExceptionsLog = "Exceptions.log";
        public static string PacketsLog = "Packets.log";
    }
}
