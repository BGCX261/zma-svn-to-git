using System;
using System.Collections.Generic;
using System.Text;
using MinecraftWrapper.XML;
using System.Xml.Serialization;
using Vitt.Andre.XML;
using System.IO;

namespace ZmaGamAzzLottoPlugin
{
    [XmlRootAttribute("LottoUserCollection", Namespace = "", IsNullable = false)]
    public  class LottoUserCollection
    {
        public LottoUserCollection()
        {
                       
        }

        public bool IsInList(string name)
        {
            foreach (LottoUser user in this)
            {
                if (user.Name == name)
                    return true;
            }
            return false;
        }

        public IEnumerator<LottoUser> GetEnumerator()
        {
            return users.GetEnumerator();
        }

        int jackpot = 0;

        public int Jackpot
        {
            get { return jackpot; }
            set { jackpot = value; }
        }

        public void Add(LottoUser user)
        {
            users.Add(user);
        }

        List<LottoUser> users = new List<LottoUser>();

        public List<LottoUser> Users
        {
            get { return users; }
            set { users = value; }
        }

        public void Save()
        {
            try
            {
                if (Directory.Exists(ConfigLotto.ConfigFolder))
                {
                    XObject<LottoUserCollection>.Save(this, ConfigLotto.ConfigFolder + ConfigLotto.LottoFile);
                }
                else
                {
                    Directory.CreateDirectory(ConfigLotto.ConfigFolder);
                    XObject<LottoUserCollection>.Save(this, ConfigLotto.ConfigFolder + ConfigLotto.LottoFile);
                }
            }
            catch
            {

            }
        }

        public static LottoUserCollection Load()
        {
            try
            {
                return XObject<LottoUserCollection>.Load(ConfigLotto.ConfigFolder + ConfigLotto.LottoFile);
            }
            catch (Exception)
            {
                return new LottoUserCollection();
            }
        }
    }
}
