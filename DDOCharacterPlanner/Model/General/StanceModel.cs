using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.DataAccess;
using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Model
    {
    public sealed class StanceModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "StanceId";
        private const string StanceGroupIdField = "StanceGroupId";
        private const string StanceNameField = "StanceName";
        private const string StanceDescriptionField = "StanceDescription";
        private const string StanceIconField = "StanceIcon";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        //Count Queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM Stance";
        private const string CountByNameQuery = "SELECT COUNT(*) AS Count From Stance WHERE StanceName=@StanceName";
        //Load Queries
        private const string LoadStanceByIdQuery = "SELECT * FROM Stance WHERE StanceID=@StanceId";
        private const string LoadStanceByNameQuery = "SELECT * FROM Stance WHERE StanceName=@StanceName";
        private const string LoadStanceByStanceGroupIdQuery = "SELECT * FROM Stance WHERE StanceGroupId=@StanceGroupId";
        //Get Value Queries
        private const string GetIdsQuery = "SELECT StanceId FROM Stance";
        private const string GetNamesQuery = "SELECT StanceName FROM Stance ORDER BY StanceName";
        private const string GetIdFromNameQuery = "SELECT StanceId FROM Stance WHERE StanceName=@StanceName";
        private const string GetNameFromIdQuery = "SELECT StanceName FROM Stance WHERE StanceId=@StanceId";
        //Change Queries
        private const string DeleteQuery = "DELETE FROM Stance WHERE StanceId=@StanceID";
        private const string InsertQuery = "INSERT INTO Stance (StanceId, StanceGroupId, StanceName, StanceDescription, StanceIcon, LastUpdatedDate, LastUpdatedVersion) VALUES (@StanceId, @StanceGroupId, @StanceName, @StanceDescription, @StanceIcon, @LastUpdatedDate, @LastUpdatedVersion)";
        private const string UpdateQuery = "UPDATE Stance SET StanceGroupId=@StanceGroupId, StanceName=@StanceName, StanceDescription=@StanceDescription, StanceIcon=@StanceIcon, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE StanceId=@StanceId";

        #endregion

        #region Properties
        public Guid StanceGroupId { get; set; }
        public string StanceName { get; set; }
        public string StanceDescription { get; set; }
        public string StanceIcon { get; set; }

        #endregion

        #region Private Static Members
        private static StanceModel Create(DbDataReader reader)
            {
            StanceModel model;
            model = new StanceModel();
            model.Load(reader);

            return model;
            }

        private static Guid ReadId(DbDataReader reader)
            {
            int ordinal;
            Guid id = Guid.Empty;

            if (reader == null)
                return Guid.Empty;

            if (reader.TryGetOrdinal(StanceModel.IdField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    id = reader.GetGuid(ordinal);

            return id;
            }

        private static string ReadName(DbDataReader reader)
            {
            int ordinal;
            string name = null;

            if (reader == null)
                return null;

            if (reader.TryGetOrdinal(StanceModel.StanceNameField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    name = reader.GetString(ordinal);

            return name;
            }

        #endregion

        #region Protected Members
        protected override void Load(DbDataReader reader)
            {
            int ordinal;

            if (reader == null)
                return;

            if (!reader.TryGetOrdinal(StanceModel.IdField, out ordinal))
                return; //No id field, can't use

            if (reader.IsDBNull(ordinal))
                return; //Null, can't use

            this.Id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(StanceModel.StanceGroupIdField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.StanceGroupId = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(StanceModel.StanceNameField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.StanceName = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(StanceModel.StanceDescriptionField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.StanceDescription = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(StanceModel.StanceIconField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.StanceIcon = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(StanceModel.LastUpdatedDateField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);

            if (reader.TryGetOrdinal(StanceModel.LastUpdatedVersionField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedVersion = reader.GetString(ordinal);
            }

        #endregion

        #region Public Members
        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can't delete this record as one doesn't exist for it. StanceModel:Delete()");
                return;
                }
            //We need to delete any associated records first before deleteing this Stance record
            //TODO: FeatModifierModel.DeleteAllByStanceId(this.id);
            //TODO: EnhancementRankModel.DeleteAllByStanceId(this.id);
            //TODO: DestinyRankModel.DeleteAllByStanceId(this.id);

            //We need to update any associated records first before deleting this Stance Record
            //TODO: FeatModel.UpdateStanceIdWithNull(this.Id);
            //TODO: Enhancement.UpdateStanceIdWithNull(this.Id);

            query = QueryInformation.Create(StanceModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + StanceModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);
            //reset the id so that the model knows it is a new record if someone tries to call the save() method afterwards.
            this.Id = Guid.Empty;
            }

        public void Initialize(Guid stanceId)
            {
            QueryInformation query;

            if (stanceId == Guid.Empty)
                return;

            query = QueryInformation.Create(StanceModel.LoadStanceByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + StanceModel.IdField, DbType.Guid, stanceId));

            this.Initialize(query);
            }

        public void Initialize(string stanceName)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(stanceName))
                return;

            query = QueryInformation.Create(StanceModel.LoadStanceByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + StanceModel.StanceNameField, DbType.String, stanceName));

            this.Initialize(query);
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
                query = QueryInformation.Create(UpdateQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + StanceModel.IdField, DbType.Guid, Id));
            query.Parameters.Add(new QueryParameter("@" + StanceModel.StanceGroupIdField, DbType.Guid, StanceGroupId));
            query.Parameters.Add(new QueryParameter("@" + StanceModel.StanceNameField, DbType.String, StanceName));
            query.Parameters.Add(new QueryParameter("@" + StanceModel.StanceDescriptionField, DbType.String, StanceDescription));
            query.Parameters.Add(new QueryParameter("@" + StanceModel.StanceIconField, DbType.String, this.StanceIcon));
            query.Parameters.Add(new QueryParameter("@" + StanceModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + StanceModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));
            BaseModel.RunCommand(query);
            }

        #endregion

        #region Public Static Stances
        public static List<StanceModel> GetAllByGroupStanceId(Guid groupStanceId)
            {
            QueryInformation query;

            if (groupStanceId == Guid.Empty)
                return new List<StanceModel>();

            query = QueryInformation.Create(StanceModel.LoadStanceByStanceGroupIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + StanceModel.StanceGroupIdField, DbType.Guid, groupStanceId));

            return BaseModel.GetAll<StanceModel>(query, StanceModel.Create);
            }

        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(StanceModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, StanceModel.ReadId);
            }

        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(StanceModel.GetNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, StanceModel.ReadName);
            }

        public static Guid GetIdFromStanceName(string methodName)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(StanceModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + StanceModel.StanceNameField, DbType.String, methodName));

            ids = BaseModel.GetIds(query, StanceModel.ReadId);
            if (ids == null)
                return Guid.Empty;
            else
                return ids[0]; //there shoudl only be one value!
            }

        public static string GetStanceNameFromId(Guid methodId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(StanceModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + StanceModel.IdField, DbType.Guid, methodId));

            names = BaseModel.GetNames(query, StanceModel.ReadName);
            if (names == null || names.Count == 0)
                return "";
            else
                return names[0];
            }

        public static int GetRecordCount()
            {
            QueryInformation query;

            query = QueryInformation.Create(CountQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetCount(query);
            }

        public bool DoesStanceNameExist(string name)
            {
            QueryInformation query;

            query = QueryInformation.Create(StanceModel.CountByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + StanceModel.StanceNameField, DbType.String, name));

            return BaseModel.GetCount(query) > 0;
            }

        public static void DeleteAllByStanceGroupId(Guid groupStanceId)
            {
            List<StanceModel> models;

            if (groupStanceId == Guid.Empty)
                return; //Id is empty, so there are no records to delete as all records have a valid id.

            models = GetAllByGroupStanceId(groupStanceId);

            foreach (StanceModel model in models)
                {
                model.Delete();
                }
            }

        #endregion

        }
    }
