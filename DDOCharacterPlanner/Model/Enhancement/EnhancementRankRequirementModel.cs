using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
    {
    public sealed class EnhancementRankRequirementModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "EnhancementRankRequirementId";
        private const string EnhancementRankIdField = "EnhancementRankId";
        private const string RequireAllField = "RequireAll";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";
        private const string RequirementIdField = "RequirementId";
        private const string RequirementValueField = "RequirementValue";
        private const string ComparisonField = "Comparison";
        //Count queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM EnhancementRankRequirement";
        private const string CountByEnhancementRankIdQuery = "SELECT COUNT(*) AS Count FROM EnhancementRankRequirement WHERE EnhancementRankId=@EnhancementRankId";
        //Load Queries
        private const string LoadEnhancementRankRequirementByIdQuery = "SELECT * FROM EnhancementRankRequirement WHERE EnhancementRankRequirementId=@EnhancementRankRequirementId";
        private const string LoadEnhancementRankRequirementsByEnhancementRankQuery = "SELECT * FROM EnhancementRankRequirement WHERE EnhancementRankId=@EnhancementRankId";
        //Get Value Queries

        //Change Queries
        private const string DeleteQuery = "DELETE FROM EnhancementRankRequirement WHERE EnhancementRankRequirementId=@EnhancementRankRequirementId";
        private const string DeleteByEnhancementRankIdQuery = "DELETE FROM EnhancementRankRequirement WHERE EnhancementRankId=@EnhancementRankId";
        private const string InsertQuery = "INSERT INTO EnhancementRankRequirement (EnhancementRankRequirementId, EnhancementRankId, RequireAll, LastUpdatedDate, LastUpdatedVersion, RequirementId, RequirementValue, Comparison) VALUES (@EnhancementRankRequirementId, @EnhancementRankId, @RequireAll, @LastUpdatedDate, @LastUpdatedVersion, @RequirementId, @RequirementValue, @Comparison)";
        private const string UpdateQuery = "UPDATE EnhancementRankRequirement SET EnhancementRankId=@EnhancementRankId, RequireAll=@RequireAll, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion, RequirementId=@RequirementId, RequirementValue=@RequirementValue, Comparison=@Comparison WHERE EnhancementRankRequirementId=@EnhancementRankRequirementId";
        #endregion

        #region Properties

        public Guid EnhancementRankId
            {
            get;
            set;
            }

        public bool RequireAll
            {
            get;
            set;
            }

        public Guid RequirementId
            {
            get;
            set;
            }

        public double RequirementValue
            {
            get;
            set;
            }

        public string Comparison { get; set; }

        #endregion

        #region Private Static Methods
        private static EnhancementRankRequirementModel Create(DbDataReader reader)
            {
            EnhancementRankRequirementModel model;

            model = new EnhancementRankRequirementModel();
            model.Load(reader);

            return model;
            }

        #endregion

        #region Protected Methods
        ///<summary>
        ///Load the specified reader
        ///</summary>
        ///<param name="reader">The reader.<param>
        protected override void Load(DbDataReader reader)
            {
            int ordinal;

            if (reader == null)
                {
                return;
                }

            if (!reader.TryGetOrdinal(EnhancementRankRequirementModel.IdField, out ordinal))
                {
                //No Id Field, can't use
                return;
                }

            if (reader.IsDBNull(ordinal))
                {
                //Null, can't use
                return;
                }

            this.Id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(EnhancementRankRequirementModel.EnhancementRankIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.EnhancementRankId = reader.GetGuid(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(EnhancementRankRequirementModel.RequireAllField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.RequireAll = reader.GetBoolean(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(EnhancementRankRequirementModel.RequirementIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.RequirementId = reader.GetGuid(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(EnhancementRankRequirementModel.RequirementValueField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.RequirementValue = reader.GetDouble(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(EnhancementRankRequirementModel.ComparisonField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.Comparison = reader.GetString(ordinal);
            }
        #endregion

        #region Public Methods
        public void ConvertToNewRecord()
            {
            this.Id = Guid.Empty;
            }

        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can delete this record as an actual Database record doesn't exist for it. EnhancementRankRequirementModel : Delete()");
                return;
                }

            query = QueryInformation.Create(EnhancementRankRequirementModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankRequirementModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);

            //This is for testing purposes, remove when done
            Debug.WriteLine("Record is being deleted: " + this.Id);

            //lets reset the ID to empty so the model knows its a new record in case someone calls the save() method afterwards for some reason
            this.Id = Guid.Empty;
            }

        public void Initialize(Guid enhancementRankRequirementId)
            {
            QueryInformation query;

            if (enhancementRankRequirementId == Guid.Empty)
                return;

            query = QueryInformation.Create(EnhancementRankRequirementModel.LoadEnhancementRankRequirementByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankRequirementModel.IdField, DbType.Guid, enhancementRankRequirementId));

            this.Initialize(query);
            }

        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(EnhancementRankRequirementModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                query = QueryInformation.Create(EnhancementRankRequirementModel.UpdateQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankRequirementModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankRequirementModel.EnhancementRankIdField, DbType.Guid, this.EnhancementRankId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankRequirementModel.RequireAllField, DbType.Boolean, this.RequireAll));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankRequirementModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankRequirementModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankRequirementModel.RequirementIdField, DbType.Guid, this.RequirementId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankRequirementModel.RequirementValueField, DbType.Double, this.RequirementValue));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankRequirementModel.ComparisonField, DbType.String, this.Comparison));
            BaseModel.RunCommand(query);

            //This is for testing purposes, remove when done
            Debug.WriteLine("Record has been saved: " + this.Id);
            }

        #endregion

        #region Public Static Methods
        public static void DeleteAllByEnhancementRankId(Guid enhancementRankId)
            {
            QueryInformation query;

            if (enhancementRankId == Guid.Empty)
                return;

            query = QueryInformation.Create(EnhancementRankRequirementModel.DeleteByEnhancementRankIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankRequirementModel.EnhancementRankIdField, DbType.Guid, enhancementRankId));
            BaseModel.RunCommand(query);
            }

        public static List<EnhancementRankRequirementModel> GetAll(Guid enhancementRankId)
            {
            QueryInformation query;

            if (enhancementRankId == Guid.Empty)
                {
                return new List<EnhancementRankRequirementModel>();
                }

            query = QueryInformation.Create(EnhancementRankRequirementModel.LoadEnhancementRankRequirementsByEnhancementRankQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@EnhancementRankId", DbType.Guid, enhancementRankId));

            return BaseModel.GetAll<EnhancementRankRequirementModel>(query, EnhancementRankRequirementModel.Create);
            }

        public static int GetRecordCount()
            {
            QueryInformation query;

            query = QueryInformation.Create(CountQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetCount(query);
            }

        public static int GetRecordCount(Guid enhancementRankId)
            {
            QueryInformation query;

            if (enhancementRankId == Guid.Empty)
                return 0;

            query = QueryInformation.Create(EnhancementRankRequirementModel.CountByEnhancementRankIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankRequirementModel.EnhancementRankIdField, DbType.Guid, enhancementRankId));

            return BaseModel.GetCount(query);
            }

        #endregion
        }
    }
