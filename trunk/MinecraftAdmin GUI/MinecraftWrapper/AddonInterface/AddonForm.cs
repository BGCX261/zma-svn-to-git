using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using MinecraftWrapper.AddonInterface;

namespace Vitt.Andre.AddonManagerLib
{
    public partial class AddonForm : Form
    {
        public AddonForm(PluginCollection addons)
        {
            InitializeComponent();

           //_addons = AddonLoader.LoadAddons(Application.StartupPath + "\\Addons");
            _addons = addons;
            
            listAddons.DataSource = _addons;
            listAddons.DisplayMember = "AddonName";
        }

        PluginCollection _addons;

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private IPlugin GetSelectedAddon()
        {
            int index = listAddons.SelectedIndex;
            if (index > -1 && listAddons.Items.Count > 0)
            {
                return (IPlugin)listAddons.Items[index];
            }
            return null;
        }

        private void listAddons_SelectedIndexChanged(object sender, EventArgs e)
        {
            IPlugin addon = GetSelectedAddon();
            if (addon != null)
            {
                Type type = addon.GetType();
                Assembly asm = type.Assembly;

                tbTitle.Text = type.Assembly.GetName().Name;
                tbCopyright.Text = AddonForm.GetAssemblyCopyrightAttribute(asm);
                tbDescription.Text = AddonForm.GetAssemblyDescriptionAttribute(asm);
                tbProduct.Text = AddonForm.GetAssemblyProductAttribute(asm);
                tbFirma.Text = AddonForm.GetAssemblyTrademarkAttribute(asm);
                tbVersion.Text = AddonForm.GetAssemblyFileVersionAttribute(asm);
                tbFileName.Text = asm.ManifestModule.Name;
                tbAddonDescription.Text = AddonForm.GetIAddonDescription(addon);
                chkEnabled.Checked = GetEnabledState(addon as IPlugin);
            }
        }

        public static string GetAssemblyModuleName(Assembly asm)
        {
            return asm.ManifestModule.Name;
        }

        public static string GetIAddonDescription(IPlugin p)
        {
            return (p as IPlugin).Description;
        }

        public static bool GetEnabledState(IPlugin addon)
        {
            return addon.Enabled;
        }

        public static string GetAssemblyCopyrightAttribute(Assembly asm)
        {
            var attributes = asm.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            if (attributes.Length > 0)
            {
                var atr = attributes[0] as AssemblyCopyrightAttribute;
                return atr.Copyright;
            }
            return "";
        }

        public static string GetAssemblyTitleAttribute(Assembly asm)
        {
            var attributes = asm.GetCustomAttributes(typeof(AssemblyTitleAttribute),false);
            if (attributes.Length > 0)
            {
                var atr = attributes[0] as AssemblyTitleAttribute;
                return atr.Title;
            }
            return "";
        }

        public static string GetAssemblyProductAttribute(Assembly asm)
        {
            var attributes = asm.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            if (attributes.Length > 0)
            {
                var atr = attributes[0] as AssemblyProductAttribute;
                return atr.Product;
            }
            return "";
        }

        public static string GetAssemblyFileVersionAttribute(Assembly asm)
        {
            var attributes = asm.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
            if (attributes.Length > 0)
            {
                var atr = attributes[0] as AssemblyFileVersionAttribute;
                return atr.Version;
            }
            return "";
        }

        public static string GetAssemblyDescriptionAttribute(Assembly asm)
        {
            var attributes = asm.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                var atr = attributes[0] as AssemblyDescriptionAttribute;
                return atr.Description;
            }
            return "";
        }

        public static string GetAssemblyTrademarkAttribute(Assembly asm)
        {
            var attributes = asm.GetCustomAttributes(typeof(AssemblyTrademarkAttribute), false);
            if (attributes.Length > 0)
            {
                var atr = attributes[0] as AssemblyTrademarkAttribute;
                return atr.Trademark;
            }
            return "";
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            IPlugin addon = GetSelectedAddon() as IPlugin;
            if (addon != null)
            {
                addon.Enabled = chkEnabled.Checked;
            }
        }
    }
}
