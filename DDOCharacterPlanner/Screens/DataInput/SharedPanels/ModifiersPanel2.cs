using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using DDOCharacterPlanner.Model;
using DDOCharacterPlanner.Screens;

namespace DDOCharacterPlanner.Screens.DataInput
    {
    public partial class ModifiersPanel2 : UserControl
        {
        #region Enums
        public enum ScreenType
            {
            DestinyRank,
            EnhancementRank,
            Feat,
            };

        #endregion

        #region Member Variables
        private ScreenType MainScreen;
        private Guid MainRecordId;
        int ModelRecordCount;

        //Model Collections
        //private List<DestinyRankModel> DestinyRankModifierModels;
        private List<EnhancementRankModifierModel> EnhancementRankModifierModels;
        private List<FeatModifierModel> FeatModifierModels;
        
        //Tracking lists for model changes
        private List<bool> RecordsChanged;
        private List<bool> RecordsDeleted;
        private List<int> ListViewModelIndex;

        #endregion

        #region Properties
        [Category("_MP Properties")]
        public ScreenType ParentScreen
            {
            get { return MainScreen; }
            set { MainScreen = value; }
            }

        [Category("_MP Properties")]
        public Color MPBackColor
            {
            get {return ListViewModifiers.BackColor; }
            set { ListViewModifiers.BackColor = value; }
            }

        [Category("_MP Properties")]
        public Color MPForeColor
            {
            get { return ListViewModifiers.ForeColor; }
            set { ListViewModifiers.ForeColor = value; }
            }
        
        [Category("_MP Properties")]
        public Font MPFont
            {
            get { return ListViewModifiers.Font; }
            set { ListViewModifiers.Font = value; }
            }

        [Category("_MP Properties")]
        public Guid RecordId
            {
            get { return MainRecordId; }
            set { MainRecordId = value; }
            }

        [Category("_MP Properties")]
        public string MPTitle
            {
            get { return LabelModifiers.Text; }
            set { LabelModifiers.Text = value; }
            }

        [Category("_MP Properties")]
        public Color MPTitleBackColor
            {
            get { return LabelModifiers.BackColor; }
            set { LabelModifiers.BackColor = value; }
            }

        [Category("_MP Properties")]
        public Color MPTitleForeColor
            {
            get { return LabelModifiers.ForeColor; }
            set { LabelModifiers.ForeColor = value; }
            }

        [Category("_MP Properties")]
        public Font MPTitleFont
            {
            get { return LabelModifiers.Font; }
            set { LabelModifiers.Font = value; }
            }

        #endregion

        #region Constructor
        public ModifiersPanel2()
            {
            InitializeComponent();

            //Lets set our intitial lists and models collections
            EnhancementRankModifierModels = new List<EnhancementRankModifierModel>();
            FeatModifierModels = new List<FeatModifierModel>();
            RecordsChanged = new List<bool>();
            RecordsDeleted = new List<bool>();
            ListViewModelIndex = new List<int>();

            }

        #endregion

        #region Control Events
        private void AddButton_Click(object sender, EventArgs e)
            {
            OpenEditDialog(true, 0);
            }

        private void DeleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
            {
            int modelIndex;

            if (ListViewModifiers.SelectedItems.Count == 0)
                return;
            modelIndex = ListViewModelIndex[ListViewModifiers.SelectedIndices[0]];
            DeleteRecord(modelIndex);
            }

        private void EditRecordToolStripMenuItem_Click(object sender, EventArgs e)
            {
            int modelIndex;

            if (ListViewModifiers.SelectedItems.Count == 0)
                return;
            modelIndex = ListViewModelIndex[ListViewModifiers.SelectedIndices[0]];

            OpenEditDialog(false, modelIndex);
            }

        private void ListViewModifiers_MouseClick(object sender, MouseEventArgs e)
            {
            ListView listView = sender as ListView;
            if (e.Button == MouseButtons.Right)
                {
                ListViewItem item = listView.GetItemAt(e.X, e.Y);
                if (item != null)
                    {
                    item.Selected = true;
                    ModifiersMenuStrip.Show(listView, e.Location);
                    }
                }
            }

        private void ListViewModifiers_MouseDoubleClick(object sender, MouseEventArgs e)
            {
            int modelIndex;

            if (ListViewModifiers.SelectedItems.Count == 0)
                return;
            modelIndex = ListViewModelIndex[ListViewModifiers.SelectedIndices[0]];

            OpenEditDialog(false, modelIndex);
            }

        #endregion

        #region Form Events
        private void ModifiersPanel2_Resize(object sender, EventArgs e)
            {
            ListViewModifiers.Columns[1].Width = (int)((ListViewModifiers.Width - 85) * .60);
            ListViewModifiers.Columns[2].Width = (int)((ListViewModifiers.Width - 85) * .40);
            }

        #endregion

        #region Private Members
        private void UpdateModifierRecord(bool addFlag, int modelIndex, Guid modifierId, byte modifierType, Guid modifierMethodId, Guid bonusTypeId, Guid pullFromId, double modifierValue,
            Guid requirementId, Guid stanceId, string comparison, double requirementValue)
            {
            int index;

            if (addFlag == true)
                index = RecordsChanged.Count;
            else
                index = modelIndex;

            switch (MainScreen)
                {
                case ScreenType.DestinyRank:
                        {
                        //TODO: Fill in once we have Destinies Setup.
                        break;
                        }
                case ScreenType.EnhancementRank:
                        {
                        if (addFlag == true)
                            EnhancementRankModifierModels.Add(new EnhancementRankModifierModel());
                        EnhancementRankModifierModels[index].EnhancementRankId = MainRecordId;
                        EnhancementRankModifierModels[index].ModifierId = modifierId;
                        EnhancementRankModifierModels[index].ModifierType = modifierType;
                        EnhancementRankModifierModels[index].ModifierMethodId = modifierMethodId;
                        EnhancementRankModifierModels[index].BonusTypeId = bonusTypeId;
                        EnhancementRankModifierModels[index].PullFromId = pullFromId;
                        EnhancementRankModifierModels[index].ModifierValue = modifierValue;
                        EnhancementRankModifierModels[index].RequirementId = requirementId;
                        EnhancementRankModifierModels[index].StanceId = stanceId;
                        EnhancementRankModifierModels[index].Comparison = comparison;
                        EnhancementRankModifierModels[index].RequirementValue = requirementValue;
                        break;
                        }
                case ScreenType.Feat:
                        {
                        if (addFlag == true)
                            FeatModifierModels.Add(new FeatModifierModel());
                        FeatModifierModels[index].FeatId = MainRecordId;
                        FeatModifierModels[index].ModifierId = modifierId;
                        FeatModifierModels[index].ModifierType = modifierType;
                        FeatModifierModels[index].ModifierMethodId = modifierMethodId;
                        FeatModifierModels[index].BonusTypeId = bonusTypeId;
                        FeatModifierModels[index].PullFromId = pullFromId;
                        FeatModifierModels[index].Value = modifierValue;
                        FeatModifierModels[index].RequirementId = requirementId;
                        FeatModifierModels[index].StanceId = stanceId;
                        FeatModifierModels[index].Comparison = comparison;
                        FeatModifierModels[index].RequirementValue = requirementValue;
                        break;
                        }
                }

            //Increment our ModelRecord Count if a new record
            if (addFlag == true)
                ModelRecordCount++;

            //add flag values to our record
            if (addFlag == true)
                {
                RecordsChanged.Add(true);
                RecordsDeleted.Add(false);
                }
            else
                {
                RecordsChanged[index] = true;
                }

            //lets refresh the listview with the new record
            FillModifierListBox();

            }

        private void DeleteRecord(int modelIndex)
            {
            //Mark model record for later deletion.
            RecordsDeleted[modelIndex] = true;
            //Lets repopulate the listboxes now to remove teh deleted record
            FillModifierListBox();
            }

        private void FillModifierListBox()
            {

            byte modifierType = 0;
            Guid modifierId = Guid.Empty;
            Guid bonustypeId = Guid.Empty;
            Guid pullFromId = Guid.Empty;
            Guid methodId = Guid.Empty;
            double modifierValue = 0;
            Guid requirementId = Guid.Empty;
            double requirementValue = 0;
            Guid stanceId = Guid.Empty;
            string comparison = "=";

            ListViewModelIndex.Clear();

            ListViewModifiers.BeginUpdate();
            ListViewModifiers.Items.Clear();

            
            for (int i = 0; i < ModelRecordCount; i++)
                {
                //Lets grab our data for this record
                switch (MainScreen)
                    {
                    case ScreenType.DestinyRank:
                            {
                            //TODO: Fill this in once we have destinies set up
                            break;
                            }
                    case ScreenType.EnhancementRank:
                            {
                            modifierType = EnhancementRankModifierModels[i].ModifierType;
                            methodId = EnhancementRankModifierModels[i].ModifierMethodId;
                            modifierId = EnhancementRankModifierModels[i].ModifierId;
                            bonustypeId = EnhancementRankModifierModels[i].BonusTypeId;
                            pullFromId = EnhancementRankModifierModels[i].PullFromId;
                            modifierValue = EnhancementRankModifierModels[i].ModifierValue;
                            requirementId = EnhancementRankModifierModels[i].RequirementId;
                            requirementValue = EnhancementRankModifierModels[i].RequirementValue;
                            stanceId = EnhancementRankModifierModels[i].StanceId;
                            comparison = EnhancementRankModifierModels[i].Comparison;
                            break;
                            }
                    case ScreenType.Feat:
                            {
                            modifierType = FeatModifierModels[i].ModifierType;
                            methodId = FeatModifierModels[i].ModifierMethodId;
                            modifierId = FeatModifierModels[i].ModifierId;
                            bonustypeId = FeatModifierModels[i].BonusTypeId;
                            pullFromId = FeatModifierModels[i].PullFromId;
                            modifierValue = FeatModifierModels[i].Value;
                            requirementId = FeatModifierModels[i].RequirementId;
                            requirementValue = FeatModifierModels[i].RequirementValue;
                            stanceId = FeatModifierModels[i].StanceId;
                            comparison = FeatModifierModels[i].Comparison;
                            break;
                            }
                    }
                if (RecordsDeleted[i] == false)
                    {
                    //now that we have the data, lets add this record to the listview
                    ListViewItem row = new ListViewItem(GetModifierTypeString(modifierType)); //Type Column
                    row.SubItems.Add(GetModifierString(methodId, modifierValue, modifierId, bonustypeId, pullFromId)); //Modifier Column
                    row.SubItems.Add(GetRequirementString(requirementId, comparison, requirementValue, stanceId)); //Modifier Requirement Column
                    ListViewModifiers.Items.Add(row);
                    ListViewModelIndex.Add(i);
                    }
                }
            ListViewModifiers.EndUpdate();
            ListViewModifiers.Refresh();
            }

        private string GetModifierString(Guid methodId, double modifierValue, Guid modifierId, Guid bonusTypeId, Guid pullFromId)
            {
            string text = "";

            if (ModifierMethodModel.GetMethodNameFromId(methodId) == "Normal")
                {
                text = "+" + modifierValue;
                if (bonusTypeId == Guid.Empty)
                    text += " bonus";
                else
                    text += " " + BonusTypeModel.GetNameFromId(bonusTypeId) + " bonus";
                text += " to " + ModifierModel.GetNameFromId(modifierId);
                return text;
                }

            if (ModifierMethodModel.GetMethodNameFromId(methodId) == "Repeater")
                {
                text = "+" + modifierValue;
                if (bonusTypeId == Guid.Empty)
                    text += " bonus";
                else
                    text += " " + BonusTypeModel.GetNameFromId(bonusTypeId) + " bonus";
                text += " to " + ModifierModel.GetNameFromId(modifierId);
                text += " for each ";
                return text;
                }

            if (ModifierMethodModel.GetMethodNameFromId(methodId) == "AbilityBonus")
                {
                text = "Apply up to +" + modifierValue + " of your ";
                text += AbilityModel.GetNameFromId(pullFromId) + " bonus to ";
                text += ModifierModel.GetNameFromId(modifierId);
                return text;
                }

            if (ModifierMethodModel.GetMethodNameFromId(methodId) == "AbilitySwap")
                {
                text = "Apply up to +" + modifierValue + " of your ";
                text += AbilityModel.GetNameFromId(pullFromId) + " to ";
                text += ModifierModel.GetNameFromId(modifierId) + " instead of your normal bonus";
                return text;
                }

            if (ModifierMethodModel.GetMethodNameFromId(methodId) == "Attribute")
                {
                text = "Apply up to +" + modifierValue + " of your ";
                text += AttributeModel.GetNameFromId(pullFromId) + " to ";
                text += ModifierModel.GetNameFromId(modifierId);
                return text;
                }

            //We should not reach this point
            Debug.Write("ERROR: No value ModifierMethod was found. ModifierPanel2 : GetModifierString()");
            text = "Not a valid Modifier MethodType";
            return text;
            }
        
        private string GetModifierTypeString(byte type)
            {
            string text;
            text = "";

            switch (type)
                {
                case 0:
                        {
                        text = "Passive";
                        break;
                        }
                case 1:
                        {
                        text = "Stance";
                        break;
                        }
                default:
                        {
                        //We should not reach here
                        break;
                        }
                }
            return text;
            }

        private void GetModifierValues(int index, out Guid modifierId, out byte modifierType, out Guid modifierMethodId, out Guid bonusTypeId,
            out Guid pullFromId, out double modifierValue, out Guid requirementId, out Guid stanceId, out string comparison, out double requirementValue)
            {
            modifierId = Guid.Empty;
            modifierType = 0;
            modifierMethodId = Guid.Empty;
            bonusTypeId = Guid.Empty;
            pullFromId = Guid.Empty;
            modifierValue = 0;
            requirementId = Guid.Empty;
            stanceId = Guid.Empty;
            comparison = "=";
            requirementValue = 0;

            switch (MainScreen)
                {
                case ScreenType.DestinyRank:
                        {
                        //TODO: Need to fill in once destinies models are in place
                        break;
                        }
                case ScreenType.EnhancementRank:
                        {
                        modifierId = EnhancementRankModifierModels[index].ModifierId;
                        modifierType = EnhancementRankModifierModels[index].ModifierType;
                        modifierMethodId = EnhancementRankModifierModels[index].ModifierMethodId;
                        bonusTypeId = EnhancementRankModifierModels[index].BonusTypeId;
                        pullFromId = EnhancementRankModifierModels[index].PullFromId;
                        modifierValue = EnhancementRankModifierModels[index].ModifierValue;
                        requirementId = EnhancementRankModifierModels[index].RequirementId;
                        stanceId = EnhancementRankModifierModels[index].StanceId;
                        comparison = EnhancementRankModifierModels[index].Comparison;
                        requirementValue = EnhancementRankModifierModels[index].RequirementValue;
                        break;
                        }
                case ScreenType.Feat:
                        {
                        modifierId = FeatModifierModels[index].ModifierId;
                        modifierType = FeatModifierModels[index].ModifierType;
                        modifierMethodId = FeatModifierModels[index].ModifierMethodId;
                        bonusTypeId = FeatModifierModels[index].BonusTypeId;
                        pullFromId = FeatModifierModels[index].PullFromId;
                        modifierValue = FeatModifierModels[index].Value;
                        requirementId = FeatModifierModels[index].RequirementId;
                        stanceId = FeatModifierModels[index].StanceId;
                        comparison = FeatModifierModels[index].Comparison;
                        requirementValue = FeatModifierModels[index].RequirementValue;
                        break;
                        }
                }
            return;
            }

        private string GetRequirementString(Guid requirementId, string comparison, double requirementValue, Guid stanceId)
            {
            string text = "";
            
            if (requirementId != Guid.Empty)
                text = RequirementModel.GetNameFromId(requirementId) + " " + comparison + " " + requirementValue.ToString();
            if (stanceId != Guid.Empty)
                {
                if (requirementId != Guid.Empty)
                    text += ", ";
                text += "while in " + StanceModel.GetStanceNameFromId(stanceId) + " stance";
                }

            return text;
            }

        private void OpenEditDialog(bool add, int modelIndex)
            {
            EditModifierDialogClass editDialog;
            DialogResult result;

            ModifierDialogClass modifierDialog;

            Guid modifierId;
            byte modifierType;
            Guid modifierMethodId;
            Guid bonusTypeId;
            Guid pullFromId;
            double modifierValue;
            Guid requirementId;
            Guid stanceId;
            string comparison;
            double requirementValue;

            if (add == true)
                {
                //New way, disable this when not coding
                    modifierDialog = new ModifierDialogClass(true, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty);
                    result = modifierDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        UpdateModifierRecord(true, -1, modifierDialog.ModifierID, modifierDialog.ModifierType, modifierDialog.ModifierMethodId, modifierDialog.BonusTypeId,
                            modifierDialog.PullFromId, modifierDialog.ModifierValue, modifierDialog.RequirementId, modifierDialog.StanceId, modifierDialog.Comparison, modifierDialog.RequirmentValue);
                        return;
                    }

                   
                    //Old way, re-enable this when not coding
                    //editDialog = new EditModifierDialogClass();
                    //result = editDialog.ShowDialog();
                    //if (result == DialogResult.OK)
                    //{
                    //    UpdateModifierRecord(true, -1, editDialog.ModifierID, editDialog.ModifierType, editDialog.ModifierMethodId, editDialog.BonusTypeId,
                    //        editDialog.PullFromId, editDialog.ModifierValue, editDialog.RequirementId, editDialog.StanceId, editDialog.Comparison, editDialog.RequirmentValue);
                    //    return;
                    //}

                    //close
                }
            else
                {
                GetModifierValues(modelIndex, out modifierId, out modifierType, out modifierMethodId, out bonusTypeId, out pullFromId, out modifierValue,
                    out requirementId, out stanceId, out comparison, out requirementValue);
                editDialog = new EditModifierDialogClass(modifierType, modifierId, modifierMethodId, bonusTypeId, pullFromId, modifierValue, requirementId,
                    stanceId, comparison, requirementValue);
                result = editDialog.ShowDialog();
                if (result == DialogResult.OK)
                    {
                    UpdateModifierRecord(false, modelIndex, editDialog.ModifierID, editDialog.ModifierType, editDialog.ModifierMethodId, editDialog.BonusTypeId,
                        editDialog.PullFromId, editDialog.ModifierValue, editDialog.RequirementId, editDialog.StanceId, editDialog.Comparison, editDialog.RequirmentValue);
                    return;
                    }
                }

            }

        private void PopulateData()
            {
            //Lets get our model records
            switch (MainScreen)
                {
                case ScreenType.DestinyRank:
                        {
                        //TODO: Add Destiny info once that system is setup
                        break;
                        }
                case ScreenType.EnhancementRank:
                        {
                        EnhancementRankModifierModels = EnhancementRankModifierModel.GetAll(MainRecordId);
                        ModelRecordCount = EnhancementRankModifierModels.Count;
                        break;
                        }
                case ScreenType.Feat:
                        {
                        FeatModifierModels = FeatModifierModel.GetAll(MainRecordId);
                        ModelRecordCount = FeatModifierModels.Count;
                        break;
                        }
                }

            //Lets set our tracking variables to false
            for (int i = 0; i < ModelRecordCount; i++)
                {
                RecordsChanged.Add(false);
                RecordsDeleted.Add(false);
                }
            }

        #endregion

        #region Public Members
        public void Clear()
            {
            //Lets Clear our lists and RecordID
            EnhancementRankModifierModels.Clear();
            FeatModifierModels.Clear();
            RecordsChanged.Clear();
            RecordsDeleted.Clear();
            MainRecordId = Guid.Empty;
            }

        public bool HaveRecordsChanged()
            {
            for (int i = 0; i < RecordsChanged.Count; i++)
                {
                if (RecordsChanged[i] == true || RecordsDeleted[i] == true)
                    return true;
                }
            return false;
            }

        public void Initialize()
            {

            PopulateData();
            FillModifierListBox();
            }

        public void SaveRecords()
            {
            if (MainRecordId == Guid.Empty)
                {
                // Main Record Id is empty, this should not happen
                Debug.WriteLine("Error: MainRecordId is empty, you need to set the RecordId property to a valid Guid Id first before calling this Save() method.");
                return;
                }

            for (int i = 0; i < RecordsChanged.Count; i++)
                {
                if (RecordsDeleted[i] == true)
                    {
                    switch (MainScreen)
                        {
                        case ScreenType.DestinyRank:
                                {
                                //TODO: need to fill in once Destinies are in place
                                break;
                                }
                        case ScreenType.EnhancementRank:
                                {
                                EnhancementRankModifierModels[i].Delete();
                                break;
                                }
                        case ScreenType.Feat:
                                {
                                FeatModifierModels[i].Delete();
                                break;
                                }
                        }
                    RecordsDeleted[i] = false;
                    RecordsChanged[i] = false;
                    }

                if (RecordsChanged[i] == true)
                    {
                    switch (MainScreen)
                        {
                        case ScreenType.DestinyRank:
                                {
                                //TODO: Need to fill in once Destinies are in place
                                break;
                                }
                        case ScreenType.EnhancementRank:
                                {
                                EnhancementRankModifierModels[i].EnhancementRankId = MainRecordId;
                                EnhancementRankModifierModels[i].Save();
                                break;
                                }
                        
                        case ScreenType.Feat:
                                {
                                FeatModifierModels[i].FeatId = MainRecordId;
                                FeatModifierModels[i].Save();
                                break;
                                }
                        }
                    RecordsChanged[i] = false;
                    }
                }
            }

        #endregion

        }
    }
