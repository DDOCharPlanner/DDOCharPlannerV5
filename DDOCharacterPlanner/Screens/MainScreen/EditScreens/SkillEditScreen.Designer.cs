namespace DDOCharacterPlanner.Screens.MainScreen
{
    partial class SkillEditScreen
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
            this.SkillPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SkillSubPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SkillHeader = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.SkillPanelLabel = new System.Windows.Forms.Label();
            this.levelSelected = new System.Windows.Forms.NumericUpDown();
            this.AutoSetPanel = new System.Windows.Forms.Panel();
            this.useclass = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.AutoSetHeader = new System.Windows.Forms.Panel();
            this.update = new System.Windows.Forms.Button();
            this.AutoSetLabel = new System.Windows.Forms.Label();
            this.SkillPanel.SuspendLayout();
            this.SkillHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelSelected)).BeginInit();
            this.AutoSetPanel.SuspendLayout();
            this.AutoSetHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // SkillPanel
            // 
            this.SkillPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SkillPanel.Controls.Add(this.label1);
            this.SkillPanel.Controls.Add(this.button1);
            this.SkillPanel.Controls.Add(this.label4);
            this.SkillPanel.Controls.Add(this.SkillSubPanel);
            this.SkillPanel.Controls.Add(this.label8);
            this.SkillPanel.Controls.Add(this.Label5);
            this.SkillPanel.Controls.Add(this.label7);
            this.SkillPanel.Controls.Add(this.label2);
            this.SkillPanel.Controls.Add(this.Label6);
            this.SkillPanel.Controls.Add(this.label3);
            this.SkillPanel.Controls.Add(this.SkillHeader);
            this.SkillPanel.Controls.Add(this.levelSelected);
            this.SkillPanel.Location = new System.Drawing.Point(12, 12);
            this.SkillPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SkillPanel.Name = "SkillPanel";
            this.SkillPanel.Size = new System.Drawing.Size(750, 715);
            this.SkillPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(577, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 35);
            this.label1.TabIndex = 42;
            this.label1.Text = "Ability";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(658, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Add Tome";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LoadTomePane);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(539, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 35);
            this.label4.TabIndex = 40;
            this.label4.Text = "Rank";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // SkillSubPanel
            // 
            this.SkillSubPanel.AutoScroll = true;
            this.SkillSubPanel.Location = new System.Drawing.Point(112, 29);
            this.SkillSubPanel.Name = "SkillSubPanel";
            this.SkillSubPanel.Size = new System.Drawing.Size(421, 686);
            this.SkillSubPanel.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(577, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 15);
            this.label8.TabIndex = 37;
            this.label8.Text = "Level";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(620, 71);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(41, 16);
            this.Label5.TabIndex = 39;
            this.Label5.Text = "Tomes";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(706, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 35);
            this.label7.TabIndex = 38;
            this.label7.Text = "Total";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Skill";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Label6.Location = new System.Drawing.Point(663, 52);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(41, 34);
            this.Label6.TabIndex = 37;
            this.Label6.Text = "Feat";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Remaining Points";
            // 
            // SkillHeader
            // 
            this.SkillHeader.Controls.Add(this.button2);
            this.SkillHeader.Controls.Add(this.SkillPanelLabel);
            this.SkillHeader.Location = new System.Drawing.Point(0, 0);
            this.SkillHeader.Name = "SkillHeader";
            this.SkillHeader.Size = new System.Drawing.Size(750, 25);
            this.SkillHeader.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(644, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 25);
            this.button2.TabIndex = 31;
            this.button2.Text = "Reset Skills";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ResetSkills);
            // 
            // SkillPanelLabel
            // 
            this.SkillPanelLabel.AutoSize = true;
            this.SkillPanelLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkillPanelLabel.Location = new System.Drawing.Point(5, 5);
            this.SkillPanelLabel.Name = "SkillPanelLabel";
            this.SkillPanelLabel.Size = new System.Drawing.Size(72, 15);
            this.SkillPanelLabel.TabIndex = 10;
            this.SkillPanelLabel.Text = "Skills Panel";
            // 
            // levelSelected
            // 
            this.levelSelected.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.levelSelected.Location = new System.Drawing.Point(618, 35);
            this.levelSelected.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.levelSelected.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.levelSelected.Name = "levelSelected";
            this.levelSelected.Size = new System.Drawing.Size(34, 20);
            this.levelSelected.TabIndex = 18;
            this.levelSelected.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.levelSelected.ValueChanged += new System.EventHandler(this.selectedLevelChanged);
            // 
            // AutoSetPanel
            // 
            this.AutoSetPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AutoSetPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutoSetPanel.Controls.Add(this.useclass);
            this.AutoSetPanel.Controls.Add(this.label11);
            this.AutoSetPanel.Controls.Add(this.label10);
            this.AutoSetPanel.Controls.Add(this.label9);
            this.AutoSetPanel.Location = new System.Drawing.Point(768, 12);
            this.AutoSetPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AutoSetPanel.Name = "AutoSetPanel";
            this.AutoSetPanel.Size = new System.Drawing.Size(228, 715);
            this.AutoSetPanel.TabIndex = 1;
            // 
            // useclass
            // 
            this.useclass.AutoSize = true;
            this.useclass.Checked = true;
            this.useclass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useclass.Location = new System.Drawing.Point(18, 31);
            this.useclass.Name = "useclass";
            this.useclass.Size = new System.Drawing.Size(122, 17);
            this.useclass.TabIndex = 30;
            this.useclass.Text = "Use Class Skills First";
            this.useclass.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(168, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "MaxValue";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(119, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "Priority";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 15);
            this.label9.TabIndex = 29;
            this.label9.Text = "Skill";
            // 
            // AutoSetHeader
            // 
            this.AutoSetHeader.Controls.Add(this.update);
            this.AutoSetHeader.Controls.Add(this.AutoSetLabel);
            this.AutoSetHeader.Location = new System.Drawing.Point(768, 12);
            this.AutoSetHeader.Name = "AutoSetHeader";
            this.AutoSetHeader.Size = new System.Drawing.Size(228, 25);
            this.AutoSetHeader.TabIndex = 0;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(122, 0);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(103, 25);
            this.update.TabIndex = 30;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.AutoSetRanks);
            // 
            // AutoSetLabel
            // 
            this.AutoSetLabel.AutoSize = true;
            this.AutoSetLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoSetLabel.Location = new System.Drawing.Point(3, 5);
            this.AutoSetLabel.Name = "AutoSetLabel";
            this.AutoSetLabel.Size = new System.Drawing.Size(53, 15);
            this.AutoSetLabel.TabIndex = 11;
            this.AutoSetLabel.Text = "Auto Set";
            // 
            // SkillEditScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.AutoSetHeader);
            this.Controls.Add(this.AutoSetPanel);
            this.Controls.Add(this.SkillPanel);
            this.Name = "SkillEditScreen";
            this.Text = "SkillEditScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.SkillPanel.ResumeLayout(false);
            this.SkillPanel.PerformLayout();
            this.SkillHeader.ResumeLayout(false);
            this.SkillHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelSelected)).EndInit();
            this.AutoSetPanel.ResumeLayout(false);
            this.AutoSetPanel.PerformLayout();
            this.AutoSetHeader.ResumeLayout(false);
            this.AutoSetHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SkillPanel;
        private System.Windows.Forms.Panel AutoSetPanel;
        private System.Windows.Forms.Panel SkillHeader;
        private System.Windows.Forms.Panel AutoSetHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel SkillSubPanel;
        private System.Windows.Forms.NumericUpDown levelSelected;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SkillPanelLabel;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Label AutoSetLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.CheckBox useclass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}