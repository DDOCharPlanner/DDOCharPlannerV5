using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.DataAccess;
using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Model
    {
    public sealed class TableNamesModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "TableNamesId";
        private const string TableNameField = "TableName";
        private const string RequirementUsageField = "RequirementUsage";
        private const string ModifierUsageField = "ModifierUsage";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        //Count Queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM TableNames";
        //Load Queries
        private const string LoadTableNamesByIdQuery = "SELECT * FROM TableNames WHERE TableNamesID=@TableNamesId";
        private const string LoadTableNamesByNameQuery = "SELECT * FROM TableNames WHERE TableName=@TableName";
        //Get Value Queries
        private const string GetIdsQuery = "SELECT TableNamesId FROM TableNames";
        private const string GetNamesQuery = "SELECT TableName FROM TableNames ORDER BY TableName";
        private const string GetNamesByRequirementUsageQuery = "SELECT TableName FROM TableNames WHERE RequirementUsage=@RequirementUsage ORDER BY TableName";
        private const string GetNamesByModifierUsageQuery = "SELECT TableName FROM TableNames WHERE ModifierUsage=@ModifierUsage ORDER BY TableName";
        
        private const string GetIdFromNameQuery = "SELECT TableNamesId FROM TableNames WHERE TableName=@TableName";
        private const string GetNameFromIdQuery = "SELECT TableName FROM TableNames WHERE TableNamesId=@TableNamesId";
        //Change Queries
        // None here atm, as this table should only get modified by the developers.

        #endregion

        #region Properties
        public string TableName { get; set; }
        public bool RequirementUsage { get; set; }
        public bool ModifierUsage { get; set; }

        #endregion

        #region Private Static Members

        private static Guid ReadId(DbDataReader reader)
            {
            int ordinal;
            Guid id = Guid.Empty;

            if (reader == null)
                return Guid.Empty;

            if (reader.TryGetOrdinal(TableNamesModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(TableNamesModel.TableNameField, out ordinal))
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

            if (!reader.TryGetOrdinal(TableNamesModel.IdField, out ordinal))
                return; //No id field, can't use

            if (reader.IsDBNull(ordinal))
                return; //Null, can't use

            this.Id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(TableNamesModel.TableNameField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.TableName = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(TableNamesModel.RequirementUsageField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.RequirementUsage = reader.GetBoolean(ordinal);

            if (reader.TryGetOrdinal(TableNamesModel.ModifierUsageField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.ModifierUsage = reader.GetBoolean(ordinal);

            if (reader.TryGetOrdinal(TableNamesModel.LastUpdatedDateField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);

            if (reader.TryGetOrdinal(TableNamesModel.LastUpdatedVersionField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedVersion = reader.GetString(ordinal);
            }

        #endregion

        #region Public Members
        public void Initialize(Guid tableNamesId)
            {
            QueryInformation query;

            if (tableNamesId == Guid.Empty)
                return;

            query = QueryInformation.Create(TableNamesModel.LoadTableNamesByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TableNamesModel.IdField, DbType.Guid, tableNamesId));

            this.Initialize(query);
            }

        public void Initialize(string tableName)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(tableName))
                return;

            query = QueryInformation.Create(TableNamesModel.LoadTableNamesByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TableNamesModel.TableNameField, DbType.String, tableName));

            this.Initialize(query);
            }
        #endregion

        #region Public Static Methods
        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(TableNamesModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, TableNamesModel.ReadId);
            }

        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(TableNamesModel.GetNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, TableNamesModel.ReadName);
            }

        public static List<string> GetNamesByRequirementUsage(bool flag)
            {
            QueryInformation query;

            query = QueryInformation.Create(TableNamesModel.GetNamesByRequirementUsageQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TableNamesModel.RequirementUsageField, DbType.Boolean, flag));

            return BaseModel.GetNames(query, TableNamesModel.ReadName);
            }

        public static List<string> GetNamesByModifierUsage(bool flag)
            {
            QueryInformation query;

            query = QueryInformation.Create(TableNamesModel.GetNamesByModifierUsageQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TableNamesModel.ModifierUsageField, DbType.Boolean, flag));

            return BaseModel.GetNames(query, TableNamesModel.ReadName);
            }

        public static Guid GetIdFromTableName(string tableName)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(TableNamesModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TableNamesModel.TableNameField, DbType.String, tableName));

            ids = BaseModel.GetIds(query, TableNamesModel.ReadId);
            if (ids == null)
                return Guid.Empty;
            else
                return ids[0]; //there shoudl only be one value!
            }

        public static string GetTableNameFromId(Guid tableNamesId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(TableNamesModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TableNamesModel.IdField, DbType.Guid, tableNamesId));

            names = BaseModel.GetNames(query, TableNamesModel.ReadName);
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

