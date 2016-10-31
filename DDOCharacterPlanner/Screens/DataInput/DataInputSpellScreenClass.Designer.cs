namespace DDOCharacterPlanner.Screens.DataInput
	{
	partial class DataInputSpellScreenClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataInputSpellScreenClass));
            this.label35 = new System.Windows.Forms.Label();
            this.SpellListBox = new System.Windows.Forms.ListBox();
            this.label40 = new System.Windows.Forms.Label();
            this.RecordFilterBox = new System.Windows.Forms.TextBox();
            this.SaveFeedbackLabel = new System.Windows.Forms.Label();
            this.ModVersionLabel = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.ModDateLabel = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.RecordGUIDLabel = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.NewSpellButton = new System.Windows.Forms.Button();
            this.DeleteRecordButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.SpellNameInputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SpellSchoolComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DescriptionEditButton = new System.Windows.Forms.Button();
            this.DescriptionPreview = new System.Windows.Forms.WebBrowser();
            this.label3 = new System.Windows.Forms.Label();
            this.ComponentCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MetamagicFeatCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.RangeInputComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TargetCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.DurationInputTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SavingThrowComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SpellResistanceComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SpellIconInputBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SPCostUpDown = new System.Windows.Forms.NumericUpDown();
            this.ClassAddButton = new System.Windows.Forms.Button();
            this.CooldownInputBox = new System.Windows.Forms.TextBox();
            this.LevelSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.ClassSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.SpellDetailSubPanel = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ClassIconBrowseButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SPCostUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Blue;
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(12, 9);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(120, 23);
            this.label35.TabIndex = 146;
            this.label35.Text = "List of Spells";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SpellListBox
            // 
            this.SpellListBox.FormattingEnabled = true;
            this.SpellListBox.Location = new System.Drawing.Point(12, 31);
            this.SpellListBox.Name = "SpellListBox";
            this.SpellListBox.Size = new System.Drawing.Size(120, 316);
            this.SpellListBox.TabIndex = 147;
            this.SpellListBox.TabStop = false;
            this.SpellListBox.SelectedIndexChanged += new System.EventHandler(this.OnSpellListBoxSelectedIndexChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.Color.DimGray;
            this.label40.Location = new System.Drawing.Point(9, 352);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(29, 13);
            this.label40.TabIndex = 251;
            this.label40.Text = "Filter";
            // 
            // RecordFilterBox
            // 
            this.RecordFilterBox.Location = new System.Drawing.Point(12, 368);
            this.RecordFilterBox.Name = "RecordFilterBox";
            this.RecordFilterBox.Size = new System.Drawing.Size(120, 20);
            this.RecordFilterBox.TabIndex = 250;
            this.RecordFilterBox.TabStop = false;
            this.RecordFilterBox.TextChanged += new System.EventHandler(this.OnRecordFilterBoxTextChanged);
            // 
            // SaveFeedbackLabel
            // 
            this.SaveFeedbackLabel.AutoSize = true;
            this.SaveFeedbackLabel.ForeColor = System.Drawing.Color.Green;
            this.SaveFeedbackLabel.Location = new System.Drawing.Point(513, 465);
            this.SaveFeedbackLabel.Name = "SaveFeedbackLabel";
            this.SaveFeedbackLabel.Size = new System.Drawing.Size(0, 13);
            this.SaveFeedbackLabel.TabIndex = 265;
            // 
            // ModVersionLabel
            // 
            this.ModVersionLabel.AutoSize = true;
            this.ModVersionLabel.ForeColor = System.Drawing.Color.DimGray;
            this.ModVersionLabel.Location = new System.Drawing.Point(668, 499);
            this.ModVersionLabel.Name = "ModVersionLabel";
            this.ModVersionLabel.Size = new System.Drawing.Size(66, 13);
            this.ModVersionLabel.TabIndex = 264;
            this.ModVersionLabel.Text = "Mod Version";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ForeColor = System.Drawing.Color.DimGray;
            this.label43.Location = new System.Drawing.Point(655, 484);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(114, 13);
            this.label43.TabIndex = 263;
            this.label43.Text = "Using Planner Version:";
            // 
            // ModDateLabel
            // 
            this.ModDateLabel.AutoSize = true;
            this.ModDateLabel.ForeColor = System.Drawing.Color.DimGray;
            this.ModDateLabel.Location = new System.Drawing.Point(521, 499);
            this.ModDateLabel.Name = "ModDateLabel";
            this.ModDateLabel.Size = new System.Drawing.Size(54, 13);
            this.ModDateLabel.TabIndex = 262;
            this.ModDateLabel.Text = "Mod Date";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.ForeColor = System.Drawing.Color.DimGray;
            this.label41.Location = new System.Drawing.Point(513, 484);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(90, 13);
            this.label41.TabIndex = 261;
            this.label41.Text = "Last Modification:";
            // 
            // RecordGUIDLabel
            // 
            this.RecordGUIDLabel.AutoSize = true;
            this.RecordGUIDLabel.ForeColor = System.Drawing.Color.DimGray;
            this.RecordGUIDLabel.Location = new System.Drawing.Point(521, 536);
            this.RecordGUIDLabel.Name = "RecordGUIDLabel";
            this.RecordGUIDLabel.Size = new System.Drawing.Size(72, 13);
            this.RecordGUIDLabel.TabIndex = 260;
            this.RecordGUIDLabel.Text = "Record GUID";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.ForeColor = System.Drawing.Color.DimGray;
            this.label39.Location = new System.Drawing.Point(513, 521);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(75, 13);
            this.label39.TabIndex = 259;
            this.label39.Text = "Record GUID:";
            // 
            // NewSpellButton
            // 
            this.NewSpellButton.Location = new System.Drawing.Point(12, 427);
            this.NewSpellButton.Name = "NewSpellButton";
            this.NewSpellButton.Size = new System.Drawing.Size(120, 23);
            this.NewSpellButton.TabIndex = 266;
            this.NewSpellButton.TabStop = false;
            this.NewSpellButton.Text = "Create New Spell";
            this.NewSpellButton.UseVisualStyleBackColor = true;
            this.NewSpellButton.Click += new System.EventHandler(this.OnNewSpellButtonClick);
            // 
            // DeleteRecordButton
            // 
            this.DeleteRecordButton.Location = new System.Drawing.Point(714, 430);
            this.DeleteRecordButton.Name = "DeleteRecordButton";
            this.DeleteRecordButton.Size = new System.Drawing.Size(87, 23);
            this.DeleteRecordButton.TabIndex = 269;
            this.DeleteRecordButton.TabStop = false;
            this.DeleteRecordButton.Text = "Delete Record";
            this.DeleteRecordButton.UseVisualStyleBackColor = true;
            this.DeleteRecordButton.Click += new System.EventHandler(this.OnDeleteRecordButtonClick);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(588, 430);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 268;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(507, 430);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 267;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.OnUpdateButtonClick);
            // 
            // SpellNameInputBox
            // 
            this.SpellNameInputBox.Location = new System.Drawing.Point(152, 31);
            this.SpellNameInputBox.Name = "SpellNameInputBox";
            this.SpellNameInputBox.Size = new System.Drawing.Size(120, 20);
            this.SpellNameInputBox.TabIndex = 271;
            this.SpellNameInputBox.TabStop = false;
            this.SpellNameInputBox.Leave += new System.EventHandler(this.OnSpellNameInputBoxLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(149, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 272;
            this.label1.Text = "Spell Name";
            // 
            // SpellSchoolComboBox
            // 
            this.SpellSchoolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SpellSchoolComboBox.FormattingEnabled = true;
            this.SpellSchoolComboBox.Items.AddRange(new object[] {
            "Abjuration",
            "Conjuration",
            "Divination",
            "Enchantment",
            "Evocation",
            "Illusion",
            "Necromancy",
            "Transmutation"});
            this.SpellSchoolComboBox.Location = new System.Drawing.Point(302, 30);
            this.SpellSchoolComboBox.Name = "SpellSchoolComboBox";
            this.SpellSchoolComboBox.Size = new System.Drawing.Size(100, 21);
            this.SpellSchoolComboBox.TabIndex = 273;
            this.SpellSchoolComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSpellSchoolComboBoxSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(299, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 274;
            this.label2.Text = "Spell School";
            // 
            // DescriptionEditButton
            // 
            this.DescriptionEditButton.Location = new System.Drawing.Point(426, 63);
            this.DescriptionEditButton.Name = "DescriptionEditButton";
            this.DescriptionEditButton.Size = new System.Drawing.Size(33, 22);
            this.DescriptionEditButton.TabIndex = 277;
            this.DescriptionEditButton.TabStop = false;
            this.DescriptionEditButton.Text = "Edit";
            this.DescriptionEditButton.UseVisualStyleBackColor = true;
            this.DescriptionEditButton.Click += new System.EventHandler(this.OnDescriptionEditButtonClick);
            // 
            // DescriptionPreview
            // 
            this.DescriptionPreview.Location = new System.Drawing.Point(152, 91);
            this.DescriptionPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.DescriptionPreview.Name = "DescriptionPreview";
            this.DescriptionPreview.Size = new System.Drawing.Size(307, 171);
            this.DescriptionPreview.TabIndex = 276;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(149, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 275;
            this.label3.Text = "Description";
            // 
            // ComponentCheckListBox
            // 
            this.ComponentCheckListBox.CheckOnClick = true;
            this.ComponentCheckListBox.FormattingEnabled = true;
            this.ComponentCheckListBox.Items.AddRange(new object[] {
            "Verbal",
            "Somatic",
            "Material",
            "Focus",
            "Divine Focus",
            "Focus / Divine Focus",
            "Material / Divine Focus"});
            this.ComponentCheckListBox.Location = new System.Drawing.Point(152, 294);
            this.ComponentCheckListBox.Name = "ComponentCheckListBox";
            this.ComponentCheckListBox.Size = new System.Drawing.Size(138, 124);
            this.ComponentCheckListBox.TabIndex = 278;
            this.ComponentCheckListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnComponentCheckListBoxItemCheck);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(149, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 279;
            this.label4.Text = "Components";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(318, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 281;
            this.label5.Text = "Metamagic Feats";
            // 
            // MetamagicFeatCheckListBox
            // 
            this.MetamagicFeatCheckListBox.CheckOnClick = true;
            this.MetamagicFeatCheckListBox.FormattingEnabled = true;
            this.MetamagicFeatCheckListBox.Items.AddRange(new object[] {
            "Empower Healing",
            "Empower",
            "Enlarge",
            "Eschew Materials",
            "Extend",
            "Heighten",
            "Maximize",
            "Quicken"});
            this.MetamagicFeatCheckListBox.Location = new System.Drawing.Point(321, 294);
            this.MetamagicFeatCheckListBox.Name = "MetamagicFeatCheckListBox";
            this.MetamagicFeatCheckListBox.Size = new System.Drawing.Size(138, 124);
            this.MetamagicFeatCheckListBox.TabIndex = 280;
            this.MetamagicFeatCheckListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnMetamagicFeatListBoxItemCheck);
            // 
            // RangeInputComboBox
            // 
            this.RangeInputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RangeInputComboBox.FormattingEnabled = true;
            this.RangeInputComboBox.Items.AddRange(new object[] {
            "Personal",
            "Touch",
            "Very Short",
            "Standard",
            "Standard AOE",
            "Double",
            "Melee"});
            this.RangeInputComboBox.Location = new System.Drawing.Point(426, 30);
            this.RangeInputComboBox.Name = "RangeInputComboBox";
            this.RangeInputComboBox.Size = new System.Drawing.Size(100, 21);
            this.RangeInputComboBox.TabIndex = 284;
            this.RangeInputComboBox.SelectedIndexChanged += new System.EventHandler(this.OnRangeInputBoxSelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(423, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 285;
            this.label7.Text = "Range";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(149, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 287;
            this.label8.Text = "Target";
            // 
            // TargetCheckListBox
            // 
            this.TargetCheckListBox.CheckOnClick = true;
            this.TargetCheckListBox.FormattingEnabled = true;
            this.TargetCheckListBox.Items.AddRange(new object[] {
            "Self",
            "Friend",
            "Friends",
            "Positional",
            "Foe",
            "Directional",
            "Breakable"});
            this.TargetCheckListBox.Location = new System.Drawing.Point(152, 446);
            this.TargetCheckListBox.Name = "TargetCheckListBox";
            this.TargetCheckListBox.Size = new System.Drawing.Size(138, 109);
            this.TargetCheckListBox.TabIndex = 286;
            this.TargetCheckListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnTargetCheckListBoxItemCheck);
            // 
            // DurationInputTextBox
            // 
            this.DurationInputTextBox.Location = new System.Drawing.Point(321, 446);
            this.DurationInputTextBox.Name = "DurationInputTextBox";
            this.DurationInputTextBox.Size = new System.Drawing.Size(138, 20);
            this.DurationInputTextBox.TabIndex = 288;
            this.DurationInputTextBox.TabStop = false;
            this.DurationInputTextBox.Leave += new System.EventHandler(this.OnDurationInputTextBoxLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(318, 430);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 289;
            this.label9.Text = "Duration";
            // 
            // SavingThrowComboBox
            // 
            this.SavingThrowComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SavingThrowComboBox.FormattingEnabled = true;
            this.SavingThrowComboBox.Items.AddRange(new object[] {
            "None",
            "Will",
            "Fortitude",
            "Reflex"});
            this.SavingThrowComboBox.Location = new System.Drawing.Point(321, 489);
            this.SavingThrowComboBox.Name = "SavingThrowComboBox";
            this.SavingThrowComboBox.Size = new System.Drawing.Size(100, 21);
            this.SavingThrowComboBox.TabIndex = 290;
            this.SavingThrowComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSavingThrowComboBoxSelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(318, 473);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 291;
            this.label10.Text = "Saving Throw";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(318, 514);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 294;
            this.label11.Text = "Spell Resistance";
            // 
            // SpellResistanceComboBox
            // 
            this.SpellResistanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SpellResistanceComboBox.FormattingEnabled = true;
            this.SpellResistanceComboBox.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.SpellResistanceComboBox.Location = new System.Drawing.Point(321, 530);
            this.SpellResistanceComboBox.Name = "SpellResistanceComboBox";
            this.SpellResistanceComboBox.Size = new System.Drawing.Size(100, 21);
            this.SpellResistanceComboBox.TabIndex = 293;
            this.SpellResistanceComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSpellResistanceComboBoxSelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(541, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 296;
            this.label12.Text = "Icon";
            // 
            // SpellIconInputBox
            // 
            this.SpellIconInputBox.Location = new System.Drawing.Point(544, 30);
            this.SpellIconInputBox.Name = "SpellIconInputBox";
            this.SpellIconInputBox.Size = new System.Drawing.Size(94, 20);
            this.SpellIconInputBox.TabIndex = 295;
            this.SpellIconInputBox.TabStop = false;
            this.SpellIconInputBox.Leave += new System.EventHandler(this.OnSpellIconInputBoxLeave);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SPCostUpDown);
            this.panel1.Controls.Add(this.ClassAddButton);
            this.panel1.Controls.Add(this.CooldownInputBox);
            this.panel1.Controls.Add(this.LevelSelectionComboBox);
            this.panel1.Controls.Add(this.ClassSelectionComboBox);
            this.panel1.Controls.Add(this.SpellDetailSubPanel);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(468, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 234);
            this.panel1.TabIndex = 299;
            // 
            // SPCostUpDown
            // 
            this.SPCostUpDown.Location = new System.Drawing.Point(258, 21);
            this.SPCostUpDown.Name = "SPCostUpDown";
            this.SPCostUpDown.Size = new System.Drawing.Size(73, 20);
            this.SPCostUpDown.TabIndex = 300;
            // 
            // ClassAddButton
            // 
            this.ClassAddButton.Location = new System.Drawing.Point(342, 20);
            this.ClassAddButton.Name = "ClassAddButton";
            this.ClassAddButton.Size = new System.Drawing.Size(39, 23);
            this.ClassAddButton.TabIndex = 300;
            this.ClassAddButton.Text = "Add";
            this.ClassAddButton.UseVisualStyleBackColor = true;
            this.ClassAddButton.Click += new System.EventHandler(this.OnClassAddButtonClick);
            // 
            // CooldownInputBox
            // 
            this.CooldownInputBox.Location = new System.Drawing.Point(176, 22);
            this.CooldownInputBox.Name = "CooldownInputBox";
            this.CooldownInputBox.Size = new System.Drawing.Size(76, 20);
            this.CooldownInputBox.TabIndex = 302;
            this.CooldownInputBox.TabStop = false;
            // 
            // LevelSelectionComboBox
            // 
            this.LevelSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LevelSelectionComboBox.FormattingEnabled = true;
            this.LevelSelectionComboBox.Items.AddRange(new object[] {
            "None",
            "Will",
            "Fortification",
            "Reflex"});
            this.LevelSelectionComboBox.Location = new System.Drawing.Point(130, 21);
            this.LevelSelectionComboBox.Name = "LevelSelectionComboBox";
            this.LevelSelectionComboBox.Size = new System.Drawing.Size(40, 21);
            this.LevelSelectionComboBox.TabIndex = 301;
            // 
            // ClassSelectionComboBox
            // 
            this.ClassSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassSelectionComboBox.FormattingEnabled = true;
            this.ClassSelectionComboBox.Items.AddRange(new object[] {
            "None",
            "Will",
            "Fortification",
            "Reflex"});
            this.ClassSelectionComboBox.Location = new System.Drawing.Point(3, 21);
            this.ClassSelectionComboBox.Name = "ClassSelectionComboBox";
            this.ClassSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.ClassSelectionComboBox.TabIndex = 300;
            this.ClassSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.OnClassSelectionComboBoxSelectedIndexChanged);
            // 
            // SpellDetailSubPanel
            // 
            this.SpellDetailSubPanel.AutoScroll = true;
            this.SpellDetailSubPanel.BackColor = System.Drawing.Color.DimGray;
            this.SpellDetailSubPanel.Location = new System.Drawing.Point(3, 48);
            this.SpellDetailSubPanel.Name = "SpellDetailSubPanel";
            this.SpellDetailSubPanel.Size = new System.Drawing.Size(378, 179);
            this.SpellDetailSubPanel.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(255, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "SP Cost";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(176, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Cooldown";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(127, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Level";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(4, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Class";
            // 
            // ClassIconBrowseButton
            // 
            this.ClassIconBrowseButton.Image = ((System.Drawing.Image)(resources.GetObject("ClassIconBrowseButton.Image")));
            this.ClassIconBrowseButton.Location = new System.Drawing.Point(637, 29);
            this.ClassIconBrowseButton.Name = "ClassIconBrowseButton";
            this.ClassIconBrowseButton.Size = new System.Drawing.Size(24, 23);
            this.ClassIconBrowseButton.TabIndex = 297;
            this.ClassIconBrowseButton.TabStop = false;
            this.ClassIconBrowseButton.UseVisualStyleBackColor = true;
            this.ClassIconBrowseButton.Click += new System.EventHandler(this.OnSpellIconBrowseButtonClick);
            // 
            // DataInputSpellScreenClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(866, 564);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ClassIconBrowseButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.SpellIconInputBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.SpellResistanceComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.SavingThrowComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DurationInputTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TargetCheckListBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RangeInputComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MetamagicFeatCheckListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ComponentCheckListBox);
            this.Controls.Add(this.DescriptionEditButton);
            this.Controls.Add(this.DescriptionPreview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SpellSchoolComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpellNameInputBox);
            this.Controls.Add(this.DeleteRecordButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.NewSpellButton);
            this.Controls.Add(this.SaveFeedbackLabel);
            this.Controls.Add(this.ModVersionLabel);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.ModDateLabel);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.RecordGUIDLabel);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.RecordFilterBox);
            this.Controls.Add(this.SpellListBox);
            this.Controls.Add(this.label35);
            this.Name = "DataInputSpellScreenClass";
            this.Text = "Data Input - Spell Screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Click += new System.EventHandler(this.OnDataInputSpellScreenClassClick);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDataInputSpellScreenClassPaint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SPCostUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.ListBox SpellListBox;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.TextBox RecordFilterBox;
		private System.Windows.Forms.Label SaveFeedbackLabel;
		private System.Windows.Forms.Label ModVersionLabel;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label ModDateLabel;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label RecordGUIDLabel;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Button NewSpellButton;
		private System.Windows.Forms.Button DeleteRecordButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button UpdateButton;
		private System.Windows.Forms.TextBox SpellNameInputBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox SpellSchoolComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button DescriptionEditButton;
		private System.Windows.Forms.WebBrowser DescriptionPreview;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckedListBox ComponentCheckListBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckedListBox MetamagicFeatCheckListBox;
		private System.Windows.Forms.ComboBox RangeInputComboBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckedListBox TargetCheckListBox;
		private System.Windows.Forms.TextBox DurationInputTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox SavingThrowComboBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox SpellResistanceComboBox;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox SpellIconInputBox;
		private System.Windows.Forms.Button ClassIconBrowseButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button ClassAddButton;
		private System.Windows.Forms.TextBox CooldownInputBox;
		private System.Windows.Forms.ComboBox LevelSelectionComboBox;
		private System.Windows.Forms.ComboBox ClassSelectionComboBox;
		private System.Windows.Forms.Panel SpellDetailSubPanel;
		private System.Windows.Forms.NumericUpDown SPCostUpDown;
		}
	}