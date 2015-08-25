using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zicore.PluginConfig
{
    public partial class ConfigDialog : Form
    {
        public ConfigDialog()
        {
            InitializeComponent();
        }

        ConfigPlugin p;

        private void ConfigDialog_Load(object sender, EventArgs e)
        {
            p = ConfigPlugin.Load();
            configGrid.SelectedObject = p;
        }

        public delegate void ConfigChangedDelegate(ConfigPlugin config);
        public event ConfigChangedDelegate ConfigChanged;

        public void FireConfigChanged(ConfigPlugin config)
        {
            if (ConfigChanged != null)
            {
                ConfigChanged(config);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            p.Save();
            FireConfigChanged(p);
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
