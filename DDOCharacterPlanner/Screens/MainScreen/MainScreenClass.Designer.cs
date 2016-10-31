using System;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.MainScreen
	{
	partial class MainScreenClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreenClass));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raceInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.featInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spellInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enhancementInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tomesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnhancementsPanel = new System.Windows.Forms.Panel();
            this.DestinyPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReincarnationButton = new System.Windows.Forms.Button();
            this.AlignmentButton = new System.Windows.Forms.Button();
            this.AlignmentLabel = new System.Windows.Forms.Label();
            this.RaceLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ClassLabel = new System.Windows.Forms.Label();
            this.LevelButton1 = new System.Windows.Forms.Button();
            this.LevelButton16 = new System.Windows.Forms.Button();
            this.LevelButton2 = new System.Windows.Forms.Button();
            this.LevelButton3 = new System.Windows.Forms.Button();
            this.LevelButton4 = new System.Windows.Forms.Button();
            this.LevelButton5 = new System.Windows.Forms.Button();
            this.LevelButton6 = new System.Windows.Forms.Button();
            this.LevelButton7 = new System.Windows.Forms.Button();
            this.LevelButton8 = new System.Windows.Forms.Button();
            this.LevelButton9 = new System.Windows.Forms.Button();
            this.LevelButton10 = new System.Windows.Forms.Button();
            this.LevelButton11 = new System.Windows.Forms.Button();
            this.LevelButton12 = new System.Windows.Forms.Button();
            this.LevelButton13 = new System.Windows.Forms.Button();
            this.LevelButton14 = new System.Windows.Forms.Button();
            this.LevelButton15 = new System.Windows.Forms.Button();
            this.LevelButton17 = new System.Windows.Forms.Button();
            this.LevelButton18 = new System.Windows.Forms.Button();
            this.LevelButton19 = new System.Windows.Forms.Button();
            this.LevelButton20 = new System.Windows.Forms.Button();
            this.LevelButton21 = new System.Windows.Forms.Button();
            this.LevelButton22 = new System.Windows.Forms.Button();
            this.LevelButton23 = new System.Windows.Forms.Button();
            this.LevelButton24 = new System.Windows.Forms.Button();
            this.LevelButton25 = new System.Windows.Forms.Button();
            this.LevelButton26 = new System.Windows.Forms.Button();
            this.LevelButton27 = new System.Windows.Forms.Button();
            this.LevelButton28 = new System.Windows.Forms.Button();
            this.LevelButton29 = new System.Windows.Forms.Button();
            this.LevelButton30 = new System.Windows.Forms.Button();
            this.buttonEditClasses = new System.Windows.Forms.Button();
            this.labelClasses = new System.Windows.Forms.Label();
            this.labelRace = new System.Windows.Forms.Label();
            this.mainScreenFeatsPanel1 = new DDOCharacterPlanner.Screens.MainScreen.MainScreenFeatsPanel();
            this.mainScreenAdditionStatsPanel1 = new DDOCharacterPlanner.Screens.MainScreen.MainScreenAdditionStatsPanel();
            this.mainScreenAbilitiesPanel1 = new DDOCharacterPlanner.Screens.MainScreen.MainScreenAbilitiesPanel();
            this.SkillPanel = new DDOCharacterPlanner.Screens.MainScreen.MainScreenSkillPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exportTextFileToolStripMenuItem,
            this.importTextFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveToolStripMenuItem.Text = "Save Character";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.loadToolStripMenuItem.Text = "Load Character";
            // 
            // exportTextFileToolStripMenuItem
            // 
            this.exportTextFileToolStripMenuItem.Name = "exportTextFileToolStripMenuItem";
            this.exportTextFileToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.exportTextFileToolStripMenuItem.Text = "Export Text File";
            // 
            // importTextFileToolStripMenuItem
            // 
            this.importTextFileToolStripMenuItem.Name = "importTextFileToolStripMenuItem";
            this.importTextFileToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.importTextFileToolStripMenuItem.Text = "Import Text File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.skinEditorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.characterInputToolStripMenuItem,
            this.raceInputToolStripMenuItem,
            this.classInputToolStripMenuItem,
            this.featInputToolStripMenuItem,
            this.spellInputToolStripMenuItem,
            this.enhancementInputToolStripMenuItem,
            this.tomesToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // characterInputToolStripMenuItem
            // 
            this.characterInputToolStripMenuItem.Name = "characterInputToolStripMenuItem";
            this.characterInputToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.characterInputToolStripMenuItem.Text = "Character Input";
            this.characterInputToolStripMenuItem.Click += new System.EventHandler(this.CharacterInputToolStripMenuItemClick);
            // 
            // raceInputToolStripMenuItem
            // 
            this.raceInputToolStripMenuItem.Name = "raceInputToolStripMenuItem";
            this.raceInputToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.raceInputToolStripMenuItem.Text = "Race Input";
            this.raceInputToolStripMenuItem.Click += new System.EventHandler(this.RaceInputToolStripMenuItemClick);
            // 
            // classInputToolStripMenuItem
            // 
            this.classInputToolStripMenuItem.Name = "classInputToolStripMenuItem";
            this.classInputToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.classInputToolStripMenuItem.Text = "Class Input";
            this.classInputToolStripMenuItem.Click += new System.EventHandler(this.ClassInputToolStripMenuItemClick);
            // 
            // featInputToolStripMenuItem
            // 
            this.featInputToolStripMenuItem.Name = "featInputToolStripMenuItem";
            this.featInputToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.featInputToolStripMenuItem.Text = "Feat Input";
            this.featInputToolStripMenuItem.Click += new System.EventHandler(this.FeatInputToolStripMenuItemClick);
            // 
            // spellInputToolStripMenuItem
            // 
            this.spellInputToolStripMenuItem.Name = "spellInputToolStripMenuItem";
            this.spellInputToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.spellInputToolStripMenuItem.Text = "Spell Input";
            this.spellInputToolStripMenuItem.Click += new System.EventHandler(this.SpellInputToolStripMenuItemClick);
            // 
            // enhancementInputToolStripMenuItem
            // 
            this.enhancementInputToolStripMenuItem.Name = "enhancementInputToolStripMenuItem";
            this.enhancementInputToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.enhancementInputToolStripMenuItem.Text = "Enhancement Input";
            this.enhancementInputToolStripMenuItem.Click += new System.EventHandler(this.EnhancementInputToolStripMenuItemClick);
            // 
            // tomesToolStripMenuItem
            // 
            this.tomesToolStripMenuItem.Name = "tomesToolStripMenuItem";
            this.tomesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.tomesToolStripMenuItem.Text = "Tomes";
            this.tomesToolStripMenuItem.Click += new System.EventHandler(this.TomesToolStripMenuItemClick);
            // 
            // skinEditorToolStripMenuItem
            // 
            this.skinEditorToolStripMenuItem.Name = "skinEditorToolStripMenuItem";
            this.skinEditorToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.skinEditorToolStripMenuItem.Text = "Skin Editor";
            this.skinEditorToolStripMenuItem.Click += new System.EventHandler(this.SkinEditorToolStripMenuItemClick);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // EnhancementsPanel
            // 
            this.EnhancementsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EnhancementsPanel.Location = new System.Drawing.Point(724, 80);
            this.EnhancementsPanel.Name = "EnhancementsPanel";
            this.EnhancementsPanel.Size = new System.Drawing.Size(272, 291);
            this.EnhancementsPanel.TabIndex = 5;
            // 
            // DestinyPanel
            // 
            this.DestinyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DestinyPanel.Location = new System.Drawing.Point(430, 377);
            this.DestinyPanel.Name = "DestinyPanel";
            this.DestinyPanel.Size = new System.Drawing.Size(287, 340);
            this.DestinyPanel.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(724, 377);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 340);
            this.panel1.TabIndex = 7;
            // 
            // ReincarnationButton
            // 
            this.ReincarnationButton.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.ReincarnationButton.Location = new System.Drawing.Point(7, 48);
            this.ReincarnationButton.Name = "ReincarnationButton";
            this.ReincarnationButton.Size = new System.Drawing.Size(84, 23);
            this.ReincarnationButton.TabIndex = 9;
            this.ReincarnationButton.Text = "Past Life";
            this.ReincarnationButton.UseVisualStyleBackColor = true;
            this.ReincarnationButton.Click += new System.EventHandler(this.ReincarnationButton_Click);
            // 
            // AlignmentButton
            // 
            this.AlignmentButton.BackColor = System.Drawing.Color.Silver;
            this.AlignmentButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AlignmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlignmentButton.ForeColor = System.Drawing.Color.Black;
            this.AlignmentButton.Location = new System.Drawing.Point(900, 48);
            this.AlignmentButton.Name = "AlignmentButton";
            this.AlignmentButton.Size = new System.Drawing.Size(96, 23);
            this.AlignmentButton.TabIndex = 10;
            this.AlignmentButton.Text = "Chaotic Neutral";
            this.AlignmentButton.UseVisualStyleBackColor = false;
            this.AlignmentButton.Click += new System.EventHandler(this.OnAlignmentButtonClick);
            // 
            // AlignmentLabel
            // 
            this.AlignmentLabel.AutoSize = true;
            this.AlignmentLabel.ForeColor = System.Drawing.Color.White;
            this.AlignmentLabel.Location = new System.Drawing.Point(900, 32);
            this.AlignmentLabel.Name = "AlignmentLabel";
            this.AlignmentLabel.Size = new System.Drawing.Size(53, 13);
            this.AlignmentLabel.TabIndex = 11;
            this.AlignmentLabel.Text = "Alignment";
            // 
            // RaceLabel
            // 
            this.RaceLabel.AutoSize = true;
            this.RaceLabel.ForeColor = System.Drawing.Color.White;
            this.RaceLabel.Location = new System.Drawing.Point(97, 53);
            this.RaceLabel.Name = "RaceLabel";
            this.RaceLabel.Size = new System.Drawing.Size(33, 13);
            this.RaceLabel.TabIndex = 13;
            this.RaceLabel.Text = "Race";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.ForeColor = System.Drawing.Color.White;
            this.NameLabel.Location = new System.Drawing.Point(391, 32);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 14;
            this.NameLabel.Text = "Name";
            // 
            // ClassLabel
            // 
            this.ClassLabel.AutoSize = true;
            this.ClassLabel.ForeColor = System.Drawing.Color.White;
            this.ClassLabel.Location = new System.Drawing.Point(392, 53);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(35, 13);
            this.ClassLabel.TabIndex = 15;
            this.ClassLabel.Text = "Class ";
            // 
            // LevelButton1
            // 
            this.LevelButton1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton1.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton1.FlatAppearance.BorderSize = 0;
            this.LevelButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LevelButton1.Location = new System.Drawing.Point(7, 83);
            this.LevelButton1.Name = "LevelButton1";
            this.LevelButton1.Size = new System.Drawing.Size(27, 23);
            this.LevelButton1.TabIndex = 16;
            this.LevelButton1.Text = "1";
            this.LevelButton1.UseVisualStyleBackColor = false;
            this.LevelButton1.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton16
            // 
            this.LevelButton16.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton16.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton16.FlatAppearance.BorderSize = 0;
            this.LevelButton16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton16.Location = new System.Drawing.Point(40, 83);
            this.LevelButton16.Name = "LevelButton16";
            this.LevelButton16.Size = new System.Drawing.Size(27, 23);
            this.LevelButton16.TabIndex = 17;
            this.LevelButton16.Text = "16";
            this.LevelButton16.UseVisualStyleBackColor = false;
            this.LevelButton16.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton2
            // 
            this.LevelButton2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton2.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton2.FlatAppearance.BorderSize = 0;
            this.LevelButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton2.Location = new System.Drawing.Point(7, 112);
            this.LevelButton2.Name = "LevelButton2";
            this.LevelButton2.Size = new System.Drawing.Size(27, 23);
            this.LevelButton2.TabIndex = 18;
            this.LevelButton2.Text = "2";
            this.LevelButton2.UseVisualStyleBackColor = false;
            this.LevelButton2.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton3
            // 
            this.LevelButton3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton3.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton3.FlatAppearance.BorderSize = 0;
            this.LevelButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton3.Location = new System.Drawing.Point(7, 141);
            this.LevelButton3.Name = "LevelButton3";
            this.LevelButton3.Size = new System.Drawing.Size(27, 23);
            this.LevelButton3.TabIndex = 19;
            this.LevelButton3.Text = "3";
            this.LevelButton3.UseVisualStyleBackColor = false;
            this.LevelButton3.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton4
            // 
            this.LevelButton4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton4.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton4.FlatAppearance.BorderSize = 0;
            this.LevelButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton4.Location = new System.Drawing.Point(7, 170);
            this.LevelButton4.Name = "LevelButton4";
            this.LevelButton4.Size = new System.Drawing.Size(27, 23);
            this.LevelButton4.TabIndex = 20;
            this.LevelButton4.Text = "4";
            this.LevelButton4.UseVisualStyleBackColor = false;
            this.LevelButton4.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton5
            // 
            this.LevelButton5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton5.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton5.FlatAppearance.BorderSize = 0;
            this.LevelButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton5.Location = new System.Drawing.Point(7, 199);
            this.LevelButton5.Name = "LevelButton5";
            this.LevelButton5.Size = new System.Drawing.Size(27, 23);
            this.LevelButton5.TabIndex = 21;
            this.LevelButton5.Text = "5";
            this.LevelButton5.UseVisualStyleBackColor = false;
            this.LevelButton5.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton6
            // 
            this.LevelButton6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton6.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton6.FlatAppearance.BorderSize = 0;
            this.LevelButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton6.Location = new System.Drawing.Point(7, 228);
            this.LevelButton6.Name = "LevelButton6";
            this.LevelButton6.Size = new System.Drawing.Size(27, 23);
            this.LevelButton6.TabIndex = 22;
            this.LevelButton6.Text = "6";
            this.LevelButton6.UseVisualStyleBackColor = false;
            this.LevelButton6.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton7
            // 
            this.LevelButton7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton7.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton7.FlatAppearance.BorderSize = 0;
            this.LevelButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton7.Location = new System.Drawing.Point(7, 257);
            this.LevelButton7.Name = "LevelButton7";
            this.LevelButton7.Size = new System.Drawing.Size(27, 23);
            this.LevelButton7.TabIndex = 23;
            this.LevelButton7.Text = "7";
            this.LevelButton7.UseVisualStyleBackColor = false;
            this.LevelButton7.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton8
            // 
            this.LevelButton8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton8.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton8.FlatAppearance.BorderSize = 0;
            this.LevelButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton8.Location = new System.Drawing.Point(7, 286);
            this.LevelButton8.Name = "LevelButton8";
            this.LevelButton8.Size = new System.Drawing.Size(27, 23);
            this.LevelButton8.TabIndex = 24;
            this.LevelButton8.Text = "8";
            this.LevelButton8.UseVisualStyleBackColor = false;
            this.LevelButton8.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton9
            // 
            this.LevelButton9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton9.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton9.FlatAppearance.BorderSize = 0;
            this.LevelButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton9.Location = new System.Drawing.Point(7, 315);
            this.LevelButton9.Name = "LevelButton9";
            this.LevelButton9.Size = new System.Drawing.Size(27, 23);
            this.LevelButton9.TabIndex = 25;
            this.LevelButton9.Text = "9";
            this.LevelButton9.UseVisualStyleBackColor = false;
            this.LevelButton9.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton10
            // 
            this.LevelButton10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton10.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton10.FlatAppearance.BorderSize = 0;
            this.LevelButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton10.Location = new System.Drawing.Point(7, 344);
            this.LevelButton10.Name = "LevelButton10";
            this.LevelButton10.Size = new System.Drawing.Size(27, 23);
            this.LevelButton10.TabIndex = 26;
            this.LevelButton10.Text = "10";
            this.LevelButton10.UseVisualStyleBackColor = false;
            this.LevelButton10.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton11
            // 
            this.LevelButton11.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton11.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton11.FlatAppearance.BorderSize = 0;
            this.LevelButton11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton11.Location = new System.Drawing.Point(7, 373);
            this.LevelButton11.Name = "LevelButton11";
            this.LevelButton11.Size = new System.Drawing.Size(27, 23);
            this.LevelButton11.TabIndex = 27;
            this.LevelButton11.Text = "11";
            this.LevelButton11.UseVisualStyleBackColor = false;
            this.LevelButton11.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton12
            // 
            this.LevelButton12.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton12.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton12.FlatAppearance.BorderSize = 0;
            this.LevelButton12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton12.Location = new System.Drawing.Point(7, 402);
            this.LevelButton12.Name = "LevelButton12";
            this.LevelButton12.Size = new System.Drawing.Size(27, 23);
            this.LevelButton12.TabIndex = 28;
            this.LevelButton12.Text = "12";
            this.LevelButton12.UseVisualStyleBackColor = false;
            this.LevelButton12.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton13
            // 
            this.LevelButton13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton13.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton13.FlatAppearance.BorderSize = 0;
            this.LevelButton13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton13.Location = new System.Drawing.Point(7, 431);
            this.LevelButton13.Name = "LevelButton13";
            this.LevelButton13.Size = new System.Drawing.Size(27, 23);
            this.LevelButton13.TabIndex = 29;
            this.LevelButton13.Text = "13";
            this.LevelButton13.UseVisualStyleBackColor = false;
            this.LevelButton13.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton14
            // 
            this.LevelButton14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton14.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton14.FlatAppearance.BorderSize = 0;
            this.LevelButton14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton14.Location = new System.Drawing.Point(7, 460);
            this.LevelButton14.Name = "LevelButton14";
            this.LevelButton14.Size = new System.Drawing.Size(27, 23);
            this.LevelButton14.TabIndex = 30;
            this.LevelButton14.Text = "14";
            this.LevelButton14.UseVisualStyleBackColor = false;
            this.LevelButton14.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton15
            // 
            this.LevelButton15.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton15.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton15.FlatAppearance.BorderSize = 0;
            this.LevelButton15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton15.Location = new System.Drawing.Point(7, 489);
            this.LevelButton15.Name = "LevelButton15";
            this.LevelButton15.Size = new System.Drawing.Size(27, 23);
            this.LevelButton15.TabIndex = 31;
            this.LevelButton15.Text = "15";
            this.LevelButton15.UseVisualStyleBackColor = false;
            this.LevelButton15.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton17
            // 
            this.LevelButton17.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton17.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton17.FlatAppearance.BorderSize = 0;
            this.LevelButton17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton17.Location = new System.Drawing.Point(40, 112);
            this.LevelButton17.Name = "LevelButton17";
            this.LevelButton17.Size = new System.Drawing.Size(27, 23);
            this.LevelButton17.TabIndex = 32;
            this.LevelButton17.Text = "17";
            this.LevelButton17.UseVisualStyleBackColor = false;
            this.LevelButton17.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton18
            // 
            this.LevelButton18.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton18.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton18.FlatAppearance.BorderSize = 0;
            this.LevelButton18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton18.Location = new System.Drawing.Point(40, 141);
            this.LevelButton18.Name = "LevelButton18";
            this.LevelButton18.Size = new System.Drawing.Size(27, 23);
            this.LevelButton18.TabIndex = 33;
            this.LevelButton18.Text = "18";
            this.LevelButton18.UseVisualStyleBackColor = false;
            this.LevelButton18.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton19
            // 
            this.LevelButton19.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton19.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton19.FlatAppearance.BorderSize = 0;
            this.LevelButton19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton19.Location = new System.Drawing.Point(40, 170);
            this.LevelButton19.Name = "LevelButton19";
            this.LevelButton19.Size = new System.Drawing.Size(27, 23);
            this.LevelButton19.TabIndex = 34;
            this.LevelButton19.Text = "19";
            this.LevelButton19.UseVisualStyleBackColor = false;
            this.LevelButton19.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton20
            // 
            this.LevelButton20.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton20.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton20.FlatAppearance.BorderSize = 0;
            this.LevelButton20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton20.Location = new System.Drawing.Point(40, 199);
            this.LevelButton20.Name = "LevelButton20";
            this.LevelButton20.Size = new System.Drawing.Size(27, 23);
            this.LevelButton20.TabIndex = 35;
            this.LevelButton20.Text = "20";
            this.LevelButton20.UseVisualStyleBackColor = false;
            this.LevelButton20.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton21
            // 
            this.LevelButton21.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton21.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton21.FlatAppearance.BorderSize = 0;
            this.LevelButton21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton21.Location = new System.Drawing.Point(40, 228);
            this.LevelButton21.Name = "LevelButton21";
            this.LevelButton21.Size = new System.Drawing.Size(27, 23);
            this.LevelButton21.TabIndex = 36;
            this.LevelButton21.Text = "21";
            this.LevelButton21.UseVisualStyleBackColor = false;
            this.LevelButton21.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton22
            // 
            this.LevelButton22.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton22.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton22.FlatAppearance.BorderSize = 0;
            this.LevelButton22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton22.Location = new System.Drawing.Point(40, 257);
            this.LevelButton22.Name = "LevelButton22";
            this.LevelButton22.Size = new System.Drawing.Size(27, 23);
            this.LevelButton22.TabIndex = 37;
            this.LevelButton22.Text = "22";
            this.LevelButton22.UseVisualStyleBackColor = false;
            this.LevelButton22.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton23
            // 
            this.LevelButton23.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton23.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton23.FlatAppearance.BorderSize = 0;
            this.LevelButton23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton23.Location = new System.Drawing.Point(40, 286);
            this.LevelButton23.Name = "LevelButton23";
            this.LevelButton23.Size = new System.Drawing.Size(27, 23);
            this.LevelButton23.TabIndex = 38;
            this.LevelButton23.Text = "23";
            this.LevelButton23.UseVisualStyleBackColor = false;
            this.LevelButton23.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton24
            // 
            this.LevelButton24.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton24.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton24.FlatAppearance.BorderSize = 0;
            this.LevelButton24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton24.Location = new System.Drawing.Point(40, 315);
            this.LevelButton24.Name = "LevelButton24";
            this.LevelButton24.Size = new System.Drawing.Size(27, 23);
            this.LevelButton24.TabIndex = 39;
            this.LevelButton24.Text = "24";
            this.LevelButton24.UseVisualStyleBackColor = false;
            this.LevelButton24.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton25
            // 
            this.LevelButton25.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton25.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton25.FlatAppearance.BorderSize = 0;
            this.LevelButton25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton25.Location = new System.Drawing.Point(40, 344);
            this.LevelButton25.Name = "LevelButton25";
            this.LevelButton25.Size = new System.Drawing.Size(27, 23);
            this.LevelButton25.TabIndex = 40;
            this.LevelButton25.Text = "25";
            this.LevelButton25.UseVisualStyleBackColor = false;
            this.LevelButton25.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton26
            // 
            this.LevelButton26.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton26.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton26.FlatAppearance.BorderSize = 0;
            this.LevelButton26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton26.Location = new System.Drawing.Point(40, 373);
            this.LevelButton26.Name = "LevelButton26";
            this.LevelButton26.Size = new System.Drawing.Size(27, 23);
            this.LevelButton26.TabIndex = 41;
            this.LevelButton26.Text = "26";
            this.LevelButton26.UseVisualStyleBackColor = false;
            this.LevelButton26.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton27
            // 
            this.LevelButton27.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton27.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton27.FlatAppearance.BorderSize = 0;
            this.LevelButton27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton27.Location = new System.Drawing.Point(40, 402);
            this.LevelButton27.Name = "LevelButton27";
            this.LevelButton27.Size = new System.Drawing.Size(27, 23);
            this.LevelButton27.TabIndex = 42;
            this.LevelButton27.Text = "27";
            this.LevelButton27.UseVisualStyleBackColor = false;
            this.LevelButton27.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton28
            // 
            this.LevelButton28.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton28.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton28.FlatAppearance.BorderSize = 0;
            this.LevelButton28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton28.Location = new System.Drawing.Point(40, 431);
            this.LevelButton28.Name = "LevelButton28";
            this.LevelButton28.Size = new System.Drawing.Size(27, 23);
            this.LevelButton28.TabIndex = 43;
            this.LevelButton28.Text = "28";
            this.LevelButton28.UseVisualStyleBackColor = false;
            this.LevelButton28.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton29
            // 
            this.LevelButton29.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton29.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton29.FlatAppearance.BorderSize = 0;
            this.LevelButton29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton29.Location = new System.Drawing.Point(40, 460);
            this.LevelButton29.Name = "LevelButton29";
            this.LevelButton29.Size = new System.Drawing.Size(27, 23);
            this.LevelButton29.TabIndex = 44;
            this.LevelButton29.Text = "29";
            this.LevelButton29.UseVisualStyleBackColor = false;
            this.LevelButton29.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // LevelButton30
            // 
            this.LevelButton30.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LevelButton30.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.LevelButton30.FlatAppearance.BorderSize = 0;
            this.LevelButton30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LevelButton30.Location = new System.Drawing.Point(40, 489);
            this.LevelButton30.Name = "LevelButton30";
            this.LevelButton30.Size = new System.Drawing.Size(27, 23);
            this.LevelButton30.TabIndex = 45;
            this.LevelButton30.Text = "30";
            this.LevelButton30.UseVisualStyleBackColor = false;
            this.LevelButton30.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // buttonEditClasses
            // 
            this.buttonEditClasses.Location = new System.Drawing.Point(264, 48);
            this.buttonEditClasses.Name = "buttonEditClasses";
            this.buttonEditClasses.Size = new System.Drawing.Size(121, 23);
            this.buttonEditClasses.TabIndex = 50;
            this.buttonEditClasses.Text = "Edit Race / Classes";
            this.buttonEditClasses.UseVisualStyleBackColor = true;
            this.buttonEditClasses.Click += new System.EventHandler(this.buttonEditClasses_Click);
            // 
            // labelClasses
            // 
            this.labelClasses.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClasses.ForeColor = System.Drawing.Color.Black;
            this.labelClasses.Location = new System.Drawing.Point(432, 51);
            this.labelClasses.Name = "labelClasses";
            this.labelClasses.Size = new System.Drawing.Size(284, 18);
            this.labelClasses.TabIndex = 51;
            // 
            // labelRace
            // 
            this.labelRace.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRace.ForeColor = System.Drawing.Color.Black;
            this.labelRace.Location = new System.Drawing.Point(136, 51);
            this.labelRace.Name = "labelRace";
            this.labelRace.Size = new System.Drawing.Size(122, 17);
            this.labelRace.TabIndex = 52;
            // 
            // mainScreenFeatsPanel1
            // 
            this.mainScreenFeatsPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainScreenFeatsPanel1.Location = new System.Drawing.Point(431, 79);
            this.mainScreenFeatsPanel1.Name = "mainScreenFeatsPanel1";
            this.mainScreenFeatsPanel1.Size = new System.Drawing.Size(287, 291);
            this.mainScreenFeatsPanel1.TabIndex = 53;
            // 
            // mainScreenAdditionStatsPanel1
            // 
            this.mainScreenAdditionStatsPanel1.BackColor = System.Drawing.Color.Black;
            this.mainScreenAdditionStatsPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainScreenAdditionStatsPanel1.Location = new System.Drawing.Point(73, 285);
            this.mainScreenAdditionStatsPanel1.Name = "mainScreenAdditionStatsPanel1";
            this.mainScreenAdditionStatsPanel1.Size = new System.Drawing.Size(350, 227);
            this.mainScreenAdditionStatsPanel1.TabIndex = 47;
            // 
            // mainScreenAbilitiesPanel1
            // 
            this.mainScreenAbilitiesPanel1.BackColor = System.Drawing.Color.Black;
            this.mainScreenAbilitiesPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainScreenAbilitiesPanel1.Location = new System.Drawing.Point(73, 79);
            this.mainScreenAbilitiesPanel1.Name = "mainScreenAbilitiesPanel1";
            this.mainScreenAbilitiesPanel1.Size = new System.Drawing.Size(350, 200);
            this.mainScreenAbilitiesPanel1.TabIndex = 46;
            this.mainScreenAbilitiesPanel1.Load += new System.EventHandler(this.mainScreenAbilitiesPanel1_Load);
            // 
            // SkillPanel
            // 
            this.SkillPanel.BackColor = System.Drawing.Color.Black;
            this.SkillPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SkillPanel.Location = new System.Drawing.Point(7, 518);
            this.SkillPanel.Name = "SkillPanel";
            this.SkillPanel.Size = new System.Drawing.Size(416, 199);
            this.SkillPanel.TabIndex = 8;
            this.SkillPanel.Load += new System.EventHandler(this.SkillPanel_Load);
            // 
            // MainScreenClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.mainScreenFeatsPanel1);
            this.Controls.Add(this.labelRace);
            this.Controls.Add(this.labelClasses);
            this.Controls.Add(this.buttonEditClasses);
            this.Controls.Add(this.mainScreenAdditionStatsPanel1);
            this.Controls.Add(this.mainScreenAbilitiesPanel1);
            this.Controls.Add(this.LevelButton30);
            this.Controls.Add(this.LevelButton29);
            this.Controls.Add(this.LevelButton28);
            this.Controls.Add(this.LevelButton27);
            this.Controls.Add(this.LevelButton26);
            this.Controls.Add(this.LevelButton25);
            this.Controls.Add(this.LevelButton24);
            this.Controls.Add(this.LevelButton23);
            this.Controls.Add(this.LevelButton22);
            this.Controls.Add(this.LevelButton21);
            this.Controls.Add(this.LevelButton20);
            this.Controls.Add(this.LevelButton19);
            this.Controls.Add(this.LevelButton18);
            this.Controls.Add(this.LevelButton17);
            this.Controls.Add(this.LevelButton15);
            this.Controls.Add(this.LevelButton14);
            this.Controls.Add(this.LevelButton13);
            this.Controls.Add(this.LevelButton12);
            this.Controls.Add(this.LevelButton11);
            this.Controls.Add(this.LevelButton10);
            this.Controls.Add(this.LevelButton9);
            this.Controls.Add(this.LevelButton8);
            this.Controls.Add(this.LevelButton7);
            this.Controls.Add(this.LevelButton6);
            this.Controls.Add(this.LevelButton5);
            this.Controls.Add(this.LevelButton4);
            this.Controls.Add(this.LevelButton3);
            this.Controls.Add(this.LevelButton2);
            this.Controls.Add(this.LevelButton16);
            this.Controls.Add(this.LevelButton1);
            this.Controls.Add(this.ClassLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.RaceLabel);
            this.Controls.Add(this.AlignmentLabel);
            this.Controls.Add(this.AlignmentButton);
            this.Controls.Add(this.ReincarnationButton);
            this.Controls.Add(this.SkillPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DestinyPanel);
            this.Controls.Add(this.EnhancementsPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainScreenClass";
            this.Text = "DDO Character Planner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainScreenClassFormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

			}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem saveToolStripMenuItem;
		private ToolStripMenuItem loadToolStripMenuItem;
		private ToolStripMenuItem editToolStripMenuItem;
		private ToolStripMenuItem toolsToolStripMenuItem;
		private ToolStripMenuItem databaseToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
		private Panel EnhancementsPanel;
		private Panel DestinyPanel;
		private Panel panel1;
		private MainScreenSkillPanel SkillPanel;
		private Button ReincarnationButton;
		private ToolStripMenuItem raceInputToolStripMenuItem;
		private ToolStripMenuItem classInputToolStripMenuItem;
		private ToolStripMenuItem exportTextFileToolStripMenuItem;
		private ToolStripMenuItem importTextFileToolStripMenuItem;
		private Button AlignmentButton;
		private Label AlignmentLabel;
		private Label RaceLabel;
		private Label NameLabel;
		private Label ClassLabel;
		private Button LevelButton1;
		private Button LevelButton16;
		private Button LevelButton2;
		private Button LevelButton3;
		private Button LevelButton4;
		private Button LevelButton5;
		private Button LevelButton6;
		private Button LevelButton7;
		private Button LevelButton8;
		private Button LevelButton9;
		private Button LevelButton10;
		private Button LevelButton11;
		private Button LevelButton12;
		private Button LevelButton13;
		private Button LevelButton14;
		private Button LevelButton15;
		private Button LevelButton17;
		private Button LevelButton18;
		private Button LevelButton19;
		private Button LevelButton20;
		private Button LevelButton21;
		private Button LevelButton22;
		private Button LevelButton23;
		private Button LevelButton24;
		private Button LevelButton25;
		private Button LevelButton26;
		private Button LevelButton27;
		private Button LevelButton28;
		private Button LevelButton29;
		private Button LevelButton30;
		private ToolStripMenuItem characterInputToolStripMenuItem;
		private MainScreenAbilitiesPanel mainScreenAbilitiesPanel1;
		private MainScreenAdditionStatsPanel mainScreenAdditionStatsPanel1;
		private ToolStripMenuItem featInputToolStripMenuItem;
		private ToolStripMenuItem spellInputToolStripMenuItem;
        private ToolStripMenuItem enhancementInputToolStripMenuItem;
		private ToolStripMenuItem skinEditorToolStripMenuItem;
        private Button buttonEditClasses;
        private Label labelRace;
        private Label labelClasses;
        private MainScreenFeatsPanel mainScreenFeatsPanel1;
		private ToolStripMenuItem tomesToolStripMenuItem;
		}
	}