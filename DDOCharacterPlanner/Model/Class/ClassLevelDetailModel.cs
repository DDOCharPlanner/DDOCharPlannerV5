using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DDOCharacterPlanner.Model
	{

	public sealed class ClassLevelDetailModel : BaseModel
		{
		#region Private Constants
		//fields
		private const string IdField = "ClassLevelDetailsId";
		private const string ClassIdField = "ClassId";
		private const string LevelField = "Level";
		private const string FortitudeSaveField = "FortitudeSave";
		private const string ReflexSaveField = "ReflexSave";
		private const string WillSaveField = "WillSave";
		private const string BaseAttackBonusField = "BaseAttackBonus";
		private const string FeatTypeIdField = "FeatTypeId";
		private const string LastUpdatedDateField = "LastUpdatedDate";
		private const string LastUpdatedVersionField = "LastUpdatedVersion";
		//queries
		private const string LoadDetailsByClassIdQuery = "SELECT * FROM ClassLevelDetails WHERE ClassId=@ClassId ORDER BY Level";
		private const string InsertQuery = "INSERT INTO ClassLevelDetails (ClassLevelDetailsId, ClassId, Level, FortitudeSave, ReflexSave, WillSave, BaseAttackBonus,FeatTypeId, LastUpdatedDate, LastUpdatedVersion) VALUES (@ClassLevelDetailsId, @ClassId, @Level, @FortitudeSave, @ReflexSave, @WillSave, @BaseAttackBonus, @FeatTypeId,  @LastUpdatedDate, @LastUpdatedVersion)";
		private const string UpdateQuery = "UPDATE ClassLevelDetails SET ClassId=@ClassId, Level=@Level, FortitudeSave=@FortitudeSave, ReflexSave=@ReflexSave, WillSave=@WillSave, BaseAttackBonus=@BaseAttackBonus, FeatTypeId=@FeatTypeId, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE ClassLevelDetailsId=@ClassLevelDetailsId";
		private const string DeleteQuery = "DELETE FROM ClassLevelDetails WHERE ClassId=@ClassId";
		#endregion

		#region Properties
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
		private static ClassLevelDetailModel Create(DbDataReader reader)
			{
			ClassLevelDetailModel model;

			model = new ClassLevelDetailModel();
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

			if (!reader.TryGetOrdinal(ClassLevelDetailModel.IdField, out ordinal))
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

			if (reader.TryGetOrdinal(ClassLevelDetailModel.ClassIdField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.ClassId = reader.GetGuid(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassLevelDetailModel.LevelField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.Level = reader.GetByte(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassLevelDetailModel.FortitudeSaveField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.FortitudeSave = reader.GetInt32(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassLevelDetailModel.ReflexSaveField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.ReflexSave = reader.GetInt32(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassLevelDetailModel.WillSaveField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.WillSave = reader.GetInt32(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassLevelDetailModel.BaseAttackBonusField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.BaseAttackBonus = reader.GetInt32(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassLevelDetailModel.FeatTypeIdField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.FeatTypeId = reader.GetGuid(ordinal);
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

		#region Public Methods
		public void Save()
			{
			QueryInformation query;

			if (this.Id == Guid.Empty)
				{
				query = QueryInformation.Create(ClassLevelDetailModel.InsertQuery);
				this.Id = Guid.NewGuid();
				}
			else
				{
				query = QueryInformation.Create(ClassLevelDetailModel.UpdateQuery);
				}

			//update the last modified fields
			LastUpdatedDate = DateTime.Now;
			LastUpdatedVersion = Constant.PlannerVersion;

			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassLevelDetailModel.IdField, DbType.Guid, this.Id));
			query.Parameters.Add(new QueryParameter("@" + ClassLevelDetailModel.ClassIdField, DbType.Guid, this.ClassId));
			query.Parameters.Add(new QueryParameter("@" + ClassLevelDetailModel.LevelField, DbType.Byte, this.Level));
			query.Parameters.Add(new QueryParameter("@" + ClassLevelDetailModel.FortitudeSaveField, DbType.Int32, this.FortitudeSave));
			query.Parameters.Add(new QueryParameter("@" + ClassLevelDetailModel.ReflexSaveField, DbType.Int32, this.ReflexSave));
			query.Parameters.Add(new QueryParameter("@" + ClassLevelDetailModel.WillSaveField, DbType.Int32, this.WillSave));
			query.Parameters.Add(new QueryParameter("@" + ClassLevelDetailModel.BaseAttackBonusField, DbType.Int32, this.BaseAttackBonus));
			query.Parameters.Add(new QueryParameter("@" + ClassLevelDetailModel.FeatTypeIdField, DbType.Guid, this.FeatTypeId));
			query.Parameters.Add(new QueryParameter("@" + LastUpdatedDateField, DbType.DateTime, LastUpdatedDate));
			query.Parameters.Add(new QueryParameter("@" + LastUpdatedVersionField, DbType.String, LastUpdatedVersion));

			BaseModel.RunCommand(query);
			}

		public void Delete()
			{
			QueryInformation query;

			query = QueryInformation.Create(DeleteQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassIdField, DbType.Guid, ClassId));
			BaseModel.RunCommand(query);
			}
		#endregion

		#region Public Static Methods
		/// <summary>
		/// Gets the names.
		/// </summary>
		/// <returns>A list of all the class names.</returns>
		public static List<ClassLevelDetailModel> GetAll(Guid classId)
			{
			QueryInformation query;

			if (classId == Guid.Empty)
				{
				return null;
				}

			query = QueryInformation.Create(ClassLevelDetailModel.LoadDetailsByClassIdQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@ClassId", DbType.Guid, classId));

			return BaseModel.GetAll<ClassLevelDetailModel>(query, ClassLevelDetailModel.Create);
			}

		#endregion
		}
	}
