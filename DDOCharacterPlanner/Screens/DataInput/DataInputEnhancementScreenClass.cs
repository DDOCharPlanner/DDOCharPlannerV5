using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using DDOCharacterPlanner.Model;
using DDOCharacterPlanner.SaveDataModel;
using DDOCharacterPlanner.Screens.Controls;
using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Screens.DataInput
    {
    public partial class DataInputEnhancementScreenClass : Form
        {
        #region Enums
        private enum InputType
            {
            Name,
            Background,
            RaceTree,
            ClassTree,
            };

        #endregion

        #region Member Variables
        private EnhancementTreeModel TreeModel;
        private List<EnhancementSlotModel> SlotModels;
        //private List<EnhancementModel> EnhancementModels;
        //private List<EnhancementRankModel> RankModels;
        private List<string> TreeNames;

        //tracking variables
        private bool NewRecord;
        private bool RecordChanged;
        private List<bool> SlotChanged;
        private List<bool> SlotDeleted;
        private bool AllowChangeEvents;
        private string DatabaseName;

        #endregion

        #region Constructors
        public DataInputEnhancementScreenClass()
            {
            Debug.WriteLine("EnhancementScreen Constructor");
            InitializeComponent();
            AllowChangeEvents = false;
            NewRecord = false;
            //Set the controls to the Chosen Skin Settings
            ApplySkin();

            TreeNames = new List<string>();
            TreeModel = new EnhancementTreeModel();
            SlotModels = new List<EnhancementSlotModel>();
            //EnhancementModels = new List<EnhancementModel>();
            //RankModels = new List<EnhancementRankModel>();

            //Lets populate the Main Tree List and sets it selected value to the first record
            PopulateEnhancementTreeListBox();
            if (TreeNames.Count() != 0)
                EnhancementTreeListBox.SelectedIndex = 0;

            //Lets Fill our fields out now
            if (TreeNames.Count() != 0)
                PopulateFields(EnhancementTreeListBox.SelectedItem.ToString());
            else
                {
                NewRecord = true;
                PopulateFields("_New Enhancement Tree_");
                
                }

            //Set our main tracking variable to false
            RecordChanged = false;

            //turn on our change events
            AllowChangeEvents = true;
            }
        #endregion

        #region Control Events

        private void buttonDuplicateRecord_Click(object sender, EventArgs e)
            {
            string selection;
            EnhancementTreeModel newTreeModel = new EnhancementTreeModel();
            List<EnhancementTreeRequirementModel> newTreeRequirementModels = new List<EnhancementTreeRequirementModel>();
            List<EnhancementSlotModel> newSlotModels = new List<EnhancementSlotModel>();
            List<EnhancementModel> newEnhancementModels = new List<EnhancementModel>();
            List<EnhancementRankModel> newEnhancementRankModels = new List<EnhancementRankModel>();
            List<EnhancementRankModifierModel> newEnhancementRankModifierModels = new List<EnhancementRankModifierModel>();
            List<EnhancementRankRequirementModel> newEnhancementRankRequirementModels = new List<EnhancementRankRequirementModel>();
            Guid oldSlotId;
            Guid oldEnhancementId;
            Guid oldRankId;
            Guid oldModifierId;
            Guid oldRequirementId;

            //Copy the Tree Model First
            newTreeModel.Initialize(TreeModel.Id);
            newTreeModel.ConvertToNewRecord();
            newTreeModel.Name = TreeModel.Name + "Duplicate";
            newTreeModel.Save();

            //Copy the Tree Requirement Models
            newTreeRequirementModels = EnhancementTreeRequirementModel.GetAll(TreeModel.Id);
            foreach (EnhancementTreeRequirementModel etrm in newTreeRequirementModels)
                {
                etrm.ConvertToNewRecord();
                etrm.EnhancementTreeId = newTreeModel.Id;
                etrm.Save();
                }

            //Copy the Slot Models
            newSlotModels = EnhancementSlotModel.GetAll(TreeModel.Id);
            foreach (EnhancementSlotModel slot in newSlotModels)
                {
                oldSlotId = slot.Id;
                slot.ConvertToNewRecord();
                slot.EnhancementTreeId = newTreeModel.Id;
                slot.Save();
                //Copy the Enhancements for this Slot Model.
                newEnhancementModels = EnhancementModel.GetAll(oldSlotId);
                foreach (EnhancementModel em in newEnhancementModels)
                    {
                    oldEnhancementId = em.Id;
                    em.ConvertToNewRecord();
                    em.EnhancementSlotId = slot.Id;
                    em.Save();
                    //Copy the Enhancement Ranks for this Enhancement.
                    newEnhancementRankModels = EnhancementRankModel.GetAll(oldEnhancementId);
                    foreach (EnhancementRankModel erm in newEnhancementRankModels)
                        {
                        oldRankId = erm.Id;
                        erm.ConvertToNewRecord();
                        erm.EnhancementId = em.Id;
                        erm.Save();
                        //Copy the Enhancement Rank Modifier Models
                        newEnhancementRankModifierModels = EnhancementRankModifierModel.GetAll(oldRankId);
                        foreach (EnhancementRankModifierModel ermm in newEnhancementRankModifierModels)
                            {
                            oldModifierId = ermm.Id;
                            ermm.ConvertToNewRecord();
                            ermm.EnhancementRankId = erm.Id;
                            ermm.Save();
                            }
                        //Copy the Enhancement Rank Requirement Models
                        newEnhancementRankRequirementModels = EnhancementRankRequirementModel.GetAll(oldRankId);
                        foreach (EnhancementRankRequirementModel errm in newEnhancementRankRequirementModels)
                            {
                            oldRequirementId = errm.Id;
                            errm.ConvertToNewRecord();
                            errm.EnhancementRankId = erm.Id;
                            errm.Save();
                            }
                        }
                    }
                }

            //Now lets update our screen with the new record
            selection = newTreeModel.Name;
            EnhancementTreeListBox.Items.Clear();
            PopulateEnhancementTreeListBox();
            //AllowChangeEvents = false;
            EnhancementTreeListBox.SelectedItem = selection;
            //AllowChangeEvents = true;

            //Now we can reset our flags
            RecordChanged = false;
            NewRecord = false;
            }

        private void EnhancementTreeControl_SelectedIndexChanged(object sender, EventArgs e)
            {
            //TODO: I may be able to remove this now as i don't change anything based on the index change
            if (AllowChangeEvents == true)
                {
                if (EnhancementTreeControl.SelectedIndex == -1)
                    return;

                //TODO: Process code here to populate the image into the slot
                }
            }

        private void EnhancementTreeControl_SlotAdded(object sender, TreeControl.TreeEventArgs e)
            {
            if (AllowChangeEvents == true)
                {
                RecordChanged = true;
                SlotChanged[e.SlotIndex] = true;
                SlotDeleted[e.SlotIndex] = false;
                }
            }

        private void EnhancementTreeControl_SlotRemoved(object sender, TreeControl.TreeEventArgs e)
            {
            if (AllowChangeEvents == true)
                {
                RecordChanged = true;
                SlotDeleted[e.SlotIndex] = true;
                SlotDeleted[e.SlotIndex] = true;
                }
            }

        private void EnhancementTreeControl_SlotMouseClick(object sender, TreeControl.TreeEventArgs e)
            {
            if (AllowChangeEvents == true)
                {
                if (e.MouseButton == MouseButtons.Right)
                    {
                    EnhancementTreeControl.RemoveSlot(e.SlotIndex);
                    }
                }
            }

        private void EnhancementTreeControl_SlotMouseDoubleClick(object sender, TreeControl.TreeEventArgs e)
            {
            if (AllowChangeEvents == true)
                {
                if (RecordChanged == true)
                    {
                    MessageBox.Show("Sorry, you must save any changes to the Tree before you can Edit or View Slot Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                    }
                else
                    {
                    //TODO: Code to open the Slot Form and wait for the result.
                    OpenEnhancementSlotForm();
                    }
                }
            }
 
        private void OnbtnTreeBackgroundBrowseClick(object sender, EventArgs e)
            {
            string fileName;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Ping Files (*.png)|*.png";
            fileDialog.InitialDirectory = Application.StartupPath + "\\Graphics\\Interface\\";
            if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                fileName = fileDialog.SafeFileName;
                //we only wan the file name, not the extension
                fileName = fileName.Replace(".png", "");
                TreeBackgoundTextBox.Text = fileName;

                //lets trigger our leave event for the TreeBackgroundTextbox
                TextBoxChange(sender, InputType.Background);

                //System.IO.FileInfo File = new System.IO.FileInfo(fileDialog.FileName);
                //EnhancementTreeControl.BackgroundImage = Image.FromFile(fileDialog.FileName);
                }
            }

        private void OnEnhancementTreeListBoxSelectedIndexChanged(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                {
                if (EnhancementTreeListBox.SelectedIndex == -1)
                    return;
                if (DataHasChangedWarning() == false)
                    return;
                ChangeEnhancementTreeRecord(EnhancementTreeListBox.SelectedItem.ToString());
                TreeNameTextBox.Focus();
                }
            }

        private void OnTreeNameTextBoxLeave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.Name);

            }

        private void ClassRadioButton_Click(object sender, EventArgs e)
            {
            TreeTypeChange(sender, InputType.ClassTree);
            }

        private void RaceRadioButton_Click(object sender, EventArgs e)
            {
            TreeTypeChange(sender, InputType.RaceTree);

            }
        
        //Primary Button Controls
        private void OnCancelChangesButtonClick(object sender, EventArgs e)
            {
            AllowChangeEvents = false;
            NewRecord = false;
            PopulateFields(EnhancementTreeListBox.SelectedItem.ToString());
            RecordChanged = false;
            AllowChangeEvents = true;
            }

        private void OnDeleteButtonClick(object sender, EventArgs e)
            {
            int selection;

            TreeModel.Delete();

            //Lets reset the EnhancementTreeListBox
            selection = EnhancementTreeListBox.SelectedIndex - 1;
            if (selection < 0)
                selection = 0;

            EnhancementTreeListBox.Items.Clear();
            PopulateEnhancementTreeListBox();
            AllowChangeEvents = false;
            EnhancementTreeListBox.SelectedIndex = selection;
            PopulateFields(EnhancementTreeListBox.SelectedItem.ToString());
            AllowChangeEvents = true;
            }

        private void OnNewTreeButtonClick(object sender, EventArgs e)
            {
			UIManagerClass uiManager = UIManagerClass.UIManager;

			if (DataHasChangedWarning() == false)
                return;
            AllowChangeEvents = false;
            NewRecord = true;
//			NewTreeButton.BackColor = uiManager.Skin.PanelHeaderColor;
            PopulateFields("_New Enhancement Tree_");
            TreeNameTextBox.Focus();
            AllowChangeEvents = true;
            }

        private void OnUpdateButtonClick(object sender, EventArgs e)
            {
            string selection;

            //lets save our changes to the database
            SaveTree();

            //Lets reset the Reset the TreeListBox, in case a Tree Name changes or for a new Tree
            selection = TreeNameTextBox.Text;
            EnhancementTreeListBox.Items.Clear();
            PopulateEnhancementTreeListBox();
            AllowChangeEvents = false;
            EnhancementTreeListBox.SelectedItem = selection;
            AllowChangeEvents = true;

            //Now we can reset our flags
            RecordChanged = false;
            NewRecord = false;
            }

        #endregion

        #region Form Events
        private void DataInputEnhancementClassFormClosing(object sender, FormClosingEventArgs e)
            {
            if (DataHasChangedWarning() == false)
                {
                //cancel the form close!
                e.Cancel = true;
                return;
                }
            UIManagerClass.UIManager.CloseChildScreen(UIManagerClass.ChildScreen.DataInputEnhancementScreen);
            }

        #endregion

        #region Private Methods
        private void ChangeEnhancementTreeRecord(string treeName)
            {
            AllowChangeEvents = false;
            NewRecord = false;
            PopulateFields(treeName);
            AllowChangeEvents = true;
            RecordChanged = false;
            }

        private bool CheckForUniqueness(string newValue, InputType type)
            {
            switch (type)
                {
                case InputType.Name:
                        {
                        if (EnhancementTreeModel.DoesNameExist(newValue) == true)
                            return false;
                        break;
                        }
                }
            return true;
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
                SaveTree();
                return true;
                }
            else
                //user answered No, I guess we really don't care about the changed data!
                return true;
            }

        private void GrabData(string treeName)
            {
            //TreeModel Data
            TreeModel = new EnhancementTreeModel();
            if (treeName != "_New Enhancement Tree_")
                TreeModel.Initialize(treeName);

            //SlotModels Data and associated trackers
            SlotModels = new List<EnhancementSlotModel>();
            SlotChanged = new List<bool>();
            SlotDeleted = new List<bool>();
            for (int i = 0; i < 31; i++)
                {
                SlotModels.Add(new EnhancementSlotModel());
                SlotModels[i].Initialize(EnhancementSlotModel.GetIdFromTreeIdandSlotIndex(TreeModel.Id, i));
                SlotChanged.Add(false);
                SlotDeleted.Add(false);
                }
            }

        private bool HasDataChanged()
            {
            if (NewRecord == true)
                return true;

            if (RecordChanged == true)
                return true;

            if (TreeRP2.HaveRecordsChanged() == true)
                return true;

            //no data has changed, so return false
            return false;

            }

        private void OpenEnhancementSlotForm()
            {
            DataInputEnhancementSlotScreenClass slotDialog;
            DialogResult result;
            Guid id;

            id = SlotModels[EnhancementTreeControl.SelectedIndex].Id;
            slotDialog = new DataInputEnhancementSlotScreenClass(id);

            result = slotDialog.ShowDialog();
            if (result == DialogResult.OK)
                SlotModels[EnhancementTreeControl.SelectedIndex].Initialize(id);




                PopulateEnhancementTreeFields();
            }

        private void PopulateEnhancementTreeListBox()
            {
            TreeNames = EnhancementTreeModel.GetNames();
            foreach (string name in TreeNames)
                EnhancementTreeListBox.Items.Add(name);
            }

        private void PopulateFields(string treeName)
            {

            //Let get our Database data for our models and lists.
            GrabData(treeName);

            //Set our database value for Error checking unique values
            DatabaseName = TreeModel.Name;

            //Set the Main Tree Fields
            PopulateEnhancementTreeFields();

            //Set up the RequirementFields
            TreeRP2.RecordId = TreeModel.Id;
            TreeRP2.Initialize();

            //System Tracking Labels for the Tree
            RecordGuidLabel.Text = TreeModel.Id.ToString();
            ModDateLabel.Text = TreeModel.LastUpdatedDate.ToString();
            ModVersionLabel.Text = TreeModel.LastUpdatedVersion.ToString();
            }

        private void PopulateEnhancementTreeFields()
            {
            TreeNameTextBox.Text = TreeModel.Name;
            TreeBackgoundTextBox.Text = TreeModel.Background;
            if (TreeModel.RaceTree == true)
                RaceRadioButton.Checked = true;
            else
                ClassRadioButton.Checked = true;

            //Let set up the Tree control
            EnhancementTreeControl.Clear();
            if (NewRecord == true)
                {
                EnhancementTreeControl.AddSlot(0);
                SlotChanged[0] = true; //Mark this slot as changed so that it will be saved. as all trees have at least this 1 slot.
                EnhancementTreeControl.ChangeSlotType(0, SlotControl.SCType.Active);
                EnhancementTreeControl.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Graphics\\Interface\\" + "BackgroundEmpty" + ".png");
                }
            else
                {
                //set up the slot control inside the tree control
                for (int i = 0; i < 31; i++)
                    {
                    if (SlotModels[i].Id != Guid.Empty)
                        {
                        //TODO: Add the slot and update its Icon if available
                        EnhancementTreeControl.AddSlot(i);

                        if(SlotModels[i].UseEnhancementInfo)
                        {
                            List<EnhancementModel> EnhancementModels;
                            EnhancementModels = new List<EnhancementModel>();
                            EnhancementModels = EnhancementModel.GetAll(SlotModels[i].Id);
                            if(EnhancementModels.Count > 0)
                            {
                                if (EnhancementModels[0].Icon != null)
                                {
                                    EnhancementTreeControl.ChangeSlotIcon(i, EnhancementModels[0].Icon);
                                }
                                else
                                {
                                    EnhancementTreeControl.ChangeSlotIcon(i, "noImage");
                                }
                            }
                            else
                            {
                                EnhancementTreeControl.ChangeSlotIcon(i, "noImageDesign");
                            }

                        }
                        else if (SlotModels[i].Icon != null)
                        {
                            EnhancementTreeControl.ChangeSlotIcon(i, SlotModels[i].Icon);
                        }
                        
                        if (SlotModels[i].Active == true)
                            EnhancementTreeControl.ChangeSlotType(i, SlotControl.SCType.Active);
                        else
                            EnhancementTreeControl.ChangeSlotType(i, SlotControl.SCType.Passive);
                        }
                    else
                    {
                        EnhancementTreeControl.ChangeSlotIcon(i, "noImageDesign");
                        EnhancementTreeControl.ChangeSlotType(i, SlotControl.SCType.Active);
                    }
                    }

                //set the background image of the tree control.
                try
                    {
                    EnhancementTreeControl.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Graphics\\Interface\\" + TreeModel.Background + ".png");
                    }
                catch (FileNotFoundException)
                    {
                    EnhancementTreeControl.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Graphics\\Interface\\BackgroundEmpty.png");
                    }
                }

            //lets set the index of the tree control
            //if (EnhancementTreeControl.IsSlotShowing(0) == true)
                EnhancementTreeControl.SelectedIndex = 0;
            //else
            //    EnhancementTreeControl.SelectedIndex = -1;
            //Set the treeName field in the TreeControl
            EnhancementTreeControl.TreeText = TreeModel.Name;

            }

        private void SaveTree()
            {
            
            if (NewRecord == true || RecordChanged == true)
                {
                TreeModel.Save();

                //Lets update the Sub Tables next (EnhancementSlot Records)
                for (int i = 0; i < SlotChanged.Count; i++)
                    {
                    if (SlotDeleted[i] == true)
                        {
                        if (SlotModels[i].Id != Guid.Empty)
                            {
                            SlotModels[i].Delete();
                            SlotChanged[i] = false;
                            }
                        }
                    if (SlotChanged[i] == true)
                        {
                        SlotModels[i].EnhancementTreeId = TreeModel.Id;
                        SlotModels[i].SlotIndex = i;
                        SlotModels[i].Save();
                        }
                    }

                }
            //Lets see if we need to update EnhancementTreeRequirement records
            if (TreeRP2.HaveRecordsChanged() == true)
                {
                TreeRP2.RecordId = TreeModel.Id;
                TreeRP2.SaveRecords();
                }

            //cache the TreeName String for later comparison since we have updated the database
            DatabaseName = TreeModel.Name;
            }

        private void TextBoxChange(object sender, InputType type)
            {
            string newStringValue;
			UIManagerClass uiManager = UIManagerClass.UIManager;

            switch (type)
                {
                case InputType.Name:
                        {
                        newStringValue = TreeNameTextBox.Text;
                        if (newStringValue != TreeModel.Name)
                            {
                            if (newStringValue == DatabaseName)
                                {
                                TreeModel.Name = newStringValue;
//								TreeNameTextBox.BackColor = uiManager.Skin.ControlBackgroundColor;
                                break;
                                }
                            if (CheckForUniqueness(newStringValue, InputType.Name) == true)
                                {
                                TreeModel.Name = newStringValue;
                                RecordChanged = true;
//								TreeNameTextBox.BackColor = uiManager.Skin.ControlBackgroundColor;
                                }
                            else
                                {
                                AllowChangeEvents = false;
                                TreeNameTextBox.Text = TreeModel.Name;
                                TreeNameTextBox.BackColor = Color.OrangeRed;
                                AllowChangeEvents = true;
                                TreeNameTextBox.Focus();
                                }
                            
                            EnhancementTreeControl.TreeText = TreeNameTextBox.Text;
                            }
                        break;
                        }
                case InputType.Background:
                        {
                        newStringValue = TreeBackgoundTextBox.Text;
                        if (newStringValue != TreeModel.Background)
                            {
                            TreeModel.Background = newStringValue;
                            RecordChanged = true;
                            //Lets set the EnhancementTree Background image
                            EnhancementTreeControl.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Graphics\\Interface\\" + newStringValue + ".png");
                            }
                        break;
                        }
                }
            }

        private void TreeTypeChange(object sender, InputType type)
            {
            switch (type)
                {
                case InputType.ClassTree:
                        {
                        if (TreeModel.RaceTree == true)
                            {
                            TreeModel.RaceTree = false;
                            RecordChanged = true;
                            }
                        break;
                        }
                case InputType.RaceTree:
                        {
                        if (TreeModel.RaceTree == false)
                            {
                            TreeModel.RaceTree = true;
                            RecordChanged = true;
                            }
                        break;
                        }
                }
            }

        #endregion

        #region Public Members
        public void ApplySkin()
            {
			UIManagerClass uiManager = UIManagerClass.UIManager;
			
/*			//form
            this.BackColor = uiManager.Skin.BackgroundColor;
            //TreeListBox
            this.EnhancementTreeListBoxLabel.ForeColor = uiManager.Skin.PanelHeaderFontColor;
            this.EnhancementTreeListBoxLabel.BackColor = uiManager.Skin.PanelHeaderColor;
            this.EnhancementTreeListBox.BackColor = uiManager.Skin.BackgroundColor;
            this.EnhancementTreeListBox.ForeColor = uiManager.Skin.StandardFontColor;
            //TreePanel
            this.EnhancementTreePanel.BackColor = uiManager.Skin.BackgroundColor;
            this.EnhancementTreeLabel.BackColor = uiManager.Skin.PanelHeaderColor;
            this.EnhancementTreeLabel.ForeColor = uiManager.Skin.PanelHeaderFontColor;
            this.TreeBackgroundLabel.ForeColor = uiManager.Skin.StandardFontColor;
            this.TreeNameLabel.ForeColor = uiManager.Skin.StandardFontColor;
            this.TreeNameTextBox.BackColor = uiManager.Skin.ControlBackgroundColor;
            this.TreeNameTextBox.ForeColor = uiManager.Skin.ControlForeColor;
            this.TreeBackgoundTextBox.BackColor = uiManager.Skin.ControlBackgroundColor;
            this.TreeBackgoundTextBox.ForeColor = uiManager.Skin.ControlForeColor;
 */ 
            }

        #endregion

        private void DataInputEnhancementScreenClass_Load(object sender, EventArgs e)
            {
            Debug.WriteLine("EnhancemenetScreen LoadEvent");
            }

        }
    }
