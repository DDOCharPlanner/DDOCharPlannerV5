
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.UserSettings
	{
	public partial class SkinEditorScreenClass : Form
		{
		public SkinEditorScreenClass()
			{
			InitializeComponent();
			}

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
		#endregion

		#region Private Methods
		private bool DataChangeWarning()
			{
			return true;
			}
		#endregion
		}
	}
