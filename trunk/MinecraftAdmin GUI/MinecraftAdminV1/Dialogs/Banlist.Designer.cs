namespace Zicore.MinecraftAdmin
{
    partial class Banlist
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
            this.btRefresh = new System.Windows.Forms.Button();
            this.listBanlist = new System.Windows.Forms.ListBox();
            this.groupBanlist = new System.Windows.Forms.GroupBox();
            this.comboBoxPlayers = new System.Windows.Forms.ComboBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.groupBanlist.SuspendLayout();
            this.SuspendLayout();
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(6, 19);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(422, 23);
            this.btRefresh.TabIndex = 0;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // listBanlist
            // 
            this.listBanlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBanlist.FormattingEnabled = true;
            this.listBanlist.Location = new System.Drawing.Point(6, 77);
            this.listBanlist.Name = "listBanlist";
            this.listBanlist.Size = new System.Drawing.Size(422, 355);
            this.listBanlist.TabIndex = 1;
            // 
            // groupBanlist
            // 
            this.groupBanlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBanlist.Controls.Add(this.comboBoxPlayers);
            this.groupBanlist.Controls.Add(this.btAdd);
            this.groupBanlist.Controls.Add(this.btRemove);
            this.groupBanlist.Controls.Add(this.listBanlist);
            this.groupBanlist.Controls.Add(this.btRefresh);
            this.groupBanlist.Location = new System.Drawing.Point(12, 12);
            this.groupBanlist.Name = "groupBanlist";
            this.groupBanlist.Size = new System.Drawing.Size(434, 495);
            this.groupBanlist.TabIndex = 3;
            this.groupBanlist.TabStop = false;
            this.groupBanlist.Text = "Banlist";
            // 
            // comboBoxPlayers
            // 
            this.comboBoxPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPlayers.FormattingEnabled = true;
            this.comboBoxPlayers.Location = new System.Drawing.Point(6, 439);
            this.comboBoxPlayers.Name = "comboBoxPlayers";
            this.comboBoxPlayers.Size = new System.Drawing.Size(422, 21);
            this.comboBoxPlayers.TabIndex = 8;
            this.comboBoxPlayers.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayers_SelectedIndexChanged);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Location = new System.Drawing.Point(6, 466);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(422, 23);
            this.btAdd.TabIndex = 7;
            this.btAdd.Text = "Add Ban";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btRemove
            // 
            this.btRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemove.Location = new System.Drawing.Point(6, 48);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(422, 23);
            this.btRemove.TabIndex = 4;
            this.btRemove.Text = "Remove from Banlist";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // Banlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBanlist);
            this.Name = "Banlist";
            this.Size = new System.Drawing.Size(458, 519);
            this.groupBanlist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.ListBox listBanlist;
        private System.Windows.Forms.GroupBox groupBanlist;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.ComboBox comboBoxPlayers;
    }
}