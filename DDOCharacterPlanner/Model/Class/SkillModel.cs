using DDOCharacterPlanner.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DDOCharacterPlanner.Model
	{

	public sealed class SkillModel : BaseModel
		{
		#region Private Constants
		private const string IdField = "SkillId";
		private const string NameField = "Name";
		private const string DescriptionField = "Description";
		private const string IsClassOnlyField = "IsClassOnly";
		private const string LastUpdatedDateField = "LastUpdatedDate";
		private const string LastUpdatedVersionField = "LastUpdatedVersion";
		private const string ImageFileNameField = "ImageFileName";
        private const string AbilityModifierField = "AbilityModifier";
		private const string LoadAllQuery = "SELECT * FROM Skill";
		private const string LoadNamesQuery = "SELECT SkillId, Name FROM Skill";
		private const string LoadAllForClassQuery = "SELECT * FROM Skill s, ClassSkill cs WHERE s.SkillId = cs.SkillId AND cs.ClassId=@ClassId";
        private const string GetIdFromNameQuery = "SELECT SkillId FROM Skill WHERE Name=@Name";
        private const string GetNameFromIdQuery = "SELECT Name FROM Skill WHERE SkillId=@SkillId";
		private const string CountQuery = "SELECT COUNT(*) AS Count FROM Skill";
        private const string IsClassOnlyByNameQuery = "SELECT IsClassOnly FROM Skill WHERE Name=@Name";
		#endregion

		#region Properties
		public string Name
			{
			get;
			set;
			}

		public string Description
			{
			get;
			set;
			}

		public bool IsClassOnly
			{
			get;
			set;
			}

		public string ImageFileName
			{
			get;
			set;
			}
        public string AbilityModifier
            {
            get;
            set;
            }

		#endregion

		#region Private Static Methods
		private static SkillModel Create(DbDataReader reader)
			{
			SkillModel model;

			model = new SkillModel();
			model.Load(reader);

			return model;
			}

		private static Dictionary<Guid, string>  ReadNameById(DbDataReader reader)
			{
			int ordinal;
			Guid id;
			string name = null;
            Dictionary<Guid, string> value = new Dictionary<Guid,string>();


			if (reader == null)
				{
				return null;
				}

			if (!reader.TryGetOrdinal(SkillModel.IdField, out ordinal))
				{
				// No ID field, can't use
				return null;
				}

			if (reader.IsDBNull(ordinal))
				{
				// Null, can't use
				return null;
				}

			id = reader.GetGuid(ordinal);

			if (reader.TryGetOrdinal(SkillModel.NameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					name = reader.GetString(ordinal);
					}
				}

            value.Add(id,name);
			return value;
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

            if (reader.TryGetOrdinal(SkillModel.IdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    id = reader.GetGuid(ordinal);
                }
            return id;
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

			if (reader.TryGetOrdinal(SkillModel.NameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					name = reader.GetString(ordinal);
					}
				}
			return name;
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

			if (!reader.TryGetOrdinal(SkillModel.IdField, out ordinal))
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

			if (reader.TryGetOrdinal(SkillModel.NameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.Name = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(SkillModel.DescriptionField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.Description = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(SkillModel.IsClassOnlyField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.IsClassOnly = reader.GetBoolean(ordinal);
					}
				}

			if (reader.TryGetOrdinal(SkillModel.LastUpdatedDateField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.LastUpdatedDate = reader.GetDateTime(ordinal);
					}
				}

			if (reader.TryGetOrdinal(SkillModel.LastUpdatedVersionField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.LastUpdatedVersion = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(SkillModel.ImageFileNameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.ImageFileName = reader.GetString(ordinal);
					}
				}
            if (reader.TryGetOrdinal(SkillModel.AbilityModifierField, out ordinal))
            {
                if (!reader.IsDBNull(ordinal))
                {
                    this.AbilityModifier = reader.GetString(ordinal);
                }
            }
			}
		#endregion

		#region Public Methods
		#endregion

		#region Public Static Methods
		public static List<SkillModel> GetAll()
			{
			QueryInformation query;

			query = QueryInformation.Create(SkillModel.LoadAllQuery);
			query.CommandType = CommandType.Text;

			return BaseModel.GetAll<SkillModel>(query, SkillModel.Create);
			}

		public static List<SkillModel> GetAllForClass(Guid classId)
			{
			QueryInformation query;

			if (classId == Guid.Empty)
				{
                return new List<SkillModel>();
				}

			query = QueryInformation.Create(SkillModel.LoadAllForClassQuery);
			query.Parameters.Add(new QueryParameter("@ClassId", DbType.Guid, classId));
			query.CommandType = CommandType.Text;

			return BaseModel.GetAll<SkillModel>(query, SkillModel.Create);
			}


		/// <summary>
		/// Gets the names.
		/// </summary>
		/// <returns>A list of all the skill names.</returns>
		public static List<string> GetNames()
			{
			QueryInformation query;

			query = QueryInformation.Create(SkillModel.LoadNamesQuery);
			query.CommandType = CommandType.Text;

			return BaseModel.GetNames(query, SkillModel.ReadName);
			}

        public static Dictionary<Guid, string> GetNamesByID()
        {
            QueryInformation query;

            query = QueryInformation.Create(SkillModel.LoadNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNamesByID(query, SkillModel.ReadNameById);
        }

        /// <summary>
        /// Get the Skill id of the specified Skill
        /// </summary>
        /// <param name="name">Name of the Skill</param>
        /// <returns>An Id of the Skill</returns>
        public static Guid GetIdFromName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(SkillModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + SkillModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, SkillModel.ReadId);
            if (ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
            }

		public static string GetNameFromId(Guid skillId)
			{
			QueryInformation query;
			List<string> names;

			query = QueryInformation.Create(GetNameFromIdQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + IdField, DbType.Guid, skillId));

			names = BaseModel.GetNames(query, ReadName);
			if (names == null)
				return "";
			else
				return names[0];
			}

		public static int GetNumSkills()
			{
			QueryInformation query;

			query = QueryInformation.Create(CountQuery);
			query.CommandType = CommandType.Text;

			return BaseModel.GetCount(query);
			}

        public static bool GetIsClassOnly(string Name)
        {
            QueryInformation query;


            query = QueryInformation.Create(IsClassOnlyByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + NameField, DbType.String, Name));


            return  BaseModel.GetBoolean(query);
        }

		#endregion
		}
	}
