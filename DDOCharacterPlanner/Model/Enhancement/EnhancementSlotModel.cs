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
    public sealed class EnhancementSlotModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "EnhancementSlotId";
        private const string EnhancementTreeIdField = "EnhancementTreeId";
        private const string SlotIndexField = "SlotIndex";
        private const string APRequirementField = "APRequirement";
        private const string ActiveField = "Active";
        private const string NameField = "Name";
        private const string DescriptionField = "Description";
        private const string IconField = "Icon";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";
        private const string UseEnhancementInfoField = "UseEnhancementInfo";
        //Count Queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM EnhancementSlot";
        private const string CountByEnhancementTreeIdQuery = "SELECT COUNT(*) AS Count FROM EnhancementSlot WHERE EnhancementTreeId=@EnhancementTreeId";
        //Load Queries
        private const string LoadEnhancementSlotByIdQuery = "SELECT * FROM EnhancementSlot WHERE EnhancementSlotId=@EnhancementSlotId";
        private const string LoadEnhancementSlotByEnhancementTreeIdQuery = "SELECT * FROM EnhancementSlot WHERE EnhancementTreeId=@EnhancementTreeId";

        //Get Value Queries
        private const string GetEnhancementSlotIdFromTreeIdandSlotIndex = "SELECT EnhancementSlotId FROM EnhancementSlot WHERE EnhancementTreeId=@EnhancementTreeId and SlotIndex=@SlotIndex";
        //Change Queries
        private const string DeleteQuery = "DELETE FROM EnhancementSlot WHERE EnhancementSlotId=@EnhancementSlotId";
        private const string DeleteByEnhancementTreeIdQuery = "DELETE FROM EnhancementSlot WHERE EnhancementTreeId=@EnhancementTreeId";
        private const string InsertQuery = "INSERT INTO EnhancementSlot (EnhancementSlotId, EnhancementTreeId, SlotIndex, APRequirement, Active, Name, Description, Icon, LastUpdatedDate, LastUpdatedVersion, UseEnhancementInfo) VALUES (@EnhancementSlotId, @EnhancementTreeId, @SlotIndex, @APRequirement, @Active, @Name, @Description, @Icon, @LastUpdatedDate, @LastUpdatedVersion, @UseEnhancementInfo)";
        private const string UpdateQuery = "UPDATE EnhancementSlot SET EnhancementTreeId=@EnhancementTreeId, SlotIndex=@SlotIndex, APRequirement=@APRequirement, Active=@Active, Name=@Name, Description=@Description, Icon=@Icon, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion, UseEnhancementInfo=@UseEnhancementInfo WHERE EnhancementSlotId=@EnhancementSlotId";

        //default values
        private const bool DefaultActive = true;
        private const int DefaultAPRequirement = 0;
        private const bool DefaultUseEnhancementInfo = true;
        #endregion

        #region Properties
        public Guid EnhancementTreeId
            {
            get;
            set;
            }

        public int SlotIndex
            {
            get;
            set;
            }

        public int APRequirement
            {
            get;
            set;
            }

        public bool Active
            {
            get;
            set;
            }

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

        public string Icon
            {
            get;
            set;
            }

        public bool UseEnhancementInfo
            {
            get;
            set;
            }

        #endregion

        #region Constructor
        public EnhancementSlotModel()
            {
            Active = DefaultActive;
            APRequirement = DefaultAPRequirement;
            UseEnhancementInfo = DefaultUseEnhancementInfo;

            }

        #endregion

        #region Private Static Members
        private static EnhancementSlotModel Create(DbDataReader reader)
            {
            EnhancementSlotModel model;

            model = new EnhancementSlotModel();
            model.Load(reader);

            return model;
            }

        private static Guid ReadId(DbDataReader reader)
            {
            int ordinal;
            Guid id = Guid.Empty;

            if (reader == null)
                return Guid.Empty;

            if (reader.TryGetOrdinal(EnhancementSlotModel.IdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    id = reader.GetGuid(ordinal);
                }
            return id;
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

            if (reader.TryGetOrdinal(EnhancementTreeIdField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    EnhancementTreeId = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(SlotIndexField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    SlotIndex = reader.GetInt32(ordinal);

            if (reader.TryGetOrdinal(APRequirementField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    APRequirement = reader.GetInt32(ordinal);

            if (reader.TryGetOrdinal(ActiveField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    Active = reader.GetBoolean(ordinal);

            if (reader.TryGetOrdinal(NameField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    Name = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(DescriptionField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    Description = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(IconField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    Icon = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(LastUpdatedDateField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    LastUpdatedDate = reader.GetDateTime(ordinal);

            if (reader.TryGetOrdinal(LastUpdatedVersionField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    LastUpdatedVersion = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(UseEnhancementInfoField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    UseEnhancementInfo = reader.GetBoolean(ordinal);
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
                Debug.WriteLine("Error: You can delete this record as an actual Database record doesn't exist for it. EnhancementSlotModel : Delete()");
                return;
                }

            //We need to delete any associated records before deleting this one
            EnhancementModel.DeleteAllByEnhancementSlotId(this.Id);

            //we need to remove any Enhancement entries in other tables for this feat

            query = QueryInformation.Create(EnhancementSlotModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);

            //lets rest the id to empty so that the model knows it is now a new record if the save method is called.
            this.Id = Guid.Empty;
            }

        public void Initialize(Guid enhancementSlotId)
            {
            QueryInformation query;

            if (enhancementSlotId == Guid.Empty)
                return;

            query = QueryInformation.Create(LoadEnhancementSlotByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + IdField, DbType.Guid, enhancementSlotId));

            Initialize(query);
            }

        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(EnhancementSlotModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                query = QueryInformation.Create(EnhancementSlotModel.UpdateQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.EnhancementTreeIdField, DbType.Guid, this.EnhancementTreeId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.SlotIndexField, DbType.Int32, this.SlotIndex));
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.APRequirementField, DbType.Int32, this.APRequirement));
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.NameField, DbType.String, this.Name));
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.DescriptionField, DbType.String, this.Description));
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.IconField, DbType.String, this.Icon));
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.ActiveField, DbType.Boolean, this.Active));
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.UseEnhancementInfoField, DbType.Boolean, this.UseEnhancementInfo));

            BaseModel.RunCommand(query);
            }
        #endregion

        #region Public Static Members
        public static void DeleteAllByEnhancementTreeId(Guid treeId)
            {
            QueryInformation query;

            if (treeId == Guid.Empty)
                return;

            query = QueryInformation.Create(DeleteByEnhancementTreeIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.EnhancementTreeIdField, DbType.Guid, treeId));
            BaseModel.RunCommand(query);

            }

        public static List<EnhancementSlotModel> GetAll(Guid treeId)
            {
            QueryInformation query;

            if (treeId == Guid.Empty)
                return new List<EnhancementSlotModel>();

            query = QueryInformation.Create(EnhancementSlotModel.LoadEnhancementSlotByEnhancementTreeIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.EnhancementTreeIdField, DbType.Guid, treeId));

            return BaseModel.GetAll<EnhancementSlotModel>(query, EnhancementSlotModel.Create);

            }

        public static Guid GetIdFromTreeIdandSlotIndex(Guid treeId, int slotIndex)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(EnhancementSlotModel.GetEnhancementSlotIdFromTreeIdandSlotIndex);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.EnhancementTreeIdField, DbType.Guid, treeId));
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.SlotIndexField, DbType.Int32, slotIndex));

            ids = BaseModel.GetIds(query, EnhancementSlotModel.ReadId);
            if (ids == null || ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
            }

        public static int GetRecordCount()
            {
            QueryInformation query;

            query = QueryInformation.Create(CountQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetCount(query);
            }

        public static int GetRecordCount(Guid treeId)
            {
            QueryInformation query;

            if (treeId == Guid.Empty)
                return 0;

            query = QueryInformation.Create(CountByEnhancementTreeIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementSlotModel.EnhancementTreeIdField, DbType.Guid, treeId));

            return BaseModel.GetCount(query);
            }


        #endregion
        }
    }
