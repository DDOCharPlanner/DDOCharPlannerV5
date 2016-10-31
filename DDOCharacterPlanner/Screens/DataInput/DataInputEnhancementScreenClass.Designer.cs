namespace DDOCharacterPlanner.Screens.DataInput
    {
    partial class DataInputEnhancementScreenClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataInputEnhancementScreenClass));
            this.EnhancementTreeListBox = new System.Windows.Forms.ListBox();
            this.EnhancementTreeListBoxLabel = new System.Windows.Forms.Label();
            this.UpdateTreeButton = new System.Windows.Forms.Button();
            this.NewTreeButton = new System.Windows.Forms.Button();
            this.DeleteTreeButton = new System.Windows.Forms.Button();
            this.CancelChangesButton = new System.Windows.Forms.Button();
            this.TreeNameTextBox = new System.Windows.Forms.TextBox();
            this.TreeNameLabel = new System.Windows.Forms.Label();
            this.TreeBackgroundLabel = new System.Windows.Forms.Label();
            this.TreeBackgoundTextBox = new System.Windows.Forms.TextBox();
            this.EnhancementTreePanel = new System.Windows.Forms.Panel();
            this.EnhancementTreeControl = new DDOCharacterPlanner.Screens.Controls.TreeControl();
            this.EnhancementTreeLabel = new System.Windows.Forms.Label();
            this.btnTreeBackgroundBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RecordGuidLabel = new System.Windows.Forms.Label();
            this.ModDateLabel = new System.Windows.Forms.Label();
            this.ModVersionLabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.EnhacementSlotPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.RaceRadioButton = new System.Windows.Forms.RadioButton();
            this.ClassRadioButton = new System.Windows.Forms.RadioButton();
            this.TreeTypeLabel = new System.Windows.Forms.Label();
            this.TreeRequirementsPanel = new System.Windows.Forms.Panel();
            this.TreeRP2 = new DDOCharacterPlanner.Screens.DataInput.RequirementsPanel2();
            this.TreeRequirementsLabel = new System.Windows.Forms.Label();
            this.TreeTypePanel = new System.Windows.Forms.Panel();
            this.EnhancemenTreeListPanel = new System.Windows.Forms.Panel();
            this.buttonDuplicateRecord = new System.Windows.Forms.Button();
            this.EnhancementTreePanel.SuspendLayout();
            this.EnhacementSlotPanel.SuspendLayout();
            this.TreeRequirementsPanel.SuspendLayout();
            this.TreeTypePanel.SuspendLayout();
            this.EnhancemenTreeListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnhancementTreeListBox
            // 
            this.EnhancementTreeListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.EnhancementTreeListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EnhancementTreeListBox.ForeColor = System.Drawing.Color.White;
            this.EnhancementTreeListBox.FormattingEnabled = true;
            this.EnhancementTreeListBox.Location = new System.Drawing.Point(3, 23);
            this.EnhancementTreeListBox.Name = "EnhancementTreeListBox";
            this.EnhancementTreeListBox.Size = new System.Drawing.Size(162, 429);
            this.EnhancementTreeListBox.TabIndex = 3;
            this.EnhancementTreeListBox.SelectedIndexChanged += new System.EventHandler(this.OnEnhancementTreeListBoxSelectedIndexChanged);
            // 
            // EnhancementTreeListBoxLabel
            // 
            this.EnhancementTreeListBoxLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(182)))), ((int)(((byte)(231)))));
            this.EnhancementTreeListBoxLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.EnhancementTreeListBoxLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnhancementTreeListBoxLabel.ForeColor = System.Drawing.Color.White;
            this.EnhancementTreeListBoxLabel.Location = new System.Drawing.Point(0, 0);
            this.EnhancementTreeListBoxLabel.Name = "EnhancementTreeListBoxLabel";
            this.EnhancementTreeListBoxLabel.Size = new System.Drawing.Size(168, 20);
            this.EnhancementTreeListBoxLabel.TabIndex = 4;
            this.EnhancementTreeListBoxLabel.Text = "List of Enhancement Trees";
            this.EnhancementTreeListBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UpdateTreeButton
            // 
            this.UpdateTreeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateTreeButton.BackColor = System.Drawing.Color.Silver;
            this.UpdateTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateTreeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateTreeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.UpdateTreeButton.Location = new System.Drawing.Point(527, 510);
            this.UpdateTreeButton.Name = "UpdateTreeButton";
            this.UpdateTreeButton.Size = new System.Drawing.Size(62, 23);
            this.UpdateTreeButton.TabIndex = 5;
            this.UpdateTreeButton.Text = "Update";
            this.UpdateTreeButton.UseVisualStyleBackColor = false;
            this.UpdateTreeButton.Click += new System.EventHandler(this.OnUpdateButtonClick);
            // 
            // NewTreeButton
            // 
            this.NewTreeButton.BackColor = System.Drawing.Color.Silver;
            this.NewTreeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.NewTreeButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.NewTreeButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.NewTreeButton.FlatAppearance.BorderSize = 0;
            this.NewTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewTreeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewTreeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NewTreeButton.Location = new System.Drawing.Point(6, 6);
            this.NewTreeButton.Name = "NewTreeButton";
            this.NewTreeButton.Size = new System.Drawing.Size(169, 20);
            this.NewTreeButton.TabIndex = 6;
            this.NewTreeButton.Text = "Create New Tree";
            this.NewTreeButton.UseVisualStyleBackColor = false;
            this.NewTreeButton.Click += new System.EventHandler(this.OnNewTreeButtonClick);
            // 
            // DeleteTreeButton
            // 
            this.DeleteTreeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteTreeButton.BackColor = System.Drawing.Color.Silver;
            this.DeleteTreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteTreeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteTreeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DeleteTreeButton.Location = new System.Drawing.Point(665, 510);
            this.DeleteTreeButton.Name = "DeleteTreeButton";
            this.DeleteTreeButton.Size = new System.Drawing.Size(101, 23);
            this.DeleteTreeButton.TabIndex = 7;
            this.DeleteTreeButton.Text = "Delete Record";
            this.DeleteTreeButton.UseVisualStyleBackColor = false;
            this.DeleteTreeButton.Click += new System.EventHandler(this.OnDeleteButtonClick);
            // 
            // CancelChangesButton
            // 
            this.CancelChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelChangesButton.BackColor = System.Drawing.Color.Silver;
            this.CancelChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelChangesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelChangesButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CancelChangesButton.Location = new System.Drawing.Point(595, 510);
            this.CancelChangesButton.Name = "CancelChangesButton";
            this.CancelChangesButton.Size = new System.Drawing.Size(64, 23);
            this.CancelChangesButton.TabIndex = 8;
            this.CancelChangesButton.Text = "Cancel";
            this.CancelChangesButton.UseVisualStyleBackColor = false;
            this.CancelChangesButton.Click += new System.EventHandler(this.OnCancelChangesButtonClick);
            // 
            // TreeNameTextBox
            // 
            this.TreeNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.TreeNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TreeNameTextBox.ForeColor = System.Drawing.Color.White;
            this.TreeNameTextBox.Location = new System.Drawing.Point(496, 23);
            this.TreeNameTextBox.Name = "TreeNameTextBox";
            this.TreeNameTextBox.Size = new System.Drawing.Size(157, 20);
            this.TreeNameTextBox.TabIndex = 10;
            this.TreeNameTextBox.Text = "Purple Dragon Knight";
            this.TreeNameTextBox.Leave += new System.EventHandler(this.OnTreeNameTextBoxLeave);
            // 
            // TreeNameLabel
            // 
            this.TreeNameLabel.AutoSize = true;
            this.TreeNameLabel.ForeColor = System.Drawing.Color.White;
            this.TreeNameLabel.Location = new System.Drawing.Point(493, 7);
            this.TreeNameLabel.Name = "TreeNameLabel";
            this.TreeNameLabel.Size = new System.Drawing.Size(60, 13);
            this.TreeNameLabel.TabIndex = 11;
            this.TreeNameLabel.Text = "Tree Name";
            // 
            // TreeBackgroundLabel
            // 
            this.TreeBackgroundLabel.AutoSize = true;
            this.TreeBackgroundLabel.ForeColor = System.Drawing.Color.White;
            this.TreeBackgroundLabel.Location = new System.Drawing.Point(493, 57);
            this.TreeBackgroundLabel.Name = "TreeBackgroundLabel";
            this.TreeBackgroundLabel.Size = new System.Drawing.Size(90, 13);
            this.TreeBackgroundLabel.TabIndex = 27;
            this.TreeBackgroundLabel.Text = "Tree Background";
            // 
            // TreeBackgoundTextBox
            // 
            this.TreeBackgoundTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.TreeBackgoundTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TreeBackgoundTextBox.ForeColor = System.Drawing.Color.White;
            this.TreeBackgoundTextBox.Location = new System.Drawing.Point(496, 73);
            this.TreeBackgoundTextBox.Name = "TreeBackgoundTextBox";
            this.TreeBackgoundTextBox.Size = new System.Drawing.Size(192, 20);
            this.TreeBackgoundTextBox.TabIndex = 26;
            // 
            // EnhancementTreePanel
            // 
            this.EnhancementTreePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnhancementTreePanel.Controls.Add(this.EnhancementTreeControl);
            this.EnhancementTreePanel.Controls.Add(this.EnhancementTreeLabel);
            this.EnhancementTreePanel.Location = new System.Drawing.Point(183, 6);
            this.EnhancementTreePanel.Name = "EnhancementTreePanel";
            this.EnhancementTreePanel.Size = new System.Drawing.Size(304, 489);
            this.EnhancementTreePanel.TabIndex = 30;
            // 
            // EnhancementTreeControl
            // 
            this.EnhancementTreeControl.APSpentText = "0 AP Spent";
            this.EnhancementTreeControl.BackColor = System.Drawing.Color.Black;
            this.EnhancementTreeControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnhancementTreeControl.BackgroundImage")));
            this.EnhancementTreeControl.ButtonText = "Add Arrow";
            this.EnhancementTreeControl.DisplayMode = DDOCharacterPlanner.Screens.Controls.TreeControl.TCMode.Design;
            this.EnhancementTreeControl.Location = new System.Drawing.Point(2, 21);
            this.EnhancementTreeControl.Name = "EnhancementTreeControl";
            this.EnhancementTreeControl.SelectableMode = true;
            this.EnhancementTreeControl.SelectedIndex = 0;
            this.EnhancementTreeControl.Size = new System.Drawing.Size(298, 464);
            this.EnhancementTreeControl.TabIndex = 0;
            this.EnhancementTreeControl.TreeText = "Tree Name";
            this.EnhancementTreeControl.SelectedIndexChanged += new System.EventHandler(this.EnhancementTreeControl_SelectedIndexChanged);
            this.EnhancementTreeControl.SlotAdded += new System.EventHandler<DDOCharacterPlanner.Screens.Controls.TreeControl.TreeEventArgs>(this.EnhancementTreeControl_SlotAdded);
            this.EnhancementTreeControl.SlotRemoved += new System.EventHandler<DDOCharacterPlanner.Screens.Controls.TreeControl.TreeEventArgs>(this.EnhancementTreeControl_SlotRemoved);
            this.EnhancementTreeControl.SlotMouseClick += new System.EventHandler<DDOCharacterPlanner.Screens.Controls.TreeControl.TreeEventArgs>(this.EnhancementTreeControl_SlotMouseClick);
            this.EnhancementTreeControl.SlotMouseDoubleClick += new System.EventHandler<DDOCharacterPlanner.Screens.Controls.TreeControl.TreeEventArgs>(this.EnhancementTreeControl_SlotMouseDoubleClick);
            // 
            // EnhancementTreeLabel
            // 
            this.EnhancementTreeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(182)))), ((int)(((byte)(231)))));
            this.EnhancementTreeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.EnhancementTreeLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnhancementTreeLabel.ForeColor = System.Drawing.Color.White;
            this.EnhancementTreeLabel.Location = new System.Drawing.Point(0, 0);
            this.EnhancementTreeLabel.Name = "EnhancementTreeLabel";
            this.EnhancementTreeLabel.Size = new System.Drawing.Size(302, 20);
            this.EnhancementTreeLabel.TabIndex = 28;
            this.EnhancementTreeLabel.Text = "Enhancement Tree";
            this.EnhancementTreeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTreeBackgroundBrowse
            // 
            this.btnTreeBackgroundBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(125)))), ((int)(((byte)(130)))));
            this.btnTreeBackgroundBrowse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(125)))), ((int)(((byte)(130)))));
            this.btnTreeBackgroundBrowse.FlatAppearance.BorderSize = 0;
            this.btnTreeBackgroundBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTreeBackgroundBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnTreeBackgroundBrowse.Image")));
            this.btnTreeBackgroundBrowse.Location = new System.Drawing.Point(688, 71);
            this.btnTreeBackgroundBrowse.Name = "btnTreeBackgroundBrowse";
            this.btnTreeBackgroundBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnTreeBackgroundBrowse.TabIndex = 31;
            this.btnTreeBackgroundBrowse.UseVisualStyleBackColor = false;
            this.btnTreeBackgroundBrowse.Click += new System.EventHandler(this.OnbtnTreeBackgroundBrowseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(8, 506);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Record GUID:";
            // 
            // RecordGuidLabel
            // 
            this.RecordGuidLabel.AutoSize = true;
            this.RecordGuidLabel.ForeColor = System.Drawing.Color.Gray;
            this.RecordGuidLabel.Location = new System.Drawing.Point(84, 506);
            this.RecordGuidLabel.Name = "RecordGuidLabel";
            this.RecordGuidLabel.Size = new System.Drawing.Size(67, 13);
            this.RecordGuidLabel.TabIndex = 34;
            this.RecordGuidLabel.Text = "Record Guid";
            // 
            // ModDateLabel
            // 
            this.ModDateLabel.AutoSize = true;
            this.ModDateLabel.ForeColor = System.Drawing.Color.Gray;
            this.ModDateLabel.Location = new System.Drawing.Point(99, 523);
            this.ModDateLabel.Name = "ModDateLabel";
            this.ModDateLabel.Size = new System.Drawing.Size(54, 13);
            this.ModDateLabel.TabIndex = 35;
            this.ModDateLabel.Text = "Mod Date";
            // 
            // ModVersionLabel
            // 
            this.ModVersionLabel.AutoSize = true;
            this.ModVersionLabel.ForeColor = System.Drawing.Color.Gray;
            this.ModVersionLabel.Location = new System.Drawing.Point(309, 521);
            this.ModVersionLabel.Name = "ModVersionLabel";
            this.ModVersionLabel.Size = new System.Drawing.Size(66, 13);
            this.ModVersionLabel.TabIndex = 36;
            this.ModVersionLabel.Text = "Mod Version";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Gray;
            this.label17.Location = new System.Drawing.Point(192, 521);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 13);
            this.label17.TabIndex = 37;
            this.label17.Text = "Using Planner Version";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Gray;
            this.label18.Location = new System.Drawing.Point(6, 523);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 13);
            this.label18.TabIndex = 38;
            this.label18.Text = "Last Modification";
            // 
            // EnhacementSlotPanel
            // 
            this.EnhacementSlotPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnhacementSlotPanel.Controls.Add(this.label2);
            this.EnhacementSlotPanel.Location = new System.Drawing.Point(493, 350);
            this.EnhacementSlotPanel.Name = "EnhacementSlotPanel";
            this.EnhacementSlotPanel.Size = new System.Drawing.Size(274, 145);
            this.EnhacementSlotPanel.TabIndex = 40;
            this.EnhacementSlotPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(182)))), ((int)(((byte)(231)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Enhancement Slot Information";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RaceRadioButton
            // 
            this.RaceRadioButton.AutoSize = true;
            this.RaceRadioButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.RaceRadioButton.Location = new System.Drawing.Point(2, 1);
            this.RaceRadioButton.Name = "RaceRadioButton";
            this.RaceRadioButton.Size = new System.Drawing.Size(51, 17);
            this.RaceRadioButton.TabIndex = 41;
            this.RaceRadioButton.TabStop = true;
            this.RaceRadioButton.Text = "Race";
            this.RaceRadioButton.UseVisualStyleBackColor = true;
            this.RaceRadioButton.Click += new System.EventHandler(this.RaceRadioButton_Click);
            // 
            // ClassRadioButton
            // 
            this.ClassRadioButton.AutoSize = true;
            this.ClassRadioButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ClassRadioButton.Location = new System.Drawing.Point(84, 1);
            this.ClassRadioButton.Name = "ClassRadioButton";
            this.ClassRadioButton.Size = new System.Drawing.Size(50, 17);
            this.ClassRadioButton.TabIndex = 42;
            this.ClassRadioButton.TabStop = true;
            this.ClassRadioButton.Text = "Class";
            this.ClassRadioButton.UseVisualStyleBackColor = true;
            this.ClassRadioButton.Click += new System.EventHandler(this.ClassRadioButton_Click);
            // 
            // TreeTypeLabel
            // 
            this.TreeTypeLabel.AutoSize = true;
            this.TreeTypeLabel.ForeColor = System.Drawing.Color.White;
            this.TreeTypeLabel.Location = new System.Drawing.Point(495, 109);
            this.TreeTypeLabel.Name = "TreeTypeLabel";
            this.TreeTypeLabel.Size = new System.Drawing.Size(56, 13);
            this.TreeTypeLabel.TabIndex = 43;
            this.TreeTypeLabel.Text = "Tree Type";
            // 
            // TreeRequirementsPanel
            // 
            this.TreeRequirementsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TreeRequirementsPanel.Controls.Add(this.TreeRP2);
            this.TreeRequirementsPanel.Controls.Add(this.TreeRequirementsLabel);
            this.TreeRequirementsPanel.Location = new System.Drawing.Point(493, 161);
            this.TreeRequirementsPanel.Name = "TreeRequirementsPanel";
            this.TreeRequirementsPanel.Size = new System.Drawing.Size(275, 187);
            this.TreeRequirementsPanel.TabIndex = 45;
            // 
            // TreeRP2
            // 
            this.TreeRP2.BackColor = System.Drawing.Color.Black;
            this.TreeRP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TreeRP2.ControlStyle = DDOCharacterPlanner.Screens.DataInput.RequirementsPanel2.ScreenStyle.Normal;
            this.TreeRP2.Location = new System.Drawing.Point(1, 23);
            this.TreeRP2.MainScreen = DDOCharacterPlanner.Screens.DataInput.RequirementsPanel2.ScreenType.EnhancementTree;
            this.TreeRP2.MinimumSize = new System.Drawing.Size(240, 80);
            this.TreeRP2.Name = "TreeRP2";
            this.TreeRP2.RecordId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.TreeRP2.Size = new System.Drawing.Size(273, 159);
            this.TreeRP2.TabIndex = 32;
            // 
            // TreeRequirementsLabel
            // 
            this.TreeRequirementsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(182)))), ((int)(((byte)(231)))));
            this.TreeRequirementsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TreeRequirementsLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeRequirementsLabel.ForeColor = System.Drawing.Color.White;
            this.TreeRequirementsLabel.Location = new System.Drawing.Point(0, 0);
            this.TreeRequirementsLabel.Name = "TreeRequirementsLabel";
            this.TreeRequirementsLabel.Size = new System.Drawing.Size(273, 20);
            this.TreeRequirementsLabel.TabIndex = 31;
            this.TreeRequirementsLabel.Text = "Tree Requirements";
            this.TreeRequirementsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TreeTypePanel
            // 
            this.TreeTypePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.TreeTypePanel.Controls.Add(this.RaceRadioButton);
            this.TreeTypePanel.Controls.Add(this.ClassRadioButton);
            this.TreeTypePanel.Location = new System.Drawing.Point(497, 125);
            this.TreeTypePanel.Name = "TreeTypePanel";
            this.TreeTypePanel.Size = new System.Drawing.Size(162, 21);
            this.TreeTypePanel.TabIndex = 46;
            // 
            // EnhancemenTreeListPanel
            // 
            this.EnhancemenTreeListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnhancemenTreeListPanel.Controls.Add(this.EnhancementTreeListBoxLabel);
            this.EnhancemenTreeListPanel.Controls.Add(this.EnhancementTreeListBox);
            this.EnhancemenTreeListPanel.Location = new System.Drawing.Point(6, 32);
            this.EnhancemenTreeListPanel.Name = "EnhancemenTreeListPanel";
            this.EnhancemenTreeListPanel.Size = new System.Drawing.Size(170, 463);
            this.EnhancemenTreeListPanel.TabIndex = 47;
            // 
            // buttonDuplicateRecord
            // 
            this.buttonDuplicateRecord.Location = new System.Drawing.Point(703, 12);
            this.buttonDuplicateRecord.Name = "buttonDuplicateRecord";
            this.buttonDuplicateRecord.Size = new System.Drawing.Size(63, 41);
            this.buttonDuplicateRecord.TabIndex = 48;
            this.buttonDuplicateRecord.Text = "Duplicate Record";
            this.buttonDuplicateRecord.UseVisualStyleBackColor = true;
            this.buttonDuplicateRecord.Click += new System.EventHandler(this.buttonDuplicateRecord_Click);
            // 
            // DataInputEnhancementScreenClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(773, 545);
            this.Controls.Add(this.buttonDuplicateRecord);
            this.Controls.Add(this.EnhancemenTreeListPanel);
            this.Controls.Add(this.TreeTypePanel);
            this.Controls.Add(this.TreeRequirementsPanel);
            this.Controls.Add(this.TreeTypeLabel);
            this.Controls.Add(this.EnhacementSlotPanel);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.TreeNameTextBox);
            this.Controls.Add(this.TreeNameLabel);
            this.Controls.Add(this.ModVersionLabel);
            this.Controls.Add(this.TreeBackgoundTextBox);
            this.Controls.Add(this.ModDateLabel);
            this.Controls.Add(this.TreeBackgroundLabel);
            this.Controls.Add(this.RecordGuidLabel);
            this.Controls.Add(this.btnTreeBackgroundBrowse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EnhancementTreePanel);
            this.Controls.Add(this.CancelChangesButton);
            this.Controls.Add(this.DeleteTreeButton);
            this.Controls.Add(this.NewTreeButton);
            this.Controls.Add(this.UpdateTreeButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataInputEnhancementScreenClass";
            this.Text = "DDO Character Planner - Data Input: Enhancements";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataInputEnhancementClassFormClosing);
            this.Load += new System.EventHandler(this.DataInputEnhancementScreenClass_Load);
            this.EnhancementTreePanel.ResumeLayout(false);
            this.EnhacementSlotPanel.ResumeLayout(false);
            this.TreeRequirementsPanel.ResumeLayout(false);
            this.TreeTypePanel.ResumeLayout(false);
            this.TreeTypePanel.PerformLayout();
            this.EnhancemenTreeListPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.ListBox EnhancementTreeListBox;
        private System.Windows.Forms.Label EnhancementTreeListBoxLabel;
        private System.Windows.Forms.Button UpdateTreeButton;
        private System.Windows.Forms.Button NewTreeButton;
        private System.Windows.Forms.Button DeleteTreeButton;
        private System.Windows.Forms.Button CancelChangesButton;
        private System.Windows.Forms.TextBox TreeNameTextBox;
        private System.Windows.Forms.Label TreeNameLabel;
        private System.Windows.Forms.Label TreeBackgroundLabel;
        private System.Windows.Forms.TextBox TreeBackgoundTextBox;
        private System.Windows.Forms.Panel EnhancementTreePanel;
        private Controls.TreeControl EnhancementTreeControl;
        private System.Windows.Forms.Button btnTreeBackgroundBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label RecordGuidLabel;
        private System.Windows.Forms.Label ModDateLabel;
        private System.Windows.Forms.Label ModVersionLabel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label EnhancementTreeLabel;
        private System.Windows.Forms.Panel EnhacementSlotPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RaceRadioButton;
        private System.Windows.Forms.RadioButton ClassRadioButton;
        private System.Windows.Forms.Label TreeTypeLabel;
        private System.Windows.Forms.Panel TreeRequirementsPanel;
        private System.Windows.Forms.Label TreeRequirementsLabel;
        private System.Windows.Forms.Panel TreeTypePanel;
        private System.Windows.Forms.Panel EnhancemenTreeListPanel;
        private RequirementsPanel2 TreeRP2;
        private System.Windows.Forms.Button buttonDuplicateRecord;
        }
    }