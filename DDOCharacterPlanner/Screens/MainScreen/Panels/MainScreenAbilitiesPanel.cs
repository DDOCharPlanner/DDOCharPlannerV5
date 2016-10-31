using DDOCharacterPlanner.CharacterData;
using DDOCharacterPlanner.Utility;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.MainScreen
	{
	public partial class MainScreenAbilitiesPanel : UserControl
		{
		private AbilityEditPanel AbilityEdit;

		#region Constructors
		public MainScreenAbilitiesPanel()
			{
			InitializeComponent();
			}
		#endregion

		#region Form Events
		private void OnAbilityPanelEditButtonClick(object sender, System.EventArgs e)
			{
                if (CharacterManagerClass.CharacterManager.CharacterRace.GetRaceName() == "")
                {
                    MessageBox.Show("Set Race first", "Missing Race", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.AbilityEditScreen);

                }
			}
		#endregion

		#region Public Methods
		public void RaceChange(int selectedLevel)
			{
			BaseStrLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Strength, 30, CharacterAbilityClass.ModifierTypes.Creation).ToString();
			BaseDexLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Dexterity, 30, CharacterAbilityClass.ModifierTypes.Creation).ToString();
			BaseConLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Constitution, 30, CharacterAbilityClass.ModifierTypes.Creation).ToString();
			BaseIntLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Intelligence, 30, CharacterAbilityClass.ModifierTypes.Creation).ToString();
			BaseWisLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Wisdom, 30, CharacterAbilityClass.ModifierTypes.Creation).ToString();
			BaseChaLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Charisma, 30, CharacterAbilityClass.ModifierTypes.Creation).ToString();

			TotalStrLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Strength, 30, CharacterAbilityClass.ModifierTypes.All).ToString();
			TotalDexLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Dexterity, 30, CharacterAbilityClass.ModifierTypes.All).ToString();
			TotalConLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Constitution, 30, CharacterAbilityClass.ModifierTypes.All).ToString();
			TotalIntLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Intelligence, 30, CharacterAbilityClass.ModifierTypes.All).ToString();
			TotalWisLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Wisdom, 30, CharacterAbilityClass.ModifierTypes.All).ToString();
			TotalChaLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Charisma, 30, CharacterAbilityClass.ModifierTypes.All).ToString();

			ModStrLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(CharacterAbilityClass.Abilities.Strength).ToString("+#;-#;0"); ;
			ModDexLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(CharacterAbilityClass.Abilities.Dexterity).ToString("+#;-#;0"); ;
			ModConLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(CharacterAbilityClass.Abilities.Constitution).ToString("+#;-#;0"); ;
			ModIntLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(CharacterAbilityClass.Abilities.Intelligence).ToString("+#;-#;0");
			ModWisLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(CharacterAbilityClass.Abilities.Wisdom).ToString("+#;-#;0");
			ModChaLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(CharacterAbilityClass.Abilities.Charisma).ToString("+#;-#;0");
			}

        public void AbilityChange(int selectedLevel)
        {
            BaseStrLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Strength, selectedLevel, CharacterAbilityClass.ModifierTypes.Creation).ToString();
            BaseDexLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Dexterity, selectedLevel, CharacterAbilityClass.ModifierTypes.Creation).ToString();
            BaseConLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Constitution, selectedLevel, CharacterAbilityClass.ModifierTypes.Creation).ToString();
            BaseIntLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Intelligence, selectedLevel, CharacterAbilityClass.ModifierTypes.Creation).ToString();
            BaseWisLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Wisdom, selectedLevel, CharacterAbilityClass.ModifierTypes.Creation).ToString();
            BaseChaLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Charisma, selectedLevel, CharacterAbilityClass.ModifierTypes.Creation).ToString();

            LevelStrLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Strength, selectedLevel, CharacterAbilityClass.ModifierTypes.LevelUp).ToString();
            LevelDexLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Dexterity, selectedLevel, CharacterAbilityClass.ModifierTypes.LevelUp).ToString();
            LevelConLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Constitution, selectedLevel, CharacterAbilityClass.ModifierTypes.LevelUp).ToString();
            LevelIntLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Intelligence, selectedLevel, CharacterAbilityClass.ModifierTypes.LevelUp).ToString();
            LevelWisLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Wisdom, selectedLevel, CharacterAbilityClass.ModifierTypes.LevelUp).ToString();
			LevelChaLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Charisma, selectedLevel, CharacterAbilityClass.ModifierTypes.LevelUp).ToString();

			TomeStrLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Strength, selectedLevel, CharacterAbilityClass.ModifierTypes.Tome).ToString();
			TomeDexLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Dexterity, selectedLevel, CharacterAbilityClass.ModifierTypes.Tome).ToString();
			TomeConLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Constitution, selectedLevel, CharacterAbilityClass.ModifierTypes.Tome).ToString();
			TomeIntLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Intelligence, selectedLevel, CharacterAbilityClass.ModifierTypes.Tome).ToString();
			TomeWisLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Wisdom, selectedLevel, CharacterAbilityClass.ModifierTypes.Tome).ToString();
			TomeChaLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Charisma, selectedLevel, CharacterAbilityClass.ModifierTypes.Tome).ToString();

            TotalStrLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Strength, selectedLevel, CharacterAbilityClass.ModifierTypes.All).ToString();
            TotalDexLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Dexterity, selectedLevel, CharacterAbilityClass.ModifierTypes.All).ToString();
            TotalConLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Constitution, selectedLevel, CharacterAbilityClass.ModifierTypes.All).ToString();
            TotalIntLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Intelligence, selectedLevel, CharacterAbilityClass.ModifierTypes.All).ToString();
            TotalWisLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Wisdom, selectedLevel, CharacterAbilityClass.ModifierTypes.All).ToString();
            TotalChaLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetAbility(CharacterAbilityClass.Abilities.Charisma, selectedLevel, CharacterAbilityClass.ModifierTypes.All).ToString();

            ModStrLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(CharacterAbilityClass.Abilities.Strength, selectedLevel).ToString("+#;-#;0"); ;
            ModDexLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(CharacterAbilityClass.Abilities.Dexterity, selectedLevel).ToString("+#;-#;0"); ;
            ModConLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(CharacterAbilityClass.Abilities.Constitution, selectedLevel).ToString("+#;-#;0"); ;
            ModIntLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(CharacterAbilityClass.Abilities.Intelligence, selectedLevel).ToString("+#;-#;0");
            ModWisLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(CharacterAbilityClass.Abilities.Wisdom, selectedLevel).ToString("+#;-#;0");
            ModChaLabel.Text = CharacterManagerClass.CharacterManager.CharacterAbility.GetMod(CharacterAbilityClass.Abilities.Charisma, selectedLevel).ToString("+#;-#;0");
			}

		/// <summary>
		/// Applies the Skin Groups to individual controls
		/// </summary>
		public void ApplySkin()
			{
			//TODO: We need better names for these labels....
			UIManagerClass uiManager = UIManagerClass.UIManager;
			SkinStyleClass style;

			//background
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityPanelBackgroundColor");
			this.BackColor = style.Color1;

			//column labels
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityPanelColumnLabelFont");
			label14.Font = style.Font;
			label15.Font = style.Font;
			label16.Font = style.Font;
			label17.Font = style.Font;
			label18.Font = style.Font;
			label19.Font = style.Font;
			label20.Font = style.Font;
			label21.Font = style.Font;
			label22.Font = style.Font;

			//ability labels (small)
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityPanelAbilityLabelSmall");
			label8.ForeColor = style.Color1;
			label9.ForeColor = style.Color1;
			label10.ForeColor = style.Color1;
			label11.ForeColor = style.Color1;
			label12.ForeColor = style.Color1;
			label13.ForeColor = style.Color1;
			label8.BackColor = style.Color2;
			label9.BackColor = style.Color2;
			label10.BackColor = style.Color2;
			label11.BackColor = style.Color2;
			label12.BackColor = style.Color2;
			label13.BackColor = style.Color2;
			label8.Font = style.Font;
			label9.Font = style.Font;
			label10.Font = style.Font;
			label11.Font = style.Font;
			label12.Font = style.Font;
			label13.Font = style.Font;

			//ability labels (large)
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityPanelAbilityLabelLarge");
			label1.ForeColor = style.Color1;
			label2.ForeColor = style.Color1;
			label3.ForeColor = style.Color1;
			label4.ForeColor = style.Color1;
			label5.ForeColor = style.Color1;
			label6.ForeColor = style.Color1;
			label1.BackColor = style.Color2;
			label2.BackColor = style.Color2;
			label3.BackColor = style.Color2;
			label4.BackColor = style.Color2;
			label5.BackColor = style.Color2;
			label6.BackColor = style.Color2;
			label1.Font = style.Font;
			label2.Font = style.Font;
			label3.Font = style.Font;
			label4.Font = style.Font;
			label5.Font = style.Font;
			label6.Font = style.Font;

			//the "+" labels
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityPanelSecondaryLabel");
			label77.ForeColor = style.Color1;
			label78.ForeColor = style.Color1;
			label79.ForeColor = style.Color1;
			label80.ForeColor = style.Color1;
			label81.ForeColor = style.Color1;
			label82.ForeColor = style.Color1;
			label83.ForeColor = style.Color1;
			label84.ForeColor = style.Color1;
			label85.ForeColor = style.Color1;
			label86.ForeColor = style.Color1;
			label87.ForeColor = style.Color1;
			label88.ForeColor = style.Color1;
			label89.ForeColor = style.Color1;
			label90.ForeColor = style.Color1;
			label91.ForeColor = style.Color1;
			label92.ForeColor = style.Color1;
			label93.ForeColor = style.Color1;
			label94.ForeColor = style.Color1;
			label95.ForeColor = style.Color1;
			label96.ForeColor = style.Color1;
			label97.ForeColor = style.Color1;
			label98.ForeColor = style.Color1;
			label99.ForeColor = style.Color1;
			label100.ForeColor = style.Color1;
			label101.ForeColor = style.Color1;
			label102.ForeColor = style.Color1;
			label103.ForeColor = style.Color1;
			label104.ForeColor = style.Color1;
			label105.ForeColor = style.Color1;
			label106.ForeColor = style.Color1;
			label107.ForeColor = style.Color1;
			label108.ForeColor = style.Color1;
			label109.ForeColor = style.Color1;
			label110.ForeColor = style.Color1;
			label111.ForeColor = style.Color1;
			label112.ForeColor = style.Color1;
			label77.BackColor = style.Color2;
			label78.BackColor = style.Color2;
			label79.BackColor = style.Color2;
			label80.BackColor = style.Color2;
			label81.BackColor = style.Color2;
			label82.BackColor = style.Color2;
			label83.BackColor = style.Color2;
			label84.BackColor = style.Color2;
			label85.BackColor = style.Color2;
			label86.BackColor = style.Color2;
			label87.BackColor = style.Color2;
			label88.BackColor = style.Color2;
			label89.BackColor = style.Color2;
			label90.BackColor = style.Color2;
			label91.BackColor = style.Color2;
			label92.BackColor = style.Color2;
			label93.BackColor = style.Color2;
			label94.BackColor = style.Color2;
			label95.BackColor = style.Color2;
			label96.BackColor = style.Color2;
			label97.BackColor = style.Color2;
			label98.BackColor = style.Color2;
			label99.BackColor = style.Color2;
			label100.BackColor = style.Color2;
			label101.BackColor = style.Color2;
			label102.BackColor = style.Color2;
			label103.BackColor = style.Color2;
			label104.BackColor = style.Color2;
			label105.BackColor = style.Color2;
			label106.BackColor = style.Color2;
			label107.BackColor = style.Color2;
			label108.BackColor = style.Color2;
			label109.BackColor = style.Color2;
			label110.BackColor = style.Color2;
			label111.BackColor = style.Color2;
			label112.BackColor = style.Color2;
			label77.Font = style.Font;
			label78.Font = style.Font;
			label79.Font = style.Font;
			label80.Font = style.Font;
			label81.Font = style.Font;
			label82.Font = style.Font;
			label83.Font = style.Font;
			label84.Font = style.Font;
			label85.Font = style.Font;
			label86.Font = style.Font;
			label87.Font = style.Font;
			label88.Font = style.Font;
			label89.Font = style.Font;
			label90.Font = style.Font;
			label91.Font = style.Font;
			label92.Font = style.Font;
			label93.Font = style.Font;
			label94.Font = style.Font;
			label95.Font = style.Font;
			label96.Font = style.Font;
			label97.Font = style.Font;
			label98.Font = style.Font;
			label99.Font = style.Font;
			label100.Font = style.Font;
			label101.Font = style.Font;
			label102.Font = style.Font;
			label103.Font = style.Font;
			label104.Font = style.Font;
			label105.Font = style.Font;
			label106.Font = style.Font;
			label107.Font = style.Font;
			label108.Font = style.Font;
			label109.Font = style.Font;
			label110.Font = style.Font;
			label111.Font = style.Font;
			label112.Font = style.Font;
			//the "=" labels
			label119.ForeColor = style.Color1;
			label120.ForeColor = style.Color1;
			label121.ForeColor = style.Color1;
			label122.ForeColor = style.Color1;
			label123.ForeColor = style.Color1;
			label124.ForeColor = style.Color1;
			label119.BackColor = style.Color2;
			label120.BackColor = style.Color2;
			label121.BackColor = style.Color2;
			label122.BackColor = style.Color2;
			label123.BackColor = style.Color2;
			label124.BackColor = style.Color2;
			label119.Font = style.Font;
			label120.Font = style.Font;
			label121.Font = style.Font;
			label122.Font = style.Font;
			label123.Font = style.Font;
			label124.Font = style.Font;

			//header
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityPanelHeaderColor");
			panel1.BackColor = style.Color1;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityPanelHeaderLabel");
			label7.ForeColor = style.Color1;
			label7.BackColor = style.Color2;
			label7.Font = style.Font;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityPanelHeaderButton");
			AbilityPanelEditButton.ForeColor = style.Color1;
			AbilityPanelEditButton.BackColor = style.Color2;
			AbilityPanelEditButton.Font = style.Font;

			//totals labels
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityPanelTotalsLabel");
			TotalChaLabel.ForeColor = style.Color1;
			TotalWisLabel.ForeColor = style.Color1;
			TotalIntLabel.ForeColor = style.Color1;
			TotalConLabel.ForeColor = style.Color1;
			TotalDexLabel.ForeColor = style.Color1;
			TotalStrLabel.ForeColor = style.Color1;
			TotalChaLabel.BackColor = style.Color2;
			TotalWisLabel.BackColor = style.Color2;
			TotalIntLabel.BackColor = style.Color2;
			TotalConLabel.BackColor = style.Color2;
			TotalDexLabel.BackColor = style.Color2;
			TotalStrLabel.BackColor = style.Color2;
			TotalChaLabel.Font = style.Font;
			TotalWisLabel.Font = style.Font;
			TotalIntLabel.Font = style.Font;
			TotalConLabel.Font = style.Font;
			TotalDexLabel.Font = style.Font;
			TotalStrLabel.Font = style.Font;

			//the number labels
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityPanelColumnNumbersFont");
			BaseStrLabel.ForeColor = style.Color1;
			BaseDexLabel.ForeColor = style.Color1;
			BaseConLabel.ForeColor = style.Color1;
			BaseIntLabel.ForeColor = style.Color1;
			BaseWisLabel.ForeColor = style.Color1;
			BaseChaLabel.ForeColor = style.Color1;
			LevelStrLabel.ForeColor = style.Color1;
			LevelDexLabel.ForeColor = style.Color1;
			LevelConLabel.ForeColor = style.Color1;
			LevelIntLabel.ForeColor = style.Color1;
			LevelWisLabel.ForeColor = style.Color1;
			LevelChaLabel.ForeColor = style.Color1;
			TomeStrLabel.ForeColor = style.Color1;
			TomeDexLabel.ForeColor = style.Color1;
			TomeConLabel.ForeColor = style.Color1;
			TomeIntLabel.ForeColor = style.Color1;
			TomeWisLabel.ForeColor = style.Color1;
			TomeChaLabel.ForeColor = style.Color1;
			label41.ForeColor = style.Color1;
			label42.ForeColor = style.Color1;
			label43.ForeColor = style.Color1;
			label44.ForeColor = style.Color1;
			label45.ForeColor = style.Color1;
			label46.ForeColor = style.Color1;
			label47.ForeColor = style.Color1;
			label48.ForeColor = style.Color1;
			label49.ForeColor = style.Color1;
			label50.ForeColor = style.Color1;
			label51.ForeColor = style.Color1;
			label52.ForeColor = style.Color1;
			label53.ForeColor = style.Color1;
			label54.ForeColor = style.Color1;
			label55.ForeColor = style.Color1;
			label56.ForeColor = style.Color1;
			label57.ForeColor = style.Color1;
			label58.ForeColor = style.Color1;
			label59.ForeColor = style.Color1;
			label60.ForeColor = style.Color1;
			label61.ForeColor = style.Color1;
			label62.ForeColor = style.Color1;
			label63.ForeColor = style.Color1;
			label64.ForeColor = style.Color1;
			ModChaLabel.ForeColor = style.Color1;
			ModWisLabel.ForeColor = style.Color1;
			ModIntLabel.ForeColor = style.Color1;
			ModConLabel.ForeColor = style.Color1;
			ModDexLabel.ForeColor = style.Color1;
			ModStrLabel.ForeColor = style.Color1;
			BaseStrLabel.BackColor = style.Color2;
			BaseDexLabel.BackColor = style.Color2;
			BaseConLabel.BackColor = style.Color2;
			BaseIntLabel.BackColor = style.Color2;
			BaseWisLabel.BackColor = style.Color2;
			BaseChaLabel.BackColor = style.Color2;
			LevelStrLabel.BackColor = style.Color2;
			LevelDexLabel.BackColor = style.Color2;
			LevelConLabel.BackColor = style.Color2;
			LevelIntLabel.BackColor = style.Color2;
			LevelWisLabel.BackColor = style.Color2;
			LevelChaLabel.BackColor = style.Color2;
			TomeStrLabel.BackColor = style.Color2;
			TomeDexLabel.BackColor = style.Color2;
			TomeConLabel.BackColor = style.Color2;
			TomeIntLabel.BackColor = style.Color2;
			TomeWisLabel.BackColor = style.Color2;
			TomeChaLabel.BackColor = style.Color2;
			label41.BackColor = style.Color2;
			label42.BackColor = style.Color2;
			label43.BackColor = style.Color2;
			label44.BackColor = style.Color2;
			label45.BackColor = style.Color2;
			label46.BackColor = style.Color2;
			label47.BackColor = style.Color2;
			label48.BackColor = style.Color2;
			label49.BackColor = style.Color2;
			label50.BackColor = style.Color2;
			label51.BackColor = style.Color2;
			label52.BackColor = style.Color2;
			label53.BackColor = style.Color2;
			label54.BackColor = style.Color2;
			label55.BackColor = style.Color2;
			label56.BackColor = style.Color2;
			label57.BackColor = style.Color2;
			label58.BackColor = style.Color2;
			label59.BackColor = style.Color2;
			label60.BackColor = style.Color2;
			label61.BackColor = style.Color2;
			label62.BackColor = style.Color2;
			label63.BackColor = style.Color2;
			label64.BackColor = style.Color2;
			ModChaLabel.BackColor = style.Color2;
			ModWisLabel.BackColor = style.Color2;
			ModIntLabel.BackColor = style.Color2;
			ModConLabel.BackColor = style.Color2;
			ModDexLabel.BackColor = style.Color2;
			ModStrLabel.BackColor = style.Color2;
			BaseStrLabel.Font = style.Font;
			BaseDexLabel.Font = style.Font;
			BaseConLabel.Font = style.Font;
			BaseIntLabel.Font = style.Font;
			BaseWisLabel.Font = style.Font;
			BaseChaLabel.Font = style.Font;
			LevelStrLabel.Font = style.Font;
			LevelDexLabel.Font = style.Font;
			LevelConLabel.Font = style.Font;
			LevelIntLabel.Font = style.Font;
			LevelWisLabel.Font = style.Font;
			LevelChaLabel.Font = style.Font;
			TomeStrLabel.Font = style.Font;
			TomeDexLabel.Font = style.Font;
			TomeConLabel.Font = style.Font;
			TomeIntLabel.Font = style.Font;
			TomeWisLabel.Font = style.Font;
			TomeChaLabel.Font = style.Font;
			label41.Font = style.Font;
			label42.Font = style.Font;
			label43.Font = style.Font;
			label44.Font = style.Font;
			label45.Font = style.Font;
			label46.Font = style.Font;
			label47.Font = style.Font;
			label48.Font = style.Font;
			label49.Font = style.Font;
			label50.Font = style.Font;
			label51.Font = style.Font;
			label52.Font = style.Font;
			label53.Font = style.Font;
			label54.Font = style.Font;
			label55.Font = style.Font;
			label56.Font = style.Font;
			label57.Font = style.Font;
			label58.Font = style.Font;
			label59.Font = style.Font;
			label60.Font = style.Font;
			label61.Font = style.Font;
			label62.Font = style.Font;
			label63.Font = style.Font;
			label64.Font = style.Font;
			ModChaLabel.Font = style.Font;
			ModWisLabel.Font = style.Font;
			ModIntLabel.Font = style.Font;
			ModConLabel.Font = style.Font;
			ModDexLabel.Font = style.Font;
			ModStrLabel.Font = style.Font;
			}
		#endregion

		#region Public Static Methods
		/// <summary>
		/// Creates the Skin Group associations with factory settings
		/// </summary>
		public static void RegisterSkinGroups()
			{
			UIManagerClass uiManager = UIManagerClass.UIManager;

			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityPanelBackgroundColor", SkinSettings.FactoryName.PanelBackgroundColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityPanelHeaderColor", SkinSettings.FactoryName.PanelHeaderColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityPanelHeaderButton", SkinSettings.FactoryName.PanelHeaderButton);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityPanelColumnLabelFont", SkinSettings.FactoryName.SmallFont);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityPanelColumnNumbersFont", SkinSettings.FactoryName.StandardFont);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityPanelAbilityLabelSmall", SkinSettings.FactoryName.TinyFont);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityPanelAbilityLabelLarge", SkinSettings.FactoryName.GoldBoldFont);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityPanelSecondaryLabel", SkinSettings.FactoryName.ReadOnlyFont);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityPanelHeaderLabel", SkinSettings.FactoryName.PanelHeaderFont);
			uiManager.Skin.RegisterSkinGroup("MainScreenAbilityPanelTotalsLabel", SkinSettings.FactoryName.StandardBoldFont);

			AbilityEditPanel.RegisterSkinGroups();
			}
		#endregion
		}
	}
