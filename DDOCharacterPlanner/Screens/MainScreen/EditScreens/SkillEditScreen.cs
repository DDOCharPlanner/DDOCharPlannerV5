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
using System.Diagnostics;

namespace DDOCharacterPlanner.Screens.MainScreen
{
    public partial class SkillEditScreen : Form
    {

        #region Member Variables
        

        int MaxLevel;
        List<string> SkillNames;
       
        bool[,] CharacterSkills;
        SkillPanelEntryStruct SkillPanelEntry;
        SkillAutoPanelStruct SkillAutoPanel;
        SkillSubPanelEntryStruct SkillSubPanelEntry;
        int NumSkills;
        int NumLevel;
        int[] SkillsRemaining;
        int[] SkillTotal;
        int[] SkillAbility;
        int[] SkillTome;
        int[] SkillPastLifeTome;
        int[] SkillGTotal;
        Guid[] Classes;
        Guid[] ClassesAtLevel;
        List<Model.SkillModel> SkillList;
        List<List<Model.SkillModel>> SkillCollection;
        List<bool> ClassOnlySkills;
        int[] MaxRank;
        List<int>[] PriorityList;



        #endregion

        #region Structures
        protected struct SkillPanelEntryStruct
        {
            public Label[] SkillLabel;
            public Label[] SkillAbility;
            public Label[] SkillTome;
            public Label[] SkillFeat;
            public Label[] SkillTotal;
            public Label[] SkillRank;
            public GroupBox[] Divider;
           
        }
        protected struct SkillSubPanelEntryStruct
        {
            public Label[] SkillRemaining;
            public Label[] Level;
            public LabelWithBorder[,] SkillPoints;
            public RepeatingButtonClass[,] SkillButtonUp;
            public RepeatingButtonClass[,] SkillButtonDown;
            public GroupBox[] Divider;
        }
        protected struct SkillAutoPanelStruct
        {
            public Label[] RestictLabel;
            public NumericUpDownWithBlank[] SkillPriority;
            public NumericUpDownWithBlank[] SkillSet;        
        }
        #endregion

        #region Constructor

        
        public SkillEditScreen()
        {

            
            
            int posx = 0;
            int posy = 0;
            InitializeComponent();
            
            SkillNames = Enum.GetNames(typeof(CharacterSkillClass.Skills)).ToList();
            NumSkills = SkillNames.Count;
            PriorityList = new List<int>[NumSkills];

            MaxRank = new int[NumSkills];
            ClassOnlySkills = new List<bool>();
            List<int> tempList;
            tempList = new List<int>();
            for (int i = 0; i < NumSkills;++i )
            {
                ClassOnlySkills.Add(Model.SkillModel.GetIsClassOnly(SkillNames[i].Replace("_", " ")));
                MaxRank[i] = 0;
                PriorityList[i] = new List<int>();  
            }



                NumLevel = 20;
            
            SkillTotal = new int[NumSkills];
            SkillAbility = new int[NumSkills];
            SkillTome = new int[NumSkills];
            SkillPastLifeTome = new int[NumSkills];
            SkillsRemaining = new int[NumLevel];
            SkillGTotal = new int[NumSkills];
            for(int i =0; i<NumSkills;++i)
            {
                SkillTotal[i] = 0;
                SkillTome[i] = 0;
                SkillPastLifeTome[i] = 0;
                
                SkillGTotal[i] = 0;

            }
            for (int i = 0; i < NumLevel;++i )
                SkillsRemaining[i] = 0;

            StringBuilder controlName;
            SkillPanelEntry.SkillLabel = new Label[NumSkills];
            SkillPanelEntry.SkillRank = new Label[NumSkills]; 
            SkillPanelEntry.SkillTome = new Label[NumSkills];
            SkillPanelEntry.SkillFeat = new Label[NumSkills];
            SkillPanelEntry.SkillAbility = new Label[NumSkills];
            SkillPanelEntry.SkillTotal = new Label[NumSkills];
            SkillPanelEntry.Divider = new GroupBox[NumSkills];
            SkillSubPanelEntry.Divider = new GroupBox[NumSkills];
            SkillSubPanelEntry.Level = new Label[NumLevel];
            SkillSubPanelEntry.SkillRemaining = new Label[NumLevel];
            SkillSubPanelEntry.SkillPoints = new LabelWithBorder[NumSkills, NumLevel];


            SkillSubPanelEntry.SkillButtonUp = new RepeatingButtonClass[NumSkills, NumLevel];
            SkillSubPanelEntry.SkillButtonDown = new RepeatingButtonClass[NumSkills, NumLevel];
            SkillAutoPanel.RestictLabel = new Label[NumSkills];
            SkillAutoPanel.SkillPriority = new NumericUpDownWithBlank[NumSkills];
            SkillAutoPanel.SkillSet = new NumericUpDownWithBlank[NumSkills];
            
            Padding buttonMargin;
            posx = 20;
            posy = 90;
            int SkillColWidth = 50;
            for (int z = 0; z < NumLevel; ++z)
            {
                // Create Remaing Points Lables
                SkillSubPanelEntry.SkillRemaining[z] = new Label();
                controlName = new StringBuilder();
                controlName.Append("Remaining");
                controlName.Append(z+1);
                SkillSubPanelEntry.SkillRemaining[z].Name = controlName.ToString();
                SkillSubPanelEntry.SkillRemaining[z].Text = SkillsRemaining[z].ToString();
                SkillSubPanelEntry.SkillRemaining[z].Location = new Point(posx + ((z) * SkillColWidth), posy - 90);
                SkillSubPanelEntry.SkillRemaining[z].Width = SkillColWidth;
                SkillSubPanelEntry.SkillRemaining[z].Font = new Font("Times New Roman", 9, FontStyle.Bold);
                SkillSubPanelEntry.SkillRemaining[z].TextAlign = ContentAlignment.MiddleCenter;
                
                // Create Level Labels
                SkillSubPanelEntry.Level[z] = new Label();
                controlName = new StringBuilder();
                controlName.Append("Level");
                controlName.Append(z+1);
                SkillSubPanelEntry.Level[z].Name = controlName.ToString();
                SkillSubPanelEntry.Level[z].Text = "LVL " + (z+1);
                SkillSubPanelEntry.Level[z].AutoSize = false;
                SkillSubPanelEntry.Level[z].Width = SkillColWidth;
                SkillSubPanelEntry.Level[z].Height = 40;

                SkillSubPanelEntry.Level[z].Font = new Font("Times New Roman", 9, FontStyle.Bold);
                SkillSubPanelEntry.Level[z].TextAlign = ContentAlignment.MiddleCenter;
                SkillSubPanelEntry.Level[z].Location = new Point(posx + ((z) * SkillColWidth), posy - 70);
 

            }
                for (int i = 0; i < NumSkills; ++i)
                {
                    //Create skill Labels
                    
                    SkillPanelEntry.SkillLabel[i] = new Label();
                    controlName = new StringBuilder();
                    controlName.Append(SkillNames[i]);
                    controlName.Append("Label");
                    SkillPanelEntry.SkillLabel[i].Name = controlName.ToString();
                    SkillPanelEntry.SkillLabel[i].Text = SkillNames[i].Replace("_"," ");
                    SkillPanelEntry.SkillLabel[i].TextAlign = ContentAlignment.MiddleLeft;
                    SkillPanelEntry.SkillLabel[i].Font = new Font("Times New Roman", 9, FontStyle.Bold);
                    SkillPanelEntry.SkillLabel[i].Location = new Point(posx, posy);

                    //Create skill Rank Labels
                    SkillPanelEntry.SkillRank[i] = new Label();
                    controlName = new StringBuilder();
                    controlName.Append(SkillNames[i]);
                    controlName.Append("Rank");
                    SkillPanelEntry.SkillRank[i].Name = controlName.ToString();
                    SkillPanelEntry.SkillRank[i].Width = 38;
                    SkillPanelEntry.SkillRank[i].TextAlign = ContentAlignment.MiddleCenter;
                    SkillPanelEntry.SkillRank[i].Text = SkillTotal[i].ToString();
                    SkillPanelEntry.SkillRank[i].Font = new Font("Times New Roman", 9, FontStyle.Bold);
                    SkillPanelEntry.SkillRank[i].Location = new Point(posx + 519, posy);


                    //Create skill Ability Labels
                    SkillPanelEntry.SkillAbility[i] = new Label();
                    controlName = new StringBuilder();
                    controlName.Append(SkillNames[i]);
                    controlName.Append("Ability");
                    SkillPanelEntry.SkillAbility[i].Name = controlName.ToString();
                    SkillPanelEntry.SkillAbility[i].Width = 38;
                    SkillPanelEntry.SkillAbility[i].TextAlign = ContentAlignment.MiddleCenter;
                    SkillPanelEntry.SkillAbility[i].Text = SkillTotal[i].ToString();
                    SkillPanelEntry.SkillAbility[i].Font = new Font("Times New Roman", 9, FontStyle.Bold);
                    SkillPanelEntry.SkillAbility[i].Location = new Point(posx + 557, posy);


                    //Create tomes Labels
                    SkillPanelEntry.SkillTome[i] = new Label();
                    controlName = new StringBuilder();
                    controlName.Append(SkillNames[i]);
                    controlName.Append("Tome");
                    SkillPanelEntry.SkillTome[i].Name = controlName.ToString();
                    SkillPanelEntry.SkillTome[i].Width = 41;
                    SkillPanelEntry.SkillTome[i].TextAlign = ContentAlignment.MiddleCenter;
                    SkillPanelEntry.SkillTome[i].Text = SkillTome[i].ToString();
                    SkillPanelEntry.SkillTome[i].Font = new Font("Times New Roman", 9, FontStyle.Bold);
                    SkillPanelEntry.SkillTome[i].Location = new Point(posx + 600, posy);

                    //Create Feat
                    SkillPanelEntry.SkillFeat[i] = new Label();
                    controlName = new StringBuilder();
                    controlName.Append(SkillNames[i]);
                    controlName.Append("Feat");
                    SkillPanelEntry.SkillFeat[i].Name = controlName.ToString();
                    SkillPanelEntry.SkillFeat[i].Width = 41;
                    SkillPanelEntry.SkillFeat[i].TextAlign = ContentAlignment.MiddleCenter;
                    SkillPanelEntry.SkillFeat[i].Font = new Font("Times New Roman", 9, FontStyle.Bold);
                    SkillPanelEntry.SkillFeat[i].Text = SkillPastLifeTome[i].ToString();
                    SkillPanelEntry.SkillFeat[i].Location = new Point(posx + 643, posy);
                    SkillPanel.Controls.Add(SkillPanelEntry.SkillFeat[i]);

                    //Create skill Total Labels
                    SkillPanelEntry.SkillTotal[i] = new Label();
                    controlName = new StringBuilder();
                    controlName.Append(SkillNames[i]);
                    controlName.Append("Total");
                    SkillPanelEntry.SkillTotal[i].Name = controlName.ToString();
                    SkillPanelEntry.SkillTotal[i].Width = 38;
                    SkillPanelEntry.SkillTotal[i].TextAlign = ContentAlignment.MiddleCenter;
                    SkillPanelEntry.SkillTotal[i].Text = SkillTotal[i].ToString();
                    SkillPanelEntry.SkillTotal[i].Font = new Font("Times New Roman", 9, FontStyle.Bold);
                    SkillPanelEntry.SkillTotal[i].Location = new Point(posx + 686, posy);




                    for (int z = 0; z < NumLevel; ++z)

                    {


                        // Create SkillLabel
                        SkillSubPanelEntry.SkillPoints[i, z] = new LabelWithBorder();
                        controlName = new StringBuilder();
                        controlName.Append("SkillPointsLVL");
                        controlName.Append((z+1).ToString("00"));
                        controlName.Append(SkillNames[i]);
                        SkillSubPanelEntry.SkillPoints[i, z].Name = controlName.ToString();
                        SkillSubPanelEntry.SkillPoints[i, z].Text = "0";
                        SkillSubPanelEntry.SkillPoints[i, z].TextAlign = ContentAlignment.MiddleCenter;
                        SkillSubPanelEntry.SkillPoints[i, z].Location = new Point(posx + ((z) * SkillColWidth+2), posy - 25);
                        SkillSubPanelEntry.SkillPoints[i, z].AutoSize = false;
                        SkillSubPanelEntry.SkillPoints[i, z].Height = 16;
                        SkillSubPanelEntry.SkillPoints[i, z].Width = 29;
                        SkillSubPanelEntry.SkillPoints[i, z].Blank = false;
                        SkillSubPanelEntry.SkillPoints[i, z].Border = false;




                        // Create Skill Up Button
                        SkillSubPanelEntry.SkillButtonUp[i, z] = new RepeatingButtonClass();
                        buttonMargin = SkillSubPanelEntry.SkillButtonUp[i, z].Margin;
                        buttonMargin.Bottom = 0;
                        buttonMargin.Top = 0;
                        buttonMargin.Left = 0;
                        buttonMargin.Right = 0;
                        controlName = new StringBuilder();
                        controlName.Append("SkillUpLVL");
                        controlName.Append((z + 1).ToString("00"));
                        controlName.Append(SkillNames[i]);
                        SkillSubPanelEntry.SkillButtonUp[i, z].Name = controlName.ToString();
                        SkillSubPanelEntry.SkillButtonUp[i, z].Location = new Point(posx + ((z) * SkillColWidth) + 31, posy - 25);
                        SkillSubPanelEntry.SkillButtonUp[i, z].Width = 12;
                        SkillSubPanelEntry.SkillButtonUp[i, z].Height = 8;
                        SkillSubPanelEntry.SkillButtonUp[i, z].Margin = buttonMargin;
                        SkillSubPanelEntry.SkillButtonUp[i, z].FlatAppearance.BorderSize = 0;
                        SkillSubPanelEntry.SkillButtonUp[i, z].FlatStyle = FlatStyle.Flat;
                        SkillSubPanelEntry.SkillButtonUp[i, z].Text = "";
                        SkillSubPanelEntry.SkillButtonUp[i, z].Click += SkillUpDownChanged;
                        SkillSubPanelEntry.SkillButtonUp[i, z].Image = Image.FromFile("Graphics\\Interface\\smallarrowup.png");


                        // Create Skill Down Button
                        SkillSubPanelEntry.SkillButtonDown[i, z] = new RepeatingButtonClass();
                        buttonMargin = SkillSubPanelEntry.SkillButtonDown[i, z].Margin;
                        buttonMargin.Bottom = 0;
                        buttonMargin.Top = 0;
                        buttonMargin.Left = 0;
                        buttonMargin.Right = 0;
                        controlName = new StringBuilder();
                        controlName.Append("SkillDownLVL");
                        controlName.Append((z + 1).ToString("00"));
                        controlName.Append(SkillNames[i]);
                        SkillSubPanelEntry.SkillButtonDown[i, z].Name = controlName.ToString();
                        SkillSubPanelEntry.SkillButtonDown[i, z].Location = new Point(posx + ((z) * SkillColWidth) + 31, posy - 17);
                        SkillSubPanelEntry.SkillButtonDown[i, z].Width = 12;
                        SkillSubPanelEntry.SkillButtonDown[i, z].Height = 8;
                        SkillSubPanelEntry.SkillButtonDown[i, z].FlatAppearance.BorderSize = 0;
                        SkillSubPanelEntry.SkillButtonDown[i, z].FlatStyle = FlatStyle.Flat;
                        SkillSubPanelEntry.SkillButtonDown[i, z].Margin = buttonMargin;
                        SkillSubPanelEntry.SkillButtonDown[i, z].Text = "";
                        SkillSubPanelEntry.SkillButtonDown[i, z].Click += SkillUpDownChanged;
                        SkillSubPanelEntry.SkillButtonDown[i, z].Image = Image.FromFile("Graphics\\Interface\\smallarrowdown.png");


                        


                    }

                    //Create Divider SkillSubPanel
                    SkillSubPanelEntry.Divider[i] = new GroupBox();
                    SkillSubPanelEntry.Divider[i].Text = "";
                    SkillSubPanelEntry.Divider[i].Height = 2;
                    SkillSubPanelEntry.Divider[i].Width = NumSkills*50;
                    SkillSubPanelEntry.Divider[i].Location = new Point(0, posy-3);
                    SkillSubPanelEntry.Divider[i].BringToFront();


                    //Create Divider SkillPanel
                    SkillPanelEntry.Divider[i] = new GroupBox();
                    SkillPanelEntry.Divider[i].Text = "";
                    SkillPanelEntry.Divider[i].Height = 2;
                    SkillPanelEntry.Divider[i].Width = SkillPanel.Width;
                    SkillPanelEntry.Divider[i].Location = new Point(0, posy + 26);
                    SkillPanelEntry.Divider[i].BringToFront();


                    //Create Controls for the Auto Fill Panel
                    //Create Auto Fill Labels Labels
                    
                    SkillAutoPanel.RestictLabel[i] = new Label();
                    controlName = new StringBuilder();
                    controlName.Append(SkillNames[i]);
                    controlName.Append("AutoFill");
                    SkillAutoPanel.RestictLabel[i].Name = controlName.ToString();
                    SkillAutoPanel.RestictLabel[i].Width = 105;
                    SkillAutoPanel.RestictLabel[i].TextAlign = ContentAlignment.MiddleLeft;
                    SkillAutoPanel.RestictLabel[i].Text = SkillNames[i].Replace("_"," ");
                    SkillAutoPanel.RestictLabel[i].Font = new Font("Times New Roman", 9, FontStyle.Bold);
                    SkillAutoPanel.RestictLabel[i].Location = new Point(posx-10, posy);


                    //Create UpDown Auto fill Priority
                    SkillAutoPanel.SkillPriority[i] = new NumericUpDownWithBlank();
                    controlName = new StringBuilder();
                    controlName.Append(SkillNames[i]);
                    controlName.Append("Priority");                    
                    SkillAutoPanel.SkillPriority[i].Name = controlName.ToString();
                    SkillAutoPanel.SkillPriority[i].Location = new Point(posx+105, posy);
                    SkillAutoPanel.SkillPriority[i].Width = 40;
                    SkillAutoPanel.SkillPriority[i].Blank = true;
                    SkillAutoPanel.SkillPriority[i].Minimum = 1;
                    SkillAutoPanel.SkillPriority[i].Maximum = NumSkills;
                    SkillAutoPanel.SkillPriority[i].ValueChanged += PriorityChanged;

                    //Create UpDown Max Value
                    SkillAutoPanel.SkillSet[i] = new NumericUpDownWithBlank();
                    controlName = new StringBuilder();
                    controlName.Append(SkillNames[i]);
                    controlName.Append("SetTo");                    
                    SkillAutoPanel.SkillSet[i].Name = controlName.ToString();
                    SkillAutoPanel.SkillSet[i].Location = new Point(posx + 160, posy);
                    SkillAutoPanel.SkillSet[i].Width = 40;
                    SkillAutoPanel.SkillSet[i].Blank = true;
                    SkillAutoPanel.SkillSet[i].Minimum = 1;
                    SkillAutoPanel.SkillSet[i].Maximum = 23;
                    SkillAutoPanel.SkillSet[i].ValueChanged += SetToChanged;


                    



                    posy += 29;
                

            }

            //Place all controls
                for (int z = 0; z < NumLevel; ++z)
                {
                    SkillSubPanel.Controls.Add(SkillSubPanelEntry.SkillRemaining[z]);
                    SkillSubPanel.Controls.Add(SkillSubPanelEntry.Level[z]);

                    

                }
                for (int i = 0; i < NumSkills; ++i)
                    {
                        SkillPanel.Controls.Add(SkillPanelEntry.SkillLabel[i]);
                        SkillPanel.Controls.Add(SkillPanelEntry.SkillRank[i]);
                        SkillPanel.Controls.Add(SkillPanelEntry.SkillAbility[i]);
                        SkillPanel.Controls.Add(SkillPanelEntry.SkillTome[i]);
                        SkillPanel.Controls.Add(SkillPanelEntry.SkillTotal[i]);
                        SkillSubPanel.Controls.Add(SkillSubPanelEntry.Divider[i]);
                        SkillPanel.Controls.Add(SkillPanelEntry.Divider[i]);
                        AutoSetPanel.Controls.Add(SkillAutoPanel.RestictLabel[i]);
                        AutoSetPanel.Controls.Add(SkillAutoPanel.SkillPriority[i]);
                        AutoSetPanel.Controls.Add(SkillAutoPanel.SkillSet[i]);
                        for (int z = 0; z < NumLevel; ++z)
                        {
                            SkillSubPanel.Controls.Add(SkillSubPanelEntry.SkillPoints[i, z]);
                            SkillSubPanel.Controls.Add(SkillSubPanelEntry.SkillButtonUp[i, z]);
                            SkillSubPanel.Controls.Add(SkillSubPanelEntry.SkillButtonDown[i, z]);
                        }

                    }
                SkillSubPanel.HorizontalScroll.SmallChange = SkillColWidth * 3;

                ApplySkin();
  
                UpdateScreen();


                //listen for change notification messages
                UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.SkillEditScreen, ScreenMessengerClass.ChangeList.ClassChange, handleClassChange);
                UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.SkillEditScreen, ScreenMessengerClass.ChangeList.AbilityChange, handleAbilityChange);
                UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.SkillEditScreen, ScreenMessengerClass.ChangeList.PastLifeChange, handlePastlifeChange);
                UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.SkillEditScreen, ScreenMessengerClass.ChangeList.SkillChange, handleSkillChange);
                
        }


        #endregion



        #region Form Events
        private void SkillUpDownChanged(object sender, EventArgs e)
        {
            RepeatingButtonClass control;
            string controlName;
            int CurrentLevel;
            control = (RepeatingButtonClass)sender;
            controlName = control.Name;
            string SkillName;
            CharacterSkillClass.Skills Skill;
            bool update;
            bool up;
            SkillName = controlName.Substring(controlName.IndexOf("LVL") + 5, controlName.Length-(controlName.IndexOf("LVL")+5));
            Skill = (CharacterSkillClass.Skills)Enum.Parse(typeof(CharacterSkillClass.Skills), SkillName, true);
            if(controlName.StartsWith("SkillUp"))
            {
                up   =   true;
            }
            else
            {
                up = false;
            }

            CurrentLevel = Convert.ToInt16(controlName.Substring(controlName.IndexOf("LVL") + 3, 2));

            update = CharacterManagerClass.CharacterManager.CharacterSkill.AdjustRankRaise(Skill, CurrentLevel, up);
            if(update)
                updateSkills(CurrentLevel,(int)Skill);
        }

        private void selectedLevelChanged(object sender, EventArgs e)
        {
            updateSummary();
        }

        private void SetToChanged(object sender, EventArgs e)
        {
            NumericUpDownWithBlank control;
            control= new NumericUpDownWithBlank();
            control = (NumericUpDownWithBlank)sender;
            string SkillName;
            SkillName = control.Name.ToString().Substring(0, control.Name.Length - ("SetTo").Length);
            int SkillID;
            SkillID = SkillNames.IndexOf(SkillName);
            if (!control.Blank)
            {
                MaxRank[SkillID] = (int)control.Value;
            }
            else
            {
                MaxRank[SkillID] = 0;
            }
                
        }

        private void PriorityChanged(object sender, EventArgs e)
        {
            NumericUpDownWithBlank control;
            control = new NumericUpDownWithBlank();
            control = (NumericUpDownWithBlank)sender;

            List<int> tempList;
            string SkillName;
            SkillName = control.Name.ToString().Substring(0, control.Name.Length - ("Priority").Length);
            int SkillID;
            SkillID = SkillNames.IndexOf(SkillName);
            tempList = new List<int>();
            for (int i = 0; i < NumSkills; ++i)
            {
                tempList = PriorityList[i];
                if(tempList.Contains(SkillID))
                {
                    tempList.Remove(SkillID);
                }
                PriorityList[i] = tempList;
            }
            if (control.Blank)
                return;
            tempList = PriorityList[(int)control.Value-1];
            tempList.Add(SkillID);
            tempList.Sort();
            PriorityList[(int)control.Value-1] = tempList;
            int y = 0;
        }

        private void AutoSetRanks(object sender, EventArgs e)
        {
            List<int> tempList;
            bool skillrankchanged;
            CharacterManagerClass.CharacterManager.CharacterSkill.ResetRanks();
            //Current Priority
            for(int i=0;i<NumSkills;++i)            
            {
                //Current Level filling Class Skills First if Sellected
                if (useclass.Checked)
                {
                    for (int x = 1; x <= 20; ++x)
                    {
                        tempList = PriorityList[i];
                        //Check if Priority has a Skill listed
                        if (tempList.Count > 0)
                        {


                            do
                            {
                                skillrankchanged = false;
                                //Cycle though the skills for each Priority
                                for (int y = 0; y < tempList.Count; ++y)
                                {

                                    //Check for Class only or if Skill has been taken
                                    if (!ClassOnlySkills[tempList[y]] | HasSkillCheck(SkillNames[tempList[y]], x))
                                    {
                                        //Is this a class skill or are we usinging all classes to met goal
                                        if (HasSkillAtLevel(SkillNames[tempList[y]], x) | !useclass.Checked)
                                        {

                                            //Get Current Value
                                            Decimal CurrentSkillRank = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)tempList[y], 20, CharacterSkillClass.ModifierTypes.RankTotal);
                                            //Check if we met our Goal in the MaxRank NumericUpDown
                                            if (CurrentSkillRank < MaxRank[tempList[y]] & CurrentSkillRank <= x+3)
                                            {
                                                skillrankchanged |= CharacterManagerClass.CharacterManager.CharacterSkill.AdjustRankRaise((CharacterSkillClass.Skills)tempList[y], x, true);
                                            }
                                        }
                                    }
                                }

                            } while (skillrankchanged & CharacterManagerClass.CharacterManager.CharacterSkill.GetRemainingRanks(x) > 0);

                        }
                    }
                }
                //Fill none class Skills
                for (int x = 1; x <= 20; ++x)
                {
                    tempList = PriorityList[i];
                    //Check if Priority has a Skill listed
                    if (tempList.Count > 0)
                    {



                        do
                        {
                            skillrankchanged = false;
                            //Cycle throw skill at the Priority Level
                            for (int y = 0; y < tempList.Count; ++y)
                            {
                                //Check for Class only or if Skill has been taken
                                if (!ClassOnlySkills[tempList[y]] | HasSkillCheck(SkillNames[tempList[y]], x))
                                {
                                    //Get Current Value
                                    Decimal CurrentSkillRank = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)tempList[y], 20, CharacterSkillClass.ModifierTypes.RankTotal);
                                    //Check if we met our Goal
                                    if (CurrentSkillRank < MaxRank[tempList[y]] & CurrentSkillRank <= x+3)
                                    {
                                        skillrankchanged |= CharacterManagerClass.CharacterManager.CharacterSkill.AdjustRankRaise((CharacterSkillClass.Skills)tempList[y], x, true);
                                    }
                                }
                            }

                        } while (skillrankchanged & CharacterManagerClass.CharacterManager.CharacterSkill.GetRemainingRanks(x) > 0);

                    }
                }



            }
            updateSkillRanks();
        }

        private void ResetSkills(object sender, EventArgs e)
        {
            CharacterManagerClass.CharacterManager.CharacterSkill.ResetRanks();
            updateSkillRanks();
        }

        private void LoadTomePane(object sender, EventArgs e)
        {

            UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.SkillTomeEditScreen);
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            //stop listening for notifiation messages
            UIManagerClass.UIManager.ScreenMessenger.DeregisterListener(UIManagerClass.ChildScreen.SkillEditScreen);
            UIManagerClass.UIManager.CloseChildScreen(UIManagerClass.ChildScreen.SkillEditScreen);

        }
        #endregion

        #region Private Functions
        private void handleClassChange()
        {
            GetClassInfo();
            for (int i = 1; i <= NumLevel; ++i)
            {

                checkClassOnlySkills(i);

                SetHighlightMarkers(i);

                updateSkills(i);

                updateRemaing(i);
            }
        }
        private void handleAbilityChange()
        {
            CharacterManagerClass.CharacterManager.CharacterSkill.IntChange();
            for (int i = 1; i <= NumLevel; ++i)
            {
                updateRemaing(i);
            }
            updateAbility();
            updateTotal();
        }
        private void handlePastlifeChange()
        {
            CharacterManagerClass.CharacterManager.CharacterSkill.IntChange();
            for (int i = 1; i <= NumLevel; ++i)
            {
                updateRemaing(i);
            }
            updateAbility();
            updateTome();
            updateTotal();
                }
        private void handleSkillChange()
        {
            updateTome();
            updateTotal();
        }



        private void updateSkillRanks()
        {
            for (int i = 1; i <= NumLevel; ++i)
            {
                updateSkills(i);

                updateRemaing(i);

            }
            updateSummary();
        }

        private void UpdateScreen()
        {

            GetClassInfo();
            
            for (int i = 1; i <= NumLevel; ++i)
            {


                checkClassOnlySkills(i);
 
                SetHighlightMarkers(i);

                updateSkills(i);

                updateRemaing(i);

            
            }
            updateSummary();

        }
        private void updateSummary()
        {
            updateRankTotal();
            updateAbility();
            updateTome();
            updateFeat();
            updateTotal();
        }
        private void GetClassInfo()
        {
            ClassesAtLevel=new Guid[20];
            for(int i=0;i<20;++i)
                ClassesAtLevel[i] = CharacterManagerClass.CharacterManager.CharacterClass.GetClass(i+1);
            Classes = new Guid[3] {Guid.Empty, Guid.Empty, Guid.Empty};
            Classes = CharacterManagerClass.CharacterManager.CharacterClass.GetClasses();
            SkillCollection = new List<List<Model.SkillModel>>();
            for(int i=0; i < Classes.Count();++i)
            {
                SkillList = new List<Model.SkillModel>();
                SkillList = Model.SkillModel.GetAllForClass(Classes[i]);
                SkillCollection.Add(SkillList);
            }
        }
        private bool HasSkillCheck(string Skill, int Level)
        {
            bool result = false;
            for(int i = 0;i<Classes.Count();++i)
            {
                for(int y = 0; y<Level;++y)
                {
                    if(Classes[i] == ClassesAtLevel[y])
                    {
                        for(int x=0; x<SkillCollection[i].Count();++x)
                        {
                            if (SkillCollection[i][x].Name == Skill.Replace("_"," "))
                            {
                                result = true;
                                return result;
                            }
                            else
                                result = false;
                        }
                    }
                }
              
            }    
            return result;
        }

        private bool HasSkillAtLevel(string Skill, int level)
        {
            bool result = false;
            Guid CharacterClassAtLevel;
            List<Model.SkillModel> ClassSkills;
            CharacterClassAtLevel = ClassesAtLevel[level - 1];
            ClassSkills = SkillCollection[0];
            for (int i = 0; i < Classes.Count(); ++i)
            {
                if (CharacterClassAtLevel == Classes[i])
                    ClassSkills = SkillCollection[i];
            }

                
                for (int i = 0; i < ClassSkills.Count; ++i)
                {
                    if (Skill.Replace("_"," ") == ClassSkills[i].Name)
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            
            
            
            
            
            
            return result;
        }
        private void checkClassOnlySkills(int level)
        {   
            string skill;
            for (int y = 0; y < NumSkills; ++y)
            {
                skill = SkillNames[y].Replace("_"," ");
                
                if(ClassOnlySkills[y])
                {
                    if (HasSkillCheck(skill,level))
                    {
                        SkillSubPanelEntry.SkillPoints[y, level-1].Blank = false;
                                            }
                    else
                    {
                        SkillSubPanelEntry.SkillPoints[y, level-1].Blank = true;
                    }
                }
            }

        }

        private void updateSkills(int CurrentLevel,int Skill=-1)
        {
            int LevelRef;
            LevelRef = CurrentLevel - 1;
            for(int i=0;i<NumSkills;++i)
            { 
                if(Skill != -1)
                {
                    if(i==Skill)
                        SkillSubPanelEntry.SkillPoints[Skill, LevelRef].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)Skill, CurrentLevel, CharacterSkillClass.ModifierTypes.Rank).ToString();
                    checkpostlvl(Skill, CurrentLevel);
                
                }
                else
                {
                    SkillSubPanelEntry.SkillPoints[i, LevelRef].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, CurrentLevel, CharacterSkillClass.ModifierTypes.Rank).ToString();
                    
                }
                if (SkillSubPanelEntry.SkillPoints[i, LevelRef].Blank)
                //Down arrow disabled and up arrow disabled
                {
                    SkillSubPanelEntry.SkillButtonDown[i, LevelRef].Image = Image.FromFile("Graphics\\Interface\\smallarrowdowndisabled.png");
                    SkillSubPanelEntry.SkillButtonUp[i, LevelRef].Image = Image.FromFile("Graphics\\Interface\\smallarrowupdisabled.png");
                }
                else if(CharacterManagerClass.CharacterManager.CharacterSkill.GetRemainingRanks(CurrentLevel) <= 0)
                //Up arrow disenabled
                {
                    SkillSubPanelEntry.SkillButtonUp[i, LevelRef].Image = Image.FromFile("Graphics\\Interface\\smallarrowupdisabled.png");
                    if (CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, CurrentLevel, CharacterSkillClass.ModifierTypes.Spent) > 0)
                    {
                        SkillSubPanelEntry.SkillButtonDown[i, LevelRef].Image = Image.FromFile("Graphics\\Interface\\smallarrowdown.png");
                    }
                    else
                    {
                        SkillSubPanelEntry.SkillButtonDown[i, LevelRef].Image = Image.FromFile("Graphics\\Interface\\smallarrowdowndisabled.png");
                    }
                }
                else
                {
                    //Check Up arrow enabled
                    if (CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, CurrentLevel, CharacterSkillClass.ModifierTypes.Spent) >= CurrentLevel + 3)
                    {
                        SkillSubPanelEntry.SkillButtonUp[i, LevelRef].Image = Image.FromFile("Graphics\\Interface\\smallarrowupdisabled.png");
                    }
                    else
                    {
                        SkillSubPanelEntry.SkillButtonUp[i, LevelRef].Image = Image.FromFile("Graphics\\Interface\\smallarrowup.png");
                    }
                        //Check Down arrow
                    if (CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, CurrentLevel, CharacterSkillClass.ModifierTypes.Spent) <= 0)
                    {
                        SkillSubPanelEntry.SkillButtonDown[i, LevelRef].Image = Image.FromFile("Graphics\\Interface\\smallarrowdowndisabled.png");
                    }
                    else
                    {
                        SkillSubPanelEntry.SkillButtonDown[i, LevelRef].Image = Image.FromFile("Graphics\\Interface\\smallarrowdown.png");
                    }

                }                   
                

        


            }

            updateRemaing(CurrentLevel);
            updateRankTotal();
            updateTotal();

        }

        private void updateRemaing(int CurrentLevel)
        {
            int Remaining = CharacterManagerClass.CharacterManager.CharacterSkill.GetRemainingRanks(CurrentLevel);
            if(Remaining>=0)
            {
                SkillSubPanelEntry.SkillRemaining[CurrentLevel-1].ForeColor = Color.White;
            }
            else
            {
                SkillSubPanelEntry.SkillRemaining[CurrentLevel-1].ForeColor = Color.Red;
            }
            SkillSubPanelEntry.SkillRemaining[CurrentLevel-1].Text = Remaining.ToString();
        }

        private void checkpostlvl(int Skill, int Level)
        {
            for (int i = Level-1; i < NumLevel; ++i)
            {

                    if (CharacterManagerClass.CharacterManager.CharacterSkill.ValidRanksSpent[Skill,i])
                    {
                        SkillSubPanelEntry.SkillPoints[Skill, i].ForeColor = Color.White;
                    }
                    else
                    {
                        SkillSubPanelEntry.SkillPoints[Skill, i].ForeColor = Color.Red;
                    }

            }



        }


        private void updateRankTotal()
        {
            for(int i=0;i<NumSkills;++i)
            {
                SkillPanelEntry.SkillRank[i].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i,(int)levelSelected.Value, CharacterSkillClass.ModifierTypes.RankTotal).ToString();
            }
        }
        private void updateAbility()
        {
                for(int i=0;i<NumSkills;++i)
                {
                    SkillPanelEntry.SkillAbility[i].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, (int)levelSelected.Value, CharacterSkillClass.ModifierTypes.Ability).ToString();
        
                }
        }
        private void updateTome()
        {
            for(int i=0;i<NumSkills;++i)
            {
                SkillPanelEntry.SkillTome[i].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, (int)levelSelected.Value, CharacterSkillClass.ModifierTypes.Tome).ToString();
            }
        }

        private void updateFeat()
        {
            for(int i=0;i<NumSkills;++i)
            {
                SkillPanelEntry.SkillFeat[i].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, (int)levelSelected.Value, CharacterSkillClass.ModifierTypes.Feat).ToString();
        
            }
        }
        private void updateTotal()
        {
            for (int i = 0; i < NumSkills; ++i)
            {
                SkillPanelEntry.SkillTotal[i].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, (int)levelSelected.Value, CharacterSkillClass.ModifierTypes.SkillSheet).ToString();
            }
        }
        private void SetHighlightMarkers(int level)
        {

            string buttonskill;
            string SkillName;
            for (int y = 0; y < NumSkills; ++y)
            {
                buttonskill = SkillSubPanelEntry.SkillPoints[y, level - 1].Name;
                SkillName = buttonskill.Substring(buttonskill.IndexOf("LVL") + 5, buttonskill.Length - (buttonskill.IndexOf("LVL") + 5));
                SkillSubPanelEntry.SkillPoints[y, level - 1].Border = HasSkillAtLevel(SkillName,level);

                
            }

        }

        #endregion

        #region Public Methods
        public void ApplySkin()
        {
            UIManagerClass uiManager = UIManagerClass.UIManager;
            SkinStyleClass style;
            SkinStyleClass style1;

            //screen background
            style = uiManager.Skin.GetSkinStyle("MainScreenSkillEditScreenBackgroundColor");
            this.BackColor = style.Color1;

            //panel backgrounds
            style = uiManager.Skin.GetSkinStyle("MainScreenSkillEditScreenPanelBackgroundColor");
            SkillPanel.BackColor = style.Color1;
            SkillSubPanel.BackColor = style.Color1;
            AutoSetPanel.BackColor = style.Color1;

            //Headers 
            style = uiManager.Skin.GetSkinStyle("MainScreenSkillEditScreenPanelHeaderColor");
            SkillHeader.BackColor = style.Color1;
            AutoSetHeader.BackColor = style.Color1;
            style = uiManager.Skin.GetSkinStyle("MainScreenSkillEditScreenPanelHeaderLabel");
            SkillPanelLabel.ForeColor = style.Color1;
            SkillPanelLabel.BackColor = style.Color2;
            SkillPanelLabel.Font = style.Font;
            AutoSetLabel.ForeColor = style.Color1;
            AutoSetLabel.BackColor = style.Color2;
            AutoSetLabel.Font = style.Font;


            //Labels
            style = uiManager.Skin.GetSkinStyle("MainScreenSkillEditPanelSummary");
            style1 = uiManager.Skin.GetSkinStyle("MainScreenSkillEditScreenSkillLabelLarge");
            for(int i=0;i<NumSkills;++i)
            {
                SkillPanelEntry.SkillRank[i].ForeColor = style.Color1;
                SkillPanelEntry.SkillRank[i].BackColor = style.Color2;
                SkillPanelEntry.SkillRank[i].Font = style.Font;

                SkillPanelEntry.SkillAbility[i].ForeColor = style.Color1;
                SkillPanelEntry.SkillAbility[i].BackColor = style.Color2;
                SkillPanelEntry.SkillAbility[i].Font = style.Font;

                SkillPanelEntry.SkillLabel[i].ForeColor = style1.Color1;
                SkillPanelEntry.SkillLabel[i].BackColor = style1.Color2;
                SkillPanelEntry.SkillLabel[i].Font = style1.Font;

                SkillPanelEntry.SkillTome[i].ForeColor = style.Color1;
                SkillPanelEntry.SkillTome[i].BackColor = style.Color2;
                SkillPanelEntry.SkillTome[i].Font = style.Font;

                SkillPanelEntry.SkillTotal[i].ForeColor = style.Color1;
                SkillPanelEntry.SkillTotal[i].BackColor = style.Color2;
                SkillPanelEntry.SkillTotal[i].Font = style.Font;

                SkillPanelEntry.SkillFeat[i].ForeColor = style.Color1;
                SkillPanelEntry.SkillFeat[i].BackColor = style.Color2;
                SkillPanelEntry.SkillFeat[i].Font = style.Font;

                SkillAutoPanel.RestictLabel[i].ForeColor = style1.Color1;
                SkillAutoPanel.RestictLabel[i].BackColor = style1.Color2;
                SkillAutoPanel.RestictLabel[i].Font = style1.Font;


            }
            for (int i = 0; i < NumLevel; ++i)
            {
                SkillSubPanelEntry.Level[i].ForeColor = style1.Color1;
                SkillSubPanelEntry.Level[i].BackColor = style1.Color2;
                SkillSubPanelEntry.Level[i].Font = style1.Font;

                SkillSubPanelEntry.SkillRemaining[i].ForeColor = style.Color1;
                SkillSubPanelEntry.SkillRemaining[i].BackColor = style.Color2;
                SkillSubPanelEntry.SkillRemaining[i].Font = style.Font;
            }


            style = uiManager.Skin.GetSkinStyle("MainScreenSkillEditScreenLabel");
            label1.ForeColor = style.Color1;
            label1.BackColor = style.Color2;
            label1.Font = style.Font;
            
            label2.ForeColor = style.Color1;
            label2.BackColor = style.Color2;
            label2.Font = style.Font;
            label3.ForeColor = style.Color1;
            label3.BackColor = style.Color2;
            label4.Font = style.Font;
            label4.ForeColor = style.Color1;
            label4.BackColor = style.Color2;
            label3.Font = style.Font;
            Label5.ForeColor = style.Color1;
            Label5.BackColor = style.Color2;
            Label5.Font = style.Font;
            Label6.ForeColor = style.Color1;
            Label6.BackColor = style.Color2;
            Label6.Font = style.Font;
            label7.ForeColor = style.Color1;
            label7.BackColor = style.Color2;
            label7.Font = style.Font;
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
            useclass.ForeColor = style.Color1;
            useclass.BackColor = style.Color2;
            useclass.Font = style.Font;
            
            
            //headerbuttons
            style = uiManager.Skin.GetSkinStyle("MainScreenSkillEditScreenSkillButton");
            update.BackColor = style.Color2;
            update.Font = style.Font;
            update.ForeColor = style.Color1;
            button2.BackColor = style.Color2;
            button2.Font = style.Font;
            button2.ForeColor = style.Color1;

            //Screen Button
            style = uiManager.Skin.GetSkinStyle("MainScreenSkillEditScreenSkillButtonScreen");
            button1.BackColor = style.Color2;
            button1.Font = style.Font;
            button1.ForeColor = style.Color1;

            style = uiManager.Skin.GetSkinStyle("MainScreenSkillEditScreenLabel");

            for (int i = 0; i < NumSkills; ++i)
            {
                for (int z = 0; z < NumLevel; ++z)
                {
                    SkillSubPanelEntry.SkillPoints[i, z].ForeColor = style.Color1;
                    SkillSubPanelEntry.SkillPoints[i, z].BackColor = style.Color2;
                    SkillSubPanelEntry.SkillPoints[i, z].Font = style.Font;
                }
            }


        }

        public static void RegisterSkinGroups()
        {
            UIManagerClass uiManager = UIManagerClass.UIManager;

            uiManager.Skin.RegisterSkinGroup("MainScreenSkillEditScreenBackgroundColor", SkinSettings.FactoryName.ScreenBackgroundColor);
            uiManager.Skin.RegisterSkinGroup("MainScreenSkillEditScreenPanelBackgroundColor", SkinSettings.FactoryName.PanelBackgroundColor);
            uiManager.Skin.RegisterSkinGroup("MainScreenSkillEditScreenPanelHeaderColor", SkinSettings.FactoryName.PanelHeaderColor);
            uiManager.Skin.RegisterSkinGroup("MainScreenSkillEditScreenLabel", SkinSettings.FactoryName.StandardLabel);
            uiManager.Skin.RegisterSkinGroup("MainScreenSkillEditPanelSummary", SkinSettings.FactoryName.StandardBoldFont);
            uiManager.Skin.RegisterSkinGroup("MainScreenSkillEditScreenPanelHeaderLabel", SkinSettings.FactoryName.PanelHeaderFont);
            uiManager.Skin.RegisterSkinGroup("MainScreenSkillEditScreenSkillLabelLarge", SkinSettings.FactoryName.GoldBoldFont);
            uiManager.Skin.RegisterSkinGroup("MainScreenSkillEditScreenSkillLabelSmall", SkinSettings.FactoryName.TinyFont);
            uiManager.Skin.RegisterSkinGroup("MainScreenSkillEditScreenSkillButton", SkinSettings.FactoryName.PanelHeaderButton);
            uiManager.Skin.RegisterSkinGroup("MainScreenSkillEditScreenSkillButtonScreen", SkinSettings.FactoryName.StandardButton);
        }

        #endregion









    }
}
       
