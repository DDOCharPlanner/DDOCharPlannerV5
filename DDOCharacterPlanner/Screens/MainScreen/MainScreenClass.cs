using DDOCharacterPlanner.CharacterData;
using DDOCharacterPlanner.Data;
using DDOCharacterPlanner.Utility;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.MainScreen
	{
	public partial class MainScreenClass : Form
        {
        #region Member Variables
        private int SelectedLevel;
        SkinStyleClass ButtonSelectedStyle;
        SkinStyleClass ButtonNotSelectedStyle;
        private bool DisplayDBMenu;
        #endregion

        #region Constructors
        public MainScreenClass()
			{
			InitializeComponent();
            SelectedLevel = 30;
			ApplySkin();
            databaseToolStripMenuItem.Visible = false;
            DBaccess();
			this.Text = "DDO Character Planner - Version " + Constant.PlannerVersion;

            //listen for change Notification messages
            UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.MainScreen, ScreenMessengerClass.ChangeList.ClassChange, HandleClassChange);
			UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.MainScreen, ScreenMessengerClass.ChangeList.AbilityChange, HandleAbilityChange);
            UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.MainScreen, ScreenMessengerClass.ChangeList.RaceChange, HandleRaceChange);
            UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.MainScreen, ScreenMessengerClass.ChangeList.SkillChange, HandleSkillChange);
            UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.MainScreen, ScreenMessengerClass.ChangeList.PastLifeChange, HandlePastLifeChange);
            UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.MainScreen, ScreenMessengerClass.ChangeList.AlignmentChange, HandleAlignmentChange);
            //initialize the sub panels
			mainScreenAbilitiesPanel1.AbilityChange(SelectedLevel);
            mainScreenFeatsPanel1.FeatChange(SelectedLevel);
            HandleAlignmentChange();
            }

        #endregion

		#region Form Events
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.F12))
            {
                DialogResult enableDBaccess = MessageBox.Show("Added info into these tables may prevent your Character from loading into Future Version of the Program","DB Edit Enabled",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if (enableDBaccess == DialogResult.OK)
                    {
                        databaseToolStripMenuItem.Visible = true;              
                    }
                    
                else
                    {
                        databaseToolStripMenuItem.Visible = false;
                    }

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        
		private void OnMainScreenClassFormClosing(object sender, FormClosingEventArgs e)
			{
			UIManagerClass.UIManager.ScreenMessenger.DeregisterListener(UIManagerClass.ChildScreen.MainScreen);
			}

		private void RaceInputToolStripMenuItemClick(object sender, EventArgs e)
			{
			UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.DataInputRaceScreen);
			}

		private void ClassInputToolStripMenuItemClick(object sender, EventArgs e)
			{
			UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.DataInputClassScreen);
			}

        private void CharacterInputToolStripMenuItemClick(object sender, EventArgs e)
            {
            UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.DataInputCharacterScreen);
            }

		private void FeatInputToolStripMenuItemClick(object sender, EventArgs e)
			{
			UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.DataInputFeatScreen);
			}

		private void SpellInputToolStripMenuItemClick(object sender, EventArgs e)
			{
			UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.DataInputSpellScreen);
			}

        private void EnhancementInputToolStripMenuItemClick(object sender, EventArgs e)
            {
            UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.DataInputEnhancementScreen);
            }

		private void TomesToolStripMenuItemClick(object sender, EventArgs e)
			{
			UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.DataInputTomeScreen);
			}

		private void SkinEditorToolStripMenuItemClick(object sender, EventArgs e)
			{
			UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.SkinEditorScreen);
			}

		private void ReincarnationButton_Click(object sender, EventArgs e)
			{
			UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.PastLifeEditScreen);
			}

        private void buttonEditClasses_Click(object sender, EventArgs e)
            {

                UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.ClassEditScreen);
            }

		private void OnAlignmentButtonClick(object sender, EventArgs e)
			{
            UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.AlignmentEditForm);
			
			}
		#endregion

        #region Control Events
        private void LevelButton_Click(object sender, EventArgs e)
            {
            int buttonIndex;
            Button levelButton;
            string buttonName;

            buttonIndex = GetButtonIndex(sender);
            if (buttonIndex != SelectedLevel)
                {
                //Ok lets set the previous selected button to nonselected style
                buttonName = "LevelButton" + SelectedLevel;
                levelButton = (Button)this.Controls[buttonName];
                levelButton.BackColor = ButtonNotSelectedStyle.Color2;
                levelButton.ForeColor = ButtonNotSelectedStyle.Color1;
                levelButton.Font = ButtonNotSelectedStyle.Font;

                //now we can set the selected button
                SelectedLevel = buttonIndex;
                buttonName = "LevelButton" + SelectedLevel;
                levelButton = (Button)this.Controls[buttonName];
                levelButton.BackColor = ButtonSelectedStyle.Color2;
                levelButton.ForeColor = ButtonSelectedStyle.Color1;
                levelButton.Font = ButtonSelectedStyle.Font;

                //Now we need refresh our screens based on the new level selected
                mainScreenFeatsPanel1.FeatChange(SelectedLevel);
                mainScreenAbilitiesPanel1.AbilityChange(SelectedLevel);
                SkillPanel.Updatevalues(SelectedLevel);
                labelClasses.Text = CharacterManagerClass.CharacterManager.CharacterClass.GetClassSplit(SelectedLevel);
                }

            }

        #endregion

        #region Private Methods
        private int GetButtonIndex(object sender)
            {
            int index;
            Button controlButton;
            string indexString;

            controlButton = (Button)sender;
            indexString = Regex.Match(controlButton.Name, @"\d+").Value;
            index = Int32.Parse(indexString);

            return index;
            }

        #endregion

        #region Public Methods
        public void ApplySkin()
			{
			SkinStyleClass style;
            string controlName;
            Button controlButton;

			UIManagerClass uiManager = UIManagerClass.UIManager;

			style = uiManager.Skin.GetSkinStyle("MainScreenBackgroundColor");
			this.BackColor = style.Color1;
			
			style = uiManager.Skin.GetSkinStyle("MainScreenNormalLabelFont");
			AlignmentLabel.Font = style.Font;
			AlignmentLabel.ForeColor = style.Color1;
			AlignmentLabel.BackColor = style.Color2;
			RaceLabel.Font = style.Font;
			RaceLabel.ForeColor = style.Color1;
			RaceLabel.BackColor = style.Color2;
			//just testing, making sure skin sytles are working....
			style = uiManager.Skin.GetSkinStyle("MainScreenGrayFont");
			NameLabel.Font = style.Font;
			NameLabel.ForeColor = style.Color1;
			NameLabel.BackColor = style.Color2;
			ClassLabel.Font = style.Font;
			ClassLabel.ForeColor = style.Color1;
			ClassLabel.BackColor = style.Color2;

			//apply the panel skins
			mainScreenAbilitiesPanel1.ApplySkin();
			mainScreenAdditionStatsPanel1.ApplySkin();
            mainScreenFeatsPanel1.ApplySkin();

            //apply the level button styles
            ButtonSelectedStyle = uiManager.Skin.GetSkinStyle("MainScreenLevelButtonSelected");
            ButtonNotSelectedStyle = uiManager.Skin.GetSkinStyle("MainScreenLevelButton");

            for (int i = 1; i < 31; i++)
                {
                controlName = "LevelButton" + i;
                controlButton = (Button)this.Controls[controlName];

                if (i == SelectedLevel)
                    style = ButtonSelectedStyle;
                else
                    style = ButtonNotSelectedStyle;

                controlButton.BackColor = style.Color2;
                controlButton.ForeColor = style.Color1;
                controlButton.Font = style.Font;
                }
			}
        [System.Diagnostics.Conditional("DEBUG")]
        public void DBaccess()
        {
            databaseToolStripMenuItem.Visible = true;
        }
        #endregion

        #region Public Static Methods
        public static void RegisterSkinGroups()
			{
			UIManagerClass uiManager = UIManagerClass.UIManager;

			uiManager.Skin.RegisterSkinGroup("MainScreenBackgroundColor", SkinSettings.FactoryName.ScreenBackgroundColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenNormalLabelFont", SkinSettings.FactoryName.StandardFont);
			uiManager.Skin.RegisterSkinGroup("MainScreenGrayFont", SkinSettings.FactoryName.ReadOnlyFont);
            uiManager.Skin.RegisterSkinGroup("MainScreenLevelButton", SkinSettings.FactoryName.StandardButton);
            uiManager.Skin.RegisterSkinGroup("MainScreenLevelButtonSelected", SkinSettings.FactoryName.StandardButtonSelected);

			MainScreenAbilitiesPanel.RegisterSkinGroups();
			MainScreenAdditionStatsPanel.RegisterSkinGroups();
            MainScreenFeatsPanel.RegisterSkinGroups();

            ClassEditScreen.RegisterSkinGroups();
            FeatsEditScreen.RegisterSkinGroups();
            SkillEditScreen.RegisterSkinGroups();
            SkillTomePanel.RegisterSkinGroups();
            AlignmentEditForm.RegisterSkinGroups();
			}
		#endregion

        
        #region Change Notification Handlers
        private void HandleClassChange()
            {
            labelClasses.Text = CharacterManagerClass.CharacterManager.CharacterClass.GetClassSplit(SelectedLevel);
            mainScreenFeatsPanel1.FeatChange(SelectedLevel);
            SkillPanel.Updatevalues(SelectedLevel);
            }

		private void HandleAbilityChange()
			{
                mainScreenAbilitiesPanel1.AbilityChange(SelectedLevel);
                SkillPanel.Updatevalues(SelectedLevel);
                CharacterManagerClass.CharacterManager.CharacterSkill.IntChange();
			}

        private void HandleRaceChange()
            {
            labelRace.Text = CharacterManagerClass.CharacterManager.CharacterRace.GetRaceName();
            mainScreenAbilitiesPanel1.AbilityChange(SelectedLevel);
            mainScreenFeatsPanel1.FeatChange(SelectedLevel);
            SkillPanel.Updatevalues(SelectedLevel);
            }
        private void HandleSkillChange()
        {
            SkillPanel.Updatevalues(SelectedLevel);
        }
        private void HandlePastLifeChange()
        {
            mainScreenAbilitiesPanel1.AbilityChange(SelectedLevel);
            mainScreenFeatsPanel1.FeatChange(SelectedLevel);
            SkillPanel.Updatevalues(SelectedLevel);
        }
        private void HandleAlignmentChange()
        {
            AlignmentButton.Text = DataManagerClass.DataManager.AlignmentData.Alignment[CharacterManagerClass.CharacterManager.CharacterAlignment.Alignment];
        }
		#endregion

        private void mainScreenAbilitiesPanel1_Load(object sender, EventArgs e)
        {

        }

        private void SkillPanel_Load(object sender, EventArgs e)
        {

        }


        }
	}
