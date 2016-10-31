using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Screens.MainScreen
	{
	public partial class MainScreenAdditionStatsPanel : UserControl
		{
		#region Constructors
		public MainScreenAdditionStatsPanel()
			{
			InitializeComponent();
			}
		#endregion

		#region Public Methods
		public void ApplySkin()
			{
			//TODO: We need better names for these labels....
			UIManagerClass uiManager = UIManagerClass.UIManager;
			SkinStyleClass style;

			//background
			style = uiManager.Skin.GetSkinStyle("MainScreenAdditionalStatPanelBackgroundColor");
			this.BackColor = style.Color1;

			//header
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityPanelHeaderColor");
			panel1.BackColor = style.Color1;
			style = uiManager.Skin.GetSkinStyle("MainScreenAbilityPanelHeaderLabel");
			label7.ForeColor = style.Color1;
			label7.BackColor = style.Color2;
			label7.Font = style.Font;
			}
		#endregion

		#region Public Static Methods
		/// <summary>
		/// Creates the Skin Group associations with factory settings
		/// </summary>
		public static void RegisterSkinGroups()
			{
			UIManagerClass uiManager = UIManagerClass.UIManager;

			uiManager.Skin.RegisterSkinGroup("MainScreenAdditionalStatPanelBackgroundColor", SkinSettings.FactoryName.PanelBackgroundColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenAdditionalStatPanelHeaderColor", SkinSettings.FactoryName.PanelHeaderColor);
			uiManager.Skin.RegisterSkinGroup("MainScreenAdditionalStatPanelGeneralFont", SkinSettings.FactoryName.StandardFont);
			uiManager.Skin.RegisterSkinGroup("MainScreenAdditionalStatPanelHeaderLabel", SkinSettings.FactoryName.PanelHeaderFont);
			}
		#endregion
		}
	}
