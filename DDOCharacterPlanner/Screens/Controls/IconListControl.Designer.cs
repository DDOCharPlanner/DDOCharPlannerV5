namespace DDOCharacterPlanner.Screens.Controls
    {
    partial class IconListControl
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
            this.panelIconControlList = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelIconControlList
            // 
            this.panelIconControlList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelIconControlList.AutoScroll = true;
            this.panelIconControlList.Location = new System.Drawing.Point(3, 3);
            this.panelIconControlList.Name = "panelIconControlList";
            this.panelIconControlList.Size = new System.Drawing.Size(223, 74);
            this.panelIconControlList.TabIndex = 0;
            // 
            // IconListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelIconControlList);
            this.Name = "IconListControl";
            this.Size = new System.Drawing.Size(231, 80);
            this.ResumeLayout(false);

            }

        #endregion

        private System.Windows.Forms.Panel panelIconControlList;
        }
    }
