using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.Model;
using DDOCharacterPlanner.Screens.Controls;

namespace DDOCharacterPlanner.Screens.DataInput
	{
	public partial class DataInputFeatScreenClass : Form
        {
        #region Enums
        private enum InputType
            {
            Name,
            Description,
            FeatCategory,
            IsParentFeat,
            ParentFeat,
            ImageFileName,
            FeatTypes,
            Multiples,
            FeatTargets,
            Duration,
            Stance,
            };
        
        #endregion

        #region Member Variables
        private FeatModel Model;

        private List<FeatTypeSelection> FeatTypesSelected;
        private List<FeatTargetSelection> FeatTargetsSelected;
		private List<string> FeatNames;
        private List<string> FeatCategoryNames;
        private List<string> ParentFeatNames;
        private List<string> FeatTypeNames;
        private List<string> TargetNames;
        private List<string> StanceNames;
		private bool RecordChanged;
        private bool NewRecord;
        private bool AllowChangeEvents;
        private string DatabaseName;
        private IconClass FeatIcon;
        private PointF FeatIconLocation = new PointF(0.92f, 0.02f);
        private Point ChildWindowLocation = new Point(450, 100);
		#endregion

		#region Constructors
		public DataInputFeatScreenClass()
			{
			InitializeComponent();
            ApplySkin();

            NewRecord = false;
            AllowChangeEvents = false;

            //let populate the Main Feat List Box and sets its selected value to the first record
            PopulateFeatListBox();
            FeatListBox.SelectedIndex = 0;

            //lets populate the other Comboboxes on the form.
            PopulateCategoryFeatComboBox();
            PopulateParentFeatComboBox();
            PopulateStanceComboBox();

            //lets populate the CheckedListboxes
            PopulateFeatTargetCheckedListBox();
            PopulateFeatTypeCheckedListBox();
            
            //Lets fill our Main fields out now
            PopulateFields(FeatListBox.SelectedItem.ToString());

            //Set our tracking variables to false
            RecordChanged = false;
            
            //turn on our change events
            AllowChangeEvents = true;
			}

		#endregion

		#region Control Events
        private void DescriptionHTMLEditor_Leave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.Description);
            }

        private void OnCancelChangesButtonClick(object sender, EventArgs e)
            {
            AllowChangeEvents = false;
            NewRecord = false;
            PopulateFields(FeatListBox.SelectedItem.ToString());
            RecordChanged = false;
            AllowChangeEvents = true;
            }

        private void OnCategoryFeatComboBoxSelectedChangeCommmitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.FeatCategory);
            }

        private void OnDeleteFeatButtonClick(object sender, EventArgs e)
            {
            int selection;

            Model.Delete();

            //Lets reset the FeatListBox
            selection = FeatListBox.SelectedIndex - 1;
            if (selection < 0)
                selection = 0;

            FeatListBox.Items.Clear();
            PopulateFeatListBox();
            AllowChangeEvents = false;
            FeatListBox.SelectedIndex = selection;
            PopulateFields(FeatListBox.SelectedItem.ToString());
            AllowChangeEvents = true;
            }

        private void OnDurationTextBoxLeave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.Duration);
            }

        private void OnFeatListBoxSelectedIndexChanged(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                {
                if (FeatListBox.SelectedIndex == -1)
                    return;
                if (DataHasChangedWarning() == false)
                    return;
                ChangeFeatRecord(FeatListBox.SelectedItem.ToString());
                NameInputBox.Focus();
                }
        
            }

        private void OnFeatTargetsCheckedListBoxItemCheck(object sender, ItemCheckEventArgs e)
            {
            if (AllowChangeEvents == true)
                CheckedListBoxChange(sender, InputType.FeatTargets, e);
            }

        private void OnFeatTypesCheckedListBoxItemCheck(object sender, ItemCheckEventArgs e)
            {
            if (AllowChangeEvents == true)
                CheckedListBoxChange(sender, InputType.FeatTypes, e);
            }

        private void OnIconBrowseButtonClick(object sender, EventArgs e)
            {
            string fileName;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Ping Files (*.png)|*.png";
            fileDialog.InitialDirectory = Application.StartupPath + "\\Graphics\\Feats\\";
            if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                fileName = fileDialog.SafeFileName;
                //we only want the file name, not the extension
                fileName = fileName.Replace(".png", "");
                IconFileNameInputBox.Text = fileName;
                
                //lets trigger our change event for the FileNameInputBox
                TextBoxChange(sender, InputType.ImageFileName);
                }
            }

        private void OnIconFileNameInputBoxLeave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.ImageFileName);
            }

        private void OnMultiplesCheckBoxCheckedChanged(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                CheckBoxChange(sender, InputType.Multiples);
            }

        private void OnNameInputBoxLeave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.Name);
            }

        private void OnNewFeatButtonClick(object sender, EventArgs e)
            {
            if (DataHasChangedWarning() == false)
                return;
            AllowChangeEvents = false;
            PopulateFields("_New Feat_");
            NameInputBox.Focus();
            AllowChangeEvents = true;
            NewRecord = true;
            }

        private void OnParentFeatCheckBoxCheckedChanged(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                CheckBoxChange(sender, InputType.IsParentFeat);
            }
                
        private void OnParentFeatComboBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.ParentFeat);
            }

        private void OnRecordFilterBoxTextChanged(object sender, EventArgs e)
            {
            FeatListBox.Items.Clear();
            foreach (string name in FeatNames)
                {
                if (Regex.Match(name, RecordFilterBox.Text, RegexOptions.IgnoreCase).Success)
                    FeatListBox.Items.Add(name);
                }
            }

        private void OnPaint(object sender, PaintEventArgs paintEventArgs)
            {
            DrawIcon(paintEventArgs);
            }

        private void OnUpdateFeatButtonClick(object sender, EventArgs e)
            {
            string selection;

            //Lets save our changed fields to the database
            SaveRecord();

            //Lets Reset the FeatListBox, in case a feat name changed or a new feat.
            selection = NameInputBox.Text;
            FeatListBox.Items.Clear();
            PopulateFeatListBox();
            AllowChangeEvents = false;
            FeatListBox.SelectedItem = selection;
            AllowChangeEvents = true;

            //Now we can reset our flags
            RecordChanged = false;
            NewRecord = false;

            }

        private void StanceComboBox_SelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.Stance);
            }

		#endregion

        #region Form Events
        private void DataInputFeatScreenClassFormClosing(object sender, FormClosingEventArgs e)
            {
            if (DataHasChangedWarning() == false)
                {
                //cancel the form close!
                e.Cancel = true;
                return;
                }
            UIManagerClass.UIManager.CloseChildScreen(UIManagerClass.ChildScreen.DataInputFeatScreen);
            }

        #endregion

        #region Private Methods
        private void PopulateFields(string featName)
			{
            List<FeatFeatTypeModel> featTypeModels;
            List<FeatTargetModel> featTargetModels;

            Model = new FeatModel();
            Model.Initialize(featName);

            featTypeModels = FeatFeatTypeModel.GetAllByFeatId(Model.Id);
            featTargetModels = FeatTargetModel.GetAllByFeatId(Model.Id);
            
            //set our Database values for Error checkign unique values.
            DatabaseName = Model.Name;

            //set the main control values
            NameInputBox.Text = Model.Name;
            CategoryFeatComboBox.SelectedItem = FeatCategoryModel.GetNameFromId(Model.FeatCategoryId);
            ParentFeatCheckBox.Checked = Model.IsParentFeat;
            MultiplesCheckBox.Checked = Model.Multiple;
            ParentFeatComboBox.SelectedItem = FeatModel.GetNameFromId(Model.ParentFeat);
            StanceComboBox.SelectedItem = StanceModel.GetStanceNameFromId(Model.StanceId);
            IconFileNameInputBox.Text = Model.ImageFileName;
            FeatIcon = new IconClass("Feats\\" + Model.ImageFileName);
            FeatIcon.SetLocation(this.Width, this.Height, FeatIconLocation);
            DurationTextBox.Text = Model.Duration;

            //System tracking labels
            RecordGUIDLabel.Text = Model.Id.ToString();
            ModDateLabel.Text = Model.LastUpdatedDate.ToString();
            ModVersionLabel.Text = Model.LastUpdatedVersion;

            //DescriptionWebBrowser control
            DescriptionHtmlEditor.Text = Model.Description;

            //Set the FeatTypes
            //clear previous values if any.
            FeatTypesSelected = new List<FeatTypeSelection>();
            foreach (int i in FeatTypesCheckedListBox.CheckedIndices)
                FeatTypesCheckedListBox.SetItemChecked(i, false);

            if (featTypeModels != null)
                {
                foreach (FeatFeatTypeModel ftmodel in featTypeModels)
                    {
                    FeatTypesSelected.Add(new FeatTypeSelection());
                    FeatTypesSelected[FeatTypesSelected.Count - 1].Model = ftmodel;
                    FeatTypesSelected[FeatTypesSelected.Count - 1].DeleteRecord = false;
                    FeatTypesCheckedListBox.SetItemChecked(FeatTypesCheckedListBox.FindStringExact(FeatTypeModel.GetNameFromId(ftmodel.FeatTypeId)), true);
                    }
                }

            //Set the FeatTargets, clear previous values if any.
            FeatTargetsSelected = new List<FeatTargetSelection>();
            foreach (int i in FeatTargetsCheckedListBox.CheckedIndices)
                FeatTargetsCheckedListBox.SetItemChecked(i, false);

            if (featTargetModels != null)
                {
                foreach (FeatTargetModel ftmodel in featTargetModels)
                    {
                    FeatTargetsSelected.Add(new FeatTargetSelection());
                    FeatTargetsSelected[FeatTargetsSelected.Count - 1].Model = ftmodel;
                    FeatTargetsSelected[FeatTargetsSelected.Count - 1].DeleteRecord = false;
                    FeatTargetsCheckedListBox.SetItemChecked(FeatTargetsCheckedListBox.FindStringExact(TargetModel.GetNameFromId(ftmodel.TargetId)), true);
                    }
                }

            //Set the the requirements panel
            FeatRequirementsRP2.Clear();
            FeatRequirementsRP2.RecordId = Model.Id;
            FeatRequirementsRP2.Initialize();

            //Set the modifiers panel
            MP2Modifiers.Clear();
            MP2Modifiers.RecordId = Model.Id;
            MP2Modifiers.Initialize();

            //Invalidate the screen to update graphics
            Invalidate();

			}

        private void PopulateFeatListBox()
            {
            FeatNames = FeatModel.GetNames();
            foreach (string name in FeatNames)
                FeatListBox.Items.Add(name);
            }

        private void PopulateCategoryFeatComboBox()
            {
            FeatCategoryNames = FeatCategoryModel.GetNames();
            CategoryFeatComboBox.Items.Add("");
            foreach (string name in FeatCategoryNames)
                CategoryFeatComboBox.Items.Add(name);
            }

        private void PopulateStanceComboBox()
            {
            StanceNames = StanceModel.GetNames();
            StanceComboBox.Items.Add("");
            foreach (string name in StanceNames)
                StanceComboBox.Items.Add(name);
            }

        private void PopulateFeatTargetCheckedListBox()
            {
            TargetNames = TargetModel.GetNames();
            foreach (string name in TargetNames)
                FeatTargetsCheckedListBox.Items.Add(name);
            }

        private void PopulateFeatTypeCheckedListBox()
            {
            FeatTypeNames = FeatTypeModel.GetNames();
            foreach (string name in FeatTypeNames)
                FeatTypesCheckedListBox.Items.Add(name);
            }

        private void PopulateParentFeatComboBox()
            {
            ParentFeatNames = FeatModel.GetNamesByIsParentFeat(true);
            ParentFeatComboBox.Items.Add("");
            if (ParentFeatNames != null)
                {
                foreach (string name in ParentFeatNames)
                    ParentFeatComboBox.Items.Add(name);
                }
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

        private bool HasDataChanged()
            {
            if (NewRecord == true)
                return true;

            if (RecordChanged == true)
                return true;

            if (FeatRequirementsRP2.HaveRecordsChanged() == true)
                return true;

            if (MP2Modifiers.HaveRecordsChanged() == true)
                return true;

            //no data has changed, so return false
            return false;
            }

        private void SaveRecord()
            {
            if (NewRecord == true || RecordChanged == true)
                Model.Save();
            
            //lets update the feattypes that need updating
            foreach (FeatTypeSelection selection in FeatTypesSelected)
                {
                //See if we need to delete a record
                if (selection.DeleteRecord == true && selection.Model.Id != Guid.Empty)
                    {
                    selection.Model.Delete();
                    }
                //see if we need to add a record
                if (selection.DeleteRecord == false && selection.Model.Id == Guid.Empty)
                    {
                    selection.Model.FeatId = Model.Id;
                    selection.Model.Save();
                    }
                }

            //lets update the Feat Targets that need updating
            foreach (FeatTargetSelection selection in FeatTargetsSelected)
                {
                //see if we need to delete a record
                if (selection.DeleteRecord == true && selection.Model.Id != Guid.Empty)
                    selection.Model.Delete();

                //see if we need to add a record
                if (selection.DeleteRecord == false && selection.Model.Id == Guid.Empty)
                    {
                    selection.Model.FeatId = Model.Id;
                    selection.Model.Save();
                    }
                }

            //See if we need save records for Requirements Panels
            if (NewRecord == true)
                FeatRequirementsRP2.RecordId = Model.Id;
            if (FeatRequirementsRP2.HaveRecordsChanged() == true)
                FeatRequirementsRP2.SaveRecords();

            //See if we need to save records for the Modifiers panel
            if (NewRecord == true)
                MP2Modifiers.RecordId = Model.Id;
            if (MP2Modifiers.HaveRecordsChanged() == true)
                MP2Modifiers.SaveRecords();

            //cache the name strings for later comparison since we have updated the database
            DatabaseName = Model.Name;
            }

        private void ChangeFeatRecord(string featName)
            {
            AllowChangeEvents = false;
            NewRecord = false;
            ParentFeatComboBox.Items.Clear();
            PopulateParentFeatComboBox();
            PopulateFields(featName);
            AllowChangeEvents = true;
            RecordChanged = false;
            }

        private void DrawIcon(PaintEventArgs paintEventArgs)
            {
            FeatIcon.Draw(paintEventArgs);
            }

        private void CheckBoxChange(object sender, InputType type)
            {
            bool boxChecked;

            switch (type)
                {
                case InputType.IsParentFeat:
                        {
                        boxChecked = ParentFeatCheckBox.Checked;
                        if (boxChecked != Model.IsParentFeat)
                            {
                            Model.IsParentFeat = boxChecked;
                            RecordChanged = true;
                            }
                        break;
                        }
                case InputType.Multiples:
                        {
                        boxChecked = MultiplesCheckBox.Checked;
                        if (boxChecked != Model.Multiple)
                            {
                            Model.Multiple = boxChecked;
                            RecordChanged = true;
                            }
                        break;
                        }
                }
            }

        private void CheckedListBoxChange(object sender, InputType type, ItemCheckEventArgs e)
            {

            switch (type)
                {
                case InputType.FeatTargets:
                        {
                        if (e.NewValue == CheckState.Unchecked)
                            {
                            foreach (FeatTargetSelection selection in FeatTargetsSelected)
                                {
                                if (TargetModel.GetNameFromId(selection.Model.TargetId) == FeatTargetsCheckedListBox.Items[e.Index].ToString())
                                    {
                                    selection.DeleteRecord = true;
                                    RecordChanged = true;
                                    return;
                                    }
                                }
                            }
                        else
                            {
                            //let see if model exist already, if not then we need to add one otherwise set deleterecord to false.
                            foreach (FeatTargetSelection selection in FeatTargetsSelected)
                                {
                                if (TargetModel.GetNameFromId(selection.Model.TargetId) == FeatTargetsCheckedListBox.Items[e.Index].ToString())
                                    {
                                    selection.DeleteRecord = false;
                                    RecordChanged = true;
                                    return;
                                    }
                                }
                            // we made it this far, so we need to add a model
                            FeatTargetsSelected.Add(new FeatTargetSelection());
                            FeatTargetsSelected[FeatTargetsSelected.Count - 1].Model = new FeatTargetModel();
                            FeatTargetsSelected[FeatTargetsSelected.Count - 1].Model.FeatId = Model.Id;
                            FeatTargetsSelected[FeatTargetsSelected.Count - 1].Model.TargetId = TargetModel.GetIdFromName(FeatTargetsCheckedListBox.Items[e.Index].ToString());
                            FeatTargetsSelected[FeatTargetsSelected.Count - 1].DeleteRecord = false;
                            RecordChanged = true;
                            }
                        break;
                        }

                case InputType.FeatTypes:
                        {
                        if (e.NewValue == CheckState.Unchecked)
                            {
                            foreach (FeatTypeSelection selection in FeatTypesSelected)
                                {
                                if (FeatTypeModel.GetNameFromId(selection.Model.FeatTypeId) == FeatTypesCheckedListBox.Items[e.Index].ToString())
                                    {
                                    selection.DeleteRecord = true;
                                    RecordChanged = true;
                                    return;
                                    }
                                }
                            }
                        else
                            {
                            //let see if model exist already, if not then we need to add one otherwise set deleterecord to false.
                            foreach (FeatTypeSelection selection in FeatTypesSelected)
                                {
                                if (FeatTypeModel.GetNameFromId(selection.Model.FeatTypeId) == FeatTypesCheckedListBox.Items[e.Index].ToString())
                                    {
                                    selection.DeleteRecord = false;
                                    RecordChanged = true;
                                    return;
                                    }
                                }
                            // we made it this far, so we need to add a model
                            FeatTypesSelected.Add(new FeatTypeSelection());
                            FeatTypesSelected[FeatTypesSelected.Count - 1].Model = new FeatFeatTypeModel();
                            FeatTypesSelected[FeatTypesSelected.Count - 1].Model.FeatId = Model.Id;
                            FeatTypesSelected[FeatTypesSelected.Count - 1].Model.FeatTypeId = FeatTypeModel.GetIdFromName(FeatTypesCheckedListBox.Items[e.Index].ToString());
                            FeatTypesSelected[FeatTypesSelected.Count - 1].DeleteRecord = false;
                            RecordChanged = true;
                            }
                        break;
                        }
                }
            }

        private void ComboBoxChange(object sender, InputType type)
            {
            string newValueString;
            Guid newValueGuid;

            switch (type)
                {
                case InputType.FeatCategory:
                        {
                        newValueString = CategoryFeatComboBox.SelectedItem.ToString();
                        if (newValueString == "")
                            newValueGuid = Guid.Empty;
                        else
                            newValueGuid = FeatCategoryModel.GetIdFromName(newValueString);

                        if (newValueGuid != Model.FeatCategoryId)
                            {
                            Model.FeatCategoryId = newValueGuid;
                            RecordChanged = true;
                            }
                        break;
                        }
                case InputType.ParentFeat:
                        {
                        newValueString = ParentFeatComboBox.SelectedItem.ToString();
                        if (newValueString == "")
                            newValueGuid = Guid.Empty;
                        else
                            newValueGuid = FeatModel.GetIdFromName(newValueString);

                        if (newValueGuid != Model.ParentFeat)
                            {
                            Model.ParentFeat = newValueGuid;
                            RecordChanged = true;
                            }
                        break;
                        }
                case InputType.Stance:
                        {
                        newValueString = StanceComboBox.SelectedItem.ToString();
                        if (newValueString == "")
                            newValueGuid = Guid.Empty;
                        else
                            newValueGuid = StanceModel.GetIdFromStanceName(newValueString);

                        if (newValueGuid != Model.StanceId)
                            {
                            Model.StanceId = newValueGuid;
                            RecordChanged = true;
                            }
                        break;
                        }
                }
            }

        private void TextBoxChange(object sender, InputType type)
            {
            string newStringValue;

            switch (type)
                {
                case InputType.Name:
                        {
                        newStringValue = NameInputBox.Text;
                        if (newStringValue != Model.Name)
                            {
                            if (newStringValue == DatabaseName)
                                {
                                Model.Name = newStringValue;
                                NameInputBox.BackColor = Color.White;
                                NameErrorLabel.Text = "";
                                break;
                                }
                            if (CheckForUniqueness(newStringValue, InputType.Name) == true)
                                {
                                Model.Name = newStringValue;
                                RecordChanged = true;
                                NameInputBox.BackColor = Color.FromArgb(99, 99, 99);
                                NameErrorLabel.Text = "";
                                }
                            else
                                {
                                //Let the user know he need to choose a new name.
                                AllowChangeEvents = false;
                                NameInputBox.Text = Model.Name;
                                NameInputBox.BackColor = Color.OrangeRed;
                                NameErrorLabel.Text = "Error: Name is already taken, please choose another";
                                AllowChangeEvents = true;
                                NameInputBox.Focus();
                                }
                            }
                        else
                            {
                            NameInputBox.BackColor = Color.FromArgb(99,99,99);
                            NameErrorLabel.Text = "";
                            }
                        break;
                        }
                case InputType.ImageFileName:
                        {
                        newStringValue = IconFileNameInputBox.Text;
                        if (newStringValue != Model.ImageFileName)
                            {
                            Model.ImageFileName = newStringValue;
                            RecordChanged = true;
                            FeatIcon = new IconClass("Feats\\" + newStringValue);
                            FeatIcon.SetLocation(this.Width, this.Height, FeatIconLocation);
                            Invalidate();
                            }
                        break;
                        }
                case InputType.Duration:
                        {
                        newStringValue = DurationTextBox.Text;
                        if (newStringValue != Model.Duration)
                            {
                            Model.Duration = newStringValue;
                            RecordChanged = true;
                            }
                        break;
                        }
                case InputType.Description:
                        {
                        newStringValue = DescriptionHtmlEditor.Text;
                        if (newStringValue != Model.Description)
                            {
                            Model.Description = newStringValue;
                            RecordChanged = true;
                            }
                        break;
                        }
                }
            }
		
        private bool CheckForUniqueness(string newValue, InputType type)
            {
            switch (type)
                {
                case InputType.Name:
                        {
                        if (FeatModel.DoesNameExist(newValue) == true)
                            return false;
                        break;
                        }
                }
            return true;
            }
        #endregion

        #region Public Methods
        public void ApplySkin()
            {
            SkinStyleClass style;

            //Screen
            style = UIManagerClass.UIManager.Skin.GetSkinStyle("DataInputScreenBackgroundColor");
            this.BackColor = style.Color1;

            //Panels
            style = UIManagerClass.UIManager.Skin.GetSkinStyle("DataInputScreenPanelBackColor");
            this.FeatListPanel.BackColor = style.Color1;
            this.DescriptionPanel.BackColor = style.Color1;
            this.RequirementsPanel.BackColor = style.Color1;
            this.FeatTypesPanel.BackColor = style.Color1;
            this.FeatTargetsPanel.BackColor = style.Color1;
            this.DescriptionHtmlEditor.BackgroundColor = style.Color1;

            //Panel Headers
			style = UIManagerClass.UIManager.Skin.GetSkinStyle("DataInputScreenPanelHeaderLabel");
			FeatListPanelLabel.ForeColor = style.Color1;
			DescriptionLabel.ForeColor = style.Color1;
			RequirementsLabel.ForeColor = style.Color1;
			FeatTargetsLabel.ForeColor = style.Color1;
			FeatTypesLabel.ForeColor = style.Color1;
			FeatListPanelLabel.BackColor = style.Color2;
			DescriptionLabel.BackColor = style.Color2;
			RequirementsLabel.BackColor = style.Color2;
			FeatTargetsLabel.BackColor = style.Color2;
			FeatTypesLabel.BackColor = style.Color2;
			FeatListPanelLabel.Font = style.Font;
			DescriptionLabel.Font = style.Font;
			RequirementsLabel.Font = style.Font;
			FeatTargetsLabel.Font = style.Font;
			FeatTypesLabel.Font = style.Font;

            //Control Labels
            style = UIManagerClass.UIManager.Skin.GetSkinStyle("DataInputScreenLabel");
			this.NameLabel.ForeColor = style.Color1;
			this.DurationLabel.ForeColor = style.Color1;
			this.IconLabel.ForeColor = style.Color1;
			this.FeatCategoryLabel.ForeColor = style.Color1;
			this.SubFeatLabel.ForeColor = style.Color1;
			this.StanceLabel.ForeColor = style.Color1;
			this.FilterLabel.ForeColor = style.Color1;
			this.NameLabel.BackColor = style.Color2;
			this.DurationLabel.BackColor = style.Color2;
			this.IconLabel.BackColor = style.Color2;
			this.FeatCategoryLabel.BackColor = style.Color2;
			this.SubFeatLabel.BackColor = style.Color2;
			this.StanceLabel.BackColor = style.Color2;
			this.FilterLabel.BackColor = style.Color2;
			this.NameLabel.Font = style.Font;
            this.DurationLabel.Font = style.Font;
            this.IconLabel.Font = style.Font;
            this.FeatCategoryLabel.Font = style.Font;
            this.SubFeatLabel.Font = style.Font;
            this.StanceLabel.Font = style.Font;
            this.FilterLabel.Font = style.Font;
 
            //Controls
            style = UIManagerClass.UIManager.Skin.GetSkinStyle("DataInputScreenControls");
			this.NameInputBox.ForeColor = style.Color1;
			this.DurationTextBox.ForeColor = style.Color1;
			this.IconFileNameInputBox.ForeColor = style.Color1;
			this.RecordFilterBox.ForeColor = style.Color1;
			this.DescriptionHtmlEditor.MainFontColor = style.Color2;
            this.NameInputBox.BackColor = style.Color2;
			this.DurationTextBox.BackColor = style.Color2;
			this.IconFileNameInputBox.BackColor = style.Color2;
			this.RecordFilterBox.BackColor = style.Color2;
            this.NameInputBox.Font = style.Font;
            this.DurationTextBox.Font = style.Font;
            this.IconFileNameInputBox.Font = style.Font;
            this.RecordFilterBox.Font = style.Font;

            //Buttons
            style = UIManagerClass.UIManager.Skin.GetSkinStyle("DataInputScreenButton1");
			this.NewFeatButton.ForeColor = style.Color1;
			this.UpdateFeatButton.ForeColor = style.Color1;
			this.DeleteFeatButton.ForeColor = style.Color1;
			this.CancelChangesButton.ForeColor = style.Color1;
			this.NewFeatButton.BackColor = style.Color2;
			this.UpdateFeatButton.BackColor = style.Color2;
			this.CancelChangesButton.BackColor = style.Color2;
			this.DeleteFeatButton.BackColor = style.Color2;
			this.NewFeatButton.Font = style.Font;
            this.UpdateFeatButton.Font = style.Font;
            this.DeleteFeatButton.Font = style.Font;
            this.CancelChangesButton.Font = style.Font;

            //ReadOnly Labels
            style = UIManagerClass.UIManager.Skin.GetSkinStyle("DataInputScreenReadOnly");
			this.GuidLabel.ForeColor = style.Color1;
			this.ModificationLabel.ForeColor = style.Color1;
			this.VersionLabel.ForeColor = style.Color1;
			this.RecordGUIDLabel.ForeColor = style.Color1;
			this.ModDateLabel.ForeColor = style.Color1;
			this.ModVersionLabel.ForeColor = style.Color1;
			this.GuidLabel.BackColor = style.Color2;
			this.ModificationLabel.BackColor = style.Color2;
			this.VersionLabel.BackColor = style.Color2;
			this.RecordGUIDLabel.BackColor = style.Color2;
			this.ModDateLabel.BackColor = style.Color2;
			this.ModVersionLabel.BackColor = style.Color2;
            this.GuidLabel.Font = style.Font;
            this.ModificationLabel.Font = style.Font;
            this.VersionLabel.Font = style.Font;
            this.RecordGUIDLabel.Font = style.Font;
            this.ModDateLabel.Font = style.Font;
            this.ModVersionLabel.Font = style.Font;

            }

        #endregion

        #region Public Static Methods
        public static void RegisterSkinGroups()
            {         
            UIManagerClass.UIManager.Skin.RegisterSkinGroup("DataInputScreenBackgroundColor", SkinSettings.FactoryName.ScreenBackgroundColor);
            UIManagerClass.UIManager.Skin.RegisterSkinGroup("DataInputScreenPanelBackColor", SkinSettings.FactoryName.PanelBackgroundColor);
			UIManagerClass.UIManager.Skin.RegisterSkinGroup("DataInputScreenPanelHeaderLabel", SkinSettings.FactoryName.PanelHeaderFont);
			UIManagerClass.UIManager.Skin.RegisterSkinGroup("DataInputScreenLabel", SkinSettings.FactoryName.StandardFont);
            UIManagerClass.UIManager.Skin.RegisterSkinGroup("DataInputScreenReadOnly", SkinSettings.FactoryName.ReadOnlyFont);
            UIManagerClass.UIManager.Skin.RegisterSkinGroup("DataInputScreenButton1", SkinSettings.FactoryName.DIButton1);
            UIManagerClass.UIManager.Skin.RegisterSkinGroup("DataInputScreenButton2", SkinSettings.FactoryName.DIButton2);
            UIManagerClass.UIManager.Skin.RegisterSkinGroup("DataInputScreenControls", SkinSettings.FactoryName.DIControls);
            }

        #endregion
        }

    public class FeatTypeSelection
        {
        public FeatFeatTypeModel Model
            {
            get;
            set;
            }

        public bool DeleteRecord
            {
            get;
            set;
            }
        }

    public class FeatTargetSelection
        {
        public FeatTargetModel Model
            {
            get;
            set;
            }
        public bool DeleteRecord
            {
            get;
            set;
            }
        }
	}
