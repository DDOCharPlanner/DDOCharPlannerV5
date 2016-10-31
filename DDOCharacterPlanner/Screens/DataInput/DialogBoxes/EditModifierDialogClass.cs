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
    public partial class EditModifierDialogClass : Form
        {

        #region Member Variables
        private List<string> ModifierNames;
        private List<string> RequirementNames;
        private List<string> BonusTypeNames;
        private List<string> StanceNames;
        private List<string> PullFromNames;
        private List<string> ModifierMethodNames;
        private bool NewFlag;
        private byte SelectedModifierType;
        private Guid SelectedModifierId;
        private Guid SelectedModifierMethodId;
        private Guid SelectedBonusTypeId;
        private Guid SelectedPullFromId;
        private double SelectedModifierValue;
        private Guid SelectedRequirementId;
        private Guid SelectedStanceId;
        private string SelectedComparison;
        private double SelectedRequirementValue;

        bool AllowEvents;
        #endregion

        #region Properties
        public byte ModifierType { get { return SelectedModifierType; } }
        public Guid ModifierID { get { return SelectedModifierId; } }
        public Guid ModifierMethodId { get { return SelectedModifierMethodId; } }
        public Guid BonusTypeId { get { return SelectedBonusTypeId; } }
        public Guid PullFromId { get { return SelectedPullFromId; } }
        public double ModifierValue { get { return SelectedModifierValue; } }
        public Guid RequirementId { get { return SelectedRequirementId; } }
        public Guid StanceId { get { return SelectedStanceId; } }
        public string Comparison { get { return SelectedComparison; } }
        public double RequirmentValue { get { return SelectedRequirementValue; } }

        #endregion

        #region Constructors
        public EditModifierDialogClass()
            {
            InitializeComponent();

            this.NewFlag = true;
            this.SelectedModifierType = 0;
            this.SelectedModifierMethodId = ModifierMethodModel.GetIdFromMethodName("Normal");
            this.SelectedModifierId = Guid.Empty;
            this.SelectedBonusTypeId = Guid.Empty;
            this.SelectedPullFromId = Guid.Empty;
            this.SelectedRequirementId = Guid.Empty;
            this.SelectedStanceId = Guid.Empty;
            this.SelectedComparison = "=";
            this.SelectedModifierValue = 0;
            this.SelectedRequirementValue = 0;

            //Set our list/trackers to empty lists
            ModifierMethodNames = new List<string>();
            ModifierNames = new List<string>();
            BonusTypeNames = new List<string>();
            PullFromNames = new List<string>();
            RequirementNames = new List<string>();
            StanceNames = new List<string>();



            AllowEvents = true;
            }

        public EditModifierDialogClass(byte modifierType, Guid modifierId, Guid modifierMethodId, Guid bonusTypeId, Guid pullFromId, double modifierValue, Guid requirementId, Guid stanceId, string comparison, double requirementValue)
            {
            InitializeComponent();

            this.NewFlag = false;
            this.SelectedModifierType = modifierType;
            this.SelectedModifierId = modifierId;
            this.SelectedModifierMethodId = modifierMethodId;
            this.SelectedBonusTypeId = bonusTypeId;
            this.SelectedPullFromId = pullFromId;
            this.SelectedModifierValue = modifierValue;
            this.SelectedRequirementId = requirementId;
            this.SelectedComparison = comparison;
            this.SelectedRequirementValue = requirementValue;
            this.SelectedStanceId = stanceId;

            //Set our list/trackers to empty lists
            ModifierMethodNames = new List<string>();
            ModifierNames = new List<string>();
            BonusTypeNames = new List<string>();
            PullFromNames = new List<string>();
            RequirementNames = new List<string>();
            StanceNames = new List<string>();

            AllowEvents = true;
            }

        #endregion

        #region Control Events
        private void BonusTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            bool flag = false;

            if (AllowEvents == false)
                return;

            if (BonusTypeCombo.SelectedIndex == 1)
                {
                flag = OpenNewBonusTypeDialog();
                if (flag == false)
                    return;
                }

            SelectedBonusTypeId = BonusTypeModel.GetIdFromName(BonusTypeCombo.SelectedItem.ToString());
            CheckToEnableOkButton();
            }

        private void CancelChangesButton_Click(object sender, EventArgs e)
            {
            Close();
            }

        private void ComparisonComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (AllowEvents == false)
                return;

            SelectedComparison = ComparisonComboBox.SelectedItem.ToString();
            CheckToEnableOkButton();
            }

        private void ModifierComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            bool flag = false;

            if (AllowEvents == false)
                return;

            if (ModifierComboBox.SelectedIndex == 0)
                {
                flag = OpenNewModifierDialog();
                if (flag == false)
                    return;
                }

            SelectedModifierId = ModifierModel.GetIdFromName(ModifierComboBox.SelectedItem.ToString());
            CheckToEnableOkButton();
            }

        private void ModifierMethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            string methodName;
            if (AllowEvents == false)
                return;

            methodName = ModifierMethodComboBox.SelectedItem.ToString();
            SelectedModifierMethodId = ModifierMethodModel.GetIdFromMethodName(methodName);
            if (methodName == "AbilityBonus" || methodName == "AbilitySwap" || methodName == "Attribute")
                {
                PullFromComboBox.Visible = true;
                PullFromLabel.Visible = true;
                FillPullFromComboBox();
                PullFromComboBox.SelectedIndex = 0;
                }
            else
                {
                PullFromComboBox.Visible = false;
                PullFromLabel.Visible = false;
                }
            CheckToEnableOkButton();
            }

        private void ModifierValueNumUpDown_ValueChanged(object sender, EventArgs e)
            {
            if (AllowEvents == false)
                return;

            SelectedModifierValue = (double)ModifierValueNumUpDown.Value;
            CheckToEnableOkButton();
            }

        private void OKButton_Click(object sender, EventArgs e)
            {
            Close();
            }

        private void PassiveRadioButton_Click(object sender, EventArgs e)
            {
            if (AllowEvents == false)
                return;

            SelectedModifierType = 0;
            StanceComboBox.Visible = false;
            StanceLabel.Visible = false;
            CheckToEnableOkButton();
            }

        private void PullFromComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            string methodName;

            if (AllowEvents == false)
                return;

            methodName = ModifierMethodComboBox.SelectedItem.ToString();
            if (methodName == "AbilityBonus" || methodName == "AbilitySwap")
                SelectedPullFromId = AbilityModel.GetIdFromName(PullFromComboBox.SelectedItem.ToString());
            else
                SelectedPullFromId = AttributeModel.GetIdFromName(PullFromComboBox.SelectedItem.ToString());

            CheckToEnableOkButton();
            }

        private void RequirementComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            bool flag = false;

            if (AllowEvents == false)
                return;

            if (RequirementComboBox.SelectedIndex == 1)
                {
                flag = OpenNewRequirementDialog();
                if (flag == false)
                    return;
                }

            SelectedRequirementId = RequirementModel.GetIdFromName(RequirementComboBox.SelectedItem.ToString());
            CheckToEnableOkButton();
            }

        private void RequirmentValueNumUpDown_ValueChanged(object sender, EventArgs e)
            {
            if (AllowEvents == false)
                return;

            SelectedRequirementValue = (double)RequirementValueNumUpDown.Value;
            CheckToEnableOkButton();
            }

        private void StanceComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {

            if (AllowEvents == false)
                return;

            SelectedStanceId  = StanceModel.GetIdFromStanceName(StanceComboBox.SelectedItem.ToString());
            CheckToEnableOkButton();
            }

        private void StanceRadioButton_Click(object sender, EventArgs e)
            {
            if (AllowEvents == false)
                return;
            SelectedModifierType = 1;
            StanceComboBox.Visible = true;
            StanceLabel.Visible = true;
            CheckToEnableOkButton();
            }

        #endregion

        #region Form Events
        private void EditModifierDialogClass_Load(object sender, EventArgs e)
            {
            string methodName;

            methodName = "";

            AllowEvents = false;
            //Fill our standard ComboBoxes
            FillModifierMethodComboBox();
            FillModifierComboBox();
            FillBonusTypeComboBox();
            FillRequirementComboBox();
            FillStanceComboBox();

            //Set values based on how dialog was opened (Add or Edit)
            if (NewFlag == true)
                {
                //Creating a new modifier
                StanceComboBox.Visible = false;
                StanceLabel.Visible = false;
                PullFromComboBox.Visible = false;
                PullFromLabel.Visible = false;
                PassiveRadioButton.Checked = true;
                ModifierMethodComboBox.SelectedItem = "Normal";     
                }

            else
                {
                //editing an existing modifier
                if (SelectedModifierType == 0)
                    PassiveRadioButton.Checked = true;
                else
                    {
                    StanceRadioButton.Checked = true;
                    StanceComboBox.Visible = true;
                    StanceLabel.Visible = true;
                    StanceComboBox.SelectedItem = StanceModel.GetStanceNameFromId(SelectedStanceId).ToString();
                    }
                methodName = ModifierMethodModel.GetMethodNameFromId(SelectedModifierMethodId).ToString();
                ModifierMethodComboBox.SelectedItem = methodName;
                if (methodName == "AbilityBonus" || methodName == "Attribute" || methodName == "AbilitySwap")
                    {
                    FillPullFromComboBox();
                    PullFromComboBox.Visible = true;
                    PullFromLabel.Visible = true;
                    if (methodName == "AbilityBonus" || methodName == "AbilitySwap")
                        PullFromComboBox.SelectedItem = AbilityModel.GetNameFromId(SelectedPullFromId).ToString();
                    if (methodName == "Attribute")
                        PullFromComboBox.SelectedItem = AttributeModel.GetNameFromId(SelectedPullFromId).ToString();
                    }
               
                ModifierComboBox.SelectedItem = ModifierModel.GetNameFromId(SelectedModifierId).ToString();
                BonusTypeCombo.SelectedItem = BonusTypeModel.GetNameFromId(SelectedBonusTypeId).ToString();
                ModifierValueNumUpDown.Value = (decimal)SelectedModifierValue;
                RequirementComboBox.SelectedItem = RequirementModel.GetNameFromId(SelectedRequirementId).ToString();
                ComparisonComboBox.SelectedItem = SelectedComparison;
                RequirementValueNumUpDown.Value = (decimal)SelectedRequirementValue;
                }
            OKButton.Enabled = false;
            AllowEvents = true;

            }

        #endregion

        #region Private Members
        private void CheckToEnableOkButton()
            {

            if (ModifierComboBox.SelectedIndex < 1)
                OKButton.Enabled = false;

            else if (SelectedModifierType == 1 && StanceComboBox.SelectedIndex < 0)
                OKButton.Enabled = false;

            else if (ModifierMethodComboBox.SelectedItem.ToString() == "AbilityBonus" || ModifierMethodComboBox.SelectedItem.ToString() == "AbilitySwap" || ModifierMethodComboBox.SelectedItem.ToString() == "Attribute")
                {
                if (PullFromComboBox.SelectedIndex < 0)
                    OKButton.Enabled = false;
                else
                    OKButton.Enabled = true;
                }
            else
                //since we made it this far, everything is valid so enable the Ok button.
                OKButton.Enabled = true;
            
            }

        private void FillBonusTypeComboBox()
            {
            BonusTypeNames.Clear();
            BonusTypeCombo.Items.Clear();
            BonusTypeNames = BonusTypeModel.GetNames();
            BonusTypeCombo.Items.Add("");
            BonusTypeCombo.Items.Add("_Add New Bonus Type");
            foreach (string name in BonusTypeNames)
                BonusTypeCombo.Items.Add(name);
            }

        private void FillModifierComboBox()
            {
            ModifierNames.Clear();
            ModifierNames = ModifierModel.GetNames();
            ModifierComboBox.Items.Clear();
            ModifierComboBox.Items.Add("_Add New Modifier");
            foreach (string name in ModifierNames)
                ModifierComboBox.Items.Add(name);
            }

        private void FillModifierMethodComboBox()
            {
            ModifierMethodNames.Clear();
            ModifierMethodNames = ModifierMethodModel.GetNames();
            ModifierMethodComboBox.Items.Clear();
            foreach (string name in ModifierMethodNames)
                ModifierMethodComboBox.Items.Add(name);
            }

        private void FillPullFromComboBox()
            {
            PullFromNames.Clear();
            PullFromComboBox.Items.Clear();
            if (ModifierMethodComboBox.SelectedItem.ToString() == "AbilityBonus")
                PullFromNames = AbilityModel.GetNames();
            else if (ModifierMethodComboBox.SelectedItem.ToString() == "Attribute")
                PullFromNames = AttributeModel.GetNames();
            else if (ModifierMethodComboBox.SelectedItem.ToString() == "AbilitySwap")
                PullFromNames = AbilityModel.GetNames();

            foreach (string name in PullFromNames)
                PullFromComboBox.Items.Add(name);
            }

        private void FillRequirementComboBox()
            {
            RequirementNames.Clear();
            RequirementNames = RequirementModel.GetNames();
            RequirementComboBox.Items.Clear();
            RequirementComboBox.Items.Add("");
            RequirementComboBox.Items.Add("_Add New Requirement");
            foreach (string name in RequirementNames)
                RequirementComboBox.Items.Add(name);
            }

        private void FillStanceComboBox()
            {
            StanceNames.Clear();
            StanceComboBox.Items.Clear();
            StanceNames = StanceModel.GetNames();
            foreach (string name in StanceNames)
                StanceComboBox.Items.Add(name);
            }

        private bool OpenNewBonusTypeDialog()
            {
            NewBonusTypeDialogClass dlgNewBonustype;
            DialogResult result;

            dlgNewBonustype = new NewBonusTypeDialogClass();
            result = dlgNewBonustype.ShowDialog();
            if (result == DialogResult.OK)
                {
                AllowEvents = false;
                //Update the BonusType ComboBox with the new value and autoselect it.
                FillBonusTypeComboBox();

                BonusTypeCombo.SelectedItem = BonusTypeModel.GetNameFromId(dlgNewBonustype.BonusTypeId);
                AllowEvents = true;
                return true;
                }
            return false;
            }

        private bool OpenNewModifierDialog()
            {
            NewModifierDialogClass dlgNewModifier;
            DialogResult result;

            dlgNewModifier = new NewModifierDialogClass();
            result = dlgNewModifier.ShowDialog();
            if (result == DialogResult.OK)
                {
                AllowEvents = false;
                //Update the Modifier ComboBox with the new value and autoselect it.
                FillModifierComboBox();
                ModifierComboBox.SelectedItem = ModifierModel.GetNameFromId(dlgNewModifier.ModifierId);
                AllowEvents = true;
                return true;
                }
            return false;
            }

        private bool OpenNewRequirementDialog()
            {
            NewRequirementDialogClass dlgNewRequirement;
            DialogResult result;

            dlgNewRequirement = new NewRequirementDialogClass();
            result = dlgNewRequirement.ShowDialog();
                if (result == DialogResult.OK)
                    {
                    AllowEvents = false;
                    //Update the Requirment ComboBox with the new value and autoSelect it.
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
