using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vitt.Andre.XML;
using Zicore.MinecraftAdmin.Commands;
using MinecraftWrapper.WebInterface;
using Vitt.Andre.MinecraftAdmin.Dialogs;

namespace Zicore.MinecraftAdmin.Admins
{
    public partial class UserForm : UserControl
    {
        public UserForm(MinecraftHandler mc)
        {
            InitializeComponent();
            dgvUsers.AutoGenerateColumns = false;
            GenerateColumns();
            this.mc = mc;
            _userCollection = UserCollectionSingletone.GetInstance();
            
            try
            {
                List<String> playerlist = mc.Player;
                comboSelectedPlayer.DataSource = playerlist;
            }
            catch
            {
                
            }
            dgvUsers.DataSource =  new BindingSource(_userCollection.Items,null);
            UpdateDataGrid(0);
            this.Dock = DockStyle.Fill;
            RefreshData();
        }

        private void UpdateDataGrid(int index)
        {
            try
            {
                User user = _userCollection.Items[index];
                
                comboBoxLevel.DisplayMember = "Name";
                comboBoxLevel.SelectedIndex = comboBoxLevel.FindStringExact(user.Level.Name);

            }
            catch
            {

            }
        }

        private void GenerateColumns()
        {
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = "User Name";
            col.DataPropertyName = "Name";
            dgvUsers.Columns.Add(col);



            GroupCollectionSingletone levels = GroupCollectionSingletone.GetInstance();
            comboBoxLevel.DataSource = null;
            comboBoxLevel.DataSource = levels.Items;

            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "Group";
            combo.DataPropertyName = "Level";
            combo.ValueMember = "Name";
            combo.DisplayMember = "Name";
            combo.DataSource = levels.Items;
            dgvUsers.Columns.Add(combo);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Balance";
            col.DataPropertyName = "Balance";
            dgvUsers.Columns.Add(col);

            col = new DataGridViewCheckBoxColumn();
            col.HeaderText = "Allow Chat";
            col.DataPropertyName = "AllowChat";
            dgvUsers.Columns.Add(col);

            //col = new DataGridViewTextBoxColumn();
            //col.HeaderText = "Remote Login";
            //col.DataPropertyName = "Login";
            //dgvUsers.Columns.Add(col);


            //DataGridViewTextBoxColumn passwordColumn = new DataGridViewTextBoxColumn();

            //passwordColumn.HeaderText = "Remote Password";
            //passwordColumn.DataPropertyName = "PasswordHash";
            //dgvUsers.Columns.Add(passwordColumn);

            col = new DataGridViewCheckBoxColumn();

            col.HeaderText = "Has Web Access";
            col.DataPropertyName = "HasWebAccess";
            dgvUsers.Columns.Add(col);
        }

        UserCollectionSingletone _userCollection;
        MinecraftHandler mc;

        private void btOK_Click(object sender, EventArgs e)
        {
            _userCollection.Save();
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
                    dgvUsers[e.ColumnIndex, e.RowIndex].Selected = true;
                    UpdateDataGrid(e.RowIndex);
                    dgvUsers.BeginEdit(true);
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
                User user = _userCollection.Items[dgvUsers.SelectedCells[0].RowIndex];
                user.LevelID = (comboBoxLevel.SelectedItem as Group).Id;

                //XObject<UserCollection>.Save(_userCollection, Config.ConfigFolder + UserCollection.File);
            }
            catch
            {
                
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (_userCollection.GetUserByName(comboSelectedPlayer.Text).Generated)
            {
                User user = new User(comboSelectedPlayer.Text);
                try
                {
                    user.LevelID = (comboBoxLevel.SelectedValue as Group).Id;
                }
                catch { }
                _userCollection.Add(user);
            }
            else
            {
                MessageBox.Show("The user is allready in the list", "User allready in list!", 
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btRemoveSelectedRow_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to delete the selected User?", "Delete User?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.Yes)
            {
                try
                {
                    int index = dgvUsers.SelectedCells[0].RowIndex;
                    _userCollection.RemoveAt(index);
                }
                catch { }
            }
        }

        private void dgvUsers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //UpdateDataGrid(e.RowIndex);
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        private void btDiscard_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to revert all changes you made ?", "Discard changes ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                _userCollection.Load();
                UpdateDataGrid();
            }
        }

        private void UpdateDataGrid()
        {
            dgvUsers.DataSource = typeof(UserCollection);
            dgvUsers.DataSource = new BindingSource(_userCollection.Items, null);
        }

        private void comboSelectedPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshData()
        {
            tbUsercount.Text = String.Format("User count: {0}", _userCollection.Items.Count);
            dgvUsers.DataSource = typeof(UserCollection);
            dgvUsers.DataSource = new BindingSource(_userCollection.Items, null);
            try
            {
                comboSelectedPlayer.DataSource = null;
                comboSelectedPlayer.DataSource = mc.Player;
            }
            catch
            {
            }
        }
        
        private void btRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        ListSortDirection direction = ListSortDirection.Ascending;

        private void dgvUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvUsers.SortedColumn.Index == e.ColumnIndex)
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
                this.dgvUsers.Sort(this.dgvUsers.Columns[e.ColumnIndex], direction);
            }
            catch
            {

            }
        }

        private void btWebUser_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvUsers.SelectedCells[0].RowIndex;
                User user = _userCollection.Items[index];
                UpdateWebUser d = new UpdateWebUser(user);
                d.Show();
            }
            catch
            {

            }
        }
    }
}
