using DDOCharacterPlanner.Model;
using System;
using System.Collections.Generic;


namespace DDOCharacterPlanner.Data
    {
    public class FeatCategoryDataCollectionClass
        {
        #region Properties
        public SortedDictionary<Guid, FeatCategoryDataClass> FeatCategories
            {
            get;
            private set;
            }

        #endregion

        #region Constructors
        public FeatCategoryDataCollectionClass()
            {
            LoadFeatCategoryIds();
            }

        #endregion

        #region Private Members
        private void LoadFeatCategoryIds()
            {
            List<Guid> featCategoryIds;

            featCategoryIds = FeatCategoryModel.GetIds();
            FeatCategories = new SortedDictionary<Guid, FeatCategoryDataClass>();
            foreach (Guid id in featCategoryIds)
                {
                FeatCategories.Add(id, new FeatCategoryDataClass(id));
                }
            }

        #endregion
        }
    }
