using DDOCharacterPlanner.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.DataInput
    {
    public partial class ModifierDialogClass : Form
        {
        #region Member Variables
        private int DefaultWidth;
        private int DefaultHeight;
        private bool isNewRecord;
        private List<string> CategoryNames;
        private List<string> ModifierNames;
        private List<string> BonusTypeNames;
        private List<string> StanceNames;
        private List<string> PullFromNames;
        private List<string> ModifierMethodNames;

        private byte SelectedModifierType;
        private Guid SelectedModifierId;
        private Guid SelectedModifierMethodId;
        private Guid SelectedBonusTypeId;
        private Guid SelectedPullFromId;
        private double SelectedModifierValue;
        private Guid SelectedStanceId;
        private Guid SelectedRequirementId;
        private string SelectedComparison;
        private double SelectedRequirementValue;

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
        public ModifierDialogClass()
            {
            InitializeComponent();
            DefaultWidth = 551;
            DefaultHeight = 358;
            }

        public ModifierDialogClass(bool recordIsNew, Guid modifierId, Guid requirementId, Guid modifierMethodId, Guid bonusTypeId, Guid pullFromId, 
            Guid stanceId, byte modifierType = 0, double modifierValue = 0, string requirementComparison = "", double requirementValue = 0)
            {
            InitializeComponent();
            DefaultWidth = 551;
            DefaultHeight = 358;

            //lets set our member variables
            isNewRecord = recordIsNew;
            SelectedModifierType = modifierType;
            SelectedModifierId = modifierId;
            if (modifierMethodId == Guid.Empty)
                SelectedModifierId = ModifierMethodModel.GetIdFromMethodName("Normal");
            else
                SelectedModifierMethodId = modifierMethodId;
            SelectedBonusTypeId = bonusTypeId;
            SelectedPullFromId = pullFromId;
            SelectedModifierValue = modifierValue;
            SelectedRequirementId = requirementId;
            SelectedComparison = requirementComparison;
            SelectedRequirementValue = requirementValue;
            SelectedStanceId = stanceId;

            //Set our Lists to Empty
            CategoryNames = new List<string>();
            ModifierMethodNames = new List<string>();
            ModifierNames = new List<string>();
            BonusTypeNames = new List<string>();
            PullFromNames = new List<string>();
            StanceNames = new List<string>();
            }

        #endregion

        #region Form Events
        private void ModifierDialogClass_Load(object sender, EventArgs e)
            {
            //Lets fill our ComboBoxes that don't change
            FillcomboBonusType();
            FillcomboCategory();
            FillcomboModifierMethod();
            FillcomboStance();

            if (SelectedModifierType == 0)
                radioPassive.Checked = true;
            else
                radioStance.Checked = true;

            comboModifierMethod.SelectedItem = ModifierMethodModel.GetMethodNameFromId(SelectedModifierMethodId);
            if (isNewRecord == true)
                {
                comboCategory.SelectedIndex = -1;
                buttonOk.Enabled = false;
                }
            else
                comboCategory.SelectedItem = GetCategoryName(SelectedModifierId);
            if (isNewRecord == false && SelectedStanceId != Guid.Empty)
                comboStance.SelectedItem = StanceModel.GetStanceNameFromId(SelectedStanceId);
            }

        #endregion

        #region Control Events
        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (e.ToString() != "")
                {
                FillcomboModifier();
                buttonOk.Enabled = false;
                }
            }

        private void comboModifier_SelectedIndexChanbed(object sender, EventArgs e)
            {
            if (e.ToString() == "")
                {
                SelectedModifierId = Guid.Empty;
                buttonOk.Enabled = false;
                }
            else
                {
                SelectedModifierId = ModifierModel.GetIdFromTableNamesIdandApplyToId(GetTableNameId(), GetApplyToId());
                }
            }

        private void radioPassive_CheckedChanged(object sender, EventArgs e)
            {
            
            }

        private void radioPassive_Click(object sender, EventArgs e)
            {
            ChangeModifierType(false);
            }

        private void radioStance_Click(object sender, EventArgs e)
            {
            ChangeModifierType(true);
            }

        #endregion

        #region Private members
        private void ChangeModifierType(bool methodStance)
            {
            if (methodStance == true)
                SelectedModifierType = 1;
            else
                SelectedModifierType = 0;

           labelStance.Visible = methodStance;
           comboStance.Visible = methodStance;

            }

        private void FillcomboBonusType()
            {
            BonusTypeNames.Clear();
            comboBonusType.Items.Clear();
            BonusTypeNames = BonusTypeModel.GetNames();
            foreach (string name in BonusTypeNames)
                comboBonusType.Items.Add(name);
            }

        private void FillcomboCategory()
            {
            CategoryNames.Clear();
            CategoryNames = TableNamesModel.GetNamesByModifierUsage(true);
            foreach (string name in CategoryNames)
                comboCategory.Items.Add(name);
            }

        private void FillcomboModifier()
            {
            string categoryName;

            categoryName = comboCategory.SelectedItem.ToString();
            ModifierNames.Clear();
            comboModifier.Items.Clear();

            if (categoryName == "Ability")
                {
                labelModifier.Text = "Select an Ability";
                ModifierNames = AbilityModel.GetNames();
                }
            else if (categoryName == "Attribute")
                {
                labelModifier.Text = "Select an Attribute";
                ModifierNames = AttributeModel.GetNames();
                }
            else if (categoryName == "Feat")
                {
                labelModifier.Text = "Select a Feat";
                ModifierNames = FeatModel.GetNames();
                }
            else if (categoryName == "Save")
                {
                labelModifier.Text = "Select a Save";
                ModifierNames = SaveModel.GetNames();
                }
            else if (categoryName == "Skill")
                {
                labelModifier.Text = "Select a Skill";
                ModifierNames = SkillModel.GetNames();
                }
            else if (categoryName == "Spell")
                {
                labelModifier.Text = "Select a Spell";
                ModifierNames = SpellModel.GetNames();
                }
            else
                {
                //We should never reach this, if so, we need to add a category of fix one.
                Debug.WriteLine("Error: no category exist for the selected. ModifierDialogClass::FillcomboModifier()");
                return;
                }

            foreach (string name in ModifierNames)
                comboModifier.Items.Add(name);
            }

        private void FillcomboModifierMethod()
            {
            ModifierMethodNames.Clear();
            ModifierMethodNames = ModifierMethodModel.GetNames();
            comboModifierMethod.Items.Clear();
            foreach (string name in ModifierMethodNames)
                comboModifierMethod.Items.Add(name);
            }

        private void FillcomboPullFrom()
            {
            string methodName;

            methodName = comboModifierMethod.SelectedItem.ToString();

            PullFromNames.Clear();
            comboPullFrom.Items.Clear();
            if (methodName == "AbilityBonus")
                PullFromNames = AbilityModel.GetNames();
            else if (methodName == "Attribute")
                PullFromNames = AttributeModel.GetNames();
            else if (methodName == "AbilitySwap")
                PullFromNames = AbilityModel.GetNames();
            else
                //We should not reach this point
                Debug.WriteLine("Error: No modifer Method exists for the one selected. ModifierDialogClass::FillcomboPullFrom()");

            foreach (string name in PullFromNames)
                comboPullFrom.Items.Add(name);

            }

        private void FillcomboStance()
            {
            StanceNames.Clear();
            comboStance.Items.Clear();
            StanceNames = StanceModel.GetNames();
            foreach (string name in StanceNames)
                comboStance.Items.Add(name);
            }

        private Guid GetApplyToId()
            {
            Guid applyToId;
            string tableName;

            applyToId = Guid.Empty;
            tableName = comboCategory.SelectedItem.ToString();


            if (tableName == "Ability")
                applyToId = AbilityModel.GetIdFromName(comboModifier.SelectedItem.ToString());
            else if (tableName == "Attribute")
                applyToId = AttributeModel.GetIdFromName(comboModifier.SelectedItem.ToString());
            else if (tableName == "Feat")
                applyToId = FeatModel.GetIdFromName(comboModifier.SelectedItem.ToString());
            else if (tableName == "Save")
                applyToId = SaveModel.GetIdFromName(comboModifier.SelectedItem.ToString());
            else if (tableName == "Skill")
                applyToId = SkillModel.GetIdFromName(comboModifier.SelectedItem.ToString());
            else if (tableName == "Spell")
                applyToId = SpellModel.GetIdFromName(comboModifier.SelectedItem.ToString());
            else
                {
                //We should never reach this, if so, we need to add a category of fix one.
                Debug.WriteLine("Error: no category exists for the selected. ModifierDialogClass::GetApplyToId()");
                return applyToId;
                }

            return applyToId;
            }

        private string GetCategoryName(Guid modifierId)
            {
            string name;
            ModifierModel model;

            model = new ModifierModel();
            model.Initialize(modifierId);
            name = TableNamesModel.GetTableNameFromId(model.TableNamesId);

            return name;
            }

        private Guid GetTableNameId()
            {
            return TableNamesModel.GetIdFromTableName(comboCategory.SelectedItem.ToString());
            }

        #endregion
        }
    }
