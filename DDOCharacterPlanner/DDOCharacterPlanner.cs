using DDOCharacterPlanner.Data;
using DDOCharacterPlanner.SaveDataModel;
using DDOCharacterPlanner.Screens;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner
	{
	static class DDOCharacterPlanner1
		{

		[STAThread]
		static void Main(string[] args)
			{
			DataManagerClass dataManager = DataManagerClass.DataManager;
			UIManagerClass uiManager = UIManagerClass.UIManager;
			RegistryKey installedVersions;
			string[] versionNames;
			double framework;

			//do a check on the installed version of .NET (if <4.0 display an error)
			installedVersions = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
			versionNames = installedVersions.GetSubKeyNames();
			//version names start with 'v', eg, 'v3.5' which needs to be trimmed off before conversion
			framework = Convert.ToDouble(versionNames[versionNames.Length - 1].Remove(0, 1), CultureInfo.InvariantCulture);
			if (framework < 4.0)
				{
				MessageBox.Show("The DDO Character Planner requires .NET Framework 4.0 or higher. Please visit http://www.microsoft.com/en-us/download/details.aspx?id=17851 to obtain the required .NET Version", "Critical Error", MessageBoxButtons.OK);
				return;
				}

            //Temporary call to fix Feat Descriptions, should comment out once done
            //UtilityClass.FixFeatDescriptions();

			//skin group registrations
			uiManager.RegisterSkinGroups();

			//grab any data we need for display on the main screen
			dataManager.InitializeDataDictionaries();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//create the skin factory settings
			uiManager.CreateSkinFactorySettings();
			//Create the main screen
			uiManager.InitializeMainScreen();
			Application.Run(uiManager.MainScreen);

			}
		}
	}
