using System.Text;
using DDOCharacterPlanner.Data;
using DDOCharacterPlanner.Utility;
using System;
using System.Collections.Generic;
using DDOCharacterPlanner.Model;

namespace DDOCharacterPlanner.CharacterData
{
    public class CharacterPastLifeClass
    {
        #region Properties
        public int NumHeroic
        {
            get;
            private set;
        }
        public int NumIconic
        {
            get;
            private set;
        }
        public int NumEpic
        {
            get;
            private set;
        }
        public List<string> HeroicNames
        {
            get;
            private set;
        }

        public List<string> IconicNames
        {
            get;
            private set;
        }

        public List<string> EpicName
        {
            get;
            private set;
        }

        public int[] PastLifeHerioc
        {
            get;
            private set;
        }
        public int[] PastLifeIconic
        {
            get;
            private set;
        }
        public int[] PastLifeEpic
        {
            get;
            private set;
        }

        #endregion



        #region Constructors
        public CharacterPastLifeClass()
        {
            NumHeroic = ClassModel.GetNumClasses();
            NumIconic = RaceModel.GetNumIconic();
            PastLifeHerioc = new int[NumHeroic];
            PastLifeIconic = new int[NumIconic];
            //TODO: Epic Lives when destiny is done
            //NumEpic = 
            HeroicNames = ClassModel.GetNames();
            IconicNames = RaceModel.GetIconicNames();
            //TODO: Epic Lives when destiny is done
            //EpicNames = 
            for (int i = 0; i < NumHeroic; ++i)
            {
                PastLifeHerioc[i] = 0;
            }
                
            for (int i = 0; i < NumIconic; ++i)
            {
                PastLifeIconic[i] = 0;
            }
                
            //TODO:Epic Lives when destiny is done
            // for(int i = 0; i< NumEpic; ++i)
            //      PastLifeEpic[i]=0;



        }


        #endregion

        #region Public Methods
        public int getNumPastLifes()
        {
            int count = 0;
            for (int i = 0; i < NumHeroic; ++i)
            {
                count += PastLifeHerioc[i];
            }
            return count;

        }
        public bool isCompletionist()
        {
            if (getNumPastLifes() / 3 == NumHeroic)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion



    }
}

