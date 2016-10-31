
using DDOCharacterPlanner.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Screens.DataInput
    {
    public partial class AutoGrantedFeatsPanel : UserControl
        {
        #region Enums
        private enum InputType
            {
            Level,
            FeatName,
            IgnoreReq,
            };
        private enum ScreenType
            {
            Character,
            Class,
            Race
            };
        #endregion

        #region Member Variables
        private List<ComboBox> LevelComboBox;
        private List<ComboBox> FeatNameComboBox;
        private List<CheckBox> IgnorePreReqsCheckBox;
        private List<Button> DeleteButton;
        private ScreenType MainScreen;
        private List<string> Levels;
        private List<string> FeatNames;
        private List<CharacterBonusFeatModel> CharacterFeatModel;
        private List<ClassBonusFeatModel> ClassFeatModel;
        private List<RaceBonusFeatModel> RaceFeatModel;
        private List<bool> HasDataChanged;
        private List<bool> RecordDeleted;
        private int RecordCount;
        private Guid MainRecordId;
        private FeatModel ModelofFeat;

        #endregion

        #region Properties
        public bool HasChanged
            {
            get;
            set;
            }

        #endregion

        #region Constructors
        public AutoGrantedFeatsPanel()
			{
			InitializeComponent();
			LevelComboBox = new List<ComboBox>();
	        FeatNameComboBox = new List<ComboBox>();
		    IgnorePreReqsCheckBox = new List<CheckBox>();
			DeleteButton = new List<Button>();
	        MainScreen = ScreenType.Character;
		    Levels = new List<string>();
			FeatNames = new List<string>();
	        CharacterFeatModel = new List<CharacterBonusFeatModel>();
		    ClassFeatModel = new List<ClassBonusFeatModel>();
			RaceFeatModel = new List<RaceBonusFeatModel>();
	        HasDataChanged = new List<bool>();
		    RecordDeleted = new List<bool>();
			RecordCount = 0;
	        MainRecordId = new Guid();
		    ModelofFeat = new FeatModel();
	        HasChanged = false;
			}
        #endregion

        #region Form Events
        private void onLevelComboBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            ComboBoxChange(sender, InputType.Level);
            }

        private void onFeatNameComboBoxSelectedChangeCommited(object sender, EventArgs e)
            {
            ComboBoxChange(sender, InputType.FeatName);
            }

        private void onIgnorePreReqCheckBoxCheckedChanged(object sender, EventArgs e)
            {
            CheckBoxChange(sender);
            }

        private void onAddLevelComboBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AddFeatNameComboBox.SelectedItem != null)
                AddNewButton.Enabled = true;
            }

        private void onAddFeatLevelComboBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            if (AddLevelComboBox.SelectedItem != null)
                AddNewButton.Enabled = true;
            }

        private void onAddNewButtonClick(object sender, EventArgs e)
            {
            if (AddLevelComboBox.SelectedItem != null && AddFeatNameComboBox.SelectedItem != null)
                AddBonusFeatRecord();
            }

        private void onDeleteButtonClick(object sender, EventArgs e)
            {
            DeleteButtonClick(sender);
            }

        #endregion

        #region Private Members
        private void PopulateData()
            {
            // Generate our lists that will be used for our comboboxes.
            FeatNames = FeatModel.GetNames();
            Levels.Clear();
            for (int i = 1; i <= Constant.MaxLevels; i++)
                {
                if (i > Constant.NumHeroicLevels && MainScreen != ScreenType.Character)
                    break;
                Levels.Add(i.ToString());
                }

            //Get our model data and record count
            switch (MainScreen)
                {
                case ScreenType.Character:
                        {
                        CharacterFeatModel = CharacterBonusFeatModel.GetAll();
                        RecordCount = CharacterFeatModel.Count;
                        break;
                        }
                case ScreenType.Class:
                        {
                        ClassFeatModel = ClassBonusFeatModel.GetAll(MainRecordId);
                        RecordCount = ClassFeatModel.Count;
                        break;
                        }
                case ScreenType.Race:
                        {
                        RaceFeatModel = RaceBonusFeatModel.GetAll(MainRecordId);
                        RecordCount = RaceFeatModel.Count;
                        break;
                        }
                }
            
            //Set our tracking variables to false.
            HasDataChanged.Clear();
            RecordDeleted.Clear();
            for (int i = 0; i < RecordCount; i++)
                {
                HasDataChanged.Add(false);
                RecordDeleted.Add(false);
                }
            }

        private void CreateControls()
            {
            LevelComboBox.Clear();
            FeatNameComboBox.Clear();
            IgnorePreReqsCheckBox.Clear();
            DeleteButton.Clear();

            for (int i = 0; i < RecordCount; i++)
                {
                //Create the Level  ComboBoxes
                LevelComboBox.Add(new ComboBox());
                AutoGrantedFeatsSubPanel.Controls.Add(LevelComboBox[i]);
                LevelComboBox[i].Location = new Point(-3, i * 23);
                LevelComboBox[i].Name = "LevelComboBox[" + i + "]";
                LevelComboBox[i].Size = new Size(40, 23);
                LevelComboBox[i].DropDownStyle = ComboBoxStyle.DropDownList;
                LevelComboBox[i].SelectionChangeCommitted += new System.EventHandler(this.onLevelComboBoxSelectedChangeCommitted);
                foreach (string Name in Levels)
                    LevelComboBox[i].Items.Add(Name);

                //Create the Feat ComboBoxes
                FeatNameComboBox.Add(new ComboBox());
                AutoGrantedFeatsSubPanel.Controls.Add(FeatNameComboBox[i]);
                FeatNameComboBox[i].Location = new Point(40, i * 23);
                FeatNameComboBox[i].Name = "FeatNameComboBox[" + i + "]";
                FeatNameComboBox[i].Size = new Size(205, 23);
                FeatNameComboBox[i].DropDownStyle = ComboBoxStyle.DropDownList;
                FeatNameComboBox[i].SelectionChangeCommitted += new System.EventHandler(this.onFeatNameComboBoxSelectedChangeCommited);
                foreach (string Name in FeatNames)
                    FeatNameComboBox[i].Items.Add(Name);

                //Create the IgnorPreReqs Checkboxes
                IgnorePreReqsCheckBox.Add(new CheckBox());
                AutoGrantedFeatsSubPanel.Controls.Add(IgnorePreReqsCheckBox[i]);
                IgnorePreReqsCheckBox[i].Location = new Point(260, i * 23);
                IgnorePreReqsCheckBox[i].Name = "IgnorePreReqsCheckBox[" + i + "]";
                IgnorePreReqsCheckBox[i].Text = "True";
                IgnorePreReqsCheckBox[i].Size = new Size(10, 23);
                IgnorePreReqsCheckBox[i].CheckedChanged += new System.EventHandler(this.onIgnorePreReqCheckBoxCheckedChanged);
               
                //Create the Delect Buttons
                DeleteButton.Add(new Button());
                AutoGrantedFeatsSubPanel.Controls.Add(DeleteButton[i]);
                DeleteButton[i].Location = new Point(285, i * 23);
                DeleteButton[i].Name = "DeleteButton[" + i + "]";
                DeleteButton[i].Size = new Size(25, 23);
                DeleteButton[i].FlatStyle = FlatStyle.System;
                DeleteButton[i].Click += new System.EventHandler(this.onDeleteButtonClick);
                }
            //We need to populate our static Controls
			AddLevelComboBox.Items.Clear();
			AddFeatNameComboBox.Items.Clear();
            foreach (string Name in Levels)
                AddLevelComboBox.Items.Add(Name);
            foreach (string Name in FeatNames)
                AddFeatNameComboBox.Items.Add(Name);
            }

        private void PopulateControls()
            {
            Guid featId;

            featId = Guid.Empty;

            for (int i = 0; i < RecordCount; i++)
                {
                switch (MainScreen)
                    {
                    case ScreenType.Character:
                            {
                            featId = CharacterFeatModel[i].FeatId;
                            LevelComboBox[i].Text = CharacterFeatModel[i].Level.ToString();
                            IgnorePreReqsCheckBox[i].Checked = CharacterFeatModel[i].IgnorePreRequirements;
                            break;
                            }
                    case ScreenType.Class:
                            {
                            featId = ClassFeatModel[i].FeatId;
                            LevelComboBox[i].Text = ClassFeatModel[i].Level.ToString();
                            IgnorePreReqsCheckBox[i].Checked = ClassFeatModel[i].HasPreRequirements;
                            break;
                            }
                    case ScreenType.Race:
                            {
                            featId = RaceFeatModel[i].FeatId;
                            LevelComboBox[i].Text = RaceFeatModel[i].Level.ToString();
                            IgnorePreReqsCheckBox[i].Checked = RaceFeatModel[i].HasPreRequirements;
                            break;
                            }
                    }
                ModelofFeat.Initialize(featId);
                FeatNameComboBox[i].SelectedItem = ModelofFeat.Name.ToString();
                }
            }

        private void CheckBoxChange(Object sender)
            {
            CheckBox changedBox;
            string boxIndexString;
            int boxIndex;
            bool boxChecked;

            //extract the index value of the control sending this message
            changedBox = new CheckBox();
            changedBox = (CheckBox)sender;
            boxIndexString = Regex.Match(changedBox.Name, @"\d+").Value;
            boxIndex = Int32.Parse(boxIndexString);

            //grab the new value
            boxChecked = changedBox.Checked;

            //Let see if the value is different than our model value
            //change the model value if needed
            switch (MainScreen)
                {
                case ScreenType.Character:
                        {
                        if (boxChecked != CharacterFeatModel[boxIndex].IgnorePreRequirements)
                            {
                            CharacterFeatModel[boxIndex].IgnorePreRequirements = boxChecked;
                            HasDataChanged[boxIndex] = true;
                            }
                        break;
                        }
                case ScreenType.Class:
                        {
                        if (boxChecked != ClassFeatModel[boxIndex].HasPreRequirements)
                            {
                            ClassFeatModel[boxIndex].HasPreRequirements = boxChecked;
                            HasDataChanged[boxIndex] = true;
                            }
                        break;
                        }
                case ScreenType.Race:
                        {
                        if (boxChecked != RaceFeatModel[boxIndex].HasPreRequirements)
                            {
                            RaceFeatModel[boxIndex].HasPreRequirements = boxChecked;
                            HasDataChanged[boxIndex] = true;
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
            int newValueInt;
            Guid newValueGuid;

            //extract the index value of the cotnrol sending this message
            changedBox = new ComboBox();
            changedBox = (ComboBox)sender;
            boxIndexString = Regex.Match(changedBox.Name, @"\d+").Value;
            boxIndex = Int32.Parse(boxIndexString);

            //grab the new value
            newValueString = changedBox.SelectedItem.ToString();

            switch (type)
                {
                case InputType.Level:
                        {
                        if (newValueString.Length == 0)
                            newValueInt = 0;
                        else
                            newValueInt = Int32.Parse(newValueString);
                        switch (MainScreen)
                            {
                            case ScreenType.Character:
                                    {
                                    if (newValueInt != CharacterFeatModel[boxIndex].Level)
                                        {
                                        CharacterFeatModel[boxIndex].Level = newValueInt;
                                        HasDataChanged[boxIndex] = true;
                                        }
                                    break;
                                    }
                            case ScreenType.Class:
                                    {
                                    if (newValueInt != ClassFeatModel[boxIndex].Level)
                                        {
                                        ClassFeatModel[boxIndex].Level = newValueInt;
                                        HasDataChanged[boxIndex] = true;
                                        }
                                    break;
                                    }
                            case ScreenType.Race:
                                    {
                                    if (newValueInt != RaceFeatModel[boxIndex].Level)
                                        {
                                        RaceFeatModel[boxIndex].Level = newValueInt;
                                        HasDataChanged[boxIndex] = true;
                                        }
                                    break;
                                    }
                            }
                        break;
                        }
                case InputType.FeatName:
                        {
                        ModelofFeat = new FeatModel();
                        ModelofFeat.Initialize(newValueString);
                        newValueGuid = ModelofFeat.Id;
                        switch (MainScreen)
                            {
                            case ScreenType.Character:
                                    {
                                    if (newValueGuid != CharacterFeatModel[boxIndex].FeatId)
                                        {
                                        CharacterFeatModel[boxIndex].FeatId = newValueGuid;
                                        HasDataChanged[boxIndex] = true;
                                        }
                                    break;
                                    }
                            case ScreenType.Class:
                                    {
                                    if (newValueGuid != ClassFeatModel[boxIndex].FeatId)
                                        {
                                        ClassFeatModel[boxIndex].FeatId = newValueGuid;
                                        HasDataChanged[boxIndex] = true;
                                        }
                                    break;
                                    }
                            case ScreenType.Race:
                                    {
                                    if (newValueGuid != RaceFeatModel[boxIndex].FeatId)
                                        {
                                        RaceFeatModel[boxIndex].FeatId = newValueGuid;
                                        HasDataChanged[boxIndex] = true;
                                        }
                                    break;
                                    }
                            }
                        break;
                        }
                default:
                        {
                        Debug.WriteLine("Error: Unknown InputType in ComboBoxChange");
                        break;
                        }
                }
            }

        private void DeleteButtonClick(object sender)
            {
            Button buttonClicked;
            string buttonName;
            int buttonIndex;
            bool flag;

            //extract the index value of the cotnrol sending this message
            buttonClicked = new Button();
            buttonClicked = (Button)sender;
            buttonName = Regex.Match(buttonClicked.Name, @"\d+").Value;
            buttonIndex = Int32.Parse(buttonName);

            flag = RecordDeleted[buttonIndex];

            //Lets mark or unmark the item for deletion to be deleted in the save routine.
            RecordDeleted[buttonIndex] = !flag;
            LevelComboBox[buttonIndex].Enabled = flag;
            FeatNameComboBox[buttonIndex].Enabled = flag;
            IgnorePreReqsCheckBox[buttonIndex].Enabled = flag;
            }

        private void AddBonusFeatRecord()
            {
            RecordCount++;
            ModelofFeat.Initialize(AddFeatNameComboBox.SelectedItem.ToString());

            //Lets add a new set of controls
            //Create the Level  ComboBoxes
            LevelComboBox.Add(new ComboBox());
            AutoGrantedFeatsSubPanel.Controls.Add(LevelComboBox[RecordCount - 1]);
            LevelComboBox[RecordCount - 1].Location = new Point(-3, (RecordCount - 1) * 23);
            LevelComboBox[RecordCount - 1].Name = "LevelComboBox[" + (RecordCount - 1) + "]";
            LevelComboBox[RecordCount - 1].Size = new Size(40, 23);
            LevelComboBox[RecordCount - 1].DropDownStyle = ComboBoxStyle.DropDownList;
            LevelComboBox[RecordCount - 1].SelectionChangeCommitted += new System.EventHandler(this.onLevelComboBoxSelectedChangeCommitted);
            foreach (string Name in Levels)
                LevelComboBox[RecordCount - 1].Items.Add(Name);

            //Create the Feat ComboBoxes
            FeatNameComboBox.Add(new ComboBox());
            AutoGrantedFeatsSubPanel.Controls.Add(FeatNameComboBox[RecordCount - 1]);
            FeatNameComboBox[RecordCount - 1].Location = new Point(40, (RecordCount - 1) * 23);
            FeatNameComboBox[RecordCount - 1].Name = "FeatNameComboBox[" + (RecordCount - 1) + "]";
            FeatNameComboBox[RecordCount - 1].Size = new Size(205, 23);
            FeatNameComboBox[RecordCount - 1].DropDownStyle = ComboBoxStyle.DropDownList;
            FeatNameComboBox[RecordCount - 1].SelectionChangeCommitted += new System.EventHandler(this.onFeatNameComboBoxSelectedChangeCommited);
            foreach (string Name in FeatNames)
                FeatNameComboBox[RecordCount - 1].Items.Add(Name);

            //Create the IgnorPreReqs Checkboxes
            IgnorePreReqsCheckBox.Add(new CheckBox());
            AutoGrantedFeatsSubPanel.Controls.Add(IgnorePreReqsCheckBox[RecordCount - 1]);
            IgnorePreReqsCheckBox[RecordCount - 1].Location = new Point(260, (RecordCount - 1) * 23);
            IgnorePreReqsCheckBox[RecordCount - 1].Name = "IgnorePreReqsCheckBox[" + (RecordCount - 1) + "]";
            IgnorePreReqsCheckBox[RecordCount - 1].Text = "True";
            IgnorePreReqsCheckBox[RecordCount - 1].Size = new Size(10, 23);

            //Create the Delect Buttons
            DeleteButton.Add(new Button());
            AutoGrantedFeatsSubPanel.Controls.Add(DeleteButton[RecordCount - 1]);
            DeleteButton[RecordCount - 1].Location = new Point(285, (RecordCount - 1) * 23);
            DeleteButton[RecordCount - 1].Name = "DeleteButton[" + (RecordCount - 1) + "]";
            DeleteButton[RecordCount - 1].Size = new Size(25, 23);
            DeleteButton[RecordCount - 1].FlatStyle = FlatStyle.System;
            DeleteButton[RecordCount - 1].Click += new System.EventHandler(this.onDeleteButtonClick);
            switch (MainScreen)
                {
                case ScreenType.Character:
                        {
                        CharacterFeatModel.Add(new CharacterBonusFeatModel());
                        CharacterFeatModel[RecordCount - 1].Level = Int32.Parse(AddLevelComboBox.SelectedItem.ToString());
                        CharacterFeatModel[RecordCount - 1].FeatId = ModelofFeat.Id;
                        CharacterFeatModel[RecordCount - 1].IgnorePreRequirements = AddIgnorPreReqsCheckBox.Checked;
                        LevelComboBox[RecordCount - 1].Text = CharacterFeatModel[RecordCount - 1].Level.ToString();
                        IgnorePreReqsCheckBox[RecordCount - 1].Checked = CharacterFeatModel[RecordCount - 1].IgnorePreRequirements;
                        break;
                        }
                case ScreenType.Class:
                        {
                        ClassFeatModel.Add(new ClassBonusFeatModel());
                        ClassFeatModel[RecordCount - 1].Level = Int32.Parse(AddLevelComboBox.SelectedItem.ToString());
                        ClassFeatModel[RecordCount - 1].FeatId = ModelofFeat.Id;
                        ClassFeatModel[RecordCount - 1].HasPreRequirements = AddIgnorPreReqsCheckBox.Checked;
                        ClassFeatModel[RecordCount - 1].ClassId = MainRecordId;
                        LevelComboBox[RecordCount - 1].Text = ClassFeatModel[RecordCount - 1].Level.ToString();
                        IgnorePreReqsCheckBox[RecordCount - 1].Checked = ClassFeatModel[RecordCount - 1].HasPreRequirements;
                        break;
                        }
                case ScreenType.Race:
                        {
                        RaceFeatModel.Add(new RaceBonusFeatModel());
                        RaceFeatModel[RecordCount - 1].Level = Int32.Parse(AddLevelComboBox.SelectedItem.ToString());
                        RaceFeatModel[RecordCount - 1].FeatId = ModelofFeat.Id;
                        RaceFeatModel[RecordCount - 1].HasPreRequirements = AddIgnorPreReqsCheckBox.Checked;
                        RaceFeatModel[RecordCount - 1].RaceId = MainRecordId;
                        LevelComboBox[RecordCount - 1].Text = RaceFeatModel[RecordCount - 1].Level.ToString();
                        IgnorePreReqsCheckBox[RecordCount - 1].Checked = RaceFeatModel[RecordCount - 1].HasPreRequirements;
                        break;
                        }
                }
            FeatNameComboBox[RecordCount - 1].SelectedItem = ModelofFeat.Name.ToString();
            
            //lets set our change and delete flag for the new record.
            HasDataChanged.Add(true);
            RecordDeleted.Add(false);
            }

        #endregion

        #region Public Members
        /// <summary>
        /// Call this function to load the panel with current data.
        /// </summary>
        /// <param name="callingScreen">String variable of "Character", "Class" or "Race"</param>
        /// <param name="id">The GUID of the main record or empty guid for new records.</param>
        public void Initialize(string callingScreen, Guid id)
            {
            //set the Screentype so we know what models we are working with.
            if (callingScreen == "Character")
                MainScreen = ScreenType.Character;
            else if (callingScreen == "Class")
                MainScreen = ScreenType.Class;
            else if (callingScreen == "Race")
                MainScreen = ScreenType.Race;
            else
                Debug.WriteLine("Error: Unknown ScreenType in AutoGrantedFeatsPanel()");

            //Set Record ID
            MainRecordId = id;

            //Load the Model data into are variables
            PopulateData();
            //Create the controls needed to show the records
            CreateControls();
            //populate those controls with our model data
            PopulateControls();

            }

        public bool HasAutoGrantedFeatsChanged()
            {
            for (int i = 0; i < RecordCount; i++)
                {
                if (HasDataChanged[i] == true || RecordDeleted[i] == true)
                    return true;
                }
            return false;
            }

        public void SaveAutoGrantedFeats()
            {
            for (int i = 0; i < RecordCount; i++)
                {
                if (RecordDeleted[i] == true)
                    {
                    switch (MainScreen)
                        {
                        case ScreenType.Character:
                                {
                                CharacterFeatModel[i].Delete();
                                break;
                                }
                        case ScreenType.Class:
                                {
                                ClassFeatModel[i].Delete();
                                break;
                                }
                        case ScreenType.Race:
                                {
                                RaceFeatModel[i].Delete();
                                break;
                                }
                        }
                    RecordDeleted[i] = false;
                    HasDataChanged[i] = false; //need this if someone added a record but then decided to delete it.
                    }
                if (HasDataChanged[i] == true)
                    {
                    switch (MainScreen)
                        {
                        case ScreenType.Character:
                                {
                                CharacterFeatModel[i].Save();
                                break;
                                }
                        case ScreenType.Class:
                                {
                                ClassFeatModel[i].Save();
                                break;
                                }
                        case ScreenType.Race:
                                {
                                RaceFeatModel[i].Save();
                                break;
                                }
                        }
                    HasDataChanged[i] = false;
                    }
                }
            }

        public void Clear()
            {
            //Delete/Remove Current Controls
			for (int i = 0; i < AutoGrantedFeatsSubPanel.Controls.Count; i++)
				AutoGrantedFeatsSubPanel.Controls[i].Dispose();
			AutoGrantedFeatsSubPanel.Controls.Clear();

            //Reset internal variables to Null or defaults.
			LevelComboBox.Clear();
			FeatNameComboBox.Clear();
			IgnorePreReqsCheckBox.Clear();
			DeleteButton.Clear();

			CharacterFeatModel.Clear();
			ClassFeatModel.Clear();
			RaceFeatModel.Clear();

			HasDataChanged.Clear();
			RecordDeleted.Clear();
            RecordCount = 0;
            MainRecordId = Guid.Empty;
            }

        public void UpdateMainRecordId(Guid recordId)
            {
            MainRecordId = recordId;
            switch (MainScreen)
                {
                case ScreenType.Class:
                        {
                        foreach (ClassBonusFeatModel cModel in ClassFeatModel)
                            cModel.ClassId = MainRecordId;
                        break;
                        }
                case ScreenType.Race:
                        {
                        foreach (RaceBonusFeatModel rModel in RaceFeatModel)
                            rModel.RaceId = MainRecordId;
                        break;
                        }
                }
            }
        #endregion
        }
    }
