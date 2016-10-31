using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using DDOCharacterPlanner.Model;
using DDOCharacterPlanner.Screens;

namespace DDOCharacterPlanner.Screens.DataInput
    {
    public partial class RequirementsPanel2 : UserControl
        {
        #region Enums

        public enum ScreenType
            {
            Destiny,
            Enhancement,
            EnhancementTree,
            Feat,
            };

        public enum ScreenStyle
            {
            Normal,
            Extended,
            };

        private enum PanelType
            {
            All,
            One,
            };

        #endregion

        #region Member Variables
        private ScreenStyle RPStyle;
        private ScreenType MainScreenType;
        private Guid MainRecordId;
        //private bool AllowChanges;
        private int ModelRecordCount;
        private bool RequireAllSelected;

        //Model Collections
        private List<FeatRequirementModel> FeatRequirementModels;
        private List<EnhancementTreeRequirementModel> EnhancementTreeRequirementModels;
        private List<EnhancementRankRequirementModel> EnhancementRequirementModels;
        //private List<DestinyRequirementsModel> DestinyRequirementModels;

        //Tracking Lists for model changes
        private List<bool> RecordsChanged;
        private List<bool> RecordsDeleted;

        //Tracking list for which model is in which listbox
        private List<int> RequiresAllIndex;
        private List<int> RequiresOneIndex;

        
        #endregion

        #region Properties
        [Category("_RP Properties")]
        public ScreenType MainScreen
            {
            get
            { return MainScreenType; }
            set
                {
                MainScreenType = value;
                }
            }

        [Category("_RP Properties")]
        public ScreenStyle ControlStyle
            {
            get
            { return RPStyle; }
            set
                {
                RPStyle = value;
                ChangeLayout(value);
                }
            }

        [Category("_RP Properties")]
        public Guid RecordId
            {
            get{ return MainRecordId; }
            set
                {
                MainRecordId = value;
                }
            }

        #endregion

        #region Constructors
        public RequirementsPanel2()
            {
            InitializeComponent();
           
            //AllowChanges = false;

            FeatRequirementModels = new List<FeatRequirementModel>();
            EnhancementTreeRequirementModels = new List<EnhancementTreeRequirementModel>();
            EnhancementRequirementModels = new List<EnhancementRankRequirementModel>();
            //DestinyRequirementModels = new List<DestinyRequirementModel>();

            RecordsChanged = new List<bool>();
            RecordsDeleted = new List<bool>();
            RequiresAllIndex = new List<int>();
            RequiresOneIndex = new List<int>();

            RequireAllSelected = true;
            //AllowChanges = true;
            }

        #endregion

        #region Control Events
        private void AddButton_Click(object sender, EventArgs e)
            {
            //OpenEditDialog(true, 0, false);
            OpenRequirementDialog(true, 0, false);
            }

        private void DeleteToolStripMenuItemAll_Click(object sender, EventArgs e)
            {
            if (RequiresAllListBox.SelectedIndex == -1)
                return;
            int modelIndex = RequiresAllIndex[RequiresAllListBox.SelectedIndex];
            DeleteRecord(modelIndex);
            }

        private void DeleteToolStripMenuItemOne_Click(object sender, EventArgs e)
            {
            if (RequiresOneListBox.SelectedIndex == -1)
                return;

            int modelIndex = RequiresOneIndex[RequiresOneListBox.SelectedIndex];
            DeleteRecord(modelIndex);
            }

        private void EditToolStripMenuItemAll_Click(object sender, EventArgs e)
            {
            if (RequiresAllListBox.SelectedIndex == -1)
                return;
            int modelIndex = RequiresAllIndex[RequiresAllListBox.SelectedIndex];

            //OpenEditDialog(false, modelIndex, true);
            OpenRequirementDialog(false, modelIndex, true);
            }

        private void EditToolStripMenuItemOne_Click(object sender, EventArgs e)
            {
            if (RequiresOneListBox.SelectedIndex == -1)
                return;
            int modelIndex = RequiresOneIndex[RequiresOneListBox.SelectedIndex];

            //OpenEditDialog(false, modelIndex, false);
            OpenRequirementDialog(false, modelIndex, false);
            }

        private void OnRequiresAllButtonClick(object sender, EventArgs e)
            {
            if (RequireAllSelected == false && RPStyle == ScreenStyle.Normal)
                {
                MainSplitContainer.Panel1Collapsed = false;
                MainSplitContainer.Panel2Collapsed = true;
                RequireAllSelected = true;
                RequiresAllButton.BackColor = Color.Blue;
                RequiresOneButton.BackColor = Color.Silver;
                }

            }

        private void OnRequiresOneButtonClick(object sender, EventArgs e)
            {
            if (RequireAllSelected == true && RPStyle == ScreenStyle.Normal)
                {
                MainSplitContainer.Panel2Collapsed = false;
                MainSplitContainer.Panel1Collapsed = true;
                RequireAllSelected = false;
                RequiresAllButton.BackColor = Color.Silver;
                RequiresOneButton.BackColor = Color.Blue;
                }
            }

        private void RequiresAllListBox_MouseDoubleClick(object sender, MouseEventArgs e)
            {
            if (RequiresAllListBox.SelectedIndex == -1)
                return;
            int modelIndex = RequiresAllIndex[RequiresAllListBox.SelectedIndex];
            
            //OpenEditDialog(false, modelIndex, true);
            OpenRequirementDialog(false, modelIndex, true);
            }

        private void RequiresAllListBox_MouseDown(object sender, MouseEventArgs e)
            {
            RequiresAllListBox.SelectedIndex = RequiresAllListBox.IndexFromPoint(e.X, e.Y);

            if (e.Button == MouseButtons.Right)
                {
                if (RequiresAllListBox.SelectedIndex > -1)
                    RequireAllMenuStrip.Show(RequiresAllListBox, e.Location);
                }
            }

        private void RequiresOneListBox_MouseDoubleClick(object sender, MouseEventArgs e)
            {
            if (RequiresOneListBox.SelectedIndex == -1)
                return;
            int modelIndex = RequiresOneIndex[RequiresOneListBox.SelectedIndex];

            //OpenEditDialog(false, modelIndex, false);
            OpenRequirementDialog(false, modelIndex, false);
            }

        private void RequiresOneListBox_MouseDown(object sender, MouseEventArgs e)
            {
            RequiresOneListBox.SelectedIndex = RequiresOneListBox.IndexFromPoint(e.X, e.Y);

            if (e.Button == MouseButtons.Right)
                {
                if (RequiresOneListBox.SelectedIndex > -1)
                    RequireOneMenuStrip.Show(RequiresOneListBox, e.Location);
                }
            }

        #endregion

        #region Private Members
        private string BuildRequirementText(Guid requirementId, string requirementComparison, double requirementValue)
            {
            string text;
            string tableName;
            RequirementModel reqModel;
            text = "";
            //text = RequirementModel.GetNameFromId(requirementId) + " " + requirementComparison + " " + requirementValue.ToString();
            reqModel = new RequirementModel();
            reqModel.Initialize(requirementId);
            tableName = TableNamesModel.GetTableNameFromId(reqModel.TableNamesId);
            if (tableName == "Ability")
                text = AbilityModel.GetNameFromId(reqModel.ApplytoId) + " " + requirementComparison + " " + requirementValue.ToString();
            else if (tableName == "Alignments")
                text = "Alignment: " + requirementComparison + " " + AlignmentModel.GetNameFromID(reqModel.ApplytoId);
            else if (tableName == "Attribute")
                text = AttributeModel.GetNameFromId(reqModel.ApplytoId) + " " + requirementComparison + " " + requirementValue.ToString();
            else if (tableName == "Character")
                text = "Character " + requirementComparison + " Level " + requirementValue.ToString();
            else if (tableName == "Class")
                text = ClassModel.GetNameFromId(reqModel.ApplytoId) + " " + requirementComparison + " Level " + requirementValue.ToString();
            else if (tableName == "Enhancement")
                text = "Enhnacement: " + EnhancementModel.GetNameFromId(reqModel.ApplytoId) + " " + requirementComparison + " Rank " + requirementValue.ToString();
            else if (tableName == "EnhancementSlot")
                text = "Enhancement Slot: " + BuildSlotName(reqModel.ApplytoId) + " " + requirementComparison + " Rank " + requirementValue.ToString();
            else if (tableName == "Feat")
                text = "Feat: " + FeatModel.GetNameFromId(reqModel.ApplytoId);
            else if (tableName == "Race")
                text = RaceModel.GetNameFromId(reqModel.ApplytoId) + " " + requirementComparison + " Level " + requirementValue.ToString();
            else if (tableName == "Skill")
                text = SkillModel.GetNameFromId(reqModel.ApplytoId) + " " + requirementComparison + " " + requirementValue.ToString();
            else
            {
                //we should not reach here
                Debug.WriteLine("Error: No category exists for this requirement. RequirementPanel2: BuildRequirementText()");
            }

            return text;
            }

        private string BuildSlotName(Guid slotId)
            {
            string slotName;
            EnhancementSlotModel slotModel;

            slotName = "";
            slotModel = new EnhancementSlotModel();
            slotModel.Initialize(slotId);

            if (slotModel.UseEnhancementInfo == true)
                slotName = EnhancementModel.GetNameFromId(EnhancementModel.GetIdFromSlotIdandDisplayOrder(slotModel.Id, 0));
            else
                slotName = slotModel.Name;

            return slotName;
            }

        private void ChangeLayout(ScreenStyle style)
            {
            if (style == ScreenStyle.Extended)
                {
                this.MinimumSize = new Size(300, 80);
                //Ok we need to unhide the panel that is hidden
                MainSplitContainer.Panel1Collapsed = false;
                MainSplitContainer.Panel2Collapsed = false;
                RequiresOneButton.Left = MainSplitContainer.Panel2.Left;
                RequiresAllButton.Enabled = false;
                RequiresOneButton.Enabled = false;
                }
            else
                {
                this.MinimumSize = new Size(240, 80);
                //Lets hide panel2
                MainSplitContainer.Panel1Collapsed = false;
                MainSplitContainer.Panel2Collapsed = true;
                RequiresOneButton.Left = RequiresOneButton.Width + 5;
                RequiresAllButton.Enabled = true;
                RequiresOneButton.Enabled = true;
                RequiresAllButton.BackColor = Color.Blue;
                }
            }

        private void PopulateData()
            {
            //Lets get our Model records
            switch (MainScreenType)
                {
                case ScreenType.Destiny:
                        {
                        break;
                        }
                case ScreenType.Enhancement:
                        {
                        EnhancementRequirementModels = EnhancementRankRequirementModel.GetAll(MainRecordId);
                        ModelRecordCount = EnhancementRequirementModels.Count();
                        break;
                        }
                case ScreenType.EnhancementTree:
                        {
                        EnhancementTreeRequirementModels = EnhancementTreeRequirementModel.GetAll(MainRecordId);
                        ModelRecordCount = EnhancementTreeRequirementModels.Count();
                        break;
                        }
                case ScreenType.Feat:
                        {
                        FeatRequirementModels = FeatRequirementModel.GetAll(MainRecordId);
                        ModelRecordCount = FeatRequirementModels.Count();
                        break;
                        }
                }

            //Lets set our tracking variables to false;
            for (int i = 0; i < ModelRecordCount; i++)
                {
                RecordsChanged.Add(false);
                RecordsDeleted.Add(false);
                }
            }

        private void FillRequirementListBoxes()
            {
            bool requireAllFlag;
            //ListItem li;
            string text;
            Guid requirementId;
            double requirementValue;
            string requirementComparison;

            RequiresAllListBox.Items.Clear();
            RequiresOneListBox.Items.Clear();
            RequiresOneIndex.Clear();
            RequiresAllIndex.Clear();
            for (int i=0; i<ModelRecordCount; i++)
                {
                requireAllFlag = false;
                text = "";
                requirementId = Guid.Empty;
                requirementValue = 0;
                requirementComparison = "=";
                
                switch (MainScreenType)
                    {
                    case ScreenType.Destiny:
                            {
                            break;
                            }
                    case ScreenType.Enhancement:
                            {
                            if (EnhancementRequirementModels[i].RequireAll == true)
                                requireAllFlag = true;
                            requirementId = EnhancementRequirementModels[i].RequirementId;
                            requirementValue = EnhancementRequirementModels[i].RequirementValue;
                            requirementComparison = EnhancementRequirementModels[i].Comparison;
                            break;
                            }
                    case ScreenType.EnhancementTree:
                            {
                            if (EnhancementTreeRequirementModels[i].RequireAll == true)
                                {
                                requireAllFlag = true;
                                }
                            requirementId = EnhancementTreeRequirementModels[i].RequirementId;
                            requirementValue = EnhancementTreeRequirementModels[i].RequirementValue;
                            requirementComparison = EnhancementTreeRequirementModels[i].Comparison;
                            break;
                            }
                    case ScreenType.Feat:
                            {
                            if (FeatRequirementModels[i].RequireAll == true)
                                requireAllFlag = true;
                            requirementId = FeatRequirementModels[i].RequirementId;
                            requirementValue = FeatRequirementModels[i].Value;
                            requirementComparison = FeatRequirementModels[i].Comparison;
                            break;
                            }
                    }
                text = BuildRequirementText(requirementId, requirementComparison, requirementValue);
                //text = RequirementModel.GetNameFromId(requirementId) + " " + requirementComparison + " " + requirementValue.ToString();
                //li = new ListItem(text, i);
                if (RecordsDeleted[i] == false)
                    {
                    if (requireAllFlag == true)
                        {

                        RequiresAllListBox.Items.Add(text);
                        RequiresAllIndex.Add(i);
                        }
                    else
                        {
                        RequiresOneListBox.Items.Add(text);
                        RequiresOneIndex.Add(i);
                        }
                    }
                }
            
            }

        //TODO: Maybe we can get rid of this, can't find any code that calls for it?
        private string GetRequirementTextString(int index)
            {
            string text;
            string value;

            Guid requirementId;
            RequirementModel requirementModel;

            value = "";
            requirementId = Guid.Empty;
            requirementModel = new RequirementModel();

            switch (MainScreenType)
                {
                case ScreenType.Destiny:
                        {
                        break;
                        }
                case ScreenType.Enhancement:
                        {
                        requirementId = EnhancementRequirementModels[index].RequirementId;
                        value = EnhancementRequirementModels[index].RequirementValue.ToString();
                        break;
                        }
                case ScreenType.Feat:
                        {
                        requirementId = FeatRequirementModels[index].RequirementId;
                        value = FeatRequirementModels[index].Value.ToString();
                        break;
                        }
                }

            requirementModel.Initialize(requirementId);

            text = requirementModel.Name + ": " + value;
            return text;
            }

        private void AddNewRecord(Guid requirementId, string requirementComparison, double requirementValue, bool requireAll)
            {
            int index;
            string text;

            index = RecordsChanged.Count;

            switch (MainScreenType)
                {
                case ScreenType.Destiny:
                        {
                        break;
                        }
                case ScreenType.Enhancement:
                        {
                        index = EnhancementRequirementModels.Count;
                        EnhancementRequirementModels.Add(new EnhancementRankRequirementModel());
                        EnhancementRequirementModels[index].EnhancementRankId = MainRecordId;
                        EnhancementRequirementModels[index].RequirementId = requirementId;
                        EnhancementRequirementModels[index].RequirementValue = requirementValue;
                        EnhancementRequirementModels[index].RequireAll = requireAll;
                        EnhancementRequirementModels[index].Comparison = requirementComparison;
                        break;
                        }
                case ScreenType.EnhancementTree:
                        {
                        index = EnhancementTreeRequirementModels.Count;
                        EnhancementTreeRequirementModels.Add(new EnhancementTreeRequirementModel());
                        EnhancementTreeRequirementModels[index].EnhancementTreeId = MainRecordId;
                        EnhancementTreeRequirementModels[index].RequirementId = requirementId;
                        EnhancementTreeRequirementModels[index].RequirementValue = requirementValue;
                        EnhancementTreeRequirementModels[index].RequireAll = requireAll;
                        EnhancementTreeRequirementModels[index].Comparison = requirementComparison;
                        break;
                        }
                case ScreenType.Feat:
                        {
                        index = FeatRequirementModels.Count;
                        FeatRequirementModels.Add(new FeatRequirementModel());
                        FeatRequirementModels[index].FeatId = MainRecordId;
                        FeatRequirementModels[index].RequirementId = requirementId;
                        FeatRequirementModels[index].Value = requirementValue;
                        FeatRequirementModels[index].RequireAll = requireAll;
                        FeatRequirementModels[index].Comparison = requirementComparison;
                        break;
                        }

                }

            //lets add the new selection to our listboxes
            //text = RequirementModel.GetNameFromId(requirementId) + " " + requirementComparison + " " + requirementValue;\
            text = BuildRequirementText(requirementId, requirementComparison, requirementValue);
            //li = new ListItem(text, index);
            if (requireAll == true)
                {
                RequiresAllListBox.Items.Add(text);
                RequiresAllIndex.Add(index);
                }
            else
                {
                RequiresOneListBox.Items.Add(text);
                RequiresOneIndex.Add(index);
                } 
            //Increment our Model record count
            ModelRecordCount++;

            //let set our flags for the new record
            RecordsChanged.Add(true);
            RecordsDeleted.Add(false);
            }

        private void DeleteRecord(int modelIndex)
            {

            //Mark model record for later deletion.
            RecordsDeleted[modelIndex] = true;

            //Lets refill the listboxes now to remove the deleted record
            FillRequirementListBoxes();
            }

        private void EditExistingRecord(int modelIndex, Guid requirementId, string requirementComparison, double requirementValue, bool requireAll)
            {
            switch (MainScreenType)
                {
                case ScreenType.Destiny:
                        {
                        break;
                        }
                case ScreenType.Enhancement:
                        {
                        EnhancementRequirementModels[modelIndex].RequirementId = requirementId;
                        EnhancementRequirementModels[modelIndex].RequirementValue = requirementValue;
                        EnhancementRequirementModels[modelIndex].RequireAll = requireAll;
                        EnhancementRequirementModels[modelIndex].Comparison = requirementComparison;
                        break;
                        }
                case ScreenType.EnhancementTree:
                        {
                        EnhancementTreeRequirementModels[modelIndex].RequirementId = requirementId;
                        EnhancementTreeRequirementModels[modelIndex].RequirementValue = requirementValue;
                        EnhancementTreeRequirementModels[modelIndex].RequireAll = requireAll;
                        EnhancementTreeRequirementModels[modelIndex].Comparison = requirementComparison;
                        break;
                        }
                case ScreenType.Feat:
                        {
                        FeatRequirementModels[modelIndex].RequirementId = requirementId;
                        FeatRequirementModels[modelIndex].Value = requirementValue;
                        FeatRequirementModels[modelIndex].RequireAll = requireAll;
                        FeatRequirementModels[modelIndex].Comparison = requirementComparison;
                        break;
                        }
                }
            //We need to repopulate the Listboxes to show the change.
            FillRequirementListBoxes();
            RecordsChanged[modelIndex] = true;
            }

        private void GetRequirementValues(int index, out Guid requirementId, out double requirementValue, out bool requireAll, out string requirementComparison)
            {
            requirementId = Guid.Empty;
            requirementValue = 0;
            requireAll = false;
            requirementComparison = "=";

            switch (MainScreenType)
                {
                case ScreenType.Destiny:
                        {
                        break;
                        }
                case ScreenType.Enhancement:
                        {
                        requirementId = EnhancementRequirementModels[index].RequirementId;
                        requirementValue = EnhancementRequirementModels[index].RequirementValue;
                        requireAll = EnhancementRequirementModels[index].RequireAll;
                        requirementComparison = EnhancementRequirementModels[index].Comparison;
                        break;
                        }
                case ScreenType.EnhancementTree:
                        {
                        requirementId = EnhancementTreeRequirementModels[index].RequirementId;
                        requirementValue = EnhancementTreeRequirementModels[index].RequirementValue;
                        requireAll = EnhancementTreeRequirementModels[index].RequireAll;
                        requirementComparison = EnhancementTreeRequirementModels[index].Comparison;
                        break;
                        }
                case ScreenType.Feat:
                        {
                        requirementId = FeatRequirementModels[index].RequirementId;
                        requirementValue = FeatRequirementModels[index].Value;
                        requireAll = FeatRequirementModels[index].RequireAll;
                        requirementComparison = FeatRequirementModels[index].Comparison;
                        break;
                        }
                }
            return;

            }

        private void OpenRequirementDialog(bool add, int modelIndex, bool allBox)
            {
            Guid requirementId;
            double requirementValue;
            bool requiresAll;
            string requirementComparison;
            RequirementDialogClass requirementDialog;
            DialogResult result;

            if (add == true)
                {
                requirementDialog = new RequirementDialogClass(true, Guid.Empty);
                result = requirementDialog.ShowDialog();
                if (result == DialogResult.OK)
                    {
                    AddNewRecord(requirementDialog.RequirementId, requirementDialog.RequirementComparison, requirementDialog.RequirementValue, requirementDialog.RequiresAll);
                    return;
                    }
                }
            else
                {
                GetRequirementValues(modelIndex, out requirementId, out requirementValue, out requiresAll, out requirementComparison);
                requirementDialog = new RequirementDialogClass(false, requirementId, requirementValue, requiresAll, requirementComparison);
                result = requirementDialog.ShowDialog();
                if (result == DialogResult.OK)
                    {
                    if (requirementDialog.RequirementId != requirementId || requirementDialog.RequirementValue != requirementValue || requirementDialog.RequirementComparison != requirementComparison || requirementDialog.RequiresAll != requiresAll)
                        {
                        EditExistingRecord(modelIndex, requirementDialog.RequirementId, requirementDialog.RequirementComparison, requirementDialog.RequirementValue, requirementDialog.RequiresAll);
                        return;
                        }
                    }
                }
            }

        /*private void OpenEditDialog(bool add, int modelIndex, bool allBox)
            {
            Guid requirementId;
            double requirementValue;
            bool requireAll;
            string requirementComparison;
            EditRequirementDialogClass editDialog;
            DialogResult result;

            if (add == true)
                {
                editDialog = new EditRequirementDialogClass(Guid.Empty, EditRequirementDialogClass.MethodType.Add, 0, false, "=");
                result = editDialog.ShowDialog();
                if (result == DialogResult.OK)
                    {
                    AddNewRecord(editDialog.RequirementId, editDialog.RequirementComparison, editDialog.RequirementValue, editDialog.RequiresAll);
                    return;
                    }
                }
            else
                {
                GetRequirementValues(modelIndex, out requirementId, out requirementValue, out requireAll, out requirementComparison);
                editDialog = new EditRequirementDialogClass(requirementId, EditRequirementDialogClass.MethodType.Edit, requirementValue, requireAll, requirementComparison);
                result = editDialog.ShowDialog();
                if (result == DialogResult.OK)
                    {
                    if (editDialog.RequirementId != requirementId || editDialog.RequirementValue != requirementValue || editDialog.RequiresAll != requireAll || editDialog.RequirementComparison != requirementComparison)
                        {
                        //Edit Existing Record as it has been changed
                        EditExistingRecord(modelIndex, editDialog.RequirementId, editDialog.RequirementComparison, editDialog.RequirementValue, editDialog.RequiresAll);
                        return;
                        }
                    }
                }
            }
         * */

        #endregion

        #region Public Members
        public void Initialize()
            {
            //AllowChanges = false;

            //Load our private variables with data from the database
            PopulateData();

            //Populate the listboxes with our requirement records.
            FillRequirementListBoxes();

            //AllowChanges = true;
            }

        public void Clear()
            {

            FeatRequirementModels.Clear();

            RecordsChanged.Clear();
            RecordsDeleted.Clear();
            RequiresAllIndex.Clear();
            RequiresOneIndex.Clear();

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
                    switch (MainScreenType)
                        {
                        case ScreenType.Destiny:
                                {
                                break;
                                }
                        case ScreenType.Enhancement:
                                {
                                EnhancementRequirementModels[i].Delete();
                                break;
                                }
                        case ScreenType.EnhancementTree:
                                {
                                EnhancementTreeRequirementModels[i].Delete();
                                break;
                                }
                        case ScreenType.Feat:
                                {
                                FeatRequirementModels[i].Delete();
                                break;
                                }
                        }
                    RecordsDeleted[i] = false;
                    RecordsChanged[i] = false;
                    }

                if (RecordsChanged[i] == true)
                    {
                    switch (MainScreenType)
                        {
                        case ScreenType.Destiny:
                                {
                                break;
                                }
                        case ScreenType.Enhancement:
                                {
                                EnhancementRequirementModels[i].EnhancementRankId = MainRecordId;
                                EnhancementRequirementModels[i].Save();
                                break;
                                }
                        case ScreenType.EnhancementTree:
                                {
                                EnhancementTreeRequirementModels[i].EnhancementTreeId = MainRecordId;
                                EnhancementTreeRequirementModels[i].Save();
                                break;
                                }
                        case ScreenType.Feat:
                                {
                                FeatRequirementModels[i].FeatId = MainRecordId;
                                FeatRequirementModels[i].Save();
                                break;
                                }
                        }
                    RecordsChanged[i] = false;
                    }
                }
            }

        #endregion

        private void RequirementsPanel2_Resize(object sender, EventArgs e)
            {
            if (RPStyle == ScreenStyle.Extended)
                RequiresOneButton.Left = MainSplitContainer.Panel2.Left;
            }

        }
    }
