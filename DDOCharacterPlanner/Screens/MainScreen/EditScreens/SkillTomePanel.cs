using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DDOCharacterPlanner.Model;
using DDOCharacterPlanner.Model.Tome;
using DDOCharacterPlanner.Screens.Controls;
using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.CharacterData;

namespace DDOCharacterPlanner.Screens.MainScreen
{
    public partial class SkillTomePanel : Form

    {
    
        #region Member Variables

        SkillTomePanelEntryStruct SkillTomePanelEntry;
                int NumSkills;
                int[,] SkillTomes;
                List<string> SkillNames;
                int[] MinLevel;
    
        #endregion

        #region Structures

            protected struct SkillTomePanelEntryStruct
            {
                public Label[] SkillLabel;
                public NumericUpDownWithBlank[,] TomeUpDown;
                public Label[] PastLifeTome;

            }

        #endregion

            #region constructor

                 public SkillTomePanel()
        {

            int posx = 10;
            int posy = 60;
            int MaxLevel;
            MaxLevel = DDOCharacterPlanner.Utility.Constant.MaxLevels;
            InitializeComponent();
            SkillNames = Enum.GetNames(typeof(CharacterSkillClass.Skills)).ToList();
            NumSkills = SkillNames.Count;
            List<Model.Tome.TomeModel> TomeList;
            TomeList = Model.Tome.TomeModel.GetAllByType("Skill");
            TomeList.Sort((x, y) => x.TomeLongName.CompareTo(y.TomeLongName));
            Dictionary<Guid, string> SkillbyID;
            SkillbyID = new Dictionary<Guid, string>();
            SkillbyID = SkillModel.GetNamesByID();
            //get max number of Tomes
            int TomeCount = TomeModel.GetCountByModifiedId(SkillbyID.Keys.First());

            SkillTomePanelEntry = new SkillTomePanelEntryStruct();
            SkillTomePanelEntry.SkillLabel = new Label[NumSkills];
            SkillTomePanelEntry.PastLifeTome = new Label[NumSkills];
            SkillTomePanelEntry.TomeUpDown= new NumericUpDownWithBlank[NumSkills, TomeCount];

            //create Skill Labels
            for (int i = 0; i < NumSkills;++i )
            {
                SkillTomePanelEntry.SkillLabel[i] = new Label();
                SkillTomePanelEntry.SkillLabel[i].Name = SkillNames[i].ToString() + "Label";
                SkillTomePanelEntry.SkillLabel[i].Text = SkillNames[i].ToString().Replace("_", " ");

                SkillTomePanelEntry.SkillLabel[i].Location = new Point(posx , posy + 27 * i);
                SkillTomePanelEntry.SkillLabel[i].Width = 100;
                SkillTomePanelEntry.SkillLabel[i].Font = new Font("Times New Roman", 9, FontStyle.Bold);
                SkillTomePanelEntry.SkillLabel[i].TextAlign = ContentAlignment.MiddleLeft;



            }
            //create past life Labels
            posx = 500;
            for (int i = 0; i < NumSkills; ++i)
            {
                SkillTomePanelEntry.PastLifeTome[i] = new Label();
                SkillTomePanelEntry.PastLifeTome[i].Name = SkillNames[i].ToString() + "PastLifeLabel";
                SkillTomePanelEntry.PastLifeTome[i].Text = "0";

                SkillTomePanelEntry.PastLifeTome[i].Location = new Point(posx, posy + 27 * i);
                SkillTomePanelEntry.PastLifeTome[i].Width = 50;
                SkillTomePanelEntry.PastLifeTome[i].Font = new Font("Times New Roman", 9, FontStyle.Bold);
                SkillTomePanelEntry.PastLifeTome[i].TextAlign = ContentAlignment.MiddleCenter;



            }

            posx = 127;

                foreach (TomeModel Tome in TomeList)
                {
                    int skillIndex;
                    int skillBonus;
                    skillIndex = SkillNames.IndexOf(SkillbyID[Tome.ModifiedID].Replace(" ","_"));
                    skillBonus = Tome.TomeBonus-1;

                    SkillTomePanelEntry.TomeUpDown[skillIndex, skillBonus] = new NumericUpDownWithBlank();
                    SkillTomePanelEntry.TomeUpDown[skillIndex, skillBonus].Name = SkillbyID[Tome.ModifiedID] + "UpDwn" + (skillBonus + 1);
                    SkillTomePanelEntry.TomeUpDown[skillIndex, skillBonus].Location = new Point(posx + (skillBonus) * 70, posy + skillIndex * 27);
                    SkillTomePanelEntry.TomeUpDown[skillIndex, skillBonus].Width = 40;
                    
                    SkillTomePanelEntry.TomeUpDown[skillIndex, skillBonus].Minimum = 1;
                    SkillTomePanelEntry.TomeUpDown[skillIndex, skillBonus].Maximum = MaxLevel;
                    if (CharacterManagerClass.CharacterManager.CharacterSkill.Tome[skillIndex, skillBonus] > 0)
                    {
                        SkillTomePanelEntry.TomeUpDown[skillIndex, skillBonus].Value = CharacterManagerClass.CharacterManager.CharacterSkill.Tome[skillIndex, skillBonus];
                        SkillTomePanelEntry.TomeUpDown[skillIndex, skillBonus].Blank = false;
                    }
                    else
                    {
                        SkillTomePanelEntry.TomeUpDown[skillIndex, skillBonus].Blank = true;
                    }
                    SkillTomePanelEntry.TomeUpDown[skillIndex, skillBonus].ValueChanged += TomeChanged;



                }




           foreach (Label newcontrol in SkillTomePanelEntry.SkillLabel)
           {
               if (newcontrol != null)
                   Skilltome.Controls.Add(newcontrol);
           }
           foreach (Label newcontrol in SkillTomePanelEntry.PastLifeTome)
           {
               if (newcontrol != null)
                   Skilltome.Controls.Add(newcontrol);
           }
           foreach (NumericUpDownWithBlank newcontrol in SkillTomePanelEntry.TomeUpDown)
           {
               if (newcontrol != null)
                   Skilltome.Controls.Add(newcontrol);
           }

            //set Pastlife tomeValues
           handlePastlifeSkillTomeChange();

            //apply Skin
           SkillTomePanelSkin();

           // listen for events
           UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.SkillTomeEditScreen, ScreenMessengerClass.ChangeList.SkillChange, handlePastlifeSkillTomeChange);

        }

 
            
            
            
            #endregion
            #region private

                private void TomeChanged(object sender, EventArgs e)
                {
                    CharacterSkillClass.Skills Skill;
                    int Bonus;
                    int Level;
                    NumericUpDownWithBlank myControl;
                    myControl = new NumericUpDownWithBlank();
                    myControl = (NumericUpDownWithBlank)sender;
                    string SkillName;
                    SkillName = myControl.Name.Substring(0, myControl.Name.IndexOf("UpDwn")).Replace(" ","_");
                    if (myControl.Blank)
                    {
                        Level = 0;
                    }
                    else
                    {
                    Level = (int)myControl.Value;
                    }
                     
                    Bonus = Convert.ToInt32(myControl.Name.Substring(myControl.Name.IndexOf("UpDwn")+"UpDwn".Length,myControl.Name.Length-myControl.Name.IndexOf("UpDwn")-"UpDwn".Length));
                    Skill = (CharacterSkillClass.Skills)SkillNames.IndexOf(SkillName);
                    CharacterManagerClass.CharacterManager.CharacterSkill.SetTomeBonus(Skill, Bonus, Level);
                    UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.SkillTomeEditScreen, ScreenMessengerClass.ChangeList.SkillChange);
                }

                private void handlePastlifeSkillTomeChange()
                {
                    int MaxSkillTomeBonus;
                    int MaxBonus;
                    
                    for(int i=0;i<NumSkills;++i)
                    {
                        MaxBonus = -1;
                        MaxSkillTomeBonus = Model.Tome.TomeModel.GetMaxBonus(Model.SkillModel.GetIdFromName("Balance"));
                        for (int x = 0; x < MaxSkillTomeBonus; ++x)
                        {
                            if(CharacterManagerClass.CharacterManager.CharacterSkill.PriorLifeTome[i, x]>0)
                            {
                                MaxBonus = x;
                            }
                        }

                        SkillTomePanelEntry.PastLifeTome[i].Text = (MaxBonus + 1).ToString();


    
                    }



                }
             #endregion
             #region public



                //Skin Panel
        public void SkillTomePanelSkin()
                {
                    UIManagerClass uiManager = UIManagerClass.UIManager;
                    SkinStyleClass style;
                    SkinStyleClass style1;

                    //screen background
                    style = uiManager.Skin.GetSkinStyle("SkillTomePanelScreenBackGroundColor");
                    this.BackColor = style.Color1;

                    //panel backgrounds
                    style = uiManager.Skin.GetSkinStyle("SkillTomePanelScreenPanelBackgroundColor");
                    Skilltome.BackColor = style.Color1;

                    //Headers 
                    style = uiManager.Skin.GetSkinStyle("SkillTomePanelScreenPanelHeaderColor");
                    panel2.BackColor = style.Color1;

                    style = uiManager.Skin.GetSkinStyle("SkillTomePanelScreenHeaderLabel");
                    Header.ForeColor = style.Color1;
                    Header.BackColor = style.Color2;
                    Header.Font = style.Font;

                    //Labels
                    style = uiManager.Skin.GetSkinStyle("SkillTomePanelScreenLabelLarge");
                    
                        label2.ForeColor = style.Color1;
                        label2.BackColor = style.Color2;
                        label2.Font = style.Font;

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

                        label7.ForeColor = style.Color1;
                        label7.BackColor = style.Color2;
                        label7.Font = style.Font;

                        label8.ForeColor = style.Color1;
                        label8.BackColor = style.Color2;
                        label8.Font = style.Font;



                        style1 = uiManager.Skin.GetSkinStyle("SkillTomePanelScreenSummary");
                    for (int i = 0; i < NumSkills; ++i)
                    {
                        

                        SkillTomePanelEntry.SkillLabel[i].ForeColor = style.Color1;
                        SkillTomePanelEntry.SkillLabel[i].BackColor = style.Color2;
                        SkillTomePanelEntry.SkillLabel[i].Font = style.Font;

                        SkillTomePanelEntry.PastLifeTome[i].ForeColor = style1.Color1;
                        SkillTomePanelEntry.PastLifeTome[i].BackColor = style1.Color2;
                        SkillTomePanelEntry.PastLifeTome[i].Font = style1.Font;


                    }



                }


        public static void RegisterSkinGroups()
        {
            UIManagerClass uiManager = UIManagerClass.UIManager;

            uiManager.Skin.RegisterSkinGroup("SkillTomePanelScreenBackGroundColor", SkinSettings.FactoryName.ScreenBackgroundColor);
            uiManager.Skin.RegisterSkinGroup("SkillTomePanelScreenPanelBackgroundColor", SkinSettings.FactoryName.PanelBackgroundColor);
            uiManager.Skin.RegisterSkinGroup("SkillTomePanelScreenPanelHeaderColor", SkinSettings.FactoryName.PanelHeaderColor);
            uiManager.Skin.RegisterSkinGroup("SkillTomePanelScreenLabel", SkinSettings.FactoryName.StandardLabel);
            uiManager.Skin.RegisterSkinGroup("SkillTomePanelScreenSummary", SkinSettings.FactoryName.StandardBoldFont);
            uiManager.Skin.RegisterSkinGroup("SkillTomePanelScreenHeaderLabel", SkinSettings.FactoryName.PanelHeaderFont);
            uiManager.Skin.RegisterSkinGroup("SkillTomePanelScreenLabelLarge", SkinSettings.FactoryName.GoldBoldFont);


        }
            #endregion
        #region Panel events
        private void OnCloseSkillTomePanel(object sender, FormClosingEventArgs e)
        {
            
            //Stop listen for updates
            UIManagerClass.UIManager.ScreenMessenger.DeregisterListener(UIManagerClass.ChildScreen.SkillTomeEditScreen);
            UIManagerClass.UIManager.CloseChildScreen(UIManagerClass.ChildScreen.SkillTomeEditScreen);
        }

        #endregion

        private void Header_Click(object sender, EventArgs e)
        {

        }




    }
}
