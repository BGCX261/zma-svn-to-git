using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vitt.Andre.XML;
using System.IO;
using Zicore.MinecraftAdmin.Commands;
using MinecraftWrapper.Blocks;

namespace Zicore.MinecraftAdmin
{
    public partial class BadBlocksForm : UserControl
    {
        public BadBlocksForm(MinecraftHandler mc)
        {
            InitializeComponent();
            dgvBadBlocks.AutoGenerateColumns = false;
            LoadDataSource();
            UpdateCombobox(0);
            GenerateColumns();

            this.mc = mc;
            this.Dock = DockStyle.Fill;            
        }

        BlockCollection _blocks = new BlockCollection();

        private void LoadDataSource()
        {
            try
            {
                _blocks = BlockCollection.Load(Config.ConfigFolder + BlockCollection.BadBlocksFile);
                if (_blocks == null)
                {
                    _blocks = new BlockCollection();
                }
            }
            catch
            {
                _blocks = new BlockCollection();
            }
            try
            {
                comboBoxItems.ValueMember = "Value";
                comboBoxItems.DisplayMember = "Name";
                comboBoxItems.DataSource = new BindingSource(ItemDictonary.GetInstance(), null);
            }
            catch
            {

            }
            dgvBadBlocks.DataSource = new BindingSource(_blocks,null);
        }

        private void GenerateColumns()
        {
            dgvBadBlocks.AllowUserToAddRows = true;
            dgvBadBlocks.AllowUserToDeleteRows = true;

            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Block ID";
            col.DataPropertyName = "Id";            
            dgvBadBlocks.Columns.Add(col);

            //try
            //{
            //    DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();

            //    combo.HeaderText = "Name";
            //    combo.DataPropertyName = "Id";
            //    combo.ValueMember = "Value";
            //    combo.DisplayMember = "Name";
            //    combo.DataSource = new BindingSource(ItemDictonary.GetInstance(), null);
            //    dgvBadBlocks.Columns.Add(combo);
            //}
            //catch { }

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Block Name";
            col.DataPropertyName = "Name";

            col.ReadOnly = true;
            col.DefaultCellStyle.BackColor = Color.LightGray;
            dgvBadBlocks.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Block Level";
            col.DataPropertyName = "BlockLevel";
            dgvBadBlocks.Columns.Add(col);            
        }

        MinecraftHandler mc;

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _blocks.Add(new BlockItem(Convert.ToInt32(((KeyValuePair<String, String>)comboBoxItems.SelectedItem).Value)));
                UpdateDataGrid();
            }
            catch { }
        }

        private void UpdateDataGrid()
        {
            dgvBadBlocks.DataSource = typeof(BlockCollection);
            dgvBadBlocks.DataSource = new BindingSource(_blocks, null);
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            try
            {
                if (Directory.Exists(Config.ConfigFolder))
                {
                    XObject<BlockCollection>.Save(_blocks, Config.ConfigFolder + BlockCollection.BadBlocksFile);
                }
                else
                {
                    Directory.CreateDirectory(Config.ConfigFolder);
                    XObject<BlockCollection>.Save(_blocks, Config.ConfigFolder + BlockCollection.BadBlocksFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "couldn't bad blocks");
            }
        }

        private void GroupEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _blocks.Save(Config.ConfigFolder + BlockCollection.BadBlocksFile);
        }

        private void dgvBadBlocks_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void UpdateCombobox(int index)
        {
            try
            {
                BlockItem item = _blocks[index];
                if (item != null)
                {
                    //comboBoxItems.DisplayMember = "ToString";
                    comboBoxItems.SelectedIndex = comboBoxItems.FindStringExact(item.ToString());
                }
            }
            catch { }
        }

        private void UpdateCombobox()
        {
            UpdateCombobox(dgvBadBlocks.SelectedCells[0].RowIndex);
        }

        private void dgvBadBlocks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                try
                {
                    BlockItem item = _blocks[dgvBadBlocks.SelectedCells[0].RowIndex];
                    if (item != null)
                    {
                        //comboBoxItems.DisplayMember = "ToString";
                        comboBoxItems.SelectedIndex = comboBoxItems.FindStringExact(item.ToString());
                    }
                }
                catch { }

                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    dgvBadBlocks[e.ColumnIndex, e.RowIndex].Selected = true;
                    dgvBadBlocks.BeginEdit(true);
                }
            }
            catch
            {

            }
        }

        private void ComboboxSelectionChanged()
        {
            try
            {
                BlockItem block = _blocks[dgvBadBlocks.SelectedCells[0].RowIndex];

                block.Id = Convert.ToInt32(comboBoxItems.SelectedValue);

                
            }
            catch 
            { 
            
            }
        }

        private void comboBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxSelectionChanged();
        }

        private void dgvBadBlocks_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            try
            {
                _blocks.RemoveAt(dgvBadBlocks.SelectedCells[0].RowIndex);
                UpdateDataGrid();
            }
            catch
            {

            }
        }

        private void btAddAll_Click(object sender, EventArgs e)
        {

        }

        private void btDiscard_Click(object sender, EventArgs e)
        {
            _blocks = BlockCollection.Load(Config.ConfigFolder + BlockCollection.BadBlocksFile);
            UpdateDataGrid();
        }
    }
}
