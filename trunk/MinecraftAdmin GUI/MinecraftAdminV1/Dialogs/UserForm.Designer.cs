namespace Zicore.MinecraftAdmin.Admins
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btOK = new System.Windows.Forms.Button();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.btRemoveSelectedRow = new System.Windows.Forms.Button();
            this.comboSelectedPlayer = new System.Windows.Forms.ComboBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btDiscard = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.tbUsercount = new System.Windows.Forms.TextBox();
            this.btWebUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(12, 12);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(849, 342);
            this.dgvUsers.TabIndex = 1;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            this.dgvUsers.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentDoubleClick);
            this.dgvUsers.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsers_ColumnHeaderMouseClick);
            this.dgvUsers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvUsers_DataError);
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Location = new System.Drawing.Point(679, 416);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(182, 23);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "Save";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(12, 389);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(184, 21);
            this.comboBoxLevel.TabIndex = 3;
            this.comboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel_SelectedIndexChanged);
            // 
            // btRemoveSelectedRow
            // 
            this.btRemoveSelectedRow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemoveSelectedRow.Location = new System.Drawing.Point(202, 416);
            this.btRemoveSelectedRow.Name = "btRemoveSelectedRow";
            this.btRemoveSelectedRow.Size = new System.Drawing.Size(471, 23);
            this.btRemoveSelectedRow.TabIndex = 4;
            this.btRemoveSelectedRow.Text = "Remove selected";
            this.btRemoveSelectedRow.UseVisualStyleBackColor = true;
            this.btRemoveSelectedRow.Click += new System.EventHandler(this.btRemoveSelectedRow_Click);
            // 
            // comboSelectedPlayer
            // 
            this.comboSelectedPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSelectedPlayer.FormattingEnabled = true;
            this.comboSelectedPlayer.Location = new System.Drawing.Point(202, 389);
            this.comboSelectedPlayer.Name = "comboSelectedPlayer";
            this.comboSelectedPlayer.Size = new System.Drawing.Size(471, 21);
            this.comboSelectedPlayer.TabIndex = 5;
            this.comboSelectedPlayer.SelectedIndexChanged += new System.EventHandler(this.comboSelectedPlayer_SelectedIndexChanged);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Location = new System.Drawing.Point(679, 387);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(182, 23);
            this.btAdd.TabIndex = 6;
            this.btAdd.Text = "Add selected player";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btDiscard
            // 
            this.btDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDiscard.Location = new System.Drawing.Point(12, 416);
            this.btDiscard.Name = "btDiscard";
            this.btDiscard.Size = new System.Drawing.Size(184, 23);
            this.btDiscard.TabIndex = 7;
            this.btDiscard.Text = "Discard Changes";
            this.btDiscard.UseVisualStyleBackColor = true;
            this.btDiscard.Click += new System.EventHandler(this.btDiscard_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(679, 360);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(182, 23);
            this.btRefresh.TabIndex = 8;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // tbUsercount
            // 
            this.tbUsercount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbUsercount.Location = new System.Drawing.Point(12, 362);
            this.tbUsercount.Name = "tbUsercount";
            this.tbUsercount.ReadOnly = true;
            this.tbUsercount.Size = new System.Drawing.Size(184, 20);
            this.tbUsercount.TabIndex = 9;
            // 
            // btWebUser
            // 
            this.btWebUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btWebUser.Location = new System.Drawing.Point(202, 359);
            this.btWebUser.Name = "btWebUser";
            this.btWebUser.Size = new System.Drawing.Size(471, 23);
            this.btWebUser.TabIndex = 10;
            this.btWebUser.Text = "Edit Web User";
            this.btWebUser.UseVisualStyleBackColor = true;
            this.btWebUser.Click += new System.EventHandler(this.btWebUser_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btWebUser);
            this.Controls.Add(this.tbUsercount);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btDiscard);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.comboSelectedPlayer);
            this.Controls.Add(this.btRemoveSelectedRow);
            this.Controls.Add(this.comboBoxLevel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.dgvUsers);
            this.Name = "UserForm";
            this.Size = new System.Drawing.Size(873, 451);
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.Button btRemoveSelectedRow;
        private System.Windows.Forms.ComboBox comboSelectedPlayer;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btDiscard;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.TextBox tbUsercount;
        private System.Windows.Forms.Button btWebUser;

    }
}