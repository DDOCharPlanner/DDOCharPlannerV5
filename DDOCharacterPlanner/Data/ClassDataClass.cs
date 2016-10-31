using System;
using DDOCharacterPlanner.Model;
using System.Diagnostics;
using System.Collections.Generic;

namespace DDOCharacterPlanner.Data
	{
	public class ClassDataClass
		{
        #region Private Member Variables
        private bool IsLoaded;
        //private ClassModel Model;

        private Guid _classId;
        private string _description;
        private int _hitDie;
        private string _iconName;
        private Guid _startingDestinySphereId;
        private int _skillPoints;
        private string _abbreviation;
        private int _sequence;
        private Guid _pastLifeFeatId;
        private Guid _bonusSpellPointAbilityId;
        private Guid _bonusSpellDCAbilityId;
        private Guid _bonusSpellsAtLevelOneAbilityId;
        private int _maxSpellLevel;
        private int _reincarnationPriorty;
        private List<Guid> _allowedAlignments;
        private List<AutoGrantedFeatDataClass> _autoGrantedFeats;
        #endregion

		#region Properties
        public Guid ClassId
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _classId;
                }
            }

		public string Name
			{
			get;
			private set;
			}

		public string Description
			{
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _description;
                }
			}

		public int HitDie
			{
			get;
			private set;
			}

		public int SkillPoints
			{
			get;
			private set;
			}

        public int ReincrantionPriorty
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _reincarnationPriorty;
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

		public List<Guid> AllowedAlignment
		    {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _allowedAlignments;
                }
		
		    }   

		public ClassLevelDataClass[] LevelData
		{
			get;
			private set;
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

		#region Constructors
		public ClassDataClass()
			{
			//Model = new ClassModel();
			Name = null;
			IsLoaded = false;
			}

		public ClassDataClass(string name) : this()
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
            List<ClassBonusFeatModel> bonusClassFeats;
            ClassModel model;

            model = new ClassModel();
			model.Initialize(Name);
            _classId = model.Id;
            _description = model.Description;
            _hitDie = model.HitDie;
            _iconName = model.ImageFilename;
            _startingDestinySphereId = model.StartingDestinySphereId;
            _skillPoints = model.SkillPoints;
            _reincarnationPriorty = model.ReincarnationPriority;
            _abbreviation = model.Abbreviation;
            _sequence = model.Sequence;
            //TODO: Are these need, if so then we need to add them to the ClassModel.
            //_pastLifeFeatId = Model.PastLifeFeatId;
            //_bonusSpellPointAbilityId = Model.BonusSpellPointAbilityId;
            //_bonusSpellDCAbilityId = -Model.BonusSpellDCAbilityId;
            //_bonusSpellsAtLevelOneAbilityId = Model.BonusSpellsAtLevelOneAbilityId;
            _maxSpellLevel = model.MaxSpellLevel;
			
            //Allowed Alignments
            _allowedAlignments = new List<Guid>();
			for (int i=0; i<model.AllowedAlignments.Count; i++)
                _allowedAlignments.Add(model.AllowedAlignments[i].Id);

            //Class Level Details
            LevelData = Array.ConvertAll(model.LevelDetails, item => new ClassLevelDataClass(item));
            
            //Autogranted feats
            _autoGrantedFeats = new List<AutoGrantedFeatDataClass>();
            bonusClassFeats = ClassBonusFeatModel.GetAll(model.Id);
            foreach (ClassBonusFeatModel cfModel in bonusClassFeats)
                _autoGrantedFeats.Add(new AutoGrantedFeatDataClass(cfModel.FeatId, cfModel.Level, cfModel.HasPreRequirements));

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
