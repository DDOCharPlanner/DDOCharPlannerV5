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
    public partial class RequirementDialogClass : Form
        {
        #region Member Variables
        private bool isNewRecord;
        private Guid SelectedRequirementId;
        private double SelectedRequirementValue;
        private bool SelectedRequiresAll;
        private string SelectedComparison;
        bool AllowEvents;
        private int DefaultWidth;
        private int DefaultHeight;
        private List<string> CategoryNames;
        private List<string> ApplyToNames;
        private List<string> TreeNames;
        #endregion

        #region Properties
        public Guid RequirementId
            {
            get { return SelectedRequirementId; }
            }
        public double RequirementValue
            {
            get { return SelectedRequirementValue; }
            }
        public bool RequiresAll
            {
            get { return SelectedRequiresAll; }
            }
        public string RequirementComparison
            {
            get { return SelectedComparison; }
            }
        #endregion

        #region Constructors

        public RequirementDialogClass()
            {
            InitializeComponent();
            }

        public RequirementDialogClass(bool recordIsNew, Guid requirementId, double value = 0, bool requiresAll = true, string comparison = ">=")
            {
            InitializeComponent();
            ApplyToNames = new List<string>();
            DefaultWidth = 300;
            DefaultHeight = 245;
            //Lets hide these controls until the user needs them
            comboTree.Visible = false;
            labelTree.Visible = false;
            comboSlot.Visible = false;
            labelSlot.Visible = false;
            //now lets resize our form
            this.Size = new Size(DefaultWidth, DefaultHeight);

            this.SelectedRequirementId = requirementId;
            this.isNewRecord = recordIsNew;
            this.SelectedRequirementValue = value;
            this.SelectedRequiresAll = requiresAll;
            this.SelectedComparison = comparison;
            AllowEvents = true;
            buttonOk.Enabled = false;
            }

        #endregion

        #region Form Events
        private void RequirementDialogClass_Load(object sender, EventArgs e)
            {
            //AllowEvents = false;

            //Lets create our category List and add it to the combobox
            CategoryNames = TableNamesModel.GetNamesByRequirementUsage(true);
            foreach (string name in CategoryNames)
                comboCategory.Items.Add(name);
            if (isNewRecord == true)
                {
                comboCategory.SelectedIndex = -1;
                buttonOk.Enabled = false;
                }
            else
                {
                comboCategory.SelectedItem = GetCategoryName(SelectedRequirementId);
                if (comboTree.Visible == true)
                    comboTree.SelectedItem = GetTreeName(SelectedRequirementId);
                if (comboSlot.Visible == true)
                    comboSlot.SelectedItem = BuildSlotName(GetSlotModel(RequirementId));
                Debug.WriteLine("ApplytoValue " + GetApplyToName(SelectedRequirementId));
                comboApplyTo.SelectedItem = GetApplyToName(SelectedRequirementId);
                
                }
            comboComparison.SelectedItem = SelectedComparison.ToString();
            numberValue.Value = (decimal)SelectedRequirementValue;
            checkboxRequiresAll.Checked = SelectedRequiresAll;
            AllowEvents = true;
            
            }

        #endregion

        #region Control Events
        private void buttonCancel_Click(object sender, EventArgs e)
            {
            Close();
            }

        private void buttonOk_Click(object sender, EventArgs e)
            {
            if (RequirementId == Guid.Empty)
                AddNewRequirementRecord();

            Close();
            }

        private void checkboxRequirersAll_CheckedChanged(object sender, EventArgs e)
            {
            SelectedRequiresAll = checkboxRequiresAll.Checked;
            }

        private void comboAppyTo_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (e.ToString() == "")
                {
                SelectedRequirementId = Guid.Empty;
                buttonOk.Enabled = false;
                }
            else
                {
                SelectedRequirementId = RequirementModel.GetIdFromTableNamesIdandApplyToId(GetTableNamesId(), GetApplyToId());
                buttonOk.Enabled = true;
                }
            }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
            {
            string categoryName;

            categoryName = comboCategory.SelectedItem.ToString();

            ApplyToNames.Clear();
            comboApplyTo.Items.Clear();
            comboTree.Items.Clear();
            //resize our form
            this.Size = new Size(DefaultWidth, DefaultHeight);
            //hide our optional controls
            labelTree.Visible = false;
            comboTree.Visible = false;
            labelSlot.Visible = false;
            comboSlot.Visible = false;

            if (categoryName == "Ability")
                {
                ApplyToNames = AbilityModel.GetNames();
                labelApplyTo.Text = "Select an Ability";
                }

            else if (categoryName == "Alignments")
            {
                ApplyToNames = AlignmentModel.GetNames();
                labelApplyTo.Text = "Select an Alignment";
            }
            else if (categoryName == "Attribute")
                {
                ApplyToNames = AttributeModel.GetNames();
                labelApplyTo.Text = "Select an Attribute";
                }

            else if (categoryName == "Character")
                {
                ApplyToNames.Add("Level");
                labelApplyTo.Text = "Select Character Property";
                }

            else if (categoryName == "Class")
                {
                ApplyToNames = ClassModel.GetNames();
                labelApplyTo.Text = "Select a Class";
                }

            else if (categoryName == "Enhancement")
                {
                //lets resie our form to make room for other controls
                this.Size = new Size(DefaultWidth, DefaultHeight + 99);
                labelTree.Visible = true;
                comboTree.Visible = true;
                labelSlot.Visible = true;
                comboSlot.Visible = true;
                TreeNames = EnhancementTreeModel.GetNames();
                foreach (string name in TreeNames)
                    comboTree.Items.Add(name);
                labelApplyTo.Text = "Select an Enhancement";
                buttonOk.Enabled = false;
                return;
                }

            else if (categoryName == "EnhancementSlot")
                {
                //lets resize our form to make room for other controls
                this.Size = new Size(DefaultWidth, DefaultHeight + 47);
                labelTree.Visible = true;
                comboTree.Visible = true;
                TreeNames = EnhancementTreeModel.GetNames();
                foreach (string name in TreeNames)
                    comboTree.Items.Add(name);
                labelApplyTo.Text = "Select an Enhancement Slot";
                buttonOk.Enabled = false;
                return;
                }

            else if (categoryName == "Feat")
                {
                ApplyToNames = FeatModel.GetNames();
                labelApplyTo.Text = "Select a Feat";
                }

            else if (categoryName == "Race")
                {
                ApplyToNames = RaceModel.GetNames();
                labelApplyTo.Text = "Select a Race";
                }

            else if (categoryName == "Skill")
                {
                ApplyToNames = SkillModel.GetNames();
                labelApplyTo.Text = "Select a Skill";
                }

            else
                {
                Debug.WriteLine("Error: No category exists for the one selected. RequirementDialogClass : comboCategory_SelectedIndexChanged()");
                return;
                }

            foreach (string name in ApplyToNames)
                comboApplyTo.Items.Add(name);
            buttonOk.Enabled = false;

            }

        private void comboComparison_SelectedIndexChanged(object sender, EventArgs e)
            {
            SelectedComparison = comboComparison.SelectedItem.ToString();
            }

        private void comboSlot_SelectedIndexChanged(object sender, EventArgs e)
            {
            List<EnhancementModel> enhancementModels;
            
            if (e.ToString() != "")
                {
                //lets pull the enhancement data for the selected slot
                enhancementModels = EnhancementModel.GetAll(GetSlotId());

                comboApplyTo.Items.Clear();
                foreach (EnhancementModel model in enhancementModels)
                    comboApplyTo.Items.Add("Pos " + model.DisplayOrder.ToString() + ":: " + model.Name);
                }

            buttonOk.Enabled = false;
            }

        private void comboTree_SelectedIndexChanged(object sender, EventArgs e)
            {
            Guid treeId;
            List<EnhancementSlotModel> slotModels;

            if (e.ToString() != "")
                {
                treeId = EnhancementTreeModel.GetIdFromTreeName(comboTree.SelectedItem.ToString());

                slotModels = EnhancementSlotModel.GetAll(treeId);
                if (comboCategory.SelectedItem.ToString() == "Enhancement")
                    {
                    comboSlot.Items.Clear();
                    foreach (EnhancementSlotModel model in slotModels)
                        comboSlot.Items.Add(BuildSlotName(model));
                    comboApplyTo.Items.Clear();
                    }
                else
                    {
                    comboApplyTo.Items.Clear();
                    foreach (EnhancementSlotModel model in slotModels)
                        comboApplyTo.Items.Add(BuildSlotName(model));
                    
                    }
                }
            buttonOk.Enabled = false;
            }

        private void numberValue_ValueChanged(object sender, EventArgs e)
            {
            SelectedRequirementValue = (int)numberValue.Value;
            }

        #endregion

        #region Private Members
        private void AddNewRequirementRecord()
            {
            RequirementModel reqModel;
            string tableName;
            string applyToName;

            reqModel = new RequirementModel();
            tableName = comboCategory.SelectedItem.ToString();
            applyToName = comboApplyTo.SelectedItem.ToString();

            reqModel.TableNamesId = TableNamesModel.GetIdFromTableName(tableName);
            if (tableName == "Ability")
                reqModel.ApplytoId = AbilityModel.GetIdFromName(applyToName);
            else if (tableName == "Alignments")
                reqModel.ApplytoId = AlignmentModel.GetIdFromName(applyToName);
            else if (tableName == "Attribute")
                reqModel.ApplytoId = AttributeModel.GetIdFromName(applyToName);
            else if (tableName == "Class")
                reqModel.ApplytoId = ClassModel.GetIdFromName(applyToName);
            else if (tableName == "Enhancement")
                reqModel.ApplytoId = GetEnhancementId();
            else if (tableName == "EnhancementSlot")
                reqModel.ApplytoId = GetSlotId();
            else if (tableName == "Feat")
                reqModel.ApplytoId = FeatModel.GetIdFromName(applyToName);
            else if (tableName == "Race")
                reqModel.ApplytoId = RaceModel.GetIdFromName(applyToName);
            else if (tableName == "Skill")
                reqModel.ApplytoId = SkillModel.GetIdFromName(applyToName);
            else
                Debug.WriteLine("Error: CategoryName isn't listed :: RequirementDialogClass: AddNewRequirement");

            reqModel.Save();
            SelectedRequirementId = reqModel.Id;

            }

        private string BuildSlotName(EnhancementSlotModel model)
            {
            string name = "";

            name = "Slot " + model.SlotIndex.ToString() + ":: " + GetSlotName(model);
            return name;
            }

        private Guid GetApplyToId()
            {
            Guid applyToId;
            string tableName;

            applyToId = Guid.Empty;
            tableName = comboCategory.SelectedItem.ToString();

            if (tableName == "Ability")
                applyToId = AbilityModel.GetIdFromName(comboApplyTo.SelectedItem.ToString());
            if (tableName == "Alignments")
                applyToId = AlignmentModel.GetIdFromName(comboApplyTo.SelectedItem.ToString());
            if (tableName == "Attribute")
                applyToId = AttributeModel.GetIdFromName(comboApplyTo.SelectedItem.ToString());
            if (tableName == "Character")
                applyToId = Guid.Empty;
            if (tableName == "Class")
                applyToId = ClassModel.GetIdFromName(comboApplyTo.SelectedItem.ToString());
            if (tableName == "Enhancement")
                applyToId = GetEnhancementId();
            if (tableName == "EnhancementSlot")
                applyToId = GetSlotId();
            if (tableName == "Feat")
                applyToId = FeatModel.GetIdFromName(comboApplyTo.SelectedItem.ToString());
            if (tableName == "Race")
                applyToId = RaceModel.GetIdFromName(comboApplyTo.SelectedItem.ToString());
            if (tableName == "Skill")
                applyToId = SkillModel.GetIdFromName(comboApplyTo.SelectedItem.ToString());

            return applyToId;
            }

        private string GetApplyToName(Guid requirementId)
            {
            string applyToName;
            string tableName;
            RequirementModel reqModel;
            EnhancementModel enhancementModel;

            reqModel = GetRequirementModel(requirementId);
            //tableName = "Class";
            
            tableName = TableNamesModel.GetTableNameFromId(reqModel.TableNamesId);

            if (tableName == "Ability")
                applyToName = AbilityModel.GetNameFromId(reqModel.ApplytoId);
            else if (tableName == "Alignments")
                applyToName = AlignmentModel.GetNameFromID(reqModel.ApplytoId);
            else if (tableName == "Attribute")
                applyToName = AttributeModel.GetNameFromId(reqModel.ApplytoId);
            else if (tableName == "Character")
                applyToName = "Level";
            else if (tableName == "Class")
                applyToName = ClassModel.GetNameFromId(reqModel.ApplytoId);
            else if (tableName == "Enhancement")
                {
                //"Pos " + model.DisplayOrder.ToString() + ":: " + model.Name)
                enhancementModel = new EnhancementModel();
                enhancementModel.Initialize(reqModel.ApplytoId);
                applyToName = "Pos " + enhancementModel.DisplayOrder + ":: " + enhancementModel.Name;
                }
            else if (tableName == "EnhancementSlot")
                applyToName = BuildSlotName(GetSlotModel(requirementId));
            else if (tableName == "Feat")
                applyToName = FeatModel.GetNameFromId(reqModel.ApplytoId);
            else if (tableName == "Race")
                applyToName = RaceModel.GetNameFromId(reqModel.ApplytoId);
            else if (tableName == "Skill")
                applyToName = SkillModel.GetNameFromId(reqModel.ApplytoId);
            else
                applyToName = "";
            Debug.WriteLine("ApplyToName = " + applyToName);
            return applyToName;
            }

        private string GetCategoryName(Guid requirementId)
            {
            string name = "";
            RequirementModel model;

            model = new RequirementModel();
            model.Initialize(requirementId);
            name = TableNamesModel.GetTableNameFromId(model.TableNamesId);

            return name;
            }

        private Guid GetEnhancementId()
            {
            Guid slotId;
            Guid enhancementId;
            string enhancementName;
            string indexString;
            int startLoc = 0;
            int index = -1;
            string tempName;

            slotId = GetSlotId();
            enhancementName = comboApplyTo.SelectedItem.ToString();
            tempName = enhancementName.Remove(0, 4);
            startLoc = tempName.IndexOf(":: ");
            indexString = tempName.Remove(startLoc);
            index = Int32.Parse(indexString);
            enhancementId = EnhancementModel.GetIdFromSlotIdandDisplayOrder(slotId, (byte)index);
            return enhancementId;
            }

        private RequirementModel GetRequirementModel(Guid requirementId)
            {
            RequirementModel requirementModel;

            requirementModel = new RequirementModel();
            requirementModel.Initialize(requirementId);

            return requirementModel;
            }

        private Guid GetSlotId()
            {
            Guid treeId;
            Guid slotId;
            string slotName;
            string slotIndexString;
            int startLoc = 0;
            int index = -1;
            string tempName;
            slotName = "";
            treeId = EnhancementTreeModel.GetIdFromTreeName(comboTree.SelectedItem.ToString());
            if (comboCategory.SelectedItem.ToString() == "EnhancementSlot")
                slotName = comboApplyTo.SelectedItem.ToString();
            if (comboCategory.SelectedItem.ToString() == "Enhancement")
                slotName = comboSlot.SelectedItem.ToString();
            tempName = slotName.Remove(0, 5);
            startLoc = tempName.IndexOf(":: ");
            slotIndexString = tempName.Remove(startLoc);
            index = Int32.Parse(slotIndexString);
            slotId = EnhancementSlotModel.GetIdFromTreeIdandSlotIndex(treeId, index);
            return slotId;
            }

        private EnhancementSlotModel GetSlotModel(Guid requirementId)
            {
            EnhancementSlotModel slotModel;
            EnhancementModel enhModel;
            RequirementModel reqModel;
            string tableName = "";
            
            slotModel = new EnhancementSlotModel();
            reqModel = GetRequirementModel(requirementId);
            //tableName = TableNamesModel.GetNameFromId(reqModel.Id);
            tableName = TableNamesModel.GetTableNameFromId(reqModel.TableNamesId);

            if (tableName == "EnhancementSlot")
                slotModel.Initialize(reqModel.ApplytoId);

            if (tableName == "Enhancement")
                {
                enhModel = new EnhancementModel();
                enhModel.Initialize(reqModel.ApplytoId);
                slotModel.Initialize(enhModel.EnhancementSlotId);
                }

            return slotModel;
            }

        private string GetSlotName(EnhancementSlotModel model)
            {
            string name;
            Guid enhancementId;

            name = "";
            if (model.UseEnhancementInfo == true)
                {
                //Retrieve the Name of the First enhancement for this slot
                enhancementId = EnhancementModel.GetIdFromSlotIdandDisplayOrder(model.Id, 0);
                name = EnhancementModel.GetNameFromId(enhancementId);
                }
            else
                name = model.Name;

            return name;
            }

        private Guid GetTableNamesId()
            {
            return TableNamesModel.GetIdFromTableName(comboCategory.SelectedItem.ToString());

            }

        private string GetTreeName(Guid requirementId)
            {
            string treeName = "";
            RequirementModel reqModel;
            string tableName = "";
            EnhancementSlotModel slotModel;
            EnhancementModel enhModel;

            reqModel = GetRequirementModel(requirementId);
            tableName = TableNamesModel.GetTableNameFromId(reqModel.TableNamesId);
            slotModel = new EnhancementSlotModel();

            if (tableName == "EnhancementSlot")
                {
                slotModel.Initialize(reqModel.ApplytoId);
                treeName = EnhancementTreeModel.GetNameFromId(slotModel.EnhancementTreeId);
                }

            if (tableName == "Enhancement")
                {
                enhModel = new EnhancementModel();
                enhModel.Initialize(reqModel.ApplytoId);
                slotModel.Initialize(enhModel.EnhancementSlotId);
                treeName = EnhancementTreeModel.GetNameFromId(slotModel.EnhancementTreeId);
                }

            return treeName;
            }

        #endregion
        }
    }
