using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDOCharacterPlanner.Data;

namespace DDOCharacterPlanner.CharacterData
{
    public class CharacterAlignmentClass
    {
        #region Member Variables
        #endregion

        #region Properties
        public Guid Alignment
			{
			get;
			private set;
			}

		#endregion

        #region Constructor
        public CharacterAlignmentClass()
            {
            Alignment = DataManagerClass.DataManager.AlignmentData.AlignmentbyName["Chaotic Neutral"];
            }
        #endregion

        #region Public Methods
        public void UpdateAlignment(string AlignmentName)
			{
                if (DataManagerClass.DataManager.AlignmentData.AlignmentbyName.ContainsKey(AlignmentName))
                   {
                    Alignment = DataManagerClass.DataManager.AlignmentData.AlignmentbyName[AlignmentName];
					return;
                   }


			}

		public string GetAlignmentName()
			{
            if (Alignment != Guid.Empty)
                return "";


			return DataManagerClass.DataManager.AlignmentData.Alignment[Alignment];
			}

		#endregion

    }
}
