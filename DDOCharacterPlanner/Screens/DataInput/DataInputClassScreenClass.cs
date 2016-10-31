
using DDOCharacterPlanner.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using DDOCharacterPlanner.Screens.Controls;
using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Screens.DataInput
	{
	public partial class DataInputClassScreenClass : Form
		{
		#region Enums
		private enum InputType
			{
			Name,
			Description,
			HitDie,
			Abbreviation,
			SkillPoint,
			ReincarnationPriority,
			IconName,
			BAB,
			FortSave,
			ReflexSave,
			WillSave,
			BonusFeat,
			MaxSpellLevel,
			DestinySphere
			};
		#endregion

		#region Member Variables
		private ClassModel Model;
		private List<string> ClassNames;
		private bool DataHasChanged;
		private IconClass ClassIcon;
		private PointF IconLocation = new PointF(0.93f, 0.02f);
		private Point ChildWindowLocation = new Point(450, 100);
		private TextEditWindow DescriptionEditWindow;
		private CheckedListBoxEditWindow AlignmentEditWindow;
		private CheckedListBoxEditWindow SkillEditWindow;
		private List<string> FeatTypeNames;
		private string OldDescription;
		private string DatabaseName;
		private string DatabaseAbbreviation;
		private bool AllowChangeEvents;
		#endregion

		#region Constructor
		public DataInputClassScreenClass()
			{
			string controlName;
			ComboBox bonusFeatTypeCombo;

			AllowChangeEvents = false;

			InitializeComponent();
			Model = new ClassModel();
			ClassNames = ClassModel.GetNames();
			foreach (string Name in ClassNames)
				ClassListBox.Items.Add(Name);

			FeatTypeNames = FeatTypeModel.GetNames();

			//selections for the bonus feat box selectors
			for (int i = 1; i <= Constant.NumHeroicLevels; i++)
				{
				controlName = "BonusFeatComboBox" + i;
				bonusFeatTypeCombo = Controls[controlName] as ComboBox;
				bonusFeatTypeCombo.Items.Add("");
				foreach (string Name in FeatTypeNames)
					bonusFeatTypeCombo.Items.Add(Name);
				}

			PopulateFields(ClassNames[0]);
			ClassListBox.SelectedIndex = 0;

			AutoGrantedFeatsPanel.Initialize("Class", Model.Id);
			DataHasChanged = false;

			AllowChangeEvents = true;
			}
		#endregion

		#region Form Events
		private void OnFormClosing(object sender, FormClosingEventArgs formClosingEventArgs)
			{
			if (DataChangeWarning() == false)
				{
				//cancel the form close!
				formClosingEventArgs.Cancel = true;
				return;
				}
			UIManagerClass.UIManager.CloseChildScreen(UIManagerClass.ChildScreen.DataInputClassScreen);
			}

		/// <summary>
		/// If any of the BAB boxes are changed, we end up here
		/// </summary>
		private void OnBABInputChange(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				ArrayInputChange(sender, InputType.BAB);
			}

		/// <summary>
		/// If any of the Fort Save boxes are changed, we end up here
		/// </summary>
		private void OnFortSaveInputChange(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				ArrayInputChange(sender, InputType.FortSave);
			}

		/// <summary>
		/// If any of the Reflex Save boxes are changed, we end up here
		/// </summary>
		private void OnReflexSaveInputChange(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				ArrayInputChange(sender, InputType.ReflexSave);
			}

		/// <summary>
		/// If any of the Will Save boxes are changed, we end up here
		/// </summary>
		private void OnWillSaveInputChange(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				ArrayInputChange(sender, InputType.WillSave);
			}

		/// <summary>
		/// Here on class name change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClassNameInputChange(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				StringInputChange(sender, InputType.Name);
			}

		/// <summary>
		/// Here on hit dice change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHitDieInputChange(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				IntInputChange(sender, InputType.HitDie);
			}

		/// <summary>
		/// Here on class name abbreviatoin change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNameAbbreviationInputChange(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				StringInputChange(sender, InputType.Abbreviation);
			}

		/// <summary>
		/// Here on skill point change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSkillPointInputChange(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				IntInputChange(sender, InputType.SkillPoint);
			}

		/// <summary>
		/// Here on Icon Name change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnIconNameInputBoxChange(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				StringInputChange(sender, InputType.IconName);
			//reload the icon
			ClassIcon = new IconClass(Model.ImageFilename);
			ClassIcon.SetLocation(this.Width, this.Height, IconLocation);
			}

		/// <summary>
		/// save the current data
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUpdateButtonClick(object sender, EventArgs e)
			{
			SaveScreen();
			}

		/// <summary>
		/// Lose any changed data and just reload the screen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCancelButtonClick(object sender, EventArgs e)
			{
			PopulateFields(ClassNames[ClassListBox.SelectedIndex]);
			DataHasChanged = false;
			}

		private void OnPaint(object sender, PaintEventArgs paintEventArgs)
			{
			DrawIcon(paintEventArgs);
			}

		/// <summary>
		/// Handle the Icon browse button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClassIconBrowseButtonClick(object sender, EventArgs e)
			{
			string fileName;

			OpenFileDialog FileDialog = new OpenFileDialog();
			FileDialog.Filter = "Ping Files (*.png)|*.png";
			FileDialog.InitialDirectory = Application.StartupPath + "\\Graphics\\Classes\\";
			if (FileDialog.ShowDialog() == DialogResult.OK)
				{
				fileName = FileDialog.SafeFileName;
				//we only want the file name, not the extention
				fileName = fileName.Replace(".png", "");
				IconNameInputBox.Text = fileName;
				}
			}

		private void OnDescriptionEditButtonClick(object sender, EventArgs e)
			{
			DescriptionEditWindow = new TextEditWindow();
			DescriptionEditWindow.SetChangeEvent(OnDescriptionEditTextChange);
			DescriptionEditWindow.SetSaveEvent(OnDescriptionEditSaveButtonClick);
			DescriptionEditWindow.SetCancelEvent(OnDescriptionEditCancelButtonClick);
			DescriptionEditWindow.SetCloseEvent(OnDescriptionEditClose);
			DescriptionEditWindow.SetText(Model.Description);
			OldDescription = Model.Description;
			DescriptionEditWindow.Show(this);
			DescriptionEditWindow.Left = this.Left + ChildWindowLocation.X;
			DescriptionEditWindow.Top = this.Top + ChildWindowLocation.Y;

			}

		private void OnDescriptionEditTextChange(object sender, EventArgs e)
			{
			DescriptionPreview.DocumentText = DescriptionEditWindow.GetText();
			}

		private void OnDescriptionEditSaveButtonClick(object sender, EventArgs e)
			{
			DescriptionEditWindow.Close();
			}

		/// <summary>
		/// undo whatever changes we have made
		/// </summary>
		private void OnDescriptionEditCancelButtonClick(object sender, EventArgs e)
			{
			DescriptionPreview.Navigate("about:blank");
			DescriptionPreview.Document.OpenNew(false);
			DescriptionPreview.Document.Write(OldDescription);
			DescriptionPreview.Refresh();

			DescriptionEditWindow.Close();
			}

		/// <summary>
		/// presume this is the same as the user hitting the Save button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDescriptionEditClose(object sender, EventArgs e)
			{
			Model.Description = DescriptionPreview.DocumentText;
			DataHasChanged = true;
			}

		private void OnAlignmentEditButtonClick(object sender, EventArgs e)
			{
			List<AlignmentModel> alignments;

			//set up the window
			AlignmentEditWindow = new CheckedListBoxEditWindow();
			AlignmentEditWindow.SetSaveEvent(OnAlignmentEditSaveButtonClick);
			AlignmentEditWindow.SetCancelEvent(OnAlignmentEditCancelButtonClick);

			alignments = AlignmentModel.GetAll();

			foreach (AlignmentModel alignment in alignments)
				AlignmentEditWindow.AddCheckbox(alignment.Name, AlignmentsAllowedListBox.Items.Contains(alignment.Name));

			AlignmentEditWindow.Show(this);
			AlignmentEditWindow.Left = this.Left + ChildWindowLocation.X;
			AlignmentEditWindow.Top = this.Top + ChildWindowLocation.Y;
			}

		private void OnAlignmentEditSaveButtonClick(object sender, EventArgs e)
			{
			List<AlignmentModel> alignments;

			alignments = AlignmentModel.GetAll();

			Model.AllowedAlignments = new List<AlignmentModel>();
			for (int i = 0; i < alignments.Count; i++)
				{
				if (AlignmentEditWindow.GetCheckboxStatus(i) == true)
					Model.AllowedAlignments.Add(alignments[i]);
				}
			//update the allowed allignments list box
			AlignmentsAllowedListBox.Items.Clear();
			foreach (AlignmentModel alignment in Model.AllowedAlignments)
				AlignmentsAllowedListBox.Items.Add(alignment.Name);
			DataHasChanged = true;
			AlignmentEditWindow.Close();
			}

		/// <summary>
		/// undo whatever changes we have made
		/// </summary>
		private void OnAlignmentEditCancelButtonClick(object sender, EventArgs e)
			{
			AlignmentEditWindow.Close();
			}

		private void OnClassSkillEditButtonClick(object sender, EventArgs e)
			{
			List<SkillModel> skills;

			//set up the window
			SkillEditWindow = new CheckedListBoxEditWindow();
			SkillEditWindow.SetSaveEvent(OnSkillEditSaveButtonClick);
			SkillEditWindow.SetCancelEvent(OnSkillEditCancelButtonClick);

			skills = SkillModel.GetAll();

			foreach (SkillModel skill in skills)
				SkillEditWindow.AddCheckbox(skill.Name, ClassSkillsListBox.Items.Contains(skill.Name));

			SkillEditWindow.Show();
			SkillEditWindow.Left = this.Left + ChildWindowLocation.X;
			SkillEditWindow.Top = this.Top + ChildWindowLocation.Y;
			}

		private void OnSkillEditSaveButtonClick(object sender, EventArgs e)
			{
			List<SkillModel> skills;

			skills = SkillModel.GetAll();
			Model.ClassSkills = new List<SkillModel>();
			for (int i = 0; i < skills.Count; i++)
				{
				if (SkillEditWindow.GetCheckboxStatus(i) == true)
					Model.ClassSkills.Add(skills[i]);
				}
			//update the class skills list box
			ClassSkillsListBox.Items.Clear();
			foreach (SkillModel skill in Model.ClassSkills)
				ClassSkillsListBox.Items.Add(skill.Name);

			DataHasChanged = true;
			SkillEditWindow.Close();
			}

		/// <summary>
		/// undo whatever changes we have made
		/// </summary>
		private void OnSkillEditCancelButtonClick(object sender, EventArgs e)
			{
			SkillEditWindow.Close();
			}

		private void OnBonusFeatChoiceBoxSelection(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				ArrayComboBoxChange(sender, InputType.BonusFeat);
			}

		private void OnMaxSpellLevelComboBoxSelectedIndexChanged(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				ComboBoxChange(sender, InputType.MaxSpellLevel);
			}

		private void OnStartingDestinySphereComboBoxSelectionChange(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				ComboBoxChange(sender, InputType.DestinySphere);
			}

		private void OnRecordFilterBoxTextChanged(object sender, EventArgs e)
			{
			ClassListBox.Items.Clear();
			foreach (string name in ClassNames)
				{
				if (Regex.Match(name, RecordFilterBox.Text, RegexOptions.IgnoreCase).Success)
					ClassListBox.Items.Add(name);
				}
			}

		private void OnNewClassButtonClick(object sender, EventArgs e)
			{
			Model = new ClassModel();
			PopulateFields(Model.Name);
			AutoGrantedFeatsPanel.Clear();
			AutoGrantedFeatsPanel.Initialize("Class", Model.Id);
			}

		private void OnClassListBoxSelectedIndexChanged(object sender, EventArgs e)
			{
			if (ClassListBox.SelectedIndex == -1)
				return;
			if (DataChangeWarning() == false)
				return;
			Model = new ClassModel();
			Model.Initialize(ClassListBox.SelectedItem.ToString());
			PopulateFields(Model.Name);
			AutoGrantedFeatsPanel.Clear();
			AutoGrantedFeatsPanel.Initialize("Class", Model.Id);
			}

		private void OnDisplayOrderUpButtonClick(object sender, EventArgs e)
			{
			ClassModel priorModel;
			int saveSequence;
			int selected;

			if (ClassListBox.SelectedIndex == -1)
				return;

			AllowChangeEvents = false;

			if (SortDisplayOrderRadioButton.Checked)
				{
				//we are changing the display order
				priorModel = new ClassModel();
				priorModel.Initialize(Model.Sequence - 1);
				if (priorModel.Id != Guid.Empty)
					{
					saveSequence = Model.Sequence;
					Model.Sequence = priorModel.Sequence;
					priorModel.Sequence = 255;

					//swap sequences such that the database won't complain about duplicate entries
					priorModel.SaveSequence();
					Model.SaveSequence();
					priorModel.Sequence = saveSequence;
					priorModel.SaveSequence();

					ClassListBox.SelectedIndex--;

					//repopulate the class list (in case any of the names have changed or new ones added)
					selected = ClassListBox.SelectedIndex;
					ClassListBox.Items.Clear();
					ClassNames = ClassModel.GetNames(SortDisplayOrderRadioButton.Checked == true);
					foreach (string Name in ClassNames)
						ClassListBox.Items.Add(Name);
					ClassListBox.SelectedIndex = selected;
					}
				}
			else
				{
				//we are changing the reincarnation order
				priorModel = new ClassModel();
				priorModel.InitializeByReincarnationPriority(Model.ReincarnationPriority - 1);
				if (priorModel.Id != Guid.Empty)
					{
					saveSequence = Model.ReincarnationPriority;
					Model.ReincarnationPriority = priorModel.ReincarnationPriority;
					priorModel.ReincarnationPriority = 255;

					//swap sequences such that the database won't complain about duplicate entries
					priorModel.SaveReincarnationPriority();
					Model.SaveReincarnationPriority();
					priorModel.ReincarnationPriority = saveSequence;
					priorModel.SaveReincarnationPriority();

					ClassListBox.SelectedIndex--;

					//repopulate the class list (in case any of the names have changed or new ones added)
					selected = ClassListBox.SelectedIndex;
					ClassListBox.Items.Clear();
					ClassNames = ClassModel.GetNames(SortDisplayOrderRadioButton.Checked == true);
					foreach (string Name in ClassNames)
						ClassListBox.Items.Add(Name);
					ClassListBox.SelectedIndex = selected;
					}
				}
			AllowChangeEvents = true;
			}

		private void OnDisplayOrderDownButtonClick(object sender, EventArgs e)
			{
			ClassModel nextModel;
			int saveSequence;
			int selected;

			if (ClassListBox.SelectedIndex == -1)
				return;

			AllowChangeEvents = false;

			if (SortDisplayOrderRadioButton.Checked)
				{
				nextModel = new ClassModel();
				nextModel.Initialize(Model.Sequence + 1);
				if (nextModel.Id != Guid.Empty)
					{
					saveSequence = Model.Sequence;
					Model.Sequence = nextModel.Sequence;
					nextModel.Sequence = 255;

					//swap sequences such that the database won't complain about duplicate entries
					nextModel.SaveSequence();
					Model.SaveSequence();
					nextModel.Sequence = saveSequence;
					nextModel.SaveSequence();

					ClassListBox.SelectedIndex++;

					//repopulate the class list (in case any of the names have changed or new ones added)
					selected = ClassListBox.SelectedIndex;
					ClassListBox.Items.Clear();
					ClassNames = ClassModel.GetNames(SortDisplayOrderRadioButton.Checked == true);
					foreach (string Name in ClassNames)
						ClassListBox.Items.Add(Name);
					ClassListBox.SelectedIndex = selected;
					}
				}
			else
				{
				//we are changing the reincarnation order
				nextModel = new ClassModel();
				nextModel.InitializeByReincarnationPriority(Model.ReincarnationPriority + 1);
				if (nextModel.Id != Guid.Empty)
					{
					saveSequence = Model.ReincarnationPriority;
					Model.ReincarnationPriority = nextModel.ReincarnationPriority;
					nextModel.ReincarnationPriority = 255;

					//swap sequences such that the database won't complain about duplicate entries
					nextModel.SaveReincarnationPriority();
					Model.SaveReincarnationPriority();
					nextModel.ReincarnationPriority = saveSequence;
					nextModel.SaveReincarnationPriority();

					ClassListBox.SelectedIndex++;

					//repopulate the class list (in case any of the names have changed or new ones added)
					selected = ClassListBox.SelectedIndex;
					ClassListBox.Items.Clear();
					ClassNames = ClassModel.GetNames(SortDisplayOrderRadioButton.Checked == true);
					foreach (string Name in ClassNames)
						ClassListBox.Items.Add(Name);
					ClassListBox.SelectedIndex = selected;
					}
				}
			AllowChangeEvents = true;
			}

		private void OnDeleteRecordButtonClick(object sender, EventArgs e)
			{
			ClassModel nextModel;
			int selected;
			int nextSequence;

			if (DataDeleteWarning() == false)
				return;

			//fix the sequence numbers
			nextSequence = Model.Sequence+1;
			nextModel = new ClassModel();
			nextModel.Initialize(nextSequence);
			while (nextModel.Id != Guid.Empty)
				{
				nextModel.Sequence--;
				nextModel.SaveSequence();
				nextSequence++;
				nextModel = new ClassModel();
				nextModel.Initialize(nextSequence);
				}
			
			Model.Delete();

			//repopulate the class list
			selected = ClassListBox.SelectedIndex-1;
			if (selected < 0)
				selected = 0;
			ClassListBox.Items.Clear();
			ClassNames = ClassModel.GetNames(SortDisplayOrderRadioButton.Checked == true);
			foreach (string Name in ClassNames)
				ClassListBox.Items.Add(Name);
			ClassListBox.SelectedIndex = selected;
			}

		private void OnSortOrderRadioButtonCheckedChanged(object sender, EventArgs e)
			{
			string selected;

			AllowChangeEvents = false;

			//repopulate the class list
			selected = ClassListBox.SelectedItem.ToString();
			ClassListBox.Items.Clear();
			ClassNames = ClassModel.GetNames(SortDisplayOrderRadioButton.Checked == true);
			foreach (string Name in ClassNames)
				ClassListBox.Items.Add(Name);
			ClassListBox.SelectedItem = selected;

			if (SortDisplayOrderRadioButton.Checked)
				OrderLabel.Text = "Display Order";
			else
				OrderLabel.Text = "Reincarnation Order";

			AllowChangeEvents = true;
			}

		#endregion

		#region Private Methods
		/// <summary>
		/// Handle an input change on an arrayed input box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="Type"></param>
		private void ArrayInputChange(object sender, InputType Type)
			{
			TextBox changedBox;
			string boxIndexString;
			int boxIndex;
			string newValueString;
			int newValue;

			//extract the index value of the control sending this message
			changedBox = new TextBox();
			changedBox = sender as TextBox;
			boxIndexString = Regex.Match(changedBox.Name, @"\d+").Value;
			boxIndex = Int32.Parse(boxIndexString) - 1;

			//grab the new value (make sure it is a valid int and not some weird thing!)
			newValueString = Regex.Match(changedBox.Text, @"\d+").Value;
			if (newValueString.Length == 0)
				newValue = 0;
			else
				newValue = Int32.Parse(newValueString);

			switch (Type)
				{
				case InputType.BAB:
					{
					Model.LevelDetails[boxIndex].BaseAttackBonus = newValue;
					DataHasChanged = true;
					break;
					}
				case InputType.FortSave:
					{
					Model.LevelDetails[boxIndex].FortitudeSave = newValue;
					DataHasChanged = true;
					break;
					}
				case InputType.ReflexSave:
					{
					Model.LevelDetails[boxIndex].ReflexSave = newValue;
					DataHasChanged = true;
					break;
					}
				case InputType.WillSave:
					{
					Model.LevelDetails[boxIndex].WillSave = newValue;
					DataHasChanged = true;
					break;
					}
				default:
					{
					Debug.WriteLine("Error: Unknown Type in Array Input Change");
					break;
					}
				}
			}

		/// <summary>
		/// Handle an input change on a string input box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="Type"></param>
		private void StringInputChange(object sender, InputType Type)
			{
			string newValue;

			switch (Type)
				{
				case InputType.Name:
					{
					newValue = ClassNameInputBox.Text;
					if (newValue == DatabaseName || CheckForUniqueness(newValue, InputType.Name) == true)
						{
						Model.Name = newValue;
						ClassNameInputBox.BackColor = Color.White;
						SaveLabel.Text = "";
						break;
						}
					else
						{
						//Let the user know he needs to choose a new name.
						ClassNameInputBox.Text = DatabaseName;
						ClassNameInputBox.BackColor = Color.OrangeRed;
						SaveLabel.Text = "Error: Name is already taken, please choose another";
						SaveLabel.ForeColor = Color.Red;
						ClassNameInputBox.Focus();
						}
					DataHasChanged = true;
					break;
					}
				case InputType.Abbreviation:
					{
					Model.Abbreviation = ClassNameAbbreviationInputBox.Text;
					DataHasChanged = true;
					break;
					}
				case InputType.IconName:
					{
					Model.ImageFilename = IconNameInputBox.Text;
					DataHasChanged = true;
					break;
					}
				default:
					{
					Debug.WriteLine("Error: Unknown Type in String Input Change");
					break;
					}
				}
			DataHasChanged = true;
			}

		/// <summary>
		/// Handle an input change on an int input box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="Type"></param>
		private void IntInputChange(object sender, InputType Type)
			{
			TextBox changedBox; 
			string newValueString;
			int newValue;

			changedBox = new TextBox();
			changedBox = sender as TextBox;
			newValueString = Regex.Match(changedBox.Text, @"\d+").Value;
			if (newValueString.Length == 0)
				newValue = 0;
			else
				newValue = Int32.Parse(newValueString);

			switch (Type)
				{
				case InputType.HitDie:
					{
					Model.HitDie = newValue;
					DataHasChanged = true;
					break;
					}
				case InputType.SkillPoint:
					{
					Model.SkillPoints = newValue;
					DataHasChanged = true;
					break;
					}
				case InputType.ReincarnationPriority:
					{
					Model.ReincarnationPriority = newValue;
					DataHasChanged = true;
					break;
					}
				default:
					{
					Debug.WriteLine("Error: Unknown Type in Int Input Change");
					DataHasChanged = true;
					break;
					}
				}

			DataHasChanged = true;
			}

		private void ArrayComboBoxChange(object sender, InputType Type)
			{
			ComboBox changedBox;
			string boxIndexString;
			int boxIndex;
			string newValueString;
			FeatTypeModel modelofFeatType;

			//extract the index value of the control sending this message
			changedBox = new ComboBox();
			changedBox = sender as ComboBox;
			boxIndexString = Regex.Match(changedBox.Name, @"\d+").Value;
			boxIndex = Int32.Parse(boxIndexString) - 1;

			switch (Type)
				{
				case InputType.BonusFeat:
					{
					if (changedBox.SelectedIndex == 0)
						Model.LevelDetails[boxIndex].FeatTypeId = Guid.Empty;
					else
						{
						//grab the selection's guid
						newValueString = changedBox.SelectedItem.ToString();
						modelofFeatType = new FeatTypeModel();
						modelofFeatType.Initialize(newValueString);
						Model.LevelDetails[boxIndex].FeatTypeId = modelofFeatType.Id;
						}
					DataHasChanged = true;
					break;
					}
				default:
					{
					Debug.WriteLine("Error: Unknown Type in Array Combo Box Change");
					break;
					}
				}
			}

		private void ComboBoxChange(object sender, InputType Type)
			{
			string newValueString;
			DestinySphereModel modelofDestinyType;

			switch (Type)
				{
				case InputType.DestinySphere:
					{
					//grab the selection's guid
					newValueString = StartingDestinySphereComboBox.SelectedItem.ToString();
					modelofDestinyType = new DestinySphereModel();
					modelofDestinyType.Initialize(newValueString);
					Model.StartingDestinySphereId = modelofDestinyType.Id;
					DataHasChanged = true;
					break;
					}
				case InputType.MaxSpellLevel:
					{
					newValueString = MaxSpellLevelComboBox.SelectedItem.ToString();
					Model.MaxSpellLevel = Int32.Parse(newValueString);
					DataHasChanged = true;
					break;
					}
				default:
					{
					Debug.WriteLine("Error: Unknown Type in Combo Box Change");
					break;
					}
				}
			}

		/// <summary>
		/// for a given selected record, show its data in the appropriate fields
		/// </summary>
		/// <param name="recordName">The name of the record to show</param>
		private void PopulateFields(string recordName)
			{
			string controlName;
			ComboBox bonusFeatComboBox;
			FeatTypeModel featType;
			List<string> destinyName;
			DestinySphereModel currentDestiny;

			Model.Initialize(recordName);
			//cache the name and abbreviation strings for later comparisons
			DatabaseName = Model.Name;
			DatabaseAbbreviation = Model.Abbreviation;
			ClassNameInputBox.Text = Model.Name;
			DescriptionPreview.Navigate("about:blank");
			DescriptionPreview.Document.OpenNew(false);
			DescriptionPreview.Document.Write(Model.Description);
			DescriptionPreview.Refresh();
			HitDieInputBox.Text = Model.HitDie.ToString();
			ClassNameAbbreviationInputBox.Text = Model.Abbreviation;
			SkillPointsInputBox.Text = Model.SkillPoints.ToString();
			IconNameInputBox.Text = Model.ImageFilename;
			ClassIcon = new IconClass(Model.ImageFilename);
			ClassIcon.SetLocation(this.Width, this.Height, IconLocation);
			for (int i = 1; i <= Constant.NumHeroicLevels; i++)
				{
				controlName = "FortSaveInputBox" + i;
				Controls[controlName].Text = Model.LevelDetails[i - 1].FortitudeSave.ToString();
				controlName = "ReflexSaveInputBox" + i;
				Controls[controlName].Text = Model.LevelDetails[i - 1].ReflexSave.ToString();
				controlName = "WillSaveInputBox" + i;
				Controls[controlName].Text = Model.LevelDetails[i - 1].WillSave.ToString();
				controlName = "BABInputBox" + i;
				Controls[controlName].Text = Model.LevelDetails[i - 1].BaseAttackBonus.ToString();
				controlName = "BonusFeatComboBox" + i;
				bonusFeatComboBox = Controls[controlName] as ComboBox;
				if (Model.LevelDetails[i - 1].FeatTypeId == Guid.Empty)
					bonusFeatComboBox.SelectedIndex = 0;
				else
					{
					featType = new FeatTypeModel();
					featType.Initialize(Model.LevelDetails[i - 1].FeatTypeId);
					bonusFeatComboBox.SelectedIndex = bonusFeatComboBox.FindStringExact(featType.Name);
					}
				}
			AlignmentsAllowedListBox.Items.Clear();
			if (Model.AllowedAlignments != null)
				{
				foreach (AlignmentModel alignment in Model.AllowedAlignments)
					AlignmentsAllowedListBox.Items.Add(alignment.Name);
				}

			ClassSkillsListBox.Items.Clear();
			if (Model.ClassSkills != null)
				{
				foreach (SkillModel skill in Model.ClassSkills)
					ClassSkillsListBox.Items.Add(skill.Name);
				}

			RecordGUIDLabel.Text = Model.Id.ToString();
			ModDateLabel.Text = Model.LastUpdatedDate.ToString();
			ModVersionLabel.Text = Model.LastUpdatedVersion;

			destinyName = DestinySphereModel.GetNames();
			StartingDestinySphereComboBox.Items.Clear();
			foreach (string name in destinyName)
				StartingDestinySphereComboBox.Items.Add(name);

			MaxSpellLevelComboBox.Items.Clear();
			for (int i=0; i<=9; i++)
				MaxSpellLevelComboBox.Items.Add(i.ToString());
			MaxSpellLevelComboBox.SelectedIndex = Model.MaxSpellLevel;

			currentDestiny = new DestinySphereModel();
			currentDestiny.Initialize(Model.StartingDestinySphereId);
			StartingDestinySphereComboBox.SelectedIndex = StartingDestinySphereComboBox.FindStringExact(currentDestiny.Name);


			//make sure we haven't changed the data (Populating data from the database doesn't count as a change!)
			DataHasChanged = false;
			}

		/// <summary>
		/// Call this function before any action that might lose data (form close, new record, or load record)
		/// return true if the action should be allowed, or false if it should be cancelled
		/// </summary>
		private bool DataChangeWarning()
			{
			DialogResult result;

			if (!DataHasChanged)
				return true;

			result = MessageBox.Show("Warning: Data has been modified! Do you want to save your changes?", "Warning!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
			if (result == DialogResult.Cancel)
				return false;
			else if (result == DialogResult.Yes)
				{
				//save
				SaveScreen();
				return true;
				}
			else
				{
				//user answered No, I guess we really don't care about the changed data!
				DataHasChanged = false;
				return true;
				}
			}

		/// <summary>
		/// Save the data from the model into the database
		/// </summary>
		private void SaveScreen()
			{
			int selected;

			SaveLabel.ForeColor = Color.Green;
			SaveLabel.Text = "Saving Record...";
			SaveLabel.Refresh();

			Model.Save();

			//Autogranted feats
            AutoGrantedFeatsPanel.UpdateMainRecordId(Model.Id);
			AutoGrantedFeatsPanel.SaveAutoGrantedFeats();
			DataHasChanged = false;

			//repopulate the class list (in case any of the names have changed or new ones added)
			selected = ClassListBox.SelectedIndex;
			ClassListBox.Items.Clear();
			ClassNames = ClassModel.GetNames(SortDisplayOrderRadioButton.Checked == true);
			foreach (string Name in ClassNames)
				ClassListBox.Items.Add(Name);
			ClassListBox.SelectedIndex = selected;

			//update the modification fields
			ModDateLabel.Text = Model.LastUpdatedDate.ToString();
			ModVersionLabel.Text = Model.LastUpdatedVersion;

			//cache the name and abbreviation strings for later comparisons
			// (we have now updated the databse, so update these as well)
			DatabaseName = Model.Name;
			DatabaseAbbreviation = Model.Abbreviation;

			SaveLabel.ForeColor = Color.Green;
			SaveLabel.Text = "Record Saved";
			}

		/// <summary>
		/// Draw the class icon
		/// </summary>
		/// <param name="paintEventArgs"></param>
		private void DrawIcon(PaintEventArgs paintEventArgs)
			{
			ClassIcon.Draw(paintEventArgs);
			}

		/// <summary>
		/// Call this function before deleting a record
		/// return true if the delete should be allowed, or false if it should be cancelled
		/// </summary>
		private bool DataDeleteWarning()
			{
			DialogResult result;

			result = MessageBox.Show("Warning: Do you really want to delete this record?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			return (result == DialogResult.Yes);
			}

		private bool CheckForUniqueness(string newValue, InputType type)
			{
			switch (type)
				{
				case InputType.Name:
					{
					if (ClassModel.DoesNameExist(newValue) == true)
						return false;
					break;
					}
				case InputType.Abbreviation:
					{
					if (ClassModel.DoesAbbreviationExist(newValue) == true)
						return false;
					break;
					}
				}
			return true;
			}
		#endregion
		}
	}

