using DDOCharacterPlanner.CharacterData;
using DDOCharacterPlanner.Data;
using DDOCharacterPlanner.Properties;
using DDOCharacterPlanner.Screens.Controls;
using DDOCharacterPlanner.Utility;
using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.MainScreen
	{
	public partial class AbilityEditPanel : Form
		{
		#region Enums
		enum Direction
			{
			up,
			down,
			stay
			}
		#endregion

		#region Member Variables
		//TODO: This needs to be generalized for all tooltips (so we can skin them identically). Do we need a tooltip class?
		private Font TooltipFont = new Font("Arial", 8.0f);
		private bool AllowChange;
		#endregion

		#region Constructors
		public AbilityEditPanel()
			{
			InitializeComponent();
			AllowChange = true;

			//update the creation panel
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Strength, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Dexterity, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Constitution, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Intelligence, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Wisdom, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Charisma, Direction.stay);

			//update the level up panel
			InitializeLevelUpPanel();
			StrLevelUpTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Strength, 30, CharacterAbilityClass.ModifierTypes.LevelUp).ToString("+#;-#;0");
			DexLevelUpTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Dexterity, 30, CharacterAbilityClass.ModifierTypes.LevelUp).ToString("+#;-#;0");
			ConLevelUpTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Constitution, 30, CharacterAbilityClass.ModifierTypes.LevelUp).ToString("+#;-#;0");
			IntLevelUpTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Intelligence, 30, CharacterAbilityClass.ModifierTypes.LevelUp).ToString("+#;-#;0");
			WisLevelUpTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Wisdom, 30, CharacterAbilityClass.ModifierTypes.LevelUp).ToString("+#;-#;0");
			ChaLevelUpTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Charisma, 30, CharacterAbilityClass.ModifierTypes.LevelUp).ToString("+#;-#;0");

			//update the tome panel
			InitializeTomePanel();

			//update the summary panel
			UpdateSummaryPanel();

			//listen for a race update
			UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.RaceChange, HandleRaceChange);
            //listen for a past life update
            UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.PastLifeChange, HandlePastLifeChange);
            //listen for a ability update
            UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange, HandleAbilityChange);
			}
		#endregion

		#region Form Events
		private void OnAbilityEditPanelFormClosing(object sender, FormClosingEventArgs e)
			{
            //Stop listen for updates
			UIManagerClass.UIManager.ScreenMessenger.DeregisterListener(UIManagerClass.ChildScreen.AbilityEditScreen);
            UIManagerClass.UIManager.CloseChildScreen(UIManagerClass.ChildScreen.AbilityEditScreen);

			}

		private void AbilitiesEditPanelToolTipDraw(object sender, DrawToolTipEventArgs e)
			{
			e.DrawBackground();
			e.DrawBorder();
			e.Graphics.DrawString(e.ToolTipText, TooltipFont, Brushes.White, new PointF(2, 2));
			}

		private void AbilitiesEditPanelToolTipPopup(object sender, PopupEventArgs e)
			{
			string Text;

			Text = UtilityClass.AddNewLinesForTooltip(AbilitiesEditPanelToolTip.GetToolTip(e.AssociatedControl));
			e.ToolTipSize = TextRenderer.MeasureText(Text, TooltipFont);
			//changing text would re-call this routine (leading to a stack overflow) so turn off the event before changing
			AbilitiesEditPanelToolTip.Popup -= AbilitiesEditPanelToolTipPopup;
			AbilitiesEditPanelToolTip.SetToolTip(e.AssociatedControl, Text);
			AbilitiesEditPanelToolTip.Popup += AbilitiesEditPanelToolTipPopup;
			}

		private void StrCreationRaiseButtonClick(object sender, EventArgs e)
			{
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Strength, Direction.up);
			//update the summary panel
			UpdateSummaryPanel();
			//inform other screens
			UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
			}

		private void DexCreationRaiseButtonClick(object sender, EventArgs e)
			{
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Dexterity, Direction.up);
			//update the summary panel
			UpdateSummaryPanel();
			//inform other screens
			UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
			}

		private void ConCreationRaiseButtonClick(object sender, EventArgs e)
			{
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Constitution, Direction.up);
			//update the summary panel
			UpdateSummaryPanel();
			//inform other screens
			UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
			}

		private void IntCreationRaiseButtonClick(object sender, EventArgs e)
			{
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Intelligence, Direction.up);
			//update the summary panel
			UpdateSummaryPanel();
			//inform other screens
			UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
			}

		private void WisCreationRaiseButtonClick(object sender, EventArgs e)
			{
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Wisdom, Direction.up);
			//update the summary panel
			UpdateSummaryPanel();
			//inform other screens
			UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
			}

		private void ChaCreationRaiseButtonClick(object sender, EventArgs e)
			{
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Charisma, Direction.up);
			//update the summary panel
			UpdateSummaryPanel();
			//inform other screens
			UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
			}

		private void StrCreationLowerButtonClick(object sender, EventArgs e)
			{
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Strength, Direction.down);
			//update the summary panel
			UpdateSummaryPanel();
			//inform other screens
			UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
			}

		private void DexCreationLowerButtonClick(object sender, EventArgs e)
			{
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Dexterity, Direction.down);
			//update the summary panel
			UpdateSummaryPanel();
			//inform other screens
			UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
			}

		private void ConCreationLowerButtonClick(object sender, EventArgs e)
			{
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Constitution, Direction.down);
			//update the summary panel
			UpdateSummaryPanel();
			//inform other screens
			UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
			}

		private void IntCreationLowerButtonClick(object sender, EventArgs e)
			{
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Intelligence, Direction.down);
			//update the summary panel
			UpdateSummaryPanel();
			//inform other screens
			UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
			}

		private void WisCreationLowerButtonClick(object sender, EventArgs e)
			{
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Wisdom, Direction.down);
			//update the summary panel
			UpdateSummaryPanel();
			//inform other screens
			UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
			}

		private void ChaCreationLowerButtonClick(object sender, EventArgs e)
			{
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Charisma, Direction.down);
			//update the summary panel
			UpdateSummaryPanel();
			//inform other screens
			UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
			}

		private void Creation32PointBuildCheckBoxCheckedChanged(object sender, EventArgs e)
			{
			int availableCreationPoints;

			CharacterManagerClass.CharacterManager.CharacterAbility.SetBuildType(CharacterAbilityClass.BuildPointType.Favor, Creation32PointBuildCheckBox.Checked);

			availableCreationPoints = CharacterManagerClass.CharacterManager.CharacterAbility.GetRemainingStatRaisePoints();
			AvailableCreationPointsValueLabel.Text = availableCreationPoints.ToString();

			UpdateCreationPanel(CharacterAbilityClass.Abilities.Strength, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Dexterity, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Constitution, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Intelligence, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Wisdom, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Charisma, Direction.stay);
			}

		private void LevelUpButtonCheckedChanged(object sender, EventArgs e)
			{
			RadioButton button;
			string controlName;
			CharacterAbilityClass.Abilities ability;
			int level;

			button = (RadioButton)sender;
			//don't worry about unchecking
			if (button.Checked == false)
				return;

			//determine the ability changed
			controlName = button.Name;
			ability = CharacterAbilityClass.Abilities.Strength;
			if (controlName.Contains("Str"))
				ability = CharacterAbilityClass.Abilities.Strength;
			if (controlName.Contains("Dex"))
				ability = CharacterAbilityClass.Abilities.Dexterity;
			if (controlName.Contains("Con"))
				ability = CharacterAbilityClass.Abilities.Constitution;
			if (controlName.Contains("Int"))
				ability = CharacterAbilityClass.Abilities.Intelligence;
			if (controlName.Contains("Wis"))
				ability = CharacterAbilityClass.Abilities.Wisdom;
			if (controlName.Contains("Cha"))
				ability = CharacterAbilityClass.Abilities.Charisma;

			//determine the level of the ability
			level = 0;
			if (controlName.Contains("04"))
				level = 4;
			if (controlName.Contains("08"))
				level = 8;
			if (controlName.Contains("12"))
				level = 12;
			if (controlName.Contains("16"))
				level = 16;
			if (controlName.Contains("20"))
				level = 20;
			if (controlName.Contains("24"))
				level = 24;
			if (controlName.Contains("28"))
				level = 28;

			if (level == 0)
				return;

			CharacterManagerClass.CharacterManager.CharacterAbility.SetAbilityLevelUp(ability, level);

			//update the panel
			StrLevelUpTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Strength, 30, CharacterAbilityClass.ModifierTypes.LevelUp).ToString("+#;-#;0");
			DexLevelUpTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Dexterity, 30, CharacterAbilityClass.ModifierTypes.LevelUp).ToString("+#;-#;0");
			ConLevelUpTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Constitution, 30, CharacterAbilityClass.ModifierTypes.LevelUp).ToString("+#;-#;0");
			IntLevelUpTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Intelligence, 30, CharacterAbilityClass.ModifierTypes.LevelUp).ToString("+#;-#;0");
			WisLevelUpTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Wisdom, 30, CharacterAbilityClass.ModifierTypes.LevelUp).ToString("+#;-#;0");
			ChaLevelUpTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Charisma, 30, CharacterAbilityClass.ModifierTypes.LevelUp).ToString("+#;-#;0");

			//update the summary panel
			UpdateSummaryPanel();
			//inform other screens
			UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
			}

		private void TomeUpDownValueChanged(object sender, EventArgs e)
			{
			NumericUpDownWithBlank control;
			string controlName;
			CharacterAbilityClass.Abilities ability;
			int tomeLevel;

			if (AllowChange == true)
				{
				control = (NumericUpDownWithBlank)sender;
				controlName = control.Name;
				//determine the ability changed
				ability = CharacterAbilityClass.Abilities.Strength;
				if (controlName.Contains("Str"))
					ability = CharacterAbilityClass.Abilities.Strength;
				if (controlName.Contains("Dex"))
					ability = CharacterAbilityClass.Abilities.Dexterity;
				if (controlName.Contains("Con"))
					ability = CharacterAbilityClass.Abilities.Constitution;
				if (controlName.Contains("Int"))
					ability = CharacterAbilityClass.Abilities.Intelligence;
				if (controlName.Contains("Wis"))
					ability = CharacterAbilityClass.Abilities.Wisdom;
				if (controlName.Contains("Cha"))
					ability = CharacterAbilityClass.Abilities.Charisma;

				//determine the level of the tome
				tomeLevel = 0;
				if (controlName.Contains("1"))
					tomeLevel = 1;
				if (controlName.Contains("2"))
					tomeLevel = 2;
				if (controlName.Contains("3"))
					tomeLevel = 3;
				if (controlName.Contains("4"))
					tomeLevel = 4;
				if (controlName.Contains("5"))
					tomeLevel = 5;
				if (controlName.Contains("6"))
					tomeLevel = 6;
                if (controlName.Contains("7"))
                    tomeLevel = 7;

				if (control.Blank == true)
					CharacterManagerClass.CharacterManager.CharacterAbility.SetTomeBonus(ability, tomeLevel, 0);
				else
					CharacterManagerClass.CharacterManager.CharacterAbility.SetTomeBonus(ability, tomeLevel, (int)control.Value);

				//inform other screens
				UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AbilityEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
				}
			//update the panel
            updateTomePanel();
			//update the summary panel
			UpdateSummaryPanel();
			}
        private void updateTomePanel()
        {
            //update the panel
            StrTomeTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Strength, 30, CharacterAbilityClass.ModifierTypes.Tome).ToString("+#;-#;0");
            DexTomeTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Dexterity, 30, CharacterAbilityClass.ModifierTypes.Tome).ToString("+#;-#;0");
            ConTomeTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Constitution, 30, CharacterAbilityClass.ModifierTypes.Tome).ToString("+#;-#;0");
            IntTomeTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Intelligence, 30, CharacterAbilityClass.ModifierTypes.Tome).ToString("+#;-#;0");
            WisTomeTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Wisdom, 30, CharacterAbilityClass.ModifierTypes.Tome).ToString("+#;-#;0");
            ChaTomeTotal.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Charisma, 30, CharacterAbilityClass.ModifierTypes.Tome).ToString("+#;-#;0");

        }

		private void SummaryPanelLevelSelectionValueChanged(object sender, EventArgs e)
			{
			UpdateSummaryPanel();
			}
		#endregion

		#region Public Methods
		/// <summary>
		/// Applies the Skin Groups to individual controls
		/// </summary>
		public void ApplySkin()
			{
			//TODO: We need better names for these labels....
			UIManagerClass uiManager = UIManagerClass.UIManager;
			SkinStyleClass style;

			//screen background
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenBackgroundColor");
			this.BackColor = style.Color1;

			//panel backgrounds
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenCurrentValuesPanelBackgroundColor");
			CurrentValuesPanel.BackColor = style.Color1;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenCreationPanelBackgroundColor");
			CreationPanel.BackColor = style.Color1;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenLevelUpPanelBackgroundColor");
			LevelUpPanel.BackColor = style.Color1;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenTomesPanelBackgroundColor");
			TomesPanel.BackColor = style.Color1;

			//headers
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenCurrentValuesPanelHeaderColor");
			panel4.BackColor = style.Color1;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenCreationPanelHeaderColor");
			panel2.BackColor = style.Color1;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenLevelUpPanelHeaderColor");
			panel6.BackColor = style.Color1;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenTomesPanelHeaderColor");
			panel8.BackColor = style.Color1;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenPanelCurrentValuesPanelHeaderLabel");
			label19.ForeColor = style.Color1;
			label19.BackColor = style.Color2;
			label19.Font = style.Font;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenPanelCreationPanelHeaderLabel");
			label7.ForeColor = style.Color1;
			label7.BackColor = style.Color2;
			label7.Font = style.Font;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenPanelLevelUpHeaderLabel");
			label47.ForeColor = style.Color1;
			label47.BackColor = style.Color2;
			label47.Font = style.Font;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenPanelTomesHeaderLabel");
			label68.ForeColor = style.Color1;
			label68.BackColor = style.Color2;
			label68.Font = style.Font;

			//ability labels (lots of these)
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenPanelAbilityLabelLarge");
			label26.ForeColor = style.Color1;
			label26.BackColor = style.Color2;
			label26.Font = style.Font;
			label27.ForeColor = style.Color1;
			label27.BackColor = style.Color2;
			label27.Font = style.Font;
			label28.ForeColor = style.Color1;
			label28.BackColor = style.Color2;
			label28.Font = style.Font;
			label29.ForeColor = style.Color1;
			label29.BackColor = style.Color2;
			label29.Font = style.Font;
			label30.ForeColor = style.Color1;
			label30.BackColor = style.Color2;
			label30.Font = style.Font;
			label31.ForeColor = style.Color1;
			label31.BackColor = style.Color2;
			label31.Font = style.Font;
			label3.ForeColor = style.Color1;
			label3.BackColor = style.Color2;
			label3.Font = style.Font;
			label4.ForeColor = style.Color1;
			label4.BackColor = style.Color2;
			label4.Font = style.Font;
			label5.ForeColor = style.Color1;
			label5.BackColor = style.Color2;
			label5.Font = style.Font;
			label6.ForeColor = style.Color1;
			label6.BackColor = style.Color2;
			label6.Font = style.Font;
			label14.ForeColor = style.Color1;
			label14.BackColor = style.Color2;
			label14.Font = style.Font;
			label15.ForeColor = style.Color1;
			label15.BackColor = style.Color2;
			label15.Font = style.Font;
			label41.ForeColor = style.Color1;
			label41.BackColor = style.Color2;
			label41.Font = style.Font;
			label42.ForeColor = style.Color1;
			label42.BackColor = style.Color2;
			label42.Font = style.Font;
			label43.ForeColor = style.Color1;
			label43.BackColor = style.Color2;
			label43.Font = style.Font;
			label44.ForeColor = style.Color1;
			label44.BackColor = style.Color2;
			label44.Font = style.Font;
			label45.ForeColor = style.Color1;
			label45.BackColor = style.Color2;
			label45.Font = style.Font;
			label46.ForeColor = style.Color1;
			label46.BackColor = style.Color2;
			label46.Font = style.Font;
			label61.ForeColor = style.Color1;
			label61.BackColor = style.Color2;
			label61.Font = style.Font;
			label62.ForeColor = style.Color1;
			label62.BackColor = style.Color2;
			label62.Font = style.Font;
			label63.ForeColor = style.Color1;
			label63.BackColor = style.Color2;
			label63.Font = style.Font;
			label64.ForeColor = style.Color1;
			label64.BackColor = style.Color2;
			label64.Font = style.Font;
			label65.ForeColor = style.Color1;
			label65.BackColor = style.Color2;
			label65.Font = style.Font;
			label66.ForeColor = style.Color1;
			label66.BackColor = style.Color2;
			label66.Font = style.Font;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityEditScreenPanelAbilityLabelSmall");
			label20.ForeColor = style.Color1;
			label20.BackColor = style.Color2;
			label20.Font = style.Font;
			label21.ForeColor = style.Color1;
			label21.BackColor = style.Color2;
			label21.Font = style.Font;
			label22.ForeColor = style.Color1;
			label22.BackColor = style.Color2;
			label22.Font = style.Font;
			label23.ForeColor = style.Color1;
			label23.BackColor = style.Color2;
			label23.Font = style.Font;
			label24.ForeColor = style.Color1;
			label24.BackColor = style.Color2;
			label24.Font = style.Font;
			label25.ForeColor = style.Color1;
			label25.BackColor = style.Color2;
			label25.Font = style.Font;
			label8.ForeColor = style.Color1;
			label8.BackColor = style.Color2;
			label8.Font = style.Font;
			label9.ForeColor = style.Color1;
			label9.BackColor = style.Color2;
			label9.Font = style.Font;
			label10.ForeColor = style.Color1;
			label10.BackColor = style.Color2;
			label10.Font = style.Font;
			label11.ForeColor = style.Color1;
			label11.BackColor = style.Color2;
			label11.Font = style.Font;
			label12.ForeColor = style.Color1;
			label12.BackColor = style.Color2;
			label12.Font = style.Font;
			label13.ForeColor = style.Color1;
			label13.BackColor = style.Color2;
			label13.Font = style.Font;
			label35.ForeColor = style.Color1;
			label35.BackColor = style.Color2;
			label35.Font = style.Font;
			label36.ForeColor = style.Color1;
			label36.BackColor = style.Color2;
			label36.Font = style.Font;
			label37.ForeColor = style.Color1;
			label37.BackColor = style.Color2;
			label37.Font = style.Font;
			label38.ForeColor = style.Color1;
			label38.BackColor = style.Color2;
			label38.Font = style.Font;
			label39.ForeColor = style.Color1;
			label39.BackColor = style.Color2;
			label39.Font = style.Font;
			label40.ForeColor = style.Color1;
			label40.BackColor = style.Color2;
			label40.Font = style.Font;
			label55.ForeColor = style.Color1;
			label55.BackColor = style.Color2;
			label55.Font = style.Font;
			label56.ForeColor = style.Color1;
			label56.BackColor = style.Color2;
			label56.Font = style.Font;
			label57.ForeColor = style.Color1;
			label57.BackColor = style.Color2;
			label57.Font = style.Font;
			label58.ForeColor = style.Color1;
			label58.BackColor = style.Color2;
			label58.Font = style.Font;
			label59.ForeColor = style.Color1;
			label59.BackColor = style.Color2;
			label59.Font = style.Font;
			label60.ForeColor = style.Color1;
			label60.BackColor = style.Color2;
			label60.Font = style.Font;
			}
		#endregion

		#region Public Static Methods
		/// <summary>
		/// Creates the Skin Group associations with factory settings
		/// </summary>
		public static void RegisterSkinGroups()
			{
			UIManagerClass uiManager = UIManagerClass.UIManager;

			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenBackgroundColor", SkinSettings.FactoryName.ScreenBackgroundColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenCurrentValuesPanelBackgroundColor", SkinSettings.FactoryName.PanelBackgroundColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenCreationPanelBackgroundColor", SkinSettings.FactoryName.PanelBackgroundColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenLevelUpPanelBackgroundColor", SkinSettings.FactoryName.PanelBackgroundColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenTomesPanelBackgroundColor", SkinSettings.FactoryName.PanelBackgroundColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenCurrentValuesPanelHeaderColor", SkinSettings.FactoryName.PanelHeaderColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenCreationPanelHeaderColor", SkinSettings.FactoryName.PanelHeaderColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenLevelUpPanelHeaderColor", SkinSettings.FactoryName.PanelHeaderColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenTomesPanelHeaderColor", SkinSettings.FactoryName.PanelHeaderColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenPanelCurrentValuesPanelHeaderLabel", SkinSettings.FactoryName.PanelHeaderFont);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenPanelCreationPanelHeaderLabel", SkinSettings.FactoryName.PanelHeaderFont);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenPanelLevelUpHeaderLabel", SkinSettings.FactoryName.PanelHeaderFont);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenPanelTomesHeaderLabel", SkinSettings.FactoryName.PanelHeaderFont);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenPanelAbilityLabelLarge", SkinSettings.FactoryName.GoldBoldFont);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityEditScreenPanelAbilityLabelSmall", SkinSettings.FactoryName.TinyFont);
			}
		#endregion

		#region Private Methods
		private void UpdateCreationPanel(CharacterAbilityClass.Abilities ability, Direction direction)
			{
			int availableCreationPoints;
			int pointsSpent;
			int baseAbility;
			int maxAbility;
			int abilityCost;
			bool up;


			if (direction == Direction.up)
				up = true;
			else
				up = false;

			if (direction != Direction.stay)
			CharacterManagerClass.CharacterManager.CharacterAbility.AdjustBaseStatRaise(ability, up);
			availableCreationPoints = CharacterManagerClass.CharacterManager.CharacterAbility.GetRemainingStatRaisePoints();
			AvailableCreationPointsValueLabel.Text = availableCreationPoints.ToString();
			pointsSpent = CharacterManagerClass.CharacterManager.CharacterAbility.GetStatRaiseSpent(ability);
			baseAbility = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(ability, 30, CharacterAbilityClass.ModifierTypes.Creation);
			maxAbility = DataManagerClass.DataManager.RaceDataCollection.Races[CharacterManagerClass.CharacterManager.CharacterRace.GetRaceName()].BaseAbilityMax[(int)ability];
			abilityCost = CharacterManagerClass.CharacterManager.CharacterAbility.GetStatRaiseCost(ability);
			//note it is possible to be at a negative value for build points now. If so, let the user know there is an error!
			if (availableCreationPoints < 0)
				{
				label7.ForeColor = Color.Red;
				AvailableCreationPointsValueLabel.ForeColor = Color.Red;
				}
			else
				{
				label7.ForeColor = Color.White;
				AvailableCreationPointsValueLabel.ForeColor = Color.White;
				}

			if (direction == Direction.down)
				{
				//turn on all plus buttons
				StrCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButton");
				DexCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButton");
				ConCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButton");
				IntCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButton");
				WisCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButton");
				ChaCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButton");
				}

			switch (ability)
				{
				case CharacterAbilityClass.Abilities.Strength:
					{
					BaseStrLabel.Text = baseAbility.ToString();
					StrCostLabel.Text = abilityCost.ToString();
					StrPointsSpentLabel.Text = pointsSpent.ToString();
					if (pointsSpent == 0)
						StrCreationLowerButton.Image = (Image)Resources.ResourceManager.GetObject("MinusButtonDisabled");
					else
						StrCreationLowerButton.Image = (Image)Resources.ResourceManager.GetObject("MinusButton");
					StrCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButton");
					if (baseAbility >= maxAbility)
						StrCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButtonDisabled");
					break;
					}
				case CharacterAbilityClass.Abilities.Dexterity:
					{
					BaseDexLabel.Text = baseAbility.ToString();
					DexCostLabel.Text = abilityCost.ToString();
					DexPointsSpentLabel.Text = pointsSpent.ToString();
					if (pointsSpent == 0)
						DexCreationLowerButton.Image = (Image)Resources.ResourceManager.GetObject("MinusButtonDisabled");
					else
						DexCreationLowerButton.Image = (Image)Resources.ResourceManager.GetObject("MinusButton");
					DexCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButton");
					if (baseAbility >= maxAbility)
						DexCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButtonDisabled");
					break;
					}
				case CharacterAbilityClass.Abilities.Constitution:
					{
					BaseConLabel.Text = baseAbility.ToString();
					ConCostLabel.Text = abilityCost.ToString();
					ConPointsSpentLabel.Text = pointsSpent.ToString();
					if (pointsSpent == 0)
						ConCreationLowerButton.Image = (Image)Resources.ResourceManager.GetObject("MinusButtonDisabled");
					else
						ConCreationLowerButton.Image = (Image)Resources.ResourceManager.GetObject("MinusButton");
					ConCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButton");
					if (baseAbility >= maxAbility)
						ConCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButtonDisabled");
					break;
					}
				case CharacterAbilityClass.Abilities.Intelligence:
					{
					BaseIntLabel.Text = baseAbility.ToString();
					IntCostLabel.Text = abilityCost.ToString();
					IntPointsSpentLabel.Text = pointsSpent.ToString();
					if (pointsSpent == 0)
						IntCreationLowerButton.Image = (Image)Resources.ResourceManager.GetObject("MinusButtonDisabled");
					else
						IntCreationLowerButton.Image = (Image)Resources.ResourceManager.GetObject("MinusButton");
					IntCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButton");
					if (baseAbility >= maxAbility)
						IntCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButtonDisabled");
					break;
					}
				case CharacterAbilityClass.Abilities.Wisdom:
					{
					BaseWisLabel.Text = baseAbility.ToString();
					WisCostLabel.Text = abilityCost.ToString();
					WisPointsSpentLabel.Text = pointsSpent.ToString();
					if (pointsSpent == 0)
						WisCreationLowerButton.Image = (Image)Resources.ResourceManager.GetObject("MinusButtonDisabled");
					else
						WisCreationLowerButton.Image = (Image)Resources.ResourceManager.GetObject("MinusButton");
					WisCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButton");
					if (baseAbility >= maxAbility)
						WisCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButtonDisabled");
					break;
					}
				case CharacterAbilityClass.Abilities.Charisma:
					{
					BaseChaLabel.Text = baseAbility.ToString();
					ChaCostLabel.Text = abilityCost.ToString();
					ChaPointsSpentLabel.Text = pointsSpent.ToString();
					if (pointsSpent == 0)
						ChaCreationLowerButton.Image = (Image)Resources.ResourceManager.GetObject("MinusButtonDisabled");
					else
						ChaCreationLowerButton.Image = (Image)Resources.ResourceManager.GetObject("MinusButton");
					ChaCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButton");
					if (baseAbility >= maxAbility)
						ChaCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButtonDisabled");
					break;
					}
				}
			//final check on the plus buttons, disable if available points is less than point cost
			UpdateCreationPanelDisablePlusButtons(availableCreationPoints);
			}

		/// <summary>
		/// We need a function to properly set the radiobuttons on the level up panel when the screen is created
		/// </summary>
		private void InitializeLevelUpPanel()
			{
			CharacterAbilityClass.Abilities ability;
			string[] abilityNames = { "Str", "Dex", "Con", "Int", "Wis", "Cha" };
			StringBuilder controlName;
			Control[] control;
			RadioButton radiobutton;

			for (int i = 4; i < Constant.MaxLevels; i += 4)
				{
				ability = CharacterManagerClass.CharacterManager.CharacterAbility.LevelUp[i - 1];

				controlName = new StringBuilder();
				controlName.Append(abilityNames[(int)ability]);
				controlName.Append("LevelUp");
				controlName.Append(i.ToString("D2"));
				control = Controls.Find(controlName.ToString(), true);
				radiobutton = (RadioButton)control[0];
				if (radiobutton == null)
					return;
				radiobutton.Checked = true;
				}
			}

		private void InitializeTomePanel()
			{
			StringBuilder controlName;
			string[] abilityNames = { "Str", "Dex", "Con", "Int", "Wis", "Cha" };
			Control[] control;
			NumericUpDownWithBlank upDown;
			Label label;
			int tomeLevel;
            int MaxAbilityTomeBonus = Model.Tome.TomeModel.GetMaxBonus(Model.AbilityModel.GetIdFromName("Strength"));

			//load the updown boxes
			for (int i = 0; i < CharacterManagerClass.CharacterManager.CharacterAbility.NumAbilities; i++)
				{
				for (int j = 0; j < MaxAbilityTomeBonus; j++)
					{
					controlName = new StringBuilder();
					controlName.Append("Tome");
					controlName.Append(abilityNames[i]);
					controlName.Append(j + 1);
					controlName.Append("UpDown");
					control = Controls.Find(controlName.ToString(), true);
					upDown = (NumericUpDownWithBlank)control[0];
					if (upDown == null)
						continue;
					SetTomeUpDownMinMax(upDown);
					tomeLevel = CharacterManagerClass.CharacterManager.CharacterAbility.Tome[i, j];
					if (tomeLevel >= upDown.Minimum && tomeLevel <= upDown.Maximum)
						{
						upDown.Blank = false;
						upDown.Value = tomeLevel;
						}
					else
						upDown.Blank = true;
					}
				}

			//set the past life values
			
            
            CharacterAbilityClass.Abilities ability;
			for (int i = 0; i < CharacterManagerClass.CharacterManager.CharacterAbility.NumAbilities; i++)
				{   
                    tomeLevel = 0;
                    int PriorLifeTomeBonus = 0;
                    ability = CharacterAbilityClass.Abilities.Strength;
                    if (abilityNames[i]=="Str")
                        ability = CharacterAbilityClass.Abilities.Strength;
                    if (abilityNames[i]=="Dex")
                        ability = CharacterAbilityClass.Abilities.Dexterity;
                    if (abilityNames[i]=="Con")
                        ability = CharacterAbilityClass.Abilities.Constitution;
                    if (abilityNames[i]=="Int")
                        ability = CharacterAbilityClass.Abilities.Intelligence;
                    if (abilityNames[i]=="Wis")
                        ability = CharacterAbilityClass.Abilities.Wisdom;
                    if (abilityNames[i]=="Cha")
                        ability = CharacterAbilityClass.Abilities.Charisma;
                    PriorLifeTomeBonus = 0;
                    for (int x = 0; x < MaxAbilityTomeBonus;++x)
                    {
                        if (CharacterManagerClass.CharacterManager.CharacterAbility.PriorLifeTome[(int)ability, x] > PriorLifeTomeBonus)
                        {
                        PriorLifeTomeBonus = CharacterManagerClass.CharacterManager.CharacterAbility.PriorLifeTome[(int)ability, x];
                        tomeLevel = x + 1;
                        }
                     }
                controlName = new StringBuilder();
				controlName.Append(abilityNames[i]);
				controlName.Append("TomePastLife");
				control = Controls.Find(controlName.ToString(), true);
				if (control.Length == 0)
					continue;
				label = (Label)control[0];
				label.Text = tomeLevel.ToString("+#;-#;0");
				}
			}

		/// <summary>
		/// this will turn off any plus buttons that the user doesn't have enough points for
		/// </summary>
		/// <param name="available"></param>
		private void UpdateCreationPanelDisablePlusButtons(int available)
			{
			int abilityCost;

			abilityCost = CharacterManagerClass.CharacterManager.CharacterAbility.GetStatRaiseCost(CharacterAbilityClass.Abilities.Strength);
			if (abilityCost > available)
				StrCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButtonDisabled");

			abilityCost = CharacterManagerClass.CharacterManager.CharacterAbility.GetStatRaiseCost(CharacterAbilityClass.Abilities.Dexterity);
			if (abilityCost > available)
				DexCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButtonDisabled");

			abilityCost = CharacterManagerClass.CharacterManager.CharacterAbility.GetStatRaiseCost(CharacterAbilityClass.Abilities.Constitution);
			if (abilityCost > available)
				ConCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButtonDisabled");

			abilityCost = CharacterManagerClass.CharacterManager.CharacterAbility.GetStatRaiseCost(CharacterAbilityClass.Abilities.Intelligence);
			if (abilityCost > available)
				IntCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButtonDisabled");

			abilityCost = CharacterManagerClass.CharacterManager.CharacterAbility.GetStatRaiseCost(CharacterAbilityClass.Abilities.Wisdom);
			if (abilityCost > available)
				WisCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButtonDisabled");

			abilityCost = CharacterManagerClass.CharacterManager.CharacterAbility.GetStatRaiseCost(CharacterAbilityClass.Abilities.Charisma);
			if (abilityCost > available)
				ChaCreationRaiseButton.Image = (Image)Resources.ResourceManager.GetObject("PlusButtonDisabled");
			}

		private void SetTomeUpDownMinMax(NumericUpDown control)
			{
			int tomeLevel;
			string subString;
			Match index;
			Regex rg = new Regex("\\d+");

			//don't allow this to change the initial values in the character ability class
			AllowChange = false;

			index = rg.Match(control.Name);
			subString = control.Name.Substring(index.Index, 1);
			Int32.TryParse(subString, out tomeLevel);

			control.Minimum = 1;
			control.Maximum = Constant.MaxLevels;

			//validate current value
			if (control.Value < control.Minimum)
				control.Value = control.Minimum;
			if (control.Value > control.Maximum)
				control.Value = control.Maximum;

			AllowChange = true;
			}

		private void UpdateSummaryPanel()
			{
			CharacterAbilityClass.ModifierTypes type;
			int abilityValue;
			int abilityMod;
			int level;

			level = (int)SummaryPanelLevelSelection.Value;
			type = CharacterAbilityClass.ModifierTypes.Base | CharacterAbilityClass.ModifierTypes.CreationRaise | CharacterAbilityClass.ModifierTypes.LevelUp | CharacterAbilityClass.ModifierTypes.Tome;

			abilityValue = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Strength, level, type);
			StrSummaryTotal.Text = abilityValue.ToString();
			abilityMod = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(abilityValue);
			StrSummaryMod.Text = abilityMod.ToString("+#;-#;0");

			abilityValue = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Dexterity, level, type);
			DexSummaryTotal.Text = abilityValue.ToString();
			abilityMod = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(abilityValue);
			DexSummaryMod.Text = abilityMod.ToString("+#;-#;0");

			abilityValue = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Constitution, level, type);
			ConSummaryTotal.Text = abilityValue.ToString();
			abilityMod = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(abilityValue);
			ConSummaryMod.Text = abilityMod.ToString("+#;-#;0");

			abilityValue = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Intelligence, level, type);
			IntSummaryTotal.Text = abilityValue.ToString();
			abilityMod = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(abilityValue);
			IntSummaryMod.Text = abilityMod.ToString("+#;-#;0");

			abilityValue = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Wisdom, level, type);
			WisSummaryTotal.Text = abilityValue.ToString();
			abilityMod = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(abilityValue);
			WisSummaryMod.Text = abilityMod.ToString("+#;-#;0");

			abilityValue = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Charisma, level, type);
			ChaSummaryTotal.Text = abilityValue.ToString();
			abilityMod = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(abilityValue);
			ChaSummaryMod.Text = abilityMod.ToString("+#;-#;0");
			}

		#endregion

		#region Change Handlers
		public void HandleRaceChange()
			{
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Strength, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Dexterity, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Constitution, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Intelligence, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Wisdom, Direction.stay);
			UpdateCreationPanel(CharacterAbilityClass.Abilities.Charisma, Direction.stay);

			UpdateSummaryPanel();
			}
        public void HandlePastLifeChange()
        {
            UpdateCreationPanel(CharacterAbilityClass.Abilities.Strength, Direction.stay);
            UpdateCreationPanel(CharacterAbilityClass.Abilities.Dexterity, Direction.stay);
            UpdateCreationPanel(CharacterAbilityClass.Abilities.Constitution, Direction.stay);
            UpdateCreationPanel(CharacterAbilityClass.Abilities.Intelligence, Direction.stay);
            UpdateCreationPanel(CharacterAbilityClass.Abilities.Wisdom, Direction.stay);
            UpdateCreationPanel(CharacterAbilityClass.Abilities.Charisma, Direction.stay);

            UpdateSummaryPanel();
        }
                public void HandleAbilityChange()
        {

            InitializeTomePanel();
            updateTomePanel();
            UpdateSummaryPanel();
        }
		#endregion

        }
	}
