using System;
using DDOCharacterPlanner.Model;
using System.Diagnostics;

namespace DDOCharacterPlanner.Data
	{
	public class ClassLevelDataClass
		{
		#region Properties
		public int Level
			{
			get;
			private set;
			}

		public int FortitudeSave
			{
			get;
			private set;
			}

		public int ReflexSave
			{
			get;
			private set;
			}

		public int WillSave
			{
			get;
			private set;
			}

		public int BaseAttackBonus
			{
			get;
			private set;
			}
		#endregion

		#region Private Member Variables
		private bool IsLoaded;
		private ClassLevelDetailModel Model;
		#endregion

		#region Constructors
		public ClassLevelDataClass(ClassLevelDetailModel model)
			{
				Model = model;
				LoadData();
			}

		#endregion

		#region Private Methods
		/// <summary>
		/// Load the data for this class
		/// </summary>
		private void LoadData()
			{
				FortitudeSave = Model.FortitudeSave;
				ReflexSave = Model.ReflexSave;
				WillSave = Model.WillSave;
				BaseAttackBonus = Model.BaseAttackBonus;
				Level = Model.Level;
			IsLoaded = true;
			}
		#endregion
		}
	}
