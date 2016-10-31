namespace DDOCharacterPlanner.Screens.MainScreen
    {
    partial class MainScreenFeatsPanel
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
            this.labelFeatsPanelHeader = new System.Windows.Forms.Label();
            this.buttonEditFeats = new System.Windows.Forms.Button();
            this.buttonAllFeats = new System.Windows.Forms.Button();
            this.buttonGrantedFeats = new System.Windows.Forms.Button();
            this.buttonSelectedFeats = new System.Windows.Forms.Button();
            this.treeViewFeats = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // labelFeatsPanelHeader
            // 
            this.labelFeatsPanelHeader.BackColor = System.Drawing.Color.SkyBlue;
            this.labelFeatsPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelFeatsPanelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeatsPanelHeader.ForeColor = System.Drawing.Color.White;
            this.labelFeatsPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelFeatsPanelHeader.Name = "labelFeatsPanelHeader";
            this.labelFeatsPanelHeader.Size = new System.Drawing.Size(287, 22);
            this.labelFeatsPanelHeader.TabIndex = 0;
            this.labelFeatsPanelHeader.Text = "Known Feats";
            // 
            // buttonEditFeats
            // 
            this.buttonEditFeats.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonEditFeats.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEditFeats.ForeColor = System.Drawing.Color.White;
            this.buttonEditFeats.Location = new System.Drawing.Point(209, 1);
            this.buttonEditFeats.Name = "buttonEditFeats";
            this.buttonEditFeats.Size = new System.Drawing.Size(75, 20);
            this.buttonEditFeats.TabIndex = 3;
            this.buttonEditFeats.Text = "Edit";
            this.buttonEditFeats.UseVisualStyleBackColor = false;
            this.buttonEditFeats.Click += new System.EventHandler(this.buttonEditFeats_Click);
            // 
            // buttonAllFeats
            // 
            this.buttonAllFeats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAllFeats.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAllFeats.Location = new System.Drawing.Point(5, 263);
            this.buttonAllFeats.Name = "buttonAllFeats";
            this.buttonAllFeats.Size = new System.Drawing.Size(75, 23);
            this.buttonAllFeats.TabIndex = 4;
            this.buttonAllFeats.Text = "All Known";
            this.buttonAllFeats.UseVisualStyleBackColor = true;
            this.buttonAllFeats.Click += new System.EventHandler(this.buttonAllFeats_Click);
            // 
            // buttonGrantedFeats
            // 
            this.buttonGrantedFeats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGrantedFeats.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGrantedFeats.Location = new System.Drawing.Point(104, 263);
            this.buttonGrantedFeats.Name = "buttonGrantedFeats";
            this.buttonGrantedFeats.Size = new System.Drawing.Size(75, 23);
            this.buttonGrantedFeats.TabIndex = 5;
            this.buttonGrantedFeats.Text = "Granted";
            this.buttonGrantedFeats.UseVisualStyleBackColor = true;
            this.buttonGrantedFeats.Click += new System.EventHandler(this.buttonGrantedFeats_Click);
            // 
            // buttonSelectedFeats
            // 
            this.buttonSelectedFeats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSelectedFeats.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSelectedFeats.Location = new System.Drawing.Point(205, 263);
            this.buttonSelectedFeats.Name = "buttonSelectedFeats";
            this.buttonSelectedFeats.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectedFeats.TabIndex = 6;
            this.buttonSelectedFeats.Text = "Selected";
            this.buttonSelectedFeats.UseVisualStyleBackColor = true;
            this.buttonSelectedFeats.Click += new System.EventHandler(this.buttonSelectedFeats_Click);
            // 
            // treeViewFeats
            // 
            this.treeViewFeats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewFeats.BackColor = System.Drawing.Color.Black;
            this.treeViewFeats.ForeColor = System.Drawing.Color.White;
            this.treeViewFeats.Indent = 15;
            this.treeViewFeats.ItemHeight = 30;
            this.treeViewFeats.Location = new System.Drawing.Point(3, 27);
            this.treeViewFeats.Name = "treeViewFeats";
            this.treeViewFeats.ShowLines = false;
            this.treeViewFeats.Size = new System.Drawing.Size(281, 232);
            this.treeViewFeats.TabIndex = 7;
            // 
            // MainScreenFeatsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.treeViewFeats);
            this.Controls.Add(this.buttonSelectedFeats);
            this.Controls.Add(this.buttonGrantedFeats);
            this.Controls.Add(this.buttonAllFeats);
            this.Controls.Add(this.buttonEditFeats);
            this.Controls.Add(this.labelFeatsPanelHeader);
            this.Name = "MainScreenFeatsPanel";
            this.Size = new System.Drawing.Size(287, 291);
            this.ResumeLayout(false);

            }

        #endregion

        private System.Windows.Forms.Label labelFeatsPanelHeader;
        private System.Windows.Forms.Button buttonEditFeats;
        private System.Windows.Forms.Button buttonAllFeats;
        private System.Windows.Forms.Button buttonGrantedFeats;
        private System.Windows.Forms.Button buttonSelectedFeats;
        private System.Windows.Forms.TreeView treeViewFeats;
        }
    }
