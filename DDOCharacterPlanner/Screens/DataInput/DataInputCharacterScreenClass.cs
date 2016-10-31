using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;

using DDOCharacterPlanner.Model;
using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Screens.DataInput
	{
	public partial class DataInputCharacterScreenClass : Form
        {
        #region Enums
        private enum InputType
            {
            BaseAttackBonus,
            FortitudeSave,
            ReflexSave,
            WillSave,
            HitPoints,
            FeatType
            };
        #endregion

        #region Member Variables
        private CharacterModel Model;
        private CharacterModel[] ModelofCharacter;
        private List<byte> CharacterLevels;
        private bool[] LevelDataHasChanged;
        private TextBox HitPointsInputBox;
        private TextBox FortitudeSaveInputBox;
        private TextBox ReflexSaveInputBox;
        private TextBox WillSaveInputBox;
        private TextBox BaseAttackBonusInputBox;
        private ComboBox BonusFeatTypeCombo;
        private string ControlName;
        private FeatTypeModel ModelofFeatType;
        private List<string> FeatTypeNames;
        
        #endregion

        #region Form Events
        private void OnFormClosing(object sender, FormClosingEventArgs e)
            {
            if (DataChangeWarning() == false)
                {
                //cancel the form close!
                e.Cancel = true;
                 return;
                }
            UIManagerClass.UIManager.CloseChildScreen(UIManagerClass.ChildScreen.DataInputCharacterScreen);
            }

        private void OnKeyPressIntOnlyTextBoxes(object sender, KeyPressEventArgs e)
            {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            }

        private void onBaseAttackBonusInputBoxLeave(object sender, EventArgs e)
            {
            InputBoxChange(sender, InputType.BaseAttackBonus);
            }

        private void OnBonusFeatComboBoxSelectedChangeCommitted(object sender, EventArgs e)
            {
            ComboBoxChange(sender);
            }

        private void OnFortitudeSaveInputboxLeave(object sender, EventArgs e)
            {
            InputBoxChange(sender, InputType.FortitudeSave);
            }

        private void OnHitPointsInputBoxLeave(object sender, EventArgs e)
            {
            InputBoxChange(sender, InputType.HitPoints);
            }

        private void OnReflexSaveInputBoxLeave(object sender, EventArgs e)
            {
            InputBoxChange(sender, InputType.ReflexSave);
            }

        private void OnWillSaveInputBoxLeave(object sender, EventArgs e)
            {
            InputBoxChange(sender, InputType.WillSave);
            }

        private void onUpdateButtonClick(object sender, EventArgs e)
            {
            if (HasDataChanged() == true || autoGrantedFeatsPanel1.HasAutoGrantedFeatsChanged() == true)
                {
                if (HasDataChanged() == true)
                    SaveScreen();
                if (autoGrantedFeatsPanel1.HasAutoGrantedFeatsChanged() == true)
                    autoGrantedFeatsPanel1.SaveAutoGrantedFeats();
                }
            }

        #endregion

        #region Private Methods
        /// <summary>
        /// Populate the fields with the appropriate Character data.
        /// </summary>
        private void PopulateFields()
            {
            string featTypeName;

            for (int i = 1; i <= Constant.MaxLevels; i++)
                {
                featTypeName = "";
 
                ControlName = "HitPointsInputBox" + i;
                HitPointsInputBox = (TextBox)this.Controls[ControlName];
                HitPointsInputBox.Text = ModelofCharacter[i-1].HitPoints.ToString();

                ControlName = "FortitudeSave" + i + "InputBox";
                FortitudeSaveInputBox = (TextBox)this.Controls[ControlName];
                FortitudeSaveInputBox.Text = ModelofCharacter[i - 1].FortitudeSave.ToString();

                ControlName = "ReflexSaveInputBox" + i;
                ReflexSaveInputBox = (TextBox)this.Controls[ControlName];
                ReflexSaveInputBox.Text = ModelofCharacter[i - 1].ReflexSave.ToString();

                ControlName = "WillSaveInputBox" + i;
                WillSaveInputBox = (TextBox)this.Controls[ControlName];
                WillSaveInputBox.Text = ModelofCharacter[i - 1].WillSave.ToString();

                ControlName = "BaseAttackBonusInputbox" + i;
                BaseAttackBonusInputBox = (TextBox)this.Controls[ControlName];
                BaseAttackBonusInputBox.Text = ModelofCharacter[i - 1].BaseAttackBonus.ToString();

                ControlName = "BonusFeatCombo" + i;
                ModelofFeatType = new FeatTypeModel();
                ModelofFeatType.Initialize(ModelofCharacter[i-1].FeatTypeId);
                BonusFeatTypeCombo = (ComboBox)this.Controls[ControlName];
                if (ModelofFeatType.Name != null)
                    {
                    featTypeName = ModelofFeatType.Name.ToString();
                    if (featTypeName != "")
                        {
                        BonusFeatTypeCombo.SelectedItem = ModelofFeatType.Name.ToString();
                        }
                    }

                //Need to set these to false since we are just populating the fields and haven't changed that data.
                LevelDataHasChanged[i - 1] = false;
                }
            }

        private void PopulateFeatTypeChoiceList()
            {
            for (int i = 1; i <= Constant.MaxLevels; i++)
                {
                ControlName = "BonusFeatCombo" + i;
                BonusFeatTypeCombo = (ComboBox)this.Controls[ControlName];
                BonusFeatTypeCombo.Items.Add("");
                foreach (string Name in FeatTypeNames)
                    BonusFeatTypeCombo.Items.Add(Name);
                }
            }

        private void ComboBoxChange(object sender)
            {
            ComboBox changedBox;
            string boxIndexString;
            int boxIndex;
            string newValueString;
            Guid newValue;

            //extract the index value of the control sending this message
            changedBox = new ComboBox();
            changedBox = (ComboBox)sender;
            boxIndexString = Regex.Match(changedBox.Name, @"\d+").Value;
            boxIndex = Int32.Parse(boxIndexString) - 1;

            //grab the new value
            //newValueString = Regex.Match(changedBox.SelectedItem, @"\d+").Value;
            newValueString = changedBox.SelectedItem.ToString();
            ModelofFeatType = new FeatTypeModel();
            ModelofFeatType.Initialize(newValueString);
            newValue = ModelofFeatType.Id;

            if (newValue != ModelofCharacter[boxIndex].FeatTypeId)
                {
                ModelofCharacter[boxIndex].FeatTypeId = newValue;
                LevelDataHasChanged[boxIndex] = true;
                }
            }

        /// <summary>
        /// Handle an input change on any of the input boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Type"></param>
        private void InputBoxChange(object sender, InputType Type)
            {
            TextBox changedBox;
            string boxIndexString;
            int boxIndex;
            string newValueString;
            int newValue;

            //extract the index value of the control sending this message
            changedBox = new TextBox();
            changedBox = (TextBox)sender;
            boxIndexString = Regex.Match(changedBox.Name, @"\d+").Value;
            boxIndex = Int32.Parse(boxIndexString) - 1;

            //grab the new value (make sure its a valid int and not some wierd thing!)
            newValueString = Regex.Match(changedBox.Text, @"\d+").Value;
            if (newValueString.Length == 0)
                newValue = 0;
            else
                newValue = Int32.Parse(newValueString);

            switch (Type)
                {
                case InputType.BaseAttackBonus:
                        {
                        if (newValue != ModelofCharacter[boxIndex].BaseAttackBonus)
                            {
                            ModelofCharacter[boxIndex].BaseAttackBonus = newValue;
                            LevelDataHasChanged[boxIndex] = true;
                            }
                        break;
                        }
                case InputType.FortitudeSave:
                        {
                        if (newValue != ModelofCharacter[boxIndex].FortitudeSave)
                            {
                            ModelofCharacter[boxIndex].FortitudeSave = newValue;
                            LevelDataHasChanged[boxIndex] = true;
                            }
                        break;
                        }
                case InputType.HitPoints:
                        {
                        if (newValue != ModelofCharacter[boxIndex].HitPoints)
                            {
                            ModelofCharacter[boxIndex].HitPoints = newValue;
                            LevelDataHasChanged[boxIndex] = true;
                            }
                        break;
                        }
                case InputType.ReflexSave:
                        {
                        if (newValue != ModelofCharacter[boxIndex].ReflexSave)
                            {
                            ModelofCharacter[boxIndex].ReflexSave = newValue;
                            LevelDataHasChanged[boxIndex] = true;
                            }
                        break;
                        }
                case InputType.WillSave:
                        {
                        if (newValue != ModelofCharacter[boxIndex].WillSave)
                            {
                            ModelofCharacter[boxIndex].WillSave = newValue;
                            LevelDataHasChanged[boxIndex] = true;
                            }
                        break;
                        }
                default:
                        {
                        Debug.WriteLine("Error: Unknown Type in Int Input Change");
                        break;
                        }
                }
            }

        /// <summary>
        /// Call this function before any action that might lose data (form close, new record, or load record)
        /// return true if the action should be allowed, or false if it should be cancelled
        /// </summary>
        /// <returns></returns>
        private bool DataChangeWarning()
            {
            DialogResult result;

            if (HasDataChanged() == false && autoGrantedFeatsPanel1.HasAutoGrantedFeatsChanged() == false)
                return true;

            result = MessageBox.Show("Warning: Data has been modified! Do you want to save your changes?", "Warning!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Cancel)
                return false;
            else if (result == DialogResult.Yes)
                {
                //save
                if (HasDataChanged() == true)
                    SaveScreen();
                if (autoGrantedFeatsPanel1.HasAutoGrantedFeatsChanged() == true)
                    autoGrantedFeatsPanel1.SaveAutoGrantedFeats();
                return true;
                }
            else
                {
                //user answered No, I guess we really don't care about the changed data!
                return true;
                }
            }

        /// <summary>
        /// Call this member to see if any data has been changed on the screen
        /// </summary>
        /// <returns>Return true is data has been changed, otherwise it return false </returns>
        private bool HasDataChanged()
            {
            for (int i = 0; i < Constant.MaxLevels; i++)
                {
                if (LevelDataHasChanged[i] == true)
                    return true;
                }
            //no data has changed on the screen so return false
            return false;
            }

        /// <summary>
        /// Save the data from the model into the database
        /// </summary>
        private void SaveScreen()
            {
            for (int i = 0; i < Constant.MaxLevels; i++)
                {
                if (LevelDataHasChanged[i])
                    {
                    ModelofCharacter[i].Save();
                    LevelDataHasChanged[i] = false;
                    }
                }
            }
        #endregion

        #region Constructor
        public DataInputCharacterScreenClass()
			{
			InitializeComponent();
            Model = new CharacterModel();
            ModelofCharacter = new CharacterModel[Constant.MaxLevels];
            ModelofFeatType = new FeatTypeModel();
            FeatTypeNames = FeatTypeModel.GetNames();

            CharacterLevels = CharacterModel.GetLevels();

            LevelDataHasChanged = new bool[Constant.MaxLevels];
            for (int i = 1; i <= Constant.MaxLevels; i++)
                {
                ModelofCharacter[i - 1] = new CharacterModel();
                ModelofCharacter[i - 1].Intialize(i);
                }

            PopulateFeatTypeChoiceList();
            PopulateFields();

            autoGrantedFeatsPanel1.Initialize("Character", Guid.Empty);

            for (int i = 0; i<Constant.MaxLevels; i++)
                LevelDataHasChanged[i] = false;
            }
        #endregion

        }
	}
