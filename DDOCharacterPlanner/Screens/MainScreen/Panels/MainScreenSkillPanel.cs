using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using DDOCharacterPlanner.Screens.MainScreen.EditScreens;
using DDOCharacterPlanner.CharacterData;


namespace DDOCharacterPlanner.Screens.MainScreen
	{
	public partial class MainScreenSkillPanel : UserControl
		{
		#region Constants
		private const int ScrollHeight = 224;
		private const int ScrollTotalMove = 100;
		private const int LargeScrollMove = 10;

		#endregion

		#region Member Variables
		ScrollBar SkillsSubPanelScrollBar;
        private List<string> SkillNames = Enum.GetNames(typeof(CharacterSkillClass.Skills)).ToList();
		private int NumSkills;
        private List<Label> SkillNameLabel;
		private List<Label> SkillTotalLabel;
        private List<Label> SkillRankLabel;
        private List<Label> SkillAbilityLabel;
        private List<Label> SkillTomeLabel;
        private List<Label> SkillFeatLabel;
        private List<Label> SkillEnhLabel;
        private List<Label> SkillDestLabel;
        private List<Label> SkillGearLabel;

		private List<int> SkillRowStartY;
		#endregion

		#region Constructors
		public MainScreenSkillPanel()
			{
			InitializeComponent();
            NumSkills = SkillNames.Count();
			}
		#endregion

		#region Protected Functions
		protected override void OnLoad(EventArgs eventArgs)
			{
			//we need a vetical scroll bar
			SkillsSubPanelScrollBar = new VScrollBar();
			SkillsSubPanelScrollBar.Dock = DockStyle.Right;
			SkillsSubPanelScrollBar.Minimum = 0;
			SkillsSubPanelScrollBar.Maximum = ScrollHeight;
			SkillsSubPanelScrollBar.SmallChange = 1;
			SkillsSubPanelScrollBar.LargeChange = LargeScrollMove;
			SkillsSubPanelScrollBar.Scroll += new ScrollEventHandler(SkillsSubPanelScrollBarOnScroll);
			SkillSubPanel.Controls.Add(SkillsSubPanelScrollBar);

			//handle the mouse wheel event
			MouseWheel += new MouseEventHandler(SkillSubPanelMouseWheel);

			//create skill name labels
			SkillNameLabel = new List<Label>();
            SkillRankLabel = new List<Label>();
            SkillAbilityLabel = new List<Label>();
            SkillTomeLabel = new List<Label>();
            SkillFeatLabel = new List<Label>();
            SkillEnhLabel = new List<Label>();
            SkillDestLabel = new List<Label>();
            SkillGearLabel = new List<Label>();
			for (int i = 0; i < NumSkills; i++)
            {

                SkillNameLabel.Add(new Label());
				SkillSubPanel.Controls.Add(SkillNameLabel[i]); 
				SkillNameLabel[i].Location = new Point(-3, i * 23);
				SkillNameLabel[i].Padding = new Padding(5);
				SkillNameLabel[i].AutoSize = true;
				SkillNameLabel[i].BackColor = Color.Black;
				SkillNameLabel[i].ForeColor = Color.White;
				SkillNameLabel[i].Name = "SkillNameLabel[" + i + "]";
				SkillNameLabel[i].Size = new Size(42, 23);
				SkillNameLabel[i].Text = SkillNames[i].Replace("_"," ");
            //create rank labels
                SkillRankLabel.Add(new Label());
                SkillSubPanel.Controls.Add(SkillRankLabel[i]);
                SkillRankLabel[i].Location = new Point(105, i * 23);
                SkillRankLabel[i].Padding = new Padding(5);
                SkillRankLabel[i].AutoSize = true;
                SkillRankLabel[i].BackColor = Color.Black;
                SkillRankLabel[i].ForeColor = Color.White;
                SkillRankLabel[i].Name = "SkillRankLabel[" + i + "]";
                SkillRankLabel[i].Size = new Size(42, 23);
                SkillRankLabel[i].Text = "0";
            //create ability labels
                SkillAbilityLabel.Add(new Label());
                SkillSubPanel.Controls.Add(SkillAbilityLabel[i]);
                SkillAbilityLabel[i].Location = new Point(140, i * 23);
                SkillAbilityLabel[i].Padding = new Padding(5);
                SkillAbilityLabel[i].AutoSize = true;
                SkillAbilityLabel[i].BackColor = Color.Black;
                SkillAbilityLabel[i].ForeColor = Color.White;
                SkillAbilityLabel[i].Name = "SkillAbilityLabel[" + i + "]";
                SkillAbilityLabel[i].Size = new Size(42, 23);
                SkillAbilityLabel[i].Text = "0";

                //create tome labels
                SkillTomeLabel.Add(new Label());
                SkillSubPanel.Controls.Add(SkillTomeLabel[i]);
                SkillTomeLabel[i].Location = new Point(180, i * 23);
                SkillTomeLabel[i].Padding = new Padding(5);
                SkillTomeLabel[i].AutoSize = true;
                SkillTomeLabel[i].BackColor = Color.Black;
                SkillTomeLabel[i].ForeColor = Color.White;
                SkillTomeLabel[i].Name = "SkillTomeLabel[" + i + "]";
                SkillTomeLabel[i].Size = new Size(42, 23);
                SkillTomeLabel[i].Text = "0";

                // create feat labels
                SkillFeatLabel.Add(new Label());
                SkillSubPanel.Controls.Add(SkillFeatLabel[i]);
                SkillFeatLabel[i].Location = new Point(215, i * 23);
                SkillFeatLabel[i].Padding = new Padding(5);
                SkillFeatLabel[i].AutoSize = true;
                SkillFeatLabel[i].BackColor = Color.Black;
                SkillFeatLabel[i].ForeColor = Color.White;
                SkillFeatLabel[i].Name = "SkillFeatLabel[" + i + "]";
                SkillFeatLabel[i].Size = new Size(42, 23);
                SkillFeatLabel[i].Text = "0";

                // create Enh labels
                SkillEnhLabel.Add(new Label());
                SkillSubPanel.Controls.Add(SkillEnhLabel[i]);
                SkillEnhLabel[i].Location = new Point(255, i * 23);
                SkillEnhLabel[i].Padding = new Padding(5);
                SkillEnhLabel[i].AutoSize = true;
                SkillEnhLabel[i].BackColor = Color.Black;
                SkillEnhLabel[i].ForeColor = Color.White;
                SkillEnhLabel[i].Name = "SkillEnhLabel[" + i + "]";
                SkillEnhLabel[i].Size = new Size(42, 23);
                SkillEnhLabel[i].Text = "0";

            //create Dest labels
                SkillDestLabel.Add(new Label());
                SkillSubPanel.Controls.Add(SkillDestLabel[i]);
                SkillDestLabel[i].Location = new Point(290, i * 23);
                SkillDestLabel[i].Padding = new Padding(5);
                SkillDestLabel[i].AutoSize = true;
                SkillDestLabel[i].BackColor = Color.Black;
                SkillDestLabel[i].ForeColor = Color.White;
                SkillDestLabel[i].Name = "SkillDestLabel[" + i + "]";
                SkillDestLabel[i].Size = new Size(42, 23);
                SkillDestLabel[i].Text = "0";
            //create Gear labels
                SkillGearLabel.Add(new Label());
                SkillSubPanel.Controls.Add(SkillGearLabel[i]);
                SkillGearLabel[i].Location = new Point(325, i * 23);
                SkillGearLabel[i].Padding = new Padding(5);
                SkillGearLabel[i].AutoSize = true;
                SkillGearLabel[i].BackColor = Color.Black;
                SkillGearLabel[i].ForeColor = Color.White;
                SkillGearLabel[i].Name = "SkillGearLabel[" + i + "]";
                SkillGearLabel[i].Size = new Size(42, 23);
                SkillGearLabel[i].Text = "0";
            }

                







            //create skill total labels
            SkillTotalLabel = new List<Label>();
            for (int i = 0; i < NumSkills; i++)
            {
                SkillTotalLabel.Add(new Label());
                TotalHighlightPanel.Controls.Add(SkillTotalLabel[i]);
                SkillTotalLabel[i].Location = new Point(1, i * 23 + 2);
                SkillTotalLabel[i].Padding = new Padding(2);
                SkillTotalLabel[i].AutoSize = false;
                SkillTotalLabel[i].BackColor = Color.Black;
                SkillTotalLabel[i].ForeColor = Color.White;
                SkillTotalLabel[i].Name = "SkillTotalLabel[" + i + "]";
                SkillTotalLabel[i].Size = new Size(25, 21);
                SkillTotalLabel[i].Text = "0";
                SkillTotalLabel[i].TextAlign = ContentAlignment.MiddleCenter;
            }

			//cache the starting positions of the labels
			SkillRowStartY = new List<int>();
			for (int i = 0; i < NumSkills; i++)
				SkillRowStartY.Add(SkillNameLabel[i].Location.Y);
			}

		#endregion

		#region Private Functions
		/// <summary>
		/// Handle the scrolling
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="scrollEventArgs"></param>
		private void SkillsSubPanelScrollBarOnScroll(Object sender, ScrollEventArgs scrollEventArgs)
			{
			for (int i = 0; i < NumSkills; i++)
				{
				SkillNameLabel[i].Location = new Point(SkillNameLabel[i].Location.X, SkillRowStartY[i] - (scrollEventArgs.NewValue * SkillSubPanel.Size.Height / ScrollTotalMove));
                SkillRankLabel[i].Location = new Point(SkillRankLabel[i].Location.X, SkillRowStartY[i] - (scrollEventArgs.NewValue * SkillSubPanel.Size.Height / ScrollTotalMove));
                SkillAbilityLabel[i].Location = new Point(SkillAbilityLabel[i].Location.X, SkillRowStartY[i] - (scrollEventArgs.NewValue * SkillSubPanel.Size.Height / ScrollTotalMove));
                SkillTomeLabel[i].Location = new Point(SkillTomeLabel[i].Location.X, SkillRowStartY[i] - (scrollEventArgs.NewValue * SkillSubPanel.Size.Height / ScrollTotalMove));
                SkillFeatLabel[i].Location = new Point(SkillFeatLabel[i].Location.X, SkillRowStartY[i] - (scrollEventArgs.NewValue * SkillSubPanel.Size.Height / ScrollTotalMove));
                SkillEnhLabel[i].Location = new Point(SkillEnhLabel[i].Location.X, SkillRowStartY[i] - (scrollEventArgs.NewValue * SkillSubPanel.Size.Height / ScrollTotalMove));
                SkillDestLabel[i].Location = new Point(SkillDestLabel[i].Location.X, SkillRowStartY[i] - (scrollEventArgs.NewValue * SkillSubPanel.Size.Height / ScrollTotalMove));
                SkillGearLabel[i].Location = new Point(SkillGearLabel[i].Location.X, SkillRowStartY[i] - (scrollEventArgs.NewValue * SkillSubPanel.Size.Height / ScrollTotalMove));
                
                
                SkillTotalLabel[i].Location = new Point(SkillTotalLabel[i].Location.X, SkillRowStartY[i] - (scrollEventArgs.NewValue * SkillSubPanel.Size.Height / ScrollTotalMove));
				}

			SkillsSubPanelScrollBar.Value = scrollEventArgs.NewValue;
			}

		/// <summary>
		/// Handle the mouse wheel event
		/// </summary>
		private void SkillSubPanelMouseWheel(Object sender, MouseEventArgs mouseEventArgs)
			{
			if (mouseEventArgs.Delta < 0)
				{
				if (SkillsSubPanelScrollBar.Value + LargeScrollMove < SkillsSubPanelScrollBar.Maximum)
					{
					ScrollEventArgs scrollEventArgs = new ScrollEventArgs(ScrollEventType.LargeIncrement, SkillsSubPanelScrollBar.Value + LargeScrollMove);
					SkillsSubPanelScrollBarOnScroll(sender, scrollEventArgs);
					}
				else
					{
					ScrollEventArgs scrollEventArgs = new ScrollEventArgs(ScrollEventType.LargeIncrement, SkillsSubPanelScrollBar.Maximum);
					SkillsSubPanelScrollBarOnScroll(sender, scrollEventArgs);
					}
				}
			else
				{
				if (SkillsSubPanelScrollBar.Value - LargeScrollMove >= SkillsSubPanelScrollBar.Minimum)
					{
					ScrollEventArgs scrollEventArgs = new ScrollEventArgs(ScrollEventType.LargeIncrement, SkillsSubPanelScrollBar.Value - LargeScrollMove);
					SkillsSubPanelScrollBarOnScroll(sender, scrollEventArgs);
					}
				else
					{
					ScrollEventArgs scrollEventArgs = new ScrollEventArgs(ScrollEventType.LargeIncrement, SkillsSubPanelScrollBar.Minimum);
					SkillsSubPanelScrollBarOnScroll(sender, scrollEventArgs);
					}
				}
			}
		
            private void SkillPanelEditButton_Click(object sender, EventArgs e)
        {   

            if(DDOCharacterPlanner.CharacterData.CharacterManagerClass.CharacterManager.CharacterClass.GetClass(1)!=Guid.Empty)
            {
                UIManagerClass.UIManager.ShowChildScreen(UIManagerClass.ChildScreen.SkillEditScreen);


            }
            else
            {
                MessageBox.Show("Set Class first", "Missing Class", MessageBoxButtons.OK, MessageBoxIcon.Warning);  
            }


        }
            #endregion

            #region public Functions
            public void Updatevalues(int SelectedLevel)
        {
            for(int i=0;i<NumSkills;++i)
            {
            
            SkillRankLabel[i].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, SelectedLevel,CharacterSkillClass.ModifierTypes.RankTotal).ToString();
            SkillAbilityLabel[i].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, SelectedLevel, CharacterSkillClass.ModifierTypes.Ability).ToString("+#;-#;0");
            SkillTomeLabel[i].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, SelectedLevel,CharacterSkillClass.ModifierTypes.Tome).ToString();
            SkillFeatLabel[i].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, SelectedLevel,CharacterSkillClass.ModifierTypes.Feat).ToString();
            SkillEnhLabel[i].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, SelectedLevel,CharacterSkillClass.ModifierTypes.Enhancement).ToString();
            SkillDestLabel[i].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, SelectedLevel,CharacterSkillClass.ModifierTypes.Destiny).ToString();
            SkillGearLabel[i].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, SelectedLevel, CharacterSkillClass.ModifierTypes.Gear).ToString();
            SkillTotalLabel[i].Text = CharacterManagerClass.CharacterManager.CharacterSkill.GetSkill((CharacterSkillClass.Skills)i, SelectedLevel, CharacterSkillClass.ModifierTypes.All).ToString();
            }
        }
        
        #endregion		


		}    

	}
