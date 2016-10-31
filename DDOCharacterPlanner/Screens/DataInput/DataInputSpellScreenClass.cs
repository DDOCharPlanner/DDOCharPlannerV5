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
	public partial class DataInputSpellScreenClass : Form
		{
		#region Enums
		enum InputType
			{
			SpellName,
			SpellSchool,
			SpellRange,
			Description,
			IconName,
			Component,
			MetamagicFeat,
			Target,
			Duration,
			SpellResistance,
			SavingThrow,
			SpellClass,
			SpellLevel,
			SpellCoolDown,
			SpellSP
			}
		#endregion

		#region Member Variables
		private SpellModel Model;
		private List<SpellDetailsModel> DetailModel;
		private List<string> SpellNames;
		private List<string> SpellSchoolNames;
		private List<string> ClassNames;
		private bool DataHasChanged;
		private bool AllowChangeEvents;
		private PointF IconLocation = new PointF(0.76f, 0.03f);
		private IconClass SpellIcon;
		private string DatabaseName;
		private Point ChildWindowLocation = new Point(450, 100);
		private TextEditWindow DescriptionEditWindow;
		private string OldDescription;
		private int[] SpellMaxLevelByClass;
		private List<ComboBox> SpellDetailClassComboBox;
		private List<ComboBox> SpellDetailLevelComboBox;
		private List<TextBox> SpellDetailCoolDownTextBox;
		private List<NumericUpDown> SpellDetailSPCostUpDownBox;
		private List<Button> SpellDetailDeleteButton;
		private int SpellDetailRecordCount;
		#endregion

		#region Constructors
		public DataInputSpellScreenClass()
			{
			AllowChangeEvents = false;
			InitializeComponent();

			Model = new SpellModel();
			DetailModel = new List<SpellDetailsModel>();
			SpellNames = new List<string>();
			SpellSchoolNames = new List<string>();
			ClassNames = new List<string>();

			//lists for spell detail controls
			SpellDetailClassComboBox = new List<ComboBox>();
			SpellDetailLevelComboBox = new List<ComboBox>();
			SpellDetailCoolDownTextBox = new List<TextBox>();
			SpellDetailSPCostUpDownBox = new List<NumericUpDown>();
			SpellDetailDeleteButton = new List<Button>();

			SpellMaxLevelByClass = ClassModel.GetMaxSpellLevels();

			PopulateSpellListBox();
			PopulateSpellSchoolComboBoxList();
			PopulateSpellClassComboBoxList();
			PopulateSpellLevelComboBoxList();

			SpellListBox.SelectedIndex = 0;
			PopulateFields(SpellNames[0]);
			DataHasChanged = false;
			AllowChangeEvents = true;

			SpellDetailRecordCount = 0;
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
			UIManagerClass.UIManager.CloseChildScreen(UIManagerClass.ChildScreen.DataInputSpellScreen);
			}

		private void OnUpdateButtonClick(object sender, EventArgs e)
			{
			SaveScreen();
			}

		private void OnNewSpellButtonClick(object sender, EventArgs e)
			{
			if (DataChangeWarning() == false)
				return;
			AllowChangeEvents = false;
			Model = new SpellModel();
			SpellListBox.SelectedIndex = -1;
			PopulateFields("");
			SpellNameInputBox.Focus();
			DataHasChanged = false;
			AllowChangeEvents = true;
			}

		private void OnSpellListBoxSelectedIndexChanged(object sender, EventArgs e)
			{
			if (DataChangeWarning() == false)
				return;
			AllowChangeEvents = false;
			Model = new SpellModel();
			DetailModel.Clear();
			if (SpellListBox.SelectedIndex != -1)
				{
				Model.Initialize(SpellListBox.SelectedItem.ToString());
				DetailModel = SpellDetailsModel.GetAll(Model.Id);
				}
			PopulateFields(Model.SpellName);
			AllowChangeEvents = true;
			}

		private void OnRecordFilterBoxTextChanged(object sender, EventArgs e)
			{
			SpellListBox.Items.Clear();
			foreach (string name in SpellNames)
				{
				if (Regex.Match(name, RecordFilterBox.Text, RegexOptions.IgnoreCase).Success)
					SpellListBox.Items.Add(name);
				}
			}

		private void OnSpellNameInputBoxLeave(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				TextBoxChange(sender, InputType.SpellName);
			}

		private void OnSpellSchoolComboBoxSelectedIndexChanged(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				ComboBoxChange(sender, InputType.SpellSchool);
			}

		private void OnRangeInputBoxSelectedIndexChanged(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				ComboBoxChange(sender, InputType.SpellRange);
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

		private void OnSpellIconInputBoxLeave(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				TextBoxChange(sender, InputType.IconName);
			}

		private void OnComponentCheckListBoxItemCheck(object sender, ItemCheckEventArgs e)
			{
			if (AllowChangeEvents == true)
				CheckBoxChange(sender, InputType.Component, e);
			}

		private void OnMetamagicFeatListBoxItemCheck(object sender, ItemCheckEventArgs e)
			{
			if (AllowChangeEvents == true)
				CheckBoxChange(sender, InputType.MetamagicFeat, e);
			}

		private void OnTargetCheckListBoxItemCheck(object sender, ItemCheckEventArgs e)
			{
			if (AllowChangeEvents == true)
				CheckBoxChange(sender, InputType.Target, e);
			}

		private void OnDurationInputTextBoxLeave(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				TextBoxChange(sender, InputType.Duration);
			}

		private void OnSavingThrowComboBoxSelectedIndexChanged(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				ComboBoxChange(sender, InputType.SavingThrow);
			}

		private void OnSpellResistanceComboBoxSelectedIndexChanged(object sender, EventArgs e)
			{
			if (AllowChangeEvents == true)
				ComboBoxChange(sender, InputType.SpellResistance);
			}

		private void OnClassSelectionComboBoxSelectedIndexChanged(object sender, EventArgs e)
			{
			PopulateSpellLevelComboBoxList();
			}

		private void OnClassAddButtonClick(object sender, EventArgs e)
			{
			//fill in the detail model
			DetailModel.Add(new SpellDetailsModel());
			DetailModel[DetailModel.Count - 1].SpellId = Model.Id;
			DetailModel[DetailModel.Count - 1].ClassId = ClassModel.GetIdFromName(ClassSelectionComboBox.SelectedItem.ToString());
			DetailModel[DetailModel.Count - 1].Level = Int32.Parse(LevelSelectionComboBox.SelectedItem.ToString());
			DetailModel[DetailModel.Count - 1].Cooldown = CooldownInputBox.Text;
			DetailModel[DetailModel.Count - 1].SPCost = (int)SPCostUpDown.Value;

			AddSpellDetailRecordUI(DetailModel[DetailModel.Count - 1]);

			DataHasChanged = true;
			}

		private void OnSpellDetailClassComboBoxSelectedChangeCommitted(object sender, EventArgs e)
			{
			ComboBoxArrayChange(sender, InputType.SpellClass);
			}

		private void OnSpellDetailLevelComboBoxSelectedChangeCommitted(object sender, EventArgs e)
			{
			ComboBoxArrayChange(sender, InputType.SpellLevel);
			}

		private void OnSpellDetailCoolDownTextBoxLeave(object sender, EventArgs e)
			{
			TextBoxArrayChange(sender, InputType.SpellCoolDown);
			}

		private void OnSpellDetailSPCostUpDownLeave(object sender, EventArgs e)
			{
			NumericUpDownArrayChange(sender, InputType.SpellSP);
			}

		private void OnSpellDetailDeleteButtonClick(object sender, EventArgs e)
			{
			Button button;
			string buttonIndexString;
			int buttonIndex;

			//extract the index value of the cotnrol sending this message
			button = new Button();
			button = (Button)sender;
			buttonIndexString = Regex.Match(button.Name, @"\d+").Value;
			buttonIndex = Int32.Parse(buttonIndexString);

			//delete this index
			DetailModel.RemoveAt(buttonIndex);

			//Delete/Remove Current Controls
			for (int i = 0; i < SpellDetailSubPanel.Controls.Count; i++)
				SpellDetailSubPanel.Controls[i].Dispose();
			SpellDetailSubPanel.Controls.Clear();
			SpellDetailClassComboBox.Clear();
			SpellDetailLevelComboBox.Clear();
			SpellDetailCoolDownTextBox.Clear();
			SpellDetailSPCostUpDownBox.Clear();
			SpellDetailDeleteButton.Clear();
			//reload the panel
			SpellDetailRecordCount = 0;
			foreach (SpellDetailsModel detail in DetailModel)
				AddSpellDetailRecordUI(detail);

			DataHasChanged = true;
			}

		private void OnCancelButtonClick(object sender, EventArgs e)
			{
			AllowChangeEvents = false;
			PopulateFields(SpellNames[SpellListBox.SelectedIndex]);
			DataHasChanged = false;
			AllowChangeEvents = true;
			}

		private void OnDeleteRecordButtonClick(object sender, EventArgs e)
			{
			int selected;

			if (DataDeleteWarning() == false)
				return;

			Model.Delete();

			//repopulate the spell list
			selected = SpellListBox.SelectedIndex - 1;
			if (selected < 0)
				selected = 0;
			SpellListBox.Items.Clear();
			SpellNames = SpellModel.GetNames();
			foreach (string name in SpellNames)
				SpellListBox.Items.Add(name);
			SpellListBox.SelectedIndex = selected;
			}

		private void OnDataInputSpellScreenClassPaint(object sender, PaintEventArgs paintEventArgs)
			{
			DrawIcon(paintEventArgs);
			}

		/// <summary>
		/// Handle the Icon browse button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSpellIconBrowseButtonClick(object sender, EventArgs e)
			{
			string fileName;

			OpenFileDialog FileDialog = new OpenFileDialog();
			FileDialog.Filter = "Ping Files (*.png)|*.png";
			FileDialog.InitialDirectory = Application.StartupPath + "\\Graphics\\Spells\\";
			if (FileDialog.ShowDialog() == DialogResult.OK)
				{
				fileName = FileDialog.SafeFileName;
				//we only want the file name, not the extention
				fileName = fileName.Replace(".png", "");
				SpellIconInputBox.Text = fileName;
				TextBoxChange(sender, InputType.IconName);
				}
			}

		private void OnDataInputSpellScreenClassClick(object sender, EventArgs e)
			{
			Point clientPoint = PointToClient(System.Windows.Forms.Cursor.Position);
			int x = clientPoint.X;
			int y = clientPoint.Y;

			Debug.WriteLine("Here: " + x + ", " + y);
			if (SpellIcon.IsOver(x, y) == true)
				Debug.WriteLine("Over Spell Icon");
			}
		#endregion

		#region Private Methods
		private void TextBoxChange(object sender, InputType type)
			{
			string newStringValue;

			switch (type)
				{
				case InputType.SpellName:
					{
					newStringValue = SpellNameInputBox.Text;
					if (newStringValue != Model.SpellName)
						{
						if (newStringValue == DatabaseName)
							{
							Model.SpellName = newStringValue;
							SpellNameInputBox.BackColor = Color.White;
							SaveFeedbackLabel.Text = "";
							break;
							}
						if (CheckForUniqueness(newStringValue, InputType.SpellName) == true)
							{
							Model.SpellName = newStringValue;
							DataHasChanged = true;
							SpellNameInputBox.BackColor = Color.White;
							SaveFeedbackLabel.Text = "";
							}
						else
							{
							//Let the user know he needs to choose a new name.
							AllowChangeEvents = false;
							SpellNameInputBox.Text = Model.SpellName;
							SpellNameInputBox.BackColor = Color.OrangeRed;
							SaveFeedbackLabel.Text = "Error: Name is already in use, please choose another";
							AllowChangeEvents = true;
							SpellNameInputBox.Focus();
							}
						}
					else
						{
						SpellNameInputBox.BackColor = Color.White;
						SaveFeedbackLabel.Text = "";
						}
					break;
					}
				case InputType.IconName:
					{
					Model.IconFilename = SpellIconInputBox.Text;
					SpellIcon = new IconClass("Spells\\" + Model.IconFilename);
					SpellIcon.SetLocation(this.Width, this.Height, IconLocation);
					//redraw the icon
					Invalidate();
					DataHasChanged = true;
					break;
					}
				case InputType.Duration:
					{
					Model.Duration = DurationInputTextBox.Text;
					DataHasChanged = true;
					break;
					}
				default:
					{
					Debug.WriteLine("Error: Unknown Type in Text Box Change");
					break;
					}
				}
			}

		private void ComboBoxChange(object sender, InputType Type)
			{
			string newValueString;

			switch (Type)
				{
				case InputType.SpellSchool:
					{
					//grab the selection's guid
					newValueString = SpellSchoolComboBox.SelectedItem.ToString();
					Model.SpellSchoolId = SpellSchoolModel.GetIdFromName(newValueString);
					DataHasChanged = true;
					break;
					}
				case InputType.SpellRange:
					{
					Model.SpellRange = RangeInputComboBox.SelectedItem.ToString();
					DataHasChanged = true;
					break;
					}
				case InputType.SavingThrow:
					{
					Model.SavingThrow = SavingThrowComboBox.SelectedItem.ToString();
					DataHasChanged = true;
					break;
					}
				case InputType.SpellResistance:
					{
					Model.SpellResistance = false;
					if (SpellResistanceComboBox.SelectedIndex == 1)
						Model.SpellResistance = true;
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
		/// Handle an input change on a checkbox input
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="Type"></param>
		private void CheckBoxChange(object sender, InputType type, ItemCheckEventArgs e)
			{
			ushort bitField;

			switch (type)
				{
				case InputType.Component:
					{
					bitField = 0;
					for (ushort i = 0; i < ComponentCheckListBox.Items.Count; i++)
						{
						if (ComponentCheckListBox.GetItemChecked(i))
							{
							bitField = (ushort)(bitField | (1 << i));
							}
						}
					if (e.NewValue == CheckState.Checked)
						bitField = (ushort)(bitField | (1 << e.Index));
					else
						bitField -= (ushort)(1 << e.Index);

					Model.SpellComponents = bitField;
					DataHasChanged = true;
					break;
					}
				case InputType.MetamagicFeat:
					{
					bitField = 0;
					for (ushort i = 0; i < MetamagicFeatCheckListBox.Items.Count; i++)
						{
						if (MetamagicFeatCheckListBox.GetItemChecked(i))
							{
							bitField = (ushort)(bitField | (1 << i));
							}
						}
					if (e.NewValue == CheckState.Checked)
						bitField = (ushort)(bitField | (1 << e.Index));
					else
						bitField -= (ushort)(1 << e.Index);

					Model.MetamagicFeats = bitField;
					DataHasChanged = true;
					break;
					}
				case InputType.Target:
					{
					bitField = 0;
					for (ushort i = 0; i < TargetCheckListBox.Items.Count; i++)
						{
						if (TargetCheckListBox.GetItemChecked(i))
							{
							bitField = (ushort)(bitField | (1 << i));
							}
						}
					if (e.NewValue == CheckState.Checked)
						bitField = (ushort)(bitField | (1 << e.Index));
					else
						bitField -= (ushort)(1 << e.Index);

					Model.Targets = bitField;
					DataHasChanged = true;
					break;
					}
				}
			}

		private void ComboBoxArrayChange(object sender, InputType type)
			{
			ComboBox changedBox;
			string boxIndexString;
			int boxIndex;
			string oldSelection = "";

			//extract the index value of the cotnrol sending this message
			changedBox = new ComboBox();
			changedBox = (ComboBox)sender;
			boxIndexString = Regex.Match(changedBox.Name, @"\d+").Value;
			boxIndex = Int32.Parse(boxIndexString);

			switch (type)
				{
				case InputType.SpellClass:
					{
					DetailModel[boxIndex].ClassId = ClassModel.GetIdFromName(changedBox.SelectedItem.ToString());
					//the class has changed, therefore we need to reset the level selection box
					if (SpellDetailLevelComboBox[boxIndex].SelectedIndex == -1)
						oldSelection = "";
					else
						oldSelection = SpellDetailLevelComboBox[boxIndex].SelectedItem.ToString();
					SpellDetailLevelComboBox[boxIndex].Items.Clear();
					for (int i = 1; i <= SpellMaxLevelByClass[changedBox.SelectedIndex]; i++)
						SpellDetailLevelComboBox[boxIndex].Items.Add(i.ToString());

					//return to our selected level if we can. If not, select level 1
					SpellDetailLevelComboBox[boxIndex].SelectedIndex = SpellDetailLevelComboBox[boxIndex].FindStringExact(oldSelection);
					if (SpellDetailLevelComboBox[boxIndex].SelectedIndex == -1)
						{
						if (SpellMaxLevelByClass[changedBox.SelectedIndex] > 0)
							SpellDetailLevelComboBox[boxIndex].SelectedIndex = 0;
						}
					break;
					}
				case InputType.SpellLevel:
					{
					DetailModel[boxIndex].Level = Int32.Parse(changedBox.SelectedItem.ToString());
					break;
					}
				}
			DataHasChanged = true;
			}

		private void TextBoxArrayChange(object sender, InputType type)
			{
			TextBox changedBox;
			string boxIndexString;
			int boxIndex;

			//extract the index value of the cotnrol sending this message
			changedBox = new TextBox();
			changedBox = (TextBox)sender;
			boxIndexString = Regex.Match(changedBox.Name, @"\d+").Value;
			boxIndex = Int32.Parse(boxIndexString);

			switch (type)
				{
				case InputType.SpellCoolDown:
					{
					DetailModel[boxIndex].Cooldown = changedBox.Text;
					break;
					}
				}

			DataHasChanged = true;
			}

		private void NumericUpDownArrayChange(object sender, InputType type)
			{
			NumericUpDown changedBox;
			string boxIndexString;
			int boxIndex;

			//extract the index value of the cotnrol sending this message
			changedBox = new NumericUpDown();
			changedBox = (NumericUpDown)sender;
			boxIndexString = Regex.Match(changedBox.Name, @"\d+").Value;
			boxIndex = Int32.Parse(boxIndexString);

			switch (type)
				{
				case InputType.SpellSP:
					{
					DetailModel[boxIndex].SPCost = (int)changedBox.Value;
					break;
					}
				}

			DataHasChanged = true;
			}

		private bool CheckForUniqueness(string newValue, InputType type)
			{
			switch (type)
				{
				case InputType.SpellName:
					{
					if (SpellModel.DoesNameExist(newValue) == true)
						return false;
					break;
					}
				}
			return true;
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
			Guid spellId;

			SaveFeedbackLabel.Text = "Saving Record...";
			SaveFeedbackLabel.Refresh();

			Model.Save();
			//clear the detail model in the database to make sure we save the correct data
			spellId = SpellModel.GetIdFromName(Model.SpellName);
			SpellDetailsModel.DeleteBySpell(spellId);
			for (int i = 0; i < DetailModel.Count; i++)
				{
				//note: It is possible the detail models don't yet have the correct spell ID. Make sure they do before saving
				DetailModel[i].SpellId = spellId;
				DetailModel[i].Save();
				}
			DataHasChanged = false;

			//repopulate the spell list (in case any of the names have changed or new ones added)
			PopulateSpellListBox();

			//update the modification fields
			ModDateLabel.Text = Model.LastUpdatedDate.ToString();
			ModVersionLabel.Text = Model.LastUpdatedVersion;

			SaveFeedbackLabel.Text = "Record Saved";

			DatabaseName = Model.SpellName;
			}

		private void PopulateFields(string recordName)
			{
			bool bitFlag;

			Model = new SpellModel();
			DetailModel = new List<SpellDetailsModel>();
			if (recordName != string.Empty)
				{
				Model.Initialize(recordName);
				DetailModel = SpellDetailsModel.GetAll(Model.Id);
				}

			//basic fields
			SpellNameInputBox.Text = Model.SpellName;
			SpellSchoolComboBox.SelectedItem = SpellSchoolModel.GetNameFromId(Model.SpellSchoolId);
			SpellIconInputBox.Text = Model.IconFilename;
			DescriptionPreview.Navigate("about:blank");
			DescriptionPreview.Document.OpenNew(false);
			DescriptionPreview.Document.Write(Model.Description);
			DescriptionPreview.Refresh();
			RangeInputComboBox.SelectedItem = Model.SpellRange;
			for (int i = 0; i < ComponentCheckListBox.Items.Count; i++)
				{
				bitFlag = ((Model.SpellComponents & (1 << i)) > 0);
				ComponentCheckListBox.SetItemChecked(i, bitFlag);
				}
			for (int i = 0; i < MetamagicFeatCheckListBox.Items.Count; i++)
				{
				bitFlag = ((Model.MetamagicFeats & (1 << i)) > 0);
				MetamagicFeatCheckListBox.SetItemChecked(i, bitFlag);
				}
			for (int i = 0; i < TargetCheckListBox.Items.Count; i++)
				{
				bitFlag = ((Model.Targets & (1 << i)) > 0);
				TargetCheckListBox.SetItemChecked(i, bitFlag);
				}
			DurationInputTextBox.Text = Model.Duration;
			SavingThrowComboBox.SelectedItem = Model.SavingThrow;
			if (Model.SpellResistance == true)
				SpellResistanceComboBox.SelectedItem = "Yes";
			else
				SpellResistanceComboBox.SelectedItem = "No";
			ModDateLabel.Text = Model.LastUpdatedDate.ToString();
			ModVersionLabel.Text = Model.LastUpdatedVersion;
			RecordGUIDLabel.Text = Model.Id.ToString();

			//the icon
			SpellIcon = new IconClass("Spells\\" + Model.IconFilename);
			SpellIcon.SetLocation(this.Width, this.Height, IconLocation);

			//the spell detail panel
			//Delete/Remove Current Controls
			for (int i = 0; i < SpellDetailSubPanel.Controls.Count; i++)
				SpellDetailSubPanel.Controls[i].Dispose();
			SpellDetailSubPanel.Controls.Clear();
			SpellDetailClassComboBox.Clear();
			SpellDetailLevelComboBox.Clear();
			SpellDetailCoolDownTextBox.Clear();
			SpellDetailSPCostUpDownBox.Clear();
			SpellDetailDeleteButton.Clear();
			//reload the panel
			SpellDetailRecordCount = 0;
			foreach (SpellDetailsModel detail in DetailModel)
				AddSpellDetailRecordUI(detail);

			DatabaseName = Model.SpellName;
			//invalidate the screen to make sure everything gets updated (icon, etc).
			Invalidate();
			}

		private void PopulateSpellListBox()
			{
			string currentSelection;

			if (SpellListBox.SelectedIndex == -1)
				currentSelection = "<none>";
			else
				currentSelection = SpellListBox.SelectedItem.ToString();
			SpellListBox.Items.Clear();
			SpellNames = SpellModel.GetNames();
			foreach (string name in SpellNames)
				SpellListBox.Items.Add(name);
			SpellListBox.SelectedIndex = SpellListBox.FindStringExact(currentSelection);
			}

		private void PopulateSpellSchoolComboBoxList()
			{
			SpellSchoolComboBox.Items.Clear();
			SpellSchoolNames = SpellSchoolModel.GetNames();
			foreach (string name in SpellSchoolNames)
				SpellSchoolComboBox.Items.Add(name);
			SpellSchoolComboBox.SelectedIndex = 0;
			}

		private void PopulateSpellClassComboBoxList()
			{
			ClassSelectionComboBox.Items.Clear();
			ClassNames = ClassModel.GetNames();
			foreach (string name in ClassNames)
				ClassSelectionComboBox.Items.Add(name);
			ClassSelectionComboBox.SelectedIndex = 0;
			}

		private void PopulateSpellLevelComboBoxList()
			{
			string oldSelection = "";

			//if we already have a level selected, try to preserve it
			if (LevelSelectionComboBox.SelectedIndex != -1)
				oldSelection = LevelSelectionComboBox.SelectedItem.ToString();

			//populate the box
			LevelSelectionComboBox.Items.Clear();
			for (int i = 1; i <= SpellMaxLevelByClass[ClassSelectionComboBox.SelectedIndex]; i++)
				LevelSelectionComboBox.Items.Add(i.ToString());

			//return to our selected level if we can. If not, select level 1
			LevelSelectionComboBox.SelectedIndex = LevelSelectionComboBox.FindStringExact(oldSelection);
			if (LevelSelectionComboBox.SelectedIndex == -1)
				{
				if (SpellMaxLevelByClass[ClassSelectionComboBox.SelectedIndex] > 0)
					LevelSelectionComboBox.SelectedIndex = 0;
				}

			//the Add button
			if (LevelSelectionComboBox.SelectedIndex == -1)
				ClassAddButton.Enabled = false;
			else
				ClassAddButton.Enabled = true;
			}

		private void AddSpellDetailRecordUI(SpellDetailsModel detail)
			{
			SpellDetailRecordCount++;

			//Lets add a new set of controls
			//Create the class combo box
			SpellDetailClassComboBox.Add(new ComboBox());
			SpellDetailSubPanel.Controls.Add(SpellDetailClassComboBox[SpellDetailRecordCount - 1]);
			SpellDetailClassComboBox[SpellDetailRecordCount - 1].Location = new Point(0, (SpellDetailRecordCount - 1) * 23);
			SpellDetailClassComboBox[SpellDetailRecordCount - 1].Name = "SpellDetailClassComboBox[" + (SpellDetailRecordCount - 1) + "]";
			SpellDetailClassComboBox[SpellDetailRecordCount - 1].Size = new Size(121, 21);
			SpellDetailClassComboBox[SpellDetailRecordCount - 1].DropDownStyle = ComboBoxStyle.DropDownList;
			SpellDetailClassComboBox[SpellDetailRecordCount - 1].SelectionChangeCommitted += new System.EventHandler(this.OnSpellDetailClassComboBoxSelectedChangeCommitted);
			foreach (string name in ClassNames)
				SpellDetailClassComboBox[SpellDetailRecordCount - 1].Items.Add(name);
			SpellDetailClassComboBox[SpellDetailRecordCount - 1].SelectedItem = ClassModel.GetNameFromId(detail.ClassId);

			//Create the level combo box
			SpellDetailLevelComboBox.Add(new ComboBox());
			SpellDetailSubPanel.Controls.Add(SpellDetailLevelComboBox[SpellDetailRecordCount - 1]);
			SpellDetailLevelComboBox[SpellDetailRecordCount - 1].Location = new Point(127, (SpellDetailRecordCount - 1) * 23);
			SpellDetailLevelComboBox[SpellDetailRecordCount - 1].Name = "SpellDetailLevelComboBox[" + (SpellDetailRecordCount - 1) + "]";
			SpellDetailLevelComboBox[SpellDetailRecordCount - 1].Size = new Size(40, 21);
			SpellDetailLevelComboBox[SpellDetailRecordCount - 1].DropDownStyle = ComboBoxStyle.DropDownList;
			SpellDetailLevelComboBox[SpellDetailRecordCount - 1].SelectionChangeCommitted += new System.EventHandler(this.OnSpellDetailLevelComboBoxSelectedChangeCommitted);
			for (int i = 1; i <= SpellMaxLevelByClass[SpellDetailClassComboBox[SpellDetailRecordCount - 1].SelectedIndex]; i++)
				SpellDetailLevelComboBox[SpellDetailRecordCount - 1].Items.Add(i.ToString());
			SpellDetailLevelComboBox[SpellDetailRecordCount - 1].SelectedItem = detail.Level.ToString();

			//Create the Cooldown numeric up/down box
			SpellDetailCoolDownTextBox.Add(new TextBox());
			SpellDetailSubPanel.Controls.Add(SpellDetailCoolDownTextBox[SpellDetailRecordCount - 1]);
			SpellDetailCoolDownTextBox[SpellDetailRecordCount - 1].Location = new Point(176, (SpellDetailRecordCount - 1) * 23);
			SpellDetailCoolDownTextBox[SpellDetailRecordCount - 1].Name = "SpellDetailCoolDownTextBox[" + (SpellDetailRecordCount - 1) + "]";
			SpellDetailCoolDownTextBox[SpellDetailRecordCount - 1].Size = new Size(73, 20);
			SpellDetailCoolDownTextBox[SpellDetailRecordCount - 1].Leave += new System.EventHandler(this.OnSpellDetailCoolDownTextBoxLeave);
			SpellDetailCoolDownTextBox[SpellDetailRecordCount - 1].Text = detail.Cooldown;

			//Create the SP Cost text box
			SpellDetailSPCostUpDownBox.Add(new NumericUpDown());
			SpellDetailSubPanel.Controls.Add(SpellDetailSPCostUpDownBox[SpellDetailRecordCount - 1]);
			SpellDetailSPCostUpDownBox[SpellDetailRecordCount - 1].Location = new Point(255, (SpellDetailRecordCount - 1) * 23);
			SpellDetailSPCostUpDownBox[SpellDetailRecordCount - 1].Name = "SpellDetailSPCostTextBox[" + (SpellDetailRecordCount - 1) + "]";
			SpellDetailSPCostUpDownBox[SpellDetailRecordCount - 1].Size = new Size(60, 20);
			SpellDetailSPCostUpDownBox[SpellDetailRecordCount - 1].Leave += new System.EventHandler(this.OnSpellDetailSPCostUpDownLeave);
			SpellDetailSPCostUpDownBox[SpellDetailRecordCount - 1].Value = detail.SPCost;

			//create the delete button
			SpellDetailDeleteButton.Add(new Button());
			SpellDetailSubPanel.Controls.Add(SpellDetailDeleteButton[SpellDetailRecordCount - 1]);
			SpellDetailDeleteButton[SpellDetailRecordCount - 1].Location = new Point(318, (SpellDetailRecordCount - 1) * 23);
			SpellDetailDeleteButton[SpellDetailRecordCount - 1].Name = "SpellDetailDeleteButton[" + (SpellDetailRecordCount - 1) + "]";
			SpellDetailDeleteButton[SpellDetailRecordCount - 1].Size = new Size(20, 20);
			SpellDetailDeleteButton[SpellDetailRecordCount - 1].Image = Properties.Resources.DeleteSmall;
			SpellDetailDeleteButton[SpellDetailRecordCount - 1].Click += new System.EventHandler(this.OnSpellDetailDeleteButtonClick);
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

		/// <summary>
		/// Draw the class icon
		/// </summary>
		/// <param name="paintEventArgs"></param>
		private void DrawIcon(PaintEventArgs paintEventArgs)
			{
			SpellIcon.Draw(paintEventArgs);
			}

		#endregion
		}
	}
