namespace DDOCharacterPlanner.Screens.DataInput
    {
    partial class EditRequirementDialogClass
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
            this.RequirementComboBox = new System.Windows.Forms.ComboBox();
            this.RequireAllCheckBox = new System.Windows.Forms.CheckBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelChangesButton = new System.Windows.Forms.Button();
            this.RequirementLabel = new System.Windows.Forms.Label();
            this.RequirementValueLabel = new System.Windows.Forms.Label();
            this.RequirementValueNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.ComparisonComboBox = new System.Windows.Forms.ComboBox();
            this.ComparisonLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RequirementValueNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // RequirementComboBox
            // 
            this.RequirementComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RequirementComboBox.FormattingEnabled = true;
            this.RequirementComboBox.Location = new System.Drawing.Point(12, 33);
            this.RequirementComboBox.Name = "RequirementComboBox";
            this.RequirementComboBox.Size = new System.Drawing.Size(243, 21);
            this.RequirementComboBox.TabIndex = 0;
            this.RequirementComboBox.SelectedIndexChanged += new System.EventHandler(this.RequirementComboBox_SelectedIndexChanged);
            // 
            // RequireAllCheckBox
            // 
            this.RequireAllCheckBox.AutoSize = true;
            this.RequireAllCheckBox.ForeColor = System.Drawing.Color.White;
            this.RequireAllCheckBox.Location = new System.Drawing.Point(173, 86);
            this.RequireAllCheckBox.Name = "RequireAllCheckBox";
            this.RequireAllCheckBox.Size = new System.Drawing.Size(82, 17);
            this.RequireAllCheckBox.TabIndex = 2;
            this.RequireAllCheckBox.Text = "Requires All";
            this.RequireAllCheckBox.UseVisualStyleBackColor = true;
            this.RequireAllCheckBox.CheckedChanged += new System.EventHandler(this.RequireAllCheckBox_CheckedChanged);
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Enabled = false;
            this.OkButton.Location = new System.Drawing.Point(40, 118);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelChangesButton
            // 
            this.CancelChangesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelChangesButton.Location = new System.Drawing.Point(138, 118);
            this.CancelChangesButton.Name = "CancelChangesButton";
            this.CancelChangesButton.Size = new System.Drawing.Size(75, 23);
            this.CancelChangesButton.TabIndex = 4;
            this.CancelChangesButton.Text = "Cancel";
            this.CancelChangesButton.UseVisualStyleBackColor = true;
            this.CancelChangesButton.Click += new System.EventHandler(this.CancelChangesButton_Click);
            // 
            // RequirementLabel
            // 
            this.RequirementLabel.AutoSize = true;
            this.RequirementLabel.ForeColor = System.Drawing.Color.White;
            this.RequirementLabel.Location = new System.Drawing.Point(15, 17);
            this.RequirementLabel.Name = "RequirementLabel";
            this.RequirementLabel.Size = new System.Drawing.Size(109, 13);
            this.RequirementLabel.TabIndex = 5;
            this.RequirementLabel.Text = "Select a Requirement";
            // 
            // RequirementValueLabel
            // 
            this.RequirementValueLabel.AutoSize = true;
            this.RequirementValueLabel.ForeColor = System.Drawing.Color.White;
            this.RequirementValueLabel.Location = new System.Drawing.Point(86, 66);
            this.RequirementValueLabel.Name = "RequirementValueLabel";
            this.RequirementValueLabel.Size = new System.Drawing.Size(70, 13);
            this.RequirementValueLabel.TabIndex = 6;
            this.RequirementValueLabel.Text = "Enter a value";
            // 
            // RequirementValueNumUpDown
            // 
            this.RequirementValueNumUpDown.DecimalPlaces = 3;
            this.RequirementValueNumUpDown.Location = new System.Drawing.Point(89, 82);
            this.RequirementValueNumUpDown.Name = "RequirementValueNumUpDown";
            this.RequirementValueNumUpDown.Size = new System.Drawing.Size(67, 20);
            this.RequirementValueNumUpDown.TabIndex = 7;
            this.RequirementValueNumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RequirementValueNumUpDown.ValueChanged += new System.EventHandler(this.RequirementValueNumUpDown_ValueChanged);
            // 
            // ComparisonComboBox
            // 
            this.ComparisonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComparisonComboBox.FormattingEnabled = true;
            this.ComparisonComboBox.Items.AddRange(new object[] {
            "=",
            "<",
            "<=",
            ">",
            ">=",
            "!="});
            this.ComparisonComboBox.Location = new System.Drawing.Point(12, 82);
            this.ComparisonComboBox.Name = "ComparisonComboBox";
            this.ComparisonComboBox.Size = new System.Drawing.Size(62, 21);
            this.ComparisonComboBox.TabIndex = 8;
            this.ComparisonComboBox.SelectedIndexChanged += new System.EventHandler(this.ComparisonComboBox_SelectedIndexChanged);
            // 
            // ComparisonLabel
            // 
            this.ComparisonLabel.AutoSize = true;
            this.ComparisonLabel.ForeColor = System.Drawing.Color.White;
            this.ComparisonLabel.Location = new System.Drawing.Point(12, 66);
            this.ComparisonLabel.Name = "ComparisonLabel";
            this.ComparisonLabel.Size = new System.Drawing.Size(62, 13);
            this.ComparisonLabel.TabIndex = 9;
            this.ComparisonLabel.Text = "Comparison";
            // 
            // EditRequirementDialogClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(270, 157);
            this.Controls.Add(this.ComparisonLabel);
            this.Controls.Add(this.ComparisonComboBox);
            this.Controls.Add(this.RequirementValueNumUpDown);
            this.Controls.Add(this.RequirementValueLabel);
            this.Controls.Add(this.RequirementLabel);
            this.Controls.Add(this.CancelChangesButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.RequireAllCheckBox);
            this.Controls.Add(this.RequirementComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditRequirementDialogClass";
            this.Text = "EditRequirementDialog";
            this.Load += new System.EventHandler(this.EditRequirementDialogClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RequirementValueNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.ComboBox RequirementComboBox;
        private System.Windows.Forms.CheckBox RequireAllCheckBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelChangesButton;
        private System.Windows.Forms.Label RequirementLabel;
        private System.Windows.Forms.Label RequirementValueLabel;
        private System.Windows.Forms.NumericUpDown RequirementValueNumUpDown;
        private System.Windows.Forms.ComboBox ComparisonComboBox;
        private System.Windows.Forms.Label ComparisonLabel;
        }
    }