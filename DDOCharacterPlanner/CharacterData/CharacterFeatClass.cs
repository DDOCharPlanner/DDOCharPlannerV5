using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDOCharacterPlanner.CharacterData
    {
    public class CharacterFeatClass
        {
    


        #region Properties
        public Guid FeatId
            {
            get;
            set;
            }

        public int LevelTaken
            {
            get;
            set;
            }

        public Guid FeatTypeId
            {
            get;
            set;
            }

        #endregion

        #region Constructors
        public CharacterFeatClass()
            {
            FeatId = Guid.Empty;
            LevelTaken = 0;
            FeatTypeId = Guid.Empty;
            }

        #endregion
 
        }
    }
