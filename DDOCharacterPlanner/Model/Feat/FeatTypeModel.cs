using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
	{
	/// <summary>
	/// Defines data availability for a class.
	/// </summary>
	public sealed class FeatTypeModel : BaseModel
		{
		#region Private Constants
		private const string IdField = "FeatTypeId";
		private const string NameField = "Name";

		private const string LoadFeatTypeByNameQuery = "SELECT * FROM FeatType WHERE Name=@Name";
		private const string LoadFeatTypeByIdQuery = "SELECT * FROM FeatType WHERE FeatTypeId=@FeatTypeId";
		private const string LoadNamesQuery = "SELECT FeatTypeId, Name FROM FeatType";
        private const string LoadNameFromIdQuery = "SELECT Name FROM FeatType WHERE FeatTypeId=@FeatTypeId";

        private const string GetIdFromNameQuery = "SELECT FeatTypeId FROM FeatType WHERE Name=@Name";

		private const string InsertQuery = "INSERT INTO FeatType (FeatTypeId, Name) VALUES (@FeatTypeId, @Name)";
		private const string UpdateQuery = "UPDATE FeatType SET Name=@Name WHERE FeatTypeId=@FeatTypeid";

		#endregion

		#region Properties
		public string Name
			{
			get;
			set;
			}
		#endregion

		#region Private Static Methods
		/// <summary>
		/// Reads the names.
		/// </summary>
		/// <param name="reader">The Reader.</param>
		/// <returns>The read id and name.</returns>
		private static string ReadNames(DbDataReader reader)
			{
			int ordinal;
			Guid id;
			string name = null;

			if (reader == null)
				{
				return null;
				}

			if (!reader.TryGetOrdinal(FeatTypeModel.IdField, out ordinal))
				{
				// No ID field, cant' use
				return null;
				}

			if (reader.IsDBNull(ordinal))
				{
				// Null, can't use
				return null;
				}

			id = reader.GetGuid(ordinal);

			if (reader.TryGetOrdinal(FeatTypeModel.NameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					name = reader.GetString(ordinal);
					}
				}

			return name;
			}

        private static string ReadJustNames(DbDataReader reader)
            {
            int ordinal;
            string name = null;

            if (reader == null)
                return null;

            if (reader.TryGetOrdinal(FeatTypeModel.NameField, out ordinal))
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

            if (reader.TryGetOrdinal(FeatTypeModel.IdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    id = reader.GetGuid(ordinal);
                }
            return id;
            }

		#endregion

		#region Protect Methods
		/// <summary>
		/// Loads the specified reader.
		/// </summary>
		/// <param name="reader">The Reader.</param>
		protected override void Load(DbDataReader reader)
			{
			int ordinal;

			if (reader == null)
				{
				return;
				}

			if (!reader.TryGetOrdinal(FeatTypeModel.IdField, out ordinal))
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

			if (reader.TryGetOrdinal(FeatTypeModel.NameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.Name = reader.GetString(ordinal);
					}
				else
					{
					this.Name = "";
					}
				}
			}
		#endregion

		#region Public Methods
		/// <summary>
		/// Creates the specified FeatType Name
		/// </summary>
		/// <param name="feattypeName">Name of the Feat Type.</param>
		public void Initialize(string feattypeName)
			{
			QueryInformation query;

			if (string.IsNullOrWhiteSpace(feattypeName))
				{
				return;
				}
			query = QueryInformation.Create(FeatTypeModel.LoadFeatTypeByNameQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + FeatTypeModel.NameField, DbType.String, feattypeName));

			this.Initialize(query);
			}

		public void Initialize(Guid feattypeId)
			{
			QueryInformation query;

			if (feattypeId == Guid.Empty)
				{
				return;
				}

			query = QueryInformation.Create(FeatTypeModel.LoadFeatTypeByIdQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + FeatTypeModel.IdField, DbType.Guid, feattypeId));

			this.Initialize(query);
			}

		public void Save()
			{
			QueryInformation query;

			if (this.Id == Guid.Empty)
				{
				query = QueryInformation.Create(FeatTypeModel.InsertQuery);
				this.Id = Guid.NewGuid();
				}
			else
				{
				query = QueryInformation.Create(FeatTypeModel.UpdateQuery);
				}

			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + FeatTypeModel.IdField, DbType.Guid, this.Id));
			query.Parameters.Add(new QueryParameter("@" + FeatTypeModel.NameField, DbType.String, this.Name));

			BaseModel.RunCommand(query);

			}
		#endregion

		#region Public Static Methods
		/// <summary>
		/// Gets the names
		/// </summary>
		/// <returns>A list of all the FeatType Names.</returns>
		public static List<string> GetNames()
			{
			QueryInformation query;

			query = QueryInformation.Create(FeatTypeModel.LoadNamesQuery);
			query.CommandType = CommandType.Text;

			return BaseModel.GetNames(query, FeatTypeModel.ReadNames);
			}

        public static string GetNameFromId(Guid featTypeId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(FeatTypeModel.LoadNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatTypeModel.IdField, DbType.Guid, featTypeId));
            
            names = BaseModel.GetNames(query, FeatTypeModel.ReadJustNames);
            if (names.Count == 0)
                return "";
            else
                return names[0];
            }

        public static Guid GetIdFromName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(FeatTypeModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatTypeModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, FeatTypeModel.ReadId);
            if (ids == null)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
            }
		#endregion
		}
	}
