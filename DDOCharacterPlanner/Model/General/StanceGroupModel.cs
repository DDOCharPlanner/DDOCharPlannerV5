using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.DataAccess;
using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Model
    {
    public sealed class StanceGroupModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "StanceGroupId";
        private const string GroupNameField = "GroupName";
        private const string OnlyOneStanceField = "OnlyOneStance";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        //Count Queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM Stance";
        private const string CountByNameQuery = "SELECT COUNT(*) AS Count From Stance WHERE GroupName=@GroupName";
        //Load Queries
        private const string LoadStanceByIdQuery = "SELECT * FROM Stance WHERE StanceGroupID=@StanceGroupId";
        private const string LoadStanceByNameQuery = "SELECT * FROM Stance WHERE StanceName=@StanceName";
        //Get Value Queries
        private const string GetIdsQuery = "SELECT StanceGroupId FROM Stance";
        private const string GetNamesQuery = "SELECT GroupName FROM Stance ORDER BY GroupName";
        private const string GetIdFromNameQuery = "SELECT StanceGroupId FROM Stance WHERE GroupName=@GroupName";
        private const string GetNameFromIdQuery = "SELECT GroupName FROM Stance WHERE StanceGroupId=@StanceGroupId";
        //Change Queries
        private const string DeleteQuery = "DELETE FROM Stance WHERE StanceGroupId=@StanceID";
        private const string InsertQuery = "INSERT INTO Stance (StanceGroupId, GroupName, OnlyOneStance, LastUpdatedDate, LastUpdatedVersion) VALUES (@StanceGroupId, @GroupName, @OnlyOneStance, @LastUpdatedDate, @LastUpdatedVersion)";
        private const string UpdateQuery = "UPDATE Stance SET GroupName=@GroupName, OnlyOneStance=@OnlyOneStance, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE StanceGroupId=@StanceGroupId";

        #endregion

        #region Properties
        public string GroupName { get; set; }
        public bool OnlyOneStance { get; set; }

        #endregion

        #region Private Static Members
        private static StanceGroupModel Create(DbDataReader reader)
            {
            StanceGroupModel model;
            model = new StanceGroupModel();
            model.Load(reader);

            return model;
            }

        private static Guid ReadId(DbDataReader reader)
            {
            int ordinal;
            Guid id = Guid.Empty;

            if (reader == null)
                return Guid.Empty;

            if (reader.TryGetOrdinal(StanceGroupModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(StanceGroupModel.GroupNameField, out ordinal))
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

            if (!reader.TryGetOrdinal(StanceGroupModel.IdField, out ordinal))
                return; //No id field, can't use

            if (reader.IsDBNull(ordinal))
                return; //Null, can't use

            this.Id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(StanceGroupModel.GroupNameField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.GroupName = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(StanceGroupModel.OnlyOneStanceField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.OnlyOneStance = reader.GetBoolean(ordinal);

            if (reader.TryGetOrdinal(StanceGroupModel.LastUpdatedDateField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);

            if (reader.TryGetOrdinal(StanceGroupModel.LastUpdatedVersionField, out ordinal))
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
                Debug.WriteLine("Error: You can't delete this record as one doesn't exist for it. StanceGroupModel:Delete()");
                return;
                }
            //We need to delete any associated records first before deleteing this Stance record
            StanceModel.DeleteAllByStanceGroupId(this.Id);

            query = QueryInformation.Create(StanceGroupModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + StanceGroupModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);
            //reset the id so that the model knows it is a new record if someone tries to call the save() method afterwards.
            this.Id = Guid.Empty;
            }

        public void Initialize(Guid stanceId)
            {
            QueryInformation query;

            if (stanceId == Guid.Empty)
                return;

            query = QueryInformation.Create(StanceGroupModel.LoadStanceByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + StanceGroupModel.IdField, DbType.Guid, stanceId));

            this.Initialize(query);
            }

        public void Initialize(string name)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(name))
                return;

            query = QueryInformation.Create(StanceGroupModel.LoadStanceByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + StanceGroupModel.GroupNameField, DbType.String, name));

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
            query.Parameters.Add(new QueryParameter("@" + StanceGroupModel.IdField, DbType.Guid, Id));
            query.Parameters.Add(new QueryParameter("@" + StanceGroupModel.GroupNameField, DbType.String, GroupName));
            query.Parameters.Add(new QueryParameter("@" + StanceGroupModel.OnlyOneStanceField, DbType.Boolean, OnlyOneStance));
            query.Parameters.Add(new QueryParameter("@" + StanceGroupModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + StanceGroupModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));
            BaseModel.RunCommand(query);
            }

        #endregion

        #region Public Static Stances
        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(StanceGroupModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, StanceGroupModel.ReadId);
            }

        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(StanceGroupModel.GetNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, StanceGroupModel.ReadName);
            }

        public static Guid GetIdFromGroupName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(StanceGroupModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + StanceGroupModel.GroupNameField, DbType.String, name));

            ids = BaseModel.GetIds(query, StanceGroupModel.ReadId);
            if (ids == null)
                return Guid.Empty;
            else
                return ids[0]; //there shoudl only be one value!
            }

        public static string GetGroupNameFromId(Guid stanceGroupId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(StanceGroupModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + StanceGroupModel.IdField, DbType.Guid, stanceGroupId));

            names = BaseModel.GetNames(query, StanceGroupModel.ReadName);
            if (names == null)
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

        #endregion

        }
    }
