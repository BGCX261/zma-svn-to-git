namespace Zicore.MinecraftAdmin
{
    partial class GroupEditor
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
            this.splitContainer1 = new Zicore.MinecraftAdmin.EnhancedSplitContainer();
            this.dgvLevels = new System.Windows.Forms.DataGridView();
            this.tbHelpText = new System.Windows.Forms.TextBox();
            this.btDiscard = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listAssignedCommands = new System.Windows.Forms.ListBox();
            this.btOk = new System.Windows.Forms.Button();
            this.btLeft = new System.Windows.Forms.Button();
            this.listCommandsAvailable = new System.Windows.Forms.ListBox();
            this.btRight = new System.Windows.Forms.Button();
            this.lbCmdHelpText = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLevels)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvLevels);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbCmdHelpText);
            this.splitContainer1.Panel2.Controls.Add(this.tbHelpText);
            this.splitContainer1.Panel2.Controls.Add(this.btDiscard);
            this.splitContainer1.Panel2.Controls.Add(this.btRefresh);
            this.splitContainer1.Panel2.Controls.Add(this.btRemove);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.listAssignedCommands);
            this.splitContainer1.Panel2.Controls.Add(this.btOk);
            this.splitContainer1.Panel2.Controls.Add(this.btLeft);
            this.splitContainer1.Panel2.Controls.Add(this.listCommandsAvailable);
            this.splitContainer1.Panel2.Controls.Add(this.btRight);
            this.splitContainer1.Size = new System.Drawing.Size(745, 558);
            this.splitContainer1.SplitterColor = System.Drawing.Color.LightBlue;
            this.splitContainer1.SplitterDistance = 226;
            this.splitContainer1.TabIndex = 6;
            // 
            // dgvLevels
            // 
            this.dgvLevels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLevels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLevels.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLevels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLevels.Location = new System.Drawing.Point(3, 3);
            this.dgvLevels.Name = "dgvLevels";
            this.dgvLevels.Size = new System.Drawing.Size(739, 220);
            this.dgvLevels.TabIndex = 0;
            this.dgvLevels.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLevels_CellClick_1);
            this.dgvLevels.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLevels_CellClick);
            this.dgvLevels.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLevels_ColumnHeaderMouseClick);
            this.dgvLevels.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvLevels_DataError);
            // 
            // tbHelpText
            // 
            this.tbHelpText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHelpText.Location = new System.Drawing.Point(238, 183);
            this.tbHelpText.Multiline = true;
            this.tbHelpText.Name = "tbHelpText";
            this.tbHelpText.ReadOnly = true;
            this.tbHelpText.Size = new System.Drawing.Size(269, 106);
            this.tbHelpText.TabIndex = 11;
            // 
            // btDiscard
            // 
            this.btDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btDiscard.Location = new System.Drawing.Point(238, 141);
            this.btDiscard.Name = "btDiscard";
            this.btDiscard.Size = new System.Drawing.Size(269, 23);
            this.btDiscard.TabIndex = 10;
            this.btDiscard.Text = "Discard Changes";
            this.btDiscard.UseVisualStyleBackColor = true;
            this.btDiscard.Click += new System.EventHandler(this.btDiscard_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(238, 112);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(269, 23);
            this.btRefresh.TabIndex = 9;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // btRemove
            // 
            this.btRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemove.Location = new System.Drawing.Point(238, 83);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(269, 23);
            this.btRemove.TabIndex = 8;
            this.btRemove.Text = "Remove Group";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(513, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Available Commands";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Group Commands";
            // 
            // listAssignedCommands
            // 
            this.listAssignedCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listAssignedCommands.FormattingEnabled = true;
            this.listAssignedCommands.Location = new System.Drawing.Point(12, 25);
            this.listAssignedCommands.Name = "listAssignedCommands";
            this.listAssignedCommands.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listAssignedCommands.Size = new System.Drawing.Size(220, 264);
            this.listAssignedCommands.TabIndex = 2;
            this.listAssignedCommands.SelectedIndexChanged += new System.EventHandler(this.listAssignedCommands_SelectedIndexChanged);
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(3, 302);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(739, 23);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "Save";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btLeft
            // 
            this.btLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btLeft.Location = new System.Drawing.Point(238, 54);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(269, 23);
            this.btLeft.TabIndex = 5;
            this.btLeft.Text = "<<";
            this.btLeft.UseVisualStyleBackColor = true;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // listCommandsAvailable
            // 
            this.listCommandsAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listCommandsAvailable.FormattingEnabled = true;
            this.listCommandsAvailable.Location = new System.Drawing.Point(513, 25);
            this.listCommandsAvailable.Name = "listCommandsAvailable";
            this.listCommandsAvailable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listCommandsAvailable.Size = new System.Drawing.Size(220, 264);
            this.listCommandsAvailable.TabIndex = 3;
            this.listCommandsAvailable.SelectedIndexChanged += new System.EventHandler(this.listCommandsAvailable_SelectedIndexChanged);
            // 
            // btRight
            // 
            this.btRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btRight.Location = new System.Drawing.Point(238, 25);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(269, 23);
            this.btRight.TabIndex = 4;
            this.btRight.Text = ">>";
            this.btRight.UseVisualStyleBackColor = true;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // lbCmdHelpText
            // 
            this.lbCmdHelpText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCmdHelpText.AutoSize = true;
            this.lbCmdHelpText.Location = new System.Drawing.Point(238, 167);
            this.lbCmdHelpText.Name = "lbCmdHelpText";
            this.lbCmdHelpText.Size = new System.Drawing.Size(79, 13);
            this.lbCmdHelpText.TabIndex = 12;
            this.lbCmdHelpText.Text = "Command Help";
            // 
            // GroupEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "GroupEditor";
            this.Size = new System.Drawing.Size(745, 558);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLevels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLevels;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.ListBox listAssignedCommands;
        private System.Windows.Forms.ListBox listCommandsAvailable;
        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Button btLeft;
        private Zicore.MinecraftAdmin.EnhancedSplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Button btDiscard;
        private System.Windows.Forms.TextBox tbHelpText;
        private System.Windows.Forms.Label lbCmdHelpText;
    }
}