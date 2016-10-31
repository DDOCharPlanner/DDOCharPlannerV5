using DDOCharacterPlanner.Model;

using System;
using System.Collections.Generic;


namespace DDOCharacterPlanner.Data
    {
    public class CharacterLevelDataClass
        {
        #region Member Variables
        private bool IsLoaded;

        private Guid _characterId;
        private int _level;
        private int _hitPoints;
        private int _fortitudeSave;
        private int _reflexSave;
        private int _willSave;
        private int _baseAttackBonus;
        private Guid _featTypeId;
        private List<AutoGrantedFeatDataClass> _autoGrantedFeats;

        #endregion

        #region Properties
        public Guid CharacterId
            { get
                {
                if (IsLoaded == false)
                    LoadData();
                return _characterId;
                }
            }
        public int Level
            { get
                {
                if (IsLoaded == false)
                    LoadData();
                return _level;
                }
            }
        public int HitPoints
            { get
                {
                if (IsLoaded == false)
                    LoadData();
                return _hitPoints;
                }
            }
        public int FortitudeSave
            { get
                {
                if (IsLoaded == false)
                    LoadData();
                return _fortitudeSave;
                }
            }
        public int ReflexSave
            { get
                {
                if (IsLoaded == false)
                    LoadData();
                return _reflexSave;
                }
            }
        public int WillSave 
            { get
                {
                if (IsLoaded == false)
                    LoadData();
                return _willSave;
                }
            }
        public int BaseAttackBonus 
            { get
                {
                if (IsLoaded == false)
                    LoadData();
                return _baseAttackBonus;
                }
            }
        public Guid FeatTypeId 
            {get
                {
                if (IsLoaded == false)
                    LoadData();
                return _featTypeId;
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

        #region Constructors
        public CharacterLevelDataClass()
            {
            IsLoaded = false;
            }

        public CharacterLevelDataClass(int level)
            : this()
            {
            _level = level;
            }

        #endregion

        #region Private Methods
        /// <summary>
        /// Load the data for this CharacterLevel
        /// </summary>
        private void LoadData()
            {
            CharacterModel model;
            List<CharacterBonusFeatModel> bonusFeatModels;

            model = new CharacterModel();
            model.Intialize(_level);
            _characterId = model.Id;
            _hitPoints = model.HitPoints;
            _fortitudeSave = model.FortitudeSave;
            _reflexSave = model.ReflexSave;
            _willSave = model.WillSave;
            _baseAttackBonus = model.BaseAttackBonus;
            _featTypeId = model.FeatTypeId;

            _autoGrantedFeats = new List<AutoGrantedFeatDataClass>();
            bonusFeatModels = CharacterBonusFeatModel.GetAll();

            foreach (CharacterBonusFeatModel bfModel in bonusFeatModels)
                {
                if (bfModel.Level == _level)
                    _autoGrantedFeats.Add(new AutoGrantedFeatDataClass(bfModel.FeatId, bfModel.Level, bfModel.IgnorePreRequirements));
                }
            IsLoaded = true;
            }

        #endregion
        }
    }
