namespace Zicore.MinecraftAdmin
{
    partial class KitEditor
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
            this.groupKitEditor = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btAddKit = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.listKitlist = new System.Windows.Forms.ListBox();
            this.chkFixed = new System.Windows.Forms.CheckBox();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.groupItem = new System.Windows.Forms.GroupBox();
            this.tbAmount = new System.Windows.Forms.NumericUpDown();
            this.comboBoxID = new System.Windows.Forms.ComboBox();
            this.btRemoveKitItem = new System.Windows.Forms.Button();
            this.btAddItem = new System.Windows.Forms.Button();
            this.btApplyItem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btApplyKit = new System.Windows.Forms.Button();
            this.btRemoveSelected = new System.Windows.Forms.Button();
            this.listSelectedKit = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.groupKitEditor.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupKitEditor
            // 
            this.groupKitEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupKitEditor.Controls.Add(this.splitContainer1);
            this.groupKitEditor.Location = new System.Drawing.Point(12, 12);
            this.groupKitEditor.Name = "groupKitEditor";
            this.groupKitEditor.Size = new System.Drawing.Size(798, 377);
            this.groupKitEditor.TabIndex = 0;
            this.groupKitEditor.TabStop = false;
            this.groupKitEditor.Text = "Kit Editor";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btAddKit);
            this.splitContainer1.Panel1.Controls.Add(this.btRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.listKitlist);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkFixed);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxLevel);
            this.splitContainer1.Panel2.Controls.Add(this.groupItem);
            this.splitContainer1.Panel2.Controls.Add(this.btApplyKit);
            this.splitContainer1.Panel2.Controls.Add(this.btRemoveSelected);
            this.splitContainer1.Panel2.Controls.Add(this.listSelectedKit);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.tbName);
            this.splitContainer1.Size = new System.Drawing.Size(792, 358);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 1;
            // 
            // btAddKit
            // 
            this.btAddKit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddKit.Location = new System.Drawing.Point(3, 326);
            this.btAddKit.Name = "btAddKit";
            this.btAddKit.Size = new System.Drawing.Size(255, 23);
            this.btAddKit.TabIndex = 2;
            this.btAddKit.Text = "Add Kit";
            this.btAddKit.UseVisualStyleBackColor = true;
            this.btAddKit.Click += new System.EventHandler(this.btAddKit_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Location = new System.Drawing.Point(3, 3);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(255, 23);
            this.btRefresh.TabIndex = 1;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // listKitlist
            // 
            this.listKitlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listKitlist.FormattingEnabled = true;
            this.listKitlist.Location = new System.Drawing.Point(3, 32);
            this.listKitlist.Name = "listKitlist";
            this.listKitlist.Size = new System.Drawing.Size(255, 290);
            this.listKitlist.TabIndex = 0;
            this.listKitlist.SelectedIndexChanged += new System.EventHandler(this.listKitlist_SelectedIndexChanged);
            // 
            // chkFixed
            // 
            this.chkFixed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFixed.AutoSize = true;
            this.chkFixed.Location = new System.Drawing.Point(430, 7);
            this.chkFixed.Name = "chkFixed";
            this.chkFixed.Size = new System.Drawing.Size(86, 17);
            this.chkFixed.TabIndex = 13;
            this.chkFixed.Text = "Fix for Group";
            this.chkFixed.UseVisualStyleBackColor = true;
            this.chkFixed.CheckedChanged += new System.EventHandler(this.chkFixed_CheckedChanged);
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(253, 5);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(171, 21);
            this.comboBoxLevel.TabIndex = 12;
            this.comboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel_SelectedIndexChanged);
            // 
            // groupItem
            // 
            this.groupItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupItem.Controls.Add(this.tbAmount);
            this.groupItem.Controls.Add(this.comboBoxID);
            this.groupItem.Controls.Add(this.btRemoveKitItem);
            this.groupItem.Controls.Add(this.btAddItem);
            this.groupItem.Controls.Add(this.btApplyItem);
            this.groupItem.Controls.Add(this.label3);
            this.groupItem.Controls.Add(this.label2);
            this.groupItem.Location = new System.Drawing.Point(6, 274);
            this.groupItem.Name = "groupItem";
            this.groupItem.Size = new System.Drawing.Size(516, 46);
            this.groupItem.TabIndex = 10;
            this.groupItem.TabStop = false;
            this.groupItem.Text = "Selected Kit Item";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(190, 18);
            this.tbAmount.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(73, 20);
            this.tbAmount.TabIndex = 14;
            this.tbAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbAmount.ValueChanged += new System.EventHandler(this.tbAmount_ValueChanged);
            // 
            // comboBoxID
            // 
            this.comboBoxID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxID.FormattingEnabled = true;
            this.comboBoxID.Location = new System.Drawing.Point(6, 18);
            this.comboBoxID.Name = "comboBoxID";
            this.comboBoxID.Size = new System.Drawing.Size(154, 21);
            this.comboBoxID.TabIndex = 13;
            // 
            // btRemoveKitItem
            // 
            this.btRemoveKitItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRemoveKitItem.Location = new System.Drawing.Point(380, 16);
            this.btRemoveKitItem.Name = "btRemoveKitItem";
            this.btRemoveKitItem.Size = new System.Drawing.Size(62, 23);
            this.btRemoveKitItem.TabIndex = 12;
            this.btRemoveKitItem.Text = "Remove";
            this.btRemoveKitItem.UseVisualStyleBackColor = true;
            this.btRemoveKitItem.Click += new System.EventHandler(this.btRemoveKitItem_Click);
            // 
            // btAddItem
            // 
            this.btAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAddItem.Location = new System.Drawing.Point(448, 16);
            this.btAddItem.Name = "btAddItem";
            this.btAddItem.Size = new System.Drawing.Size(62, 23);
            this.btAddItem.TabIndex = 11;
            this.btAddItem.Text = "Add";
            this.btAddItem.UseVisualStyleBackColor = true;
            this.btAddItem.Click += new System.EventHandler(this.btAddItem_Click);
            // 
            // btApplyItem
            // 
            this.btApplyItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btApplyItem.Location = new System.Drawing.Point(318, 16);
            this.btApplyItem.Name = "btApplyItem";
            this.btApplyItem.Size = new System.Drawing.Size(56, 23);
            this.btApplyItem.TabIndex = 10;
            this.btApplyItem.Text = "Apply";
            this.btApplyItem.UseVisualStyleBackColor = true;
            this.btApplyItem.Click += new System.EventHandler(this.btApplyItem_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Amount";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID";
            // 
            // btApplyKit
            // 
            this.btApplyKit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btApplyKit.Location = new System.Drawing.Point(6, 326);
            this.btApplyKit.Name = "btApplyKit";
            this.btApplyKit.Size = new System.Drawing.Size(374, 23);
            this.btApplyKit.TabIndex = 5;
            this.btApplyKit.Text = "Save Kitlist";
            this.btApplyKit.UseVisualStyleBackColor = true;
            this.btApplyKit.Click += new System.EventHandler(this.btApplyKit_Click);
            // 
            // btRemoveSelected
            // 
            this.btRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemoveSelected.Location = new System.Drawing.Point(386, 326);
            this.btRemoveSelected.Name = "btRemoveSelected";
            this.btRemoveSelected.Size = new System.Drawing.Size(136, 23);
            this.btRemoveSelected.TabIndex = 2;
            this.btRemoveSelected.Text = "Remove Kit";
            this.btRemoveSelected.UseVisualStyleBackColor = true;
            this.btRemoveSelected.Click += new System.EventHandler(this.btRemoveSelected_Click);
            // 
            // listSelectedKit
            // 
            this.listSelectedKit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listSelectedKit.FormattingEnabled = true;
            this.listSelectedKit.Location = new System.Drawing.Point(6, 33);
            this.listSelectedKit.Name = "listSelectedKit";
            this.listSelectedKit.Size = new System.Drawing.Size(516, 238);
            this.listSelectedKit.TabIndex = 4;
            this.listSelectedKit.SelectedIndexChanged += new System.EventHandler(this.listSelectedKit_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(6, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 20);
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // KitEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupKitEditor);
            this.Name = "KitEditor";
            this.Size = new System.Drawing.Size(822, 401);
            this.groupKitEditor.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.groupItem.ResumeLayout(false);
            this.groupItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupKitEditor;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listKitlist;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ListBox listSelectedKit;
        private System.Windows.Forms.Button btApplyKit;
        private System.Windows.Forms.Button btRemoveSelected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupItem;
        private System.Windows.Forms.Button btAddItem;
        private System.Windows.Forms.Button btApplyItem;
        private System.Windows.Forms.Button btRemoveKitItem;
        private System.Windows.Forms.Button btAddKit;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.ComboBox comboBoxID;
        private System.Windows.Forms.CheckBox chkFixed;
        private System.Windows.Forms.NumericUpDown tbAmount;
    }
}