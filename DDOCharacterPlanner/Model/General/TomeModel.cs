using DDOCharacterPlanner.DataAccess;
using DDOCharacterPlanner.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DDOCharacterPlanner.Model.Tome
	{
	class TomeModel : BaseModel
		{
		#region Private Constants
		//fields
		private const string IdField = "Id";
		private const string TypeField = "Type";
		private const string ModifiedIDField = "ModifiedID";
		private const string MinLevelField = "MinLevel";
		private const string NameField = "Name";
		private const string LongNameField = "LongName";
		private const string BonusField = "Bonus";
		private const string LastUpdatedDateField = "LastUpdatedDate";
		private const string LastUpdatedVersionField = "LastUpdatedVersion";

		//updates
		private const string InsertQuery = "INSERT INTO Tome (Id, Type, ModifiedID, MinLevel, Name, LongName, Bonus, LastUpdatedDate, LastUpdatedVersion) VALUES (@Id, @Type, @ModifiedID, @MinLevel, @Name, @LongName, @Bonus, @LastUpdatedDate, @LastUpdatedVersion)";
		private const string UpdateQuery = "UPDATE Tome SET Type=@Type, ModifiedID=@ModifiedID, MinLevel=@MinLevel, Name=@Name, LongName=@LongName, Bonus=@Bonus, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE Id=@Id";
		private const string DeleteQuery = "DELETE FROM Tome WHERE Id=@Id";



		//selections
		private const string LoadNamesQuery = "SELECT LongName FROM Tome ORDER BY LongName";
		private const string LoadTomeByNameQuery = "SELECT * FROM Tome WHERE LongName=@LongName";
        private const string LoadAllByTypeQuery = "SELECT * FROM Tome WHERE Type=@Type ORDER BY LongName";

        //Counts
        private const string CountByModifiedId = "SELECT Count(*) AS Count FROM Tome WHERE ModifiedID=@ModifiedID";

        //Max Tome Value
        private const string LoadTomeMaxValueQuery = "SELECT Bonus FROM Tome WHERE ModifiedID=@ModifiedID";

        //Min Tome Level
        private const string LoadTomeMinLevel = "SELECT MinLevel FROM Tome WHERE ModifiedID=@ModifiedID AND Bonus=@Bonus";

		#endregion

		#region Properties
		public string TomeName
			{
			get;
			set;
			}

		public string TomeLongName
			{
			get;
			set;
			}

		public string TomeType
			{
			get;
			set;
			}

		public int TomeBonus
			{
			get;
			set;
			}

		public Guid ModifiedID
			{
			get;
			set;
			}

		public int MinLevel
			{
			get;
			set;
			}
		#endregion

		#region Constructors
		public TomeModel()
			{
			TomeName = "";
			TomeLongName = "";
			TomeType = "Ability";
			TomeBonus = 0;
			ModifiedID = Guid.Empty;
			MinLevel = 1;
			}

		#endregion

		#region Public Methods
		/// <summary>
		/// Creates the specified tome by Name.
		/// </summary>
		/// <param name="tomeName">Name of the tome.</param>
		public void Initialize(string tomeName)
			{
			QueryInformation query;

			if (string.IsNullOrWhiteSpace(tomeName))
				return;

			query = QueryInformation.Create(LoadTomeByNameQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + LongNameField, DbType.String, tomeName));

			this.Initialize(query);
			}
        public static int GetMaxBonus(Guid ModifiedID)
        {
            QueryInformation query;

            query = QueryInformation.Create(LoadTomeMaxValueQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TomeModel.ModifiedIDField, DbType.Guid, ModifiedID));
            int result = BaseModel.GetMax(query,ReadBonus);

            return result;

        }
        public static int GetMinLevel(Guid ModifiedID, int Bonus)
        {


            QueryInformation query;

            query = QueryInformation.Create(LoadTomeMinLevel);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TomeModel.ModifiedIDField, DbType.Guid, ModifiedID));
            query.Parameters.Add(new QueryParameter("@" + TomeModel.BonusField, DbType.Int16, Bonus));
            int result = BaseModel.GetMin(query, ReadMinLevel);

            return result;

        }
        public static int GetCountByModifiedId(Guid ModifiedID)
        {
            QueryInformation query;

            query = QueryInformation.Create(CountByModifiedId);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TomeModel.ModifiedIDField, DbType.Guid, ModifiedID));
            int result = BaseModel.GetCount(query);

            return result;
        }

		public void Save()
			{
			QueryInformation query;

			if (Id == Guid.Empty)
				{
				query = QueryInformation.Create(InsertQuery);
				Id = Guid.NewGuid();
				}
			else
				{
				query = QueryInformation.Create(UpdateQuery);
				}

			//update the last modified fields
			LastUpdatedDate = DateTime.Now;
			LastUpdatedVersion = Constant.PlannerVersion;

			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + IdField, DbType.Guid, Id));
			query.Parameters.Add(new QueryParameter("@" + TypeField, DbType.String, TomeType));
			query.Parameters.Add(new QueryParameter("@" + ModifiedIDField, DbType.Guid, ModifiedID));
			query.Parameters.Add(new QueryParameter("@" + MinLevelField, DbType.Int16, MinLevel));
			query.Parameters.Add(new QueryParameter("@" + NameField, DbType.String, TomeName));
			query.Parameters.Add(new QueryParameter("@" + LongNameField, DbType.String, TomeLongName));
			query.Parameters.Add(new QueryParameter("@" + BonusField, DbType.Int16, TomeBonus));
			query.Parameters.Add(new QueryParameter("@" + LastUpdatedDateField, DbType.DateTime, LastUpdatedDate));
			query.Parameters.Add(new QueryParameter("@" + LastUpdatedVersionField, DbType.String, LastUpdatedVersion));
			BaseModel.RunCommand(query);

			return;
			}

		public void Delete()
			{
			QueryInformation query;

			//record
			query = QueryInformation.Create(DeleteQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + IdField, DbType.Guid, this.Id));
			BaseModel.RunCommand(query);
			}
		#endregion 

		#region Protected Methods
		protected override void Load(DbDataReader reader)
			{
			int ordinal;

			if (reader == null)
				{
				return;
				}

			if (!reader.TryGetOrdinal(IdField, out ordinal))
				{
				// No ID field, can't use
				return;
				}

			if (reader.IsDBNull(ordinal))
				{
				// Null, can't use
				return;
				}

			Id = reader.GetGuid(ordinal);

			if (reader.TryGetOrdinal(NameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					TomeName = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(LongNameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					TomeLongName = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(TypeField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					TomeType = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(BonusField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					TomeBonus = reader.GetInt16(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ModifiedIDField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					ModifiedID = reader.GetGuid(ordinal);
					}
				}

			if (reader.TryGetOrdinal(MinLevelField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					MinLevel = reader.GetInt16(ordinal);
					}
				}

			if (reader.TryGetOrdinal(LastUpdatedDateField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					LastUpdatedDate = reader.GetDateTime(ordinal);
					}
				}

			if (reader.TryGetOrdinal(LastUpdatedVersionField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					LastUpdatedVersion = reader.GetString(ordinal);
					}
				}
			}
		#endregion

		#region Public Static Methods
		/// <summary>
		/// Gets all the ability names
		/// </summary>
		/// <returns>A list of all the Race names.</return>
		public static List<string> GetNames()
			{
			QueryInformation query;

			query = QueryInformation.Create(LoadNamesQuery);
			query.CommandType = CommandType.Text;

			return BaseModel.GetNames(query, ReadName);
			}
        public static List<TomeModel> GetAllByType(string Type)
        {
            QueryInformation query;

            query = QueryInformation.Create(TomeModel.LoadAllByTypeQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TomeModel.TypeField, DbType.String, Type));

            return BaseModel.GetAll<TomeModel>(query, TomeModel.Create);
        }
        

		#endregion

		#region Private Static Methods
        private static TomeModel Create(DbDataReader reader)
        {
            TomeModel model;

            model = new TomeModel();
            model.Load(reader);

            return model;
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

            if (reader.TryGetOrdinal(LongNameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    name = reader.GetString(ordinal);
                    }
                }
            return name;
            }

        /// <summary>
        /// Reads the bonus
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <returns>bonus</returns>
        protected static int ReadBonus(DbDataReader reader)
        {
            int ordinal;
            int bonus = 0;

            if (reader == null)
                return 0;

            if (reader.TryGetOrdinal(BonusField, out ordinal))
            {
                if (!reader.IsDBNull(ordinal))
                {
                    bonus = reader.GetInt16(ordinal);
                }
            }
            return bonus;
        }
        /// <summary>
        /// Reads the bonus
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <returns>bonus</returns>
        protected static int ReadMinLevel(DbDataReader reader)
        {
            int ordinal;
            int MinLevel = 0;

            if (reader == null)
                return 0;

            if (reader.TryGetOrdinal(MinLevelField, out ordinal))
            {
                if (!reader.IsDBNull(ordinal))
                {
                    MinLevel = reader.GetInt16(ordinal);
                }
            }
            return MinLevel;
        }
		#endregion
		}
	}
