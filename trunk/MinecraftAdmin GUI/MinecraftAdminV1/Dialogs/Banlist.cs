using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Zicore.MinecraftAdmin
{
    public partial class Banlist : UserControl
    {
        MinecraftHandler mc;

        public Banlist(MinecraftHandler mc)
        {
            InitializeComponent();
            comboBoxPlayers.DataSource = mc.Player;
            try
            {
                if (!File.Exists(mc.StrBanList))
                {
                    FileStream fs = File.Create(Application.StartupPath + Path.DirectorySeparatorChar + mc.StrBanList);
                    fs.Close();
                }
            }
            catch { }

            this.mc = mc;
            RefreshPlayerlist();
            this.Dock = DockStyle.Fill;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            RefreshPlayerlist();
        }

        List<String> list;

        private void RefreshPlayerlist()
        {
            list = mc.GetListFromFile(mc.StrBanList);
            listBanlist.DataSource = null;
            listBanlist.DataSource = list;
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (listBanlist.SelectedItem != null)
            {
                mc.ExecuteCommand("pardon",listBanlist.SelectedItem.ToString());
                RefreshPlayerlist();
            }
        }


        private void btAdd_Click(object sender, EventArgs e)
        {
            string str = comboBoxPlayers.Text;
            if (!String.IsNullOrEmpty(str))
            {
                mc.ExecuteCommand("ban", comboBoxPlayers.Text);
                RefreshPlayerlist();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBoxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
