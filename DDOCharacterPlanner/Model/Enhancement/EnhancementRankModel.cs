using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
    {
    /// <summary>
    /// Defines data availability for the EnhancementRank Records
    /// </summary>
    public sealed class EnhancementRankModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "EnhancementRankId";
        private const string EnhancementIdField = "EnhancementId";
        private const string RankField = "Rank";
        private const string DescriptionField = "Description";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        //Count Queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM EnhancementRank";
        private const string CountByEnhancementIdQuery = "SELECT COUNT(*) AS Count FROM EnhancementRank WHERE EnhancementId=@EnhancementId";
        //Load Queries
        private const string LoadEnhancementRankByIdQuery = "SELECT * FROM EnhancementRank WHERE EnhancementRankId=@EnhancementRankId";
        private const string LoadEnhancementRankByEnhancementIdQuery = "SELECT * FROM EnhancementRank WHERE EnhancementId=@EnhancementId";
        //Get Value Queries

        //Change Queries
        private const string DeleteQuery = "DELETE FROM EnhancementRank WHERE EnhancementRankId=@EnhancementRankId";
        private const string DeleteByEnhancementIdQuery = "DELETE FROM Enhancement WHERE EnhancementId=@EnhancementId";
        private const string InsertQuery = "INSERT INTO EnhancementRank (EnhancementRankId, EnhancementId, Rank, Description, LastUpdatedDate, LastUpdatedVersion) VALUES (@EnhancementRankId, @EnhancementId, @Rank, @Description, @LastUpdatedDate, @LastUpdatedVersion)";
        private const string UpdateQuery = "UPDATE EnhancementRank SET EnhancementId=@EnhancementId, Rank=@Rank, Description=@Description, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE EnhancementRankId=@EnhancementRankId";

        #endregion

        #region Properties
        public Guid EnhancementId
            {
            get;
            set;
            }

        public byte Rank
            {
            get;
            set;
            }

        public string Description
            {
            get;
            set;
            }

        #endregion

        #region Private Static Members
        private static EnhancementRankModel Create(DbDataReader reader)
            {
            EnhancementRankModel model;

            model = new EnhancementRankModel();
            model.Load(reader);

            return model;
            }

        #endregion

        #region Protected Members
        protected override void Load(DbDataReader reader)
            {
            int ordinal;

            if (reader == null)
                return;

            if (!reader.TryGetOrdinal(IdField, out ordinal))
                return; // No Id field, can't use

            if (reader.IsDBNull(ordinal))
                return; //Null, can't use

            this.Id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(EnhancementIdField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    EnhancementId = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(RankField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    Rank = reader.GetByte(ordinal);

            if (reader.TryGetOrdinal(DescriptionField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    Description = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(LastUpdatedDateField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    LastUpdatedDate = reader.GetDateTime(ordinal);

            if (reader.TryGetOrdinal(LastUpdatedVersionField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    LastUpdatedVersion = reader.GetString(ordinal);

            }
        #endregion

        #region Public Members
        public void ConvertToNewRecord()
            {
            this.Id = Guid.Empty;
            }

        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can delete this record as an actual Database record doesn't exist for it. EnhancementRankModel : Delete()");
                return;
                }

            //We need to delete any associated records before deleting this one
            //TODO: EnhancementRankModifierModel.DeleteAllByEnhancementRankId(this.Id);
            EnhancementRankRequirementModel.DeleteAllByEnhancementRankId(this.Id);

            //we need to remove any Enhancement entries in other tables for this feat

            query = QueryInformation.Create(EnhancementRankModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);

            //lets rest the id to empty so that the model knows it is now a new record if the save method is called.
            this.Id = Guid.Empty;
            }

        public void Initialize(Guid enhancementRankId)
            {
            QueryInformation query;

            if (enhancementRankId == Guid.Empty)
                return;

            query = QueryInformation.Create(LoadEnhancementRankByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + IdField, DbType.Guid, enhancementRankId));

            Initialize(query);
            }

        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(EnhancementRankModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                query = QueryInformation.Create(EnhancementRankModel.UpdateQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModel.EnhancementIdField, DbType.Guid, this.EnhancementId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModel.RankField, DbType.Byte, this.Rank));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModel.DescriptionField, DbType.String, this.Description));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));

            BaseModel.RunCommand(query);
            }

        #endregion

        #region Public Static Members
        public static void DeleteAllByEnhancementId(Guid enhancementId)
            {
            QueryInformation query;

            if (enhancementId == Guid.Empty)
                return;

            query = QueryInformation.Create(DeleteByEnhancementIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModel.EnhancementIdField, DbType.Guid, enhancementId));
            BaseModel.RunCommand(query);

            }

        public static List<EnhancementRankModel> GetAll(Guid enhancementId)
            {
            QueryInformation query;

            if (enhancementId == Guid.Empty)
                return new List<EnhancementRankModel>();

            query = QueryInformation.Create(EnhancementRankModel.LoadEnhancementRankByEnhancementIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModel.EnhancementIdField, DbType.Guid, enhancementId));

            return BaseModel.GetAll<EnhancementRankModel>(query, EnhancementRankModel.Create);

            }

        public static int GetRecordCount()
            {
            QueryInformation query;

            query = QueryInformation.Create(CountQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetCount(query);
            }

        public static int GetRecordCount(Guid enhancementId)
            {
            QueryInformation query;

            if (enhancementId == Guid.Empty)
                return 0;

            query = QueryInformation.Create(CountByEnhancementIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModel.EnhancementIdField, DbType.Guid, enhancementId));

            return BaseModel.GetCount(query);
            }

        #endregion
        }
    }
