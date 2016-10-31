using DDOCharacterPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDOCharacterPlanner.Data
	{
	public class AlignmentDataClass
		{
		#region Properties
		public List<string> AlignmentNames
        {
			get;
			private set;
		}
        public SortedDictionary<Guid, string> Alignment
        {
            get;
            private set;
        }
        public SortedDictionary<string, Guid> AlignmentbyName
        {
            get;
            private set;
        }




		#endregion

		#region Private Member Variables
		#endregion

		#region Constructors
		public AlignmentDataClass()
			{
			LoadData();
			}

		#endregion

		#region Private Methods
		/// <summary>
		/// Load the data for this class
		/// </summary>
		private void LoadData()
			{
                List<AlignmentModel> Alignments;
                Alignments = AlignmentModel.GetAll();
                AlignmentNames = new List<string>();
                Alignment= new SortedDictionary<Guid, string>();
                AlignmentbyName = new SortedDictionary<string,Guid>();
                foreach(AlignmentModel newModel in Alignments)
                {
                    AlignmentNames.Add(newModel.Name);
                    Alignment.Add(newModel.Id, newModel.Name);
                    AlignmentbyName.Add(newModel.Name, newModel.Id);
                }
			}

		#endregion
		}
	}
