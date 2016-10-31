namespace DDOCharacterPlanner.Screens.DataInput
	{
	partial class DataInputFeatScreenClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataInputFeatScreenClass));
            this.FeatListBox = new System.Windows.Forms.ListBox();
            this.FeatListPanelLabel = new System.Windows.Forms.Label();
            this.FilterLabel = new System.Windows.Forms.Label();
            this.RecordFilterBox = new System.Windows.Forms.TextBox();
            this.NewFeatButton = new System.Windows.Forms.Button();
            this.ModVersionLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.ModDateLabel = new System.Windows.Forms.Label();
            this.ModificationLabel = new System.Windows.Forms.Label();
            this.RecordGUIDLabel = new System.Windows.Forms.Label();
            this.GuidLabel = new System.Windows.Forms.Label();
            this.NameInputBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionPanel = new System.Windows.Forms.Panel();
            this.ParentFeatCheckBox = new System.Windows.Forms.CheckBox();
            this.CategoryFeatComboBox = new System.Windows.Forms.ComboBox();
            this.FeatCategoryLabel = new System.Windows.Forms.Label();
            this.SubFeatLabel = new System.Windows.Forms.Label();
            this.ParentFeatComboBox = new System.Windows.Forms.ComboBox();
            this.IconFileNameInputBox = new System.Windows.Forms.TextBox();
            this.IconBrowseButton = new System.Windows.Forms.Button();
            this.IconLabel = new System.Windows.Forms.Label();
            this.FeatTypesLabel = new System.Windows.Forms.Label();
            this.RequirementsLabel = new System.Windows.Forms.Label();
            this.DeleteFeatButton = new System.Windows.Forms.Button();
            this.CancelChangesButton = new System.Windows.Forms.Button();
            this.UpdateFeatButton = new System.Windows.Forms.Button();
            this.FeatTypesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.NameErrorLabel = new System.Windows.Forms.Label();
            this.MultiplesCheckBox = new System.Windows.Forms.CheckBox();
            this.FeatTargetsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.FeatTargetsLabel = new System.Windows.Forms.Label();
            this.DurationTextBox = new System.Windows.Forms.TextBox();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.FeatListPanel = new System.Windows.Forms.Panel();
            this.RequirementsPanel = new System.Windows.Forms.Panel();
            this.FeatTypesPanel = new System.Windows.Forms.Panel();
            this.FeatTargetsPanel = new System.Windows.Forms.Panel();
            this.StanceLabel = new System.Windows.Forms.Label();
            this.StanceComboBox = new System.Windows.Forms.ComboBox();
            this.MP2Modifiers = new DDOCharacterPlanner.Screens.DataInput.ModifiersPanel2();
            this.FeatRequirementsRP2 = new DDOCharacterPlanner.Screens.DataInput.RequirementsPanel2();
            this.DescriptionHtmlEditor = new DDOCharacterPlanner.Screens.Controls.HTMLEditor();
            this.DescriptionPanel.SuspendLayout();
            this.FeatListPanel.SuspendLayout();
            this.RequirementsPanel.SuspendLayout();
            this.FeatTypesPanel.SuspendLayout();
            this.FeatTargetsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FeatListBox
            // 
            this.FeatListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FeatListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.FeatListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FeatListBox.ForeColor = System.Drawing.Color.White;
            this.FeatListBox.FormattingEnabled = true;
            this.FeatListBox.Location = new System.Drawing.Point(0, 21);
            this.FeatListBox.Name = "FeatListBox";
            this.FeatListBox.Size = new System.Drawing.Size(171, 494);
            this.FeatListBox.TabIndex = 1;
            this.FeatListBox.TabStop = false;
            this.FeatListBox.SelectedIndexChanged += new System.EventHandler(this.OnFeatListBoxSelectedIndexChanged);
            // 
            // FeatListPanelLabel
            // 
            this.FeatListPanelLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(182)))), ((int)(((byte)(231)))));
            this.FeatListPanelLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FeatListPanelLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeatListPanelLabel.ForeColor = System.Drawing.Color.White;
            this.FeatListPanelLabel.Location = new System.Drawing.Point(0, 0);
            this.FeatListPanelLabel.Name = "FeatListPanelLabel";
            this.FeatListPanelLabel.Size = new System.Drawing.Size(171, 20);
            this.FeatListPanelLabel.TabIndex = 146;
            this.FeatListPanelLabel.Text = "List of Feats";
            this.FeatListPanelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FilterLabel
            // 
            this.FilterLabel.AutoSize = true;
            this.FilterLabel.ForeColor = System.Drawing.Color.White;
            this.FilterLabel.Location = new System.Drawing.Point(3, 577);
            this.FilterLabel.Name = "FilterLabel";
            this.FilterLabel.Size = new System.Drawing.Size(29, 13);
            this.FilterLabel.TabIndex = 252;
            this.FilterLabel.Text = "Filter";
            // 
            // RecordFilterBox
            // 
            this.RecordFilterBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.RecordFilterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RecordFilterBox.ForeColor = System.Drawing.Color.White;
            this.RecordFilterBox.Location = new System.Drawing.Point(6, 594);
            this.RecordFilterBox.Name = "RecordFilterBox";
            this.RecordFilterBox.Size = new System.Drawing.Size(171, 20);
            this.RecordFilterBox.TabIndex = 251;
            this.RecordFilterBox.TabStop = false;
            this.RecordFilterBox.TextChanged += new System.EventHandler(this.OnRecordFilterBoxTextChanged);
            // 
            // NewFeatButton
            // 
            this.NewFeatButton.BackColor = System.Drawing.Color.Silver;
            this.NewFeatButton.FlatAppearance.BorderSize = 0;
            this.NewFeatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewFeatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFeatButton.ForeColor = System.Drawing.Color.Black;
            this.NewFeatButton.Location = new System.Drawing.Point(5, 27);
            this.NewFeatButton.Name = "NewFeatButton";
            this.NewFeatButton.Size = new System.Drawing.Size(173, 20);
            this.NewFeatButton.TabIndex = 250;
            this.NewFeatButton.Text = "Create New Feat";
            this.NewFeatButton.UseVisualStyleBackColor = false;
            this.NewFeatButton.Click += new System.EventHandler(this.OnNewFeatButtonClick);
            // 
            // ModVersionLabel
            // 
            this.ModVersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ModVersionLabel.AutoSize = true;
            this.ModVersionLabel.ForeColor = System.Drawing.Color.DimGray;
            this.ModVersionLabel.Location = new System.Drawing.Point(347, 635);
            this.ModVersionLabel.Name = "ModVersionLabel";
            this.ModVersionLabel.Size = new System.Drawing.Size(66, 13);
            this.ModVersionLabel.TabIndex = 258;
            this.ModVersionLabel.Text = "Mod Version";
            // 
            // VersionLabel
            // 
            this.VersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.ForeColor = System.Drawing.Color.DimGray;
            this.VersionLabel.Location = new System.Drawing.Point(225, 635);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(114, 13);
            this.VersionLabel.TabIndex = 257;
            this.VersionLabel.Text = "Using Planner Version:";
            // 
            // ModDateLabel
            // 
            this.ModDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ModDateLabel.AutoSize = true;
            this.ModDateLabel.ForeColor = System.Drawing.Color.DimGray;
            this.ModDateLabel.Location = new System.Drawing.Point(108, 635);
            this.ModDateLabel.Name = "ModDateLabel";
            this.ModDateLabel.Size = new System.Drawing.Size(54, 13);
            this.ModDateLabel.TabIndex = 256;
            this.ModDateLabel.Text = "Mod Date";
            // 
            // ModificationLabel
            // 
            this.ModificationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ModificationLabel.AutoSize = true;
            this.ModificationLabel.ForeColor = System.Drawing.Color.DimGray;
            this.ModificationLabel.Location = new System.Drawing.Point(12, 635);
            this.ModificationLabel.Name = "ModificationLabel";
            this.ModificationLabel.Size = new System.Drawing.Size(90, 13);
            this.ModificationLabel.TabIndex = 255;
            this.ModificationLabel.Text = "Last Modification:";
            // 
            // RecordGUIDLabel
            // 
            this.RecordGUIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RecordGUIDLabel.AutoSize = true;
            this.RecordGUIDLabel.ForeColor = System.Drawing.Color.DimGray;
            this.RecordGUIDLabel.Location = new System.Drawing.Point(90, 620);
            this.RecordGUIDLabel.Name = "RecordGUIDLabel";
            this.RecordGUIDLabel.Size = new System.Drawing.Size(72, 13);
            this.RecordGUIDLabel.TabIndex = 254;
            this.RecordGUIDLabel.Text = "Record GUID";
            // 
            // GuidLabel
            // 
            this.GuidLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GuidLabel.AutoSize = true;
            this.GuidLabel.ForeColor = System.Drawing.Color.DimGray;
            this.GuidLabel.Location = new System.Drawing.Point(9, 620);
            this.GuidLabel.Name = "GuidLabel";
            this.GuidLabel.Size = new System.Drawing.Size(75, 13);
            this.GuidLabel.TabIndex = 253;
            this.GuidLabel.Text = "Record GUID:";
            // 
            // NameInputBox
            // 
            this.NameInputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.NameInputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameInputBox.ForeColor = System.Drawing.Color.White;
            this.NameInputBox.Location = new System.Drawing.Point(185, 27);
            this.NameInputBox.Name = "NameInputBox";
            this.NameInputBox.Size = new System.Drawing.Size(277, 20);
            this.NameInputBox.TabIndex = 2;
            this.NameInputBox.Leave += new System.EventHandler(this.OnNameInputBoxLeave);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.ForeColor = System.Drawing.Color.White;
            this.NameLabel.Location = new System.Drawing.Point(185, 11);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(59, 13);
            this.NameLabel.TabIndex = 260;
            this.NameLabel.Text = "Feat Name";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(182)))), ((int)(((byte)(231)))));
            this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DescriptionLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.ForeColor = System.Drawing.Color.White;
            this.DescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(449, 20);
            this.DescriptionLabel.TabIndex = 261;
            this.DescriptionLabel.Text = "Description";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescriptionPanel
            // 
            this.DescriptionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptionPanel.Controls.Add(this.DescriptionHtmlEditor);
            this.DescriptionPanel.Controls.Add(this.DescriptionLabel);
            this.DescriptionPanel.Location = new System.Drawing.Point(185, 53);
            this.DescriptionPanel.Name = "DescriptionPanel";
            this.DescriptionPanel.Size = new System.Drawing.Size(451, 186);
            this.DescriptionPanel.TabIndex = 262;
            // 
            // ParentFeatCheckBox
            // 
            this.ParentFeatCheckBox.AutoSize = true;
            this.ParentFeatCheckBox.ForeColor = System.Drawing.Color.White;
            this.ParentFeatCheckBox.Location = new System.Drawing.Point(185, 300);
            this.ParentFeatCheckBox.Name = "ParentFeatCheckBox";
            this.ParentFeatCheckBox.Size = new System.Drawing.Size(120, 17);
            this.ParentFeatCheckBox.TabIndex = 8;
            this.ParentFeatCheckBox.Text = "Is this a Parent Feat";
            this.ParentFeatCheckBox.UseVisualStyleBackColor = true;
            this.ParentFeatCheckBox.CheckedChanged += new System.EventHandler(this.OnParentFeatCheckBoxCheckedChanged);
            // 
            // CategoryFeatComboBox
            // 
            this.CategoryFeatComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.CategoryFeatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryFeatComboBox.ForeColor = System.Drawing.Color.White;
            this.CategoryFeatComboBox.FormattingEnabled = true;
            this.CategoryFeatComboBox.Location = new System.Drawing.Point(185, 267);
            this.CategoryFeatComboBox.Name = "CategoryFeatComboBox";
            this.CategoryFeatComboBox.Size = new System.Drawing.Size(138, 21);
            this.CategoryFeatComboBox.TabIndex = 5;
            this.CategoryFeatComboBox.SelectionChangeCommitted += new System.EventHandler(this.OnCategoryFeatComboBoxSelectedChangeCommmitted);
            // 
            // FeatCategoryLabel
            // 
            this.FeatCategoryLabel.AutoSize = true;
            this.FeatCategoryLabel.ForeColor = System.Drawing.Color.White;
            this.FeatCategoryLabel.Location = new System.Drawing.Point(185, 248);
            this.FeatCategoryLabel.Name = "FeatCategoryLabel";
            this.FeatCategoryLabel.Size = new System.Drawing.Size(73, 13);
            this.FeatCategoryLabel.TabIndex = 265;
            this.FeatCategoryLabel.Text = "Feat Category";
            // 
            // SubFeatLabel
            // 
            this.SubFeatLabel.AutoSize = true;
            this.SubFeatLabel.ForeColor = System.Drawing.Color.White;
            this.SubFeatLabel.Location = new System.Drawing.Point(330, 251);
            this.SubFeatLabel.Name = "SubFeatLabel";
            this.SubFeatLabel.Size = new System.Drawing.Size(62, 13);
            this.SubFeatLabel.TabIndex = 267;
            this.SubFeatLabel.Text = "Sub-Feat of";
            // 
            // ParentFeatComboBox
            // 
            this.ParentFeatComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.ParentFeatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParentFeatComboBox.ForeColor = System.Drawing.Color.White;
            this.ParentFeatComboBox.FormattingEnabled = true;
            this.ParentFeatComboBox.Location = new System.Drawing.Point(333, 267);
            this.ParentFeatComboBox.Name = "ParentFeatComboBox";
            this.ParentFeatComboBox.Size = new System.Drawing.Size(153, 21);
            this.ParentFeatComboBox.TabIndex = 6;
            this.ParentFeatComboBox.SelectionChangeCommitted += new System.EventHandler(this.OnParentFeatComboBoxSelectedChangeCommitted);
            // 
            // IconFileNameInputBox
            // 
            this.IconFileNameInputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.IconFileNameInputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IconFileNameInputBox.ForeColor = System.Drawing.Color.White;
            this.IconFileNameInputBox.Location = new System.Drawing.Point(617, 27);
            this.IconFileNameInputBox.Name = "IconFileNameInputBox";
            this.IconFileNameInputBox.Size = new System.Drawing.Size(125, 20);
            this.IconFileNameInputBox.TabIndex = 4;
            this.IconFileNameInputBox.Leave += new System.EventHandler(this.OnIconFileNameInputBoxLeave);
            // 
            // IconBrowseButton
            // 
            this.IconBrowseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(125)))), ((int)(((byte)(130)))));
            this.IconBrowseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(125)))), ((int)(((byte)(130)))));
            this.IconBrowseButton.FlatAppearance.BorderSize = 0;
            this.IconBrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IconBrowseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IconBrowseButton.Image = ((System.Drawing.Image)(resources.GetObject("IconBrowseButton.Image")));
            this.IconBrowseButton.Location = new System.Drawing.Point(742, 25);
            this.IconBrowseButton.Name = "IconBrowseButton";
            this.IconBrowseButton.Size = new System.Drawing.Size(25, 23);
            this.IconBrowseButton.TabIndex = 269;
            this.IconBrowseButton.UseVisualStyleBackColor = false;
            this.IconBrowseButton.Click += new System.EventHandler(this.OnIconBrowseButtonClick);
            // 
            // IconLabel
            // 
            this.IconLabel.AutoSize = true;
            this.IconLabel.ForeColor = System.Drawing.Color.White;
            this.IconLabel.Location = new System.Drawing.Point(614, 10);
            this.IconLabel.Name = "IconLabel";
            this.IconLabel.Size = new System.Drawing.Size(28, 13);
            this.IconLabel.TabIndex = 270;
            this.IconLabel.Text = "Icon";
            // 
            // FeatTypesLabel
            // 
            this.FeatTypesLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(182)))), ((int)(((byte)(231)))));
            this.FeatTypesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FeatTypesLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FeatTypesLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeatTypesLabel.ForeColor = System.Drawing.Color.White;
            this.FeatTypesLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FeatTypesLabel.Location = new System.Drawing.Point(0, 0);
            this.FeatTypesLabel.Name = "FeatTypesLabel";
            this.FeatTypesLabel.Size = new System.Drawing.Size(167, 20);
            this.FeatTypesLabel.TabIndex = 262;
            this.FeatTypesLabel.Text = "Feat Types";
            this.FeatTypesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RequirementsLabel
            // 
            this.RequirementsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(182)))), ((int)(((byte)(231)))));
            this.RequirementsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RequirementsLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequirementsLabel.ForeColor = System.Drawing.Color.White;
            this.RequirementsLabel.Location = new System.Drawing.Point(0, 0);
            this.RequirementsLabel.Name = "RequirementsLabel";
            this.RequirementsLabel.Size = new System.Drawing.Size(449, 20);
            this.RequirementsLabel.TabIndex = 265;
            this.RequirementsLabel.Text = "Requirements";
            this.RequirementsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeleteFeatButton
            // 
            this.DeleteFeatButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteFeatButton.BackColor = System.Drawing.Color.Silver;
            this.DeleteFeatButton.FlatAppearance.BorderSize = 0;
            this.DeleteFeatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteFeatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteFeatButton.ForeColor = System.Drawing.Color.Black;
            this.DeleteFeatButton.Location = new System.Drawing.Point(716, 628);
            this.DeleteFeatButton.Name = "DeleteFeatButton";
            this.DeleteFeatButton.Size = new System.Drawing.Size(100, 20);
            this.DeleteFeatButton.TabIndex = 274;
            this.DeleteFeatButton.Text = "Delete Record";
            this.DeleteFeatButton.UseVisualStyleBackColor = false;
            this.DeleteFeatButton.Click += new System.EventHandler(this.OnDeleteFeatButtonClick);
            // 
            // CancelChangesButton
            // 
            this.CancelChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelChangesButton.BackColor = System.Drawing.Color.Silver;
            this.CancelChangesButton.FlatAppearance.BorderSize = 0;
            this.CancelChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelChangesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelChangesButton.ForeColor = System.Drawing.Color.Black;
            this.CancelChangesButton.Location = new System.Drawing.Point(642, 628);
            this.CancelChangesButton.Name = "CancelChangesButton";
            this.CancelChangesButton.Size = new System.Drawing.Size(64, 20);
            this.CancelChangesButton.TabIndex = 275;
            this.CancelChangesButton.Text = "Cancel";
            this.CancelChangesButton.UseVisualStyleBackColor = false;
            this.CancelChangesButton.Click += new System.EventHandler(this.OnCancelChangesButtonClick);
            // 
            // UpdateFeatButton
            // 
            this.UpdateFeatButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateFeatButton.BackColor = System.Drawing.Color.Silver;
            this.UpdateFeatButton.FlatAppearance.BorderSize = 0;
            this.UpdateFeatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateFeatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateFeatButton.ForeColor = System.Drawing.Color.Black;
            this.UpdateFeatButton.Location = new System.Drawing.Point(566, 628);
            this.UpdateFeatButton.Name = "UpdateFeatButton";
            this.UpdateFeatButton.Size = new System.Drawing.Size(64, 20);
            this.UpdateFeatButton.TabIndex = 276;
            this.UpdateFeatButton.Text = "Update";
            this.UpdateFeatButton.UseVisualStyleBackColor = false;
            this.UpdateFeatButton.Click += new System.EventHandler(this.OnUpdateFeatButtonClick);
            // 
            // FeatTypesCheckedListBox
            // 
            this.FeatTypesCheckedListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.FeatTypesCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FeatTypesCheckedListBox.CheckOnClick = true;
            this.FeatTypesCheckedListBox.ForeColor = System.Drawing.Color.White;
            this.FeatTypesCheckedListBox.FormattingEnabled = true;
            this.FeatTypesCheckedListBox.Location = new System.Drawing.Point(3, 23);
            this.FeatTypesCheckedListBox.Name = "FeatTypesCheckedListBox";
            this.FeatTypesCheckedListBox.Size = new System.Drawing.Size(164, 210);
            this.FeatTypesCheckedListBox.Sorted = true;
            this.FeatTypesCheckedListBox.TabIndex = 265;
            this.FeatTypesCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnFeatTypesCheckedListBoxItemCheck);
            // 
            // NameErrorLabel
            // 
            this.NameErrorLabel.AutoSize = true;
            this.NameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.NameErrorLabel.Location = new System.Drawing.Point(5, 10);
            this.NameErrorLabel.Name = "NameErrorLabel";
            this.NameErrorLabel.Size = new System.Drawing.Size(53, 13);
            this.NameErrorLabel.TabIndex = 277;
            this.NameErrorLabel.Text = "Error Text";
            // 
            // MultiplesCheckBox
            // 
            this.MultiplesCheckBox.AutoSize = true;
            this.MultiplesCheckBox.ForeColor = System.Drawing.Color.White;
            this.MultiplesCheckBox.Location = new System.Drawing.Point(333, 300);
            this.MultiplesCheckBox.Name = "MultiplesCheckBox";
            this.MultiplesCheckBox.Size = new System.Drawing.Size(143, 17);
            this.MultiplesCheckBox.TabIndex = 9;
            this.MultiplesCheckBox.Text = "Can Take Multiple Times";
            this.MultiplesCheckBox.UseVisualStyleBackColor = true;
            this.MultiplesCheckBox.CheckedChanged += new System.EventHandler(this.OnMultiplesCheckBoxCheckedChanged);
            // 
            // FeatTargetsCheckedListBox
            // 
            this.FeatTargetsCheckedListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.FeatTargetsCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FeatTargetsCheckedListBox.CheckOnClick = true;
            this.FeatTargetsCheckedListBox.ForeColor = System.Drawing.Color.White;
            this.FeatTargetsCheckedListBox.FormattingEnabled = true;
            this.FeatTargetsCheckedListBox.Location = new System.Drawing.Point(3, 24);
            this.FeatTargetsCheckedListBox.Name = "FeatTargetsCheckedListBox";
            this.FeatTargetsCheckedListBox.Size = new System.Drawing.Size(158, 135);
            this.FeatTargetsCheckedListBox.Sorted = true;
            this.FeatTargetsCheckedListBox.TabIndex = 282;
            this.FeatTargetsCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnFeatTargetsCheckedListBoxItemCheck);
            // 
            // FeatTargetsLabel
            // 
            this.FeatTargetsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(182)))), ((int)(((byte)(231)))));
            this.FeatTargetsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FeatTargetsLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FeatTargetsLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeatTargetsLabel.ForeColor = System.Drawing.Color.White;
            this.FeatTargetsLabel.Location = new System.Drawing.Point(0, 0);
            this.FeatTargetsLabel.Name = "FeatTargetsLabel";
            this.FeatTargetsLabel.Size = new System.Drawing.Size(167, 20);
            this.FeatTargetsLabel.TabIndex = 283;
            this.FeatTargetsLabel.Text = "Targets";
            this.FeatTargetsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DurationTextBox
            // 
            this.DurationTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.DurationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DurationTextBox.ForeColor = System.Drawing.Color.White;
            this.DurationTextBox.Location = new System.Drawing.Point(468, 27);
            this.DurationTextBox.Name = "DurationTextBox";
            this.DurationTextBox.Size = new System.Drawing.Size(143, 20);
            this.DurationTextBox.TabIndex = 3;
            this.DurationTextBox.Leave += new System.EventHandler(this.OnDurationTextBoxLeave);
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.ForeColor = System.Drawing.Color.White;
            this.DurationLabel.Location = new System.Drawing.Point(465, 9);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(47, 13);
            this.DurationLabel.TabIndex = 285;
            this.DurationLabel.Text = "Duration";
            // 
            // FeatListPanel
            // 
            this.FeatListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FeatListPanel.Controls.Add(this.FeatListPanelLabel);
            this.FeatListPanel.Controls.Add(this.FeatListBox);
            this.FeatListPanel.Location = new System.Drawing.Point(5, 53);
            this.FeatListPanel.Name = "FeatListPanel";
            this.FeatListPanel.Size = new System.Drawing.Size(173, 521);
            this.FeatListPanel.TabIndex = 286;
            // 
            // RequirementsPanel
            // 
            this.RequirementsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RequirementsPanel.Controls.Add(this.FeatRequirementsRP2);
            this.RequirementsPanel.Controls.Add(this.RequirementsLabel);
            this.RequirementsPanel.Location = new System.Drawing.Point(185, 325);
            this.RequirementsPanel.Name = "RequirementsPanel";
            this.RequirementsPanel.Size = new System.Drawing.Size(451, 134);
            this.RequirementsPanel.TabIndex = 287;
            // 
            // FeatTypesPanel
            // 
            this.FeatTypesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FeatTypesPanel.Controls.Add(this.FeatTypesLabel);
            this.FeatTypesPanel.Controls.Add(this.FeatTypesCheckedListBox);
            this.FeatTypesPanel.Location = new System.Drawing.Point(642, 224);
            this.FeatTypesPanel.Name = "FeatTypesPanel";
            this.FeatTypesPanel.Size = new System.Drawing.Size(169, 235);
            this.FeatTypesPanel.TabIndex = 288;
            // 
            // FeatTargetsPanel
            // 
            this.FeatTargetsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FeatTargetsPanel.Controls.Add(this.FeatTargetsLabel);
            this.FeatTargetsPanel.Controls.Add(this.FeatTargetsCheckedListBox);
            this.FeatTargetsPanel.Location = new System.Drawing.Point(642, 53);
            this.FeatTargetsPanel.Name = "FeatTargetsPanel";
            this.FeatTargetsPanel.Size = new System.Drawing.Size(169, 162);
            this.FeatTargetsPanel.TabIndex = 289;
            // 
            // StanceLabel
            // 
            this.StanceLabel.AutoSize = true;
            this.StanceLabel.ForeColor = System.Drawing.Color.White;
            this.StanceLabel.Location = new System.Drawing.Point(497, 250);
            this.StanceLabel.Name = "StanceLabel";
            this.StanceLabel.Size = new System.Drawing.Size(41, 13);
            this.StanceLabel.TabIndex = 291;
            this.StanceLabel.Text = "Stance";
            // 
            // StanceComboBox
            // 
            this.StanceComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.StanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StanceComboBox.ForeColor = System.Drawing.Color.White;
            this.StanceComboBox.FormattingEnabled = true;
            this.StanceComboBox.Location = new System.Drawing.Point(496, 266);
            this.StanceComboBox.Name = "StanceComboBox";
            this.StanceComboBox.Size = new System.Drawing.Size(140, 21);
            this.StanceComboBox.TabIndex = 7;
            this.StanceComboBox.SelectionChangeCommitted += new System.EventHandler(this.StanceComboBox_SelectedChangeCommitted);
            // 
            // MP2Modifiers
            // 
            this.MP2Modifiers.Location = new System.Drawing.Point(185, 465);
            this.MP2Modifiers.MPBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.MP2Modifiers.MPFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MP2Modifiers.MPForeColor = System.Drawing.Color.White;
            this.MP2Modifiers.MPTitle = "Modifiers";
            this.MP2Modifiers.MPTitleBackColor = System.Drawing.Color.LightSkyBlue;
            this.MP2Modifiers.MPTitleFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MP2Modifiers.MPTitleForeColor = System.Drawing.Color.White;
            this.MP2Modifiers.Name = "MP2Modifiers";
            this.MP2Modifiers.ParentScreen = DDOCharacterPlanner.Screens.DataInput.ModifiersPanel2.ScreenType.Feat;
            this.MP2Modifiers.RecordId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.MP2Modifiers.Size = new System.Drawing.Size(626, 149);
            this.MP2Modifiers.TabIndex = 292;
            // 
            // FeatRequirementsRP2
            // 
            this.FeatRequirementsRP2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FeatRequirementsRP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.FeatRequirementsRP2.ControlStyle = DDOCharacterPlanner.Screens.DataInput.RequirementsPanel2.ScreenStyle.Extended;
            this.FeatRequirementsRP2.Location = new System.Drawing.Point(3, 24);
            this.FeatRequirementsRP2.MainScreen = DDOCharacterPlanner.Screens.DataInput.RequirementsPanel2.ScreenType.Feat;
            this.FeatRequirementsRP2.MinimumSize = new System.Drawing.Size(300, 80);
            this.FeatRequirementsRP2.Name = "FeatRequirementsRP2";
            this.FeatRequirementsRP2.RecordId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.FeatRequirementsRP2.Size = new System.Drawing.Size(444, 105);
            this.FeatRequirementsRP2.TabIndex = 266;
            // 
            // DescriptionHtmlEditor
            // 
            this.DescriptionHtmlEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.DescriptionHtmlEditor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.DescriptionHtmlEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptionHtmlEditor.Location = new System.Drawing.Point(2, 21);
            this.DescriptionHtmlEditor.MainFontColor = System.Drawing.Color.White;
            this.DescriptionHtmlEditor.Name = "DescriptionHtmlEditor";
            this.DescriptionHtmlEditor.Size = new System.Drawing.Size(447, 160);
            this.DescriptionHtmlEditor.TabIndex = 262;
            this.DescriptionHtmlEditor.Leave += new System.EventHandler(this.DescriptionHTMLEditor_Leave);
            // 
            // DataInputFeatScreenClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(823, 653);
            this.Controls.Add(this.MP2Modifiers);
            this.Controls.Add(this.StanceLabel);
            this.Controls.Add(this.StanceComboBox);
            this.Controls.Add(this.FeatTargetsPanel);
            this.Controls.Add(this.FeatTypesPanel);
            this.Controls.Add(this.RequirementsPanel);
            this.Controls.Add(this.FeatListPanel);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.DurationTextBox);
            this.Controls.Add(this.MultiplesCheckBox);
            this.Controls.Add(this.NameErrorLabel);
            this.Controls.Add(this.UpdateFeatButton);
            this.Controls.Add(this.CancelChangesButton);
            this.Controls.Add(this.DeleteFeatButton);
            this.Controls.Add(this.IconLabel);
            this.Controls.Add(this.IconBrowseButton);
            this.Controls.Add(this.IconFileNameInputBox);
            this.Controls.Add(this.SubFeatLabel);
            this.Controls.Add(this.ParentFeatComboBox);
            this.Controls.Add(this.FeatCategoryLabel);
            this.Controls.Add(this.CategoryFeatComboBox);
            this.Controls.Add(this.ParentFeatCheckBox);
            this.Controls.Add(this.DescriptionPanel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameInputBox);
            this.Controls.Add(this.ModVersionLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.ModDateLabel);
            this.Controls.Add(this.ModificationLabel);
            this.Controls.Add(this.RecordGUIDLabel);
            this.Controls.Add(this.GuidLabel);
            this.Controls.Add(this.FilterLabel);
            this.Controls.Add(this.RecordFilterBox);
            this.Controls.Add(this.NewFeatButton);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "DataInputFeatScreenClass";
            this.Text = "Data Input - Feat Screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataInputFeatScreenClassFormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.DescriptionPanel.ResumeLayout(false);
            this.FeatListPanel.ResumeLayout(false);
            this.RequirementsPanel.ResumeLayout(false);
            this.FeatTypesPanel.ResumeLayout(false);
            this.FeatTargetsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.ListBox FeatListBox;
		private System.Windows.Forms.Label FeatListPanelLabel;
		private System.Windows.Forms.Label FilterLabel;
		private System.Windows.Forms.TextBox RecordFilterBox;
		private System.Windows.Forms.Button NewFeatButton;
		private System.Windows.Forms.Label ModVersionLabel;
		private System.Windows.Forms.Label VersionLabel;
		private System.Windows.Forms.Label ModDateLabel;
		private System.Windows.Forms.Label ModificationLabel;
		private System.Windows.Forms.Label RecordGUIDLabel;
		private System.Windows.Forms.Label GuidLabel;
        private System.Windows.Forms.TextBox NameInputBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Panel DescriptionPanel;
        private System.Windows.Forms.CheckBox ParentFeatCheckBox;
        private System.Windows.Forms.ComboBox CategoryFeatComboBox;
        private System.Windows.Forms.Label FeatCategoryLabel;
        private System.Windows.Forms.Label SubFeatLabel;
        private System.Windows.Forms.ComboBox ParentFeatComboBox;
        private System.Windows.Forms.TextBox IconFileNameInputBox;
        private System.Windows.Forms.Button IconBrowseButton;
        private System.Windows.Forms.Label IconLabel;
        private System.Windows.Forms.Label FeatTypesLabel;
        private System.Windows.Forms.Label RequirementsLabel;
        private System.Windows.Forms.Button DeleteFeatButton;
        private System.Windows.Forms.Button CancelChangesButton;
        private System.Windows.Forms.Button UpdateFeatButton;
        private System.Windows.Forms.CheckedListBox FeatTypesCheckedListBox;
        private System.Windows.Forms.Label NameErrorLabel;
        private System.Windows.Forms.CheckBox MultiplesCheckBox;
        private System.Windows.Forms.CheckedListBox FeatTargetsCheckedListBox;
        private System.Windows.Forms.Label FeatTargetsLabel;
        private System.Windows.Forms.TextBox DurationTextBox;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.Panel FeatListPanel;
        private System.Windows.Forms.Panel RequirementsPanel;
        private RequirementsPanel2 FeatRequirementsRP2;
        private System.Windows.Forms.Panel FeatTypesPanel;
        private System.Windows.Forms.Panel FeatTargetsPanel;
        private System.Windows.Forms.Label StanceLabel;
        private System.Windows.Forms.ComboBox StanceComboBox;
        private Controls.HTMLEditor DescriptionHtmlEditor;
        private ModifiersPanel2 MP2Modifiers;
		}
	}