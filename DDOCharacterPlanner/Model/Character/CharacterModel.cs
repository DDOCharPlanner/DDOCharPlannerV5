using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using DDOCharacterPlanner.DataAccess;
using DDOCharacterPlanner.Screens.Controls;
using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Model
	{
	/// <summary>
	/// Defines data availability for a Character
	/// </summary>
	public sealed class CharacterModel : BaseModel
		{
		#region Private Constants
		private const string IdField = "CharacterId";
		private const string LevelField = "Level";
		private const string HitPointsField = "HitPoints";
		private const string FortitudeSaveField = "FortitudeSave";
		private const string ReflexSaveField = "ReflexSave";
		private const string WillSaveField = "WillSave";
		private const string BaseAttackBonusField = "BaseAttackBonus";
		private const string FeatTypeIdField = "FeatTypeId";
		private const string LastUpdatedDateField = "LastUpdatedDate";
		private const string LastUpdatedVersionField = "LastUpdatedVersion";

		private const string LoadCharacterByLevelQuery = "SELECT * FROM Character WHERE Level=@Level";
		private const string LoadCharacterByIdQuery = "SELECT * FROM Character WHERE CharacterId=@CharacterId";
		private const string LoadCharactersQuery = "SELECT * FROM Character";

		private const string InsertQuery = "INSERT INTO Character (CharacterId, Level, HitPoints, FortitudeSave, ReflexSave, WillSave, BaseAttackBonus, FeatTypeId, LastUpdatedDate, LastUpdatedVersion) VALUES (@CharcterId, @Level, @HitPoints, @FortitudeSave, @ReflexSave, @WillSave, @BaseAttackBonus, @FeatTypeId, @LastUpdatedDate, @LastUpdatedVersion)";
		private const string UpdateQuery = "UPDATE Character SET Level=@Level, HitPoints=@HitPoints, FortitudeSave=@FortitudeSave, ReflexSave=@ReflexSave, WillSave=@WillSave, BaseAttackBonus=@BaseAttackBonus, FeatTypeId=@FeatTypeId, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE CharacterId=@CharacterId";
		#endregion

		#region Properties
		public int Level
			{
			get;
			set;
			}

		public int HitPoints
			{
			get;
			set;
			}

		public int FortitudeSave
			{
			get;
			set;
			}

		public int ReflexSave
			{
			get;
			set;
			}

		public int WillSave
			{
			get;
			set;
			}

		public int BaseAttackBonus
			{
			get;
			set;
			}

		public Guid FeatTypeId
			{
			get;
			set;
			}
		#endregion

		#region Private Static Methods
		private static CharacterModel Create(DbDataReader reader)
			{
			CharacterModel model;

			model = new CharacterModel();

			if (reader == null)
				return model;

			model.Load(reader);

			return model;
			}
		#endregion

		#region Protected Methods
		/// <summary>
		/// Loads the specified reader.
		/// </summary>
		/// <param level="reader">The reader.</param>
		protected override void Load(DbDataReader reader)
			{
			int ordinal;

			if (reader == null)
				{
				return;
				}

			if (!reader.TryGetOrdinal(CharacterModel.IdField, out ordinal))
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

			if (reader.TryGetOrdinal(CharacterModel.LevelField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.Level = reader.GetByte(ordinal);
					}
				}

			if (reader.TryGetOrdinal(CharacterModel.HitPointsField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.HitPoints = reader.GetByte(ordinal);
					}
				else
					{
					this.HitPoints = 0;
					}
				}

			if (reader.TryGetOrdinal(CharacterModel.FortitudeSaveField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.FortitudeSave = reader.GetByte(ordinal);
					}
				else
					{
					this.FortitudeSave = 0;
					}
				}

			if (reader.TryGetOrdinal(CharacterModel.ReflexSaveField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.ReflexSave = reader.GetByte(ordinal);
					}
				else
					{
					this.ReflexSave = 0;
					}
				}

			if (reader.TryGetOrdinal(CharacterModel.WillSaveField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.WillSave = reader.GetByte(ordinal);
					}
				else
					{
					this.WillSave = 0;
					}
				}

			if (reader.TryGetOrdinal(CharacterModel.BaseAttackBonusField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.BaseAttackBonus = reader.GetByte(ordinal);
					}
				else
					{
					this.BaseAttackBonus = 0;
					}
				}

			if (reader.TryGetOrdinal(CharacterModel.FeatTypeIdField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.FeatTypeId = reader.GetGuid(ordinal);
					}
				else
					{
					this.FeatTypeId = Guid.Empty;
					}
				}
			}

		#endregion

		#region Public Methods
		/// <summary>
		/// Creates the specified character level.
		/// </summary>
		/// <param level="characerlevel">Character level.</param>
		public void Intialize(int characterlevel)
			{
			QueryInformation query;

			if (characterlevel == 0)
				{
				return;
				}

			query = QueryInformation.Create(CharacterModel.LoadCharacterByLevelQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + CharacterModel.LevelField, DbType.Byte, characterlevel));

			this.Initialize(query);
			}

		public void Initialize(Guid characterId)
			{
			QueryInformation query;

			if (characterId == Guid.Empty)
				{
				return;
				}

			query = QueryInformation.Create(CharacterModel.LoadCharacterByIdQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + CharacterModel.IdField, DbType.Guid, characterId));

			this.Initialize(query);
			}

		public void Save()
			{
			QueryInformation query;

			if (this.Id == Guid.Empty)
				{
				query = QueryInformation.Create(CharacterModel.InsertQuery);
				this.Id = Guid.NewGuid();
				}
			else
				{
				query = QueryInformation.Create(CharacterModel.UpdateQuery);
				}

			//update the last modified fields
			LastUpdatedDate = DateTime.Now;
			LastUpdatedVersion = Constant.PlannerVersion;

			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + CharacterModel.IdField, DbType.Guid, this.Id));
			query.Parameters.Add(new QueryParameter("@" + CharacterModel.LevelField, DbType.Byte, this.Level));
			query.Parameters.Add(new QueryParameter("@" + CharacterModel.HitPointsField, DbType.Byte, this.HitPoints));
			query.Parameters.Add(new QueryParameter("@" + CharacterModel.FortitudeSaveField, DbType.Byte, this.FortitudeSave));
			query.Parameters.Add(new QueryParameter("@" + CharacterModel.ReflexSaveField, DbType.Byte, this.ReflexSave));
			query.Parameters.Add(new QueryParameter("@" + CharacterModel.WillSaveField, DbType.Byte, this.WillSave));
			query.Parameters.Add(new QueryParameter("@" + CharacterModel.BaseAttackBonusField, DbType.Byte, this.BaseAttackBonus));
			query.Parameters.Add(new QueryParameter("@" + CharacterModel.FeatTypeIdField, DbType.Guid, this.FeatTypeId));
			query.Parameters.Add(new QueryParameter("@" + CharacterModel.LastUpdatedDateField, DbType.DateTime, this.LastUpdatedDate));
			query.Parameters.Add(new QueryParameter("@" + CharacterModel.LastUpdatedVersionField, DbType.String, this.LastUpdatedVersion));

			BaseModel.RunCommand(query);
			}
		#endregion

		#region Public Static Methods
		/// <summary>
		/// Gets the levels
		/// </summary>
		/// <returns>A list of all the character levels.</returns>
		public static List<byte> GetLevels()
			{
			List<byte> results;
			List<CharacterModel> modelList;
			QueryInformation query;

			modelList = new List<CharacterModel>();
			query = QueryInformation.Create(LoadCharactersQuery);
			query.CommandType = CommandType.Text;
			modelList = BaseModel.GetAll<CharacterModel>(query, Create);

			results = new List<byte>();
			foreach (CharacterModel model in modelList)
				results.Add((byte)model.Level);

			return results;
			}
        public static List<CharacterModel> GetAll()
        {
          
            List<CharacterModel> modelList;
            QueryInformation query;

            modelList = new List<CharacterModel>();
            query = QueryInformation.Create(LoadCharactersQuery);
            query.CommandType = CommandType.Text;
            modelList = BaseModel.GetAll<CharacterModel>(query, Create);

            return modelList;
        }
		#endregion
		}
	}
