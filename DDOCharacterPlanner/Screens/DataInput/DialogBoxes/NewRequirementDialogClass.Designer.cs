namespace DDOCharacterPlanner.Screens.DataInput
    {
    partial class NewRequirementDialogClass
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
            this.NameBorderPanel = new System.Windows.Forms.Panel();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.CancelChangesButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ApplyToLabel = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.ApplyToComboBox = new System.Windows.Forms.ComboBox();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.TreeLabel = new System.Windows.Forms.Label();
            this.TreeComboBox = new System.Windows.Forms.ComboBox();
            this.SlotLabel = new System.Windows.Forms.Label();
            this.SlotComboBox = new System.Windows.Forms.ComboBox();
            this.NameBorderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameBorderPanel
            // 
            this.NameBorderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameBorderPanel.BackColor = System.Drawing.Color.Red;
            this.NameBorderPanel.Controls.Add(this.NameTextBox);
            this.NameBorderPanel.Location = new System.Drawing.Point(12, 228);
            this.NameBorderPanel.Name = "NameBorderPanel";
            this.NameBorderPanel.Size = new System.Drawing.Size(201, 24);
            this.NameBorderPanel.TabIndex = 17;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Enabled = false;
            this.NameTextBox.Location = new System.Drawing.Point(2, 2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(196, 20);
            this.NameTextBox.TabIndex = 3;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBoxTextChanged);
            // 
            // CancelChangesButton
            // 
            this.CancelChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelChangesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelChangesButton.Location = new System.Drawing.Point(119, 263);
            this.CancelChangesButton.Name = "CancelChangesButton";
            this.CancelChangesButton.Size = new System.Drawing.Size(75, 23);
            this.CancelChangesButton.TabIndex = 16;
            this.CancelChangesButton.Text = "Cancel";
            this.CancelChangesButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Enabled = false;
            this.OkButton.Location = new System.Drawing.Point(31, 263);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 15;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Select a Category";
            // 
            // ApplyToLabel
            // 
            this.ApplyToLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ApplyToLabel.AutoSize = true;
            this.ApplyToLabel.ForeColor = System.Drawing.Color.White;
            this.ApplyToLabel.Location = new System.Drawing.Point(12, 164);
            this.ApplyToLabel.Name = "ApplyToLabel";
            this.ApplyToLabel.Size = new System.Drawing.Size(49, 13);
            this.ApplyToLabel.TabIndex = 13;
            this.ApplyToLabel.Text = "Apply To";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(12, 211);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Name";
            // 
            // ApplyToComboBox
            // 
            this.ApplyToComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ApplyToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ApplyToComboBox.FormattingEnabled = true;
            this.ApplyToComboBox.Location = new System.Drawing.Point(12, 183);
            this.ApplyToComboBox.Name = "ApplyToComboBox";
            this.ApplyToComboBox.Size = new System.Drawing.Size(191, 21);
            this.ApplyToComboBox.Sorted = true;
            this.ApplyToComboBox.TabIndex = 11;
            this.ApplyToComboBox.SelectedIndexChanged += new System.EventHandler(this.ApplyToComboBox_SelectedIndexChanged);
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(12, 31);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.CategoryComboBox.Sorted = true;
            this.CategoryComboBox.TabIndex = 10;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // TreeLabel
            // 
            this.TreeLabel.AutoSize = true;
            this.TreeLabel.ForeColor = System.Drawing.Color.White;
            this.TreeLabel.Location = new System.Drawing.Point(12, 61);
            this.TreeLabel.Name = "TreeLabel";
            this.TreeLabel.Size = new System.Drawing.Size(146, 13);
            this.TreeLabel.TabIndex = 19;
            this.TreeLabel.Text = "Select an Enhancement Tree";
            // 
            // TreeComboBox
            // 
            this.TreeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TreeComboBox.FormattingEnabled = true;
            this.TreeComboBox.Location = new System.Drawing.Point(12, 80);
            this.TreeComboBox.Name = "TreeComboBox";
            this.TreeComboBox.Size = new System.Drawing.Size(191, 21);
            this.TreeComboBox.Sorted = true;
            this.TreeComboBox.TabIndex = 18;
            this.TreeComboBox.SelectedIndexChanged += new System.EventHandler(this.TreeComboBox_SelectedIndexChanged);
            // 
            // SlotLabel
            // 
            this.SlotLabel.AutoSize = true;
            this.SlotLabel.ForeColor = System.Drawing.Color.White;
            this.SlotLabel.Location = new System.Drawing.Point(12, 112);
            this.SlotLabel.Name = "SlotLabel";
            this.SlotLabel.Size = new System.Drawing.Size(142, 13);
            this.SlotLabel.TabIndex = 21;
            this.SlotLabel.Text = "Select an Enhancement Slot";
            // 
            // SlotComboBox
            // 
            this.SlotComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SlotComboBox.FormattingEnabled = true;
            this.SlotComboBox.Location = new System.Drawing.Point(12, 131);
            this.SlotComboBox.Name = "SlotComboBox";
            this.SlotComboBox.Size = new System.Drawing.Size(191, 21);
            this.SlotComboBox.Sorted = true;
            this.SlotComboBox.TabIndex = 20;
            this.SlotComboBox.SelectedIndexChanged += new System.EventHandler(this.SlotComboBox_SelectedIndexChanged);
            // 
            // NewRequirementDialogClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(224, 301);
            this.ControlBox = false;
            this.Controls.Add(this.SlotLabel);
            this.Controls.Add(this.SlotComboBox);
            this.Controls.Add(this.TreeLabel);
            this.Controls.Add(this.TreeComboBox);
            this.Controls.Add(this.NameBorderPanel);
            this.Controls.Add(this.CancelChangesButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ApplyToLabel);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.ApplyToComboBox);
            this.Controls.Add(this.CategoryComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewRequirementDialogClass";
            this.Text = "New Requirement";
            this.NameBorderPanel.ResumeLayout(false);
            this.NameBorderPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.Panel NameBorderPanel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button CancelChangesButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ApplyToLabel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox ApplyToComboBox;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.Label TreeLabel;
        private System.Windows.Forms.ComboBox TreeComboBox;
        private System.Windows.Forms.Label SlotLabel;
        private System.Windows.Forms.ComboBox SlotComboBox;
        }
    }