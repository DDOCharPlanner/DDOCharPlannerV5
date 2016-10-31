namespace DDOCharacterPlanner.Screens.DataInput
    {
    partial class ModifiersPanel2
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
            this.AddButton = new System.Windows.Forms.Button();
            this.ListViewModifiers = new System.Windows.Forms.ListView();
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colModifier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRequirement = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LabelModifiers = new System.Windows.Forms.Label();
            this.ModifiersMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifiersMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.BackColor = System.Drawing.Color.Silver;
            this.AddButton.ForeColor = System.Drawing.Color.Black;
            this.AddButton.Location = new System.Drawing.Point(233, -1);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(40, 20);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ListViewModifiers
            // 
            this.ListViewModifiers.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListViewModifiers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewModifiers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.ListViewModifiers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colType,
            this.colModifier,
            this.colRequirement});
            this.ListViewModifiers.ForeColor = System.Drawing.Color.White;
            this.ListViewModifiers.FullRowSelect = true;
            this.ListViewModifiers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewModifiers.Location = new System.Drawing.Point(0, 21);
            this.ListViewModifiers.MultiSelect = false;
            this.ListViewModifiers.Name = "ListViewModifiers";
            this.ListViewModifiers.Size = new System.Drawing.Size(272, 117);
            this.ListViewModifiers.TabIndex = 1;
            this.ListViewModifiers.UseCompatibleStateImageBehavior = false;
            this.ListViewModifiers.View = System.Windows.Forms.View.Details;
            this.ListViewModifiers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewModifiers_MouseClick);
            this.ListViewModifiers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewModifiers_MouseDoubleClick);
            // 
            // colType
            // 
            this.colType.Text = "Type";
            // 
            // colModifier
            // 
            this.colModifier.Text = "Modifier";
            this.colModifier.Width = 142;
            // 
            // colRequirement
            // 
            this.colRequirement.Text = "Modifier Requirement";
            this.colRequirement.Width = 124;
            // 
            // LabelModifiers
            // 
            this.LabelModifiers.BackColor = System.Drawing.Color.LightSkyBlue;
            this.LabelModifiers.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelModifiers.ForeColor = System.Drawing.Color.White;
            this.LabelModifiers.Location = new System.Drawing.Point(0, 0);
            this.LabelModifiers.Name = "LabelModifiers";
            this.LabelModifiers.Size = new System.Drawing.Size(272, 20);
            this.LabelModifiers.TabIndex = 2;
            this.LabelModifiers.Text = "Modifiers";
            this.LabelModifiers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModifiersMenuStrip
            // 
            this.ModifiersMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditRecordToolStripMenuItem,
            this.DeleteRecordToolStripMenuItem});
            this.ModifiersMenuStrip.Name = "ModifiersMenuStrip";
            this.ModifiersMenuStrip.Size = new System.Drawing.Size(148, 48);
            // 
            // EditRecordToolStripMenuItem
            // 
            this.EditRecordToolStripMenuItem.Name = "EditRecordToolStripMenuItem";
            this.EditRecordToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.EditRecordToolStripMenuItem.Text = "Edit Record";
            this.EditRecordToolStripMenuItem.Click += new System.EventHandler(this.EditRecordToolStripMenuItem_Click);
            // 
            // DeleteRecordToolStripMenuItem
            // 
            this.DeleteRecordToolStripMenuItem.Name = "DeleteRecordToolStripMenuItem";
            this.DeleteRecordToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.DeleteRecordToolStripMenuItem.Text = "Delete Record";
            this.DeleteRecordToolStripMenuItem.Click += new System.EventHandler(this.DeleteRecordToolStripMenuItem_Click);
            // 
            // ModifiersPanel2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListViewModifiers);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.LabelModifiers);
            this.Name = "ModifiersPanel2";
            this.Size = new System.Drawing.Size(272, 138);
            this.Resize += new System.EventHandler(this.ModifiersPanel2_Resize);
            this.ModifiersMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListView ListViewModifiers;
        private System.Windows.Forms.ColumnHeader colModifier;
        private System.Windows.Forms.ColumnHeader colRequirement;
        private System.Windows.Forms.Label LabelModifiers;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ContextMenuStrip ModifiersMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EditRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteRecordToolStripMenuItem;
        }
    }
