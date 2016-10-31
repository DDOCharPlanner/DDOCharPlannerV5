using DDOCharacterPlanner.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DDOCharacterPlanner.Model
	{

	public sealed class AlignmentModel : BaseModel
		{
		#region Private Constants
		private const string IdField = "AlignmentId";
		private const string NameField = "Name";
        private const string SortByField = "SortBy";
		private const string LoadAllQuery = "SELECT * FROM Alignments ORDER BY SortBy";
        private const string LoadNames = "SELECT Name FROM Alignments ORDER BY SortBy";
		private const string LoadAllForClassQuery = "SELECT * FROM Alignments a, ClassAlignmentsAllowed ca WHERE a.AlignmentId = ca.AlignmentId AND ca.ClassId=@ClassId";
        private const string GetNameFromIdQuery = "SELECT Name FROM Alignments WHERE AlignmentId=@AlignmentId";
        private const string GetIdFromNameQuery = "SELECT AlignmentId FROM Alignments WHERE Name=@Name";
        #endregion

		#region Properties
		public string Name
			{
			get;
			set;
			}
        public int SortBy
        {
            get;
            set;
        }

		#endregion

		#region Private Static Methods
		private static AlignmentModel Create(DbDataReader reader)
		{
			AlignmentModel model;

			model = new AlignmentModel();
			model.Load(reader);

			return model;
		}
		#endregion

		#region Protected Methods
		/// <summary>
		/// Loads the specified reader.
		/// </summary>
		/// <param name="reader">The reader.</param>
		protected override void Load(DbDataReader reader)
			{
			int ordinal;

			if (reader == null)
				{
				return;
				}

			if (!reader.TryGetOrdinal(AlignmentModel.IdField, out ordinal))
				{
				// No ID field, can't use
				return;
				}


			if (reader.IsDBNull(ordinal))
				{
				// Null, can't use
				return;
				}

			this.Id = reader.GetGuid(ordinal);

			if (reader.TryGetOrdinal(AlignmentModel.NameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.Name = reader.GetString(ordinal);
					}
				}
            if (!reader.TryGetOrdinal(AlignmentModel.SortByField, out ordinal))
            {
                // No ID field, can't use
                return;
            }
			}
        /// <summary>
        /// Reads the Name
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <returns>the name</returns>
        private static string ReadName(DbDataReader reader)
        {
            int ordinal;
            string name = null;

            if (reader == null)
                return null;

            if (reader.TryGetOrdinal(AlignmentModel.NameField, out ordinal))
            {
                if (!reader.IsDBNull(ordinal))
                {
                    name = reader.GetString(ordinal);
                }
            }
            return name;
        }
        private static Guid ReadId(DbDataReader reader)
        {
            int ordinal;
            Guid id = Guid.Empty;

            if (reader == null)
                return Guid.Empty;

            if (reader.TryGetOrdinal(AlignmentModel.IdField, out ordinal))
            {
                if (!reader.IsDBNull(ordinal))
                    id = reader.GetGuid(ordinal);
            }
            return id;
        }
		#endregion

		#region Public Methods
		#endregion

		#region Public Static Methods
		public static List<AlignmentModel> GetAll()
			{
			QueryInformation query;

			query = QueryInformation.Create(AlignmentModel.LoadAllQuery);
			query.CommandType = CommandType.Text;

			return BaseModel.GetAll<AlignmentModel>(query, AlignmentModel.Create);
			}

		public static List<AlignmentModel> GetAllForClass(Guid classId)
		{
			QueryInformation query;

			if (classId == Guid.Empty)
			{
				return null;
			}

			query = QueryInformation.Create(AlignmentModel.LoadAllForClassQuery);
			query.Parameters.Add(new QueryParameter("@ClassId", DbType.Guid, classId));
			query.CommandType = CommandType.Text;

			return BaseModel.GetAll<AlignmentModel>(query, AlignmentModel.Create);
		}
        public static List<string> GetNames()
        {
            QueryInformation query;
            query = QueryInformation.Create(AlignmentModel.LoadNames);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, ReadName);
        }
        public static String GetNameFromID(Guid AlignmentID)
        {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(AlignmentModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + AlignmentModel.IdField, DbType.Guid, AlignmentID));

            names = BaseModel.GetNames(query, AlignmentModel.ReadName);
            if (names == null)
                return "";
            else
                return names[0];

        }
        public static Guid GetIdFromName(string name)
        {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(AlignmentModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + AlignmentModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, AlignmentModel.ReadId);
            if (ids == null)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
        }

		#endregion
		}
	}
