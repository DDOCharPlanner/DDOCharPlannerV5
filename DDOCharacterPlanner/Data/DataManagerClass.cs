using System;
using System.Collections.Generic;

namespace DDOCharacterPlanner.Data
	{
	public sealed class DataManagerClass
		{
		#region Singleton Pattern
		private static readonly DataManagerClass dataManager = new DataManagerClass();
		private DataManagerClass() { }
		public static DataManagerClass DataManager
			{
			get { return dataManager; }
			}
		#endregion

		#region Properties
		public RaceDataCollectionClass RaceDataCollection
			{
			get;
			private set;
			}
		public ClassDataCollectionClass ClassDataCollection
			{
			get;
			private set;
			}

        public CharacterDataCollectionClass CharacterDataCollection
            {
            get;
            private set;
            }

        public FeatDataCollectionClass FeatDataCollection
            {
            get;
            private set;
            }

        public FeatCategoryDataCollectionClass FeatCategoryDataCollection
            {
            get;
            private set;
            }
        public AlignmentDataClass AlignmentData
        {
            get;
            private set;
        }

		#endregion

		#region Member Variables
		#endregion

		#region Public Methods
		public void InitializeDataDictionaries()
			{
			RaceDataCollection = new RaceDataCollectionClass();
			ClassDataCollection = new ClassDataCollectionClass();
            CharacterDataCollection = new CharacterDataCollectionClass();
            FeatDataCollection = new FeatDataCollectionClass();
            FeatCategoryDataCollection = new FeatCategoryDataCollectionClass();
            AlignmentData = new AlignmentDataClass();
            
			}
		#endregion
		}
	}