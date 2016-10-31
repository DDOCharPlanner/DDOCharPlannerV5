using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using DDOCharacterPlanner.Model;

namespace DDOCharacterPlanner.Screens.DataInput
    {
    public partial class NewRequirementDialogClass : Form
        {
        #region Memmber Variables
        private List<string> CategoryNames;
        private List<string> ApplyToNames;
        private List<String> TreeNames;
        private int DefaultWidth;
        private int DefaultHeight;
        private Guid NewRequirementId;
        #endregion

        #region Properties
        public Guid RequirementId
            {
            get { return NewRequirementId; }
            }
        #endregion

        #region Constructors
        public NewRequirementDialogClass()
            {
            InitializeComponent();
            DefaultWidth = 240;
            DefaultHeight = 240;
            //Lets hide these controls until the user needs them
            TreeLabel.Visible = false;
            TreeComboBox.Visible = false;
            SlotLabel.Visible = false;
            SlotComboBox.Visible = false;
            //Resize our form now
            this.Size = new Size(DefaultWidth, DefaultHeight);
            //lets create our Category List and add it to the CategoryComboBox
            CategoryNames = TableNamesModel.GetNamesByRequirementUsage(true);
            CategoryNames.Remove("Character");
            foreach (string name in CategoryNames)
                CategoryComboBox.Items.Add(name);
            ApplyToNames = new List<string>();
            TreeNames = new List<string>();
            this.NewRequirementId = Guid.Empty;
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
            ApplyToComboBox.Items.Clear();
            TreeComboBox.Items.Clear();
            //Lets set the default size of our form
            this.Size = new Size(DefaultWidth, DefaultHeight);
            //Hide our optional controls
            TreeLabel.Visible = false;
            TreeComboBox.Visible = false;
            SlotLabel.Visible = false;
            SlotComboBox.Visible = false;

            if (category == "Ability")
                {
                ApplyToNames = AbilityModel.GetNames();
                ApplyToLabel.Text = "Select an Ability";
                }

            else if (category == "Attribute")
                {
                ApplyToNames = AttributeModel.GetNames();
                ApplyToLabel.Text = "Select an Attribute";
                }

            else if (category == "Class")
                {
                ApplyToNames = ClassModel.GetNames();
                ApplyToLabel.Text = "Select a Class";
                }

            else if (category == "Enhancement")
                {
                //Lets resize our form to make room for other controls
                this.Size = new Size(DefaultWidth+100, DefaultHeight + 94);
                TreeLabel.Visible = true;
                TreeComboBox.Visible = true;
                SlotLabel.Visible = true;
                SlotComboBox.Visible = true;
                TreeNames = EnhancementTreeModel.GetNames();
                foreach (string name in TreeNames)
                    TreeComboBox.Items.Add(name);
                ApplyToLabel.Text = "Select an Enhancement";
                UpdateNameField();
                return;
               
                }

            else if (category == "EnhancementSlot")
                {
                //Lets resize our form to make room for other controls
                this.Size = new Size(DefaultWidth+100, DefaultHeight + 42);
                TreeLabel.Visible = true;
                TreeComboBox.Visible = true;
                TreeNames = EnhancementTreeModel.GetNames();
                foreach (string name in TreeNames)
                    TreeComboBox.Items.Add(name);
                ApplyToLabel.Text = "Select An Enhancement Slot";
                UpdateNameField();
                return;
                
                }
            else if (category == "Feat")
                {
                ApplyToNames = FeatModel.GetNames();
                ApplyToLabel.Text = "Select a Feat";
                }

            else if (category == "Race")
                {
                ApplyToNames = RaceModel.GetNames();
                ApplyToLabel.Text = "Select a Race";
                }

            else if (category == "Skill")
                {
                ApplyToNames = SkillModel.GetNames();
                ApplyToLabel.Text = "Select a Skill";
                }

            else
                {
                Debug.WriteLine("Error: No category exists for the one selected. NewRequirementDialogClass : CategoryComboBox_SelectedIndexChanged()");
                return;
                }

            foreach (string name in ApplyToNames)
                ApplyToComboBox.Items.Add(name);

            UpdateNameField();
            }

        private void NameTextBoxTextChanged(object sender, EventArgs e)
            {
            if (ApplyToComboBox.SelectedIndex == -1)
                {
                NameBorderPanel.BackColor = Color.Red;
                OkButton.Enabled = false;
                return;
                }

            if (RequirementModel.GetIdFromName(NameTextBox.Text.ToString()) == Guid.Empty)
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

        private void OKButton_Click(object sender, EventArgs e)
            {
            AddNewRequirementRecord();
            Close();
            }

        private void TreeComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            Guid treeId;
            List<EnhancementSlotModel> slotModels;

            if (e.ToString() != "")
                {
                treeId = EnhancementTreeModel.GetIdFromTreeName(TreeComboBox.SelectedItem.ToString());
                //Lets pull slot data for the tree Selected
                slotModels = EnhancementSlotModel.GetAll(treeId);

                if (CategoryComboBox.SelectedItem.ToString() == "Enhancement")
                    {
                    SlotComboBox.Items.Clear();
                    foreach (EnhancementSlotModel model in slotModels)
                        SlotComboBox.Items.Add("Slot " + model.SlotIndex.ToString() + ": " + GetSlotName(model));
                    ApplyToComboBox.Items.Clear();
                    }
                else
                    {
                    ApplyToComboBox.Items.Clear();
                    foreach (EnhancementSlotModel model in slotModels)
                        ApplyToComboBox.Items.Add("Slot " + model.SlotIndex.ToString() + ": " + GetSlotName(model));
                    }
                UpdateNameField();
                }

            }

        private void SlotComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
            List<EnhancementModel> enhancementModels;
            Guid slotId;
            Guid treeId;

            if (e.ToString() != "")
                {
                treeId = EnhancementTreeModel.GetIdFromTreeName(TreeComboBox.SelectedItem.ToString());
                slotId = EnhancementSlotModel.GetIdFromTreeIdandSlotIndex(treeId, GetSlotIndex(SlotComboBox.SelectedItem.ToString()));
                //lets pull the enhancement data for the selected slot
                enhancementModels = EnhancementModel.GetAll(slotId);

                ApplyToComboBox.Items.Clear();
                foreach (EnhancementModel model in enhancementModels)
                    ApplyToComboBox.Items.Add("Pos " + model.DisplayOrder.ToString() + ": " + model.Name);

                UpdateNameField();
                }
            }

        #endregion

        #region Private Members
        private void AddNewRequirementRecord()
            {
            RequirementModel model;
            string categoryName;
            string applyToName;
            string treeName;
            Guid treeId;
            Guid slotId;
            Guid enhancementId;

            treeName = "";
            model = new RequirementModel();
            categoryName = CategoryComboBox.SelectedItem.ToString();
            applyToName = ApplyToComboBox.SelectedItem.ToString();
            if (categoryName == "Enhancement" || categoryName == "EnhancementSlot")
                treeName = TreeComboBox.SelectedItem.ToString();
            
            model.Initialize(Guid.Empty);
            model.TableNamesId = TableNamesModel.GetIdFromTableName(categoryName);
            if (categoryName == "Ability")
                model.ApplytoId = AbilityModel.GetIdFromName(applyToName);
            if (categoryName == "Attribute")
                model.ApplytoId = AttributeModel.GetIdFromName(applyToName);
            if (categoryName == "Class")
                model.ApplytoId = ClassModel.GetIdFromName(applyToName);
            if (categoryName == "Enhancement")
                {
                treeId = EnhancementTreeModel.GetIdFromTreeName(treeName);
                slotId = EnhancementSlotModel.GetIdFromTreeIdandSlotIndex(treeId, GetSlotIndex(SlotComboBox.SelectedItem.ToString()));
                enhancementId = EnhancementModel.GetIdFromSlotIdandDisplayOrder(slotId, GetDisplayOrder(ApplyToComboBox.SelectedItem.ToString()));
                model.ApplytoId = enhancementId;
                }
            if (categoryName == "EnhancementSlot")
                {
                treeId = EnhancementTreeModel.GetIdFromTreeName(treeName);
                slotId = EnhancementSlotModel.GetIdFromTreeIdandSlotIndex(treeId, GetSlotIndex(ApplyToComboBox.SelectedItem.ToString()));
                model.ApplytoId = slotId;
                }
            if (categoryName == "Feat")
                model.ApplytoId = FeatModel.GetIdFromName(applyToName);
            if (categoryName == "Race")
                model.ApplytoId = RaceModel.GetIdFromName(applyToName);
            if (categoryName == "Skill")
                model.ApplytoId = SkillModel.GetIdFromName(applyToName);

            model.Name = NameTextBox.Text;
            model.Save();
            NewRequirementId = model.Id;
            
            }

        private byte GetDisplayOrder(string selectedEnhancementName)
            {
            byte index = 0;
            string displayOrderString;
            string tempName;
            int startLoc = 0;

            tempName = selectedEnhancementName.Remove(0, 3);
            startLoc = tempName.IndexOf(": ");
            displayOrderString = tempName.Remove(startLoc);
            index = Byte.Parse(displayOrderString);
            return index;
            }

        private int GetSlotIndex(string selectedSlotName)
            {
            int index = -1;
            string slotIndexString;
            string tempName;
            int startloc = 0;

            tempName = selectedSlotName.Remove(0, 5);
            startloc = tempName.IndexOf(": ");
            slotIndexString = tempName.Remove(startloc);
            index = Int32.Parse(slotIndexString);
            return index;
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

        private void UpdateNameField()
            {
            string name;

            name = "";
            if (CategoryComboBox.SelectedItem != null)
                name = CategoryComboBox.SelectedItem.ToString();

            if (name == "Enhancement")
                {
                if (ApplyToComboBox.SelectedItem !=null)
                    name += ": " + ApplyToComboBox.SelectedItem.ToString();
                if (TreeComboBox.SelectedItem != null)
                    name += " (T:" + TreeComboBox.SelectedItem.ToString();
                if (SlotComboBox.SelectedItem !=null)
                    name += ", S:" + SlotComboBox.SelectedItem.ToString();
                if (SlotComboBox.SelectedItem != null || TreeComboBox.SelectedItem != null)
                    name += ")"; 
                }

            else if (name == "EnhancementSlot")
                {
                if (ApplyToComboBox.SelectedItem !=null)
                    name += ": " + ApplyToComboBox.SelectedItem.ToString();
                if (TreeComboBox.SelectedItem != null)
                    name += " (T:" + TreeComboBox.SelectedItem.ToString() + ")";
                }
            else
                {
                if (ApplyToComboBox.SelectedItem != null)
                    name += ": " + ApplyToComboBox.SelectedItem.ToString();
                }

            NameTextBox.Text = name.ToString();
            }

        #endregion
        }
    }
