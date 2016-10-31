using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DDOCharacterPlanner.Model;

namespace DDOCharacterPlanner.Screens.DataInput
    {
    public partial class EditRequirementDialogClass : Form
        {
        #region Enums
        public enum MethodType
            {
            Add,
            Edit,
            }

        #endregion

        #region Member Variables
        private List<string> RequirementNames;        
        private MethodType Method;
        private Guid SelectedRequirementId;
        private double RequirementValueEntered;
        private bool RequireAllChecked;
        private string SelectedComparison;
        bool AllowEvents;

        #endregion

        #region Properties
        public Guid RequirementId
            {
            get { return SelectedRequirementId; }
            }
        public double RequirementValue
            {
            get { return RequirementValueEntered; }
            }
        public bool RequiresAll
            {
            get { return RequireAllChecked; }
            }
        public string RequirementComparison
            {
            get { return SelectedComparison; }
            }

        #endregion

        #region Constructors
        public EditRequirementDialogClass()
            {
            InitializeComponent();
            }

        public EditRequirementDialogClass(Guid requirementId, MethodType method, double value, bool requireAll, string comparison)
            {
            InitializeComponent();
            this.SelectedRequirementId = requirementId;
            this.Method = method;
            this.RequirementValueEntered = value;
            this.RequireAllChecked = requireAll;
            this.SelectedComparison = comparison;
            ComparisonComboBox.SelectedItem = "=";
            AllowEvents = true;
            }

        #endregion

        #region Control Events
        private void ComparisonComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            SelectedComparison = ComparisonComboBox.SelectedItem.ToString();
            CheckToEnableOkButton();
            }

        private void RequirementComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (AllowEvents == false)
                return;

            bool flag = false;
            if (RequirementComboBox.SelectedIndex == 0)
                {
                flag = OpenNewRequirmentDialog();
                if (flag == false)
                    return;
                }

            SelectedRequirementId = RequirementModel.GetIdFromName(RequirementComboBox.SelectedItem.ToString());
            CheckToEnableOkButton();
            }

        private void RequireAllCheckBox_CheckedChanged(object sender, EventArgs e)
            {
            RequireAllChecked = RequireAllCheckBox.Checked;
            CheckToEnableOkButton();
            }

        private void RequirementValueNumUpDown_ValueChanged(object sender, EventArgs e)
            {
            RequirementValueEntered = (int)RequirementValueNumUpDown.Value;
            CheckToEnableOkButton();
            }

        private void OkButton_Click(object sender, EventArgs e)
            {
            Close();
            }

        private void CancelChangesButton_Click(object sender, EventArgs e)
            {
            Close();
            }

        #endregion

        #region Form Events
        private void EditRequirementDialogClass_Load(object sender, EventArgs e)
            {
            AllowEvents = false;
            RequirementNames = RequirementModel.GetNames();
            FillRequirementComboBox();
            if (Method == MethodType.Add)
                RequirementComboBox.SelectedIndex = -1;
            else
                RequirementComboBox.SelectedItem = RequirementModel.GetNameFromId(SelectedRequirementId);
            ComparisonComboBox.SelectedItem = SelectedComparison.ToString();
            RequirementValueNumUpDown.Value = (decimal)RequirementValueEntered;
            RequireAllCheckBox.Checked = RequireAllChecked;
            AllowEvents = true;

            }
        #endregion

        #region Private Members
        private void FillRequirementComboBox()
            {
            RequirementNames.Clear();
            RequirementNames = RequirementModel.GetNames();
            RequirementComboBox.Items.Clear();
            RequirementComboBox.Items.Add("_Add New Requirement");
            foreach (string name in RequirementNames)
                RequirementComboBox.Items.Add(name);
            }

        private void CheckToEnableOkButton()
            {
            if (RequirementComboBox.SelectedIndex < 1)
                OkButton.Enabled = false;
            else
                OkButton.Enabled = true;   
            }

        private bool OpenNewRequirmentDialog()
            {
            NewRequirementDialogClass dlgNewRequirement;
            DialogResult result;

            dlgNewRequirement = new NewRequirementDialogClass();
            result = dlgNewRequirement.ShowDialog();
            if (result == DialogResult.OK)
                {
                AllowEvents = false;
                //Update the Requiremetn Listbox with the new value and autoselect it.
                FillRequirementComboBox();

                RequirementComboBox.SelectedItem = RequirementModel.GetNameFromId(dlgNewRequirement.RequirementId);
                AllowEvents = true;
                return true;
                }

            return false;
            }
        #endregion
        }
    }
