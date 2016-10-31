using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.Model;

using System;
using System.Collections.Generic;


namespace DDOCharacterPlanner.Data
    {
    public class CharacterDataCollectionClass
        {
        #region Properties
        public List<int> Levels
            {
            get;
            private set;
            }

        public SortedDictionary<int, CharacterLevelDataClass> CharacterLevels
            {
            get;
            private set;
            }

        #endregion

        #region Constructors
        public CharacterDataCollectionClass()
            {
            LoadCharacterLevels();
            }

        #endregion

        #region Private Members
        private void LoadCharacterLevels()
            {
            CharacterLevels = new SortedDictionary<int, CharacterLevelDataClass>();
            for (int i = 1; i <= Utility.Constant.MaxLevels; i++)
                {
                CharacterLevels.Add(i, new CharacterLevelDataClass(i));
                }
            }

        #endregion

        #region Public Members
        public Dictionary<Guid, int> GetAutograntedFeats(int level)
            {
            Dictionary<Guid, int> featList;
            int count;

            featList = new Dictionary<Guid, int>();

            for (int i = 1; i <= level; i++)
                {
                for (int j = 0; j < CharacterLevels[i].AutoGrantedFeats.Count; j++)
                    {
                    if (featList.TryGetValue(CharacterLevels[i].AutoGrantedFeats[j].FeatId, out count))
                        featList[CharacterLevels[i].AutoGrantedFeats[j].FeatId] = count + 1;
                    else
                        featList.Add(CharacterLevels[i].AutoGrantedFeats[j].FeatId, 1);
                    }
                }

            return featList;
            }
        #endregion
        }
    }
