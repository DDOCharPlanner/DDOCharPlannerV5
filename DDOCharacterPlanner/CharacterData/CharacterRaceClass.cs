
using DDOCharacterPlanner.Data;

namespace DDOCharacterPlanner.CharacterData
	{
	public class CharacterRaceClass
        {
        #region Member Variables
        private bool _iconicRestrictions;
        #endregion

        #region Properties
        public int Race
			{
			get;
			private set;
			}

        public bool IconicRestrictions
            {
            get
                {
                return _iconicRestrictions;
                }
            set
                {
                _iconicRestrictions = value;
                }
            }
		#endregion

        #region Constructor
        public CharacterRaceClass()
            {
            Race = -1;
            }
        #endregion

        #region Public Methods
        public void UpdateRace(string RaceName)
			{
			for (int i=0; i<DataManagerClass.DataManager.RaceDataCollection.RaceNames.Count; i++)
				{
				if (RaceName == DataManagerClass.DataManager.RaceDataCollection.RaceNames[i])
					{
					Race = i;
					CharacterManagerClass.CharacterManager.CharacterAbility.UpdateRace(RaceName);
					return;
					}
				}
			}

		public string GetRaceName()
			{
            if (Race == -1)
                return "";


			return DataManagerClass.DataManager.RaceDataCollection.RaceNames[Race];
			}

		public bool IsRaceIconic()
			{
                if (Race == -1)
                    return false;

                return DataManagerClass.DataManager.RaceDataCollection.Races[DataManagerClass.DataManager.RaceDataCollection.RaceNames[Race]].IconicRace;
			}
		#endregion
		}
	}
