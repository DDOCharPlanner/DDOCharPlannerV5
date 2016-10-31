using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DDOCharacterPlanner.Data;

namespace DDOCharacterPlanner.CharacterData
    {
    public class CharacterFeatCollectionClass
        {
        #region Enums
        public enum FeatGroup
            {
            All,
            Granted,
            Selected,
            };
        #endregion

        #region Member Variables
        List<CharacterFeatClass> SelectedFeats;

        #endregion

        #region Properties

        #endregion

        #region Constructor
        public CharacterFeatCollectionClass()
            {
            SelectedFeats = new List<CharacterFeatClass>();
            }

        #endregion

        #region Private Members
        private Dictionary<Guid, int> MergeDictionaries(Dictionary<Guid, int> dictionary1, Dictionary<Guid, int> dictionary2)
            {

            for (int i = 0; i < dictionary2.Count; i++)
                {
                if (dictionary1.ContainsKey(dictionary2.ElementAt(i).Key) == true)
                    dictionary1[dictionary1.ElementAt(i).Key] += dictionary2.ElementAt(i).Value;
                else
                    dictionary1.Add(dictionary2.ElementAt(i).Key, dictionary2.ElementAt(i).Value);
                }
            return dictionary1;
            }

        #endregion

        #region Public Members
        public List<Tuple<Guid,int>> GetKnownFeatsList(FeatGroup featGroup, int level)
            {
            List <Tuple<Guid, int>> featList;
            featList = new List<Tuple<Guid, int>>();
            Dictionary<Guid, int> dicFeats;
            Dictionary<Guid, int> dicTemp;
            Guid[] classes;

            dicFeats = new Dictionary<Guid, int>();
            dicTemp = new Dictionary<Guid, int>();

            //pull the autogranted feats from CharacterData
            if (featGroup == FeatGroup.All || featGroup == FeatGroup.Granted)
                {
                //pull the autogranted feast form CharacterData
                dicFeats = DataManagerClass.DataManager.CharacterDataCollection.GetAutograntedFeats(level);
            
                //pull the autogranted feats from RaceData
                if (CharacterManagerClass.CharacterManager.CharacterRace.Race != -1)
                    {
                    dicTemp = DataManagerClass.DataManager.RaceDataCollection.Races[CharacterManagerClass.CharacterManager.CharacterRace.GetRaceName()].GetAutograntedFeats(level);
                    //we need to add the temp dictionary to the feats dictionary now
                    dicFeats = MergeDictionaries(dicFeats, dicTemp);
                    }

                //pull the autogranted feats from ClassData
                classes = CharacterManagerClass.CharacterManager.CharacterClass.GetClasses(level);
                for (int i = 0; i < 3; i++)
                    {
                    if (classes[i] != Guid.Empty)
                        {
                        dicTemp = DataManagerClass.DataManager.ClassDataCollection.Classes[DataManagerClass.DataManager.ClassDataCollection.GetClassName(classes[i])]
                            .GetAutograntedFeats(CharacterManagerClass.CharacterManager.CharacterClass.GetClassCount(classes[i], level));
                        //we need to add the temp dictionary to the feats dictionary
                        dicFeats = MergeDictionaries(dicFeats, dicTemp);
                        }
                    }
                }

            //pull the selected feats from CharacterFeatCollection (this class)
            if (featGroup == FeatGroup.All || featGroup == FeatGroup.Selected)
                {
                dicTemp.Clear();
                foreach (CharacterFeatClass sf in SelectedFeats)
                    {
                    if (dicTemp.ContainsKey(sf.FeatId) == true)
                        dicTemp[sf.FeatId] += 1;
                    else
                        dicTemp.Add(sf.FeatId, 1);
                    }
                dicFeats = MergeDictionaries(dicFeats, dicTemp);
                }

            //Ok now that we have our dictionary of featid and the count, lets create the Tuple list to send back
            foreach (KeyValuePair<Guid, int> dic in dicFeats)
                {
                featList.Add(new Tuple<Guid, int>(dic.Key, dic.Value));
                }


            return featList;
            }

        #endregion
        }
    }
