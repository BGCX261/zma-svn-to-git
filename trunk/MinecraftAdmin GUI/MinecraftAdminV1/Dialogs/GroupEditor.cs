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
using MinecraftWrapper.Chat;

namespace Zicore.MinecraftAdmin
{
    public partial class GroupEditor : UserControl
    {
        public GroupEditor(MinecraftHandler mc)
        {
            InitializeComponent();
            try
            {
                dgvLevels.AutoGenerateColumns = false;
                GenerateColumns();

                this.mc = mc;
                _levelCollection = GroupCollectionSingletone.GetInstance();
                RefreshAvailableCommands();
                dgvLevels.DataSource = _levelCollection.Items;
                UpdateDataGrid(0);
            }
            catch { }
            this.Dock = DockStyle.Fill;
        }

        private void RefreshAvailableCommands()
        {
            try
            {
                listCommandsAvailable.DataSource = null;
                listCommandsAvailable.DataSource = CommandManager.GetInstance(mc).CommandList;
                listCommandsAvailable.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerateColumns()
        {
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "Name";
            col.HeaderText = "Group Name";
            dgvLevels.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "ID";
            col.DataPropertyName = "ID";
            dgvLevels.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Block Level";
            col.DataPropertyName = "BlockLevel";
            dgvLevels.Columns.Add(col);
            
            col = new DataGridViewComboBoxColumn();
            col.HeaderText = "Color Char";
            col.DataPropertyName = "GroupColor";
            (col as DataGridViewComboBoxColumn).DisplayMember = "Name";
            (col as DataGridViewComboBoxColumn).ValueMember = "Key";
            (col as DataGridViewComboBoxColumn).DataSource = ColorCollection.GetInstance().Items;
            dgvLevels.Columns.Add(col);

            col = new DataGridViewCheckBoxColumn();
            col.HeaderText = "Allow Destroy";
            col.DataPropertyName = "AllowDestroy";
            dgvLevels.Columns.Add(col);

            col = new DataGridViewCheckBoxColumn();

            col.HeaderText = "Allow Build";
            col.DataPropertyName = "AllowBuild";
            dgvLevels.Columns.Add(col);

            col = new DataGridViewCheckBoxColumn();

            col.HeaderText = "Allow Chat";
            col.DataPropertyName = "AllowChat";
            dgvLevels.Columns.Add(col);

            //col = new DataGridViewCheckBoxColumn();
            //col.HeaderText = "Instant Destroy";
            //col.DataPropertyName = "InstantDestroy";
            //dgvLevels.Columns.Add(col);

            col = new DataGridViewCheckBoxColumn();
            col.HeaderText = "Self Response";
            col.DataPropertyName = "OwnExecuteResponse";
            dgvLevels.Columns.Add(col);

            col = new DataGridViewCheckBoxColumn();
            col.HeaderText = "Other Response";
            col.DataPropertyName = "OtherExecuteResponse";
            dgvLevels.Columns.Add(col);
        }

        MinecraftHandler mc;

        GroupCollectionSingletone _levelCollection;

        private void btAdd_Click(object sender, EventArgs e)
        {
            _levelCollection.Add(new Group("Empty",0));
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            dgvLevels.DataSource = typeof(GroupCollection);
            dgvLevels.DataSource = _levelCollection;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            try
            {
                _levelCollection.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "couldn't save config");
            }
        }

        private void dgvLevels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    dgvLevels[e.ColumnIndex, e.RowIndex].Selected = true;
                    UpdateDataGrid(e.RowIndex);
                    dgvLevels.BeginEdit(true);
                }
            }
            catch
            {

            }
        }

        private void UpdateDataGrid(int index)
        {
            try
            {
                Group level = _levelCollection.Items[index];
                listAssignedCommands.DataSource = null;
                listAssignedCommands.DataSource = level.Commands;
            }
            catch
            {

            }      
        }

        private void btRight_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> commands = listAssignedCommands.DataSource as List<String>;

                ListBox.SelectedIndexCollection indicies = listAssignedCommands.SelectedIndices;

                for (int i = indicies.Count; i > 0; i--)
                {
                    commands.RemoveAt(indicies[0]);
                }

                
                listAssignedCommands.DataSource = null;
                listAssignedCommands.DataSource = commands;
            }
            catch 
            {
            
            }
        }

        private void btLeft_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> commands = listCommandsAvailable.DataSource as List<String>;
                List<String> realCommands = listAssignedCommands.DataSource as List<String>;

                foreach (String str in listCommandsAvailable.SelectedItems)
                {
                    if (!mc.IsStringInList(str, realCommands))
                    {
                        realCommands.Add(str);
                    }
                }                
                
                UpdateDataGrid(dgvLevels.SelectedCells[0].RowIndex);
            }
            catch
            {
                MessageBox.Show("Select a group at first");
            }
        }

        private void dgvLevels_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDataGrid(e.RowIndex);
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to delete the selected Zone?", "Delete Zone?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                try
                {
                    int index = dgvLevels.SelectedCells[0].RowIndex;
                    _levelCollection.RemoveAt(index);
                }
                catch { }
            }
        }

        private void dgvLevels_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        ListSortDirection direction = ListSortDirection.Ascending;

        private void dgvLevels_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvLevels.SortedColumn.Index == e.ColumnIndex)
                {
                    if (direction == ListSortDirection.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
                this.dgvLevels.Sort(this.dgvLevels.Columns[e.ColumnIndex], direction);
            }
            catch
            {

            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            CommandManager.GetInstance(mc).ResetCommands();
            RefreshAvailableCommands();
            dgvLevels.DataSource = typeof(GroupCollection);
            dgvLevels.DataSource = _levelCollection.Items;
            
            UpdateDataGrid(0);
        }

        private void btDiscard_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to revert all changes you made ?", "Discard changes ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                _levelCollection.Load();
                dgvLevels.DataSource = typeof(GroupCollection);
                dgvLevels.DataSource = _levelCollection.Items;
                UpdateDataGrid(0);
            }
        }

        private void listCommandsAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCommandsAvailable.SelectedItem != null)
            {
                try
                {
                    String cmd = (String)listCommandsAvailable.SelectedValue;
                    tbHelpText.Text = CommandManager.GetInstance(mc).Items[cmd].Help;
                }
                catch { }
            }
        }

        private void listAssignedCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listAssignedCommands.SelectedItem != null)
            {
                try
                {
                    String cmd = (String)listAssignedCommands.SelectedValue;
                    tbHelpText.Text = CommandManager.GetInstance(mc).Items[cmd].Help;
                }
                catch { }
            }
        }
    }
}
