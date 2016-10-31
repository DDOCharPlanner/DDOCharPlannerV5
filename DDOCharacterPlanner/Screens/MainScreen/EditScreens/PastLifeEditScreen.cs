using DDOCharacterPlanner.Model;
using DDOCharacterPlanner.Model.Tome;
using DDOCharacterPlanner.Screens.Controls;
using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.CharacterData;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Linq;

namespace DDOCharacterPlanner.Screens.MainScreen.EditScreens
	{

	public partial class PastLifeEditScreen : Form
		{
		#region Member Variables
		int ClassTooltipDisplay;
        int IconicTooltipDisplay;
		int NumClasses;
		int NumSkills;
        int NumIconic;
        bool AllowChange = true;
        List<string> SkillNames;
        List<string> ClassNames;
        List<string> IconicNames;
		ClassPanelEntryStruct ClassPanelEntry;
		SkillTomePanelEntryStruct SkillTomePanelEntry;
        IconicPanelEntryStruct IconicPanelEntry;
		#endregion

		#region Structures
		protected struct ClassPanelEntryStruct
			{
			public IconClass[] ClassIcon;
			//public Label[] ClassPastLifeValue;
            public NumericUpDownWithBlank[] ClassPastLifeUpDown;
			}

		protected struct SkillTomePanelEntryStruct
			{
			public Label[] SkillLabel;
			public NumericUpDownWithBlank[] SkillUpDown;
			}

        protected struct IconicPanelEntryStruct
            {
            public IconClass[] IconicIcon;
            public NumericUpDownWithBlank[] IconicPastLifeUpDown;
            }
		#endregion

		#region Constructor
		public PastLifeEditScreen()
			{

			InitializeComponent();
			NumClasses = ClassModel.GetNumClasses();
			NumSkills = SkillModel.GetNumSkills();
            NumIconic = RaceModel.GetNumIconic();
            AllowChange = false;
            int xpos = 4;
            int ypos = 0;
            float iconposx = 4;
            float iconposy = 0;
            int currentrow = 0;
            int PanelHeight = PastLifeClassPanel.Height;
            int PanelWidth = PastLifeClassPanel.Width;
            int maxrow = (int)System.Math.Ceiling((decimal)NumClasses / 4);
            StringBuilder controlName;
			ClassPanelEntry.ClassIcon = new IconClass[NumClasses];
			//ClassPanelEntry.ClassPastLifeValue = new Label[NumClasses];
			ClassPanelEntry.ClassPastLifeUpDown = new NumericUpDownWithBlank[NumClasses];
            ClassNames = ClassModel.GetNames();
            int xposstart = 10;
            
			for (int i = 0; i < NumClasses; i++)
				{
                    
                    //create Icon
                    ClassPanelEntry.ClassIcon[i] = new IconClass("Classes\\" + ClassNames[i]);

                    //create updown data entry
                    controlName = new StringBuilder();
                    controlName.Append("ClassUpDown");
                    controlName.Append(i);
                    

                    ClassPanelEntry.ClassPastLifeUpDown[i] = new NumericUpDownWithBlank();
                    ClassPanelEntry.ClassPastLifeUpDown[i].Name = controlName.ToString();
                    PastLifeClassPanel.Controls.Add(ClassPanelEntry.ClassPastLifeUpDown[i]);
                    ClassPanelEntry.ClassPastLifeUpDown[i].Size = new Size(39, 20);
                    ClassPanelEntry.ClassPastLifeUpDown[i].Blank = true;
                    ClassPanelEntry.ClassPastLifeUpDown[i].ValueChanged += ClassUpDownValueChanged;
                    ClassPanelEntry.ClassPastLifeUpDown[i].Minimum = 1;
                    //TODO: Hardcoded value! Remove into the database
                    ClassPanelEntry.ClassPastLifeUpDown[i].Maximum = 3;
                    
                    //create position start point
                    currentrow = (int)i / 4;
                    xpos = (i - (currentrow * 4)) * 100+xposstart;
                    iconposx = ((float)xpos / (float)PanelWidth);
                    ypos = 30 + ((PastLifeClassPanel.Height - 30) / maxrow) * currentrow;
                    iconposy = ((float)ypos / (float)PanelHeight);
                // Place Icon and control
                    ClassPanelEntry.ClassIcon[i].SetLocation(PastLifeClassPanel.Width, PastLifeClassPanel.Height, new PointF(iconposx, iconposy));
                    ClassPanelEntry.ClassPastLifeUpDown[i].Location = new Point(xpos + 40, ypos+5);
    
				}
            //populate the Iconic past life panel
            xpos = 4;
            ypos = 0;
            iconposx = 0;
            iconposy = 0;
            currentrow = 0;
            PanelHeight = PastLifeIconicPanel.Height;
            PanelWidth = PastLifeIconicPanel.Width;
            maxrow = (int)System.Math.Ceiling((decimal)NumIconic / 4);
            IconicPanelEntry.IconicIcon = new IconClass[NumIconic];
            IconicPanelEntry.IconicPastLifeUpDown = new NumericUpDownWithBlank[NumIconic];
            IconicNames = RaceModel.GetIconicNames();
            for (int i = 0; i < NumIconic; i++)
            {

                //create Icon
                IconicPanelEntry.IconicIcon[i] = new IconClass("Races\\" + IconicNames[i]+ " Icon");

                //create updown data entry
                controlName = new StringBuilder();
                controlName.Append("IconicUpDown");
                controlName.Append(i);

                IconicPanelEntry.IconicPastLifeUpDown[i] = new NumericUpDownWithBlank();
                IconicPanelEntry.IconicPastLifeUpDown[i].Name = controlName.ToString();
                PastLifeIconicPanel.Controls.Add(IconicPanelEntry.IconicPastLifeUpDown[i]);
                IconicPanelEntry.IconicPastLifeUpDown[i].Size = new Size(39, 20);
                IconicPanelEntry.IconicPastLifeUpDown[i].Blank = true;
                IconicPanelEntry.IconicPastLifeUpDown[i].ValueChanged += IconiocUpDownValueChanged;
                IconicPanelEntry.IconicPastLifeUpDown[i].Minimum = 1;
                //TODO: Hardcoded value! Remove into the database
                IconicPanelEntry.IconicPastLifeUpDown[i].Maximum = 3;

                //create position start point
                currentrow = (int)i / 4;
                xpos = (i - (currentrow * 4)) * 100+xposstart;
                iconposx = ((float)xpos / (float)PanelWidth);
                ypos = 30 + ((PastLifeClassPanel.Height - 30) / maxrow) * currentrow;
                iconposy = ((float)ypos / (float)PanelHeight);
                // Place Icon and control
                IconicPanelEntry.IconicIcon[i].SetLocation(PastLifeIconicPanel.Width, PastLifeIconicPanel.Height, new PointF(iconposx, iconposy));
                IconicPanelEntry.IconicPastLifeUpDown[i].Location = new Point(xpos + 40, ypos+10);

            }

			//populate the skills panel
            SkillNames = Enum.GetNames(typeof(CharacterSkillClass.Skills)).ToList();
			SkillTomePanelEntry.SkillLabel = new Label[NumSkills];
			SkillTomePanelEntry.SkillUpDown = new NumericUpDownWithBlank[NumSkills];
            xpos = 20;
            ypos = 0;
            Control[] control;
            NumericUpDownWithBlank upDown;
            int rowsplit = (int)System.Math.Ceiling((decimal)NumSkills/2);
			for (int i=0; i<NumSkills; i++)
				{
                    ypos = 30 * i;
                    if (i >= rowsplit)
                        ypos -= 30 * rowsplit;
				SkillTomePanelEntry.SkillLabel[i] = new Label();
				SkillTomeSubPanel.Controls.Add(SkillTomePanelEntry.SkillLabel[i]);
				SkillTomePanelEntry.SkillLabel[i].Text = SkillNames[i].Replace("_"," ");
				SkillTomePanelEntry.SkillLabel[i].Location = new Point(xpos, ypos+3);
				SkillTomePanelEntry.SkillLabel[i].AutoSize = true;
				SkillTomePanelEntry.SkillLabel[i].ForeColor = System.Drawing.Color.Gold;
                SkillTomePanelEntry.SkillLabel[i].Font = new Font("Times New Roman", 9, FontStyle.Bold);
               	SkillTomePanelEntry.SkillLabel[i].Name = "SkillLabel" + i;
                SkillTomePanelEntry.SkillUpDown[i] = new NumericUpDownWithBlank();
				SkillTomeSubPanel.Controls.Add(SkillTomePanelEntry.SkillUpDown[i]);
				SkillTomePanelEntry.SkillUpDown[i].Location = new Point(xpos+120, ypos);
                SkillTomePanelEntry.SkillUpDown[i].Name = "SkillUpDown" + SkillNames[i];
				SkillTomePanelEntry.SkillUpDown[i].Size = new Size(39, 20);
				SkillTomePanelEntry.SkillUpDown[i].Blank = true;
                SkillTomePanelEntry.SkillUpDown[i].Minimum = 1;
                SkillTomePanelEntry.SkillUpDown[i].ValueChanged += SkillUpDownValueChanged;
				
				System.Guid SkillID = SkillModel.GetIdFromName(SkillNames[i].Replace("_"," "));
                int UpDownMax = TomeModel.GetMaxBonus(SkillID);
                SkillTomePanelEntry.SkillUpDown[i].Maximum = UpDownMax;
                if (i >= rowsplit-1)
                    xpos = 200;
				}
            AllowChange = true;
            for (int i = 0; i < NumSkills;++i )
            {
                SetSkillUpDown(SkillTomePanelEntry.SkillUpDown[i]);
            }
                SetAbilityUpDown(StrUpDown);
            SetAbilityUpDown(DexUpDown);
            SetAbilityUpDown(ConUpDown);
            SetAbilityUpDown(IntUpDown);
            SetAbilityUpDown(WisUpDown);
            SetAbilityUpDown(ChaUpDown);
            for(int i=0;i<NumClasses;++i)
            {
                controlName = new StringBuilder();
                controlName.Append("ClassUpDown");
                controlName.Append(i);
                control = Controls.Find(controlName.ToString(), true);
                upDown = (NumericUpDownWithBlank)control[0];
                if (upDown == null)
                    continue;
                SetClassUpDown(upDown);


            }
            for (int i = 0; i < NumIconic; ++i)
            {
                controlName = new StringBuilder();
                controlName.Append("IconicUpDown");
                controlName.Append(i);
                control = Controls.Find(controlName.ToString(), true);
                upDown = (NumericUpDownWithBlank)control[0];
                if (upDown == null)
                    continue;
                SetIconicUpDown(upDown);


            }

            ClassTooltipDisplay = -1;
            IconicTooltipDisplay = -1;
            
			}
        public void SetClassUpDown(NumericUpDownWithBlank control)
        {
            string controlName;
            int controlNum;

            if (AllowChange == true)
            {
                controlName = control.Name;
                //determine the Control changed
                controlNum = Convert.ToInt16(controlName.Substring((int)"ClassUpDown".Length, (int)controlName.Length - (int)"ClassUpDown".Length));
                //Send to PastLifeHeroic
                if (CharacterManagerClass.CharacterManager.CharacterPastLife.PastLifeHerioc[controlNum] != 0)
                {
                    control.Blank = false;
                    control.Value = CharacterManagerClass.CharacterManager.CharacterPastLife.PastLifeHerioc[controlNum];
                }
                else
                {
                    control.Blank = true;
                }
                    
            }
        }
        public void SetIconicUpDown(NumericUpDownWithBlank control)
        {
            string controlName;
            int controlNum;

            if (AllowChange == true)
            {
                controlName = control.Name;
                //determine the Control changed
                
                controlNum = Convert.ToInt16(controlName.Substring((int)"IconicUpDown".Length, (int)controlName.Length - (int)"IconicUpDown".Length));
                //Send to PastLifeHeroic
                if (CharacterManagerClass.CharacterManager.CharacterPastLife.PastLifeIconic[controlNum] != 0)
                {
                    control.Blank = false;
                    control.Value = CharacterManagerClass.CharacterManager.CharacterPastLife.PastLifeIconic[controlNum];
                }
                else
                {
                    control.Blank = true;
                }
                    
            }

        }
        public void SetAbilityUpDown(NumericUpDownWithBlank control)
        {
			string controlName;
			CharacterAbilityClass.Abilities ability;

            if (AllowChange == true)
            {
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

                int MaxAbility = TomeModel.GetMaxBonus(AbilityModel.GetIdFromName(ability.ToString()));
                control.Maximum = MaxAbility;

                int maxValue;
                int CurrentValue;
                int CurrentBonus;
                CurrentValue = 0;
                maxValue = 0;
                CurrentBonus = 0;
                for (int i = 0; i < MaxAbility; ++i)
                {
                    CurrentValue = CharacterManagerClass.CharacterManager.CharacterAbility.PriorLifeTome[(int)ability, i];
                    if (CurrentValue > maxValue)
                    {
                        maxValue = CurrentValue;

                        CurrentBonus = i + 1;
                    }
                }
                if (maxValue != 0)
                {
                    control.Blank = false;
                    control.Value = CurrentBonus;
                }
                else
                {
                    control.Blank = true;
                }
            }

        }

        public void SetSkillUpDown(NumericUpDownWithBlank control)
        {
            string controlName;
            List<string> SkillNames;
            CharacterSkillClass.Skills Skill;
            SkillNames = Enum.GetNames(typeof(CharacterSkillClass.Skills)).ToList();

            if (AllowChange == true)
            {
                bool SkillFound = false;
                controlName = control.Name;
                //determine the ability changed
                Skill = CharacterSkillClass.Skills.Balance;
                for(int i=0;i<SkillNames.Count;++i)
                {
                    if(controlName.Contains(SkillNames[i]))
                    {
                        Skill = (CharacterSkillClass.Skills)i;
                        SkillFound = true;
                        if(SkillFound)
                        {
                            break;
                        }
                    }
                }
                if(!SkillFound)
                {
                    return;
                }

                int MaxSkill = TomeModel.GetMaxBonus(SkillModel.GetIdFromName(Skill.ToString().Replace("_"," ")));
                control.Maximum = MaxSkill;

                int maxValue;
                int CurrentValue;
                int CurrentBonus;
                CurrentValue = 0;
                maxValue = 0;
                CurrentBonus = 0;
                for (int i = 0; i < MaxSkill; ++i)
                {
                    CurrentValue = CharacterManagerClass.CharacterManager.CharacterSkill.PriorLifeTome[(int)Skill, i];
                    if (CurrentValue > maxValue)
                    {
                        maxValue = CurrentValue;

                        CurrentBonus = i + 1;
                    }
                }
                if (maxValue != 0)
                {
                    control.Blank = false;
                    control.Value = CurrentBonus;
                }
                else
                {
                    control.Blank = true;
                }
            }
        }


		#endregion

		#region Form Events
		private void OnPastLifeEditScreenFormClosing(object sender, FormClosingEventArgs e)
			{
			UIManagerClass.UIManager.CloseChildScreen(UIManagerClass.ChildScreen.PastLifeEditScreen);
			}

		private void OnPastLifeClassPanelPaint(object sender, PaintEventArgs paintEventArgs)
			{
			DrawClassIcon(paintEventArgs);
			}
        private void OnPastLifeIconicPanelPaint(object sender, PaintEventArgs paintEventArgs)
        {
            DrawIconicIcon(paintEventArgs);
        }

		private void OnPastLifeClassPanelMouseMove(object sender, MouseEventArgs e)
			{
			Point clientPoint = PastLifeClassPanel.PointToClient(System.Windows.Forms.Cursor.Position);
			int x = clientPoint.X;
			int y = clientPoint.Y;

			//debugging
			//Debug.WriteLine("X, Y: " + x + "," + y);
            for (int i=0; i<NumClasses; i++)
                {

                    if (ClassPanelEntry.ClassIcon[i].IsOver(x, y) == true)
                    {

                        if (ClassTooltipDisplay != i)
                        {   
                            PastLifeEditScreenToolTip.Hide(PastLifeClassPanel);
                            if(ClassNames[i] !="")
                                PastLifeEditScreenToolTip.Show(ClassNames[i], PastLifeClassPanel, 3000);
                            ClassTooltipDisplay = i;   
                        } 
                    }
                }
			}
        private void OnPastLifeIconicPanelMouseMove(object sender, MouseEventArgs e)
        {
            Point clientPoint = PastLifeIconicPanel.PointToClient(System.Windows.Forms.Cursor.Position);
            int x = clientPoint.X;
            int y = clientPoint.Y;

            //debugging
            //Debug.WriteLine("X, Y: " + x + "," + y);
            for (int i = 0; i < NumIconic; i++)
            {

                if (IconicPanelEntry.IconicIcon[i].IsOver(x, y) == true)
                {

                    if (IconicTooltipDisplay != i)
                    {
                        PastLifeEditScreenToolTip.Hide(PastLifeIconicPanel);
                        if (IconicNames[i] != "")
                            PastLifeEditScreenToolTip.Show(IconicNames[i], PastLifeIconicPanel, 3000);
                        IconicTooltipDisplay = i;
                    }
                }
            }
        }
        private void TomeUpDownValueChanged(object sender, EventArgs e)
        {
            NumericUpDownWithBlank control;
            string controlName;
            CharacterAbilityClass.Abilities ability;
            int tomeBonus;
            int minLevel=0;

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
                tomeBonus = (int)control.Value;
                Guid AbilityID = AbilityModel.GetIdFromName(ability.ToString());
                int AbilityMax = TomeModel.GetMaxBonus(AbilityID);
                if (tomeBonus != 0)

                    minLevel = TomeModel.GetMinLevel(AbilityID, tomeBonus); 
                if (control.Blank == true)
                    
                    CharacterManagerClass.CharacterManager.CharacterAbility.SetPriorLifeTomeBonus(ability, tomeBonus, 0);
                else
                    CharacterManagerClass.CharacterManager.CharacterAbility.SetPriorLifeTomeBonus(ability, tomeBonus, minLevel);
                for (int i = tomeBonus+1; i < AbilityMax+1; ++i)
                {
                    CharacterManagerClass.CharacterManager.CharacterAbility.SetPriorLifeTomeBonus(ability, i, 0);
                }
                    //inform other screens
                    UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.PastLifeEditScreen, ScreenMessengerClass.ChangeList.AbilityChange);
            }

        }
        private void SkillUpDownValueChanged(object sender, EventArgs e)
        {
            NumericUpDownWithBlank control;
            string controlName;
            List<string> SkillNames;
            CharacterSkillClass.Skills Skill;
            SkillNames = Enum.GetNames(typeof(CharacterSkillClass.Skills)).ToList();
            control = (NumericUpDownWithBlank)sender;
            int tomeBonus;
            int minLevel = 0;
            if (AllowChange == true)
            {
                bool SkillFound = false;
                controlName = control.Name;
                //determine the ability changed
                Skill = CharacterSkillClass.Skills.Balance;
                for (int i = 0; i < SkillNames.Count; ++i)
                {
                    if (controlName.Contains(SkillNames[i]))
                    {
                        Skill = (CharacterSkillClass.Skills)i;
                        SkillFound = true;
                        if (SkillFound)
                        {
                            break;
                        }
                    }
                }
                if (!SkillFound)
                {
                    return;
                }
                //determine the level of the tome
                tomeBonus = (int)control.Value;
                Guid SkillID = SkillModel.GetIdFromName(Skill.ToString().Replace("_"," "));
                int SkillMax = TomeModel.GetMaxBonus(SkillID);
                if (tomeBonus != 0)

                    minLevel = TomeModel.GetMinLevel(SkillID, tomeBonus);
                if (control.Blank == true)

                    CharacterManagerClass.CharacterManager.CharacterSkill.SetPriorLifeTomeBonus(Skill, tomeBonus, 0);
                else
                    CharacterManagerClass.CharacterManager.CharacterSkill.SetPriorLifeTomeBonus(Skill, tomeBonus, minLevel);
                for (int i = tomeBonus + 1; i < SkillMax + 1; ++i)
                {
                    CharacterManagerClass.CharacterManager.CharacterSkill.SetPriorLifeTomeBonus(Skill, i, 0);
                }
                //inform other screens
                UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.PastLifeEditScreen, ScreenMessengerClass.ChangeList.SkillChange);


            }
        }
        private void ClassUpDownValueChanged(object sender, EventArgs e)
        {
            NumericUpDownWithBlank control;
            string controlName;
            int controlNum;

            if (AllowChange == true)
            {
                control = (NumericUpDownWithBlank)sender;
                controlName = control.Name;
                //determine the Control changed
                controlNum = Convert.ToInt16(controlName.Substring((int)"ClassUpDown".Length, (int)controlName.Length - (int)"ClassUpDown".Length));
                //Send to PastLifeHeroic
                if (control.Blank != true)
                {
                    CharacterManagerClass.CharacterManager.CharacterPastLife.PastLifeHerioc[controlNum] = (int)control.Value;
                }
                else
                {
                    CharacterManagerClass.CharacterManager.CharacterPastLife.PastLifeHerioc[controlNum] = 0;
                }
                
                int mycount = CharacterManagerClass.CharacterManager.CharacterPastLife.getNumPastLifes();

                if(mycount > 1)
                {
                    CharacterManagerClass.CharacterManager.CharacterAbility.SetBuildType(CharacterAbilityClass.BuildPointType.ThirdLife, true);
                    CharacterManagerClass.CharacterManager.CharacterAbility.SetBuildType(CharacterAbilityClass.BuildPointType.SecondLife, false);
                }
                else if(mycount >0)
                {
                    CharacterManagerClass.CharacterManager.CharacterAbility.SetBuildType(CharacterAbilityClass.BuildPointType.ThirdLife, false);
                    CharacterManagerClass.CharacterManager.CharacterAbility.SetBuildType(CharacterAbilityClass.BuildPointType.SecondLife, true);
                }
                else
                {
                    CharacterManagerClass.CharacterManager.CharacterAbility.SetBuildType(CharacterAbilityClass.BuildPointType.ThirdLife, false);
                    CharacterManagerClass.CharacterManager.CharacterAbility.SetBuildType(CharacterAbilityClass.BuildPointType.SecondLife, false);
                }
                //inform other screens
                UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.PastLifeEditScreen, ScreenMessengerClass.ChangeList.PastLifeChange);
            }

        }
        private void IconiocUpDownValueChanged(object sender, EventArgs e)
        {
            NumericUpDownWithBlank control;
            string controlName;
            int controlNum;

            if (AllowChange == true)
            {
                control = (NumericUpDownWithBlank)sender;
                controlName = control.Name;
                //determine the Control changed
                controlNum = Convert.ToInt16(controlName.Substring((int)"IconicUpDown".Length, (int)controlName.Length - (int)"IconicUpDown".Length));
                //Send to PastLifeHeroic
                CharacterManagerClass.CharacterManager.CharacterPastLife.PastLifeIconic[controlNum] = (int)control.Value;
                //inform other screens
                UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.PastLifeEditScreen, ScreenMessengerClass.ChangeList.PastLifeChange);
           }

        }
		private void OnPastLifeClassPanelMouseLeave(object sender, System.EventArgs e)
			{
			ClassTooltipDisplay = -1;
			}

        private void OnPastLifeIconicPanelMouseLeave(object sender, System.EventArgs e)
        {
            IconicTooltipDisplay = -1;
        }

		private void OnPastLifeEditScreenToolTipDraw(object sender, DrawToolTipEventArgs e)
			{
		    e.DrawBackground();
			e.DrawBorder();
			e.DrawText();
			}
		#endregion

		#region Private Functions
		/// <summary>
		/// Draw the class icon
		/// </summary>
		/// <param name="paintEventArgs"></param>
		private void DrawClassIcon(PaintEventArgs paintEventArgs)
			{
			for (int i = 0; i < NumClasses; i++)
				ClassPanelEntry.ClassIcon[i].Draw(paintEventArgs);
            }
        private void DrawIconicIcon(PaintEventArgs paintEventArgs)
            {
                for (int i = 0; i < NumIconic; i++)
                    IconicPanelEntry.IconicIcon[i].Draw(paintEventArgs);
            }
		

        private void SkillTomeSubPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GrantedFeatSubPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AbilityTomePanel_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
		}
	}
