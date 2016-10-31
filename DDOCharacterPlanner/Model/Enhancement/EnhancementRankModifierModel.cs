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
    /// Defines the data availability for an EnhancementRankModifier Record
    /// </summary>
    public sealed class EnhancementRankModifierModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "EnhancementRankModifierId";
        private const string EnhancementRankIdField = "EnhancementRankId";
        private const string ModifierIdField = "ModifierId";
        private const string ModifierTypeField = "ModifierType";
        private const string ModifierMethodIdField = "ModifierMethodId";
        private const string PullFromIdField = "PullFromId";
        private const string ModifierValueField = "ModifierValue";
        private const string BonusTypeIdField = "BonusTypeId";
        private const string RequirementIdField = "RequirementId";
        private const string StanceIdField = "StanceId";
        private const string ComparisonField = "Comparison";
        private const string RequirementValueField = "RequirementValue";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";
        //Count Queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM EnhancementRankModifier";
        private const string CountByEnhancementRankIdQuery = "SELECT COUNT(*) AS Count FROM EnhancementRankModifier WHERE EnhancementRankId=@EnhancementRankId";
        //Load Queries
        private const string LoadEnhancementRankModifierByIdQuery = "SELECT * FROM EnhancementRankModifier WHERE EnhancementRankModifierId=@EnhancementRankModifierId";
        private const string LoadEnhancementRankModifierByEnhancementRankIdQuery = "SELECT * FROM EnhancementRankModifier WHERE EnhancementRankId=@EnhancementRankId";
        //Get Value Queries

        //Change Queries
        private const string DeleteQuery = "DELETE FROM EnhancementRankModifier WHERE EnhancementRankModifierId=@EnhancementRankModifierId";
        private const string InsertQuery = "INSERT INTO EnhancementRankModifier (EnhancementRankModifierId, EnhancementRankId, ModifierId, ModifierType, ModifierMethodID, PullFromId, ModifierValue, BonusTypeId, RequirementId, StanceId, Comparison, RequirementValue, LastUpdatedDate, LastUpdatedVersion) VALUES (@EnhancementRankModifierId, @EnhancementRankId, @ModifierId, @ModifierType, @ModifierMethodId, @PullFromId, @ModifierValue, @BonusTypeId, @RequirementId, @StanceId, @Comparison, @RequirementValue, @LastUpdatedDate, @LastUpdatedVersion)";
        private const string UpdateQuery = "UPDATE EnhancementRankModifier SET EnhancementRankId=@EnhancementRankId, ModifierId=@ModifierId, ModifierType=@ModifierType, ModifierMethodId=@ModifierMethodId, PullFromId=@PullFromId, ModifierValue=@ModifierValue, BonusTypeId=@BonusTypeId, RequirementId=@RequirementId, StanceId=@StanceId, Comparison=@Comparison, RequirementValue=@RequirementValue, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE EnhancementRankModifierId=@EnhancementRankModifierId";
        #endregion

        #region Properties
        public Guid EnhancementRankId
            {
            get;
            set;
            }

        public Guid ModifierId
            {
            get;
            set;
            }

        public byte ModifierType { get; set; }
        public Guid ModifierMethodId { get; set; }
        public Guid PullFromId { get; set; }


        public double ModifierValue
            {
            get;
            set;
            }

        public Guid BonusTypeId
            {
            get;
            set;
            }

        public Guid RequirementId
            {
            get;
            set;
            }

        public Guid StanceId { get; set; }
        public string Comparison { get; set; }

        public double RequirementValue
            {
            get;
            set;
            }

        #endregion

        #region Private Static Methods
        private static EnhancementRankModifierModel Create(DbDataReader reader)
            {
            EnhancementRankModifierModel model;

            model = new EnhancementRankModifierModel();
            model.Load(reader);

            return model;
            }

        #endregion

        #region Protected Methods
        /// <summary>
        /// Loads the specified reader.
        /// </summary>
        /// <param name="reader">The Reader.</param>
        protected override void Load(DbDataReader reader)
            {
            int ordinal;

            if (reader == null)
                {
                return;
                }

            if (!reader.TryGetOrdinal(EnhancementRankModifierModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(EnhancementRankModifierModel.EnhancementRankIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.EnhancementRankId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(EnhancementRankModifierModel.ModifierIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.ModifierId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(EnhancementRankModifierModel.ModifierTypeField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.ModifierType = reader.GetByte(ordinal);

            if (reader.TryGetOrdinal(EnhancementRankModifierModel.ModifierMethodIdField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.ModifierMethodId = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(EnhancementRankModifierModel.PullFromIdField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.PullFromId = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(EnhancementRankModifierModel.ModifierValueField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.ModifierValue = reader.GetDouble(ordinal);
                }

            if (reader.TryGetOrdinal(EnhancementRankModifierModel.BonusTypeIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.BonusTypeId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(EnhancementRankModifierModel.RequirementIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.RequirementId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(EnhancementRankModifierModel.StanceIdField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.StanceId = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(EnhancementRankModifierModel.ComparisonField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.Comparison = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(EnhancementRankModifierModel.RequirementValueField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.RequirementValue = reader.GetDouble(ordinal);
                }

            if (reader.TryGetOrdinal(EnhancementRankModifierModel.LastUpdatedDateField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);
                }

            if (reader.TryGetOrdinal(EnhancementRankModifierModel.LastUpdatedVersionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedVersion = reader.GetString(ordinal);
                }
            }
        #endregion

        #region Public Methods
        public void ConvertToNewRecord()
            {
            this.Id = Guid.Empty;
            }

        /// <summary>
        /// Create the specified EnhancementRankModifier Model
        /// </summary>
        /// <param name="featModifierId">EnhancementRankModifierId of the EnhancementRankModifier</param>
        public void Initialize(Guid enhancementRankModifierId)
            {
            QueryInformation query;

            if (enhancementRankModifierId == Guid.Empty)
                {
                return;
                }

            query = QueryInformation.Create(EnhancementRankModifierModel.LoadEnhancementRankModifierByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.IdField, DbType.Guid, enhancementRankModifierId));

            this.Initialize(query);
            }

        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can not delete this record, there is no database entry for it. EnhancementRankModifierModel : Delete()");
                return;
                }

            query = QueryInformation.Create(EnhancementRankModifierModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);

            //lets reset the Id to empty so the model knows it is a new record now if the "Save()" is called afterwards for some reason.
            this.Id = Guid.Empty;
            }

        /// <summary>
        /// Saves the currently loaded EnhancementRankModifier
        /// </summary>
        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(EnhancementRankModifierModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                {
                query = QueryInformation.Create(EnhancementRankModifierModel.UpdateQuery);
                }

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.EnhancementRankIdField, DbType.Guid, this.EnhancementRankId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.ModifierIdField, DbType.Guid, this.ModifierId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.ModifierTypeField, DbType.Byte, this.ModifierType));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.ModifierMethodIdField, DbType.Guid, this.ModifierMethodId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.PullFromIdField, DbType.Guid, this.PullFromId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.ModifierValueField, DbType.Double, this.ModifierValue));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.BonusTypeIdField, DbType.Guid, this.BonusTypeId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.RequirementIdField, DbType.Guid, this.RequirementId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.StanceIdField, DbType.Guid, this.StanceId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.ComparisonField, DbType.String, this.Comparison));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.RequirementValueField, DbType.Double, this.RequirementValue));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));

            BaseModel.RunCommand(query);

            }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Delete all records with the supplied FeatId
        /// </summary>
        /// <param name="featId">Guid of the Feat</param>
        public static void DeleteAllByEnhancementRankId(Guid enhancementRankId)
            {
            List<EnhancementRankModifierModel> models;

            if (enhancementRankId == Guid.Empty)
                return;

            models = GetAll(enhancementRankId);
            foreach (EnhancementRankModifierModel model in models)
                model.Delete();
            }

        public static List<EnhancementRankModifierModel> GetAll(Guid enhancementRankId)
            {
            QueryInformation query;

            if (enhancementRankId == Guid.Empty)
                return new List<EnhancementRankModifierModel>();

            query = QueryInformation.Create(EnhancementRankModifierModel.LoadEnhancementRankModifierByEnhancementRankIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.EnhancementRankIdField, DbType.Guid, enhancementRankId));

            return BaseModel.GetAll<EnhancementRankModifierModel>(query, EnhancementRankModifierModel.Create);
            }

        public static int GetRecordCount()
            {
            QueryInformation query;

            query = QueryInformation.Create(CountQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetCount(query);
            }

        public static int GetRecordCount(Guid rankId)
            {
            QueryInformation query;

            if (rankId == Guid.Empty)
                return 0;

            query = QueryInformation.Create(CountByEnhancementRankIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementRankModifierModel.EnhancementRankIdField, DbType.Guid, rankId));

            return BaseModel.GetCount(query);
            }

        #endregion
        }
    }

