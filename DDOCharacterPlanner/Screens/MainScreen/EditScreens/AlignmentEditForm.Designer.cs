namespace DDOCharacterPlanner.Screens.MainScreen
{
    partial class AlignmentEditForm
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
            this.AlignmentPanel = new System.Windows.Forms.Panel();
            this.Header = new System.Windows.Forms.Panel();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.AlignmentPanel.SuspendLayout();
            this.Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // AlignmentPanel
            // 
            this.AlignmentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlignmentPanel.Controls.Add(this.Header);
            this.AlignmentPanel.Location = new System.Drawing.Point(13, 13);
            this.AlignmentPanel.Name = "AlignmentPanel";
            this.AlignmentPanel.Size = new System.Drawing.Size(271, 220);
            this.AlignmentPanel.TabIndex = 0;
            // 
            // Header
            // 
            this.Header.Controls.Add(this.HeaderLabel);
            this.Header.Location = new System.Drawing.Point(-1, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(271, 25);
            this.Header.TabIndex = 0;
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Location = new System.Drawing.Point(5, 4);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(53, 13);
            this.HeaderLabel.TabIndex = 0;
            this.HeaderLabel.Text = "Alignment";
            // 
            // AlignmentEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 245);
            this.Controls.Add(this.AlignmentPanel);
            this.Name = "AlignmentEditForm";
            this.Text = "AlignmentEditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlignmentEditForm_FormClosing);
            this.AlignmentPanel.ResumeLayout(false);
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AlignmentPanel;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Label HeaderLabel;
    }
}