namespace DDOCharacterPlanner.Screens.DataInput
    {
    partial class AutoGrantedFeatsPanel
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
            this.LevelButton = new System.Windows.Forms.Button();
            this.FeatNameButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.AutoGrantedFeatsSubPanel = new System.Windows.Forms.Panel();
            this.AddNewButton = new System.Windows.Forms.Button();
            this.AddLevelComboBox = new System.Windows.Forms.ComboBox();
            this.AddFeatNameComboBox = new System.Windows.Forms.ComboBox();
            this.AddIgnorPreReqsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LevelButton
            // 
            this.LevelButton.Location = new System.Drawing.Point(3, 3);
            this.LevelButton.Name = "LevelButton";
            this.LevelButton.Size = new System.Drawing.Size(43, 23);
            this.LevelButton.TabIndex = 0;
            this.LevelButton.Text = "Level";
            this.LevelButton.UseVisualStyleBackColor = true;
            // 
            // FeatNameButton
            // 
            this.FeatNameButton.Location = new System.Drawing.Point(44, 3);
            this.FeatNameButton.Name = "FeatNameButton";
            this.FeatNameButton.Size = new System.Drawing.Size(210, 23);
            this.FeatNameButton.TabIndex = 1;
            this.FeatNameButton.Text = "Feat Name";
            this.FeatNameButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(250, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(41, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Reqs";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // AutoGrantedFeatsSubPanel
            // 
            this.AutoGrantedFeatsSubPanel.AutoScroll = true;
            this.AutoGrantedFeatsSubPanel.BackColor = System.Drawing.Color.DimGray;
            this.AutoGrantedFeatsSubPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutoGrantedFeatsSubPanel.Location = new System.Drawing.Point(3, 32);
            this.AutoGrantedFeatsSubPanel.Name = "AutoGrantedFeatsSubPanel";
            this.AutoGrantedFeatsSubPanel.Size = new System.Drawing.Size(329, 181);
            this.AutoGrantedFeatsSubPanel.TabIndex = 4;
            // 
            // AddNewButton
            // 
            this.AddNewButton.Enabled = false;
            this.AddNewButton.Location = new System.Drawing.Point(287, 219);
            this.AddNewButton.Name = "AddNewButton";
            this.AddNewButton.Size = new System.Drawing.Size(45, 23);
            this.AddNewButton.TabIndex = 5;
            this.AddNewButton.Text = "Add";
            this.AddNewButton.UseVisualStyleBackColor = true;
            this.AddNewButton.Click += new System.EventHandler(this.onAddNewButtonClick);
            // 
            // AddLevelComboBox
            // 
            this.AddLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AddLevelComboBox.FormattingEnabled = true;
            this.AddLevelComboBox.Location = new System.Drawing.Point(3, 219);
            this.AddLevelComboBox.Name = "AddLevelComboBox";
            this.AddLevelComboBox.Size = new System.Drawing.Size(43, 21);
            this.AddLevelComboBox.TabIndex = 6;
            this.AddLevelComboBox.SelectionChangeCommitted += new System.EventHandler(this.onAddLevelComboBoxSelectedChangeCommitted);
            // 
            // AddFeatNameComboBox
            // 
            this.AddFeatNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AddFeatNameComboBox.FormattingEnabled = true;
            this.AddFeatNameComboBox.Location = new System.Drawing.Point(49, 219);
            this.AddFeatNameComboBox.Name = "AddFeatNameComboBox";
            this.AddFeatNameComboBox.Size = new System.Drawing.Size(195, 21);
            this.AddFeatNameComboBox.TabIndex = 7;
            this.AddFeatNameComboBox.SelectionChangeCommitted += new System.EventHandler(this.onAddFeatLevelComboBoxSelectedChangeCommitted);
            // 
            // AddIgnorPreReqsCheckBox
            // 
            this.AddIgnorPreReqsCheckBox.AutoSize = true;
            this.AddIgnorPreReqsCheckBox.Location = new System.Drawing.Point(259, 224);
            this.AddIgnorPreReqsCheckBox.Name = "AddIgnorPreReqsCheckBox";
            this.AddIgnorPreReqsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.AddIgnorPreReqsCheckBox.TabIndex = 8;
            this.AddIgnorPreReqsCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoGrantedFeatsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.AddIgnorPreReqsCheckBox);
            this.Controls.Add(this.AddFeatNameComboBox);
            this.Controls.Add(this.AddLevelComboBox);
            this.Controls.Add(this.AddNewButton);
            this.Controls.Add(this.AutoGrantedFeatsSubPanel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.FeatNameButton);
            this.Controls.Add(this.LevelButton);
            this.Name = "AutoGrantedFeatsPanel";
            this.Size = new System.Drawing.Size(340, 246);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.Button LevelButton;
        private System.Windows.Forms.Button FeatNameButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel AutoGrantedFeatsSubPanel;
        private System.Windows.Forms.Button AddNewButton;
        private System.Windows.Forms.ComboBox AddLevelComboBox;
        private System.Windows.Forms.ComboBox AddFeatNameComboBox;
        private System.Windows.Forms.CheckBox AddIgnorPreReqsCheckBox;
        }
    }
