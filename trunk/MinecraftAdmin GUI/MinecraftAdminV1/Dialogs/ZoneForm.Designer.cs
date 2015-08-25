namespace Zicore.MinecraftAdmin.Admins
{
    partial class ZoneForm
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
            this.enhancedSplitContainer1 = new Zicore.MinecraftAdmin.EnhancedSplitContainer();
            this.chkExpertView = new System.Windows.Forms.CheckBox();
            this.dgvZones = new System.Windows.Forms.DataGridView();
            this.tbZoneName = new System.Windows.Forms.TextBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btDiscard = new System.Windows.Forms.Button();
            this.btRemoveSelectedRow = new System.Windows.Forms.Button();
            this.btAddPlayer = new System.Windows.Forms.Button();
            this.tbAddPlayer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btLeft = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btRight = new System.Windows.Forms.Button();
            this.listPlayerWhitelisted = new System.Windows.Forms.ListBox();
            this.listPlayerConnected = new System.Windows.Forms.ListBox();
            this.enhancedSplitContainer1.Panel1.SuspendLayout();
            this.enhancedSplitContainer1.Panel2.SuspendLayout();
            this.enhancedSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).BeginInit();
            this.SuspendLayout();
            // 
            // enhancedSplitContainer1
            // 
            this.enhancedSplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.enhancedSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.enhancedSplitContainer1.Name = "enhancedSplitContainer1";
            this.enhancedSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // enhancedSplitContainer1.Panel1
            // 
            this.enhancedSplitContainer1.Panel1.Controls.Add(this.btRefresh);
            this.enhancedSplitContainer1.Panel1.Controls.Add(this.chkExpertView);
            this.enhancedSplitContainer1.Panel1.Controls.Add(this.dgvZones);
            this.enhancedSplitContainer1.Panel1.Controls.Add(this.tbZoneName);
            this.enhancedSplitContainer1.Panel1.Controls.Add(this.btOK);
            this.enhancedSplitContainer1.Panel1.Controls.Add(this.comboBoxLevel);
            this.enhancedSplitContainer1.Panel1.Controls.Add(this.btAdd);
            this.enhancedSplitContainer1.Panel1.Controls.Add(this.btDiscard);
            this.enhancedSplitContainer1.Panel1.Controls.Add(this.btRemoveSelectedRow);
            // 
            // enhancedSplitContainer1.Panel2
            // 
            this.enhancedSplitContainer1.Panel2.Controls.Add(this.btAddPlayer);
            this.enhancedSplitContainer1.Panel2.Controls.Add(this.tbAddPlayer);
            this.enhancedSplitContainer1.Panel2.Controls.Add(this.label1);
            this.enhancedSplitContainer1.Panel2.Controls.Add(this.btLeft);
            this.enhancedSplitContainer1.Panel2.Controls.Add(this.label2);
            this.enhancedSplitContainer1.Panel2.Controls.Add(this.btRight);
            this.enhancedSplitContainer1.Panel2.Controls.Add(this.listPlayerWhitelisted);
            this.enhancedSplitContainer1.Panel2.Controls.Add(this.listPlayerConnected);
            this.enhancedSplitContainer1.Size = new System.Drawing.Size(680, 451);
            this.enhancedSplitContainer1.SplitterColor = System.Drawing.Color.LightBlue;
            this.enhancedSplitContainer1.SplitterDistance = 269;
            this.enhancedSplitContainer1.TabIndex = 17;
            // 
            // chkExpertView
            // 
            this.chkExpertView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkExpertView.AutoSize = true;
            this.chkExpertView.Location = new System.Drawing.Point(18, 190);
            this.chkExpertView.Name = "chkExpertView";
            this.chkExpertView.Size = new System.Drawing.Size(82, 17);
            this.chkExpertView.TabIndex = 12;
            this.chkExpertView.Text = "Expert View";
            this.chkExpertView.UseVisualStyleBackColor = true;
            this.chkExpertView.CheckedChanged += new System.EventHandler(this.chkExpertView_CheckedChanged);
            // 
            // dgvZones
            // 
            this.dgvZones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvZones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvZones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvZones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZones.Location = new System.Drawing.Point(7, 3);
            this.dgvZones.MultiSelect = false;
            this.dgvZones.Name = "dgvZones";
            this.dgvZones.Size = new System.Drawing.Size(667, 179);
            this.dgvZones.TabIndex = 11;
            this.dgvZones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvZones_CellClick);
            this.dgvZones.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvZones_DataError);
            // 
            // tbZoneName
            // 
            this.tbZoneName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbZoneName.Location = new System.Drawing.Point(232, 217);
            this.tbZoneName.Name = "tbZoneName";
            this.tbZoneName.Size = new System.Drawing.Size(219, 20);
            this.tbZoneName.TabIndex = 8;
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Location = new System.Drawing.Point(457, 243);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(217, 23);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "Save";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(232, 186);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(444, 23);
            this.btRefresh.TabIndex = 10;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(6, 217);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(220, 21);
            this.comboBoxLevel.TabIndex = 3;
            this.comboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel_SelectedIndexChanged);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Location = new System.Drawing.Point(457, 215);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(217, 23);
            this.btAdd.TabIndex = 6;
            this.btAdd.Text = "Add Zone";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btDiscard
            // 
            this.btDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDiscard.Location = new System.Drawing.Point(6, 243);
            this.btDiscard.Name = "btDiscard";
            this.btDiscard.Size = new System.Drawing.Size(220, 23);
            this.btDiscard.TabIndex = 9;
            this.btDiscard.Text = "Discard Changes";
            this.btDiscard.UseVisualStyleBackColor = true;
            this.btDiscard.Click += new System.EventHandler(this.btDiscard_Click);
            // 
            // btRemoveSelectedRow
            // 
            this.btRemoveSelectedRow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemoveSelectedRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRemoveSelectedRow.ForeColor = System.Drawing.Color.Black;
            this.btRemoveSelectedRow.Location = new System.Drawing.Point(232, 243);
            this.btRemoveSelectedRow.Name = "btRemoveSelectedRow";
            this.btRemoveSelectedRow.Size = new System.Drawing.Size(219, 23);
            this.btRemoveSelectedRow.TabIndex = 4;
            this.btRemoveSelectedRow.Text = "Remove selected";
            this.btRemoveSelectedRow.UseVisualStyleBackColor = true;
            this.btRemoveSelectedRow.Click += new System.EventHandler(this.btRemoveSelectedRow_Click);
            // 
            // btAddPlayer
            // 
            this.btAddPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddPlayer.Location = new System.Drawing.Point(232, 137);
            this.btAddPlayer.Name = "btAddPlayer";
            this.btAddPlayer.Size = new System.Drawing.Size(219, 23);
            this.btAddPlayer.TabIndex = 18;
            this.btAddPlayer.Text = "Add Player";
            this.btAddPlayer.UseVisualStyleBackColor = true;
            this.btAddPlayer.Click += new System.EventHandler(this.btAddPlayer_Click);
            // 
            // tbAddPlayer
            // 
            this.tbAddPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAddPlayer.Location = new System.Drawing.Point(232, 111);
            this.tbAddPlayer.Name = "tbAddPlayer";
            this.tbAddPlayer.Size = new System.Drawing.Size(219, 20);
            this.tbAddPlayer.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Whitelisted Players";
            // 
            // btLeft
            // 
            this.btLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btLeft.Location = new System.Drawing.Point(232, 55);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(219, 23);
            this.btLeft.TabIndex = 14;
            this.btLeft.Text = "<<";
            this.btLeft.UseVisualStyleBackColor = true;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Players Online";
            // 
            // btRight
            // 
            this.btRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btRight.Location = new System.Drawing.Point(232, 26);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(219, 23);
            this.btRight.TabIndex = 13;
            this.btRight.Text = ">>";
            this.btRight.UseVisualStyleBackColor = true;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // listPlayerWhitelisted
            // 
            this.listPlayerWhitelisted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listPlayerWhitelisted.FormattingEnabled = true;
            this.listPlayerWhitelisted.Location = new System.Drawing.Point(6, 26);
            this.listPlayerWhitelisted.Name = "listPlayerWhitelisted";
            this.listPlayerWhitelisted.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listPlayerWhitelisted.Size = new System.Drawing.Size(220, 134);
            this.listPlayerWhitelisted.TabIndex = 11;
            // 
            // listPlayerConnected
            // 
            this.listPlayerConnected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listPlayerConnected.FormattingEnabled = true;
            this.listPlayerConnected.Location = new System.Drawing.Point(457, 26);
            this.listPlayerConnected.Name = "listPlayerConnected";
            this.listPlayerConnected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listPlayerConnected.Size = new System.Drawing.Size(217, 134);
            this.listPlayerConnected.TabIndex = 12;
            // 
            // ZoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.enhancedSplitContainer1);
            this.Name = "ZoneForm";
            this.Size = new System.Drawing.Size(680, 451);
            this.enhancedSplitContainer1.Panel1.ResumeLayout(false);
            this.enhancedSplitContainer1.Panel1.PerformLayout();
            this.enhancedSplitContainer1.Panel2.ResumeLayout(false);
            this.enhancedSplitContainer1.Panel2.PerformLayout();
            this.enhancedSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btRemoveSelectedRow;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox tbZoneName;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.Button btDiscard;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listPlayerWhitelisted;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.ListBox listPlayerConnected;
        private System.Windows.Forms.Button btRight;
        private EnhancedSplitContainer enhancedSplitContainer1;
        private System.Windows.Forms.Button btAddPlayer;
        private System.Windows.Forms.TextBox tbAddPlayer;
        private System.Windows.Forms.DataGridView dgvZones;
        private System.Windows.Forms.CheckBox chkExpertView;

    }
}