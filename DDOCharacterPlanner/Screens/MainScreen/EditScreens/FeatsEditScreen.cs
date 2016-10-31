using DDOCharacterPlanner.CharacterData;
using DDOCharacterPlanner.Data;
using DDOCharacterPlanner.Utility;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.MainScreen
    {



    public partial class FeatsEditScreen : Form
        {
        #region Enums
        public enum Slottype
        {
               
            General,
            Race_Bonus,
            Class_Bonus,
            Class_Special,
            Auto_Granted
        };


        #endregion

        #region Member Variables
        Guid[] CharacterFeats;
        Guid[] RaceFeats;
        Guid[,] ClassFeats;
        List<Guid>[] FeatLevelListTypeID;
        List<String>[] FeatLevelListType;
        List<Guid> FeatListTypeID;
        List<String> FeatListType;
        Guid[] CurrentClass;
        FeatSlot[] FeatSlotList;

        #endregion

        #region Constructors
        public FeatsEditScreen()
            {
                CharacterFeats = new Guid[Constant.MaxLevels+1];
                RaceFeats = new Guid[Constant.MaxLevels+1];
                ClassFeats = new Guid[3, Constant.MaxLevels+1];
                FeatLevelListTypeID = new List<Guid>[Constant.MaxLevels + 1];
                FeatLevelListType = new List<string>[Constant.MaxLevels + 1];
                
                CurrentClass = CharacterManagerClass.CharacterManager.CharacterClass.GetClasses();
                //Get Current Feats
                // Add Checks for Class and Race selection.
                getCharacterFeats();
                getClassFeats();
                getRaceFeats();



                InitializeComponent();
            ApplySkin();
            }

        #endregion

        #region Form Events

        #endregion

        #region Private Methods
        private void getCharacterFeats()
        {
            for (int i = 0; i <= CharacterFeats.Rank;i++ )
            {
                CharacterFeats[i] = Guid.Empty;
            }
                foreach (Model.CharacterModel newLevel in Model.CharacterModel.GetAll())
                {
                    if (newLevel.FeatTypeId != Guid.Empty)
                        CharacterFeats[newLevel.Level] = newLevel.FeatTypeId;
                }
            updateFeatList();
        }
        private void getRaceFeats()
        {
            for (int i = 0; i <= RaceFeats.Rank; i++)
            {
                RaceFeats[i] = Guid.Empty;
            }
            Guid CurrentRace;
            CurrentRace = new Guid();
            CurrentRace = Model.RaceModel.GetIdFromName(CharacterManagerClass.CharacterManager.CharacterRace.GetRaceName());
            foreach (Model.RaceLevelDetailModel newLevel in Model.RaceLevelDetailModel.GetAll(CurrentRace))
            {

                if (newLevel.FeatTypeId != Guid.Empty)
                    RaceFeats[newLevel.Level] = newLevel.FeatTypeId;

            }
            updateFeatList();
        }
        private void getClassFeats()
        {
            for (int x = 0; x <= 2;x++)
            {
                for (int i = 0; i <= ClassFeats.Rank; i++)
                {
                    ClassFeats[x,i] = Guid.Empty;
                }
            }

            
            CurrentClass = CharacterManagerClass.CharacterManager.CharacterClass.GetClasses();
            for (int i = 0; i <= 2; i++)
            {
                if (CurrentClass[i] != Guid.Empty)
                {
                    foreach (Model.ClassLevelDetailModel newLevel in Model.ClassLevelDetailModel.GetAll(CurrentClass[i]))
                    {
                        if (newLevel.FeatTypeId != Guid.Empty)
                            ClassFeats[i, newLevel.Level] = newLevel.FeatTypeId;
                    }
                }
            }
            updateFeatList();
        }
        private void updateFeatList()
        {
            
            for(int i=1;i<=Constant.MaxLevels;i++)
            {
                FeatLevelListTypeID[i] = new List<Guid>();
                FeatLevelListType[i] = new List<string>();
                FeatListTypeID = new List<Guid>();
                FeatListType = new List<string>();
                if(CharacterFeats[i] != Guid.Empty)
                {
                    FeatListTypeID.Add(CharacterFeats[i]);
                    FeatListType.Add(Model.FeatTypeModel.GetNameFromId(CharacterFeats[i]));
                }
                if (RaceFeats[i] != Guid.Empty)
                {
                    FeatListTypeID.Add(RaceFeats[i]);
                    FeatListType.Add(Model.FeatTypeModel.GetNameFromId(RaceFeats[i]));
                }
                    int ClassNum;
                    Guid test;
                    test = new Guid();
                    ClassNum = 0;
                    int CurrentClassLevel;
                    if (i <= 20)
                    {
                        
                        for (int x = 0; x <= CurrentClass.Rank;x++ )
                        {   test = CharacterData.CharacterManagerClass.CharacterManager.CharacterClass.GetClass(i);
                            if (CurrentClass[x] == CharacterData.CharacterManagerClass.CharacterManager.CharacterClass.GetClass(i))
                            {
                            ClassNum = x;
                            break;
                            }

                        }

                        CurrentClassLevel = CharacterData.CharacterManagerClass.CharacterManager.CharacterClass.GetClassCount(CurrentClass[ClassNum], i);
                            if (ClassFeats[ClassNum, CurrentClassLevel] != Guid.Empty)
                            {
                                FeatListTypeID.Add(ClassFeats[ClassNum, CurrentClassLevel]);
                                FeatListType.Add(Model.FeatTypeModel.GetNameFromId(ClassFeats[ClassNum, CurrentClassLevel]));
                            }

                    }

                FeatLevelListTypeID[i] = FeatListTypeID;
                FeatLevelListType[i] = FeatListType;
            }
        }
        private void updateFeatSlots()
        {

        }
        #endregion

        #region Public Methods
        public void ApplySkin()
            {
            UIManagerClass uiManager = UIManagerClass.UIManager;
            SkinStyleClass style;

            //Screen Background
            style = uiManager.Skin.GetSkinStyle("MainScreenFeatsEditScreenBackgroundColor");
            this.BackColor = style.Color1;

            //Panel Backgrounds
            style = uiManager.Skin.GetSkinStyle("MainScreenFeatsEditScreenPanelBackgroundColor");
            panelAvailableFeats.BackColor = style.Color1;
            panelDesiredFeats.BackColor = style.Color1;
            panelChosenFeats.BackColor = style.Color1;

            //Panel Headers
            style = uiManager.Skin.GetSkinStyle("MainScreenFeatsEditScreenPanelHeader");
            labelAvailableFeats.BackColor = style.Color2;
            labelAvailableFeats.ForeColor = style.Color1;
            labelAvailableFeats.Font = style.Font;
            labelChosenFeats.BackColor = style.Color2;
            labelChosenFeats.ForeColor = style.Color1;
            labelChosenFeats.Font = style.Font;
            labelDesiredFeats.BackColor = style.Color2;
            labelDesiredFeats.ForeColor = style.Color1;
            labelDesiredFeats.Font = style.Font;
            }

        #endregion

        #region Public Static Methods
        public static void RegisterSkinGroups()
            {
            UIManagerClass uiManager = UIManagerClass.UIManager;

            uiManager.Skin.RegisterSkinGroup("MainScreenFeatsEditScreenBackgroundColor", SkinSettings.FactoryName.ScreenBackgroundColor);
            uiManager.Skin.RegisterSkinGroup("MainScreenFeatsEditScreenPanelBackgroundColor", SkinSettings.FactoryName.PanelBackgroundColor);
            uiManager.Skin.RegisterSkinGroup("MainScreenFeatsEditScreenPanelHeader", SkinSettings.FactoryName.PanelHeader);
            uiManager.Skin.RegisterSkinGroup("MainScreenFeatsEditScreenLabel", SkinSettings.FactoryName.StandardLabel);
            
            }

        #endregion

        private void labelCharacter_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanelSelectedFeats_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label92_Click(object sender, EventArgs e)
        {

        }

        private void label139_Click(object sender, EventArgs e)
        {

        }

        private void label138_Click(object sender, EventArgs e)
        {

        }

        private void FeatsEditScreen_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label141_Click(object sender, EventArgs e)
        {

        }

        private void label167_Click(object sender, EventArgs e)
        {

        }

        #region Change Notification Handlers

        #endregion

        }
    class FeatSlot
    {
        public int Level { get; set; }
        public String Class { get; set; }
        public Guid FeatTypeID { get; set; }
        public String FeatTypeName { get; set; }
        public Guid FeatID { get; set; }
        public String FeatName { get; set; }

        public string Featslottext()
        {
            if(this.FeatName != "")
                return this.FeatName;
            else
                return this.FeatTypeName;
        }

        public MainScreen.FeatsEditScreen.Slottype FeatSlotType()
        {
            MainScreen.FeatsEditScreen.Slottype returnvalue;
            switch(this.FeatTypeName)
            {
                case "General":

                    returnvalue = MainScreen.FeatsEditScreen.Slottype.General;
                    break;

                case "Human Bonus":
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Race_Bonus;
                    break;

                case "Fighter Bonus":
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Class_Bonus;
                    break;

                case "Favored Enemy":
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Class_Bonus;
                    break;

                case "Martial Bonus":
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Class_Bonus;
                    break;

                case "Artificer Bonus":
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Class_Bonus;
                    break;

                case "Epic Destiny":
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Class_Bonus;
                    break;

                case "Deity Bonus":
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Class_Special;
                    break;

                case "Energy Resistance":
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Class_Special;
                    break;

                case "Philosphy":
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Class_Special;
                    break;

                case "Rogue Special Ability":
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Class_Bonus;
                    break;

                case "Wizard Bonus":
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Class_Bonus;
                    break;

                case "Dilettante":
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Race_Bonus;
                    break;

                case "Warlock Pact":
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Class_Special;
                    break;
                    
                default:
                    returnvalue = MainScreen.FeatsEditScreen.Slottype.Auto_Granted;
                    break;
            }
            return returnvalue;
        }

    }
    }
