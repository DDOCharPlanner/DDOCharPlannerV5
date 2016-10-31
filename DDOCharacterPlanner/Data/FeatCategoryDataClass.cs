using DDOCharacterPlanner.Model;

using System;
using System.Collections.Generic;


namespace DDOCharacterPlanner.Data
    {
    public class FeatCategoryDataClass
        {
        #region Member Variables
        private bool IsLoaded;

        private Guid _id;
        private string _name;
        private string _description;
        private Guid _parentCategoryId;
        private string _iconName;

        #endregion

        #region Properties
        public Guid FeatCategoryId
            {
            get
                {
                return _id;
                }
            }

        public string Name
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _name;
                }
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

        public Guid ParentCategoryId
            {
            get
                {
                if (IsLoaded == false)
                    LoadData();
                return _parentCategoryId;
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

        #endregion

        #region Constructors
        public FeatCategoryDataClass()
            {
            IsLoaded = false;
            }

        public FeatCategoryDataClass(Guid featCategoryId)
            :this()
            {
            _id = featCategoryId;
            }

        #endregion

        #region Private Members
        private void LoadData()
            {
            FeatCategoryModel model = new FeatCategoryModel();

            model.Initialize(_id);
            _name = model.Name;
            _description = model.Description;
            _parentCategoryId = model.ParentFeatCategoryId;
            _iconName = model.IconName;
            IsLoaded = true;
            }

        #endregion
        }
    }
