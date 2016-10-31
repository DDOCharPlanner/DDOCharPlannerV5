using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DDOCharacterPlanner.Model;

namespace DDOCharacterPlanner.Screens.DataInput
    {
    public partial class NewModifierDialogClass : Form
        {
        #region Private Variables
        private List<string> CategoryNames;
        private List<string> ApplyToNames;
        private Guid NewModifierId;

        #endregion

        #region Properties
        public Guid ModifierId { get { return NewModifierId; } }

        #endregion

        #region Constructor
        public NewModifierDialogClass()
            {
            InitializeComponent();
            CategoryNames = new List<string>();
            ApplyToNames = new List<string>();
            NewModifierId = Guid.Empty;

            FillCategoryComboBox();
            OkButton.Enabled = false;

            }

        #endregion

        #region Control Events
        private void ApplyToComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (e.ToString() != "")
                UpdateNameField();
            }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            string category;

            category = CategoryComboBox.SelectedItem.ToString();

            ApplyToNames.Clear();
            if (category == "Ability")
                {
                ApplyToLabel.Text = "Select an Ability";
                ApplyToNames = AbilityModel.GetNames();
                }
            else if (category == "Attribute")
                {
                ApplyToLabel.Text = "Select an Attribute";
                ApplyToNames = AttributeModel.GetNames();
                }
            else if (category == "Feat")
                {
                ApplyToLabel.Text = "Select a Feat";
                ApplyToNames = FeatModel.GetNames();
                }
            else if (category == "Save")
                {
                ApplyToLabel.Text = "Select a Save";
                ApplyToNames = SaveModel.GetNames();
                }
            else if (category == "Skill")
                {
                ApplyToLabel.Text = "Select a Skill";
                ApplyToNames = SkillModel.GetNames();
                }
            else if (category == "Spell")
                {
                ApplyToLabel.Text = "Select a spell";
                ApplyToNames = SpellModel.GetNames();
                }
            else
                {
                Debug.WriteLine("Error: No category exists for the one selected. NewModifierDialogClass : CategoryComboBox_SelectedIndexChanged()");
                return;
                }
            FillApplyToComboBox();
            UpdateNameField();

            }

        private void NameTextBoxChanged(object sender, EventArgs e)
            {
            if (ApplyToComboBox.SelectedIndex == -1)
                {
                NameBorderPanel.BackColor = Color.Red;
                OkButton.Enabled = false;
                return;
                }

            if (ModifierModel.GetIdFromName(NameTextBox.Text.ToString()) == Guid.Empty)
                {
                NameBorderPanel.BackColor = Color.Green;
                OkButton.Enabled = true;
                }
            else
                {
                NameBorderPanel.BackColor = Color.Red;
                OkButton.Enabled = false;
                }
            }

        private void OkButton_Click(object sender, EventArgs e)
            {
            AddModifierRecord();
            Close();
            }

        #endregion

        #region Private Members
        private void AddModifierRecord()
            {
            ModifierModel model;
            string categoryName;
            string applyToName;

            categoryName = CategoryComboBox.SelectedItem.ToString();
            applyToName = ApplyToComboBox.SelectedItem.ToString();

            model = new ModifierModel();
            model.Initialize(Guid.Empty);
            model.TableNamesId = TableNamesModel.GetIdFromTableName(categoryName);
            if (categoryName == "Ability")
                model.ApplyToId = AbilityModel.GetIdFromName(applyToName);
            else if (categoryName == "Attribute")
                model.ApplyToId = AttributeModel.GetIdFromName(applyToName);
            else if (categoryName == "Feat")
                model.ApplyToId = AttributeModel.GetIdFromName(applyToName);
            else if (categoryName == "Save")
                model.ApplyToId = AttributeModel.GetIdFromName(applyToName);
            else if (categoryName == "Skill")
                model.ApplyToId = AttributeModel.GetIdFromName(applyToName);
            else if (categoryName == "Spell")
                model.ApplyToId = AttributeModel.GetIdFromName(applyToName);
            else
                {
                Debug.WriteLine("Error: No category exists for the one selected. NewModifierDialogClass: AddModifierRecord()");
                return;
                }
            model.Name = NameTextBox.Text;
            model.Save();
            NewModifierId = model.Id;

            }

        private void FillApplyToComboBox()
            {
            //do not reset the ApplyToNames here as it is reset elsewhere since ApplyToNames
            //can come from various models, so it is set then this routine is called.
            foreach (string name in ApplyToNames)
                ApplyToComboBox.Items.Add(name);

            }

        private void FillCategoryComboBox()
            {
            CategoryNames.Clear();
            CategoryNames = TableNamesModel.GetNamesByModifierUsage(true);
            foreach (string name in CategoryNames)
                CategoryComboBox.Items.Add(name);
            }

        private void UpdateNameField()
            {
            string name;
            name = "";
            if (CategoryComboBox.SelectedItem != null)
                name = CategoryComboBox.SelectedItem.ToString();
            if (ApplyToComboBox.SelectedItem != null)
                name += ": " + ApplyToComboBox.SelectedItem.ToString();

            NameTextBox.Text = name.ToString();
            }

        #endregion
        }
    }
