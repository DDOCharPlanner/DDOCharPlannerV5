using System;
using DDOCharacterPlanner.SaveDataModel;
using DDOCharacterPlanner.Screens.DataInput;
using DDOCharacterPlanner.Screens.MainScreen;
using DDOCharacterPlanner.Screens.UserSettings;
using DDOCharacterPlanner.Screens.MainScreen.EditScreens;

namespace DDOCharacterPlanner.Screens
	{
	public sealed class UIManagerClass
		{
		#region Singleton Pattern
		private static readonly UIManagerClass uiManager = new UIManagerClass();
		private UIManagerClass()
			{
			Skin = new SkinSettings();
			ScreenMessenger = new ScreenMessengerClass();
			}
		public static UIManagerClass UIManager
			{
			get { return uiManager; }
			}
		#endregion

		#region Enums
		public enum ChildScreen
			{
			MainScreen,
			ClassEditScreen,
			AbilityEditScreen,
			PastLifeEditScreen,
            SkillEditScreen,
			SkinEditorScreen,
			DataInputRaceScreen,
			DataInputClassScreen,
			DataInputCharacterScreen,
			DataInputFeatScreen,
			DataInputSpellScreen,
			DataInputEnhancementScreen,
			DataInputTomeScreen,
            SkillTomeEditScreen,
            AlignmentEditForm
			};
		#endregion

		#region Properties
        public AlignmentEditForm AlignmentScreen
        {
            get;
            private set;
        }
		public MainScreenClass MainScreen
			{
			get;
			private set;
			}

        public ClassEditScreen ClassScreen
        {
            get;
            private set;
        }
        
        public DataInputRaceScreenClass DataInputRaceScreen
			{
			get;
			private set;
			}

		public DataInputClassScreenClass DataInputClassScreen
			{
			get;
			private set;
			}

		public DataInputCharacterScreenClass DataInputCharacterScreen
			{
			get;
			private set;
			}

		public DataInputFeatScreenClass DataInputFeatScreen
			{
			get;
			private set;
			}

		public DataInputSpellScreenClass DataInputSpellScreen
			{
			get;
			private set;
			}

		public DataInputEnhancementScreenClass DataInputEnhancementScreen
			{
			get;
			private set;
			}

		public DataInputTomeScreenClass DataInputTomeScreen
			{
			get;
			private set;
			}

		public SkinEditorScreenClass SkinEditorScreen
			{
			get;
			private set;
			}

		public SkinSettings Skin
			{
			get;
			private set;
			}

		public PastLifeEditScreen PastLifeScreen
			{
			get;
			private set;
			}

		public ScreenMessengerClass ScreenMessenger
			{
			get;
			private set;
			}
        public SkillEditScreen SkillScreen
        {
            get;
            private set;
        }

        public AbilityEditPanel AbilityScreen
        {
            get;
            private set;
        }
        public SkillTomePanel SkillTomeScreen
        {
            get;
            private set;
        }
		#endregion

		#region Member Variables
		private bool DataInputRaceScreenVisible = false;
		private bool DataInputClassScreenVisible = false;
		private bool DataInputCharacterScreenVisible = false;
		private bool DataInputFeatScreenVisible = false;
		private bool DataInputSpellScreenVisible = false;
		private bool DataInputEnhancementScreenVisible = false;
		private bool DataInputTomeScreenVisible = false;
		private bool SkinEditorScreenVisible = false;
		private bool PastLifeEditScreenVisible = false;
        private bool SkillEditScreenVisible = false;
        private bool ClassEditScreenVisible = false;
        private bool AbilityEditScreenVisible = false;
        private bool SkillTomeScreenVisible = false;
        private bool AlignmentScreenVisible = false;
		private SaveSkinModel SaveSkin;
		#endregion

		#region Public Methods
		public void InitializeMainScreen()
			{
			MainScreen = new MainScreenClass();
			//TODO: Best to move this model to the skin setup screen when it exists
			//check for and create the save database
			SaveSkin = new SaveSkinModel();
			}

		public void CreateSkinFactorySettings()
			{
			//create Factory Settings
			Skin.CreateFactorySettings();
			}

		/// <summary>
		/// Show a child screen
		/// </summary>
		/// <param name="Child">The screen to show</param>
        public void ShowChildScreen(ChildScreen Child)
        {
            switch (Child)
            {
                case ChildScreen.DataInputRaceScreen:
                    {
                        //if the screen is already up, don't try to bring it up again, just pull it to the foreground
                        if (DataInputRaceScreenVisible == true)
                            DataInputRaceScreen.BringToFront();
                        else
                        {
                            DataInputRaceScreen = new DataInputRaceScreenClass();
                            DataInputRaceScreen.Show();
                        }
                        DataInputRaceScreenVisible = true;
                        break;
                    }
                case ChildScreen.DataInputClassScreen:
                    {
                        //if the screen is already up, don't try to bring it up again, just pull it to the foreground
                        if (DataInputClassScreenVisible == true)
                            DataInputClassScreen.BringToFront();
                        else
                        {
                            DataInputClassScreen = new DataInputClassScreenClass();
                            DataInputClassScreen.Show();
                        }
                        DataInputClassScreenVisible = true;
                        break;
                    }
                case ChildScreen.DataInputCharacterScreen:
                    {
                        //if the screen is already up, don't try to bring it up again, just pull it to the foreground
                        if (DataInputCharacterScreenVisible == true)
                            DataInputCharacterScreen.BringToFront();
                        else
                        {
                            DataInputCharacterScreen = new DataInputCharacterScreenClass();
                            DataInputCharacterScreen.Show();
                        }
                        DataInputCharacterScreenVisible = true;
                        break;
                    }
                case ChildScreen.DataInputFeatScreen:
                    {
                        //if the screen is already up, don't try to bring it up again, just pull it to the foreground
                        if (DataInputFeatScreenVisible == true)
                            DataInputFeatScreen.BringToFront();
                        else
                        {
                            DataInputFeatScreen = new DataInputFeatScreenClass();
                            DataInputFeatScreen.Show();
                        }
                        DataInputFeatScreenVisible = true;
                        break;
                    }
                case ChildScreen.DataInputSpellScreen:
                    {
                        //if the screen is already up, don't try to bring it up again, just pull it to the foreground
                        if (DataInputSpellScreenVisible == true)
                            DataInputSpellScreen.BringToFront();
                        else
                        {
                            DataInputSpellScreen = new DataInputSpellScreenClass();
                            DataInputSpellScreen.Show();
                        }
                        DataInputSpellScreenVisible = true;
                        break;
                    }
                case ChildScreen.DataInputEnhancementScreen:
                    {
                        //if the screen is already up, don't try to bring it up again, just pull it to the foreground
                        if (DataInputEnhancementScreenVisible == true)
                            DataInputEnhancementScreen.BringToFront();
                        else
                        {
                            DataInputEnhancementScreen = new DataInputEnhancementScreenClass();
                            DataInputEnhancementScreen.Show();
                        }
                        DataInputEnhancementScreenVisible = true;
                        break;
                    }

                case ChildScreen.DataInputTomeScreen:
                    {
                        //if the screen is already up, don't try to bring it up again, just pull it to the foreground
                        if (DataInputTomeScreenVisible == true)
                            DataInputTomeScreen.BringToFront();
                        else
                        {
                            DataInputTomeScreen = new DataInputTomeScreenClass();
                            DataInputTomeScreen.Show();
                        }
                        DataInputTomeScreenVisible = true;
                        break;
                    }

                case ChildScreen.PastLifeEditScreen:
                    {
                        if (PastLifeEditScreenVisible == true)
                            PastLifeScreen.BringToFront();
                        else
                        {
                            PastLifeScreen = new PastLifeEditScreen();
                            PastLifeScreen.Show();
                        }
                        PastLifeEditScreenVisible = true;
                        break;
                    }

                case ChildScreen.SkinEditorScreen:
                    {
                        //if the screen is already up, don't try to bring it up again, just pull it to the foreground
                        if (SkinEditorScreenVisible == true)
                            SkinEditorScreen.BringToFront();
                        else
                        {
                            SkinEditorScreen = new SkinEditorScreenClass();
                            SkinEditorScreen.Show();
                        }
                        SkinEditorScreenVisible = true;
                        break;
                    }
                case ChildScreen.SkillEditScreen:
                    {
                        if (SkillEditScreenVisible == true)
                            SkillScreen.BringToFront();
                        else
                        {
                            SkillScreen = new SkillEditScreen();
                            SkillScreen.Show();
                        }
                        SkillEditScreenVisible = true;
                        break;
                    }
                case ChildScreen.ClassEditScreen:
                    {
                        if (ClassEditScreenVisible == true)
                            ClassScreen.BringToFront();
                        else
                        {
                            ClassScreen = new ClassEditScreen();
                            ClassScreen.Show();
                        }
                        ClassEditScreenVisible = true;
                        break;
                    }
                case ChildScreen.AbilityEditScreen:
                    {
                        if (AbilityEditScreenVisible == true)
                            AbilityScreen.BringToFront();
                        else
                        {
                            AbilityScreen = new AbilityEditPanel();
                            AbilityScreen.Show();
                        }
                        AbilityEditScreenVisible = true;
                        break;
                    }
                case ChildScreen.SkillTomeEditScreen:
                    {
                        if (SkillTomeScreenVisible == true)
                            SkillTomeScreen.BringToFront();
                        else
                        {
                            SkillTomeScreen = new SkillTomePanel();
                            SkillTomeScreen.Show();
                        }
                        SkillTomeScreenVisible = true;
                        break;
                    }
                case ChildScreen.AlignmentEditForm:
                    {
                        if (AlignmentScreenVisible == true)
                            AlignmentScreen.BringToFront();
                        else
                        {
                            AlignmentScreen = new AlignmentEditForm();
                            AlignmentScreen.Show();
                        }
                        AlignmentScreenVisible = true;
                        break;
                    }
            }
        }
		/// <summary>
		/// Call this function when a child screen is closed
		/// </summary>
		/// <param name="Child"></param>
		public void CloseChildScreen(ChildScreen Child)
			{
			switch (Child)
				{
				case ChildScreen.DataInputRaceScreen:
					{
					DataInputRaceScreenVisible = false;
					break;
					}
				case ChildScreen.DataInputClassScreen:
					{
					DataInputClassScreenVisible = false;
					break;
					}
				case ChildScreen.DataInputCharacterScreen:
					{
					DataInputCharacterScreenVisible = false;
					break;
					}
				case ChildScreen.DataInputFeatScreen:
					{
					DataInputFeatScreenVisible = false;
					break;
					}
				case ChildScreen.DataInputSpellScreen:
					{
					DataInputSpellScreenVisible = false;
					break;
					}
				case ChildScreen.DataInputEnhancementScreen:
					{
					DataInputEnhancementScreenVisible = false;
					break;
					}
				case ChildScreen.DataInputTomeScreen:
					{
					DataInputTomeScreenVisible = false;
					break;
					}
				case ChildScreen.PastLifeEditScreen:
					{
					PastLifeEditScreenVisible = false;
					break;
					}
				case ChildScreen.SkinEditorScreen:
					{
					SkinEditorScreenVisible = false;
					break;
					}
                case ChildScreen.ClassEditScreen:
                    {
                        ClassEditScreenVisible = false;
                        break;
                    }
                case ChildScreen.SkillEditScreen:
                    {
                        SkillEditScreenVisible = false;
                        break;
                    }
                case ChildScreen.AbilityEditScreen:
                    {
                        AbilityEditScreenVisible = false;
                        break;
                    }
                case ChildScreen.SkillTomeEditScreen:
                    {
                        SkillTomeScreenVisible = false;
                        break;
                    }
                case ChildScreen.AlignmentEditForm:
                    {
                        AlignmentScreenVisible = false;
                        break;
                    }
				}
			}
		#endregion

		#region static public methods
		/// <summary>
		/// register all skin groups. This should only be done ONCE!
		/// </summary>
		public void RegisterSkinGroups()
			{
            DataInputFeatScreenClass.RegisterSkinGroups();
			MainScreenClass.RegisterSkinGroups();
			}
		#endregion
		}
	}
