namespace DDOCharacterPlanner.Screens.DataInput
    {
    partial class NewBonusTypeDialogClass
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameBorderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameBorderPanel
            // 
            this.NameBorderPanel.BackColor = System.Drawing.Color.Red;
            this.NameBorderPanel.Controls.Add(this.NameTextBox);
            this.NameBorderPanel.Location = new System.Drawing.Point(12, 40);
            this.NameBorderPanel.Name = "NameBorderPanel";
            this.NameBorderPanel.Size = new System.Drawing.Size(194, 24);
            this.NameBorderPanel.TabIndex = 13;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(2, 2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(189, 20);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // CancelChangesButton
            // 
            this.CancelChangesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelChangesButton.Location = new System.Drawing.Point(112, 72);
            this.CancelChangesButton.Name = "CancelChangesButton";
            this.CancelChangesButton.Size = new System.Drawing.Size(75, 23);
            this.CancelChangesButton.TabIndex = 12;
            this.CancelChangesButton.Text = "Cancel";
            this.CancelChangesButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Enabled = false;
            this.OkButton.Location = new System.Drawing.Point(31, 72);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 11;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.ForeColor = System.Drawing.Color.White;
            this.NameLabel.Location = new System.Drawing.Point(12, 21);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(132, 13);
            this.NameLabel.TabIndex = 10;
            this.NameLabel.Text = "Enter a Bonus Type Name";
            // 
            // NewBonusTypeDialogClass
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.CancelChangesButton;
            this.ClientSize = new System.Drawing.Size(224, 109);
            this.Controls.Add(this.NameBorderPanel);
            this.Controls.Add(this.CancelChangesButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.NameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewBonusTypeDialogClass";
            this.Text = "New Bonus Type";
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
        private System.Windows.Forms.Label NameLabel;
        }
    }