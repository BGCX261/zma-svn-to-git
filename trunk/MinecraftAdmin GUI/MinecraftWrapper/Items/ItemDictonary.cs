using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Zicore.MinecraftAdmin
{
    public sealed class ItemDictonary : Dictionary<String, String>
    {
        private ItemDictonary()
        {
            ReadFromFile();
        }

        public static ItemDictonary GetInstance()
        {
            // DoubleLock
            if (instance == null)
            lock (m_lock) 
            {
                if (instance == null)
                    instance = new ItemDictonary(); 
            }
            return instance;
        }

        public bool GetKeyValuePairByValue(out KeyValuePair<String, String> keyValuePair, String value)
        {
            keyValuePair = new KeyValuePair<string, string>();
            if (this.ContainsValue(value))
            {
                foreach (KeyValuePair<String, String> kvp in this)
                {
                    if (kvp.Value.ToLower() == value.ToLower())
                    {
                        keyValuePair = kvp;
                        return true;
                    }
                }
            }
            return false;
        }

        private static object m_lock = new object();

        private static volatile ItemDictonary instance = null;

        public static string File = "items.txt";

        public void ReadFromFile()
        {
            this.Clear();
            String itemPattern = "[ ]+(?<hex>[0-9a-f]+)[ ]+(?<dec>[0-9]+)[ ]+(?<name>[A-Za-z0-9() ]+)";
            Regex itemRegex = new Regex(itemPattern,RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
            try
            {
                using (StreamReader sr = new StreamReader(Config.ConfigFolder + File))
                {
                    while (!sr.EndOfStream)
                    {
                        String line = sr.ReadLine();
                        Match match = itemRegex.Match(line);
                        if (match.Success)
                        {
                            try
                            {
                                string hex = match.Groups["hex"].Value;
                                string dec = match.Groups["dec"].Value;
                                string name = match.Groups["name"].Value;

                                this.Add(name, dec);
                            }
                            catch
                            {
                            }
                        }
                    }
                    sr.Close();
                }
            }
            catch
            {

            }
        }
    }
}
