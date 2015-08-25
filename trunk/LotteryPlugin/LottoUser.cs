using System;
using System.Collections.Generic;
using System.Text;
using Zicore.MinecraftAdmin.Admins;

namespace ZmaGamAzzLottoPlugin
{
    public class LottoUser
    {
        String name = "<user>";

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        int zahl = 0;

        public int Zahl
        {
            get { return zahl; }
            set { zahl = value; }
        }


        public LottoUser()
        {
            UserCollectionSingletone users = UserCollectionSingletone.GetInstance();
        }

        public LottoUser(String name, int zahl)
        {
            this.Name = name;
            this.Zahl = zahl;
        }
    }
}
