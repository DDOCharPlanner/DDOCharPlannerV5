using DDOCharacterPlanner.Model;
using System;
using System.Collections.Generic;


namespace DDOCharacterPlanner.Data
    {
    public class AutoGrantedFeatDataClass
        {
        #region Member Variables

        #endregion

        #region Properties
        public Guid FeatId
            {
            get;
            set;
            }

        public int LevelGranted
            {
            get;
            set;
            }

        public bool IgnoreRequirement
            {
            get;
            set;
            }

        #endregion

        #region Constructors
        public AutoGrantedFeatDataClass()
            {
            FeatId = Guid.Empty;
            LevelGranted = 0;
            IgnoreRequirement = true;
            }

        public AutoGrantedFeatDataClass(Guid featId, int levelGranted, bool ignoreRequirement)
            {
            FeatId = featId;
            LevelGranted = levelGranted;
            IgnoreRequirement = ignoreRequirement;
            }

        #endregion

        #region Private Methods
        #endregion

        }
    }
