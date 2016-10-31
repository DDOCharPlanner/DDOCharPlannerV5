namespace DDOCharacterPlanner.Screens.DataInput
	{
	partial class DataInputTomeScreenClass
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
            this.SaveLabel = new System.Windows.Forms.Label();
            this.ModVersionLabel = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.ModDateLabel = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.RecordGUIDLabel = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.DeleteRecordButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.TomeListBox = new System.Windows.Forms.ListBox();
            this.NewTomeButton = new System.Windows.Forms.Button();
            this.DuplicateRecordButton = new System.Windows.Forms.Button();
            this.TomeTypeAbilityRadioButton = new System.Windows.Forms.RadioButton();
            this.TomeTypeSkillRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ModifierListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TomeBonusInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MinimumLevelInputUpDown = new System.Windows.Forms.NumericUpDown();
            this.TomeNameInputBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TomeNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TomeBonusInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumLevelInputUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveLabel
            // 
            this.SaveLabel.AutoSize = true;
            this.SaveLabel.ForeColor = System.Drawing.Color.DimGray;
            this.SaveLabel.Location = new System.Drawing.Point(285, 386);
            this.SaveLabel.Name = "SaveLabel";
            this.SaveLabel.Size = new System.Drawing.Size(0, 13);
            this.SaveLabel.TabIndex = 0;
            // 
            // ModVersionLabel
            // 
            this.ModVersionLabel.AutoSize = true;
            this.ModVersionLabel.ForeColor = System.Drawing.Color.DimGray;
            this.ModVersionLabel.Location = new System.Drawing.Point(290, 421);
            this.ModVersionLabel.Name = "ModVersionLabel";
            this.ModVersionLabel.Size = new System.Drawing.Size(66, 13);
            this.ModVersionLabel.TabIndex = 254;
            this.ModVersionLabel.Text = "Mod Version";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ForeColor = System.Drawing.Color.DimGray;
            this.label43.Location = new System.Drawing.Point(277, 406);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(114, 13);
            this.label43.TabIndex = 253;
            this.label43.Text = "Using Planner Version:";
            // 
            // ModDateLabel
            // 
            this.ModDateLabel.AutoSize = true;
            this.ModDateLabel.ForeColor = System.Drawing.Color.DimGray;
            this.ModDateLabel.Location = new System.Drawing.Point(284, 458);
            this.ModDateLabel.Name = "ModDateLabel";
            this.ModDateLabel.Size = new System.Drawing.Size(54, 13);
            this.ModDateLabel.TabIndex = 252;
            this.ModDateLabel.Text = "Mod Date";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.ForeColor = System.Drawing.Color.DimGray;
            this.label41.Location = new System.Drawing.Point(276, 443);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(90, 13);
            this.label41.TabIndex = 251;
            this.label41.Text = "Last Modification:";
            // 
            // RecordGUIDLabel
            // 
            this.RecordGUIDLabel.AutoSize = true;
            this.RecordGUIDLabel.ForeColor = System.Drawing.Color.DimGray;
            this.RecordGUIDLabel.Location = new System.Drawing.Point(284, 495);
            this.RecordGUIDLabel.Name = "RecordGUIDLabel";
            this.RecordGUIDLabel.Size = new System.Drawing.Size(72, 13);
            this.RecordGUIDLabel.TabIndex = 250;
            this.RecordGUIDLabel.Text = "Record GUID";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.ForeColor = System.Drawing.Color.DimGray;
            this.label39.Location = new System.Drawing.Point(276, 480);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(75, 13);
            this.label39.TabIndex = 249;
            this.label39.Text = "Record GUID:";
            // 
            // DeleteRecordButton
            // 
            this.DeleteRecordButton.Location = new System.Drawing.Point(15, 485);
            this.DeleteRecordButton.Name = "DeleteRecordButton";
            this.DeleteRecordButton.Size = new System.Drawing.Size(87, 23);
            this.DeleteRecordButton.TabIndex = 260;
            this.DeleteRecordButton.TabStop = false;
            this.DeleteRecordButton.Text = "Delete Record";
            this.DeleteRecordButton.UseVisualStyleBackColor = true;
            this.DeleteRecordButton.Click += new System.EventHandler(this.OnDeleteRecordButtonClick);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(366, 357);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 259;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(285, 357);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 258;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.OnUpdateButtonClick);
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Blue;
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(12, 11);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(471, 23);
            this.label35.TabIndex = 262;
            this.label35.Text = "List of Tomes";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TomeListBox
            // 
            this.TomeListBox.FormattingEnabled = true;
            this.TomeListBox.Location = new System.Drawing.Point(12, 34);
            this.TomeListBox.Name = "TomeListBox";
            this.TomeListBox.Size = new System.Drawing.Size(471, 134);
            this.TomeListBox.TabIndex = 261;
            this.TomeListBox.TabStop = false;
            this.TomeListBox.SelectedIndexChanged += new System.EventHandler(this.OnTomeListBoxSelectedIndexChanged);
            // 
            // NewTomeButton
            // 
            this.NewTomeButton.Location = new System.Drawing.Point(12, 203);
            this.NewTomeButton.Name = "NewTomeButton";
            this.NewTomeButton.Size = new System.Drawing.Size(120, 23);
            this.NewTomeButton.TabIndex = 263;
            this.NewTomeButton.TabStop = false;
            this.NewTomeButton.Text = "Create New Tome";
            this.NewTomeButton.UseVisualStyleBackColor = true;
            this.NewTomeButton.Click += new System.EventHandler(this.OnNewTomeButtonClick);
            // 
            // DuplicateRecordButton
            // 
            this.DuplicateRecordButton.Location = new System.Drawing.Point(12, 232);
            this.DuplicateRecordButton.Name = "DuplicateRecordButton";
            this.DuplicateRecordButton.Size = new System.Drawing.Size(120, 23);
            this.DuplicateRecordButton.TabIndex = 264;
            this.DuplicateRecordButton.TabStop = false;
            this.DuplicateRecordButton.Text = "Duplicate Record";
            this.DuplicateRecordButton.UseVisualStyleBackColor = true;
            this.DuplicateRecordButton.Click += new System.EventHandler(this.OnDuplicateRecordButtonClick);
            // 
            // TomeTypeAbilityRadioButton
            // 
            this.TomeTypeAbilityRadioButton.AutoSize = true;
            this.TomeTypeAbilityRadioButton.Checked = true;
            this.TomeTypeAbilityRadioButton.ForeColor = System.Drawing.Color.White;
            this.TomeTypeAbilityRadioButton.Location = new System.Drawing.Point(156, 195);
            this.TomeTypeAbilityRadioButton.Name = "TomeTypeAbilityRadioButton";
            this.TomeTypeAbilityRadioButton.Size = new System.Drawing.Size(52, 17);
            this.TomeTypeAbilityRadioButton.TabIndex = 265;
            this.TomeTypeAbilityRadioButton.TabStop = true;
            this.TomeTypeAbilityRadioButton.Text = "Ability";
            this.TomeTypeAbilityRadioButton.UseVisualStyleBackColor = true;
            this.TomeTypeAbilityRadioButton.CheckedChanged += new System.EventHandler(this.OnTomeTypeAbilityRadioButtonCheckedChanged);
            // 
            // TomeTypeSkillRadioButton
            // 
            this.TomeTypeSkillRadioButton.AutoSize = true;
            this.TomeTypeSkillRadioButton.ForeColor = System.Drawing.Color.White;
            this.TomeTypeSkillRadioButton.Location = new System.Drawing.Point(224, 196);
            this.TomeTypeSkillRadioButton.Name = "TomeTypeSkillRadioButton";
            this.TomeTypeSkillRadioButton.Size = new System.Drawing.Size(44, 17);
            this.TomeTypeSkillRadioButton.TabIndex = 266;
            this.TomeTypeSkillRadioButton.Text = "Skill";
            this.TomeTypeSkillRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(147, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 267;
            this.label1.Text = "Tome Type";
            // 
            // ModifierListBox
            // 
            this.ModifierListBox.FormattingEnabled = true;
            this.ModifierListBox.Location = new System.Drawing.Point(148, 236);
            this.ModifierListBox.Name = "ModifierListBox";
            this.ModifierListBox.Size = new System.Drawing.Size(120, 277);
            this.ModifierListBox.TabIndex = 268;
            this.ModifierListBox.TabStop = false;
            this.ModifierListBox.SelectedValueChanged += new System.EventHandler(this.OnModifierListBoxSelectedValueChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Blue;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(148, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 269;
            this.label2.Text = "Modifies";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TomeBonusInput
            // 
            this.TomeBonusInput.Location = new System.Drawing.Point(309, 299);
            this.TomeBonusInput.Name = "TomeBonusInput";
            this.TomeBonusInput.Size = new System.Drawing.Size(41, 20);
            this.TomeBonusInput.TabIndex = 270;
            this.TomeBonusInput.ValueChanged += new System.EventHandler(this.OnTomeBonusInputValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(289, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 271;
            this.label3.Text = "Tome Bonus";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(390, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 273;
            this.label4.Text = "Minimum Level";
            // 
            // MinimumLevelInputUpDown
            // 
            this.MinimumLevelInputUpDown.Location = new System.Drawing.Point(410, 299);
            this.MinimumLevelInputUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.MinimumLevelInputUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinimumLevelInputUpDown.Name = "MinimumLevelInputUpDown";
            this.MinimumLevelInputUpDown.Size = new System.Drawing.Size(41, 20);
            this.MinimumLevelInputUpDown.TabIndex = 272;
            this.MinimumLevelInputUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinimumLevelInputUpDown.ValueChanged += new System.EventHandler(this.OnMinimumLevelInputUpDownValueChanged);
            // 
            // TomeNameInputBox
            // 
            this.TomeNameInputBox.Location = new System.Drawing.Point(288, 219);
            this.TomeNameInputBox.Name = "TomeNameInputBox";
            this.TomeNameInputBox.Size = new System.Drawing.Size(196, 20);
            this.TomeNameInputBox.TabIndex = 274;
            this.TomeNameInputBox.TextChanged += new System.EventHandler(this.OnTomeNameInputBoxTextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(286, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 275;
            this.label5.Text = "Tome Name";
            // 
            // TomeNameLabel
            // 
            this.TomeNameLabel.AutoSize = true;
            this.TomeNameLabel.ForeColor = System.Drawing.Color.White;
            this.TomeNameLabel.Location = new System.Drawing.Point(285, 178);
            this.TomeNameLabel.Name = "TomeNameLabel";
            this.TomeNameLabel.Size = new System.Drawing.Size(94, 13);
            this.TomeNameLabel.TabIndex = 276;
            this.TomeNameLabel.Text = "Tome Name Label";
            // 
            // DataInputTomeScreenClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(497, 525);
            this.Controls.Add(this.TomeNameLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TomeNameInputBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MinimumLevelInputUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TomeBonusInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ModifierListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TomeTypeSkillRadioButton);
            this.Controls.Add(this.TomeTypeAbilityRadioButton);
            this.Controls.Add(this.DuplicateRecordButton);
            this.Controls.Add(this.NewTomeButton);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.TomeListBox);
            this.Controls.Add(this.DeleteRecordButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.ModVersionLabel);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.ModDateLabel);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.RecordGUIDLabel);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.SaveLabel);
            this.Name = "DataInputTomeScreenClass";
            this.Text = "DataInputTomeClass";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.TomeBonusInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumLevelInputUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Label SaveLabel;
		private System.Windows.Forms.Label ModVersionLabel;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label ModDateLabel;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label RecordGUIDLabel;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Button DeleteRecordButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button UpdateButton;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.ListBox TomeListBox;
		private System.Windows.Forms.Button NewTomeButton;
		private System.Windows.Forms.Button DuplicateRecordButton;
		private System.Windows.Forms.RadioButton TomeTypeAbilityRadioButton;
		private System.Windows.Forms.RadioButton TomeTypeSkillRadioButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox ModifierListBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown TomeBonusInput;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown MinimumLevelInputUpDown;
		private System.Windows.Forms.TextBox TomeNameInputBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label TomeNameLabel;
		}
	}