using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zicore.MinecraftAdmin;
using Vitt.Andre.XML;

namespace Zicore.MinecraftAdmin
{
    public partial class KitEditor : UserControl
    {
        MinecraftHandler mc;
        public KitEditor(MinecraftHandler mc)
        {
            InitializeComponent();
            this.mc = mc;
            mc.Items.ReadFromFile();
            try
            {
                _levels = GroupCollectionSingletone.GetInstance();
                comboBoxLevel.DataSource = null;
                comboBoxLevel.DataSource = _levels.Items;
            }
            catch
            {

            }
            RefreshKitlist();
            UpdateSelectedKit();
            this.Dock = DockStyle.Fill;
        }

        GroupCollectionSingletone _levels;

        private void btRefresh_Click(object sender, EventArgs e)
        {
            RefreshKitlist();
        }

        List<Kit> kitlist;

        private void RefreshKitlist()
        {
            try
            {
                kitlist = KitReader.GetKitlist(Config.ConfigFolder + KitReader.File);
            }
            catch
            {
                kitlist = new List<Kit>();
            }
            try
            {
                listKitlist.DataSource = kitlist;

                this.comboBoxID.DisplayMember = "ToString"; // Propertyname aus dem Value Objekt im Dictionary           
                this.comboBoxID.ValueMember = "Value";
                this.comboBoxID.DataSource = new BindingSource(mc.Items, null);
            }
            catch
            {
                MessageBox.Show("items.txt couldn't be found.\nCheck the Settings folder and add items.txt here");
            }
        }

        private Kit GetSelectedKit()
        {
            return listKitlist.SelectedItem as Kit;
        }

        private KitItem GetSelectedKitItem()
        {
            return listSelectedKit.SelectedItem as KitItem;
        }

        private void listKitlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSelectedKit();
        }

        private void RefreshSelectedKit()
        {
            Kit kit = GetSelectedKit();
            if (kit != null)
            {
                tbName.Text = kit.Name;
                listSelectedKit.DataSource = null;
                listSelectedKit.DataSource = kit.Items;
                chkFixed.Checked = kit.FixedGroup;
                try
                {
                    comboBoxLevel.DisplayMember = "Name";
                    comboBoxLevel.SelectedIndex = comboBoxLevel.FindStringExact(_levels.GetGroupByID(kit.Level).Name);
                }
                catch
                {

                }
            }
        }

        private void listSelectedKit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedKit();
        }

        private void UpdateSelectedKit()
        {
            KitItem kitItem = GetSelectedKitItem();
            if (kitItem != null)
            {
                try
                {
                    comboBoxID.SelectedValue = kitItem.Id;
                }
                catch { }
                tbAmount.Value = kitItem.Amount;
                
            }
        }

        private void btApplyItem_Click(object sender, EventArgs e)
        {
            ApplySelectedKitItem();
        }

        private void ApplySelectedKitItem()
        {
            KitItem kitItem = GetSelectedKitItem();
            if (kitItem != null)
            {
                kitItem.Id = comboBoxID.SelectedValue as String;
                try
                {
                    kitItem.Amount = (int)tbAmount.Value;
                }
                catch
                {
                    kitItem.Amount = 1;
                }
                RefreshSelectedKit();
            }
        }

        private void btAddItem_Click(object sender, EventArgs e)
        {
            AddSelectedKitItem();   
        }

        private void AddSelectedKitItem()
        {
            Kit kit = GetSelectedKit();
            if (kit != null)
            {
                String id;
                int amount;

                id = comboBoxID.SelectedValue as String;
                try
                {
                    amount = int.Parse(tbAmount.Text);
                }
                catch
                {
                    amount = 1;
                }
                kit.Items.Add(new KitItem(id, amount));
                RefreshSelectedKit();
            }
        }

        private void btRemoveSelected_Click(object sender, EventArgs e)
        {
            int index = listKitlist.SelectedIndex;
            if (index >= 0 && index < listKitlist.Items.Count)
            {
                kitlist.RemoveAt(index);
                listKitlist.DataSource = null;
                listKitlist.DataSource = kitlist;
            }
        }

        private void RefreshList()
        {
            listKitlist.DataSource = null;
            listKitlist.DataSource = kitlist;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
           SaveKitList();
        }

        private void btApplyKit_Click(object sender, EventArgs e)
        {
            SaveKitList();
        }

        private void SaveKitList()
        {
            try
            {
                KitReader.SaveKitlist(kitlist, Config.ConfigFolder + KitReader.File);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            Kit kit = GetSelectedKit();
            if (kit != null)
            {
                kit.Name = tbName.Text;
                RefreshList();
            }
        }

        private void btAddKit_Click(object sender, EventArgs e)
        {
            Kit kit = new Kit();
            kit.Name = "rename";
            kitlist.Add(kit);
            RefreshList();

            KitReader.SaveKitlist(kitlist, Config.ConfigFolder + KitReader.File);
            RefreshKitlist();
        }

        private void btRemoveKitItem_Click(object sender, EventArgs e)
        {
            Kit kit = GetSelectedKit();
            if (kit != null)
            {
                int index = listSelectedKit.SelectedIndex;
                if (index >= 0 && index < kit.Items.Count)
                {
                    kit.Items.RemoveAt(index);
                    RefreshSelectedKit();
                }
            }
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kit kit = GetSelectedKit();
            if (kit != null)
            {
                try
                {
                    kit.Level = (comboBoxLevel.SelectedItem as Group).Id;
                }
                catch
                {

                }
            }
        }

        private void chkFixed_CheckedChanged(object sender, EventArgs e)
        {
            Kit kit = GetSelectedKit();
            if (kit != null)
            {
                try
                {
                    kit.FixedGroup = chkFixed.Checked;
                }
                catch
                {

                }
            }
        }

        private void tbAmount_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
