using DDOCharacterPlanner.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace DDOCharacterPlanner.Data
	{
	public class ClassDataCollectionClass
		{
		//private List<string> ClassNames; Changed this to a propery since we need to access, just like it is the Race Collection
		//private SortedDictionary<string, ClassDataClass> Classes;

        #region Properties
        public List<string> ClassNames
            {
            get;
            private set;
            }

        public SortedDictionary<string, ClassDataClass> Classes
            {
            get;
            private set;
            }

        #endregion
        #region Constructors
        public ClassDataCollectionClass()
			{
			LoadClassName();
			}
		#endregion

		#region Private Methods
		/// <summary>
		/// On initialization, preload the class names and set up an entry in the dictionary
		/// </summary>
		private void LoadClassName()
			{
			ClassNames = ClassModel.GetNames();
			Classes = new SortedDictionary<string, ClassDataClass>();
			foreach (string name in ClassNames)
				{
				Classes.Add(name, new ClassDataClass(name));
				}
			}
		#endregion

        #region Public Methods
        public string GetClassName(Guid classId)
            {
            string className;
            className = "";

            for (int i = 0; i < Classes.Count; i++)
                {
                if (classId == Classes[ClassNames[i]].ClassId)
                    return ClassNames[i];
                }

            return className;
            }

        public int HasReincarnationPriorty(Guid firstClassId, Guid secondClassId)
            {
            int priorty = -1;

            if (Classes[GetClassName(firstClassId)].ReincrantionPriorty < Classes[GetClassName(secondClassId)].ReincrantionPriorty)
                priorty = 0;
            else
                priorty = 1;
            return priorty;
            }
        #endregion
        }
	}
