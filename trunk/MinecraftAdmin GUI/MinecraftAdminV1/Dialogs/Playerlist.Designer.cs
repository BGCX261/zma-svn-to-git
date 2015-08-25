namespace Zicore.MinecraftAdmin
{
    partial class Playerlist
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
            this.listPlayerlist = new System.Windows.Forms.ListBox();
            this.btKick = new System.Windows.Forms.Button();
            this.groupPlayerlist = new System.Windows.Forms.GroupBox();
            this.comboBoxPlayers = new System.Windows.Forms.ComboBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.lbOnline = new System.Windows.Forms.Label();
            this.btRemove = new System.Windows.Forms.Button();
            this.btBan = new System.Windows.Forms.Button();
            this.groupPlayerlist.SuspendLayout();
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
            // listPlayerlist
            // 
            this.listPlayerlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listPlayerlist.FormattingEnabled = true;
            this.listPlayerlist.Location = new System.Drawing.Point(6, 103);
            this.listPlayerlist.Name = "listPlayerlist";
            this.listPlayerlist.Size = new System.Drawing.Size(422, 264);
            this.listPlayerlist.TabIndex = 1;
            // 
            // btKick
            // 
            this.btKick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btKick.Location = new System.Drawing.Point(6, 437);
            this.btKick.Name = "btKick";
            this.btKick.Size = new System.Drawing.Size(422, 23);
            this.btKick.TabIndex = 2;
            this.btKick.Text = "Kick";
            this.btKick.UseVisualStyleBackColor = true;
            this.btKick.Click += new System.EventHandler(this.btKick_Click);
            // 
            // groupPlayerlist
            // 
            this.groupPlayerlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPlayerlist.Controls.Add(this.comboBoxPlayers);
            this.groupPlayerlist.Controls.Add(this.btAdd);
            this.groupPlayerlist.Controls.Add(this.lbOnline);
            this.groupPlayerlist.Controls.Add(this.btRemove);
            this.groupPlayerlist.Controls.Add(this.btBan);
            this.groupPlayerlist.Controls.Add(this.listPlayerlist);
            this.groupPlayerlist.Controls.Add(this.btKick);
            this.groupPlayerlist.Controls.Add(this.btRefresh);
            this.groupPlayerlist.Location = new System.Drawing.Point(12, 12);
            this.groupPlayerlist.Name = "groupPlayerlist";
            this.groupPlayerlist.Size = new System.Drawing.Size(434, 495);
            this.groupPlayerlist.TabIndex = 3;
            this.groupPlayerlist.TabStop = false;
            this.groupPlayerlist.Text = "Playerlist";
            // 
            // comboBoxPlayers
            // 
            this.comboBoxPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPlayers.FormattingEnabled = true;
            this.comboBoxPlayers.Location = new System.Drawing.Point(6, 381);
            this.comboBoxPlayers.Name = "comboBoxPlayers";
            this.comboBoxPlayers.Size = new System.Drawing.Size(422, 21);
            this.comboBoxPlayers.TabIndex = 10;
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Location = new System.Drawing.Point(6, 408);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(422, 23);
            this.btAdd.TabIndex = 9;
            this.btAdd.Text = "Add Player";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // lbOnline
            // 
            this.lbOnline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOnline.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOnline.Location = new System.Drawing.Point(6, 74);
            this.lbOnline.Name = "lbOnline";
            this.lbOnline.Size = new System.Drawing.Size(422, 26);
            this.lbOnline.TabIndex = 6;
            this.lbOnline.Text = "Online:";
            this.lbOnline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRemove
            // 
            this.btRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemove.Location = new System.Drawing.Point(6, 48);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(422, 23);
            this.btRemove.TabIndex = 4;
            this.btRemove.Text = "Remove from Playerlist";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btBan
            // 
            this.btBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btBan.Location = new System.Drawing.Point(6, 466);
            this.btBan.Name = "btBan";
            this.btBan.Size = new System.Drawing.Size(422, 23);
            this.btBan.TabIndex = 3;
            this.btBan.Text = "Ban";
            this.btBan.UseVisualStyleBackColor = true;
            this.btBan.Click += new System.EventHandler(this.btBan_Click);
            // 
            // Playerlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPlayerlist);
            this.Name = "Playerlist";
            this.Size = new System.Drawing.Size(458, 519);
            this.groupPlayerlist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.ListBox listPlayerlist;
        private System.Windows.Forms.Button btKick;
        private System.Windows.Forms.GroupBox groupPlayerlist;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btBan;
        private System.Windows.Forms.Label lbOnline;
        private System.Windows.Forms.ComboBox comboBoxPlayers;
        private System.Windows.Forms.Button btAdd;
    }
}