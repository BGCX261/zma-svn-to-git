using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zicore.MinecraftAdmin.IO;

namespace Zicore.MinecraftAdmin
{
    public partial class Playerlist : UserControl
    {
        MinecraftHandler mc;

        public Playerlist(MinecraftHandler mc)
        {
            InitializeComponent();
            this.mc = mc;
            RefreshPlayerlist();
            mc.PlayerJoined += new MinecraftHandler.OnPlayerjoined(mc_PlayerJoined);
            mc.PlayerLeft += new MinecraftHandler.OnPlayerLeft(mc_PlayerLeft);

            comboBoxPlayers.DataSource = mc.Player;

            this.Dock = DockStyle.Fill;
        }

        void mc_PlayerLeft(object sender, string player)
        {
            RefreshPlayerlist();
        }

        void mc_PlayerJoined(object sender, string player)
        {
            RefreshPlayerlist();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            RefreshPlayerlist();
            //Log.Append(this, "Refresh Exception", Log.ExceptionsLog);
        }

        private void RefreshPlayerlist()
        {
            List<String> list = mc.Player;
            listPlayerlist.DataSource = null;
            listPlayerlist.DataSource = list;
            lbOnline.Text = "Online: " + list.Count.ToString(); 
        }

        private void btKick_Click(object sender, EventArgs e)
        {
            if (listPlayerlist.SelectedItem != null)
            {
                mc.ExecuteKick(listPlayerlist.SelectedItem.ToString(), "Console");
                RemoveSelected();
                RefreshPlayerlist();
            }
        }

        private void btBan_Click(object sender, EventArgs e)
        {
            if (listPlayerlist.SelectedItem != null)
            {
                mc.ExecuteBan(listPlayerlist.SelectedItem.ToString(), "Console");
                RemoveSelected();
                RefreshPlayerlist();
            }
        }

        private void RemoveSelected()
        {
            if (listPlayerlist.SelectedItem != null)
            {
                mc.RemovePlayer(listPlayerlist.SelectedItem.ToString());
                RefreshPlayerlist();
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string str = comboBoxPlayers.Text;
                if (!String.IsNullOrEmpty(str))
                {
                    mc.AddPlayer(comboBoxPlayers.Text,-1);
                    RefreshPlayerlist();
                }
            }
            catch
            {

            }
        }
    }
}
