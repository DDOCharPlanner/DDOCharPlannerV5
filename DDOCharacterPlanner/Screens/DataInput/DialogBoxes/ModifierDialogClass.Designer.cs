namespace DDOCharacterPlanner.Screens.DataInput
    {
    partial class ModifierDialogClass
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
            this.labelBonusType = new System.Windows.Forms.Label();
            this.comboBonusType = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelModifierMethod = new System.Windows.Forms.Label();
            this.comboModifierMethod = new System.Windows.Forms.ComboBox();
            this.labelStance = new System.Windows.Forms.Label();
            this.comboStance = new System.Windows.Forms.ComboBox();
            this.labelPullFrom = new System.Windows.Forms.Label();
            this.comboPullFrom = new System.Windows.Forms.ComboBox();
            this.labelModifierValue = new System.Windows.Forms.Label();
            this.numModifierValue = new System.Windows.Forms.NumericUpDown();
            this.labelCategory = new System.Windows.Forms.Label();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.labelRequirement = new System.Windows.Forms.Label();
            this.labelModifierType = new System.Windows.Forms.Label();
            this.ModifierTypePanel = new System.Windows.Forms.Panel();
            this.radioStance = new System.Windows.Forms.RadioButton();
            this.radioPassive = new System.Windows.Forms.RadioButton();
            this.labelModifier = new System.Windows.Forms.Label();
            this.comboModifier = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numModifierValue)).BeginInit();
            this.ModifierTypePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelBonusType
            // 
            this.labelBonusType.AutoSize = true;
            this.labelBonusType.ForeColor = System.Drawing.Color.White;
            this.labelBonusType.Location = new System.Drawing.Point(44, 114);
            this.labelBonusType.Name = "labelBonusType";
            this.labelBonusType.Size = new System.Drawing.Size(106, 13);
            this.labelBonusType.TabIndex = 41;
            this.labelBonusType.Text = "Select a Bonus Type";
            // 
            // comboBonusType
            // 
            this.comboBonusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBonusType.FormattingEnabled = true;
            this.comboBonusType.Location = new System.Drawing.Point(44, 132);
            this.comboBonusType.Name = "comboBonusType";
            this.comboBonusType.Size = new System.Drawing.Size(196, 21);
            this.comboBonusType.TabIndex = 40;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(267, 287);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 39;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(143, 287);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 38;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // labelModifierMethod
            // 
            this.labelModifierMethod.AutoSize = true;
            this.labelModifierMethod.ForeColor = System.Drawing.Color.White;
            this.labelModifierMethod.Location = new System.Drawing.Point(264, 19);
            this.labelModifierMethod.Name = "labelModifierMethod";
            this.labelModifierMethod.Size = new System.Drawing.Size(123, 13);
            this.labelModifierMethod.TabIndex = 37;
            this.labelModifierMethod.Text = "Select a Modifer Method";
            // 
            // comboModifierMethod
            // 
            this.comboModifierMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboModifierMethod.FormattingEnabled = true;
            this.comboModifierMethod.Location = new System.Drawing.Point(393, 13);
            this.comboModifierMethod.Name = "comboModifierMethod";
            this.comboModifierMethod.Size = new System.Drawing.Size(123, 21);
            this.comboModifierMethod.TabIndex = 36;
            // 
            // labelStance
            // 
            this.labelStance.AutoSize = true;
            this.labelStance.ForeColor = System.Drawing.Color.White;
            this.labelStance.Location = new System.Drawing.Point(286, 105);
            this.labelStance.Name = "labelStance";
            this.labelStance.Size = new System.Drawing.Size(83, 13);
            this.labelStance.TabIndex = 35;
            this.labelStance.Text = "Select a Stance";
            // 
            // comboStance
            // 
            this.comboStance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStance.FormattingEnabled = true;
            this.comboStance.Location = new System.Drawing.Point(286, 123);
            this.comboStance.Name = "comboStance";
            this.comboStance.Size = new System.Drawing.Size(196, 21);
            this.comboStance.TabIndex = 34;
            this.comboStance.Visible = false;
            // 
            // labelPullFrom
            // 
            this.labelPullFrom.AutoSize = true;
            this.labelPullFrom.ForeColor = System.Drawing.Color.White;
            this.labelPullFrom.Location = new System.Drawing.Point(44, 163);
            this.labelPullFrom.Name = "labelPullFrom";
            this.labelPullFrom.Size = new System.Drawing.Size(82, 13);
            this.labelPullFrom.TabIndex = 33;
            this.labelPullFrom.Text = "Use Value From";
            // 
            // comboPullFrom
            // 
            this.comboPullFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPullFrom.FormattingEnabled = true;
            this.comboPullFrom.Location = new System.Drawing.Point(44, 181);
            this.comboPullFrom.Name = "comboPullFrom";
            this.comboPullFrom.Size = new System.Drawing.Size(196, 21);
            this.comboPullFrom.TabIndex = 32;
            this.comboPullFrom.Visible = false;
            // 
            // labelModifierValue
            // 
            this.labelModifierValue.AutoSize = true;
            this.labelModifierValue.ForeColor = System.Drawing.Color.White;
            this.labelModifierValue.Location = new System.Drawing.Point(41, 219);
            this.labelModifierValue.Name = "labelModifierValue";
            this.labelModifierValue.Size = new System.Drawing.Size(74, 13);
            this.labelModifierValue.TabIndex = 30;
            this.labelModifierValue.Text = "Modifier Value";
            // 
            // numModifierValue
            // 
            this.numModifierValue.DecimalPlaces = 3;
            this.numModifierValue.Location = new System.Drawing.Point(44, 238);
            this.numModifierValue.Name = "numModifierValue";
            this.numModifierValue.Size = new System.Drawing.Size(70, 20);
            this.numModifierValue.TabIndex = 29;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.ForeColor = System.Drawing.Color.White;
            this.labelCategory.Location = new System.Drawing.Point(22, 53);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(82, 13);
            this.labelCategory.TabIndex = 27;
            this.labelCategory.Text = "Select Category";
            // 
            // comboCategory
            // 
            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(22, 71);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(196, 21);
            this.comboCategory.TabIndex = 26;
            this.comboCategory.SelectedIndexChanged += new System.EventHandler(this.comboCategory_SelectedIndexChanged);
            // 
            // labelRequirement
            // 
            this.labelRequirement.AutoSize = true;
            this.labelRequirement.ForeColor = System.Drawing.Color.White;
            this.labelRequirement.Location = new System.Drawing.Point(407, 264);
            this.labelRequirement.Name = "labelRequirement";
            this.labelRequirement.Size = new System.Drawing.Size(109, 13);
            this.labelRequirement.TabIndex = 25;
            this.labelRequirement.Text = "Select a Requirement";
            // 
            // labelModifierType
            // 
            this.labelModifierType.AutoSize = true;
            this.labelModifierType.ForeColor = System.Drawing.Color.White;
            this.labelModifierType.Location = new System.Drawing.Point(19, 17);
            this.labelModifierType.Name = "labelModifierType";
            this.labelModifierType.Size = new System.Drawing.Size(73, 13);
            this.labelModifierType.TabIndex = 23;
            this.labelModifierType.Text = "Select a Type";
            // 
            // ModifierTypePanel
            // 
            this.ModifierTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModifierTypePanel.Controls.Add(this.radioStance);
            this.ModifierTypePanel.Controls.Add(this.radioPassive);
            this.ModifierTypePanel.Location = new System.Drawing.Point(101, 10);
            this.ModifierTypePanel.Name = "ModifierTypePanel";
            this.ModifierTypePanel.Size = new System.Drawing.Size(148, 27);
            this.ModifierTypePanel.TabIndex = 22;
            // 
            // radioStance
            // 
            this.radioStance.AutoSize = true;
            this.radioStance.ForeColor = System.Drawing.Color.White;
            this.radioStance.Location = new System.Drawing.Point(79, 4);
            this.radioStance.Name = "radioStance";
            this.radioStance.Size = new System.Drawing.Size(59, 17);
            this.radioStance.TabIndex = 1;
            this.radioStance.TabStop = true;
            this.radioStance.Text = "Stance";
            this.radioStance.UseVisualStyleBackColor = true;
            // 
            // radioPassive
            // 
            this.radioPassive.AutoSize = true;
            this.radioPassive.ForeColor = System.Drawing.Color.White;
            this.radioPassive.Location = new System.Drawing.Point(3, 4);
            this.radioPassive.Name = "radioPassive";
            this.radioPassive.Size = new System.Drawing.Size(62, 17);
            this.radioPassive.TabIndex = 0;
            this.radioPassive.TabStop = true;
            this.radioPassive.Text = "Passive";
            this.radioPassive.UseVisualStyleBackColor = true;
            this.radioPassive.CheckedChanged += new System.EventHandler(this.radioPassive_CheckedChanged);
            // 
            // labelModifier
            // 
            this.labelModifier.AutoSize = true;
            this.labelModifier.ForeColor = System.Drawing.Color.White;
            this.labelModifier.Location = new System.Drawing.Point(240, 53);
            this.labelModifier.Name = "labelModifier";
            this.labelModifier.Size = new System.Drawing.Size(77, 13);
            this.labelModifier.TabIndex = 43;
            this.labelModifier.Text = "Select Modifier";
            // 
            // comboModifier
            // 
            this.comboModifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboModifier.FormattingEnabled = true;
            this.comboModifier.Location = new System.Drawing.Point(240, 71);
            this.comboModifier.Name = "comboModifier";
            this.comboModifier.Size = new System.Drawing.Size(196, 21);
            this.comboModifier.TabIndex = 42;
            // 
            // ModifierDialogClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(535, 320);
            this.Controls.Add(this.labelModifier);
            this.Controls.Add(this.comboModifier);
            this.Controls.Add(this.labelBonusType);
            this.Controls.Add(this.comboBonusType);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelModifierMethod);
            this.Controls.Add(this.comboModifierMethod);
            this.Controls.Add(this.labelStance);
            this.Controls.Add(this.comboStance);
            this.Controls.Add(this.labelPullFrom);
            this.Controls.Add(this.comboPullFrom);
            this.Controls.Add(this.labelModifierValue);
            this.Controls.Add(this.numModifierValue);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.labelRequirement);
            this.Controls.Add(this.labelModifierType);
            this.Controls.Add(this.ModifierTypePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ModifierDialogClass";
            this.Text = "Modifiers";
            this.Load += new System.EventHandler(this.ModifierDialogClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numModifierValue)).EndInit();
            this.ModifierTypePanel.ResumeLayout(false);
            this.ModifierTypePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.Label labelBonusType;
        private System.Windows.Forms.ComboBox comboBonusType;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelModifierMethod;
        private System.Windows.Forms.ComboBox comboModifierMethod;
        private System.Windows.Forms.Label labelStance;
        private System.Windows.Forms.ComboBox comboStance;
        private System.Windows.Forms.Label labelPullFrom;
        private System.Windows.Forms.ComboBox comboPullFrom;
        private System.Windows.Forms.Label labelModifierValue;
        private System.Windows.Forms.NumericUpDown numModifierValue;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.Label labelRequirement;
        private System.Windows.Forms.Label labelModifierType;
        private System.Windows.Forms.Panel ModifierTypePanel;
        private System.Windows.Forms.RadioButton radioStance;
        private System.Windows.Forms.RadioButton radioPassive;
        private System.Windows.Forms.Label labelModifier;
        private System.Windows.Forms.ComboBox comboModifier;
        }
    }