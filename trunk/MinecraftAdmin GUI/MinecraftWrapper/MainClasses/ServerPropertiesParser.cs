using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Zicore.MinecraftAdmin.IO;
using System.Text.RegularExpressions;

namespace MinecraftWrapper.MainClasses
{
    public class ServerPropertiesParser
    {
        public static ServerPropertiesDictonary Load(String file)
        {
            ServerPropertiesDictonary dict = new ServerPropertiesDictonary();
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    while (!sr.EndOfStream)
                    {
                        String line = sr.ReadLine();
                        if (line.Length > 0 && !line.Contains("#"))
                        {
                            Match m = Regex.Match(line, "(?<left>[^=]+)=(?<right>[^=]+)",RegexOptions.IgnoreCase);
                            if (m.Success)
                            {
                                String left = m.Groups["left"].Value;
                                String right = m.Groups["right"].Value;

                                dict.Add(left, right);
                            }
                        }
                    }
                    sr.Close();
                }
            }
            catch ( Exception ex )
            {
                Log.Append(null, "Load Serverproperties " + ex.Message, Log.ExceptionsLog);
            }
            return dict;
        }
    }
}
