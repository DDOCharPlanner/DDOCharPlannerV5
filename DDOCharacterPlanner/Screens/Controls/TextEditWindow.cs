using System;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.Controls
	{
	public partial class TextEditWindow : Form
		{
		#region Constructors
		public TextEditWindow()
			{
			InitializeComponent();
			}
		#endregion

		#region Public Methods
		public void SetChangeEvent(EventHandler routine)
			{
			TextInputBox.TextChanged += new EventHandler(routine);		
			}

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

		public void SetText(string text)
			{
			TextInputBox.Text = text;
			}

		public string GetText()
			{
			return TextInputBox.Text;
			}
		#endregion
		}
	}
