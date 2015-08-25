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
    public partial class WhiteList : UserControl
    {
        MinecraftHandler mc;

        public WhiteList(MinecraftHandler mc)
        {
            InitializeComponent();
            
            try
            {
                if (!File.Exists(Config.ConfigFolder + mc.Config.WhiteListFile))
                {
                    FileStream fs = File.Create(Config.ConfigFolder + mc.Config.WhiteListFile);
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

        List<String> whitelist;

        private void RefreshPlayerlist()
        {
            whitelist = mc.GetListFromFile(Config.ConfigFolder + mc.Config.WhiteListFile);
            listWhitelist.DataSource = whitelist;
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (listWhitelist.SelectedItem != null)
            {
                mc.RemovePlayerFromList(whitelist, listWhitelist.SelectedItem.ToString(), Config.ConfigFolder + mc.Config.WhiteListFile);
                RefreshPlayerlist();
            }
        }


        private void btAdd_Click(object sender, EventArgs e)
        {
            string str = tbBan.Text;
            if (!String.IsNullOrEmpty(str))
            {
                mc.AddToPlayerList(whitelist,str, Config.ConfigFolder + mc.Config.WhiteListFile);
                RefreshPlayerlist();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            
        }
    }
}
