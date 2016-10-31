using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using DDOCharacterPlanner.Model;
using DDOCharacterPlanner.Screens.Controls;
using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Screens.DataInput
	{
	public partial class DataInputRaceScreenClass : Form
        {
        #region Enums
        private enum Direction
            {
            Up,
            Down
            };
        private enum InputType
            {
            Name,
            Description,
            StrMin,
            StrMax,
            DexMin,
            DexMax,
            ConMin,
            ConMax,
            IntMin,
            IntMax,
            WisMin,
            WisMax,
            ChaMin,
            ChaMax,
            StartingClass,
            MaleIconName,
            FemaleIconName,
            Abbreviation,
            SkillPoints,
            BonusFeatChoice,
            PastLifeFeat,
            Iconic
            };

        #endregion

        #region Member Variables
        private RaceModel ModelofRace;
        private List<RaceLevelDetailModel> ModelofRaceDetail;
        private List<string> RaceNames;
        private List<string> FeatNames;
        private List<string> FeatTypeNames;
        private bool NewRecord;
        private bool HasRaceDataChanged;
        private List<bool> HasRaceDetailsChanged;
        private List<string> ClassNames;
        private bool AllowChangeEvents;
        private string DatabaseName;
        private string DatabaseAbbreviation;
        private TextEditWindow DescriptionEditWindow;
        private string OldDescription;
        private Point ChildWindowLocation = new Point(450, 100);
        private IconClass MaleIcon;
        private IconClass FemaleIcon;
        private PointF MaleIconLocation = new PointF(0.90f, 0.02f);
        private PointF FemaleIconLocation = new PointF(0.90f, 0.08f);
        #endregion

        #region Constructors
        public DataInputRaceScreenClass()
			{
			InitializeComponent();

            NewRecord = false;
            AllowChangeEvents = false;

            PopulateRaceListBox();
            RaceListBox.SelectedIndex = 0;
            PopulateStartingClassComboBoxList();
            PopulatePastLifeFeatComboBoxList();
            PopulateBonusFeatChoiceComboBoxesList();
            PopulateStatRangeBoxesList();

            PopulateFields(RaceListBox.SelectedItem.ToString());

            autoGrantedFeatsPanel1.Initialize("Race", ModelofRace.Id);

            //set our tracking variables to false
            HasRaceDataChanged = false;
            HasRaceDetailsChanged = new List<bool>();
            for (int i = 0; i < Constant.NumHeroicLevels; i++)
                HasRaceDetailsChanged.Add(false);
            //allow changes to happen in Change events again.
            AllowChangeEvents = true;
			}
        #endregion

        #region Form Events
        private void OnFormClosing(object sender, FormClosingEventArgs e)
			{
            if (DataChangeWarning() == false)
                {
                //cancel the form close!
                e.Cancel = true;
                return;
                }
			UIManagerClass.UIManager.CloseChildScreen(UIManagerClass.ChildScreen.DataInputRaceScreen);
            }

        private void OnUpdateButtonClick(object sender, EventArgs e)
            {
            string selection;

            //Lets save our changed fields to the database
            SaveScreen();

            //Lets reset the RaceList Box
            selection = NameInputBox.Text;
            RaceListBox.Items.Clear();
            PopulateRaceListBox();
            AllowChangeEvents = false;
            RaceListBox.SelectedItem = selection;
            AllowChangeEvents = true;
            //Now we can reset our flags and fields
            ResetFieldsandFlags(RaceListBox.SelectedItem.ToString());

            }

        private void OnKeyPressAllowIntOnlyTextBoxes(object sender, KeyPressEventArgs e)
            {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            }

		private void RecordFilterBoxTextChanged(object sender, EventArgs e)
			{
			RaceListBox.Items.Clear();
			foreach (string name in RaceNames)
				{
				if (Regex.Match(name, RecordFilterBox.Text, RegexOptions.IgnoreCase).Success)
					RaceListBox.Items.Add(name);
				}
			}

        private void OnNameInputBoxLeave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.Name);
            }

        private void OnMaleIconNameInputBoxLeave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.MaleIconName);
            }

        private void OnFemaleIconNameInputBoxLeave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.FemaleIconName);
            }

        private void OnAbbreviationInputBoxLeave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.Abbreviation);
            }

        private void OnBonusFeatComboSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.BonusFeatChoice);
            }

        private void OnSkillPointsInputBoxLeave(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                TextBoxChange(sender, InputType.SkillPoints);
            }

        private void OnStartingClassComboBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.StartingClass);
            }

        private void OnPastLifeFeatComboSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.PastLifeFeat);
            }

        private void OnIconicCheckBoxCheckedChanged(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                CheckBoxChange(sender, InputType.Iconic);
            }

        private void OnStrengthMinimumBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.StrMin);
            }

        private void OnStrengthMaximumBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.StrMax);
            }

        private void OnDexterityMinimumBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.DexMin);
            }

        private void OnDexterityMaximumBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.DexMax);
            }

        private void OnConstitutionMinimumBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.ConMin);
            }

        private void OnConstitutionMaximumBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.ConMax);
            }

        private void OnIntelligenceMinimumBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.IntMin);
            }

        private void OnIntelligenceMaximumBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.IntMax);
            }

        private void OnWisdomMinimumBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.WisMin);
            }

        private void OnWisdomMaximumBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.WisMax);
            }

        private void OnCharismaMinimumBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.ChaMin);
            }

        private void OnCharismaMaximumBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                ComboBoxChange(sender, InputType.ChaMax);
            }

        private void OnCancelButtonClick(object sender, EventArgs e)
            {
            AllowChangeEvents = false;
            NewRecord = false;
            PopulateFields(RaceListBox.SelectedItem.ToString());
            HasRaceDataChanged = false;
            for (int i =0; i<Constant.NumHeroicLevels; i++)
                HasRaceDetailsChanged[i] = false;
            AllowChangeEvents = true;
            }

        private void OnMaleIconBrowseButtonClick(object sender, EventArgs e)
            {
            string fileName;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Ping Files (*.png)|*.png";
            fileDialog.InitialDirectory = Application.StartupPath + "\\Graphics\\Races\\";
            if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                fileName = fileDialog.SafeFileName;
                //we only want the file name, not the extension
                fileName = fileName.Replace(".png", "");
                MaleIconNameInputBox.Text = fileName;
                }
            TextBoxChange(sender, InputType.MaleIconName);
            }

        private void OnFemaleIconBrowseButtonClick(object sender, EventArgs e)
            {
            string fileName;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Ping Files (*.png)|*.png";
            fileDialog.InitialDirectory = Application.StartupPath + "\\Graphics\\Races\\";
            if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                fileName = fileDialog.SafeFileName;
                //we only want the file name, not the extension
                fileName = fileName.Replace(".png", "");
                FemaleIconNameInputBox.Text = fileName;
                }
            TextBoxChange(sender, InputType.FemaleIconName);
            }

        private void OnNewRaceButtonClick(object sender, EventArgs e)
            {
            if (DataChangeWarning() == false)
                return;
            ResetFieldsandFlags("_New Race_");
            NameInputBox.Focus();
            }

        private void OnRaceListBoxSelectedIndexChanged(object sender, EventArgs e)
            {
            if (AllowChangeEvents == true)
                {
                if (RaceListBox.SelectedIndex == -1)
                    return;
                if (DataChangeWarning() == false)
                    return;
                ResetFieldsandFlags(RaceListBox.SelectedItem.ToString());
                NameInputBox.Focus();
                }
            }

        private void OnDescriptionEditButtonClick(object sender, EventArgs e)
            {
            DescriptionEditWindow = new TextEditWindow();
            DescriptionEditWindow.SetChangeEvent(OnDescriptionEditTextChange);
            DescriptionEditWindow.SetSaveEvent(OnDescriptionEditSaveButtonClick);
            DescriptionEditWindow.SetCancelEvent(OnDescriptionEditCancelButtonClick);
            DescriptionEditWindow.SetCloseEvent(OnDescriptionEditClose);
            DescriptionEditWindow.SetText(ModelofRace.Description);
            OldDescription = ModelofRace.Description;
            DescriptionEditWindow.Show(this);
            DescriptionEditWindow.Left = this.Left + ChildWindowLocation.X;
            DescriptionEditWindow.Top = this.Top + ChildWindowLocation.Y;
            }

        private void OnDeleteRaceButtonClick(object sender, EventArgs e)
            {
            int selection;
            RaceModel nextModel;
            int nextSequence;

            ModelofRace.Delete();

            //We need to fix the sequence numbers
            nextSequence = ModelofRace.Sequence + 1;
            nextModel = new RaceModel();
            nextModel.Initialize(nextSequence);
            while (nextModel.Id != Guid.Empty)
                {
                nextModel.Sequence--;
                nextModel.SaveSequence();
                nextSequence++;
                nextModel = new RaceModel();
                nextModel.Initialize(nextSequence);
                }

            //Lets reset the RaceList Box
            selection = RaceListBox.SelectedIndex - 1;
            if (selection < 0)
                selection = 0;

            RaceListBox.Items.Clear();
            PopulateRaceListBox();
            AllowChangeEvents = false;
            RaceListBox.SelectedIndex = selection;
            AllowChangeEvents = true;
            //Now we can reset our flags and fields
            ResetFieldsandFlags(RaceListBox.SelectedItem.ToString());
            }

        private void OnPaint(object sender, PaintEventArgs paintEventArgs)
            {
            DrawIcons(paintEventArgs);
            }

        private void OnDisplayUpButtonClick(object sender, EventArgs e)
            {
            if (RaceListBox.SelectedIndex == -1)
                return;

            ChangeDisplayOrder(Direction.Up);
            }

        private void OnDisplayDownButtonClick(object sender, EventArgs e)
            {
            if (RaceListBox.SelectedIndex == -1)
                return;

            ChangeDisplayOrder(Direction.Down);
            }

        #endregion

        #region Form Events for Description Edit Window
        private void OnDescriptionEditTextChange(object sender, EventArgs e)
            {
            DescriptionWebBrowser.DocumentText = DescriptionEditWindow.GetText();
            }

        private void OnDescriptionEditSaveButtonClick(object sender, EventArgs e)
            {
            DescriptionEditWindow.Close();
            }

        private void OnDescriptionEditCancelButtonClick(object sender, EventArgs e)
            {
            DescriptionWebBrowser.Navigate("about:blank");
            DescriptionWebBrowser.Document.OpenNew(false);
            DescriptionWebBrowser.Document.Write(OldDescription);
            DescriptionWebBrowser.Refresh();

            DescriptionEditWindow.Close();
            }

        private void OnDescriptionEditClose(object sender, EventArgs e)
            {
            ModelofRace.Description = DescriptionWebBrowser.DocumentText;
            HasRaceDataChanged = true;
            }

		#endregion

        #region Private Methods
        private void PopulateFields(string raceName)
            {
            string controlName;
            TextBox skillPointsBox;
            ComboBox bonusFeatChoiceBox;

            ModelofRace = new RaceModel();
            ModelofRace.Initialize(raceName);
            //set our Original values for error checking unique values.
			DatabaseName = ModelofRace.Name;
            DatabaseAbbreviation = ModelofRace.Abbreviation;

            //Set the Main Control Values
            NameInputBox.Text = ModelofRace.Name;
            AbbreviationInputBox.Text = ModelofRace.Abbreviation;
            PastLifeFeatCombo.SelectedItem = FeatModel.GetNameFromId(ModelofRace.PastLifeFeatId);
			StartingClassComboBox.SelectedItem = ClassModel.GetNameFromId(ModelofRace.StartingClassId);
            IconicCheckBox.Checked = ModelofRace.Iconic;

            DescriptionWebBrowser.Navigate("about:blank");
            DescriptionWebBrowser.Document.OpenNew(false);
            DescriptionWebBrowser.Document.Write(ModelofRace.Description);
            DescriptionWebBrowser.Refresh();
            MaleIconNameInputBox.Text = ModelofRace.MaleImageFileName;
            FemaleIconNameInputBox.Text = ModelofRace.FemaleImageFileName;
            MaleIcon = new IconClass(ModelofRace.MaleImageFileName);
            MaleIcon.SetLocation(this.Width, this.Height, MaleIconLocation);
            FemaleIcon = new IconClass(ModelofRace.FemaleImageFileName);
            FemaleIcon.SetLocation(this.Width, this.Height, FemaleIconLocation);
            //Starting Stat Boxes
            StrengthMinimumBox.SelectedItem = ModelofRace.StrengthMinimum.ToString();
            StrengthMaximumBox.SelectedItem = ModelofRace.StrengthMaximum.ToString();
            DexterityMinimumBox.SelectedItem = ModelofRace.DexterityMinimum.ToString();
            DexterityMaximumBox.SelectedItem = ModelofRace.DexterityMaximum.ToString();
            ConstitutionMinimumBox.SelectedItem = ModelofRace.ConstitutionMinimum.ToString();
            ConstitutionMaximumBox.SelectedItem = ModelofRace.ConstitutionMaximum.ToString();
            IntelligenceMinimumBox.SelectedItem = ModelofRace.IntelligenceMinimum.ToString();
            IntelligenceMaximumBox.SelectedItem = ModelofRace.IntelligenceMaximum.ToString();
            WisdomMinimumBox.SelectedItem = ModelofRace.WisdomMinimum.ToString();
            WisdomMaximumBox.SelectedItem = ModelofRace.WisdomMaximum.ToString();
            CharismaMinimumBox.SelectedItem = ModelofRace.CharismaMinimum.ToString();
            CharismaMaximumBox.SelectedItem = ModelofRace.CharismaMaximum.ToString();
            //System Boxes
            GuidLabel.Text = ModelofRace.Id.ToString();
            LastUpdatedDateLabel.Text = ModelofRace.LastUpdatedDate.ToString();
            LastUpdatedVersionLabel.Text = ModelofRace.LastUpdatedVersion;

            //LevelDetails Information
            ModelofRaceDetail = RaceLevelDetailModel.GetAll(ModelofRace.Id);
            if (ModelofRaceDetail == null)
                {
                //no detail records exist for this race, so we need to create them
                ModelofRaceDetail = new List<RaceLevelDetailModel>();
                for (int i = 0; i < Constant.NumHeroicLevels; i++)
                    {
                    ModelofRaceDetail.Add(new RaceLevelDetailModel());
                    ModelofRaceDetail[i].Level = i + 1;
                    }
                NewRecord = true;
                }
            //now lets fill in our Level Detail Controls
            for (int i = 0; i < Constant.NumHeroicLevels; i++)
                {
                controlName = "SkillPointsInputBox" + (i + 1);
                skillPointsBox = (TextBox)this.LevelDetailsPanel.Controls[controlName];
                skillPointsBox.Text = ModelofRaceDetail[i].BonusSkillPoints.ToString();

                controlName = "BonusFeatChoiceCombo" + (i + 1);
                bonusFeatChoiceBox = (ComboBox)this.LevelDetailsPanel.Controls[controlName];
                bonusFeatChoiceBox.SelectedItem = FeatTypeModel.GetNameFromId(ModelofRaceDetail[i].FeatTypeId);
                }   
            }

        private void PopulateRaceListBox()
            {
            RaceNames = RaceModel.GetNames();
            foreach (string name in RaceNames)
                RaceListBox.Items.Add(name);
            }

        private void PopulateStartingClassComboBoxList()
            {
			ClassNames = ClassModel.GetNames();
            StartingClassComboBox.Items.Add("");
            foreach (string name in ClassNames)
                StartingClassComboBox.Items.Add(name);
            }

        private void PopulatePastLifeFeatComboBoxList()
            {
            FeatNames = FeatModel.GetNames();
            PastLifeFeatCombo.Items.Add("");
            foreach (string name in FeatNames)
                PastLifeFeatCombo.Items.Add(name);
            }

        private void PopulateBonusFeatChoiceComboBoxesList()
            {
            string controlName;
            ComboBox controlBox;

            FeatTypeNames = FeatTypeModel.GetNames();
            for (int i = 1; i <= Constant.NumHeroicLevels; i++)
                {
                controlName = "BonusFeatChoiceCombo" + i;
                controlBox = (ComboBox)this.LevelDetailsPanel.Controls[controlName];
                controlBox.Items.Add("");
                foreach (string name in FeatTypeNames)
                    controlBox.Items.Add(name);
                }
            }

        private void PopulateStatRangeBoxesList()
            {
            int minimum;
            int maximum;

            minimum = 6;
            maximum = 20;

            for (int i = minimum; i <= maximum; i++)
                {
                StrengthMinimumBox.Items.Add(i.ToString());
                StrengthMaximumBox.Items.Add(i.ToString());
                DexterityMinimumBox.Items.Add(i.ToString());
                DexterityMaximumBox.Items.Add(i.ToString());
                ConstitutionMinimumBox.Items.Add(i.ToString());
                ConstitutionMaximumBox.Items.Add(i.ToString());
                IntelligenceMinimumBox.Items.Add(i.ToString());
                IntelligenceMaximumBox.Items.Add(i.ToString());
                WisdomMinimumBox.Items.Add(i.ToString());
                WisdomMaximumBox.Items.Add(i.ToString());
                CharismaMinimumBox.Items.Add(i.ToString());
                CharismaMaximumBox.Items.Add(i.ToString());
                }
            }

        private bool HasDataChanged()
            {
            if (NewRecord == true)
                return true;

            if (HasRaceDataChanged == true)
                return true;

            for (int i = 0; i < Constant.NumHeroicLevels; i++)
                {
                if (HasRaceDetailsChanged[i] == true)
                    return true;
                }

            if (autoGrantedFeatsPanel1.HasAutoGrantedFeatsChanged() == true)
                return true;

            //no data was changed, so return false
            return false;
            }

        private bool DataChangeWarning()
            {
            DialogResult result;

            if (HasDataChanged() == false)
                return true;

            result = MessageBox.Show("Warninig: Data has been modified! Do you want to save your changes?", "Warning!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Cancel)
                return false;
            else if (result == DialogResult.Yes)
                {
                SaveScreen();
                return true;
                }
            else
                //user answered No, I guess we really don't care abou the changed data!
                return true;
            }

        private void SaveScreen()
            {
            if (NewRecord == true || HasRaceDataChanged == true)
                ModelofRace.Save();

            for (int i = 0; i < Constant.NumHeroicLevels; i++)
                {
                if (NewRecord == true || HasRaceDetailsChanged[i] == true)
                    {
                    if (ModelofRaceDetail[i].RaceId == Guid.Empty)
                        ModelofRaceDetail[i].RaceId = ModelofRace.Id;
                    ModelofRaceDetail[i].Save();
                    }
                }
            //if we are dealing with a new record we need to send the new id to the autograntedfeat form so it 
            //will update the records properly.
            if (NewRecord == true)
                autoGrantedFeatsPanel1.UpdateMainRecordId(ModelofRace.Id);
            if (autoGrantedFeatsPanel1.HasAutoGrantedFeatsChanged() == true)
                autoGrantedFeatsPanel1.SaveAutoGrantedFeats();

			//cache the name and abbreviation strings for later comparisons
			// (we have now updated the databse, so update these as well)
			DatabaseName = ModelofRace.Name;
			DatabaseAbbreviation = ModelofRace.Abbreviation;

            }

        private bool CheckForUniqueness(string newValue, InputType type)
            {
            switch (type)
                {
                case InputType.Name:
                        {
                        if (RaceModel.DoesNameExist(newValue) == true)
                            return false;
                        break;
                        }
                case InputType.Abbreviation:
                        {
                        if (RaceModel.DoesAbbreviationExist(newValue) == true)
                            return false;
                        break;
                        }
                }
            return true;
            }

        private void TextBoxChange(object sender, InputType type)
            {
            string newStringValue;

            TextBox changedBox;
            string boxIndexString;
            int boxIndex;
            int newIntValue;

            switch (type)
                {
                case InputType.Name:
                        {
                        newStringValue = NameInputBox.Text;
                        if (newStringValue != ModelofRace.Name)
                            {
							if (newStringValue == DatabaseName)
                                {
                                ModelofRace.Name = newStringValue;
                                NameInputBox.BackColor = Color.White;
                                NameErrorLabel.Text = "";
                                break;
                                }
                            if (CheckForUniqueness(newStringValue, InputType.Name) == true)
                                {
                                ModelofRace.Name = newStringValue;
                                HasRaceDataChanged = true;
                                NameInputBox.BackColor = Color.White;
                                NameErrorLabel.Text = "";
                                }
                            else
                                {
                                //Let the user know he needs to choose a new name.
                                //MessageBox.Show("Error: The Name '" + newStringValue + "' already exist, you need to choose a different name", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                AllowChangeEvents = false;
                                NameInputBox.Text = ModelofRace.Name;
                                NameInputBox.BackColor = Color.OrangeRed;
                                NameErrorLabel.Text = "Error: Name is already taken, please choose another";
                                AllowChangeEvents = true;
                                NameInputBox.Focus();
                                }
                            }
                        else
                            {
                            NameInputBox.BackColor = Color.White;
                            NameErrorLabel.Text = "";
                            }
                        break;
                        }
                case InputType.MaleIconName:
                        {
                        newStringValue = MaleIconNameInputBox.Text;
                        if (newStringValue != ModelofRace.MaleImageFileName)
                            {
                            ModelofRace.MaleImageFileName = newStringValue;
                            HasRaceDataChanged = true;
                            MaleIcon = new IconClass(newStringValue);
                            MaleIcon.SetLocation(this.Width, this.Height, MaleIconLocation);
                            }
                        break;
                        }
                case InputType.FemaleIconName:
                        {
                        newStringValue = FemaleIconNameInputBox.Text;
                        if (newStringValue != ModelofRace.FemaleImageFileName)
                            {
                            ModelofRace.FemaleImageFileName = newStringValue;
                            HasRaceDataChanged = true;
                            FemaleIcon = new IconClass(newStringValue);
                            FemaleIcon.SetLocation(this.Width, this.Height, FemaleIconLocation);
                            }
                        break;
                        }
                case InputType.Abbreviation:
                        {
                        newStringValue = AbbreviationInputBox.Text;
                        if (newStringValue != ModelofRace.Abbreviation)
                            {
                            if (newStringValue == DatabaseAbbreviation)
                                {
                                ModelofRace.Abbreviation = newStringValue;
                                AbbreviationInputBox.BackColor = Color.White;
                                NameErrorLabel.Text = "";
                                break;
                                }
                            if (CheckForUniqueness(newStringValue, InputType.Abbreviation) == true)
                                {
                                ModelofRace.Abbreviation = newStringValue;
                                HasRaceDataChanged = true;
                                AbbreviationInputBox.BackColor = Color.White;
                                NameErrorLabel.Text = "";
                                }
                            else
                                {
                                //Let the user know he needs to choose a new name.
                                //MessageBox.Show("Error: The Abbreviation '" + newStringValue + "' already exist, you need to choose a different abbreviation", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                AllowChangeEvents = false;
                                AbbreviationInputBox.Text = ModelofRace.Abbreviation;
                                AbbreviationInputBox.BackColor = Color.OrangeRed;
                                NameErrorLabel.Text = "Error: Abbreviation is already taken, please choose another";
                                AllowChangeEvents = true;
                                AbbreviationInputBox.Focus();
                                }
                            }
                        else
                            {
                            AbbreviationInputBox.BackColor = Color.White;
                            NameErrorLabel.Text = "";
                            }
                        break;
                        }
                case InputType.SkillPoints:
                        {
                        //extract the index value of the control sending this message
                        changedBox = new TextBox();
                        changedBox = (TextBox)sender;
                        boxIndexString = Regex.Match(changedBox.Name, @"\d+").Value;
                        boxIndex = Int32.Parse(boxIndexString)-1;

                        //grab the new value (make sure its a valid int and not some wierd string!)
                        newStringValue = Regex.Match(changedBox.Text, @"\d+").Value;
                        if (newStringValue.Length == 0)
                            newIntValue = 0;
                        else
                            newIntValue = Int32.Parse(newStringValue);

                        if (newIntValue != ModelofRaceDetail[boxIndex].BonusSkillPoints)
                            {
                            ModelofRaceDetail[boxIndex].BonusSkillPoints = newIntValue;
                            HasRaceDetailsChanged[boxIndex] = true;
                            }
                        break;
                        }
                }
            }

        private void ComboBoxChange(object sender, InputType type)
            {
            ComboBox changedBox;
            string boxIndexString;
            int boxIndex;
            string newValueString;
            Guid newValueGuid;

            ClassModel modelofClass;
            FeatModel modelofFeat;
            FeatTypeModel modelofFeatType;

            switch (type)
                {
                case InputType.StrMin:
                    {
                    newValueString = StrengthMinimumBox.SelectedItem.ToString();

                    if (newValueString != ModelofRace.StrengthMinimum.ToString())
                        {
                        ModelofRace.StrengthMinimum = Int32.Parse(newValueString);
                        HasRaceDataChanged = true;
                        }
                    break;
                    }
                case InputType.StrMax:
                    {
                    newValueString = StrengthMaximumBox.SelectedItem.ToString();

                    if (newValueString != ModelofRace.StrengthMaximum.ToString())
                        {
                        ModelofRace.StrengthMaximum = Int32.Parse(newValueString);
                        HasRaceDataChanged = true;
                        }
                    break;
                    }
                case InputType.DexMin:
                    {
                    newValueString = DexterityMinimumBox.SelectedItem.ToString();

                    if (newValueString != ModelofRace.DexterityMinimum.ToString())
                        {
                        ModelofRace.DexterityMinimum = Int32.Parse(newValueString);
                        HasRaceDataChanged = true;
                        }
                    break;
                    }
                case InputType.DexMax:
                    {
                    newValueString = DexterityMaximumBox.SelectedItem.ToString();

                    if (newValueString != ModelofRace.DexterityMaximum.ToString())
                        {
                        ModelofRace.DexterityMaximum = Int32.Parse(newValueString);
                        HasRaceDataChanged = true;
                        }
                    break;
                    }
                case InputType.ConMin:
                    {
                    newValueString = ConstitutionMinimumBox.SelectedItem.ToString();

                    if (newValueString != ModelofRace.ConstitutionMinimum.ToString())
                        {
                        ModelofRace.ConstitutionMinimum = Int32.Parse(newValueString);
                        HasRaceDataChanged = true;
                        }
                    break;
                    }
                case InputType.ConMax:
                    {
                    newValueString = ConstitutionMaximumBox.SelectedItem.ToString();

                    if (newValueString != ModelofRace.ConstitutionMaximum.ToString())
                        {
                        ModelofRace.ConstitutionMaximum = Int32.Parse(newValueString);
                        HasRaceDataChanged = true;
                        }
                    break;
                    }
                case InputType.IntMin:
                    {
                    newValueString = IntelligenceMinimumBox.SelectedItem.ToString();

                    if (newValueString != ModelofRace.IntelligenceMinimum.ToString())
                        {
                        ModelofRace.IntelligenceMinimum = Int32.Parse(newValueString);
                        HasRaceDataChanged = true;
                        }
                    break;
                    }
                case InputType.IntMax:
                    {
                    newValueString = IntelligenceMaximumBox.SelectedItem.ToString();

                    if (newValueString != ModelofRace.IntelligenceMaximum.ToString())
                        {
                        ModelofRace.IntelligenceMaximum = Int32.Parse(newValueString);
                        HasRaceDataChanged = true;
                        }
                    break;
                    }
                case InputType.WisMin:
                    {
                    newValueString = WisdomMinimumBox.SelectedItem.ToString();

                    if (newValueString != ModelofRace.WisdomMinimum.ToString())
                        {
                        ModelofRace.WisdomMinimum = Int32.Parse(newValueString);
                        HasRaceDataChanged = true;
                        }
                    break;
                    }
                case InputType.WisMax:
                    {
                    newValueString = WisdomMaximumBox.SelectedItem.ToString();

                    if (newValueString != ModelofRace.WisdomMaximum.ToString())
                        {
                        ModelofRace.WisdomMaximum = Int32.Parse(newValueString);
                        HasRaceDataChanged = true;
                        }
                    break;
                    }
                case InputType.ChaMin:
                    {
                    newValueString = CharismaMinimumBox.SelectedItem.ToString();

                    if (newValueString != ModelofRace.CharismaMinimum.ToString())
                        {
                        ModelofRace.CharismaMinimum = Int32.Parse(newValueString);
                        HasRaceDataChanged = true;
                        }
                    break;
                    }
                case InputType.ChaMax:
                    {
                    newValueString = CharismaMaximumBox.SelectedItem.ToString();

                    if (newValueString != ModelofRace.CharismaMaximum.ToString())
                        {
                        ModelofRace.CharismaMaximum = Int32.Parse(newValueString);
                        HasRaceDataChanged = true;
                        }
                    break;
                    }
                case InputType.StartingClass:
                    {
                    newValueString = StartingClassComboBox.SelectedItem.ToString();
                    if (newValueString == "")
                        {
                        newValueGuid = Guid.Empty;
                        }
                    else
                        {
                        modelofClass = new ClassModel();
                        modelofClass.Initialize(newValueString);
                        newValueGuid = modelofClass.Id;
                        }

                    if (newValueGuid != ModelofRace.StartingClassId)
                        {
                        ModelofRace.StartingClassId = newValueGuid;
                        HasRaceDataChanged = true;
                        }
                    break;
                    }
                case InputType.PastLifeFeat:
                        {
                        newValueString = PastLifeFeatCombo.SelectedItem.ToString();
                        if (newValueString == "")
                            {
                            newValueGuid = Guid.Empty;
                            }
                        else
                            {
                            modelofFeat = new FeatModel();
                            modelofFeat.Initialize(newValueString);
                            newValueGuid = modelofFeat.Id;
                            }
                        if (newValueGuid != ModelofRace.PastLifeFeatId)
                            {
                            ModelofRace.PastLifeFeatId = newValueGuid;
                            HasRaceDataChanged = true;
                            }
                        break;
                        }
                case InputType.BonusFeatChoice:
                    {
                    changedBox = new ComboBox();
                    changedBox = (ComboBox)sender;
                    boxIndexString = Regex.Match(changedBox.Name, @"\d+").Value;
                    boxIndex = Int32.Parse(boxIndexString) - 1;

                    newValueString = changedBox.SelectedItem.ToString();
                    modelofFeatType = new FeatTypeModel();
                    modelofFeatType.Initialize(newValueString);
                    newValueGuid = modelofFeatType.Id;

                    if (newValueGuid != ModelofRaceDetail[boxIndex].FeatTypeId)
                        {
                        ModelofRaceDetail[boxIndex].FeatTypeId = newValueGuid;
                        HasRaceDetailsChanged[boxIndex] = true;
                        }
                    break;
                    }
                }
            }

        private void CheckBoxChange(object sender, InputType type)
            {
            bool boxChecked;

            switch (type)
                {
                case InputType.Iconic:
                        {
                        boxChecked = IconicCheckBox.Checked;
                        if (boxChecked != ModelofRace.Iconic)
                            {
                            ModelofRace.Iconic = boxChecked;
                            HasRaceDataChanged = true;
                            }
                        break;
                        }
                default:
                        {
                        //should not be here
                        break;
                        }
                }
            }

        private void ResetFieldsandFlags(string raceName)
            {
            AllowChangeEvents = false;
            NewRecord = false;
            PopulateFields(raceName);
            autoGrantedFeatsPanel1.Clear();
            autoGrantedFeatsPanel1.Initialize("Race", ModelofRace.Id);
            AllowChangeEvents = true;
            HasRaceDataChanged = false;
            for (int i = 0; i < Constant.NumHeroicLevels; i++)
                HasRaceDetailsChanged[i] = false;

            }

        private void DrawIcons(PaintEventArgs paintEventArgs)
            {
            MaleIcon.Draw(paintEventArgs);
            FemaleIcon.Draw(paintEventArgs);
            }

        private void ChangeDisplayOrder(Direction direction)
            {
            RaceModel swapRaceModel;
            int saveSequence;
            int selected;

            //Turn off change events
            AllowChangeEvents = false;

            swapRaceModel = new RaceModel();
            if (direction == Direction.Up)
                swapRaceModel.Initialize(ModelofRace.Sequence - 1);
            else
                swapRaceModel.Initialize(ModelofRace.Sequence + 1);

            if (swapRaceModel.Id != Guid.Empty)
                {
                saveSequence = ModelofRace.Sequence;
                ModelofRace.Sequence = swapRaceModel.Sequence;
                swapRaceModel.Sequence = 255;

                //swap sequences such that the database wont' complain about duplicate entries
                swapRaceModel.SaveSequence();
                ModelofRace.SaveSequence();
                swapRaceModel.Sequence = saveSequence;
                swapRaceModel.SaveSequence();

                if (direction == Direction.Up)
                    RaceListBox.SelectedIndex--;
                else
                    RaceListBox.SelectedIndex++;

                //repopulate the list box to show the new order
                selected = RaceListBox.SelectedIndex;
                RaceListBox.Items.Clear();
                PopulateRaceListBox();
                RaceListBox.SelectedIndex = selected;
                }

            //Turn change events back on
            AllowChangeEvents = true;
            }

        #endregion
        }
	}
