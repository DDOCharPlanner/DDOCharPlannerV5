using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.Controls
	{
	public partial class CheckedListBoxEditWindow : Form
		{
		#region Constructor
		public CheckedListBoxEditWindow()
			{
			InitializeComponent();
			}
		#endregion

		#region Public Methods
		public void SetSaveEvent(EventHandler routine)
			{
			SaveButton.Click += new EventHandler(routine);
			}

		public void SetCancelEvent(EventHandler routine)
			{
			CancelButton.Click += new EventHandler(routine);
			}

		public void SetCloseEvent(FormClosingEventHandler routine)
			{
			this.FormClosing += new FormClosingEventHandler(routine);
			}

		public void AddCheckbox(string text, bool check)
			{
			checkedListBox.Items.Add(text);
			checkedListBox.SetItemChecked(checkedListBox.Items.Count-1, check);
			}

		public bool GetCheckboxStatus(int index)
			{
			return checkedListBox.GetItemChecked(index);
			}

		public void SetCheckboxStatus(int index, bool check)
			{
			checkedListBox.SetItemChecked(index, check);
			}

		public int GetItemCount()
			{
			return checkedListBox.Items.Count;
			}
		#endregion
		}
	}
