namespace DDOCharacterPlanner.Screens.DataInput
    {
    partial class EditModifierDialogClass
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
            this.ModifierTypePanel = new System.Windows.Forms.Panel();
            this.StanceRadioButton = new System.Windows.Forms.RadioButton();
            this.PassiveRadioButton = new System.Windows.Forms.RadioButton();
            this.ModifierTypeLabel = new System.Windows.Forms.Label();
            this.RequirementComboBox = new System.Windows.Forms.ComboBox();
            this.RequirementLabel = new System.Windows.Forms.Label();
            this.ModifierLabel = new System.Windows.Forms.Label();
            this.ModifierComboBox = new System.Windows.Forms.ComboBox();
            this.RequirementValueNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.ModifierValueNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.ModifierValueLabel = new System.Windows.Forms.Label();
            this.RequirementValueLabel = new System.Windows.Forms.Label();
            this.PullFromLabel = new System.Windows.Forms.Label();
            this.PullFromComboBox = new System.Windows.Forms.ComboBox();
            this.StanceLabel = new System.Windows.Forms.Label();
            this.StanceComboBox = new System.Windows.Forms.ComboBox();
            this.ModifierMethodLabel = new System.Windows.Forms.Label();
            this.ModifierMethodComboBox = new System.Windows.Forms.ComboBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelChangesButton = new System.Windows.Forms.Button();
            this.BonusTypeLabel = new System.Windows.Forms.Label();
            this.BonusTypeCombo = new System.Windows.Forms.ComboBox();
            this.ComparisonComboBox = new System.Windows.Forms.ComboBox();
            this.ComparisonLabel = new System.Windows.Forms.Label();
            this.ModifierTypePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RequirementValueNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifierValueNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ModifierTypePanel
            // 
            this.ModifierTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModifierTypePanel.Controls.Add(this.StanceRadioButton);
            this.ModifierTypePanel.Controls.Add(this.PassiveRadioButton);
            this.ModifierTypePanel.Location = new System.Drawing.Point(94, 9);
            this.ModifierTypePanel.Name = "ModifierTypePanel";
            this.ModifierTypePanel.Size = new System.Drawing.Size(148, 27);
            this.ModifierTypePanel.TabIndex = 0;
            // 
            // StanceRadioButton
            // 
            this.StanceRadioButton.AutoSize = true;
            this.StanceRadioButton.ForeColor = System.Drawing.Color.White;
            this.StanceRadioButton.Location = new System.Drawing.Point(79, 4);
            this.StanceRadioButton.Name = "StanceRadioButton";
            this.StanceRadioButton.Size = new System.Drawing.Size(59, 17);
            this.StanceRadioButton.TabIndex = 1;
            this.StanceRadioButton.TabStop = true;
            this.StanceRadioButton.Text = "Stance";
            this.StanceRadioButton.UseVisualStyleBackColor = true;
            this.StanceRadioButton.Click += new System.EventHandler(this.StanceRadioButton_Click);
            // 
            // PassiveRadioButton
            // 
            this.PassiveRadioButton.AutoSize = true;
            this.PassiveRadioButton.ForeColor = System.Drawing.Color.White;
            this.PassiveRadioButton.Location = new System.Drawing.Point(3, 4);
            this.PassiveRadioButton.Name = "PassiveRadioButton";
            this.PassiveRadioButton.Size = new System.Drawing.Size(62, 17);
            this.PassiveRadioButton.TabIndex = 0;
            this.PassiveRadioButton.TabStop = true;
            this.PassiveRadioButton.Text = "Passive";
            this.PassiveRadioButton.UseVisualStyleBackColor = true;
            this.PassiveRadioButton.Click += new System.EventHandler(this.PassiveRadioButton_Click);
            // 
            // ModifierTypeLabel
            // 
            this.ModifierTypeLabel.AutoSize = true;
            this.ModifierTypeLabel.ForeColor = System.Drawing.Color.White;
            this.ModifierTypeLabel.Location = new System.Drawing.Point(12, 16);
            this.ModifierTypeLabel.Name = "ModifierTypeLabel";
            this.ModifierTypeLabel.Size = new System.Drawing.Size(73, 13);
            this.ModifierTypeLabel.TabIndex = 1;
            this.ModifierTypeLabel.Text = "Select a Type";
            // 
            // RequirementComboBox
            // 
            this.RequirementComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RequirementComboBox.FormattingEnabled = true;
            this.RequirementComboBox.Location = new System.Drawing.Point(282, 180);
            this.RequirementComboBox.Name = "RequirementComboBox";
            this.RequirementComboBox.Size = new System.Drawing.Size(196, 21);
            this.RequirementComboBox.TabIndex = 2;
            this.RequirementComboBox.SelectedIndexChanged += new System.EventHandler(this.RequirementComboBox_SelectedIndexChanged);
            // 
            // RequirementLabel
            // 
            this.RequirementLabel.AutoSize = true;
            this.RequirementLabel.ForeColor = System.Drawing.Color.White;
            this.RequirementLabel.Location = new System.Drawing.Point(282, 162);
            this.RequirementLabel.Name = "RequirementLabel";
            this.RequirementLabel.Size = new System.Drawing.Size(109, 13);
            this.RequirementLabel.TabIndex = 3;
            this.RequirementLabel.Text = "Select a Requirement";
            // 
            // ModifierLabel
            // 
            this.ModifierLabel.AutoSize = true;
            this.ModifierLabel.ForeColor = System.Drawing.Color.White;
            this.ModifierLabel.Location = new System.Drawing.Point(37, 61);
            this.ModifierLabel.Name = "ModifierLabel";
            this.ModifierLabel.Size = new System.Drawing.Size(86, 13);
            this.ModifierLabel.TabIndex = 5;
            this.ModifierLabel.Text = "Select a Modifier";
            // 
            // ModifierComboBox
            // 
            this.ModifierComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModifierComboBox.FormattingEnabled = true;
            this.ModifierComboBox.Location = new System.Drawing.Point(37, 79);
            this.ModifierComboBox.Name = "ModifierComboBox";
            this.ModifierComboBox.Size = new System.Drawing.Size(196, 21);
            this.ModifierComboBox.TabIndex = 4;
            this.ModifierComboBox.SelectedIndexChanged += new System.EventHandler(this.ModifierComboBox_SelectedIndexChanged);
            // 
            // RequirementValueNumUpDown
            // 
            this.RequirementValueNumUpDown.DecimalPlaces = 3;
            this.RequirementValueNumUpDown.Location = new System.Drawing.Point(384, 237);
            this.RequirementValueNumUpDown.Name = "RequirementValueNumUpDown";
            this.RequirementValueNumUpDown.Size = new System.Drawing.Size(94, 20);
            this.RequirementValueNumUpDown.TabIndex = 6;
            this.RequirementValueNumUpDown.ValueChanged += new System.EventHandler(this.RequirmentValueNumUpDown_ValueChanged);
            // 
            // ModifierValueNumUpDown
            // 
            this.ModifierValueNumUpDown.DecimalPlaces = 3;
            this.ModifierValueNumUpDown.Location = new System.Drawing.Point(37, 237);
            this.ModifierValueNumUpDown.Name = "ModifierValueNumUpDown";
            this.ModifierValueNumUpDown.Size = new System.Drawing.Size(70, 20);
            this.ModifierValueNumUpDown.TabIndex = 7;
            this.ModifierValueNumUpDown.ValueChanged += new System.EventHandler(this.ModifierValueNumUpDown_ValueChanged);
            // 
            // ModifierValueLabel
            // 
            this.ModifierValueLabel.AutoSize = true;
            this.ModifierValueLabel.ForeColor = System.Drawing.Color.White;
            this.ModifierValueLabel.Location = new System.Drawing.Point(34, 218);
            this.ModifierValueLabel.Name = "ModifierValueLabel";
            this.ModifierValueLabel.Size = new System.Drawing.Size(74, 13);
            this.ModifierValueLabel.TabIndex = 8;
            this.ModifierValueLabel.Text = "Modifier Value";
            // 
            // RequirementValueLabel
            // 
            this.RequirementValueLabel.AutoSize = true;
            this.RequirementValueLabel.ForeColor = System.Drawing.Color.White;
            this.RequirementValueLabel.Location = new System.Drawing.Point(381, 221);
            this.RequirementValueLabel.Name = "RequirementValueLabel";
            this.RequirementValueLabel.Size = new System.Drawing.Size(97, 13);
            this.RequirementValueLabel.TabIndex = 9;
            this.RequirementValueLabel.Text = "Requirement Value";
            // 
            // PullFromLabel
            // 
            this.PullFromLabel.AutoSize = true;
            this.PullFromLabel.ForeColor = System.Drawing.Color.White;
            this.PullFromLabel.Location = new System.Drawing.Point(37, 162);
            this.PullFromLabel.Name = "PullFromLabel";
            this.PullFromLabel.Size = new System.Drawing.Size(82, 13);
            this.PullFromLabel.TabIndex = 11;
            this.PullFromLabel.Text = "Use Value From";
            // 
            // PullFromComboBox
            // 
            this.PullFromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PullFromComboBox.FormattingEnabled = true;
            this.PullFromComboBox.Location = new System.Drawing.Point(37, 180);
            this.PullFromComboBox.Name = "PullFromComboBox";
            this.PullFromComboBox.Size = new System.Drawing.Size(196, 21);
            this.PullFromComboBox.TabIndex = 10;
            this.PullFromComboBox.Visible = false;
            this.PullFromComboBox.SelectedIndexChanged += new System.EventHandler(this.PullFromComboBox_SelectedIndexChanged);
            // 
            // StanceLabel
            // 
            this.StanceLabel.AutoSize = true;
            this.StanceLabel.ForeColor = System.Drawing.Color.White;
            this.StanceLabel.Location = new System.Drawing.Point(282, 61);
            this.StanceLabel.Name = "StanceLabel";
            this.StanceLabel.Size = new System.Drawing.Size(83, 13);
            this.StanceLabel.TabIndex = 13;
            this.StanceLabel.Text = "Select a Stance";
            // 
            // StanceComboBox
            // 
            this.StanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StanceComboBox.FormattingEnabled = true;
            this.StanceComboBox.Location = new System.Drawing.Point(282, 79);
            this.StanceComboBox.Name = "StanceComboBox";
            this.StanceComboBox.Size = new System.Drawing.Size(196, 21);
            this.StanceComboBox.TabIndex = 12;
            this.StanceComboBox.Visible = false;
            this.StanceComboBox.SelectedIndexChanged += new System.EventHandler(this.StanceComboBox_SelectedIndexChanged);
            // 
            // ModifierMethodLabel
            // 
            this.ModifierMethodLabel.AutoSize = true;
            this.ModifierMethodLabel.ForeColor = System.Drawing.Color.White;
            this.ModifierMethodLabel.Location = new System.Drawing.Point(257, 18);
            this.ModifierMethodLabel.Name = "ModifierMethodLabel";
            this.ModifierMethodLabel.Size = new System.Drawing.Size(123, 13);
            this.ModifierMethodLabel.TabIndex = 15;
            this.ModifierMethodLabel.Text = "Select a Modifer Method";
            // 
            // ModifierMethodComboBox
            // 
            this.ModifierMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModifierMethodComboBox.FormattingEnabled = true;
            this.ModifierMethodComboBox.Location = new System.Drawing.Point(386, 12);
            this.ModifierMethodComboBox.Name = "ModifierMethodComboBox";
            this.ModifierMethodComboBox.Size = new System.Drawing.Size(123, 21);
            this.ModifierMethodComboBox.TabIndex = 14;
            this.ModifierMethodComboBox.SelectedIndexChanged += new System.EventHandler(this.ModifierMethodComboBox_SelectedIndexChanged);
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(136, 286);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 16;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelChangesButton
            // 
            this.CancelChangesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelChangesButton.Location = new System.Drawing.Point(260, 286);
            this.CancelChangesButton.Name = "CancelChangesButton";
            this.CancelChangesButton.Size = new System.Drawing.Size(75, 23);
            this.CancelChangesButton.TabIndex = 17;
            this.CancelChangesButton.Text = "Cancel";
            this.CancelChangesButton.UseVisualStyleBackColor = true;
            this.CancelChangesButton.Click += new System.EventHandler(this.CancelChangesButton_Click);
            // 
            // BonusTypeLabel
            // 
            this.BonusTypeLabel.AutoSize = true;
            this.BonusTypeLabel.ForeColor = System.Drawing.Color.White;
            this.BonusTypeLabel.Location = new System.Drawing.Point(37, 113);
            this.BonusTypeLabel.Name = "BonusTypeLabel";
            this.BonusTypeLabel.Size = new System.Drawing.Size(106, 13);
            this.BonusTypeLabel.TabIndex = 19;
            this.BonusTypeLabel.Text = "Select a Bonus Type";
            // 
            // BonusTypeCombo
            // 
            this.BonusTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BonusTypeCombo.FormattingEnabled = true;
            this.BonusTypeCombo.Location = new System.Drawing.Point(37, 131);
            this.BonusTypeCombo.Name = "BonusTypeCombo";
            this.BonusTypeCombo.Size = new System.Drawing.Size(196, 21);
            this.BonusTypeCombo.TabIndex = 18;
            this.BonusTypeCombo.SelectedIndexChanged += new System.EventHandler(this.BonusTypeComboBox_SelectedIndexChanged);
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
            this.ComparisonComboBox.Location = new System.Drawing.Point(282, 237);
            this.ComparisonComboBox.Name = "ComparisonComboBox";
            this.ComparisonComboBox.Size = new System.Drawing.Size(62, 21);
            this.ComparisonComboBox.TabIndex = 20;
            this.ComparisonComboBox.SelectedIndexChanged += new System.EventHandler(this.ComparisonComboBox_SelectedIndexChanged);
            // 
            // ComparisonLabel
            // 
            this.ComparisonLabel.AutoSize = true;
            this.ComparisonLabel.ForeColor = System.Drawing.Color.White;
            this.ComparisonLabel.Location = new System.Drawing.Point(283, 218);
            this.ComparisonLabel.Name = "ComparisonLabel";
            this.ComparisonLabel.Size = new System.Drawing.Size(62, 13);
            this.ComparisonLabel.TabIndex = 21;
            this.ComparisonLabel.Text = "Comparison";
            // 
            // EditModifierDialogClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(535, 320);
            this.Controls.Add(this.ComparisonLabel);
            this.Controls.Add(this.ComparisonComboBox);
            this.Controls.Add(this.BonusTypeLabel);
            this.Controls.Add(this.BonusTypeCombo);
            this.Controls.Add(this.CancelChangesButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ModifierMethodLabel);
            this.Controls.Add(this.ModifierMethodComboBox);
            this.Controls.Add(this.StanceLabel);
            this.Controls.Add(this.StanceComboBox);
            this.Controls.Add(this.PullFromLabel);
            this.Controls.Add(this.PullFromComboBox);
            this.Controls.Add(this.RequirementValueLabel);
            this.Controls.Add(this.ModifierValueLabel);
            this.Controls.Add(this.ModifierValueNumUpDown);
            this.Controls.Add(this.RequirementValueNumUpDown);
            this.Controls.Add(this.ModifierLabel);
            this.Controls.Add(this.ModifierComboBox);
            this.Controls.Add(this.RequirementLabel);
            this.Controls.Add(this.RequirementComboBox);
            this.Controls.Add(this.ModifierTypeLabel);
            this.Controls.Add(this.ModifierTypePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditModifierDialogClass";
            this.Text = "Edit Modifier";
            this.Load += new System.EventHandler(this.EditModifierDialogClass_Load);
            this.ModifierTypePanel.ResumeLayout(false);
            this.ModifierTypePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RequirementValueNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifierValueNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.Panel ModifierTypePanel;
        private System.Windows.Forms.RadioButton StanceRadioButton;
        private System.Windows.Forms.RadioButton PassiveRadioButton;
        private System.Windows.Forms.Label ModifierTypeLabel;
        private System.Windows.Forms.ComboBox RequirementComboBox;
        private System.Windows.Forms.Label RequirementLabel;
        private System.Windows.Forms.Label ModifierLabel;
        private System.Windows.Forms.ComboBox ModifierComboBox;
        private System.Windows.Forms.NumericUpDown RequirementValueNumUpDown;
        private System.Windows.Forms.NumericUpDown ModifierValueNumUpDown;
        private System.Windows.Forms.Label ModifierValueLabel;
        private System.Windows.Forms.Label RequirementValueLabel;
        private System.Windows.Forms.Label PullFromLabel;
        private System.Windows.Forms.ComboBox PullFromComboBox;
        private System.Windows.Forms.Label StanceLabel;
        private System.Windows.Forms.ComboBox StanceComboBox;
        private System.Windows.Forms.Label ModifierMethodLabel;
        private System.Windows.Forms.ComboBox ModifierMethodComboBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelChangesButton;
        private System.Windows.Forms.Label BonusTypeLabel;
        private System.Windows.Forms.ComboBox BonusTypeCombo;
        private System.Windows.Forms.ComboBox ComparisonComboBox;
        private System.Windows.Forms.Label ComparisonLabel;
        }
    }