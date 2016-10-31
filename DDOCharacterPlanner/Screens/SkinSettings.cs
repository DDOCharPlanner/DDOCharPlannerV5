
using System.Collections.Generic;
using System.Drawing;

using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Screens
	{
	public class SkinSettings
		{
		#region Enums
		/// <summary>
		/// A list of all the factory and general names
		/// </summary>
		public enum FactoryName
			{
			ScreenBackgroundColor,
			PanelBackgroundColor,
			PanelHeaderColor,
			StandardFont,
			StandardBoldFont,
			SmallFont,
			TinyFont,
			ReadOnlyFont,
			GoldBoldFont,
			PanelHeaderFont,
			PanelHeaderButton,
            StandardLabel,
			//TODO: rename these with generic names
            DIButton1,
            DIButton2,
            DIControls,

            PanelHeader,
            StandardControl,
            ListControl,
            StandardButton,
            StandardButtonSelected,
			}
		#endregion

		#region Private Static Variables
		private static Dictionary<string, SkinStyleClass> SkinDictionary = new Dictionary<string,SkinStyleClass>();
		private static List<List<string>> FactoryToOverrideConversionList = new List<List<string>>();
		#endregion

		#region Public Methods
		public void RegisterSkinGroup(string overrideName, FactoryName factoryName)
			{
			string key;

			key = GetStyleString(factoryName);
			for (int i = 0; i < FactoryToOverrideConversionList.Count; i++)
				{
				if (FactoryToOverrideConversionList[i][0] == key)
					{
					FactoryToOverrideConversionList[i].Add(overrideName);
					return;
					}
				}
			//factory name not yet in the list
			FactoryToOverrideConversionList.Add(new List<string>{key, overrideName});
			}

		public void CreateFactorySettings()
			{
			SkinStyleClass style;
			//Factory Colors
			style = new SkinStyleClass(Color.Black);
			DistributeSkinStyle(GetStyleString(FactoryName.ScreenBackgroundColor), style);
			style = new SkinStyleClass(Color.FromArgb(20, 20, 20));	//a dark gray
			DistributeSkinStyle(GetStyleString(FactoryName.PanelBackgroundColor), style);
			style = new SkinStyleClass(Color.FromArgb(88, 182, 231));
			DistributeSkinStyle(GetStyleString(FactoryName.PanelHeaderColor), style);
			//Factory fonts
			style = new SkinStyleClass("Microsoft San Serif", 8.25f, Color.White);
			DistributeSkinStyle(GetStyleString(FactoryName.StandardFont), style);
			style = new SkinStyleClass("Microsoft San Serif", 10.0f, FontStyle.Bold, Color.White);
			DistributeSkinStyle(GetStyleString(FactoryName.StandardBoldFont), style);
			style = new SkinStyleClass("Microsoft San Serif", 6.25f, Color.White);
			DistributeSkinStyle(GetStyleString(FactoryName.SmallFont), style);
			style = new SkinStyleClass("Microsoft San Serif", 5.50f, Color.White);
			DistributeSkinStyle(GetStyleString(FactoryName.TinyFont), style);
			style = new SkinStyleClass("Microsoft San Serif", 8.25f, Color.DimGray);
			DistributeSkinStyle(GetStyleString(FactoryName.ReadOnlyFont), style);
			style = new SkinStyleClass("Times New Roman", 10.0f, FontStyle.Bold, Color.Gold);
			DistributeSkinStyle(GetStyleString(FactoryName.GoldBoldFont), style);
			style = new SkinStyleClass("Trebuchet MS", 12.0f, FontStyle.Bold, Color.White, Color.FromArgb(88, 182, 231));
			DistributeSkinStyle(GetStyleString(FactoryName.PanelHeaderFont), style);
			//Factory Buttons
			style = new SkinStyleClass("Microsoft San Serif", 8.25f, FontStyle.Bold, Color.White, Color.FromName("DeepSkyBlue"));
			DistributeSkinStyle(GetStyleString(FactoryName.PanelHeaderButton), style);

            style = new SkinStyleClass("Microsoft Sans Serif", 8.25f, FontStyle.Regular, Color.Black, Color.Silver);
            DistributeSkinStyle(GetStyleString(FactoryName.StandardButton), style);
            style = new SkinStyleClass("Microsoft Sans Serif", 8.25f, FontStyle.Regular, Color.Black, Color.Green);
            DistributeSkinStyle(GetStyleString(FactoryName.StandardButtonSelected), style);

			style = new SkinStyleClass("Microsoft Sans Serif", 8.25f, FontStyle.Bold, Color.Black, Color.Silver);
			DistributeSkinStyle(GetStyleString(FactoryName.DIButton1), style);
			style = new SkinStyleClass("Microsoft Sans Serif", 8.25f, FontStyle.Bold, Color.Blue, Color.Black);
			DistributeSkinStyle(GetStyleString(FactoryName.DIButton2), style);
			//Factory Controls
			style = new SkinStyleClass("Microsoft Sans Serif", 8.25f, FontStyle.Regular, Color.White, Color.FromArgb(99, 99, 99));
			DistributeSkinStyle(GetStyleString(FactoryName.DIControls), style);
            style = new SkinStyleClass("Microsoft Sans Serif", 8.25f, FontStyle.Regular, Color.White, Color.Transparent);
            DistributeSkinStyle(GetStyleString(FactoryName.StandardLabel), style);
            style = new SkinStyleClass("Trebucket MS", 12.0f, FontStyle.Bold, Color.White, Color.FromArgb(88, 182, 231));
            DistributeSkinStyle(GetStyleString(FactoryName.PanelHeader), style);
            style = new SkinStyleClass("Microsoft Sans Serif", 8.25f, FontStyle.Regular, Color.White, Color.FromArgb(99, 99, 99));
            DistributeSkinStyle(GetStyleString(FactoryName.StandardControl), style);
            style = new SkinStyleClass("Microsoft Sans Serif", 8.25f, FontStyle.Regular, Color.White, Color.FromArgb(20, 20, 20));
            DistributeSkinStyle(GetStyleString(FactoryName.ListControl), style);
			}

		public SkinStyleClass GetSkinStyle(string key)
			{
			return SkinDictionary[key];
			}
		#endregion

		#region Private Methods
		private void DistributeSkinStyle(string factoryName, SkinStyleClass style)
			{
			string key;

			for (int i = 0; i < FactoryToOverrideConversionList.Count; i++)
				{
				if (FactoryToOverrideConversionList[i][0] == factoryName)
					{
					for (int j = 1; j < FactoryToOverrideConversionList[i].Count; j++)
						{
						key = FactoryToOverrideConversionList[i][j];
						if (SkinDictionary.ContainsKey(key))
							SkinDictionary[key] = style;
						else
							SkinDictionary.Add(key, style);
						}
					}
				}
			}

		private string GetStyleString(FactoryName name)
			{
			switch (name)
				{
				case FactoryName.ScreenBackgroundColor:
					return "StandardBackgroundColor";
				case FactoryName.PanelBackgroundColor:
					return "PanelBackgroundColor";
				case FactoryName.PanelHeaderColor:
					return "PanelHeaderColor";
				case FactoryName.StandardFont:
					return "StandardFont";
				case FactoryName.StandardBoldFont:
					return "StandardBoldFont";
				case FactoryName.SmallFont:
					return "SmallFont";
				case FactoryName.TinyFont:
					return "TinyFont";
				case FactoryName.ReadOnlyFont:
					return "ReadOnlyFont";
				case FactoryName.GoldBoldFont:
					return "GoldFont";
				case FactoryName.PanelHeaderFont:
					return "PanelHeaderFont";
				case FactoryName.PanelHeaderButton:
					return "PanelHeaderButton";
               case FactoryName.DIButton1:
					return "DIButton1";
                case FactoryName.DIButton2:
					return "DIButton2";
                case FactoryName.DIControls:
					return "DIControls";
                case FactoryName.StandardLabel:
                    return "StandardLabel";
                case FactoryName.PanelHeader:
                    return "PanelHeader";
                case FactoryName.StandardButtonSelected:
                    return "StandardButtonSelected";
                case FactoryName.StandardButton:
                    return "StandardButton";
				default:
					return "null";
				}
			}
		#endregion
		}
	}
