namespace DDOCharacterPlanner.Screens.DataInput
    {
    partial class RequirementsPanel2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            this.RequiresAllButton = new System.Windows.Forms.Button();
            this.RequiresOneButton = new System.Windows.Forms.Button();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.RequiresAllListBox = new System.Windows.Forms.ListBox();
            this.RequiresOneListBox = new System.Windows.Forms.ListBox();
            this.RequireAllMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditToolStripMenuItemAll = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteRecordToolStripMenuItemAll = new System.Windows.Forms.ToolStripMenuItem();
            this.AddButton = new System.Windows.Forms.Button();
            this.RequireOneMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditToolStripMenuItemOne = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteRecordToolStripMenuItemOne = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.RequireAllMenuStrip.SuspendLayout();
            this.RequireOneMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // RequiresAllButton
            // 
            this.RequiresAllButton.BackColor = System.Drawing.Color.LightGray;
            this.RequiresAllButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.RequiresAllButton.FlatAppearance.BorderSize = 0;
            this.RequiresAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RequiresAllButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequiresAllButton.ForeColor = System.Drawing.Color.Black;
            this.RequiresAllButton.Location = new System.Drawing.Point(0, 0);
            this.RequiresAllButton.Name = "RequiresAllButton";
            this.RequiresAllButton.Size = new System.Drawing.Size(96, 22);
            this.RequiresAllButton.TabIndex = 1;
            this.RequiresAllButton.Text = "Requires All of";
            this.RequiresAllButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RequiresAllButton.UseVisualStyleBackColor = false;
            this.RequiresAllButton.Click += new System.EventHandler(this.OnRequiresAllButtonClick);
            // 
            // RequiresOneButton
            // 
            this.RequiresOneButton.BackColor = System.Drawing.Color.Silver;
            this.RequiresOneButton.FlatAppearance.BorderSize = 0;
            this.RequiresOneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RequiresOneButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequiresOneButton.Location = new System.Drawing.Point(98, 0);
            this.RequiresOneButton.Name = "RequiresOneButton";
            this.RequiresOneButton.Size = new System.Drawing.Size(96, 22);
            this.RequiresOneButton.TabIndex = 2;
            this.RequiresOneButton.Text = "Requires One of";
            this.RequiresOneButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RequiresOneButton.UseVisualStyleBackColor = false;
            this.RequiresOneButton.Click += new System.EventHandler(this.OnRequiresOneButtonClick);
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainSplitContainer.IsSplitterFixed = true;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 23);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.RequiresAllListBox);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.RequiresOneListBox);
            this.MainSplitContainer.Size = new System.Drawing.Size(237, 145);
            this.MainSplitContainer.SplitterDistance = 116;
            this.MainSplitContainer.SplitterWidth = 5;
            this.MainSplitContainer.TabIndex = 5;
            // 
            // RequiresAllListBox
            // 
            this.RequiresAllListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.RequiresAllListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RequiresAllListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequiresAllListBox.ForeColor = System.Drawing.Color.White;
            this.RequiresAllListBox.FormattingEnabled = true;
            this.RequiresAllListBox.Location = new System.Drawing.Point(0, 0);
            this.RequiresAllListBox.Name = "RequiresAllListBox";
            this.RequiresAllListBox.Size = new System.Drawing.Size(116, 145);
            this.RequiresAllListBox.TabIndex = 0;
            this.RequiresAllListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RequiresAllListBox_MouseDoubleClick);
            this.RequiresAllListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RequiresAllListBox_MouseDown);
            // 
            // RequiresOneListBox
            // 
            this.RequiresOneListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.RequiresOneListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RequiresOneListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequiresOneListBox.ForeColor = System.Drawing.Color.White;
            this.RequiresOneListBox.FormattingEnabled = true;
            this.RequiresOneListBox.Location = new System.Drawing.Point(0, 0);
            this.RequiresOneListBox.Name = "RequiresOneListBox";
            this.RequiresOneListBox.Size = new System.Drawing.Size(116, 145);
            this.RequiresOneListBox.TabIndex = 0;
            this.RequiresOneListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RequiresOneListBox_MouseDoubleClick);
            this.RequiresOneListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RequiresOneListBox_MouseDown);
            // 
            // RequireAllMenuStrip
            // 
            this.RequireAllMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditToolStripMenuItemAll,
            this.DeleteRecordToolStripMenuItemAll});
            this.RequireAllMenuStrip.Name = "contextMenuStrip1";
            this.RequireAllMenuStrip.Size = new System.Drawing.Size(148, 48);
            // 
            // EditToolStripMenuItemAll
            // 
            this.EditToolStripMenuItemAll.Name = "EditToolStripMenuItemAll";
            this.EditToolStripMenuItemAll.Size = new System.Drawing.Size(147, 22);
            this.EditToolStripMenuItemAll.Text = "Edit Record";
            this.EditToolStripMenuItemAll.Click += new System.EventHandler(this.EditToolStripMenuItemAll_Click);
            // 
            // DeleteRecordToolStripMenuItemAll
            // 
            this.DeleteRecordToolStripMenuItemAll.Name = "DeleteRecordToolStripMenuItemAll";
            this.DeleteRecordToolStripMenuItemAll.Size = new System.Drawing.Size(147, 22);
            this.DeleteRecordToolStripMenuItemAll.Text = "Delete Record";
            this.DeleteRecordToolStripMenuItemAll.Click += new System.EventHandler(this.DeleteToolStripMenuItemAll_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddButton.Image = global::DDOCharacterPlanner.Properties.Resources.Add;
            this.AddButton.Location = new System.Drawing.Point(209, 0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(27, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RequireOneMenuStrip
            // 
            this.RequireOneMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditToolStripMenuItemOne,
            this.DeleteRecordToolStripMenuItemOne});
            this.RequireOneMenuStrip.Name = "RequireOneMenuStrip";
            this.RequireOneMenuStrip.Size = new System.Drawing.Size(148, 48);
            // 
            // EditToolStripMenuItemOne
            // 
            this.EditToolStripMenuItemOne.Name = "EditToolStripMenuItemOne";
            this.EditToolStripMenuItemOne.Size = new System.Drawing.Size(147, 22);
            this.EditToolStripMenuItemOne.Text = "Edit Record";
            this.EditToolStripMenuItemOne.Click += new System.EventHandler(this.EditToolStripMenuItemOne_Click);
            // 
            // DeleteRecordToolStripMenuItemOne
            // 
            this.DeleteRecordToolStripMenuItemOne.Name = "DeleteRecordToolStripMenuItemOne";
            this.DeleteRecordToolStripMenuItemOne.Size = new System.Drawing.Size(147, 22);
            this.DeleteRecordToolStripMenuItemOne.Text = "Delete Record";
            this.DeleteRecordToolStripMenuItemOne.Click += new System.EventHandler(this.DeleteToolStripMenuItemOne_Click);
            // 
            // RequirementsPanel2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.RequiresOneButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RequiresAllButton);
            this.MinimumSize = new System.Drawing.Size(240, 80);
            this.Name = "RequirementsPanel2";
            this.Size = new System.Drawing.Size(240, 170);
            this.Resize += new System.EventHandler(this.RequirementsPanel2_Resize);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.RequireAllMenuStrip.ResumeLayout(false);
            this.RequireOneMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RequiresAllButton;
        private System.Windows.Forms.Button RequiresOneButton;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ListBox RequiresAllListBox;
        private System.Windows.Forms.ListBox RequiresOneListBox;
        private System.Windows.Forms.ContextMenuStrip RequireAllMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItemAll;
        private System.Windows.Forms.ToolStripMenuItem DeleteRecordToolStripMenuItemAll;
        private System.Windows.Forms.ContextMenuStrip RequireOneMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItemOne;
        private System.Windows.Forms.ToolStripMenuItem DeleteRecordToolStripMenuItemOne;
        }
    }
