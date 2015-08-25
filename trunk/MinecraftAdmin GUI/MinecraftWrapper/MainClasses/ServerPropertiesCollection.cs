using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Zicore.MinecraftAdmin.IO;

namespace MinecraftWrapper.MainClasses
{
    public class ServerPropertiesDictonary : Dictionary<String, String>
    {
        public void Save(String file)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    foreach (KeyValuePair<String, String> v in this)
                    {
                        sw.WriteLine(String.Format("{0}={1}",v.Key,v.Value));
                    }
                    sw.Close();
                }
            }
            catch (Exception ex)
            {                
                Log.Append(this, "Save Serverproperties " + ex.Message, Log.ExceptionsLog);
            }
        }
    }
}
