using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DDOCharacterPlanner.Model;

namespace DDOCharacterPlanner.Screens.DataInput
    {
    public partial class NewBonusTypeDialogClass : Form
        {
        #region Private Variables
        private Guid NewBonusTypeId;

        #endregion

        #region Properties
        public Guid BonusTypeId { get { return NewBonusTypeId; } }

        #endregion
        #region Constructor
        public NewBonusTypeDialogClass()
            {
            InitializeComponent();
            NewBonusTypeId = Guid.Empty;
            }

        #endregion

        #region Control Events
        private void NameTextBox_TextChanged(object sender, EventArgs e)
            {
            if (BonusTypeModel.GetIdFromName(NameTextBox.Text.ToString()) == Guid.Empty)
                {
                NameBorderPanel.BackColor = Color.Green;
                OkButton.Enabled = true;
                }
            else
                {
                NameBorderPanel.BackColor = Color.Red;
                OkButton.Enabled = false;
                }
            }

        private void OkButton_Click(object sender, EventArgs e)
            {
            AddBonusTypeRecord();
            Close();
            }
        #endregion

        #region Form Events
        #endregion

        #region Private Members
        private void AddBonusTypeRecord()
            {
            BonusTypeModel model;

            model = new BonusTypeModel();
            model.Initialize(Guid.Empty);

            model.Name = NameTextBox.Text;
            model.Save();
            NewBonusTypeId = model.Id;
            }

        #endregion
        }
    }
