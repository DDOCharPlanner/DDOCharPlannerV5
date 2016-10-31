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
    /// Defines the data availability for an FeatModifier Record
    /// </summary>
    public sealed class FeatModifierModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "FeatModifierId";
        private const string FeatIdField = "FeatId";
        private const string ModifierIdField = "ModifierId";
        private const string ModifierTypeField = "ModifierType";
        private const string ModifierMethodIdField = "ModifierMethodId";
        private const string PullFromIdField = "PullFromId";
        private const string ValueField = "Value";
        private const string BonusTypeIdField = "BonusTypeId";
        private const string RequirementIdField = "RequirementId";
        private const string RequirementValueField = "RequirementValue";
        private const string StanceIDField = "StanceId";
        private const string ComparisonField = "Comparison";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";
        //Count Queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM FeatModifier";
        private const string CountByFeatIdQuery = "SELECT COUNT(*) AS Count FROM FeatModifier WHERE FeatId=@FeatId";
        //Load Queries
        private const string LoadFeatModifierByIdQuery = "SELECT * FROM FeatModifier WHERE FeatModifierId=@FeatModifierId";
        private const string LoadFeatModifierByFeatIdQuery = "SELECT * FROM FeatModifier WHERE FeatId=@FeatId";
        //Get Value Queries
        private const string GetIdsQuery = "SELECT FeatModifierId FROM FeatModifier";
        //Change Queries
        private const string DeleteQuery = "DELETE FROM FeatModifier WHERE FeatModifierId=@FeatModifierId";
        private const string InsertQuery = "INSERT INTO FeatModifier (FeatModifierId, FeatId, ModifierId, ModifierType, ModifierMethodId, PullFromId, Value, BonusTypeId, RequirementId, RequirementValue, StanceId, Comparison, LastUpdatedDate, LastUpdatedVersion) VALUES (@FeatModifierId, @FeatId, @ModifierId, @ModifierType, @ModifierMethodId, @PullFromId, @Value, @BonusTypeId, @RequirementId, @RequirementValue, @StanceId, @Comparison, @LastUpdatedDate, @LastUpdatedVersion)";
        private const string UpdateQuery = "UPDATE FeatModifier SET FeatId=@FeatId, ModifierId=@ModifierId, ModifierType=@ModifierType, ModifierMethodId=@ModifierMethodId, PullFromId=@PullFromId, Value=@Value, BonusTypeId=@BonusTypeId, RequirementId=@RequirementId, RequirementValue=@RequirementValue, StanceId=@StanceId, Comparison=@Comparison, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE FeatModifierId=@FeatModifierId";
        #endregion

        #region Properties
        public Guid FeatId
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

        public double Value
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
        private static FeatModifierModel Create(DbDataReader reader)
            {
            FeatModifierModel model;

            model = new FeatModifierModel();
            model.Load(reader);

            return model;
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

            if (reader.TryGetOrdinal(FeatModifierModel.IdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    id = reader.GetGuid(ordinal);
                }
            return id;
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

            if (!reader.TryGetOrdinal(FeatModifierModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(FeatModifierModel.FeatIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.FeatId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(FeatModifierModel.ModifierIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.ModifierId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(FeatModifierModel.ModifierTypeField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.ModifierType = reader.GetByte(ordinal);

            if (reader.TryGetOrdinal(FeatModifierModel.ModifierMethodIdField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.ModifierMethodId = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(FeatModifierModel.PullFromIdField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.PullFromId = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(FeatModifierModel.ValueField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.Value = reader.GetDouble(ordinal);
                }

            if (reader.TryGetOrdinal(FeatModifierModel.BonusTypeIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.BonusTypeId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(FeatModifierModel.RequirementIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.RequirementId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(FeatModifierModel.StanceIDField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.StanceId = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(FeatModifierModel.ComparisonField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.Comparison = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(FeatModifierModel.RequirementValueField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.RequirementValue = reader.GetDouble(ordinal);
                }

            if (reader.TryGetOrdinal(FeatModifierModel.LastUpdatedDateField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);
                }

            if (reader.TryGetOrdinal(FeatModifierModel.LastUpdatedVersionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedVersion = reader.GetString(ordinal);
                }
            }
        #endregion

        #region Public Methods
        /// <summary>
        /// Create the specified FeatModifier Model
        /// </summary>
        /// <param name="featModifierId">FeatModifierId of the FeatModifier</param>
        public void Initialize(Guid featModifierId)
            {
            QueryInformation query;

            if (featModifierId == Guid.Empty)
                {
                return;
                }

            query = QueryInformation.Create(FeatModifierModel.LoadFeatModifierByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.IdField, DbType.Guid, featModifierId));

            this.Initialize(query);
            }

        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can not delete this record, there is no database entry for it. FeatModifierModel : Delete()");
                return;
                }

            query = QueryInformation.Create(FeatModifierModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);

            //lets reset the Id to empty so the model knows it is a new record now if the "Save()" is called afterwards for some reason.
            this.Id = Guid.Empty;
            }

        /// <summary>
        /// Saves the currently loaded FeatModifier
        /// </summary>
        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(FeatModifierModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                {
                query = QueryInformation.Create(FeatModifierModel.UpdateQuery);
                }

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.FeatIdField, DbType.Guid, this.FeatId));
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.ModifierIdField, DbType.Guid, this.ModifierId));
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.ModifierTypeField, DbType.Byte, this.ModifierType));
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.ModifierMethodIdField, DbType.Guid, this.ModifierMethodId));
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.PullFromIdField, DbType.Guid, this.PullFromId));
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.ValueField, DbType.Double, this.Value));
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.BonusTypeIdField, DbType.Guid, this.BonusTypeId));
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.RequirementIdField, DbType.Guid, this.RequirementId));
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.StanceIDField, DbType.Guid, this.StanceId));
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.ComparisonField, DbType.String, this.Comparison));
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.RequirementValueField, DbType.Double, this.RequirementValue));
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));

            BaseModel.RunCommand(query);

            }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Delete all records with the supplied FeatId
        /// </summary>
        /// <param name="featId">Guid of the Feat</param>
        public static void DeleteAllByFeatId(Guid featId)
            {
            List<FeatModifierModel> models;

            if (featId == Guid.Empty)
                return;

            models = GetAll(featId);
            foreach (FeatModifierModel model in models)
                model.Delete();
            }

        /// <summary>
        /// Gets all the FeatModifier Ids
        /// </summary>
        /// <returns>A list of all the FeatModifier ids</returns>
        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(FeatModifierModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, FeatModifierModel.ReadId);
            }

        public static List<FeatModifierModel> GetAll(Guid featId)
            {
            QueryInformation query;

            if (featId == Guid.Empty)
                return new List<FeatModifierModel>();

            query = QueryInformation.Create(FeatModifierModel.LoadFeatModifierByFeatIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatModifierModel.FeatIdField, DbType.Guid, featId));

            return BaseModel.GetAll<FeatModifierModel>(query, FeatModifierModel.Create);
            }

        public static int GetRecordCount()
            {
            QueryInformation query;

            query = QueryInformation.Create(CountQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetCount(query);
            }

        #endregion
        }
    }

