using DDOCharacterPlanner.CharacterData;
using DDOCharacterPlanner.Data;
using DDOCharacterPlanner.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.MainScreen
    {
    public partial class ClassEditScreen : Form
        {
        #region enums
        #endregion

        #region Member Variables
        private List<string> ClassNames;
        private List<string> HeroicRaceNames;
        private List<string> IconicRaceNames;
        private List<PictureBox> PanelClassPictureBoxes;
        private List<PictureBox> HeroicRacePictureBoxes;
        private List<PictureBox> IconicRacePictureBoxes;
        private List<Panel> HeroicRacePanels;
        private List<Panel> IconicRacePanels;
        private List<Label> HeroicRaceLabels;
        private List<Label> IconicRaceLabels;
        private List<string> ChosenClasses;
        private int DragClassIndex;
        private int ChosenClassSelected;
        private string RaceSelected;
        //IconClass testIcon;
        #endregion

        #region Constructors
        public ClassEditScreen()
            {
            List<string> raceNames;

            InitializeComponent();
            ApplySkin();

            pictureBoxChosenClass1.AllowDrop = true;
            pictureBoxChosenClass2.AllowDrop = true;
            pictureBoxChosenClass3.AllowDrop = true;

            ClassNames = DataManagerClass.DataManager.ClassDataCollection.ClassNames;
            ChosenClasses = new List<string>();
            ChosenClasses.Add("");
            ChosenClasses.Add("");
            ChosenClasses.Add("");
            ChosenClassSelected = 0;

            //Lets sort our race names into the 2 categories (heroic and Iconic)
            raceNames = DataManagerClass.DataManager.RaceDataCollection.RaceNames;
            HeroicRaceNames = new List<string>();
            IconicRaceNames = new List<string>();
            foreach (string name in raceNames)
                {
                if (DataManagerClass.DataManager.RaceDataCollection.Races[name].IconicRace == true)
                    IconicRaceNames.Add(name);
                else
                    HeroicRaceNames.Add(name);
                }

            //Now lets create our race boxes
            HeroicRacePanels = new List<Panel>();
            IconicRacePanels = new List<Panel>();
            HeroicRacePictureBoxes = new List<PictureBox>();
            IconicRacePictureBoxes = new List<PictureBox>();
            HeroicRaceLabels = new List<Label>();
            IconicRaceLabels = new List<Label>();
            CreateRaceBoxes();

            //Let create our Class Picture boxes
            PanelClassPictureBoxes = new List<PictureBox>();
            CreateClassesPanelPictureBoxes();

            //lets set the emptyimage of the chosenclassboxes
            UpdateChosenPictureBox(1, "");
            UpdateChosenPictureBox(2, "");
            UpdateChosenPictureBox(3, "");

            //Lets check for existing values (race and selected classes already)
            GetCharacterData();

            //lets refresh our Available Classes panel
            UpdateClassesPanel();

			//listen for change notification messages
			UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.ClassEditScreen, ScreenMessengerClass.ChangeList.ClassChange, HandleClassChange);
            UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.ClassEditScreen, ScreenMessengerClass.ChangeList.RaceChange, HandleRaceChange);
            UIManagerClass.UIManager.ScreenMessenger.RegisterListen(UIManagerClass.ChildScreen.ClassEditScreen, ScreenMessengerClass.ChangeList.AlignmentChange, HandleAlignmentChange);
        }

        #endregion

        #region Control Events
        private void checkBoxIgnoreIconicRestrictions_Click(object sender, EventArgs e)
            {
            if (checkBoxIgnoreIconicRestrictions.Checked == true)
                CharacterManagerClass.CharacterManager.CharacterRace.IconicRestrictions = false;
            else
                CharacterManagerClass.CharacterManager.CharacterRace.IconicRestrictions = true;

            }

        private void labelClass_Click(object sender, EventArgs e)
            {
            Label labelBox;
            string boxIndexString;
            int boxIndex;

            labelBox = (Label)sender;
            boxIndexString = Regex.Match(labelBox.Name, @"\d+").Value;
            boxIndex = Int32.Parse(boxIndexString);

            if (ChosenClassSelected == 0)
                return;
            if (labelBox.Text != ChosenClasses[ChosenClassSelected - 1])
                {
                labelBox.Text = ChosenClasses[ChosenClassSelected - 1];
                UpdateCharacterDataClass(boxIndex, ChosenClasses[ChosenClassSelected - 1]);
                }

            UpdateClassSplitBreakdown();
            }

        private void labelClass_MouseClick(object sender, MouseEventArgs e)
            {
            Label labelBox;
            string boxIndexString;
            int boxIndex;
            
            labelBox = (Label)sender;
            boxIndexString = Regex.Match(labelBox.Name, @"\d+").Value;
            boxIndex = Int32.Parse(boxIndexString);

            if (e.Button == MouseButtons.Right)
                {
                labelBox.Text = ChosenClasses[0];
                UpdateCharacterDataClass(boxIndex, ChosenClasses[0]);
                UpdateClassSplitBreakdown();
                }
            }

        private void PanelClassPictureBox_MouseDown(object sender, MouseEventArgs e)
            {
            PictureBox pictureBox;
            string boxIndexString;

            pictureBox = new PictureBox();
            pictureBox = (PictureBox)sender;
            boxIndexString = Regex.Match(pictureBox.Name, @"\d+").Value;
            DragClassIndex = Int32.Parse(boxIndexString);

            Image img = pictureBox.Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
                {
                //DragClassIndex = Int32.Parse(boxIndexString);
                pictureBox.Image = img;
                UpdateClassesPanel();
                }
            }

        private void pbHeroicRace_Click(object sender, EventArgs e)
            {
            int boxIndex;

            boxIndex = GetPictureBoxIndex(sender);
            
            if (RaceSelected == HeroicRaceNames[boxIndex])
                return;

            UpdateRaceSelection(false, boxIndex);
            RaceSelected = HeroicRaceNames[boxIndex];
            
            if (RaceSelected == "Drow")
            {
                CharacterManagerClass.CharacterManager.CharacterAbility.SetBuildType(CharacterAbilityClass.BuildPointType.Drow, true);
            }

            else
            {
                CharacterManagerClass.CharacterManager.CharacterAbility.SetBuildType(CharacterAbilityClass.BuildPointType.Drow, false);
                CharacterManagerClass.CharacterManager.CharacterAbility.SetBuildType(CharacterAbilityClass.BuildPointType.Iconic, false);
            }
            UpdateCharacterDataRace(RaceSelected);
            }

        private void pbIconicRace_Click(object sender, EventArgs e)
            {
            int boxIndex;

            boxIndex = GetPictureBoxIndex(sender);

            if (RaceSelected == IconicRaceNames[boxIndex])
                return;

            UpdateRaceSelection(true, boxIndex);
            RaceSelected = IconicRaceNames[boxIndex];
            
            CharacterManagerClass.CharacterManager.CharacterAbility.SetBuildType(CharacterAbilityClass.BuildPointType.Iconic, true);
            UpdateCharacterDataRace(RaceSelected);
            if (checkBoxIgnoreIconicRestrictions.Checked == false)
                UpdateClassChoicesFromIconicRaceChange(RaceSelected);
                    string ClassName;
                    ClassName = DataManagerClass.DataManager.RaceDataCollection.Races[RaceSelected].IconicStartingClass;
            if(HasValidAlignment(ClassName)==false)
                {
                    CharacterManagerClass.CharacterManager.CharacterAlignment.UpdateAlignment(
                        DataManagerClass.DataManager.AlignmentData.Alignment[DataManagerClass.DataManager.ClassDataCollection.Classes[ClassName].AllowedAlignment[0]]);
                    UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.ClassEditScreen, ScreenMessengerClass.ChangeList.AlignmentChange);
                }
            }

        private void pbHeroicRace_Paint(object sender, PaintEventArgs e)
            {
            PictureBox pbBox;
            string boxIndexString;
            int boxIndex;
            string name;

            pbBox = (PictureBox)sender;
            boxIndexString = Regex.Match(pbBox.Name, @"\d+").Value;
            boxIndex = Int32.Parse(boxIndexString);
            name = HeroicRaceNames[boxIndex];
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(name, Font, Brushes.White, 50, 15);
            }

        private void pbIconicRace_Paint(object sender, PaintEventArgs e)
            {
            PictureBox pbBox;
            string boxIndexString;
            int boxIndex;
            string name;

            pbBox = (PictureBox)sender;
            boxIndexString = Regex.Match(pbBox.Name, @"\d+").Value;
            boxIndex = Int32.Parse(boxIndexString);
            name = IconicRaceNames[boxIndex];
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(name, Font, Brushes.White, 50, 15);
            }

        private void pictureBoxChosenClass1_Click(object sender, EventArgs e)
            {          
            ChosenClassSelected = 1;
            UpdateClassSelection();
            }

        private void pictureBoxChosenClass2_Click(object sender, EventArgs e)
            {
            ChosenClassSelected = 2;
            UpdateClassSelection();
            }

        private void pictureBoxChosenClass3_Click(object sender, EventArgs e)
            {
            ChosenClassSelected = 3;
            UpdateClassSelection();
            }

        private void pictureBoxChosenClass1_DragEnter(object sender, DragEventArgs e)
            {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
            }

        private void pictureBoxChosenClass1_DragDrop(object sender, DragEventArgs e)
            {
            if (CanChosenClassBeRemoved(1) == true)
                {
                Image img = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                pictureBoxChosenClass1.Image = img;
                UpdateClassLabels(ChosenClasses[0], ClassNames[DragClassIndex]);
                ChosenClasses[0] = ClassNames[DragClassIndex];
                labelChosenClass1.Text = ChosenClasses[0];
                UpdateClassSplitBreakdown();
                ChosenClassSelected = 1;
                UpdateClassSelection();
                }
            }

        private void pictureBoxChosenClass2_DragEnter(object sender, DragEventArgs e)
            {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
            }

        private void pictureBoxChosenClass2_DragDrop(object sender, DragEventArgs e)
            {
            if (CanChosenClassBeRemoved(2) == true)
                {
                Image img = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                pictureBoxChosenClass2.Image = img;
                UpdateClassLabels(ChosenClasses[1], ClassNames[DragClassIndex]);
                ChosenClasses[1] = ClassNames[DragClassIndex];
                labelChosenClass2.Text = ChosenClasses[1];
                UpdateClassSplitBreakdown();
                ChosenClassSelected = 2;
                UpdateClassSelection();
                }
            }

        private void pictureBoxChosenClass3_DragEnter(object sender, DragEventArgs e)
            {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
            }

        private void pictureBoxChosenClass3_DragDrop(object sender, DragEventArgs e)
            {
            Image img = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            if (CanChosenClassBeRemoved(3) == true)
                {
                pictureBoxChosenClass3.Image = img;
                UpdateClassLabels(ChosenClasses[2], ClassNames[DragClassIndex]);
                ChosenClasses[2] = ClassNames[DragClassIndex];
                labelChosenClass3.Text = ChosenClasses[2];
                UpdateClassSplitBreakdown();
                ChosenClassSelected = 3;
                UpdateClassSelection();
                }
            }

        private void picutureBoxChosenClass_MouseClick(object sender, MouseEventArgs e)
            {
            PictureBox pictureBox;
            string boxIndexString;
            int index;

            pictureBox = (PictureBox)sender;
            boxIndexString = Regex.Match(pictureBox.Name, @"\d+").Value;
            index = Int32.Parse(boxIndexString);

            if (e.Button == MouseButtons.Right)
                {
                if (CanChosenClassBeRemoved(index) == true)
                    {
                    if (index > 1)
                        {
                        UpdateClassLabels(ChosenClasses[index - 1], ChosenClasses[0]);
                        }
                    else
                        {
                        UpdateClassLabels(ChosenClasses[0], "");
                        }

                    UpdateChosenClassLabel(index, "");
                    ChosenClasses[index - 1] = "";
                    UpdateChosenPictureBox(index, "");
                    ChosenClassSelected = 0;
                
                    UpdateClassSelection();
                    UpdateClassesPanel();
                    UpdateClassSplitBreakdown();
                    }
                }
            }
        #endregion

        #region Form Events
        private void ClassEditScreen_Load(object sender, EventArgs e)
            {

            }

        private void OnPaint(object sender, PaintEventArgs paintEventArgs)
            {
            //DrawIcon(paintEventArgs);
            }

		private void OnFormClosing(object sender, FormClosingEventArgs e)
			{

            UIManagerClass.UIManager.CloseChildScreen(UIManagerClass.ChildScreen.ClassEditScreen);
			//stop listening for notifiation messages
			UIManagerClass.UIManager.ScreenMessenger.DeregisterListener(UIManagerClass.ChildScreen.ClassEditScreen);
			}

        #endregion

        #region Private Methods
        private void DrawIcon(PaintEventArgs paintEventArgs)
            {
            //testIcon.Draw(paintEventArgs);
            }

        private bool CanChosenClassBeRemoved(int index)
            {
            bool removable;

            removable = true;

            if (RaceSelected != "" && RaceSelected != null)
                {
                if (DataManagerClass.DataManager.RaceDataCollection.Races[RaceSelected].IconicRace == true && checkBoxIgnoreIconicRestrictions.Checked == false)
                    {
                    if (ChosenClasses[index - 1] == DataManagerClass.DataManager.RaceDataCollection.Races[RaceSelected].IconicStartingClass)
                        removable = false;
                    }
                }

            return removable;
            }

        private void CreateClassesPanelPictureBoxes()
            {
            int classCount = ClassNames.Count;
            int top = 5;
            int left = 5;
            string iconName;
            Image img;
            Image ResizeImage;
            //testIcon = new IconClass("Classes\\Barbarian");
            //testIcon.SetLocation(this.Width, this.Height, new PointF(.02f, .02f));

            //PanelClassPictureBoxes.Clear();
            for (int i = 0; i < classCount; i++)
                {
                iconName = "Artificer";
                iconName = DataManagerClass.DataManager.ClassDataCollection.Classes[ClassNames[i]].IconName;
                try
                    {
                    img = Image.FromFile(Application.StartupPath + "\\Graphics\\Classes\\" + iconName + ".png");
                    }
                catch
                    {
                    img = Image.FromFile(Application.StartupPath + "\\Graphics\\NoImage.png");
                    }
                ResizeImage = (Image)new Bitmap(img, new Size(60,60));
                img = ResizeImage;
                //lets create the boxes
                PanelClassPictureBoxes.Add(new PictureBox());
                PanelClassPictureBoxes[i].Name = "PanelClassPictureBox[" + i + "]";
                PanelClassPictureBoxes[i].Size = new Size(60, 60);
                PanelClassPictureBoxes[i].Location = new Point(left, top);
                PanelClassPictureBoxes[i].BackColor = Color.Black;
                PanelClassPictureBoxes[i].Image = img;
                //PanelClassPictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                PanelClassPictureBoxes[i].MouseDown += PanelClassPictureBox_MouseDown;
                panelClasses.Controls.Add(PanelClassPictureBoxes[i]);

                //set the locations for the next box.
                if ((i+1) % 3 == 0)
                    left = 5;
                else
                    left += 70;
                if (i != 0 && ((i + 1) % 3 == 0))
                    top += 70;
                }
            Invalidate();
            }

        private void CreateRaceBoxes()
            {
            int top = 5;
            int left = 5;
            string iconName;
            Image img;
            Image ResizeImage;

            //Lets create the Heroic Race Boxes
            for (int i = 0; i < HeroicRaceNames.Count; i++)
                {
                iconName = DataManagerClass.DataManager.RaceDataCollection.Races[HeroicRaceNames[i]].IconName;
                try
                    {
                    img = Image.FromFile(Application.StartupPath + "\\Graphics\\Races\\" + iconName + ".png");
                    }
                catch
                    {
                    img = Image.FromFile(Application.StartupPath + "\\Graphics\\NoImage.png");
                    }
                ResizeImage = (Image)new Bitmap(img, new Size(147, 39));
                img = ResizeImage;

                //create the panel
                HeroicRacePanels.Add(new Panel());
                HeroicRacePanels[i].Name = "panelHeroicRace[" + i + "]";
                HeroicRacePanels[i].Size = new Size(157, 49);
                HeroicRacePanels[i].BackColor = Color.Transparent;
                HeroicRacePanels[i].Location = new Point(left,top);
                //HeroicRacePanels[i].BorderStyle = BorderStyle.FixedSingle;
                panelHeroicRaces.Controls.Add(HeroicRacePanels[i]);

                //create the picturebox
                HeroicRacePictureBoxes.Add(new PictureBox());
                HeroicRacePictureBoxes[i].Name = "pbHeroicRace[" + i + "]";
                HeroicRacePictureBoxes[i].Size = new Size(147, 39);
                //HeroicRacePictureBoxes[i].Size = new Size (60 , 60);
                HeroicRacePictureBoxes[i].BackColor = Color.Black;
                HeroicRacePictureBoxes[i].Image = img;
                HeroicRacePictureBoxes[i].Location = new Point(5,5);
                HeroicRacePictureBoxes[i].Paint += pbHeroicRace_Paint;
                HeroicRacePictureBoxes[i].Click += pbHeroicRace_Click;
                HeroicRacePanels[i].Controls.Add(HeroicRacePictureBoxes[i]);

                //set the locations for the next panel
                if ((i +1)%2 == 0)
                    left = 5;
                else
                    left += 167;
                if (i !=0 && ((i+1)%2 == 0))
                    top += 50;
                }

            //Lets create the Iconic Race Boxes
            top = 5;
            left = 5;
            for (int i = 0; i < IconicRaceNames.Count; i++)
                {
                iconName = DataManagerClass.DataManager.RaceDataCollection.Races[IconicRaceNames[i]].IconName;
                try
                    {
                    img = Image.FromFile(Application.StartupPath + "\\Graphics\\Races\\" + iconName + ".png");
                    }
                catch
                    {
                    img = Image.FromFile(Application.StartupPath + "\\Graphics\\NoImage.png");
                    }
                ResizeImage = (Image)new Bitmap(img, new Size(147, 39));
                img = ResizeImage;

                //create the panel
                IconicRacePanels.Add(new Panel());
                IconicRacePanels[i].Name = "panelIconicRace[" + i + "]";
                IconicRacePanels[i].Size = new Size(157, 49);
                IconicRacePanels[i].BackColor = Color.Transparent;
                IconicRacePanels[i].Location = new Point(left, top);
                //IconicRacePanels[i].BorderStyle = BorderStyle.FixedSingle;
                panelIconicRaces.Controls.Add(IconicRacePanels[i]);

                //create the picturebox
                IconicRacePictureBoxes.Add(new PictureBox());
                IconicRacePictureBoxes[i].Name = "pbIconicRace[" + i + "]";
                IconicRacePictureBoxes[i].Size = new Size(147, 39);
                IconicRacePictureBoxes[i].BackColor = Color.Black;
                IconicRacePictureBoxes[i].Image = img;
                IconicRacePictureBoxes[i].Location = new Point(5, 5);
                IconicRacePictureBoxes[i].Paint += pbIconicRace_Paint;
                IconicRacePictureBoxes[i].Click += pbIconicRace_Click;
                IconicRacePanels[i].Controls.Add(IconicRacePictureBoxes[i]);

                //set the locations for the next panel
                //if ((i + 1) % 2 == 0)
                //    left = 5;
                //else
                //    left += 167;
                //if (i != 0 && ((i + 1) % 2 == 0))
                    top += 50;
                }
            }

        private void GetCharacterData()
            {
            Label labelControl;
            string controlName;
            Guid classId;
            string className;
            string race;
            string[] classes;
           
            //Lets get the Character race if one has been selected already
            race = CharacterManagerClass.CharacterManager.CharacterRace.GetRaceName();
            if (race != "")
                {
                if (DataManagerClass.DataManager.RaceDataCollection.Races[race].IconicRace == true)
                    {
                    RaceSelected = race;
                    UpdateRaceSelection(true, IconicRaceNames.IndexOf(race));
                    
                    }
                else
                    {
                    RaceSelected = race;
                    UpdateRaceSelection(false, HeroicRaceNames.IndexOf(race));
                    }
                }

            checkBoxIgnoreIconicRestrictions.Checked = CharacterManagerClass.CharacterManager.CharacterRace.IconicRestrictions;

            //Lets set up the selected Class pictureboxes
            classes = CharacterManagerClass.CharacterManager.CharacterClass.GetClassesSorted();
            UpdateChosenPictureBox(1, classes[0]);
            UpdateChosenClassLabel(1, classes[0]);
            ChosenClasses[0] = classes[0];
            UpdateChosenPictureBox(2, classes[1]);
            UpdateChosenClassLabel(2, classes[1]);
            ChosenClasses[1] = classes[1];
            UpdateChosenPictureBox(3, classes[2]);
            UpdateChosenClassLabel(3, classes[2]);
            ChosenClasses[2] = classes[2];

            labelClassSplitBreakdown.Text = CharacterManagerClass.CharacterManager.CharacterClass.GetClassSplit();

            //Load previous selected classes if any
            for (int i = 1; i < 21; i++)
                {
                controlName = "labelClass" + (i);
                labelControl = (Label)this.Controls[controlName];
                classId = CharacterManagerClass.CharacterManager.CharacterClass.GetClass(i);
                if (classId == Guid.Empty)
                    {
                    labelControl.Text = "";
                    }
                else
                    {
                    //we need to get the class name and then update the class lable for this level
                    className = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classId);
                    labelControl.Text = DataManagerClass.DataManager.ClassDataCollection.Classes[className].Name;
                    }
                }
            }

        private int GetPictureBoxIndex(object pictureBox)
            {
            int index;
            PictureBox pBox;
            string boxIndexString;
            index = -1;

            pBox = (PictureBox)pictureBox;
            boxIndexString = Regex.Match(pBox.Name, @"\d+").Value;
            index = Int32.Parse(boxIndexString);

            return index;
            }

        private bool HasAlignmentMatch(string className1, string className2)
            {
            for (int i = 0; i < DataManagerClass.DataManager.ClassDataCollection.Classes[className1].AllowedAlignment.Count(); i++)
                {
                for (int j = 0; j < DataManagerClass.DataManager.ClassDataCollection.Classes[className2].AllowedAlignment.Count(); j++)
                    {
                    if (DataManagerClass.DataManager.ClassDataCollection.Classes[className1].AllowedAlignment[i] ==
                        DataManagerClass.DataManager.ClassDataCollection.Classes[className2].AllowedAlignment[j])
                        return true;
                    }
                }
            return false;
            }
        private bool HasValidAlignment(string className1)
        {
            for(int i = 0; i<DataManagerClass.DataManager.ClassDataCollection.Classes[className1].AllowedAlignment.Count(); i++ )
            {
                if (DataManagerClass.DataManager.ClassDataCollection.Classes[className1].AllowedAlignment[i] == CharacterManagerClass.CharacterManager.CharacterAlignment.Alignment)
                    return true;
            }
            return false;
        }

        private void UpdateChosenClassLabel(int index, string text)
            {
            Label labelControl;
            string controlName;

            if (index < 1 || index > 3)
                return;


            if (text == "" && index == 1)
                text = "Primary Class";
            if (text == "" && index == 2)
                text = "Secondary Class";
            if (text == "" && index == 3)
                text = "Third Class";

            labelControl = new Label();
            controlName = "";
            controlName = "labelChosenClass" + index;
            labelControl = (Label)this.Controls[controlName];
            labelControl.Text = text;
            }

        private void UpdateChosenPictureBox(int index, string className)
            {
            PictureBox pbControl;
            string panelName;
            string pbName;
            Image img;
            Image ResizedImage;
            string iconName;

            if (className == "")
                iconName = "";
            else
                iconName = DataManagerClass.DataManager.ClassDataCollection.Classes[className].IconName;
            try
                {
                img = Image.FromFile(Application.StartupPath + "\\Graphics\\Classes\\" + iconName + ".png");
                }
            catch
                {
                img = Image.FromFile(Application.StartupPath + "\\Graphics\\Interface\\EmptyBox.png");
                }
            ResizedImage = (Image)new Bitmap(img, new Size(60, 60));

            pbControl = new PictureBox();
            
            pbName = "pictureBoxChosenClass" + index;
            panelName = "panelChosenClass" + index;
            pbControl = (PictureBox)this.Controls[panelName].Controls[pbName];
            pbControl.Image = ResizedImage;
            }

        private void UpdateClassChoicesFromIconicRaceChange(string raceName)
            {
            string iconicClass;

            iconicClass = DataManagerClass.DataManager.RaceDataCollection.Races[raceName].IconicStartingClass;
            
            //lets see if the startingclasss is already chosen, if so then we can just exit
            for (int i = 0; i < 3; i++)
                {
                if (ChosenClasses[i] == iconicClass)
                    return;
                }

            //Ok we made it this far, so now we need to change the first class choice to the starting class.
            UpdateClassLabels(ChosenClasses[0], iconicClass);
            ChosenClasses[0] = iconicClass;
            UpdateChosenClassLabel(1, iconicClass);
            UpdateChosenPictureBox(1, iconicClass);

            //ok now that we have changed the first class, we need to verify the alignmet compatiblity of
            //other 2 classes and change them if necessary
            if (ChosenClasses[1] != "")
                {
                    if (HasAlignmentMatch(ChosenClasses[0], ChosenClasses[1]) == false)
                    {
                    UpdateClassLabels(ChosenClasses[1], ChosenClasses[0]);
                    ChosenClasses[1] = "";
                    UpdateChosenClassLabel(2, "");
                    UpdateChosenPictureBox(2, "");
                    }
                }

            if (ChosenClasses[2] != "")
                {
                    if (HasAlignmentMatch(ChosenClasses[0], ChosenClasses[2]) == false)
                    {
                    UpdateClassLabels(ChosenClasses[2], ChosenClasses[0]);
                    ChosenClasses[2] = "";
                    UpdateChosenClassLabel(3, "");
                    UpdateChosenPictureBox(3, "");
                    }
                }

            UpdateClassesPanel();

            }

        private void UpdateClassLabels(string oldClass, string newClass)
            {
            Label labelControl;
            string controlName;
            bool notify;

            notify = false;
            labelControl = new Label();
            controlName = "";
            for (int i = 1; i < 21; i++)
                {
                controlName = "labelClass" + i;
                labelControl = (Label)this.Controls[controlName];
                if (labelControl.Text == oldClass || labelControl.Text == "" || labelControl.Text == null)
                    {
                    notify = true;
                    labelControl.Text = newClass;
                    UpdateCharacterDataClass(i, newClass, false);
                    }
                }
            if (notify == true)
                UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.ClassEditScreen, ScreenMessengerClass.ChangeList.ClassChange);
            }
        
        private void UpdateCharacterDataClass(int level, string className, bool notify=true)
            {
            Guid classId;

            if (className == "")
                classId = Guid.Empty;
            else
                classId = DataManagerClass.DataManager.ClassDataCollection.Classes[className].ClassId;

            CharacterManagerClass.CharacterManager.CharacterClass.UpdateClass(level, classId);
            if (notify == true)
                UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.ClassEditScreen, ScreenMessengerClass.ChangeList.ClassChange);
            }

        private void UpdateCharacterDataRace(string raceName)
            {

            CharacterManagerClass.CharacterManager.CharacterRace.UpdateRace(raceName);

            UIManagerClass.UIManager.ScreenMessenger.NotifyChange(UIManagerClass.ChildScreen.ClassEditScreen, ScreenMessengerClass.ChangeList.RaceChange);
            }

        private void UpdateClassesPanel()
            {
            string controlName;
            PictureBox pictureBox;
            bool flag;
            string iconName;
            Image img;
            Image ResizeImage;

            controlName = "";
            pictureBox = new PictureBox();

            //ok lets hide the classes that are already chosen
            for (int i = 0; i < ClassNames.Count; i++)
                {
                controlName = "PanelClassPictureBox[" + i + "]";
                pictureBox = (PictureBox)this.panelClasses.Controls[controlName];
                if (ClassNames[i] == ChosenClasses[0] || ClassNames[i] == ChosenClasses[1] || ClassNames[i] == ChosenClasses[2])
                    pictureBox.Visible = false;
                else
                    {
                    pictureBox.Visible = true;
                    //Lets disable the classes that can't be chosen because of alignment issues.
                    flag = true;
                    for (int j = 0; j < 3; j++)
                        {
                        if (ChosenClasses[j] != "")
                            {
                                if (HasAlignmentMatch(ClassNames[i], ChosenClasses[j]) == false)
                                {
                                flag = false;
                                break;
                                }

                            }
                        }
                    if (HasValidAlignment(ClassNames[i]) == false)
                    {
                        flag = false;
                    }


                    if (flag == false)
                        {
                        pictureBox.Image = UtilityClass.ConvertImageToGrayscale(pictureBox.Image);
                        pictureBox.Enabled = false;
                        }
                    else
                        {
                        if (pictureBox.Enabled == false)
                            {
                            pictureBox.Enabled = true;
                            iconName = DataManagerClass.DataManager.ClassDataCollection.Classes[ClassNames[i]].IconName;
                            try
                                {
                                img = Image.FromFile(Application.StartupPath + "\\Graphics\\Classes\\" + iconName + ".png");
                                }
                            catch
                                {
                                img = Image.FromFile(Application.StartupPath + "\\Graphics\\NoImage.png");
                                }
                            ResizeImage = (Image)new Bitmap(img, new Size(60, 60));
                            img = ResizeImage;
                            pictureBox.Image = img;
                            }
                        }
                    }
                }
            
            }

        private void UpdateClassSelection()
            {
            switch (ChosenClassSelected)
                {
                case 0:
                        {
                        panelChosenClass1.BackColor = Color.Transparent;
                        panelChosenClass2.BackColor = Color.Transparent;
                        panelChosenClass3.BackColor = Color.Transparent;
                        break;
                        }
                case 1:
                        {
                        panelChosenClass1.BackColor = Color.Green;
                        panelChosenClass2.BackColor = Color.Transparent;
                        panelChosenClass3.BackColor = Color.Transparent;
                        break;
                        }
                case 2:
                        {
                        panelChosenClass1.BackColor = Color.Transparent;
                        panelChosenClass2.BackColor = Color.Green;
                        panelChosenClass3.BackColor = Color.Transparent;
                        break;
                        }
                case 3:
                        {
                        panelChosenClass1.BackColor = Color.Transparent;
                        panelChosenClass2.BackColor = Color.Transparent;
                        panelChosenClass3.BackColor = Color.Green;
                        break;
                        }
                }
            }

        private void UpdateClassSplitBreakdown()
            {
            labelClassSplitBreakdown.Text = CharacterManagerClass.CharacterManager.CharacterClass.GetClassSplit();
            }

        private void UpdateRaceSelection(bool isIconic, int index)
            {
            string controlName;
            Panel panelBox;

            //lets turn of any previous selection.
            if (RaceSelected != "")
                {
                for (int i = 0; i < HeroicRaceNames.Count; i++)
                    {
                    controlName = "PanelHeroicRace[" + i + "]";
                    panelBox = (Panel)this.panelHeroicRaces.Controls[controlName];
                    panelBox.BackColor = Color.Transparent;
                    }
                for (int i = 0; i < IconicRaceNames.Count; i++)
                    {
                    controlName = "PanelIconicRace[" + i + "]";
                    panelBox = (Panel)this.panelIconicRaces.Controls[controlName];
                    panelBox.BackColor = Color.Transparent;
                    }
                }

            //now lets turn on the selection for the selected race
            if (isIconic == true)
                {
                controlName = "PanelIconicRace[" + index + "]";
                panelBox = (Panel)this.panelIconicRaces.Controls[controlName];
                panelBox.BackColor = Color.Green;
                }
            else
                {
                controlName = "PanelHeroicRace[" + index + "]";
                panelBox = (Panel)this.panelHeroicRaces.Controls[controlName];
                panelBox.BackColor = Color.Green;
                }

            }
        #endregion

        #region Public Methods
        public void ApplySkin()
            {
            UIManagerClass uiManager = UIManagerClass.UIManager;
            SkinStyleClass style;
            string controlName;
            Label labelBox;

            //Screen Background
            style = uiManager.Skin.GetSkinStyle("MainScreenClassEditScreenBackgroundColor");
            this.BackColor = style.Color1;

            //Level Labels
            style = uiManager.Skin.GetSkinStyle("MainScreenClassEditScreenLabel");
            for (int i = 1; i < 21; i++)
                {
                controlName = "labelLevel" + i;
                labelBox = (Label)this.Controls[controlName];
                labelBox.BackColor = style.Color2;
                labelBox.ForeColor = style.Color1;
                labelBox.Font = style.Font;
                }

            //Chosen Class Labels
            for (int i = 1; i < 4; i++)
                {
                controlName = "labelChosenClass" + i;
                labelBox = (Label)this.Controls[controlName];
                labelBox.BackColor = style.Color2;
                labelBox.ForeColor = style.Color1;
                labelBox.Font = style.Font;
                }

            labelClassSplit.BackColor = style.Color2;
            labelClassSplit.ForeColor = style.Color1;
            labelClassSplit.Font = style.Font;
            labelClassSplitBreakdown.BackColor = style.Color2;
            labelClassSplitBreakdown.ForeColor = style.Color1;
            labelClassSplitBreakdown.Font = style.Font;
            labelSelectClasses.BackColor = style.Color2;
            labelSelectClasses.ForeColor = style.Color1;
            labelSelectClasses.Font = style.Font;
            labelSelectRace.BackColor = style.Color2;
            labelSelectRace.ForeColor = style.Color1;
            labelSelectRace.Font = style.Font;
            }

        #endregion

        #region Public Static Methods
        public static void RegisterSkinGroups()
            {
            UIManagerClass uiManager = UIManagerClass.UIManager;

            uiManager.Skin.RegisterSkinGroup("MainScreenClassEditScreenBackgroundColor", SkinSettings.FactoryName.ScreenBackgroundColor);
            uiManager.Skin.RegisterSkinGroup("MainScreenClassEditScreenLabel", SkinSettings.FactoryName.StandardLabel);
            }
        #endregion

		#region Change Notification Handlers
		private void HandleAlignmentChange()
			{
                //ok now that we have changed the alignment, we need to verify the alignmet compatiblity of
                //classes and change them if necessary
                if (ChosenClasses[0] != "")
                {
                    if (HasAlignmentMatch(ChosenClasses[0], ChosenClasses[0]) == false)
                    {
                        UpdateClassLabels(ChosenClasses[1], ChosenClasses[0]);
                        ChosenClasses[0] = "";
                        UpdateChosenClassLabel(1, "");
                        UpdateChosenPictureBox(1, "");
                    }
                }
                if (ChosenClasses[1] != "")
                {
                    if (HasAlignmentMatch(ChosenClasses[0], ChosenClasses[1]) == false)
                    {
                        UpdateClassLabels(ChosenClasses[1], ChosenClasses[0]);
                        ChosenClasses[1] = "";
                        UpdateChosenClassLabel(2, "");
                        UpdateChosenPictureBox(2, "");
                    }
                }

                if (ChosenClasses[2] != "")
                {
                    if (HasAlignmentMatch(ChosenClasses[0], ChosenClasses[2]) == false)
                    {
                        UpdateClassLabels(ChosenClasses[2], ChosenClasses[0]);
                        ChosenClasses[2] = "";
                        UpdateChosenClassLabel(3, "");
                        UpdateChosenPictureBox(3, "");
                    }
                }

                UpdateClassesPanel();


			}

        private void HandleClassChange()
            {

            }

        private void HandleRaceChange()
            {

            }

		#endregion


        }
    }
