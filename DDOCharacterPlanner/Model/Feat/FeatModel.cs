using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace DDOCharacterPlanner.Model
    {
    
    /// <summary>
    /// Defines data availability for a character's bonus feats.
    /// </summary>
    public sealed class FeatModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "FeatId";
        private const string NameField = "Name";
        private const string FeatCategoryIdField = "FeatCategoryId";
        private const string IsParentFeatField = "isParentFeat";
        private const string ParentFeatField = "ParentFeat";
        private const string ImageFileNameField = "ImageFileName";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";
        private const string DescriptionField = "Description";
        private const string MultipleField = "Multiple";
        private const string DurationField = "Duration";
        private const string StanceIdField = "StanceId";

        private const string CountByNameQuery = "SELECT COUNT(*) AS Count FROM Feat WHERE Name=@Name";

        private const string LoadFeatByNameQuery = "SELECT * FROM Feat WHERE Name=@Name";
        private const string LoadFeatByIdQuery = "SELECT * FROM Feat WHERE FeatId=@FeatId";
        private const string LoadNamesQuery = "SELECT FeatId, Name FROM Feat ORDER BY Name";

        private const string GetIdsQuery = "SELECT FeatId FROM Feat";
        private const string GetIdsFromParentFeatIdQuery = "SELECT FeatId FROM Feat WHERE ParentFeat=@ParentFeat";
        private const string GetIdFromNameQuery = "SELECT FeatId FROM Feat WHERE Name=@Name";
        private const string GetNameFromIdQuery = "SELECT Name FROM Feat WHERE FeatId=@FeatId";
        private const string GetNamesByisParentFeatQuery = "SELECT Name FROM Feat WHERE isParentFeat=@IsParentFeat ORDER BY Name";

        private const string DeleteQuery = "DELETE FROM Feat WHERE FeatId=@FeatId";
        private const string InsertQuery = "INSERT INTO Feat (FeatId, Name, FeatCategoryId, isParentFeat, ParentFeat, ImageFileName, LastUpdatedDate, LastUpdatedVersion, Description, Multiple, Duration, StanceId) VALUES (@FeatId, @Name, @FeatCategoryId, @isParentFeat, @ParentFeat, @ImageFileName, @LastUpdatedDate, @LastUpdatedVersion, @Description, @Multiple, @Duration, @StanceId)";
        private const string UpdateQuery = "UPDATE Feat SET Name=@Name, FeatCategoryId=@FeatCategoryId, isParentFeat=@isParentFeat, ParentFeat=@ParentFeat, ImageFileName=@ImageFileName, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion, Description=@Description, Multiple=@Multiple, Duration=@Duration, StanceId=@StanceId WHERE FeatId=@FeatId";
        private const string UpdateParentFeatByParenFeatQuery = "UPDATE Feat SET ParentFeat=@NewValue WHERE ParentFeat=@ParentFeat";
        #endregion

        #region Properties
        public string Name
            {
            get;
            set;
            }
        public Guid FeatCategoryId
            {
            get;
            set;
            }
        public bool IsParentFeat
            {
            get;
            set;
            }
        public Guid ParentFeat
            {
            get;
            set;
            }
        public string ImageFileName
            {
            get;
            set;
            }

        public string Description
            {
            get;
            set;
            }

        public bool Multiple
            {
            get;
            set;
            }

        public string Duration
            {
            get;
            set;
            }

        public Guid StanceId { get; set; }

        #endregion

        #region Private Static Methods
        private static FeatModel Create(DbDataReader reader)
            {
            FeatModel model;

            model = new FeatModel();
            model.Load(reader);

            return model;
            }

        private static Guid ReadId(DbDataReader reader)
            {
            int ordinal;
            Guid id = Guid.Empty;

            if (reader == null)
                return Guid.Empty;

            if (reader.TryGetOrdinal(FeatModel.IdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    id = reader.GetGuid(ordinal);
                }
            return id;
            }

        private static string ReadNames(DbDataReader reader)
            {
            int ordinal;
            Guid id;
            string name = null;

            if (reader == null)
                {
                return null;
                }

            if (!reader.TryGetOrdinal(IdField, out ordinal))
                {
                // No ID Field, cna't use
                return null;
                }

            if (reader.IsDBNull(ordinal))
                {
                //Null, cant' use
                return null;
                }

            id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(NameField, out ordinal))
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

            if (reader.TryGetOrdinal(FeatModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    name = reader.GetString(ordinal);
                    }
                }
            return name;
            }

        #endregion

        #region Protectd Methods
        /// <summary>
        /// Loads the specified reader
        /// </summary>
        /// <param name="reader">The reader.</param>
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

            this.Id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    Name = reader.GetString(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(FeatCategoryIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    FeatCategoryId = reader.GetGuid(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(IsParentFeatField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    IsParentFeat = reader.GetBoolean(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(ParentFeatField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    ParentFeat = reader.GetGuid(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(ImageFileNameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    ImageFileName = reader.GetString(ordinal);
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

            if (reader.TryGetOrdinal(DescriptionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    Description = reader.GetString(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(MultipleField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    Multiple = reader.GetBoolean(ordinal);
                }

            if (reader.TryGetOrdinal(DurationField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    Duration = reader.GetString(ordinal);
                }

            if (reader.TryGetOrdinal(FeatModel.StanceIdField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.StanceId = reader.GetGuid(ordinal);

            }
        #endregion

        #region Public Methods
        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can delete this record as an actual Database record doesn't exist for it. FeatModel : Delete()");
                return;
                }

            //We need to delete any associated records first before deleting this Feat record
            CharacterBonusFeatModel.DeleteAllbyFeatId(this.Id);
            ClassBonusFeatModel.DeleteAllbyFeatId(this.Id);
            //TODO: DestinySpherePastLifeFeatModel.DeleteAllByFeatId(this.Id);
            FeatFeatTypeModel.DeleteAllByFeatId(this.Id);
            FeatModifierModel.DeleteAllByFeatId(this.Id);
            FeatRequirementModel.DeleteAllByFeatId(this.Id);
            ModifierModel.DeleteAllByFeatId(this.Id);
            RaceBonusFeatModel.DeleteAllByFeatId(this.Id);
            RequirementModel.DeleteAllbyFeatId(this.Id);

            //We need to remove any feat entries in other tables for this Feat
            //Class - PastLifeFeatId
            ClassModel.UpdatePastLifeFeatIdWithNull(this.Id);
            //Feat - ParentFeat
            FeatModel.UpdatedParentFeatWithNull(this.Id);
            //Race - PastLifeFeatId
            RaceModel.UpdatePastLifeFeatIdWithNull(this.Id);
           


            query = QueryInformation.Create(FeatModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);
            //lets reset the ID to empty so the model knows its a new record in case someone calls the save() method afterwards for some reason
            this.Id = Guid.Empty;
            }


        public void Initialize(string featName)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(featName))
                {
                return;
                }

            query = QueryInformation.Create(LoadFeatByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + NameField, DbType.String, featName));

            Initialize(query);
            }

        public void Initialize(Guid featId)
            {
            QueryInformation query;

            if (featId == Guid.Empty)
                {
                return;
                }

            query = QueryInformation.Create(LoadFeatByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + IdField, DbType.Guid, featId));

            Initialize(query);
            }

        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(InsertQuery);
                this.Id = Guid.NewGuid();
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
            query.Parameters.Add(new QueryParameter("@" + NameField, DbType.String, Name));
            if (this.FeatCategoryId == Guid.Empty)
                query.Parameters.Add(new QueryParameter("@" + FeatCategoryIdField, DbType.Guid, null));
            else
                query.Parameters.Add(new QueryParameter("@" + FeatCategoryIdField, DbType.Guid, FeatCategoryId));
            query.Parameters.Add(new QueryParameter("@" + IsParentFeatField, DbType.Boolean, IsParentFeat));
            if (this.ParentFeat == Guid.Empty)
                query.Parameters.Add(new QueryParameter("@" + ParentFeatField, DbType.Guid, null));
            else
                query.Parameters.Add(new QueryParameter("@" + ParentFeatField, DbType.Guid, ParentFeat));
            query.Parameters.Add(new QueryParameter("@" + ImageFileNameField, DbType.String, ImageFileName));
            query.Parameters.Add(new QueryParameter("@" + LastUpdatedDateField, DbType.DateTime, LastUpdatedDate));
            query.Parameters.Add(new QueryParameter("@" + LastUpdatedVersionField, DbType.String, LastUpdatedVersion));
            query.Parameters.Add(new QueryParameter("@" + DescriptionField, DbType.String, Description));
            query.Parameters.Add(new QueryParameter("@" + MultipleField, DbType.Boolean, Multiple));
            query.Parameters.Add(new QueryParameter("@" + DurationField, DbType.String, Duration));
            if (this.StanceId == Guid.Empty)
                query.Parameters.Add(new QueryParameter("@" + FeatModel.StanceIdField, DbType.Guid, null));
            else
                query.Parameters.Add(new QueryParameter("@" + FeatModel.StanceIdField, DbType.Guid, this.StanceId));
            BaseModel.RunCommand(query);
            }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Gets the Ids of the Feats
        /// </summary>
        /// <returns>A list of all the Feat ids.</returns>
        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(FeatModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, FeatModel.ReadId);
            }

        public static List<Guid> GetIdsFromParentFeatId(Guid featId)
            {
            QueryInformation query;
            query = QueryInformation.Create(FeatModel.GetIdsFromParentFeatIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatModel.ParentFeatField, DbType.Guid, featId));

            return BaseModel.GetIds(query, FeatModel.ReadId);
            }

        /// <summary>
        /// Gets the names of the feats
        /// </summary>
        /// <returns> A list of all the Feat names.</return>
        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(LoadNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, ReadNames);
            }

        public static List<string> GetNamesByIsParentFeat(bool flag)
            {
            QueryInformation query;

            query = QueryInformation.Create(GetNamesByisParentFeatQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatModel.IsParentFeatField, DbType.Boolean, flag));

            return BaseModel.GetNames(query, FeatModel.ReadJustNames);
            }

        public static Guid GetIdFromName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(FeatModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, FeatModel.ReadId);
            if (ids == null)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
            }

        public static string GetNameFromId(Guid featId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(FeatModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatModel.IdField, DbType.Guid, featId));

            names = BaseModel.GetNames(query, FeatModel.ReadJustNames);
            if (names.Count == 0)
                return "";
            else
                return names[0]; // there should only be one value!
            }

        public static bool DoesNameExist(string name)
            {
            QueryInformation query;

            query = QueryInformation.Create(FeatModel.CountByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatModel.NameField, DbType.String, name));

            return BaseModel.GetCount(query) > 0;
            }

        public static void UpdatedParentFeatWithNull(Guid parentFeat)
            {
            QueryInformation query;

            if (parentFeat == Guid.Empty)
                return;

            query = QueryInformation.Create(FeatModel.UpdateParentFeatByParenFeatQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@NewValue", DbType.Guid, null));
            query.Parameters.Add(new QueryParameter("@" + FeatModel.ParentFeatField, DbType.Guid, parentFeat));

            BaseModel.RunCommand(query);

            }
        #endregion
        }
    }
