using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet;
using updateSystemDotNet.Core.Types;

namespace Zicore.MinecraftAdmin.Dialogs
{
    public partial class UpdateDialog : Form
    {
        public UpdateDialog(UpdateResult result, String oldVersion)
        {
            InitializeComponent();

            try
            {
                updatePackage update = result.newUpdatePackages[result.newUpdatePackages.Count - 1];
                string str = result.Changelogs[update].englishChanges;
                tbChangelog.AppendText(str + Environment.NewLine);
            }
            catch
            {
                
            }
            try
            {
                updatePackage update = result.newUpdatePackages[result.newUpdatePackages.Count-1];
                string version = String.Format("{0}  to  {1}", oldVersion, update.Version);
                lbVersion.Text = version;
                Text = "Update available " + version;
            }
            catch
            {
                
            }
        }

        private void btYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void UpdateDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
