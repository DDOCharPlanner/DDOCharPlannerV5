using DDOCharacterPlanner.Model;
using System;
using System.Collections.Generic;


namespace DDOCharacterPlanner.Data
    {
    public class FeatDataClass
        {
        #region Memeber Variables
        private bool IsLoaded;

        private Guid _FeatId;
        private string _FeatName;
        private Guid _FeatCategoryId;
        private bool _isParentFeat;
        private Guid _parentFeatId;
        private string _iconName;
        private string _description;
        private bool _multiple;
        private string _duration;
        private Guid _stanceId;
        private List<Guid> _featTypeIds;

        #endregion

        #region Properties
        public Guid FeatId
            {
            get
                {
                return _FeatId;
                }
            }

        public string Name
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _FeatName;
                }
            }

        public Guid FeatCategoryId
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _FeatCategoryId;
                }
            }

        public bool IsParentFeat
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _isParentFeat;
                }
            }

        public Guid ParentFeatId
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _parentFeatId;
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

        public bool Multiple
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _multiple;
                }
            }

        public string Duration
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _duration;
                }
            }

        public Guid StanceId
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _stanceId;
                }
            }

        public List<Guid> FeatTypeIds
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _featTypeIds;
                }
            }

        #endregion

        #region Constructors
        public FeatDataClass()
            {
            IsLoaded = false;
            }

        public FeatDataClass(Guid featId)
            : this()
            {
            _FeatId = featId;
            }

        #endregion

        #region Private Members
        private void LoadData()
            {
            FeatModel model;

            model = new FeatModel();
            model.Initialize(_FeatId);
            _FeatName = model.Name;
            _FeatCategoryId = model.FeatCategoryId;
            _isParentFeat = model.IsParentFeat;
            _parentFeatId = model.ParentFeat;
            _iconName = model.ImageFileName;
            _description = model.Description;
            _multiple = model.Multiple;
            _duration = model.Duration;
            _stanceId = model.StanceId;
            _featTypeIds = FeatFeatTypeModel.GetIdsByFeatId(_FeatId);
            IsLoaded = true;
            }
        #endregion
        }
    }
