using System;
using System.Collections.Generic;
using System.Windows.Forms;

using DDOCharacterPlanner.Model;
using DDOCharacterPlanner.Screens.Controls;

namespace DDOCharacterPlanner.Screens.DataInput
    {
    public partial class DataInputEnhancementSlotScreenClass : Form
        {
        #region Enums
        private enum InputType
            {
            Active,
            APRequirement,
            SlotName,
            SlotDescription,
            SlotIcon,
            UseEnhancementInfo,
            EnhancementName,
            APCost,
            EnhancementIcon,
            RankDescription1,
            RankDescription2,
            RankDescription3,
            }

        #endregion

        #region Member Variables
        Guid SlotId;
        EnhancementSlotModel SlotModel;
        List<EnhancementModel> EnhancementModels;
        List<List<EnhancementRankModel>> RankModels;

        bool AllowChangeEvents;
        bool EnhancementRecordChanged;
        bool SlotRecordChanged;
        bool NewEnhancementRecord;

        int EnhancementIndexLoaded;

        private TabPage tpRank2;
        private TabPage tpRank3;
        private TabPage tpNewRank;

        #endregion

        #region Constructor
        public DataInputEnhancementSlotScreenClass()
            {
            InitializeComponent();
            }

        public DataInputEnhancementSlotScreenClass(Guid slotID)
            {
            InitializeComponent();

            SlotRecordChanged = false;
            EnhancementRecordChanged = false;
            SlotId = slotID;

            //Lets save some tab formatting for future use in the Ranks.
            tpRank2 = tabControl1.TabPages[1];
            tpRank3 = tabControl1.TabPages[2];
            tpNewRank = tabControl1.TabPages[3];

            //lets retrieve our Data for this Slot and its Enhancmenets
            GatherData();

            //Fill the Slot info in
            EnhancementSlotLabel.Text = "Enhancement Slot " + SlotModel.SlotIndex + " from ";
            PopulateSlotFields();

            //Fill the Enhancmeent Info in
            FillEnhancementIconList();
            EnhancementIconListControl.SelectedIndex = 0;
            PopulateEnhancementFields();

            //Fill the Enhancement Rank info in
            PopulateRankFields();

            //UpdateSlotIcon

            }

        #endregion

        #region Control Events
        private void AcceptButton_Click(object sender, EventArgs e)
            {
            SaveSlotRecord();

            }

        private void ActiveCheckbox_CheckedChanged(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                {
                CheckBoxChange(sender, InputType.Active);
                }
            }

        private void APCostNumUpDown_ValueChanged(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                NumUpDownChange(sender, InputType.APCost);
            }

        private void APRequirementNumUpDown_ValueChanged(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                NumUpDownChange(sender, InputType.APRequirement);
            }

        private void buttonCopyRank1_Click(object sender, EventArgs e)
            {
            CopyPreviousRank(1);
            }

        private void buttonCopyRank2_Click(object sender, EventArgs e)
            {
            CopyPreviousRank(2);
            }

        private void EnhancementAddButton_Click(object sender, EventArgs e)
            {
            if (DataHasChangedWarning() == false)
                return;

            AllowChangeEvents = false;

            //Lets add a new EnhancementModel to our Model list
            AddEnhancementModel();
            EnhancementIconListControl.Add();
            EnhancementIconListControl.SelectedIndex = EnhancementIconListControl.Count() - 1;
            AddRankModel(EnhancementIconListControl.SelectedIndex);
            PopulateEnhancementFields();

            PopulateRankFields();

            AllowChangeEvents = true;
            NewEnhancementRecord = true;
            EnhancementRecordChanged = true;
            }

        private void EnhancementDeleteButton_Click(object sender, EventArgs e)
            {
            int selection;
            int newSelection;
            byte selectedOrder;

            //If only one enhancement exists then exit as we don't wont' to delete the only enhancement.
            if (EnhancementModels.Count <= 1)
                return;

            selection = EnhancementIconListControl.SelectedIndex;
            newSelection = selection - 1;
            selectedOrder = EnhancementModels[selection].DisplayOrder;

            //Lets delete the selected enhancement from the database
            EnhancementModels[selection].Delete();

            //We need to update the display orders of any enhancements after this one
            for (int x = selection+1; x < EnhancementModels.Count; x++)
                {
                EnhancementModels[x].DisplayOrder = (byte)(x-1);
                EnhancementModels[x].Save();
                }

            //Now we need to repopulate our fields and iconlist
            GatherData();
            AllowChangeEvents = false;
            FillEnhancementIconList();
            //Now lets reset the index
            if (newSelection < 0)
                newSelection = 0;
            EnhancementIconListControl.SelectedIndex = newSelection;
            AllowChangeEvents = true;
            PopulateEnhancementFields();
            PopulateRankFields();

            }

        private void EnhancementIconBrowseButton_Click(object sender, EventArgs e)
            {
            string fileName;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Ping Files (*.png)|*.png";
            fileDialog.InitialDirectory = Application.StartupPath + "\\Graphics\\Enhancements\\";
            if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                fileName = fileDialog.SafeFileName;
                //we only want the file name, not the extension
                fileName = fileName.Replace(".png", "");
                EnhancementIconTextBox.Text = fileName;

                //lets trigger our change event for the FileNameInputBox
                TextBoxChange(sender, InputType.EnhancementIcon);
                }
            }

        private void EnhancementIconListControl_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                {
                if (EnhancementIconListControl.SelectedIndex == -1)
                    return;
                if (DataHasChangedWarning() == false)
                    return;
                ChangeEnhancementRecord(EnhancementIconListControl.SelectedIndex);
                EnhancementNameTextBox.Focus();
                }
            }

        private void EnhancementIconTextBox_Leave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.EnhancementIcon);
            }

        private void EnhancementNameTextBox_Leave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.EnhancementName);
            }

        private void EnhancementUpdateButton_Click(object sender, EventArgs e)
            {
            if (HasDataChanged() == false)
            //if (EnhancementRecordChanged == false)
                return;

            //Lets save our Enhancement Changes
            SaveRecord();

            //reset our flags
            EnhancementRecordChanged = false;
            NewEnhancementRecord = false;
            }

        private void OptionalCheckbox_CheckedChanged(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                {
                CheckBoxChange(sender, InputType.UseEnhancementInfo);
                }
            }

        private void RankDescriptionHE1_Leave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.RankDescription1);
            }

        private void RankDescriptionHE2_Leave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.RankDescription2);
            }

        private void RankDescriptionHE3_Leave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.RankDescription3);
            }

        private void SlotDescriptionHTMLEditor_Leave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.SlotDescription);
            }

        private void SlotIconBrowseButton_Click(object sender, EventArgs e)
            {
            string fileName;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Ping Files (*.png)|*.png";
            fileDialog.InitialDirectory = Application.StartupPath + "\\Graphics\\Enhancements\\";
            if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                fileName = fileDialog.SafeFileName;
                //we only want the file name, not the extension
                fileName = fileName.Replace(".png", "");
                SlotIconTextBox.Text = fileName;

                //lets trigger our change event for the FileNameInputBox
                TextBoxChange(sender, InputType.SlotIcon);
                }
            }

        private void SlotIconTextBox_Leave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.SlotIcon);
            }

        private void SlotNameTextBox_Leave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.SlotName);
            }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
            {
            for (int i = 0; i < tabControl1.TabCount; i++)
                if (tabControl1.GetTabRect(i).Contains(e.Location))
                    {
                    if (tabControl1.TabPages[i] == tpNewRank)
                        {
                        //we need to add a new rank model for this tab
                        AddRankModel(EnhancementIconListControl.SelectedIndex);
                        if (i == 1)
                            {
                            //tabControl1.TabPages.Insert(i, tpRank2);
                            //tabControl1.TabPages.Add(tpRank2);
                            tabControl1.TabPages.Insert(i, tpRank2);
                            tabControl1.SelectedTab = tpRank2;
                            RankDescriptionHE2.Text = "test2";
                            RankRequirementsRP2.Clear();
                            RankRequirementsRP2.RecordId = RankModels[EnhancementIconListControl.SelectedIndex][1].Id;
                            RankRequirementsRP2.Initialize();
                            RankModifiersMP2.Clear();
                            RankModifiersMP2.RecordId = RankModels[EnhancementIconListControl.SelectedIndex][1].Id;
                            RankModifiersMP2.Initialize();
                            }
                        if (i == 2)
                            {
                            tabControl1.TabPages.Insert(i, tpRank3);
                            tabControl1.TabPages.Remove(tpNewRank);
                            tabControl1.SelectedTab = tpRank3;
                            RankDescriptionHE3.Text = "Test3";
                            RankRequirementsRP3.Clear();
                            RankRequirementsRP3.RecordId = RankModels[EnhancementIconListControl.SelectedIndex][2].Id;
                            RankRequirementsRP3.Initialize();
                            RankModifiersMP3.Clear();
                            RankModifiersMP3.RecordId = RankModels[EnhancementIconListControl.SelectedIndex][2].Id;
                            RankModifiersMP3.Initialize();
                            }
                        
                        }
                    
                    }
            }

        #endregion

        #region Form Events

        #endregion

        #region Private Members
        private void AddEnhancementModel()
            {
            EnhancementModel tempEnhancementModel;
            int order;

            order = EnhancementModels.Count;

            tempEnhancementModel = new EnhancementModel();
            tempEnhancementModel.EnhancementSlotId = SlotId;
            tempEnhancementModel.Name = "Need More Info!!";
            tempEnhancementModel.DisplayOrder = (byte)order;

            EnhancementModels.Add(tempEnhancementModel);
            }

        private void AddRankModel(int enhancementIndex)
            {
            EnhancementRankModel tempRankModel;
            int rankCount;

            if (RankModels.Count >= enhancementIndex)
                rankCount = 0;
            else
                rankCount = RankModels[enhancementIndex].Count;

            tempRankModel = new EnhancementRankModel();
            tempRankModel.EnhancementId = EnhancementModels[enhancementIndex].Id;
            tempRankModel.Description = "Enter description here";
            tempRankModel.Rank = (byte)(rankCount + 1);

            if (RankModels.Count == enhancementIndex)
                {
                List<EnhancementRankModel> sublist = new List<EnhancementRankModel>();
                sublist.Add(tempRankModel);
                RankModels.Add(sublist);
                }
             
            else
                RankModels[enhancementIndex].Add(tempRankModel);
            }

        private void ChangeEnhancementRecord(int selectedIndex)
            {
            AllowChangeEvents = false;
            
            //Update the Enhancement Record
            PopulateEnhancementFields();

            //Update the Enhancement Rank Record(s)
            PopulateRankFields();

            AllowChangeEvents = true;
            EnhancementRecordChanged = false;
            }

        private void CheckBoxChange(object sender, InputType type)
            {
            bool boxChecked;
            
            switch (type)
                {
                case InputType.UseEnhancementInfo:
                        {
                        boxChecked = OptionalCheckBox.Checked;
                        
                        if (boxChecked == SlotModel.UseEnhancementInfo)
                            {
                            SlotModel.UseEnhancementInfo = !boxChecked;
                            SlotRecordChanged = true;
                            }
                        SlotNameTextBox.Enabled = boxChecked;
                        SlotIconTextBox.Enabled = boxChecked;
                        SlotDescriptionHtmlEditor.Enabled = boxChecked;
                        SlotIconBrowseButton.Enabled = boxChecked;
                        break;
                        }
                case InputType.Active:
                        {
                        boxChecked = ActiveCheckBox.Checked;
                        if (boxChecked != SlotModel.Active)
                            {
                            SlotModel.Active = boxChecked;
                            SlotRecordChanged = true;
                            }
                        if (boxChecked)
                            slotControl1.SlotType = SlotControl.SCType.Active;
                        else
                            slotControl1.SlotType = SlotControl.SCType.Passive;

                        break;
                        }
                }
            }

        private void CopyPreviousRank(int previousRank)
            {
            List<EnhancementRankRequirementModel> newRankRequirements;
            List<EnhancementRankModifierModel> newRankModifiers;
            List<EnhancementRankRequirementModel> deleteRankRequirements;
            List<EnhancementRankModifierModel> deleteRankModifiers;
            
            newRankRequirements = new List<EnhancementRankRequirementModel>();
            newRankModifiers = new List<EnhancementRankModifierModel>();
            deleteRankRequirements = new List<EnhancementRankRequirementModel>();
            deleteRankModifiers = new List<EnhancementRankModifierModel>();

            //We need to save any changes to the enhancement record before doing any copying.
            if (HasDataChanged() == true)
                {
                SaveSlotRecord();
                SaveRecord();
                }

            //Lets delete the records for the current rank requirements and modifiers.
            deleteRankRequirements = EnhancementRankRequirementModel.GetAll(RankModels[EnhancementIndexLoaded][previousRank].Id);
            foreach (EnhancementRankRequirementModel deleteRequirement in deleteRankRequirements)
                deleteRequirement.Delete();
            deleteRankModifiers = EnhancementRankModifierModel.GetAll(RankModels[EnhancementIndexLoaded][previousRank].Id);
            foreach (EnhancementRankModifierModel deleteModifier in deleteRankModifiers)
                deleteModifier.Delete();

            //Lets make a copy of the previous rank requirements and modifiers now and save them to the database.
            newRankRequirements = EnhancementRankRequirementModel.GetAll(RankModels[EnhancementIndexLoaded][previousRank - 1].Id);
            foreach (EnhancementRankRequirementModel rankRequirement in newRankRequirements)
                {
                rankRequirement.ConvertToNewRecord();
                rankRequirement.EnhancementRankId = RankModels[EnhancementIndexLoaded][previousRank].Id;
                rankRequirement.Save();
                }
            newRankModifiers = EnhancementRankModifierModel.GetAll(RankModels[EnhancementIndexLoaded][previousRank - 1].Id);
            foreach (EnhancementRankModifierModel rankModifier in newRankModifiers)
                {
                rankModifier.ConvertToNewRecord();
                rankModifier.EnhancementRankId = RankModels[EnhancementIndexLoaded][previousRank].Id;
                rankModifier.Save();
                }

            //Ok, now that new records are saved, lets Update the screen with the changes and also update the Description boxes.
            switch (previousRank)
                {
                case 1:
                        {
                        RankRequirementsRP2.Clear();
                        RankRequirementsRP2.RecordId = RankModels[EnhancementIndexLoaded][previousRank].Id;
                        RankRequirementsRP2.Initialize();
                        RankModifiersMP2.Clear();
                        RankModifiersMP2.RecordId = RankModels[EnhancementIndexLoaded][previousRank].Id;
                        RankModifiersMP2.Initialize();
                        
                        RankModels[EnhancementIconListControl.SelectedIndex][1].Description = RankDescriptionHE1.Text;
                        RankDescriptionHE2.Text = RankDescriptionHE1.Text  ;
                        EnhancementRecordChanged = true;
                        break;
                        }
                case 2:
                        {
                        RankRequirementsRP3.Clear();
                        RankRequirementsRP3.RecordId = RankModels[EnhancementIndexLoaded][previousRank].Id;
                        RankRequirementsRP3.Initialize();
                        RankModifiersMP3.Clear();
                        RankModifiersMP3.RecordId = RankModels[EnhancementIndexLoaded][previousRank].Id;
                        RankModifiersMP3.Initialize();
                        
                        RankModels[EnhancementIconListControl.SelectedIndex][2].Description = RankDescriptionHE2.Text;
                        RankDescriptionHE3.Text = RankDescriptionHE2.Text;
                        EnhancementRecordChanged = true;
                        break;
                        }
                }

            //lets save the enhancement record again to make sure changes hold. this may be redundant but it doesn't hurt :)
            SaveRecord();

            }

        private bool DataHasChangedWarning()
            {
            DialogResult result;

            if (HasDataChanged() == false)
                return true;

            result = MessageBox.Show("Warninig: Data has been modified! Do you want to save your changes?", "Warning!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Cancel)
                return false;
            else if (result == DialogResult.Yes)
                {
                SaveRecord();
                return true;
                }
            else
                //user answered No, I guess we really don't care about the changed data!
                return true;
            }

        private void FillEnhancementIconList()
            {
            int index;
            string iconName;

            EnhancementIconListControl.Clear();
            foreach (EnhancementModel model in EnhancementModels)
                {
                EnhancementIconListControl.Add();
                index = EnhancementIconListControl.Count() - 1;
                iconName = "Enhancements\\" + model.Icon;
                EnhancementIconListControl.SetIconControlImage(index, iconName);
                }
            }

        private void GatherData()
            {
            
            //Enhancment Slot Data
            SlotModel = new EnhancementSlotModel();
            SlotModel.Initialize(SlotId);

            //Enhancement Data
            EnhancementModels = EnhancementModel.GetAll(SlotId);
            if (EnhancementModels.Count == 0)
                {
                //we need to add an enhancement as one was never assigned and all slots should have at least 1 enhancement.
                AddEnhancementModel();
                }

            //Enhancement Rank Data
            RankModels = new List<List<EnhancementRankModel>>();
            foreach (EnhancementModel model in EnhancementModels)
                {
                List<EnhancementRankModel> sublist = new List<EnhancementRankModel>();
                sublist = EnhancementRankModel.GetAll(model.Id);
                RankModels.Add(sublist);
                if (RankModels[RankModels.Count - 1].Count == 0)
                    AddRankModel(RankModels.Count -1);
                }
            
            }

        private bool HasDataChanged()
            {
            if (SlotRecordChanged == true)
                return true;

            if (EnhancementRecordChanged == true)
                return true;

            if (RankRequirementsRP1.HaveRecordsChanged() == true || RankRequirementsRP2.HaveRecordsChanged() == true || RankRequirementsRP2.HaveRecordsChanged() == true)
                return true;

            if (RankModifiersMP1.HaveRecordsChanged() == true || RankModifiersMP2.HaveRecordsChanged() == true || RankModifiersMP3.HaveRecordsChanged() == true)
                return true;

            //no data has changed, so return false.
            return false;
            }

        private void NumUpDownChange(object sender, InputType type)
            {
            decimal newValue;
            int enhancementIndex;

            enhancementIndex = EnhancementIconListControl.SelectedIndex;

            switch (type)
                {
                case InputType.APRequirement:
                        {
                        newValue = APRequirementNumUpDown.Value;
                        if (newValue != SlotModel.APRequirement)
                            {
                            SlotModel.APRequirement = (int)newValue;
                            SlotRecordChanged = true;
                            }
                        break;
                        }
                case InputType.APCost:
                        {
                        newValue = APCostNumUpDown.Value;
                        if (newValue != EnhancementModels[enhancementIndex].APCost)
                            {
                            EnhancementModels[enhancementIndex].APCost = (int)newValue;
                            EnhancementRecordChanged = true;
                            }
                        break;
                        }
                }
            }

        private void PopulateEnhancementFields()
            {
            int index;

            AllowChangeEvents = false;
            index = EnhancementIconListControl.SelectedIndex;

            EnhancementNameTextBox.Text = EnhancementModels[index].Name;
            APCostNumUpDown.Value = (decimal)EnhancementModels[index].APCost;
            EnhancementIconTextBox.Text = EnhancementModels[index].Icon;

            EnhancementIndexLoaded = index;
            AllowChangeEvents = true;
            }

        private void PopulateRankFields()
            {
            int rankCount;
            int enhancementIndex;

            enhancementIndex = EnhancementIconListControl.SelectedIndex;
            rankCount = RankModels[enhancementIndex].Count;

            //lets reset what tabs are shown based on number of ranks
            tabControl1.TabPages.Remove(tpRank2);
            tabControl1.TabPages.Remove(tpRank3);
            tabControl1.TabPages.Remove(tpNewRank);
            

            //Rank 1 data
            RankDescriptionHE1.Text = RankModels[enhancementIndex][0].Description;
            RankRequirementsRP1.Clear();
            RankRequirementsRP1.RecordId = RankModels[enhancementIndex][0].Id;
            RankRequirementsRP1.Initialize();
            RankModifiersMP1.Clear();
            RankModifiersMP1.RecordId = RankModels[enhancementIndex][0].Id;
            RankModifiersMP1.Initialize();

            //Rank 2 data
            if (rankCount > 1)
                {
                tabControl1.TabPages.Add(tpRank2);
                RankDescriptionHE2.Text = RankModels[enhancementIndex][1].Description;
                RankRequirementsRP2.Clear();
                RankRequirementsRP2.RecordId = RankModels[enhancementIndex][1].Id;
                RankRequirementsRP2.Initialize();
                RankModifiersMP2.Clear();
                RankModifiersMP2.RecordId = RankModels[enhancementIndex][1].Id;
                RankModifiersMP2.Initialize();
                }

            //Rank 3 data
            if (rankCount == 3)
                {
                tabControl1.TabPages.Add(tpRank3);
                RankDescriptionHE3.Text = RankModels[enhancementIndex][2].Description;
                RankRequirementsRP3.Clear();
                RankRequirementsRP3.RecordId = RankModels[enhancementIndex][2].Id;
                RankRequirementsRP3.Initialize();
                RankModifiersMP3.Clear();
                RankModifiersMP3.RecordId = RankModels[enhancementIndex][2].Id;
                RankModifiersMP3.Initialize();
                }
            if (rankCount < 3)
                tabControl1.TabPages.Add(tpNewRank);
            }

        private void PopulateSlotFields()
            {
            AllowChangeEvents = false;

            ActiveCheckBox.Checked = SlotModel.Active;
            if (SlotModel.Active == true)
                slotControl1.SlotType = SlotControl.SCType.Active;
            else
                slotControl1.SlotType = SlotControl.SCType.Passive;
            APRequirementNumUpDown.Value = SlotModel.APRequirement;

            //Optional Area
            OptionalCheckBox.Checked = !SlotModel.UseEnhancementInfo;
            SlotNameTextBox.Text = SlotModel.Name;
            SlotIconTextBox.Text = SlotModel.Icon;
            SlotDescriptionHtmlEditor.Text = SlotModel.Description;

            if (SlotModel.UseEnhancementInfo == true)
                {
                SlotNameTextBox.Enabled = false;
                SlotIconTextBox.Enabled = false;
                SlotDescriptionHtmlEditor.Enabled = false;
                SlotIconBrowseButton.Enabled = false;
                slotControl1.SetIcon("Enhancements\\" + EnhancementModels[0].Icon);
                }
            else
                {
                SlotNameTextBox.Enabled = true;
                SlotIconTextBox.Enabled = true;
                SlotDescriptionHtmlEditor.Enabled = true;
                SlotIconBrowseButton.Enabled = true;
                slotControl1.SetIcon("Enhancements\\" + SlotIconTextBox.Text);
                }

            AllowChangeEvents = true;
            }

        private void SaveRecord()
            {
            if (EnhancementRecordChanged == true || HasDataChanged() == true)
                {
                //Update the Enhancement Record
                if (NewEnhancementRecord == true)
                    EnhancementModels[EnhancementIndexLoaded].EnhancementSlotId = SlotModel.Id;

                EnhancementModels[EnhancementIndexLoaded].Save();

                //Update the Enhancement Rank Record(s)
                for (int i = 0; i < RankModels[EnhancementIndexLoaded].Count; i++)
                    {
                    RankModels[EnhancementIndexLoaded][i].EnhancementId = EnhancementModels[EnhancementIndexLoaded].Id;
                    RankModels[EnhancementIndexLoaded][i].Rank = (byte)(i + 1);
                    RankModels[EnhancementIndexLoaded][i].Save();
                    switch (i)
                        {
                        case 0:
                                {
                                if (RankRequirementsRP1.HaveRecordsChanged() == true)
                                    {
                                    RankRequirementsRP1.RecordId = RankModels[EnhancementIndexLoaded][i].Id;
                                    RankRequirementsRP1.SaveRecords();
                                    }
                                if (RankModifiersMP1.HaveRecordsChanged() == true)
                                    {
                                    RankModifiersMP1.RecordId = RankModels[EnhancementIndexLoaded][i].Id;
                                    RankModifiersMP1.SaveRecords();
                                    }
                                break;
                                }
                        case 1:
                                {
                                if (RankRequirementsRP2.HaveRecordsChanged() == true)
                                    {
                                    RankRequirementsRP2.RecordId = RankModels[EnhancementIndexLoaded][i].Id;
                                    RankRequirementsRP2.SaveRecords();
                                    }
                                if (RankModifiersMP2.HaveRecordsChanged() == true)
                                    {
                                    RankModifiersMP2.RecordId = RankModels[EnhancementIndexLoaded][i].Id;
                                    RankModifiersMP2.SaveRecords();
                                    }
                                break;
                                }
                        case 2:
                                {
                                if (RankRequirementsRP3.HaveRecordsChanged() == true)
                                    {
                                    RankRequirementsRP3.RecordId = RankModels[EnhancementIndexLoaded][i].Id;
                                    RankRequirementsRP3.SaveRecords();
                                    }
                                if (RankModifiersMP3.HaveRecordsChanged() == true)
                                    {
                                    RankModifiersMP3.RecordId = RankModels[EnhancementIndexLoaded][i].Id;
                                    RankModifiersMP3.SaveRecords();
                                    }
                                break;
                                }
                        }
                    }

                }


            }

        private void SaveSlotRecord()
            {
            if (SlotRecordChanged == true)
                SlotModel.Save();
            }

        private void TextBoxChange(object sender, InputType type)
            {
            string newStringValue;
            int enhancementIndex;

            enhancementIndex = EnhancementIconListControl.SelectedIndex;

            switch (type)
                {
                case InputType.SlotName:
                        {
                        newStringValue = SlotNameTextBox.Text;
                        if (newStringValue != SlotModel.Name)
                            {
                            SlotModel.Name = newStringValue;
                            SlotRecordChanged = true;
                            }
                        break;
                        }
                case InputType.SlotIcon:
                        {
                        newStringValue = SlotIconTextBox.Text;
                        if (newStringValue != SlotModel.Icon)
                            {
                            SlotModel.Icon = newStringValue;
                            SlotRecordChanged = true;
                            UpdateSlotIcon(newStringValue);
                            }
                        break;
                        }
                case InputType.SlotDescription:
                        {
                        newStringValue = SlotDescriptionHtmlEditor.Text;
                        if (newStringValue != SlotModel.Description)
                            {
                            SlotModel.Description = newStringValue;
                            SlotRecordChanged = true;
                            }
                        break;
                        }
                case InputType.EnhancementName:
                        {
                        newStringValue = EnhancementNameTextBox.Text;
                        if (newStringValue != EnhancementModels[enhancementIndex].Name)
                            {
                            EnhancementModels[enhancementIndex].Name = newStringValue;
                            EnhancementRecordChanged = true;
                            }
                        break;
                        }
                case InputType.EnhancementIcon:
                        {
                        newStringValue = EnhancementIconTextBox.Text;
                        if (newStringValue != EnhancementModels[enhancementIndex].Icon)
                            {
                            EnhancementModels[enhancementIndex].Icon = newStringValue;
                            EnhancementRecordChanged = true;
                            EnhancementIconListControl.SetIconControlImage(enhancementIndex, "Enhancements\\" + newStringValue);
                            //Lets see if we need to update the slot icon with this enhancement
                            if (OptionalCheckBox.Checked == false)
                                {
                                if (enhancementIndex == 0)
                                    UpdateSlotIcon(newStringValue);
                                }
                            }
                            break;
                        }
                case InputType.RankDescription1:
                        {
                        newStringValue = RankDescriptionHE1.Text;
                        if (newStringValue != RankModels[EnhancementIconListControl.SelectedIndex][0].Description)
                            {
                            RankModels[EnhancementIconListControl.SelectedIndex][0].Description = newStringValue;
                            EnhancementRecordChanged = true;
                            }
                        break;
                        }
                case InputType.RankDescription2:
                        {
                        newStringValue = RankDescriptionHE2.Text;
                        if (newStringValue != RankModels[EnhancementIconListControl.SelectedIndex][1].Description)
                            {
                            RankModels[EnhancementIconListControl.SelectedIndex][1].Description = newStringValue;
                            EnhancementRecordChanged = true;
                            }
                        break;
                        }
                case InputType.RankDescription3:
                        {
                        newStringValue = RankDescriptionHE3.Text;
                        if (newStringValue != RankModels[EnhancementIconListControl.SelectedIndex][2].Description)
                            {
                            RankModels[EnhancementIconListControl.SelectedIndex][2].Description = newStringValue;
                            EnhancementRecordChanged = true;
                            }
                        break;
                        }
                }

            }

        private void UpdateSlotIcon(string iconName)
            {
            slotControl1.SetIcon("Enhancements\\" + iconName);
            }
        #endregion

        #region Public Members

        #endregion
        }
    }
