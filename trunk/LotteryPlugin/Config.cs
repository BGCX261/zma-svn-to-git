using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Vitt.Andre.XML;
using System.Xml.Serialization;

namespace ZmaGamAzzLottoPlugin
{
    [XmlRootAttribute("LottoConfig", Namespace = "", IsNullable = false)]
    public class ConfigLotto
    {
        public static String ConfigFolder = "";
        public static String ConfigFile = "config.xml";
        public static String LottoFile = "lotto.xml";

        int price = 10;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        int bonus = 0;

        public int Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        int min = 0;

        public int Min
        {
            get { return min; }
            set { min = value; }
        }
        int max = 100;

        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        int ziehung = 10;

        public int Ziehung
        {
            get { return ziehung; }
            set { ziehung = value; }
        }

        public void Save()
        {
            try
            {
                if (Directory.Exists(ConfigLotto.ConfigFolder))
                {
                    XObject<ConfigLotto>.Save(this, ConfigLotto.ConfigFolder + ConfigLotto.ConfigFile);
                }
                else
                {
                    Directory.CreateDirectory(ConfigLotto.ConfigFolder);
                    XObject<ConfigLotto>.Save(this, ConfigLotto.ConfigFolder + ConfigLotto.ConfigFile);
                }
            }
            catch
            {
                
            }
        }

        public static ConfigLotto Load()
        {
            try
            {
                return XObject<ConfigLotto>.Load(ConfigLotto.ConfigFolder + ConfigLotto.ConfigFile);
            }
            catch (Exception)
            {
                return new ConfigLotto();
            }           
        }
    }
}
