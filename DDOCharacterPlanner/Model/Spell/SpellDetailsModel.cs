using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DDOCharacterPlanner.Model
	{
	class SpellDetailsModel : BaseModel
		{
		#region Private Constants
		//fields
		private const string IdField = "SpellDetailsId";
		private const string LastUpdatedDateField = "LastUpdatedDate";
		private const string LastUpdatedVersionField = "LastUpdatedVersion";
		private const string SpellIdField = "SpellId";
		private const string ClassIdField = "ClassId";
		private const string LevelField = "Level";
		private const string SPCostField = "SPCost";
		private const string CooldownField = "Cooldown";
		//queries
		private const string LoadDetailsBySpellIdQuery = "SELECT * FROM SpellDetails WHERE SpellId=@SpellId";
		private const string InsertQuery = "INSERT INTO SpellDetails (SpellDetailsId, LastUpdatedDate, LastUpdatedVersion, SpellId, ClassId, Level, SPCost, Cooldown) VALUES (@SpellDetailsId, @LastUpdatedDate, @LastUpdatedVersion, @SpellId, @ClassId, @Level, @SPCost, @Cooldown)";
		private const string DeleteQuery = "DELETE FROM SpellDetails WHERE SpellId=@SpellId";
		#endregion

		#region Properties
		public Guid SpellId
			{
			get;
			set;
			}

		public Guid ClassId
			{
			get;
			set;
			}

		public int Level
			{
			get;
			set;
			}

		public int SPCost
			{
			get;
			set;
			}

		public string Cooldown
			{
			get;
			set;
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

			if (reader.TryGetOrdinal(SpellIdField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					SpellId = reader.GetGuid(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassIdField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					ClassId = reader.GetGuid(ordinal);
					}
				}

			if (reader.TryGetOrdinal(LevelField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					Level = reader.GetByte(ordinal);
					}
				}

			if (reader.TryGetOrdinal(SPCostField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					SPCost = reader.GetByte(ordinal);
					}
				}

			if (reader.TryGetOrdinal(CooldownField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					Cooldown = reader.GetString(ordinal);
					}
				}
			}
		#endregion

		#region Public Methods
		public void Save()
			{
			QueryInformation query;

			query = QueryInformation.Create(InsertQuery);
			Id = Guid.NewGuid();

			//update the last modified fields
			LastUpdatedDate = DateTime.Now;
			LastUpdatedVersion = Constant.PlannerVersion;

			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + IdField, DbType.Guid, Id));
			query.Parameters.Add(new QueryParameter("@" + LastUpdatedDateField, DbType.DateTime, LastUpdatedDate));
			query.Parameters.Add(new QueryParameter("@" + LastUpdatedVersionField, DbType.String, LastUpdatedVersion));
			query.Parameters.Add(new QueryParameter("@" + SpellIdField, DbType.Guid, SpellId));
			query.Parameters.Add(new QueryParameter("@" + ClassIdField, DbType.Guid, ClassId));
			query.Parameters.Add(new QueryParameter("@" + LevelField, DbType.Byte, Level));
			query.Parameters.Add(new QueryParameter("@" + SPCostField, DbType.Byte, SPCost));
			query.Parameters.Add(new QueryParameter("@" + CooldownField, DbType.String, Cooldown));
			BaseModel.RunCommand(query);

			return;
			}
		#endregion

		#region Public static methods
		public static void DeleteBySpell(Guid spellId)
			{
			QueryInformation query;

			query = QueryInformation.Create(DeleteQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + SpellIdField, DbType.Guid, spellId));
			BaseModel.RunCommand(query);
			}

		/// <summary>
		/// gets a list of models associated with the spell id.
		/// </summary>
		/// <returns>A list of all the class names.</returns>
		public static List<SpellDetailsModel> GetAll(Guid spellId)
			{
			QueryInformation query;

			if (spellId == Guid.Empty)
				return new List<SpellDetailsModel>();

			query = QueryInformation.Create(LoadDetailsBySpellIdQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + SpellIdField, DbType.Guid, spellId));

			return BaseModel.GetAll<SpellDetailsModel>(query, Create);
			}
		#endregion

		#region Private Static Methods
		private static SpellDetailsModel Create(DbDataReader reader)
			{
			SpellDetailsModel model;

			model = new SpellDetailsModel();
			model.Load(reader);

			return model;
			}
		#endregion
		}
	}
