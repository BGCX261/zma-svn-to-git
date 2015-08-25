namespace Zicore.MinecraftAdmin
{
    partial class WhiteList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhiteList));
            this.btRefresh = new System.Windows.Forms.Button();
            this.listWhitelist = new System.Windows.Forms.ListBox();
            this.groupBanlist = new System.Windows.Forms.GroupBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.tbBan = new System.Windows.Forms.TextBox();
            this.btClose = new System.Windows.Forms.Button();
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
            // listWhitelist
            // 
            this.listWhitelist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listWhitelist.FormattingEnabled = true;
            this.listWhitelist.Location = new System.Drawing.Point(6, 77);
            this.listWhitelist.Name = "listWhitelist";
            this.listWhitelist.Size = new System.Drawing.Size(422, 316);
            this.listWhitelist.TabIndex = 1;
            // 
            // groupBanlist
            // 
            this.groupBanlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBanlist.Controls.Add(this.btAdd);
            this.groupBanlist.Controls.Add(this.tbBan);
            this.groupBanlist.Controls.Add(this.btClose);
            this.groupBanlist.Controls.Add(this.btRemove);
            this.groupBanlist.Controls.Add(this.listWhitelist);
            this.groupBanlist.Controls.Add(this.btRefresh);
            this.groupBanlist.Location = new System.Drawing.Point(12, 12);
            this.groupBanlist.Name = "groupBanlist";
            this.groupBanlist.Size = new System.Drawing.Size(434, 495);
            this.groupBanlist.TabIndex = 3;
            this.groupBanlist.TabStop = false;
            this.groupBanlist.Text = "Whitelist";
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Location = new System.Drawing.Point(6, 437);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(422, 23);
            this.btAdd.TabIndex = 7;
            this.btAdd.Text = "Add Whitelist Entry";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // tbBan
            // 
            this.tbBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBan.Location = new System.Drawing.Point(6, 411);
            this.tbBan.Name = "tbBan";
            this.tbBan.Size = new System.Drawing.Size(422, 20);
            this.tbBan.TabIndex = 6;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Location = new System.Drawing.Point(6, 466);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(422, 23);
            this.btClose.TabIndex = 5;
            this.btClose.Text = "Save";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btRemove
            // 
            this.btRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemove.Location = new System.Drawing.Point(6, 48);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(422, 23);
            this.btRemove.TabIndex = 4;
            this.btRemove.Text = "Remove from Whitelist";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // WhiteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 519);
            this.Controls.Add(this.groupBanlist);
            this.Name = "WhiteList";
            this.Text = "Zicore\'s Minecraft Admintool - Whitelist";
            this.groupBanlist.ResumeLayout(false);
            this.groupBanlist.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.ListBox listWhitelist;
        private System.Windows.Forms.GroupBox groupBanlist;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox tbBan;
    }
}