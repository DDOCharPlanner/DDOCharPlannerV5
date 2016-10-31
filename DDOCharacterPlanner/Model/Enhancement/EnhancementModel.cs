using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
    {
    ///<summary>
    ///Defines data availability for the Enhnacement Records
    ///</summary>
    public sealed class EnhancementModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "EnhancementId";
        private const string EnhancementSlotIdField = "EnhancementSlotId";
        private const string DisplayOrderField = "DisplayOrder";
        private const string NameField = "Name";
        private const string APCostField = "APCost";
        private const string IconField = "Icon";
        private const string StanceIdField = "StanceId";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        //count queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM Enhancement";
        private const string CountByEnhancementSlotIdQuery = "SELECT COUNT(*) AS Count FROM Enhancement WHERE EnhancementSlotId=@EnhancementSlotId";

        //Load queries
        private const string LoadEnhancementByIdQuery = "SELECT * FROM Enhancement WHERE EnhancementId=@EnhancementId";
        private const string LoadEnhancementByEnhancementSlotIdQuery = "SELECT * FROM Enhancement WHERE EnhancementSlotId=@EnhancementSlotId ORDER BY DisplayOrder";

        //Get Value queries
        private const string GetIdFromEnhancementSlotIdandDisplayOrderQuery = "SELECT EnhancementId FROM Enhancement WHERE EnhancementSlotId=@EnhancementSlotId AND DisplayOrder=@DisplayOrder";
        private const string GetNameFromIdQuery = "SELECT Name FROM Enhancement WHERE EnhancementId=@EnhancementId";

        //Change queries
        private const string DeleteQuery = "DELETE FROM Enhancement WHERE EnhancementId=@EnhancementId";
        private const string DeleteByEnhancementSlotIdQuery = "DELETE FROM Enhancement WHERE EnhancementSlotId=@EnhancementSlotId";
        private const string InsertQuery = "INSERT INTO Enhancement (EnhancementId, EnhancementSlotId, DisplayOrder, Name, APCost, Icon, StanceId, LastUpdatedDate, LastUpdatedVersion) VALUES (@EnhancementId, @EnhancementSlotId, @DisplayOrder, @Name, @APCost, @Icon, @StanceId, @LastUpdatedDate, @LastUpdatedVersion)";
        private const string UpdateQuery = "UPDATE Enhancement SET EnhancementSlotId=@EnhancementSlotId, DisplayOrder=@DisplayOrder, Name=@Name, APCost=@APCost, Icon=@Icon, StanceId=@StanceId, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE EnhancementId=@EnhancementId";
        private const string UpdateDisplayOrderQuery = "Update Enhancement SET DisplayOrder=@DisplayOrder WHERE EnhancementId=EnhancementId";

        #endregion

        #region Properties
        public Guid EnhancementSlotId
            {
            get;
            set;
            }

        public byte DisplayOrder
            {
            get;
            set;
            }

        public string Name
            {
            get;
            set;
            }

        public int APCost
            {
            get;
            set;
            }

        public string Icon
            {
            get;
            set;
            }

        public Guid StanceId { get; set; }

        #endregion

        #region Private Static Members
        private static EnhancementModel Create(DbDataReader reader)
            {
            EnhancementModel model;

            model = new EnhancementModel();
            model.Load(reader);

            return model;
            }

        private static Guid ReadId(DbDataReader reader)
            {
            int ordinal;
            Guid id = Guid.Empty;

            if (reader == null)
                return Guid.Empty;

            if (reader.TryGetOrdinal(EnhancementModel.IdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    id = reader.GetGuid(ordinal);
                }
            return id;
            }

        private static string ReadName(DbDataReader reader)
            {
            int ordinal;
            string name = null;

            if (reader == null)
                return null;

            if (reader.TryGetOrdinal(EnhancementModel.NameField, out ordinal))
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

            if (reader.TryGetOrdinal(EnhancementSlotIdField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    EnhancementSlotId = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(DisplayOrderField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    DisplayOrder = reader.GetByte(ordinal);

            if (reader.TryGetOrdinal(NameField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    Name = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(APCostField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    APCost = reader.GetByte(ordinal);

            if (reader.TryGetOrdinal(IconField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    Icon = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(EnhancementModel.StanceIdField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.StanceId = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(LastUpdatedDateField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    LastUpdatedDate = reader.GetDateTime(ordinal);

            if (reader.TryGetOrdinal(LastUpdatedVersionField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    LastUpdatedVersion = reader.GetString(ordinal);
     
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
                Debug.WriteLine("Error: You can delete this record as an actual Database record doesn't exist for it. EnhancementModel : Delete()");
                return;
                }

            //We need to delete any associated records before deleting this one
            //TODO: EnhancementRankModel.DeleteAllbyEnhancementId(this.Id);
            //TODO: EnhancementRankModifierModel.DeleteAllByEnhancementId(this.Id);
            //TODO: EnhancementRankRequirementModel.DeleteAllByEnhancementId(this.Id);

            //we need to remove any Enhancement entries in other tables for this feat

            query = QueryInformation.Create(EnhancementModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);

            //lets rest the id to empty so that the model knows it is now a new record if the save method is called.
            this.Id = Guid.Empty;
            }

        public void Initialize(Guid enhancementId)
            {
            QueryInformation query;

            if (enhancementId == Guid.Empty)
                return;

            query = QueryInformation.Create(LoadEnhancementByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + IdField, DbType.Guid, enhancementId));

            Initialize(query);
            }

        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(EnhancementModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                query = QueryInformation.Create(EnhancementModel.UpdateQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.EnhancementSlotIdField, DbType.Guid, this.EnhancementSlotId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.DisplayOrderField, DbType.Byte, this.DisplayOrder));
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.NameField, DbType.String, this.Name));
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.APCostField, DbType.Int16, this.APCost));
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.IconField, DbType.String, this.Icon));
            if (StanceId == Guid.Empty)
                query.Parameters.Add(new QueryParameter("@" + EnhancementModel.StanceIdField, DbType.Guid, null));
            else
                query.Parameters.Add(new QueryParameter("@" + EnhancementModel.StanceIdField, DbType.Guid, this.StanceId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));

            BaseModel.RunCommand(query);
            }

        #endregion

        #region Public Static Methods
        public static void DeleteAllByEnhancementSlotId(Guid slotId)
            {
            QueryInformation query;

            if (slotId == Guid.Empty)
                return;

            query = QueryInformation.Create(DeleteByEnhancementSlotIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.EnhancementSlotIdField, DbType.Guid, slotId));
            BaseModel.RunCommand(query);

            }

        public static List<EnhancementModel> GetAll(Guid slotId)
            {
            QueryInformation query;

            if (slotId == Guid.Empty)
                return new List<EnhancementModel>();

            query = QueryInformation.Create(EnhancementModel.LoadEnhancementByEnhancementSlotIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.EnhancementSlotIdField, DbType.Guid, slotId));

            return BaseModel.GetAll<EnhancementModel>(query, EnhancementModel.Create);

            }

        public static Guid GetIdFromSlotIdandDisplayOrder(Guid slotId, byte displayOrder)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(EnhancementModel.GetIdFromEnhancementSlotIdandDisplayOrderQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.EnhancementSlotIdField, DbType.Guid, slotId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.DisplayOrderField, DbType.Byte, displayOrder));
            
            ids = BaseModel.GetIds(query, EnhancementModel.ReadId);
            if (ids == null || ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; //There should only one value
            }

        public static string GetNameFromId(Guid enhancementId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(EnhancementModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.IdField, DbType.Guid, enhancementId));

            names = BaseModel.GetNames(query, EnhancementModel.ReadName);
            if (names.Count == 0)
                return "";
            else
                return names[0]; // there should only be one value!
            
            }

        public static int GetRecordCount()
            {
            QueryInformation query;

            query = QueryInformation.Create(CountQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetCount(query);
            }

        public static int GetRecordCount(Guid slotId)
            {
            QueryInformation query;

            if (slotId == Guid.Empty)
                return 0;

            query = QueryInformation.Create(CountByEnhancementSlotIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementModel.EnhancementSlotIdField, DbType.Guid, slotId));

            return BaseModel.GetCount(query);
            }

        #endregion
        }
    }
