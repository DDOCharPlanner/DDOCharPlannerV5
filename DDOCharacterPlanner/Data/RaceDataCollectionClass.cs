using DDOCharacterPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDOCharacterPlanner.Data
	{
	public class RaceDataCollectionClass
		{
		#region Properties
		public List<string> RaceNames
			{
			get;
			private set;
			}

		public SortedDictionary<string, RaceDataClass> Races
			{
			get;
			private set;
			}
		#endregion

		#region Constructors
		public RaceDataCollectionClass()
			{
			LoadRaceName();
			}
		#endregion

		/// <summary>
		/// On initialization, preload the class names and set up an entry in the dictionary
		/// </summary>
		private void LoadRaceName()
			{
			RaceNames = RaceModel.GetNames();
			Races = new SortedDictionary<string, RaceDataClass>();
			foreach (string name in RaceNames)
				{
				Races.Add(name, new RaceDataClass(name));
				}
			}
		}
	}
