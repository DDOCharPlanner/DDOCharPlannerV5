using DDOCharacterPlanner.Model;
using System;
using System.Collections.Generic;

namespace DDOCharacterPlanner.Data
	{
	public class RaceDataClass
        {
        #region Member Variables
        private string _iconName;
        private string _iconicStartingClass;
        private List<AutoGrantedFeatDataClass> _autoGrantedFeats;
        #endregion

        #region Properties
        public string Name
			{
			get;
			private set;
			}

		private string description;
		public string Description
			{
			get
				{
				if (IsLoaded == false)
					LoadData();
				return description;
				}
			private set
				{
				description = value;
				}
			}

		private List<int> baseAbility;
		public List<int> BaseAbility
			{
			get
				{
				if (IsLoaded == false)
					LoadData();
				return baseAbility;
				}
			private set
				{
				baseAbility = new List<int>();
				baseAbility = value;
				}
			}

		private List<int> baseAbilityMax;
		public List<int> BaseAbilityMax
			{
			get
				{
				if (IsLoaded == false)
					LoadData();
				return baseAbilityMax;
				}
			private set
				{
				baseAbilityMax = new List<int>();
				baseAbilityMax = value;
				}
			}

        private bool iconicRace;
        public bool IconicRace
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return iconicRace;
                }

            }
        public string IconName
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _iconName;
                }
            }

        public string IconicStartingClass
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _iconicStartingClass;
                }
            }

        public List<AutoGrantedFeatDataClass> AutoGrantedFeats
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _autoGrantedFeats;
                }
            }

		#endregion

		#region Private Member Variables
		private bool IsLoaded;
		private RaceModel Model;
		#endregion

		#region Constructors
		public RaceDataClass()
			{
			Model = new RaceModel();
			Name = null;
			IsLoaded = false;
			}

		public RaceDataClass(string name)
			: this()
			{
			Name = name;
			}
		#endregion

		#region Private Methods
		/// <summary>
		/// Load the data for this class
		/// </summary>
		private void LoadData()
			{
			List<int> values;
            List<RaceBonusFeatModel> bonusRaceFeats;

			Model.Initialize(Name);
			Description = Model.Description;
			values = new List<int>();
			values.Add(Model.StrengthMinimum);
			values.Add(Model.DexterityMinimum);
			values.Add(Model.ConstitutionMinimum);
			values.Add(Model.IntelligenceMinimum);
			values.Add(Model.WisdomMinimum);
			values.Add(Model.CharismaMinimum);
			BaseAbility = values;
			values = new List<int>();
			values.Add(Model.StrengthMaximum);
			values.Add(Model.DexterityMaximum);
			values.Add(Model.ConstitutionMaximum);
			values.Add(Model.IntelligenceMaximum);
			values.Add(Model.WisdomMaximum);
			values.Add(Model.CharismaMaximum);
			BaseAbilityMax = values;
            iconicRace = Model.Iconic;
            _iconName = Model.MaleImageFileName;
            _iconicStartingClass = DataManagerClass.DataManager.ClassDataCollection.GetClassName(Model.StartingClassId);

            _autoGrantedFeats = new List<AutoGrantedFeatDataClass>();
            bonusRaceFeats = RaceBonusFeatModel.GetAll(Model.Id);

            foreach (RaceBonusFeatModel rfModel in bonusRaceFeats)
                _autoGrantedFeats.Add(new AutoGrantedFeatDataClass(rfModel.FeatId, rfModel.Level, rfModel.HasPreRequirements));
                
			IsLoaded = true;
			}
		#endregion

        #region Public Methods
        public Dictionary<Guid, int> GetAutograntedFeats(int level)
            {
            Dictionary<Guid, int> featList;
            int count;

            featList = new Dictionary<Guid, int>();

            for (int i = 0; i < AutoGrantedFeats.Count; i++)
                {
                if (AutoGrantedFeats[i].LevelGranted <= level)
                    {
                    if (featList.TryGetValue(AutoGrantedFeats[i].FeatId, out count))
                        featList[AutoGrantedFeats[i].FeatId] = count + 1;
                    else
                        featList.Add(AutoGrantedFeats[i].FeatId, 1);
                    }
                }

            return featList;
            }
        #endregion
        }
	}
