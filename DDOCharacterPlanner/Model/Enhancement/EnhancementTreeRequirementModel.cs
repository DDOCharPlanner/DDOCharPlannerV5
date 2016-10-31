using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
    {
    public sealed class EnhancementTreeRequirementModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "EnhancementTreeRequirementId";
        private const string EnhancementTreeIdField = "EnhancementTreeId";
        private const string RequireAllField = "RequireAll";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";
        private const string RequirementIdField = "RequirementId";
        private const string RequirementValueField = "RequirementValue";
        private const string ComparisonField = "Comparison";
        //Count queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM EnhancementTreeRequirement";
        private const string CountByEnhancementTreeIdQuery = "SELECT COUNT(*) AS Count FROM EnhancementTreeRequirement WHERE EnhancementTreeId=@EnhancementTreeId";
        //Load Queries
        private const string LoadEnhancementTreeRequirementByIdQuery = "SELECT * FROM EnhancementTreeRequirement WHERE EnhancementTreeRequirementId=@EnhancementTreeRequirementId";
        private const string LoadEnhancementTreeRequirementsByEnhancementTreeQuery = "SELECT * FROM EnhancementTreeRequirement WHERE EnhancementTreeId=@EnhancementTreeId";
        //Get Value Queries

        //Change Queries
        private const string DeleteQuery = "DELETE FROM EnhancementTreeRequirement WHERE EnhancementTreeRequirementId=@EnhancementTreeRequirementId";
        private const string DeleteByEnhancementTreeIdQuery = "DELETE FROM EnhancementTreeRequirement WHERE EnhancementTreeId=@EnhancementTreeId";
        private const string InsertQuery = "INSERT INTO EnhancementTreeRequirement (EnhancementTreeRequirementId, EnhancementTreeId, RequireAll, LastUpdatedDate, LastUpdatedVersion, RequirementId, RequirementValue, Comparison) VALUES (@EnhancementTreeRequirementId, @EnhancementTreeId, @RequireAll, @LastUpdatedDate, @LastUpdatedVersion, @RequirementId, @RequirementValue, @Comparison)";
        private const string UpdateQuery = "UPDATE EnhancementTreeRequirement SET EnhancementTreeId=@EnhancementTreeId, RequireAll=@RequireAll, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion, RequirementId=@RequirementId, RequirementValue=@RequirementValue, Comparison=@Comparison WHERE EnhancementTreeRequirementId=@EnhancementTreeRequirementId";
        #endregion

        #region Properties

        public Guid EnhancementTreeId
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
        private static EnhancementTreeRequirementModel Create(DbDataReader reader)
            {
            EnhancementTreeRequirementModel model;

            model = new EnhancementTreeRequirementModel();
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

            if (!reader.TryGetOrdinal(EnhancementTreeRequirementModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(EnhancementTreeRequirementModel.EnhancementTreeIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.EnhancementTreeId = reader.GetGuid(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(EnhancementTreeRequirementModel.RequireAllField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.RequireAll = reader.GetBoolean(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(EnhancementTreeRequirementModel.RequirementIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.RequirementId = reader.GetGuid(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(EnhancementTreeRequirementModel.RequirementValueField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.RequirementValue = reader.GetDouble(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(EnhancementTreeRequirementModel.ComparisonField, out ordinal))
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
                Debug.WriteLine("Error: You can delete this record as an actual Database record doesn't exist for it. EnhancementTreeRequirementModel : Delete()");
                return;
                }

            query = QueryInformation.Create(EnhancementTreeRequirementModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeRequirementModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);
            //lets reset the ID to empty so the model knows its a new record in case someone calls the save() method afterwards for some reason
            this.Id = Guid.Empty;
            }

        public void Initialize(Guid enhancementTreeRequirementId)
            {
            QueryInformation query;

            if (enhancementTreeRequirementId == Guid.Empty)
                return;

            query = QueryInformation.Create(EnhancementTreeRequirementModel.LoadEnhancementTreeRequirementByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeRequirementModel.IdField, DbType.Guid, enhancementTreeRequirementId));

            this.Initialize(query);
            }

        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(EnhancementTreeRequirementModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                query = QueryInformation.Create(EnhancementTreeRequirementModel.UpdateQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeRequirementModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeRequirementModel.EnhancementTreeIdField, DbType.Guid, this.EnhancementTreeId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeRequirementModel.RequireAllField, DbType.Boolean, this.RequireAll));
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeRequirementModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeRequirementModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeRequirementModel.RequirementIdField, DbType.Guid, this.RequirementId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeRequirementModel.RequirementValueField, DbType.Double, this.RequirementValue));
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeRequirementModel.ComparisonField, DbType.String, this.Comparison));
            BaseModel.RunCommand(query);
            }

        #endregion

        #region Public Static Methods
        public static void DeleteAllByEnhancementTreeId(Guid enhancementTreeId)
            {
            QueryInformation query;

            if (enhancementTreeId == Guid.Empty)
                return;

            query = QueryInformation.Create(EnhancementTreeRequirementModel.DeleteByEnhancementTreeIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeRequirementModel.EnhancementTreeIdField, DbType.Guid, enhancementTreeId));
            BaseModel.RunCommand(query);
            }

        public static List<EnhancementTreeRequirementModel> GetAll(Guid enhancementTreeId)
            {
            QueryInformation query;

            if (enhancementTreeId == Guid.Empty)
                {
                return new List<EnhancementTreeRequirementModel>();
                }

            query = QueryInformation.Create(EnhancementTreeRequirementModel.LoadEnhancementTreeRequirementsByEnhancementTreeQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@EnhancementTreeId", DbType.Guid, enhancementTreeId));

            return BaseModel.GetAll<EnhancementTreeRequirementModel>(query, EnhancementTreeRequirementModel.Create);
            }

        public static int GetRecordCount()
            {
            QueryInformation query;

            query = QueryInformation.Create(CountQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetCount(query);
            }

        public static int GetRecordCount(Guid enhancementTreeId)
            {
            QueryInformation query;

            if (enhancementTreeId == Guid.Empty)
                return 0;

            query = QueryInformation.Create(EnhancementTreeRequirementModel.CountByEnhancementTreeIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeRequirementModel.EnhancementTreeIdField, DbType.Guid, enhancementTreeId));

            return BaseModel.GetCount(query);
            }

        #endregion
        }
    }