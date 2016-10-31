using DDOCharacterPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDOCharacterPlanner.Data
    {
    public class FeatDataCollectionClass
        {
        #region Properties
        public List<string> FeatNames
            {
            get;
            private set;
            }

        public SortedDictionary<Guid, FeatDataClass> Feats
            {
            get;
            private set;
            }

        #endregion

        #region Constructors
        public FeatDataCollectionClass()
            {
            FeatNames = FeatModel.GetNames();
            LoadFeatIds();
            }

        #endregion

        #region Private Members
        /// <summary>
        /// On initialization, preload the feat ids adn set up an entry in the dictionary
        /// </summary>
        private void LoadFeatIds()
            {
            List<Guid> featIds;

            featIds = FeatModel.GetIds();
            Feats = new SortedDictionary<Guid, FeatDataClass>();
            foreach (Guid id in featIds)
                {
                Feats.Add(id, new FeatDataClass(id));
                }
            }
        #endregion

        #region Public Members
        /// <summary>
        /// Returns the feat ids of the feats belonging to a parent feat
        /// </summary>
        /// <param name="featId">FeatId of the parent feat</param>
        /// <returns>A Guid List of the feats belonging to the parent feat</returns>
        public List<Guid> GetSubfeats(Guid featId)
            {
            List<Guid> subFeats = new List<Guid>();

            subFeats = FeatModel.GetIdsFromParentFeatId(featId);
            return subFeats;
            }

        #endregion
        }
    }
