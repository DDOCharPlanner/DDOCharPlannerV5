using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.DataAccess;
using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Model
    {
    public sealed class FeatRequirementModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "FeatRequirementId";
        private const string FeatIdField = "FeatId";
        private const string RequireAllField = "RequireAll";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";
        private const string RequirementIdField = "RequirementId";
        private const string ValueField = "Value";
        private const string ComparisonField = "Comparison";

        private const string CountQuery = "SELECT COUNT(*) AS Count FROM FeatRequirement";
        private const string CountByFeatIdQuery = "SELECT COUNT(*) AS Count FROM FeatRequirement WHERE FeatId=@FeatId";

        private const string LoadFeatRequirementByIdQuery = "SELECT * FROM FeatRequirement WHERE FeatRequirementId=@FeatRequirementId";
        private const string LoadFeatRequirementsByFeatQuery = "SELECT * FROM FeatRequirement WHERE FeatId=@FeatId";

        private const string DeleteQuery = "DELETE FROM FeatRequirement WHERE FeatRequirementId=@FeatRequirementId";
        private const string DeleteByFeatIdQuery = "DELETE FROM FeatRequirement WHERE FeatId=@FeatId";
        private const string InsertQuery = "INSERT INTO FeatRequirement (FeatRequirementId, FeatId, RequireAll, LastUpdatedDate, LastUpdatedVersion, RequirementId, Value, Comparison) VALUES (@FeatRequirementId, @FeatId, @RequireAll, @LastUpdatedDate, @LastUpdatedVersion, @RequirementId, @Value, @Comparison)";
        private const string UpdateQuery = "UPDATE FeatRequirement SET FeatId=@FeatId, RequireAll=@RequireAll, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion, RequirementId=@RequirementId, Value=@Value, Comparison=@Comparison WHERE FeatRequirementId=@FeatRequirementId";
        #endregion

        #region Properties

        public Guid FeatId
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

        public double Value
            {
            get;
            set;
            }

        public string Comparison { get; set; }

        #endregion

        #region Private Static Methods
        private static FeatRequirementModel Create(DbDataReader reader)
            {
            FeatRequirementModel model;

            model = new FeatRequirementModel();
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

            if (!reader.TryGetOrdinal(FeatRequirementModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(FeatRequirementModel.FeatIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.FeatId = reader.GetGuid(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(FeatRequirementModel.RequireAllField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.RequireAll = reader.GetBoolean(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(FeatRequirementModel.RequirementIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.RequirementId = reader.GetGuid(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(FeatRequirementModel.ValueField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.Value = reader.GetDouble(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(FeatRequirementModel.ComparisonField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.Comparison = reader.GetString(ordinal);
            }
        #endregion

        #region Public Methods
        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can delete this record as an actual Database record doesn't exist for it. FeatRequirementModel : Delete()");
                return;
                }

            query = QueryInformation.Create(FeatRequirementModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatRequirementModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);
            //lets reset the ID to empty so the model knows its a new record in case someone calls the save() method afterwards for some reason
            this.Id = Guid.Empty;
            }

        public void Initialize(Guid featRequirementId)
            {
            QueryInformation query;

            if (featRequirementId == Guid.Empty)
                return;

            query = QueryInformation.Create(FeatRequirementModel.LoadFeatRequirementByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatRequirementModel.IdField, DbType.Guid, featRequirementId));

            this.Initialize(query);
            }

        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(FeatRequirementModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                query = QueryInformation.Create(FeatRequirementModel.UpdateQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatRequirementModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + FeatRequirementModel.FeatIdField, DbType.Guid, this.FeatId));
            query.Parameters.Add(new QueryParameter("@" + FeatRequirementModel.RequireAllField, DbType.Boolean, this.RequireAll));
            query.Parameters.Add(new QueryParameter("@" + FeatRequirementModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + FeatRequirementModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));
            query.Parameters.Add(new QueryParameter("@" + FeatRequirementModel.RequirementIdField, DbType.Guid, this.RequirementId));
            query.Parameters.Add(new QueryParameter("@" + FeatRequirementModel.ValueField, DbType.Double, this.Value));
            query.Parameters.Add(new QueryParameter("@" + FeatRequirementModel.ComparisonField, DbType.String, this.Comparison));
            BaseModel.RunCommand(query);
            }

        #endregion

        #region Public Static Methods
        public static void DeleteAllByFeatId(Guid featId)
            {
            QueryInformation query;

            if (featId == Guid.Empty)
                return;

            query = QueryInformation.Create(FeatRequirementModel.DeleteByFeatIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatRequirementModel.FeatIdField, DbType.Guid, featId));
            BaseModel.RunCommand(query);
            }

        public static List<FeatRequirementModel> GetAll(Guid featId)
            {
            QueryInformation query;

            if (featId == Guid.Empty)
                {
                return new List<FeatRequirementModel>();
                }

            query = QueryInformation.Create(FeatRequirementModel.LoadFeatRequirementsByFeatQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@FeatId", DbType.Guid, featId));

            return BaseModel.GetAll<FeatRequirementModel>(query, FeatRequirementModel.Create);
            }

        public static int GetRecordCount()
            {
            QueryInformation query;

            query = QueryInformation.Create(CountQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetCount(query);
            }

        public static int GetRecordCount(Guid featId)
            {
            QueryInformation query;

            if (featId == Guid.Empty)
                return 0;

            query = QueryInformation.Create(FeatRequirementModel.CountByFeatIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatRequirementModel.FeatIdField, DbType.Guid, featId));

            return BaseModel.GetCount(query);
            }

        #endregion
        }
    }
