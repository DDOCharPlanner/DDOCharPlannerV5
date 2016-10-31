namespace DDOCharacterPlanner.Screens.DataInput
    {
    partial class RequirementDialogClass
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.ComparisonLabel = new System.Windows.Forms.Label();
            this.comboComparison = new System.Windows.Forms.ComboBox();
            this.numberValue = new System.Windows.Forms.NumericUpDown();
            this.RequirementValueLabel = new System.Windows.Forms.Label();
            this.checkboxRequiresAll = new System.Windows.Forms.CheckBox();
            this.labelSlot = new System.Windows.Forms.Label();
            this.comboSlot = new System.Windows.Forms.ComboBox();
            this.labelTree = new System.Windows.Forms.Label();
            this.comboTree = new System.Windows.Forms.ComboBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelApplyTo = new System.Windows.Forms.Label();
            this.comboApplyTo = new System.Windows.Forms.ComboBox();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numberValue)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(56, 270);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(74, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(160, 270);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(74, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ComparisonLabel
            // 
            this.ComparisonLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComparisonLabel.AutoSize = true;
            this.ComparisonLabel.ForeColor = System.Drawing.Color.White;
            this.ComparisonLabel.Location = new System.Drawing.Point(22, 213);
            this.ComparisonLabel.Name = "ComparisonLabel";
            this.ComparisonLabel.Size = new System.Drawing.Size(62, 13);
            this.ComparisonLabel.TabIndex = 14;
            this.ComparisonLabel.Text = "Comparison";
            // 
            // comboComparison
            // 
            this.comboComparison.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboComparison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboComparison.FormattingEnabled = true;
            this.comboComparison.Items.AddRange(new object[] {
            "=",
            "<",
            "<=",
            ">",
            ">=",
            "!="});
            this.comboComparison.Location = new System.Drawing.Point(22, 229);
            this.comboComparison.Name = "comboComparison";
            this.comboComparison.Size = new System.Drawing.Size(61, 21);
            this.comboComparison.TabIndex = 13;
            this.comboComparison.SelectedIndexChanged += new System.EventHandler(this.comboComparison_SelectedIndexChanged);
            // 
            // numberValue
            // 
            this.numberValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberValue.DecimalPlaces = 3;
            this.numberValue.Location = new System.Drawing.Point(99, 229);
            this.numberValue.Name = "numberValue";
            this.numberValue.Size = new System.Drawing.Size(66, 20);
            this.numberValue.TabIndex = 12;
            this.numberValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numberValue.ValueChanged += new System.EventHandler(this.numberValue_ValueChanged);
            // 
            // RequirementValueLabel
            // 
            this.RequirementValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RequirementValueLabel.AutoSize = true;
            this.RequirementValueLabel.ForeColor = System.Drawing.Color.White;
            this.RequirementValueLabel.Location = new System.Drawing.Point(96, 213);
            this.RequirementValueLabel.Name = "RequirementValueLabel";
            this.RequirementValueLabel.Size = new System.Drawing.Size(70, 13);
            this.RequirementValueLabel.TabIndex = 11;
            this.RequirementValueLabel.Text = "Enter a value";
            // 
            // checkboxRequiresAll
            // 
            this.checkboxRequiresAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkboxRequiresAll.AutoSize = true;
            this.checkboxRequiresAll.ForeColor = System.Drawing.Color.White;
            this.checkboxRequiresAll.Location = new System.Drawing.Point(183, 233);
            this.checkboxRequiresAll.Name = "checkboxRequiresAll";
            this.checkboxRequiresAll.Size = new System.Drawing.Size(82, 17);
            this.checkboxRequiresAll.TabIndex = 10;
            this.checkboxRequiresAll.Text = "Requires All";
            this.checkboxRequiresAll.UseVisualStyleBackColor = true;
            this.checkboxRequiresAll.CheckedChanged += new System.EventHandler(this.checkboxRequirersAll_CheckedChanged);
            // 
            // labelSlot
            // 
            this.labelSlot.AutoSize = true;
            this.labelSlot.ForeColor = System.Drawing.Color.White;
            this.labelSlot.Location = new System.Drawing.Point(25, 113);
            this.labelSlot.Name = "labelSlot";
            this.labelSlot.Size = new System.Drawing.Size(142, 13);
            this.labelSlot.TabIndex = 29;
            this.labelSlot.Text = "Select an Enhancement Slot";
            // 
            // comboSlot
            // 
            this.comboSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSlot.FormattingEnabled = true;
            this.comboSlot.Location = new System.Drawing.Point(25, 132);
            this.comboSlot.Name = "comboSlot";
            this.comboSlot.Size = new System.Drawing.Size(191, 21);
            this.comboSlot.Sorted = true;
            this.comboSlot.TabIndex = 28;
            this.comboSlot.SelectedIndexChanged += new System.EventHandler(this.comboSlot_SelectedIndexChanged);
            // 
            // labelTree
            // 
            this.labelTree.AutoSize = true;
            this.labelTree.ForeColor = System.Drawing.Color.White;
            this.labelTree.Location = new System.Drawing.Point(25, 62);
            this.labelTree.Name = "labelTree";
            this.labelTree.Size = new System.Drawing.Size(146, 13);
            this.labelTree.TabIndex = 27;
            this.labelTree.Text = "Select an Enhancement Tree";
            // 
            // comboTree
            // 
            this.comboTree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTree.FormattingEnabled = true;
            this.comboTree.Location = new System.Drawing.Point(25, 81);
            this.comboTree.Name = "comboTree";
            this.comboTree.Size = new System.Drawing.Size(191, 21);
            this.comboTree.Sorted = true;
            this.comboTree.TabIndex = 26;
            this.comboTree.SelectedIndexChanged += new System.EventHandler(this.comboTree_SelectedIndexChanged);
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.ForeColor = System.Drawing.Color.White;
            this.labelCategory.Location = new System.Drawing.Point(25, 13);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(91, 13);
            this.labelCategory.TabIndex = 25;
            this.labelCategory.Text = "Select a Category";
            // 
            // labelApplyTo
            // 
            this.labelApplyTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelApplyTo.AutoSize = true;
            this.labelApplyTo.ForeColor = System.Drawing.Color.White;
            this.labelApplyTo.Location = new System.Drawing.Point(22, 160);
            this.labelApplyTo.Name = "labelApplyTo";
            this.labelApplyTo.Size = new System.Drawing.Size(49, 13);
            this.labelApplyTo.TabIndex = 24;
            this.labelApplyTo.Text = "Apply To";
            // 
            // comboApplyTo
            // 
            this.comboApplyTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboApplyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboApplyTo.FormattingEnabled = true;
            this.comboApplyTo.Location = new System.Drawing.Point(22, 179);
            this.comboApplyTo.Name = "comboApplyTo";
            this.comboApplyTo.Size = new System.Drawing.Size(191, 21);
            this.comboApplyTo.Sorted = true;
            this.comboApplyTo.TabIndex = 23;
            this.comboApplyTo.SelectedIndexChanged += new System.EventHandler(this.comboAppyTo_SelectedIndexChanged);
            // 
            // comboCategory
            // 
            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(25, 32);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(121, 21);
            this.comboCategory.Sorted = true;
            this.comboCategory.TabIndex = 22;
            this.comboCategory.SelectedIndexChanged += new System.EventHandler(this.comboCategory_SelectedIndexChanged);
            // 
            // RequirementDialogClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(283, 305);
            this.Controls.Add(this.labelSlot);
            this.Controls.Add(this.comboSlot);
            this.Controls.Add(this.labelTree);
            this.Controls.Add(this.comboTree);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelApplyTo);
            this.Controls.Add(this.comboApplyTo);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.ComparisonLabel);
            this.Controls.Add(this.comboComparison);
            this.Controls.Add(this.numberValue);
            this.Controls.Add(this.RequirementValueLabel);
            this.Controls.Add(this.checkboxRequiresAll);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RequirementDialogClass";
            this.Text = "RequirementDialogClass";
            this.Load += new System.EventHandler(this.RequirementDialogClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numberValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label ComparisonLabel;
        private System.Windows.Forms.ComboBox comboComparison;
        private System.Windows.Forms.NumericUpDown numberValue;
        private System.Windows.Forms.Label RequirementValueLabel;
        private System.Windows.Forms.CheckBox checkboxRequiresAll;
        private System.Windows.Forms.Label labelSlot;
        private System.Windows.Forms.ComboBox comboSlot;
        private System.Windows.Forms.Label labelTree;
        private System.Windows.Forms.ComboBox comboTree;
        private System.Windows.Forms.Label labelApplyTo;
        private System.Windows.Forms.ComboBox comboApplyTo;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.Label labelCategory;
        }
    }