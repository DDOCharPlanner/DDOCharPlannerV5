using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.CharacterData;
using DDOCharacterPlanner.Data;
using DDOCharacterPlanner.Screens.MainScreen.EditScreens;
using DDOCharacterPlanner.Screens.Controls;


namespace DDOCharacterPlanner.Screens.MainScreen
{
    public partial class AlignmentEditForm : Form
    {
        
      #region Member Variables
        AlignmentPanelEntryStruct AlignmentPanelEntry;
        bool AllowChange;
      #endregion

        #region Structures
        protected struct AlignmentPanelEntryStruct
        {
            public CustomRadioButton[] AlignmentControl;


        }
        #endregion

        #region Constructors
          public AlignmentEditForm()
        {
            InitializeComponent();
            int AlignmentCount;
            AlignmentCount = DataManagerClass.DataManager.AlignmentData.Alignment.Count();
            AlignmentPanelEntry.AlignmentControl = new CustomRadioButton[AlignmentCount];
            int i = 0;
            int startx = 10;
            int starty = 30;
            foreach(string Alignment in DataManagerClass.DataManager.AlignmentData.AlignmentNames)
            {
                AlignmentPanelEntry.AlignmentControl[i] = new CustomRadioButton();
                AlignmentPanelEntry.AlignmentControl[i].Name = Alignment.Replace(" ", "_");
                AlignmentPanelEntry.AlignmentControl[i].Text = Alignment;
                AlignmentPanelEntry.AlignmentControl[i].Checked = false;
                AlignmentPanelEntry.AlignmentControl[i].Location = new Point(startx, starty + i * 30);
                AlignmentPanelEntry.AlignmentControl[i].Width = 200;
                AlignmentPanelEntry.AlignmentControl[i].disabledColor = Color.LightGray;
                AlignmentPanelEntry.AlignmentControl[i].CheckedChanged += OnSelectionChange;
                i++;
            }

            //Place all controls
            for (int z = 0; z < AlignmentPanelEntry.AlignmentControl.Count(); ++z)
            {
                AlignmentPanel.Controls.Add(AlignmentPanelEntry.AlignmentControl[z]);




            }
            AllowChange = false;
            ApplySkin();
            SetValid();
            GetAlignment();
            UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.AlignmentEditForm, ScreenMessengerClass.ChangeList.ClassChange, HandleClassChange);
            UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.AlignmentEditForm, ScreenMessengerClass.ChangeList.RaceChange, HandleRaceChange);
            UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.AlignmentEditForm, ScreenMessengerClass.ChangeList.AlignmentChange, HandleAlignmentChange);
              AllowChange = true;
          }

        #endregion

		#region Form Events
        
  
		#endregion

        #region Control Events
          private void OnSelectionChange(object sender, EventArgs e)
          {
              if (AllowChange)
              {
                  RadioButton btn;
                  btn = new RadioButton();
                  btn = (RadioButton)sender;
                  CharacterManagerClass.CharacterManager.CharacterAlignment.UpdateAlignment(btn.Text);
                  UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.AlignmentEditForm, ScreenMessengerClass.ChangeList.AlignmentChange);
              }
          }
        private void AlignmentEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
                UIManagerClass.UIManager.CloseChildScreen(UIManagerClass.ChildScreen.AlignmentEditForm);

        }

    
        #endregion

        #region Private Methods
        private void SetValid()
        {
            Guid ClassID;
            string ClassName;
            ClassID = CharacterManagerClass.CharacterManager.CharacterClass.GetClass(1);
            ClassName = DataManagerClass.DataManager.ClassDataCollection.GetClassName(ClassID);
            foreach (RadioButton myRadio in AlignmentPanelEntry.AlignmentControl)
            {

                if (ClassName != "") 
                { 
                    for (int i = 0; i < DataManagerClass.DataManager.ClassDataCollection.Classes[ClassName].AllowedAlignment.Count(); i++)
                    {
                        if(DataManagerClass.DataManager.AlignmentData.AlignmentbyName[myRadio.Text] == DataManagerClass.DataManager.ClassDataCollection.Classes[ClassName].AllowedAlignment[i])
                        {
                            myRadio.Enabled = true;
                            break;
                        }
                        else
                        {
                            myRadio.Enabled = false;
                        }


                    }
                }
                else
                {
                    myRadio.Enabled = true;
                }
            }
        }
        private void GetAlignment()
        {
            foreach(RadioButton myRadio in AlignmentPanelEntry.AlignmentControl)
            {
                if(DataManagerClass.DataManager.AlignmentData.AlignmentbyName[myRadio.Text] == CharacterManagerClass.CharacterManager.CharacterAlignment.Alignment)
                {
                    myRadio.Checked = true;
                    return;
                }
            }
        }




        

        #endregion

        #region Public Methods
        public void ApplySkin()
			{
			SkinStyleClass style;
            SkinStyleClass style1;
            RadioButton controlButton;

			UIManagerClass uiManager = UIManagerClass.UIManager;

            style = uiManager.Skin.GetSkinStyle("MainScreenAlignmentEditScreenBackgroundColor");
            this.BackColor = style.Color1;

            style = uiManager.Skin.GetSkinStyle("MainScreenAlignmentEditScreenPanelBackgroundColor");
            AlignmentPanel.BackColor = style.Color1;


            style = uiManager.Skin.GetSkinStyle("MainScreenAlignmentEditScreenPanelHeaderColor");
            Header.BackColor = style.Color1;

            style = uiManager.Skin.GetSkinStyle("MainScreenAlignmentEditScreenPanelPanelHeaderLabel");
            HeaderLabel.Font = style.Font;
            HeaderLabel.ForeColor = style.Color1;
            HeaderLabel.BackColor = style.Color2;

            style = uiManager.Skin.GetSkinStyle("MainScreenAlignmentEditScreenButton");

            //apply style to the Radio buttons
            style = uiManager.Skin.GetSkinStyle("MainScreenAlignmentEditLabelLarge");
            style1 = uiManager.Skin.GetSkinStyle("MainScreenAlignmentEditScreenPanelBackgroundColor");
                for (int i = 0; i < AlignmentPanelEntry.AlignmentControl.Count(); i++)
                {

                    controlButton = (RadioButton)AlignmentPanelEntry.AlignmentControl[i];
                    controlButton.BackColor = style1.Color1;
                    controlButton.Font = style.Font;
                    controlButton.ForeColor = style.Color1;
                }
			}
 
        #endregion

        #region Public Static Methods
        public static void RegisterSkinGroups()
			{
			UIManagerClass uiManager = UIManagerClass.UIManager;

            uiManager.Skin.RegisterSkinGroup("MainScreenAlignmentEditScreenBackgroundColor", SkinSettings.FactoryName.ScreenBackgroundColor);
            uiManager.Skin.RegisterSkinGroup("MainScreenAlignmentEditScreenNormalLabelFont", SkinSettings.FactoryName.StandardFont);
            uiManager.Skin.RegisterSkinGroup("MainScreenAlignmentEditScreenGrayFont", SkinSettings.FactoryName.ReadOnlyFont);
            uiManager.Skin.RegisterSkinGroup("MainScreenAlignmentEditScreenButton", SkinSettings.FactoryName.StandardButton);

            uiManager.Skin.RegisterSkinGroup("MainScreenAlignmentEditScreenPanelBackgroundColor", SkinSettings.FactoryName.PanelBackgroundColor);
            uiManager.Skin.RegisterSkinGroup("MainScreenAlignmentEditScreenPanelHeaderColor", SkinSettings.FactoryName.PanelHeaderColor);
            uiManager.Skin.RegisterSkinGroup("MainScreenAlignmentEditScreenPanelPanelHeaderLabel", SkinSettings.FactoryName.PanelHeaderFont);
            uiManager.Skin.RegisterSkinGroup("MainScreenAlignmentEditLabelLarge", SkinSettings.FactoryName.GoldBoldFont);
			}
		#endregion



        
        #region Change Notification Handlers
        private void HandleRaceChange()
        {
            AllowChange = false;
            foreach (RadioButton myRadio in AlignmentPanelEntry.AlignmentControl)
            {
                if (DataManagerClass.DataManager.AlignmentData.AlignmentbyName[myRadio.Text] == CharacterManagerClass.CharacterManager.CharacterAlignment.Alignment)
                {
                    myRadio.Checked = true;
                    break;
                }
            }

            SetValid();
            AllowChange = true;


        }
        private void HandleAlignmentChange()
        {
            AllowChange = false;
            foreach (RadioButton myRadio in AlignmentPanelEntry.AlignmentControl)
            {
                if (DataManagerClass.DataManager.AlignmentData.AlignmentbyName[myRadio.Text] == CharacterManagerClass.CharacterManager.CharacterAlignment.Alignment)
                {
                    myRadio.Checked = true;
                    break;
                }
            }

            SetValid();
            AllowChange = true;


        }
        private void HandleClassChange()
        {
            AllowChange = false;
            foreach (RadioButton myRadio in AlignmentPanelEntry.AlignmentControl)
            {
                if (DataManagerClass.DataManager.AlignmentData.AlignmentbyName[myRadio.Text] == CharacterManagerClass.CharacterManager.CharacterAlignment.Alignment)
                {
                    myRadio.Checked = true;
                    break;
                }
            }

            SetValid();
            AllowChange = true;


        }
		#endregion









    }
}
