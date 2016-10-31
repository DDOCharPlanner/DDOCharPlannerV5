using DDOCharacterPlanner.Model;
using DDOCharacterPlanner.Model.Tome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.DataInput
	{
	public partial class DataInputTomeScreenClass : Form
		{
		#region Member Variables
		private TomeModel Model;
		private bool DataHasChanged;
		private List<string> AbilityNames;
		private List<string> SkillNames;
		private List<string> TomeListNames;
		#endregion

		#region Constructor
		public DataInputTomeScreenClass()
			{
			InitializeComponent();

			Model = new TomeModel();

			//populate the list of abilty and skill names
			AbilityNames = AbilityModel.GetNames();
			SkillNames = SkillModel.GetNames();

			foreach (string Name in AbilityNames)
				ModifierListBox.Items.Add(Name);

			//populate the tome list box
			TomeListNames = TomeModel.GetNames();
			foreach (string Name in TomeListNames)
				TomeListBox.Items.Add(Name);
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
			UIManagerClass.UIManager.CloseChildScreen(UIManagerClass.ChildScreen.DataInputTomeScreen);
			}

		private void OnNewTomeButtonClick(object sender, System.EventArgs e)
			{
			Model = new TomeModel();
			ClearScreen();
			}

		private void OnTomeTypeAbilityRadioButtonCheckedChanged(object sender, System.EventArgs e)
			{
			ModifierListBox.Items.Clear();
			if (TomeTypeAbilityRadioButton.Checked == true)
				{
				foreach (string Name in AbilityNames)
					ModifierListBox.Items.Add(Name);
				Model.TomeType = "Ability";
				}
			else
				{
				foreach (string Name in SkillNames)
					ModifierListBox.Items.Add(Name);
				Model.TomeType = "Skill";
				}
			DataHasChanged = true;
			}

		private void OnModifierListBoxSelectedValueChanged(object sender, System.EventArgs e)
			{
			string modifiedName;

			modifiedName = ModifierListBox.Items[ModifierListBox.SelectedIndex].ToString();
			if (TomeTypeAbilityRadioButton.Checked == true)
				{
				Model.ModifiedID = AbilityModel.GetIdFromName(modifiedName);
				}
			else
				{
				Model.ModifiedID = SkillModel.GetIdFromName(modifiedName);
				}
			SetTomeLongName();
			DataHasChanged = true;
			}

		private void OnTomeNameInputBoxTextChanged(object sender, System.EventArgs e)
			{
			Model.TomeName = TomeNameInputBox.Text;
			SetTomeLongName();
			DataHasChanged = true;
			}

		private void OnTomeBonusInputValueChanged(object sender, System.EventArgs e)
			{
			Model.TomeBonus = (int)TomeBonusInput.Value;
			SetTomeLongName();
			DataHasChanged = true;
			}

		private void OnMinimumLevelInputUpDownValueChanged(object sender, System.EventArgs e)
			{
			Model.MinLevel = (int)MinimumLevelInputUpDown.Value;
			DataHasChanged = true;
			}

		private void OnUpdateButtonClick(object sender, System.EventArgs e)
			{
			SaveScreen();
			DataHasChanged = false;
			}

		private void OnDuplicateRecordButtonClick(object sender, System.EventArgs e)
			{
			TomeModel duplicateModel;
			int index, newIndex;

			SaveLabel.ForeColor = Color.Green;
			SaveLabel.Text = "Duplicating Record...";
			SaveLabel.Refresh();

			//save the current model (just in case the user has changed anything
			Model.Save();
			duplicateModel = new TomeModel();
			duplicateModel.MinLevel = Model.MinLevel;
			duplicateModel.ModifiedID = Model.ModifiedID;
			duplicateModel.TomeBonus = Model.TomeBonus;
			duplicateModel.TomeName = Model.TomeName;
			duplicateModel.TomeLongName = Model.TomeLongName;
			duplicateModel.TomeType = Model.TomeType;
			duplicateModel.Save();

			SaveLabel.ForeColor = Color.Green;
			SaveLabel.Text = "Record Duplicated";
			DataHasChanged = false;

			//populate the tome list box
			TomeListBox.Items.Clear();
			TomeListNames = TomeModel.GetNames();
			foreach (string Name in TomeListNames)
				TomeListBox.Items.Add(Name);

			//select the last instance of this name
			index = 0;
			newIndex = TomeListBox.FindStringExact(duplicateModel.TomeLongName);
			while (newIndex != ListBox.NoMatches && newIndex>=index)
				{
				index = newIndex;
				newIndex = TomeListBox.FindStringExact(duplicateModel.TomeLongName, index);
				}
			TomeListBox.SelectedIndex = index;
			}

		private void OnTomeListBoxSelectedIndexChanged(object sender, EventArgs e)
			{
			if (DataChangeWarning() == false)
				return;
			Model = new TomeModel();
			if (TomeListBox.SelectedIndex != -1)
				Model.Initialize(TomeListBox.SelectedItem.ToString());
			PopulateFields(Model.TomeLongName);
			}

		private void OnDeleteRecordButtonClick(object sender, EventArgs e)
			{
			int selected;

			if (DataDeleteWarning() == false)
				return;

			Model.Delete();

			//repopulate the tome list
			selected = TomeListBox.SelectedIndex - 1;
			if (selected < 0)
				selected = 0;
			TomeListBox.Items.Clear();
			TomeListNames = TomeModel.GetNames();
			foreach (string name in TomeListNames)
				TomeListBox.Items.Add(name);
			TomeListBox.SelectedIndex = selected;
			}

		private void OnCancelButtonClick(object sender, EventArgs e)
			{
			//reload the record
			PopulateFields(TomeListNames[TomeListBox.SelectedIndex]);
			DataHasChanged = false;
			}
		#endregion

		#region Private Methods
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
			SaveLabel.ForeColor = Color.Green;
			SaveLabel.Text = "Saving Record...";
			SaveLabel.Refresh();

			Model.Save();

			SaveLabel.ForeColor = Color.Green;
			SaveLabel.Text = "Record Saved";

			//populate the tome list box
			TomeListBox.Items.Clear();
			TomeListNames = TomeModel.GetNames();
			foreach (string Name in TomeListNames)
				TomeListBox.Items.Add(Name);
			}

		/// <summary>
		/// for a given selected record, show its data in the appropriate fields
		/// </summary>
		/// <param name="recordName">The name of the record to show</param>
		private void PopulateFields(string recordName)
			{
			int index;

			if (recordName == string.Empty)
				{
				ClearScreen();
				DataHasChanged = false;
				return;
				}

			Model.Initialize(recordName);

			TomeNameInputBox.Text = Model.TomeName;
			TomeBonusInput.Value = Model.TomeBonus;
			MinimumLevelInputUpDown.Value = Model.MinLevel;
			TomeNameLabel.Text = Model.TomeLongName;
			if (Model.TomeType == "Ability")
				{
				TomeTypeAbilityRadioButton.Checked = true;
				index = AbilityNames.IndexOf(AbilityModel.GetNameFromId(Model.ModifiedID));
				ModifierListBox.SetSelected(index, true);
				}
			else
				{
				TomeTypeSkillRadioButton.Checked = true;
				index = SkillNames.IndexOf(SkillModel.GetNameFromId(Model.ModifiedID));
				ModifierListBox.SetSelected(index, true);
				}

			ModVersionLabel.Text = Model.LastUpdatedVersion;
			ModDateLabel.Text = Model.LastUpdatedDate.ToString();
			RecordGUIDLabel.Text = Model.Id.ToString();

			//make sure we haven't changed the data (Populating data from the database doesn't count as a change!)
			DataHasChanged = false;
			}

		private void SetTomeLongName()
			{
			string name;
			string abilityName;

			name = TomeNameInputBox.Text;
			if (TomeTypeAbilityRadioButton.Checked == true)
				{
				if (ModifierListBox.SelectedIndex != -1)
					{
					name += " (";
					abilityName = ModifierListBox.Items[ModifierListBox.SelectedIndex].ToString();
					abilityName = abilityName.Substring(0, 3).ToUpper();
					name += abilityName;
					name += " +";
					name += TomeBonusInput.Value;
					name += ")";
					}
				}
			else
				{
				if (ModifierListBox.SelectedIndex != -1)
					{
					name += " (";
					name += ModifierListBox.Items[ModifierListBox.SelectedIndex].ToString();
					name += " +";
					name += TomeBonusInput.Value;
					name += ")";
					}
				}
			Model.TomeLongName = name;
			TomeNameLabel.Text = name;
			}

		private void ClearScreen()
			{
			TomeTypeAbilityRadioButton.Checked = true;
			TomeNameInputBox.Clear();
			TomeBonusInput.Value = 1;
			MinimumLevelInputUpDown.Value = 1;
			ModifierListBox.SelectedIndex = -1;
			TomeListBox.SelectedIndex = -1;
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
		#endregion



		}
	}
