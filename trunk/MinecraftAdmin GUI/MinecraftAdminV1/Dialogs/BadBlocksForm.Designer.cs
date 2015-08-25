namespace Zicore.MinecraftAdmin
{
    partial class BadBlocksForm
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
            this.btOk = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.comboBoxItems = new System.Windows.Forms.ComboBox();
            this.dgvBadBlocks = new System.Windows.Forms.DataGridView();
            this.btRemove = new System.Windows.Forms.Button();
            this.btDiscard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBadBlocks)).BeginInit();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(158, 393);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(287, 23);
            this.btOk.TabIndex = 3;
            this.btOk.Text = "Save";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Location = new System.Drawing.Point(451, 364);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(123, 23);
            this.btAdd.TabIndex = 4;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // comboBoxItems
            // 
            this.comboBoxItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxItems.FormattingEnabled = true;
            this.comboBoxItems.Location = new System.Drawing.Point(12, 366);
            this.comboBoxItems.Name = "comboBoxItems";
            this.comboBoxItems.Size = new System.Drawing.Size(433, 21);
            this.comboBoxItems.TabIndex = 5;
            this.comboBoxItems.SelectedIndexChanged += new System.EventHandler(this.comboBoxItems_SelectedIndexChanged);
            // 
            // dgvBadBlocks
            // 
            this.dgvBadBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBadBlocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBadBlocks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBadBlocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBadBlocks.Location = new System.Drawing.Point(12, 12);
            this.dgvBadBlocks.MultiSelect = false;
            this.dgvBadBlocks.Name = "dgvBadBlocks";
            this.dgvBadBlocks.Size = new System.Drawing.Size(562, 340);
            this.dgvBadBlocks.TabIndex = 7;
            this.dgvBadBlocks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBadBlocks_CellClick);
            this.dgvBadBlocks.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvBadBlocks_DataError);
            // 
            // btRemove
            // 
            this.btRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemove.Location = new System.Drawing.Point(451, 393);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(123, 23);
            this.btRemove.TabIndex = 8;
            this.btRemove.Text = "Remove selected";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btDiscard
            // 
            this.btDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDiscard.Location = new System.Drawing.Point(12, 393);
            this.btDiscard.Name = "btDiscard";
            this.btDiscard.Size = new System.Drawing.Size(140, 23);
            this.btDiscard.TabIndex = 9;
            this.btDiscard.Text = "Discard";
            this.btDiscard.UseVisualStyleBackColor = true;
            this.btDiscard.Click += new System.EventHandler(this.btDiscard_Click);
            // 
            // BadBlocksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btDiscard);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.dgvBadBlocks);
            this.Controls.Add(this.comboBoxItems);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btOk);
            this.Name = "BadBlocksForm";
            this.Size = new System.Drawing.Size(586, 428);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBadBlocks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.ComboBox comboBoxItems;
        private System.Windows.Forms.DataGridView dgvBadBlocks;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btDiscard;


    }
}