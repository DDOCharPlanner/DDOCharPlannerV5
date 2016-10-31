using System;
using System.Collections.Generic;
//using System.Data.Common;
using DDOCharacterPlanner.Data;

namespace DDOCharacterPlanner.CharacterData
{
    public class CharacterClassClass
        {
        #region Member Variables
        private List<Guid> Classes;

        #endregion

        #region Properties
        #endregion

        #region Constructor
        public CharacterClassClass()
            {
            Classes = new List<Guid>();
            for (int i = 0; i < 20; i++)
                Classes.Add(Guid.Empty);
            }
        #endregion

        #region Public Methods
        public Guid GetClass(int level)
            {
            return Classes[level-1];
            }

        public Guid[] GetClasses(int level=20)
            {
            Guid[] classIds;

            classIds = new Guid[3] { Guid.Empty, Guid.Empty, Guid.Empty };
            if (level > 20)
                level = 20;
            for (int i = 0; i < level; i++)
                {
                if (Classes[i] != Guid.Empty)
                    {
                    if (classIds[0] == Guid.Empty)
                        classIds[0] = Classes[i];
                    else if (classIds[1] == Guid.Empty && classIds[0] != Classes[i] && classIds[2] != Classes[i])
                        classIds[1] = Classes[i];
                    else
                        if (classIds[2] == Guid.Empty && classIds[0] != Classes[i] && classIds[1] != Classes[i])
                            classIds[2] = Classes[i];
                    }
                }

            return classIds;
            }

        public string[] GetClassesSorted()
            {
            string[] classNames;
            Guid[] classIds;
            int[] classCount;
            List<int> sortedIndex;

            classNames = new string[3] { "", "", "" };
            classCount = new int[3] { 0, 0, 0 };
            classIds = GetClasses();

            //lets get our class counts
            for (int i = 0; i < 3; i++)
                {
                if (classIds[i] != Guid.Empty)
                    classCount[i] = GetClassCount(classIds[i]);
                }

            //lets sort our class counts in descending order
            sortedIndex = Utility.UtilityClass.ReturnSortedIndex(new List<int>(classCount));

            //Now that our coutns are sorted, we can build the classnames array
            if (classCount[sortedIndex[0]] == 0)
                return classNames;

            if (classCount[sortedIndex[0]] != classCount[sortedIndex[1]])
                {
                classNames[0] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[0]]);
                if (classCount[sortedIndex[1]] != classCount[sortedIndex[2]])
                    {
                    classNames[1] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);
                    if (classCount[sortedIndex[2]] > 0)
                        classNames[2] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                    }
                else
                    {
                    if (classCount[sortedIndex[1]] != 0)
                        {
                        //since class 2 & 3 have equal amounts, we need to find which has the reincarnatino priorty
                        if (DataManagerClass.DataManager.ClassDataCollection.HasReincarnationPriorty(classIds[sortedIndex[1]], classIds[sortedIndex[2]]) == 0)
                            {
                            classNames[1] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);
                            classNames[2] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                            }
                        else
                            {
                            classNames[2] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                            classNames[1] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);
                            }
                        }
                    }
                }
            else
            //since class 1 and 2 are equal we nee to find which has the reincarnation priorty
                {
                if (DataManagerClass.DataManager.ClassDataCollection.HasReincarnationPriorty(classIds[sortedIndex[0]], classIds[sortedIndex[1]]) == 0)
                    {
                    classNames[0] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[0]]);
                    if (classCount[sortedIndex[1]] != classCount[sortedIndex[2]])
                        {
                        classNames[1] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);
                        if (classCount[sortedIndex[2]] > 0)
                            classNames[2] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                        }
                    else
                        {
                        if (classCount[sortedIndex[1]] != 0)
                            {
                            //since class 2 & 3 have equal amounts, we need to find which has the reincarnatino priorty
                            if (DataManagerClass.DataManager.ClassDataCollection.HasReincarnationPriorty(classIds[sortedIndex[1]], classIds[sortedIndex[2]]) == 0)
                                {
                                classNames[1] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);
                                classNames[2] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                                }
                            else
                                {
                                classNames[2] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                                classNames[1] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);
                                }
                            }
                        }
                    }
                else
                    {
                    classNames[1] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);
                    if (classCount[sortedIndex[0]] != classCount[sortedIndex[2]])
                        {
                        classNames[0] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[0]]);
                        if (classCount[sortedIndex[2]] > 0)
                            classNames[2] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                        }
                    else
                        {
                        if (classCount[sortedIndex[0]] != 0)
                            {
                            //since class 1 & 3 have equal amounts, we need to find which has the reincarnatino priorty
                            if (DataManagerClass.DataManager.ClassDataCollection.HasReincarnationPriorty(classIds[sortedIndex[0]], classIds[sortedIndex[2]]) == 0)
                                {
                                classNames[0] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[0]]);
                                classNames[2] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                                }
                            else
                                {
                                classNames[2] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                                classNames[0] = DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[0]]);
                                }
                            }
                        }
                    }
                }

            return classNames;
            }

        public int GetClassCount(Guid classId, int level=20)
            {
            int count = 0;

            if (level > 20)
                level = 20;

            for (int i = 0; i < level; i++)
                if (Classes[i] == classId)
                    count++;

            return count;
            }

        public string GetClassSplit(int level=30)
            {
            string classSplit;
            int[] classCount;
            Guid[] classIds;
            List<int> sortedIndex;

            classSplit = "";
            classCount = new int[3]{0,0,0};
            classIds = GetClasses();

            if (level > 20)
                level = 20;
            //lets get our class counts
            for (int i = 0; i < 3; i++)
                {
                if (classIds[i] != Guid.Empty)
                    classCount[i] = GetClassCount(classIds[i], level);
                }

            //lets sort our class counts in descending order
            sortedIndex = Utility.UtilityClass.ReturnSortedIndex(new List<int>(classCount));

            //Now that our counts are sorted, we can build the string for classSplit
            if (classCount[sortedIndex[0]] == 0)
                return classSplit;

            if (classCount[sortedIndex[0]] != classCount[sortedIndex[1]])
                {
                classSplit = classCount[sortedIndex[0]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[0]]);
                if (classCount[sortedIndex[1]] != classCount[sortedIndex[2]])
                    {
                    classSplit += " / " + classCount[sortedIndex[1]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);
                    if (classCount[sortedIndex[2]] > 0)
                        classSplit += " / " + classCount[sortedIndex[2]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                    }
                else
                    {
                    if (classCount[sortedIndex[1]] != 0)
                        {
                        //since class 2 & 3 have equal amounts, we need to find which has the reincarnatino priorty
                        if (DataManagerClass.DataManager.ClassDataCollection.HasReincarnationPriorty(classIds[sortedIndex[1]], classIds[sortedIndex[2]]) == 0)
                            {
                            classSplit += " / " + classCount[sortedIndex[1]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);
                            classSplit += " / " + classCount[sortedIndex[2]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                            }
                        else
                            {
                            classSplit += " / " + classCount[sortedIndex[2]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                            classSplit += " / " + classCount[sortedIndex[1]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);

                            }
                        }
                    }
                }
            else
            //since class 1 and 2 are equal we nee to find which has the reincarnation priorty
                {
                if (DataManagerClass.DataManager.ClassDataCollection.HasReincarnationPriorty(classIds[sortedIndex[0]], classIds[sortedIndex[1]]) == 0)
                    {
                    classSplit = classCount[sortedIndex[0]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[0]]);
                    if (classCount[sortedIndex[1]] != classCount[sortedIndex[2]])
                        {
                        classSplit += " / " + classCount[sortedIndex[1]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);
                        if (classCount[sortedIndex[2]] > 0)
                            classSplit += " / " + classCount[sortedIndex[2]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                        }
                    else
                        {
                        if (classCount[sortedIndex[1]] != 0)
                            {
                            //since class 2 & 3 have equal amounts, we need to find which has the reincarnatino priorty
                            if (DataManagerClass.DataManager.ClassDataCollection.HasReincarnationPriorty(classIds[sortedIndex[1]], classIds[sortedIndex[2]]) == 0)
                                {
                                classSplit += " / " + classCount[sortedIndex[1]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);
                                classSplit += " / " + classCount[sortedIndex[2]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                                }
                            else
                                {
                                classSplit += " / " + classCount[sortedIndex[2]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                                classSplit += " / " + classCount[sortedIndex[1]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);

                                }
                            }
                        }
                    }
                else
                    {
                    classSplit = classCount[sortedIndex[1]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[1]]);
                    if (classCount[sortedIndex[0]] != classCount[sortedIndex[2]])
                        {
                        classSplit += " / " + classCount[sortedIndex[1]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[0]]);
                        if (classCount[sortedIndex[2]] > 0)
                            classSplit += " / " + classCount[sortedIndex[2]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                        }
                    else
                        {
                        if (classCount[sortedIndex[0]] != 0)
                            {
                            //since class 1 & 3 have equal amounts, we need to find which has the reincarnatino priorty
                            if (DataManagerClass.DataManager.ClassDataCollection.HasReincarnationPriorty(classIds[sortedIndex[0]], classIds[sortedIndex[2]]) == 0)
                                {
                                classSplit += " / " + classCount[sortedIndex[0]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[0]]);
                                classSplit += " / " + classCount[sortedIndex[2]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                                }
                            else
                                {
                                classSplit += " / " + classCount[sortedIndex[2]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[2]]);
                                classSplit += " / " + classCount[sortedIndex[0]] + " " + DataManagerClass.DataManager.ClassDataCollection.GetClassName(classIds[sortedIndex[0]]);

                                }
                            }
                        }
                    }
                }

            return classSplit;
            }

		public void UpdateClass(int level, Guid chosenClass)
			{
            //if (chosenClass == Guid.Empty)
            //    return;

            Classes[level - 1] = chosenClass;
            CharacterManagerClass.CharacterManager.CharacterSkill.UpdateClass(level, chosenClass);

			}

        #endregion

        }
}
