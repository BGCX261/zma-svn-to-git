using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vitt.Andre.XML;
using Zicore.MinecraftAdmin.Commands;
using MinecraftWrapper.Zones;

namespace Zicore.MinecraftAdmin.Admins
{
    public partial class ZoneForm : UserControl
    {
        public ZoneForm(MinecraftHandler mc)
        {
            InitializeComponent();
            dgvZones.AutoGenerateColumns = false;

            this.mc = mc;

            _zoneCollection = ZoneCollectionSingletone.GetInstance();

            dgvZones.DataSource = _zoneCollection.Items;
            GenerateColumns(false);
            UpdateDataGrid(0);
            this.Dock = DockStyle.Fill;
        }


        private void btAdd_Click(object sender, EventArgs e)
        {
            if (_zoneCollection.GetZoneByName(tbZoneName.Text) == null)
            {
                Zone zone = new Zone(tbZoneName.Text);
                try
                {
                    zone.LevelID = (comboBoxLevel.SelectedValue as Group).Id;
                }
                catch { }
                _zoneCollection.Add(zone);
            }
            else
            {
                MessageBox.Show("The Zone is allready in the list", "Zone allready in list!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btRemoveSelectedRow_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to delete the selected Zone?", "Delete Zone?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                try
                {
                    int index = dgvZones.SelectedCells[0].RowIndex;
                    _zoneCollection.RemoveAt(index);
                    UpdateDataGrid(index);
                }
                catch { }
            }
        }

        private void btDiscard_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to revert all changes you made ?", "Discard changes ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                _zoneCollection.Load();
                dgvZones.DataSource = typeof(ZoneCollection);
                dgvZones.DataSource = _zoneCollection.Items;
                UpdateDataGrid(0);
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            dgvZones.DataSource = typeof(ZoneCollection);
            dgvZones.DataSource = _zoneCollection.Items;
            try
            {
                listPlayerConnected.DataSource = null;
                listPlayerConnected.DataSource = mc.Player;
            }
            catch
            {
            }
        }

        private void btLeft_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> commands = listPlayerConnected.DataSource as List<String>;
                List<String> realCommands = listPlayerWhitelisted.DataSource as List<String>;

                foreach (String str in listPlayerConnected.SelectedItems)
                {
                    if (!mc.IsStringInList(str, realCommands))
                    {
                        realCommands.Add(str);
                    }
                }

                UpdateDataGrid(dgvZones.SelectedCells[0].RowIndex);
            }
            catch
            {
                MessageBox.Show("Select a group at first");
            }
        }

        private void btRight_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> commands = listPlayerWhitelisted.DataSource as List<String>;

                ListBox.SelectedIndexCollection indicies = listPlayerWhitelisted.SelectedIndices;

                for (int i = indicies.Count; i > 0; i--)
                {
                    commands.RemoveAt(indicies[0]);
                }


                listPlayerWhitelisted.DataSource = null;
                listPlayerWhitelisted.DataSource = commands;
            }
            catch
            {

            }
        }

        private void btAddPlayer_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> realCommands = listPlayerWhitelisted.DataSource as List<String>;

                if (!mc.IsStringInList(tbAddPlayer.Text, realCommands))
                {
                    realCommands.Add(tbAddPlayer.Text);
                }

                UpdateDataGrid(dgvZones.SelectedCells[0].RowIndex);
            }
            catch
            {
                MessageBox.Show("Select a group at first");
            }
        }

        ListSortDirection direction = ListSortDirection.Ascending;

        private void dgvZones_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvZones.SortedColumn.Index == e.ColumnIndex)
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
                this.dgvZones.Sort(this.dgvZones.Columns[e.ColumnIndex], direction);
            }
            catch
            {

            }
        }

        private void dgvZones_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvZones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDataGrid(e.RowIndex);
        }

        private void UpdateDataGrid(int index)
        {
            try
            {
                Zone user = _zoneCollection.Items[index];
                comboBoxLevel.DisplayMember = "Name";

                listPlayerWhitelisted.DataSource = null;
                listPlayerWhitelisted.DataSource = user.Whitelist;
            }
            catch
            {

            }
        }

        private void GenerateColumns(bool expert)
        {
            dgvZones.Columns.Clear();

            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Zone Name";
            col.DataPropertyName = "Name";
            dgvZones.Columns.Add(col);


            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Welcome";
            col.DataPropertyName = "WelcomeMessage";
            dgvZones.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Description";
            col.DataPropertyName = "Description";
            dgvZones.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Block Level";
            col.DataPropertyName = "BlockLevel";
            dgvZones.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Owner";
            col.DataPropertyName = "Owner";
            dgvZones.Columns.Add(col);

            col = new DataGridViewCheckBoxColumn();
            col.HeaderText = "Fix permissions to group";
            col.DataPropertyName = "FixToGroup";
            dgvZones.Columns.Add(col);

            col = new DataGridViewCheckBoxColumn();
            col.HeaderText = "Allow destroy";
            col.DataPropertyName = "AllowDestroy";
            dgvZones.Columns.Add(col);

            col = new DataGridViewCheckBoxColumn();
            col.HeaderText = "Allow Build";
            col.DataPropertyName = "AllowBuild";
            dgvZones.Columns.Add(col);     

            GroupCollectionSingletone levels = GroupCollectionSingletone.GetInstance();
            comboBoxLevel.DataSource = null;
            comboBoxLevel.DataSource = levels.Items;

            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "Group";
            combo.DataPropertyName = "Level";
            combo.ValueMember = "Name";
            combo.DisplayMember = "Name";
            combo.DataSource = levels.Items;
            dgvZones.Columns.Add(combo);

            if (expert)
            {
                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "X1";
                col.DataPropertyName = "X1";
                dgvZones.Columns.Add(col);

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "Y1";
                col.DataPropertyName = "Y1";
                dgvZones.Columns.Add(col);

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "Z1";
                col.DataPropertyName = "Z1";
                dgvZones.Columns.Add(col);

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "X2";
                col.DataPropertyName = "X2";
                dgvZones.Columns.Add(col);

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "Y2";
                col.DataPropertyName = "Y2";
                dgvZones.Columns.Add(col);

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "Z2";
                col.DataPropertyName = "Z2";
                dgvZones.Columns.Add(col);
            }
        }

        ZoneCollectionSingletone _zoneCollection;
        MinecraftHandler mc;

        private void btOK_Click(object sender, EventArgs e)
        {
            _zoneCollection.Save();
        }

        private void dgvUsers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    UpdateDataGrid(e.RowIndex);
                    dgvZones[e.ColumnIndex, e.RowIndex].Selected = true;
                    UpdateDataGrid(e.RowIndex);
                    dgvZones.BeginEdit(true);
                }

            }
            catch
            {

            }
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Zone z = _zoneCollection.Items[dgvZones.SelectedCells[0].RowIndex];
                z.LevelID = (comboBoxLevel.SelectedItem as Group).Id;

                //XObject<UserCollection>.Save(_userCollection, Config.ConfigFolder + UserCollection.File);
            }
            catch
            {

            }
        }

        private void dgvUsers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //UpdateDataGrid(e.RowIndex);
        }

        private void chkExpertView_CheckedChanged(object sender, EventArgs e)
        {
            GenerateColumns(chkExpertView.Checked);
        }
    }
}
