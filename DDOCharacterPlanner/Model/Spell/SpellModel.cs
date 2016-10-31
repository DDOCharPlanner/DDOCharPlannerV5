using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DDOCharacterPlanner.Model
	{
	class SpellModel : BaseModel
		{
		#region Private Constants
		//fields
		private const string IdField = "SpellId";
		private const string NameField = "SpellName";
		private const string SpellSchoolIdField = "SpellSchoolId";
		private const string SpellRangeField = "SpellRange";
		private const string SpellDescriptionField = "Description";
		private const string SpellIconField = "Icon";
		private const string ComponentsField = "Components";
		private const string MetamagicFeatsField = "MetamagicFeats";
		private const string TargetsField = "Targets";
		private const string DurationField = "Duration";
		private const string SpellResistanceField = "SpellResistance";
		private const string SavingThrowField = "SavingThrow";
		private const string LastUpdatedDateField = "LastUpdatedDate";
		private const string LastUpdatedVersionField = "LastUpdatedVersion";
		//updates
		private const string InsertQuery = "INSERT INTO Spell (SpellId, SpellName, SpellSchoolId, SpellRange, Description, Icon, Components, MetamagicFeats, Targets, Duration, SpellResistance, SavingThrow, LastUpdatedDate, LastUpdatedVersion) VALUES (@SpellId, @SpellName, @SpellSchoolId, @SpellRange, @Description, @Icon, @Components, @MetamagicFeats, @Targets, @Duration, @SpellResistance, @SavingThrow, @LastUpdatedDate, @LastUpdatedVersion)";
		private const string UpdateQuery = "UPDATE Spell SET SpellName=@SpellName, SpellSchoolId=@SpellSchoolId, SpellRange=@SpellRange, Description=@Description, Icon=@Icon, Components=@Components, MetamagicFeats=@MetamagicFeats, Targets=@Targets, Duration=@Duration, SpellResistance=@SpellResistance, SavingThrow=@SavingThrow, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE SpellId=@SpellId";
		private const string DeleteQuery = "DELETE FROM Spell WHERE SpellId=@SpellId";
		//selections
		private const string LoadNamesQuery = "SELECT SpellName FROM Spell ORDER BY SpellName";
		private const string LoadSpellByNameQuery = "SELECT * FROM Spell WHERE SpellName=@SpellName";
        //Get values
        private const string GetIdFromNameQuery = "SELECT SpellId FROM Spell WHERE SpellName=@SpellName";
		//counts
		private const string NameCountQuery = "SELECT COUNT(*) AS Count FROM Spell WHERE SpellName=@SpellName";
		//default values for the constructor
		private const string DefaultSpellSchool = "Abjuration";
		private const string DefaultSpellRange = "Personal";
		private const string DefaultDescription = "<HTML><body style=\"background: #000000\"><font color=\"white\"><p><B>Bold Text</b></p><p>Regular Text</p><p>Important stats</p><p>Strength...</p></font></body></HTML>";
		private const string DefaultImageName = "NoImage";
		private const string DefaultDuration = "1 Second";
		private const string DefaultSavingThrow = "None";
		#endregion

		#region Properties
		public string SpellName
			{
			get;
			set;
			}

		public Guid SpellSchoolId
			{
			get;
			set;
			}

		public string SpellRange
			{
			get;
			set;
			}

		public string Description
			{
			get;
			set;
			}

		public string IconFilename
			{
			get;
			set;
			}

		public ushort SpellComponents
			{
			get;
			set;
			}

		public ushort MetamagicFeats
			{
			get;
			set;
			}

		public ushort Targets
			{
			get;
			set;
			}

		public string Duration
			{
			get;
			set;
			}

		public bool SpellResistance
			{
			get;
			set;
			}

		public string SavingThrow
			{
			get;
			set;
			}

		#endregion

		#region Constructors
		public SpellModel()
			{
			SpellName = "";
			SpellSchoolId = SpellSchoolModel.GetIdFromName(DefaultSpellSchool);
			SpellRange = DefaultSpellRange;
			Description = DefaultDescription;
			IconFilename = DefaultImageName;
			SpellComponents = 0;
			MetamagicFeats = 0;
			Targets = 0;
			Duration = DefaultDuration;
			SpellResistance = false;
			SavingThrow = DefaultSavingThrow;
			}
		#endregion

		#region Public Static Methods
		/// <summary>
		/// Gets all the race names
		/// </summary>
		/// <returns>A list of all the Race names.</return>
		public static List<string> GetNames()
			{
			QueryInformation query;

			query = QueryInformation.Create(LoadNamesQuery);
			query.CommandType = CommandType.Text;

			return BaseModel.GetNames(query, ReadNames);
			}

        /// <summary>
        /// Get the Ablity id of the specified Save
        /// </summary>
        /// <param name="name">Name of the Save</param>
        /// <returns>An Id of the Save</returns>
        public static Guid GetIdFromName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(SpellModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + SpellModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, SpellModel.ReadId);
            if (ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
            }
		#endregion

		#region Public Methods
		/// <summary>
		/// Creates the specified spell by Name.
		/// </summary>
		/// <param name="spellName">Name of the spell.</param>
		public void Initialize(string spellName)
			{
			QueryInformation query;

			if (string.IsNullOrWhiteSpace(spellName))
				return;

			query = QueryInformation.Create(LoadSpellByNameQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + NameField, DbType.String, spellName));

			this.Initialize(query);
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
			query.Parameters.Add(new QueryParameter("@" + NameField, DbType.String, SpellName));
			query.Parameters.Add(new QueryParameter("@" + SpellSchoolIdField, DbType.Guid, SpellSchoolId));
			query.Parameters.Add(new QueryParameter("@" + SpellRangeField, DbType.String, SpellRange));
			query.Parameters.Add(new QueryParameter("@" + SpellDescriptionField, DbType.String, Description));
			query.Parameters.Add(new QueryParameter("@" + SpellIconField, DbType.String, IconFilename));
			query.Parameters.Add(new QueryParameter("@" + ComponentsField, DbType.Int16, SpellComponents));
			query.Parameters.Add(new QueryParameter("@" + MetamagicFeatsField, DbType.Int16, MetamagicFeats));
			query.Parameters.Add(new QueryParameter("@" + TargetsField, DbType.Int16, Targets));
			query.Parameters.Add(new QueryParameter("@" + DurationField, DbType.String, Duration));
			query.Parameters.Add(new QueryParameter("@" + SpellResistanceField, DbType.Boolean, SpellResistance));
			query.Parameters.Add(new QueryParameter("@" + SavingThrowField, DbType.String, SavingThrow));
			query.Parameters.Add(new QueryParameter("@" + LastUpdatedDateField, DbType.DateTime, LastUpdatedDate));
			query.Parameters.Add(new QueryParameter("@" + LastUpdatedVersionField, DbType.String, LastUpdatedVersion));
			BaseModel.RunCommand(query);

			return;
			}

		public void Delete()
			{
			QueryInformation query;

			//get rid of anything in the spell detail model table
			SpellDetailsModel.DeleteBySpell(Id);

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
					SpellName = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(SpellSchoolIdField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					SpellSchoolId = reader.GetGuid(ordinal);
					}
				}

			if (reader.TryGetOrdinal(SpellRangeField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					SpellRange = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(SpellDescriptionField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					Description = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(SpellIconField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					IconFilename = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ComponentsField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					SpellComponents = (ushort)(reader.GetInt16(ordinal));
					}
				}

			if (reader.TryGetOrdinal(MetamagicFeatsField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					MetamagicFeats = (ushort)(reader.GetInt16(ordinal));
					}
				}

			if (reader.TryGetOrdinal(TargetsField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					Targets = (ushort)(reader.GetInt16(ordinal));
					}
				}

			if (reader.TryGetOrdinal(DurationField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					Duration = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(SpellResistanceField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					SpellResistance = reader.GetBoolean(ordinal);
					}
				}

			if (reader.TryGetOrdinal(SavingThrowField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					SavingThrow = reader.GetString(ordinal);
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

		#region Private Static Methods
		/// <summary>
		/// Reads the names.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <returns>The read id and name.</returns>
		private static string ReadNames(DbDataReader reader)
			{
			int ordinal;
			string name = null;

			if (reader == null)
				{
				return null;
				}

			if (reader.TryGetOrdinal(NameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					name = reader.GetString(ordinal);
					}
				}

			return name;
			}

        /// <summary>
        /// Read the Id
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <returns>The Id</returns>
        private static Guid ReadId(DbDataReader reader)
            {
            int ordinal;
            Guid id = Guid.Empty;

            if (reader == null)
                return Guid.Empty;

            if (reader.TryGetOrdinal(SpellModel.IdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    id = reader.GetGuid(ordinal);
                }
            return id;
            }
		#endregion

		#region Private Methods
		public static bool DoesNameExist(string name)
			{
			QueryInformation query;

			query = QueryInformation.Create(NameCountQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + NameField, DbType.String, name));

			return BaseModel.GetCount(query) > 0;
			}
		#endregion
		}
	}
