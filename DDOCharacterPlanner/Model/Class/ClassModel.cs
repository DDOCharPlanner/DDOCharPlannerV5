using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using DDOCharacterPlanner.DataAccess;
using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Model
	{

	/// <summary>
	/// Defines data availability for a class.
	/// </summary>
	public sealed class ClassModel : BaseModel
		{
		#region Private Constants
		//fields
		private const string IdField = "ClassId";
		private const string LastUpdatedDateField = "LastUpdatedDate";
		private const string LastUpdatedVersionField = "LastUpdatedVersion";
		private const string NameField = "Name";
		private const string AbbreviationField = "Abbreviation";
		private const string DescriptionField = "Description";
		private const string HitDieField = "HitDie";
		private const string SkillPointsField = "SkillPoints";
		private const string StartingDestinySphereIdField = "StartingDestinySphereId";
		private const string ReincarnationPriorityField = "ReincarnationPriority";
		private const string ImageFileNameField = "ImageFileName";
		private const string SequenceField = "Sequence";
        private const string PastLifeFeatIdField = "PastLifeFeatId";
		private const string MaxSpellLevelField = "MaxSpellLevel";
		//queries
		private const string LoadClassByNameQuery = "SELECT * FROM Class WHERE Name=@Name";
		private const string LoadClassByAbbreviationQuery = "SELECT * FROM Class WHERE Abbreviation=@Abbreviation";
		private const string LoadClassByIdQuery = "SELECT * FROM Class WHERE ClassId=@ClassId";
		private const string LoadClassBySequenceQuery = "SELECT * FROM Class WHERE Sequence=@Sequence";
		private const string LoadClassByReincarnationPriorityQuery = "SELECT * FROM Class WHERE ReincarnationPriority=@ReincarnationPriority";
		private const string LoadNamesBySequenceQuery = "SELECT ClassId, Name FROM Class ORDER BY Sequence";
		private const string LoadNamesByReincarnationQuery = "SELECT ClassId, Name FROM Class ORDER BY ReincarnationPriority";
		private const string LoadNameFromIDQuery = "SELECT Name FROM Class WHERE ClassId=@ClassId";
		private const string LoadIDFromNameQuery = "SELECT ClassId FROM Class WHERE Name=@Name";
		private const string LoadClassesQuery = "SELECT * FROM Class ORDER BY Sequence";
		private const string InsertQuery = "INSERT INTO Class (ClassId, Name, Abbreviation, Description, HitDie, SkillPoints, StartingDestinySphereId, ReincarnationPriority, ImageFileName, LastUpdatedDate, LastUpdatedVersion, Sequence, MaxSpellLevel) VALUES (@ClassId, @Name, @Abbreviation, @Description, @HitDie, @SkillPoints, @StartingDestinySphereId, @ReincarnationPriority, @ImageFileName, @LastUpdatedDate, @LastUpdatedVersion, @Sequence, @MaxSpellLevel)";
		private const string UpdateQuery = "UPDATE Class SET Name=@Name, Abbreviation=@Abbreviation, Description=@Description, HitDie=@HitDie, SkillPoints=@SkillPoints, StartingDestinySphereId=@StartingDestinySphereId, ReincarnationPriority=@ReincarnationPriority, ImageFileName=@ImageFileName, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion, Sequence=@Sequence, MaxSpellLevel=@MaxSpellLevel WHERE ClassId=@ClassId";
		private const string UpdateSequenceQuery = "UPDATE Class SET Sequence=@Sequence WHERE ClassId=@ClassId";
		private const string UpdateReincarnationPriorityQuery = "UPDATE Class SET ReincarnationPriority=@ReincarnationPriority WHERE ClassId=@ClassId";
		private const string DeleteQuery = "DELETE FROM Class WHERE ClassId=@ClassId";
		private const string DeleteAlignmentsQuery = "DELETE FROM ClassAlignmentsAllowed WHERE ClassId=@ClassId";
		private const string InsertAlignmentAllowedQuery = "INSERT INTO ClassAlignmentsAllowed (ClassId, AlignmentId, LastUpdatedDate, LastUpdatedVersion) VALUES (@ClassId, @AlignmentId, @LastUpdatedDate, @LastUpdatedVersion)";
		private const string DeleteClassSkillsQuery = "DELETE FROM ClassSkill WHERE ClassId=@ClassId";
		private const string InsertClassSkillQuery = "INSERT INTO ClassSkill (ClassId, SkillId, LastUpdatedDate, LastUpdatedVersion) VALUES (@ClassId, @SkillId, @LastUpdatedDate, @LastUpdatedVersion)";
		private const string CountQuery = "SELECT COUNT(*) AS Count FROM Class";
		private const string NameCountQuery = "SELECT COUNT(*) AS Count FROM Class WHERE Name=@Name";
		private const string AbbreviationCountQuery = "SELECT COUNT(*) AS Count FROM Class WHERE Abbreviation=@Abbreviation";
        private const string UpdatePastLifeFeatIdByPastLifeFeatIdQuery = "UPDATE Class SET PastLifeFeatId=@NewValue WHERE PastLifeFeatId=@PastLifeFeatId";
		//default values for the constructor
		private const string DefaultName = "New Class";
		private const string DefaultAbbreviation = "NEW";
		private const string DefaultImageFilename = "NoImage";
		private const string DefaultDescription = "<HTML><body style=\"background: #000000\"><font color=\"white\"><p><B>Bold Text</b></p><p>Regular Text</p><p>Important stats</p><p>Strength...</p></font></body></HTML>";

 
		#endregion

		#region Properties
		public string Name
			{
			get;
			set;
			}

		public string Abbreviation
			{
			get;
			set;
			}

		public string Description
			{
			get;
			set;
			}

		public int HitDie
			{
			get;
			set;
			}

		public int SkillPoints
			{
			get;
			set;
			}

		public List<AlignmentModel> AllowedAlignments
			{
			get;
			set;
			}

		public List<SkillModel> ClassSkills
			{
			get;
			set;
			}

		public int MaxSpellLevel
			{
			get;
			set;
			}

		public Guid StartingDestinySphereId
			{
			get;
			set;
			}

		public int ReincarnationPriority
			{
			get;
			set;
			}

		public string ImageFilename
			{
			get;
			set;
			}

		public ClassLevelDetailModel[] LevelDetails
			{
			get;
			private set;
			}

		public int Sequence
			{
			get;
			set;
			}
		#endregion

		#region Constructors
		public ClassModel()
			{
			QueryInformation query;
			List<string> destinyNames;
			DestinySphereModel DefaultDestiny;

			//set up default values for properties where needed
			Name = DefaultName;
			Abbreviation = DefaultAbbreviation;

			//starting destiny sphere
			destinyNames = DestinySphereModel.GetNames();
			DefaultDestiny = new DestinySphereModel();
			DefaultDestiny.Initialize(destinyNames[0]);
			MaxSpellLevel = 0;
			StartingDestinySphereId = DefaultDestiny.Id;

			ImageFilename = DefaultImageFilename;
			Description = DefaultDescription;
			LevelDetails = new ClassLevelDetailModel[Constant.NumHeroicLevels];
			for (int i=0; i<Constant.NumHeroicLevels; i++)
				LevelDetails[i] = new ClassLevelDetailModel();
			
			//the sequence and reincarnation priority number (default to last record in sequence)
			query = QueryInformation.Create(ClassModel.CountQuery); 
			query.CommandType = CommandType.Text;
			Sequence = BaseModel.GetCount(query);
			ReincarnationPriority = Sequence;
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

			if (!reader.TryGetOrdinal(ClassModel.IdField, out ordinal))
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

			if (reader.TryGetOrdinal(ClassModel.NameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					Name = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassModel.AbbreviationField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					Abbreviation = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassModel.DescriptionField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					Description = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassModel.HitDieField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					HitDie = reader.GetByte(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassModel.SkillPointsField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					SkillPoints = reader.GetByte(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassModel.StartingDestinySphereIdField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					StartingDestinySphereId = reader.GetGuid(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassModel.ReincarnationPriorityField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					ReincarnationPriority = reader.GetByte(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassModel.ImageFileNameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					ImageFilename = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassModel.LastUpdatedDateField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					LastUpdatedDate = reader.GetDateTime(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassModel.LastUpdatedVersionField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					LastUpdatedVersion = reader.GetString(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassModel.SequenceField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					Sequence = reader.GetByte(ordinal);
					}
				}

			if (reader.TryGetOrdinal(ClassModel.MaxSpellLevelField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					MaxSpellLevel = reader.GetByte(ordinal);
					}
				}


			AllowedAlignments = AlignmentModel.GetAllForClass(Id);
			ClassSkills = SkillModel.GetAllForClass(Id);
			LevelDetails = ClassLevelDetailModel.GetAll(Id).ToArray();
			}
		#endregion

		#region Public Methods
		/// <summary>
		/// Creates the specified class name.
		/// </summary>
		/// <param name="className">Name of the class.</param>
		public void Initialize(string className)
			{
			QueryInformation query;

			if (string.IsNullOrWhiteSpace(className))
				{
				return;
				}

			query = QueryInformation.Create(ClassModel.LoadClassByNameQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.NameField, DbType.String, className));

			this.Initialize(query);
			}

		public void Initialize(Guid classId)
			{
			QueryInformation query;

			if (classId == Guid.Empty)
				{
				return;
				}

			query = QueryInformation.Create(ClassModel.LoadClassByIdQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.IdField, DbType.Guid, classId));

			this.Initialize(query);
			}

		public void Initialize(int sequence)
			{
			QueryInformation query;

			query = QueryInformation.Create(ClassModel.LoadClassBySequenceQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.SequenceField, DbType.Byte, sequence));

			this.Initialize(query);
			}

		public void InitializeByReincarnationPriority(int reincarnationPriority)
			{
			QueryInformation query;

			query = QueryInformation.Create(ClassModel.LoadClassByReincarnationPriorityQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.ReincarnationPriorityField, DbType.Byte, reincarnationPriority));

			this.Initialize(query);
			}

		public void Save()
			{
			QueryInformation query;

			if (Id == Guid.Empty)
				{
				query = QueryInformation.Create(ClassModel.InsertQuery);
				Id = Guid.NewGuid();
				for(int i=0; i<LevelDetails.Length; i++)
					{
					LevelDetails[i].ClassId = Id;
					LevelDetails[i].Level = i+1;
					}
				}
			else
				{
				query = QueryInformation.Create(ClassModel.UpdateQuery);
				}

			//update the last modified fields
			LastUpdatedDate = DateTime.Now;
			LastUpdatedVersion = Constant.PlannerVersion;

			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.IdField, DbType.Guid, Id));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.NameField, DbType.String, Name));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.AbbreviationField, DbType.String, Abbreviation));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.DescriptionField, DbType.String, Description));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.HitDieField, DbType.Byte, HitDie));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.SkillPointsField, DbType.Byte, SkillPoints));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.StartingDestinySphereIdField, DbType.Guid, StartingDestinySphereId));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.ReincarnationPriorityField, DbType.Byte, ReincarnationPriority));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.ImageFileNameField, DbType.String, ImageFilename));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.LastUpdatedDateField, DbType.DateTime, LastUpdatedDate));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.LastUpdatedVersionField, DbType.String, LastUpdatedVersion));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.SequenceField, DbType.Byte, Sequence));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.MaxSpellLevelField, DbType.Byte, MaxSpellLevel));
			BaseModel.RunCommand(query);

			//allowed alignments
			query = QueryInformation.Create(ClassModel.DeleteAlignmentsQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.IdField, DbType.Guid, this.Id));
			BaseModel.RunCommand(query);
			if (AllowedAlignments != null)
				{
				for (int i = 0; i < this.AllowedAlignments.Count; i++)
					{
					query = QueryInformation.Create(ClassModel.InsertAlignmentAllowedQuery);
					query.CommandType = CommandType.Text;
					query.Parameters.Add(new QueryParameter("@" + ClassModel.IdField, DbType.Guid, this.Id));
					query.Parameters.Add(new QueryParameter("@AlignmentId", DbType.Guid, this.AllowedAlignments[i].Id));
					query.Parameters.Add(new QueryParameter("@" + ClassModel.LastUpdatedDateField, DbType.DateTime, LastUpdatedDate));
					query.Parameters.Add(new QueryParameter("@" + ClassModel.LastUpdatedVersionField, DbType.String, LastUpdatedVersion));
					BaseModel.RunCommand(query);
					}
				}

			//class skills
			query = QueryInformation.Create(ClassModel.DeleteClassSkillsQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.IdField, DbType.Guid, this.Id));
			BaseModel.RunCommand(query);
			if (ClassSkills != null)
				{
				for (int i = 0; i < this.ClassSkills.Count; i++)
					{
					query = QueryInformation.Create(ClassModel.InsertClassSkillQuery);
					query.CommandType = CommandType.Text;
					query.Parameters.Add(new QueryParameter("@" + ClassModel.IdField, DbType.Guid, this.Id));
					query.Parameters.Add(new QueryParameter("@SkillId", DbType.Guid, this.ClassSkills[i].Id));
					query.Parameters.Add(new QueryParameter("@" + ClassModel.LastUpdatedDateField, DbType.DateTime, LastUpdatedDate));
					query.Parameters.Add(new QueryParameter("@" + ClassModel.LastUpdatedVersionField, DbType.String, LastUpdatedVersion));
					BaseModel.RunCommand(query);
					}
				}

			//level details
			Array.ForEach(this.LevelDetails, item => item.Save());

			return;
 			}

		public void SaveSequence()
			{
			QueryInformation query;

			query = QueryInformation.Create(ClassModel.UpdateSequenceQuery);

			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.IdField, DbType.Guid, Id));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.SequenceField, DbType.Byte, Sequence));
			BaseModel.RunCommand(query);
			}

		public void SaveReincarnationPriority()
			{
			QueryInformation query;

			query = QueryInformation.Create(ClassModel.UpdateReincarnationPriorityQuery);

			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.IdField, DbType.Guid, Id));
			query.Parameters.Add(new QueryParameter("@" + ClassModel.ReincarnationPriorityField, DbType.Byte, ReincarnationPriority));
			BaseModel.RunCommand(query);
			}

		public void Delete()
			{
			QueryInformation query;

			//alignments
			query = QueryInformation.Create(ClassModel.DeleteAlignmentsQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.IdField, DbType.Guid, this.Id));
			BaseModel.RunCommand(query);

			//class skills
			query = QueryInformation.Create(ClassModel.DeleteClassSkillsQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.IdField, DbType.Guid, this.Id));
			BaseModel.RunCommand(query);

			//level details
			Array.ForEach(LevelDetails, item => item.Delete());

			//record
			query = QueryInformation.Create(ClassModel.DeleteQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.IdField, DbType.Guid, this.Id));
			BaseModel.RunCommand(query);
			}
		#endregion

		#region Public Static Methods
		/// <summary>
		/// Gets the names.
		/// </summary>
		/// <returns>A list of all the class names.</returns>
		public static List<string> GetNames(bool OrderBySequence = true)
			{
			QueryInformation query;

			if(OrderBySequence)
				query = QueryInformation.Create(ClassModel.LoadNamesBySequenceQuery);
			else
				query = QueryInformation.Create(ClassModel.LoadNamesByReincarnationQuery);
			query.CommandType = CommandType.Text;

			return BaseModel.GetNames(query, ClassModel.ReadNames);
			}


		public static string GetNameFromId(Guid classId)
			{
			QueryInformation query;
			List <string> names;

			query = QueryInformation.Create(ClassModel.LoadNameFromIDQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.IdField, DbType.Guid, classId));

			names = BaseModel.GetNames(query, ClassModel.ReadNames);
			if (names.Count == 0)
				return "";
			else
				//there should only be one value!
				return names[0];
			}

		public static Guid GetIdFromName(string name)
			{
			QueryInformation query;
			List<Guid> ids;

			query = QueryInformation.Create(ClassModel.LoadIDFromNameQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + ClassModel.NameField, DbType.String, name));

			ids = BaseModel.GetIds(query, ClassModel.ReadIds);
			if (ids == null)
				return Guid.Empty;
			else
				//there should only be one value!
				return ids[0];
			}

		public static bool DoesNameExist(string name)
			{
			QueryInformation query;

			query = QueryInformation.Create(NameCountQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + NameField, DbType.String, name));

			return BaseModel.GetCount(query) > 0;
			}

		public static bool DoesAbbreviationExist(string abbreviation)
			{
			QueryInformation query;

			query = QueryInformation.Create(AbbreviationCountQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + AbbreviationField, DbType.String, abbreviation));

			return BaseModel.GetCount(query) > 0;
			}

        public static void UpdatePastLifeFeatIdWithNull(Guid pastLifeFeatId)
            {
            QueryInformation query;

            if (pastLifeFeatId == Guid.Empty)
                return;

            query = QueryInformation.Create(ClassModel.UpdatePastLifeFeatIdByPastLifeFeatIdQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@NewValue", DbType.Guid, null));
            query.Parameters.Add(new QueryParameter("@" + ClassModel.PastLifeFeatIdField, DbType.Guid, pastLifeFeatId));

            BaseModel.RunCommand(query);
            }

		public static int[] GetMaxSpellLevels()
			{
			int[] results;
			List<ClassModel> modelList;
			QueryInformation query;

			modelList = new List<ClassModel>();
			query = QueryInformation.Create(LoadClassesQuery);
			query.CommandType = CommandType.Text;
			modelList = BaseModel.GetAll<ClassModel>(query, Create);

			results = new int[modelList.Count];
			for (int i=0; i<modelList.Count; i++)
				results[i] = modelList[i].MaxSpellLevel;

			return results;
			}

        public static int GetSkillPoints(Guid ClassId)
        {
            int results = 0;
            if (ClassId == Guid.Empty)
                return results;
            List<ClassModel> ModelList;
            QueryInformation query;

            ModelList = new List<ClassModel>();
            query = QueryInformation.Create(LoadClassByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ClassModel.IdField, DbType.Guid, ClassId));
            ModelList = BaseModel.GetAll<ClassModel>(query, Create);

            results = ModelList[0].SkillPoints;


            return results;
        }

		public static int GetNumClasses()
			{
			QueryInformation query;

			query = QueryInformation.Create(CountQuery);
			query.CommandType = CommandType.Text;

			return BaseModel.GetCount(query);
			}

		#endregion

		#region Private Static Methods
        private static string ReadNames(DbDataReader reader)
            {
            int ordinal;
            string name = null;

            if (reader == null)
                return null;

            if (reader.TryGetOrdinal(ClassModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    name = reader.GetString(ordinal);
                    }
                }
            return name;
            }
            
		private static Guid ReadIds(DbDataReader reader)
			{
			int ordinal;
			Guid id = Guid.Empty;

			if (reader == null)
				return Guid.Empty;

			if (reader.TryGetOrdinal(ClassModel.IdField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					id = reader.GetGuid(ordinal);
					}
				}
			return id;
			}

		private static ClassModel Create(DbDataReader reader)
			{
			ClassModel model;

			model = new ClassModel();

			if (reader == null)
				return model;

			model.Load(reader);

			return model;
			}
		#endregion
		}
	}
