using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.DataAccess;
using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Model
    {
    public sealed class ModifierMethodModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "ModifierMethodId";
        private const string MethodNameField = "MethodName";
        private const string MethodDescriptionField = "MethodDescription";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        //Count Queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM ModifierMethod";
        //Load Queries
        private const string LoadModifierMethodByIdQuery = "SELECT * FROM ModifierMethod WHERE ModifierMethodID=@ModifierMethodId";
        private const string LoadModifierMethodByNameQuery = "SELECT * FROM ModifierMethod WHERE MethodName=@MethodName";
        //Get Value Queries
        private const string GetIdsQuery = "SELECT ModifierMethodId FROM ModifierMethod";
        private const string GetNamesQuery = "SELECT MethodName FROM ModifierMethod ORDER BY MethodName";
        private const string GetIdFromNameQuery = "SELECT ModifierMethodId FROM ModifierMethod WHERE MethodName=@MethodName";
        private const string GetNameFromIdQuery = "SELECT MethodName FROM ModifierMethod WHERE ModifierMethodId=@ModifierMethodId";
        //Change Queries
        // None here atm, as this table should only get modified by the developers.

        #endregion

        #region Properties
        public string MethodName { get; set; }
        public string MethodDescription { get; set; }
        
        #endregion

        #region Private Static Members
 
        private static Guid ReadId(DbDataReader reader)
            {
            int ordinal;
            Guid id = Guid.Empty;

            if (reader == null)
                return Guid.Empty;

            if (reader.TryGetOrdinal(ModifierMethodModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(ModifierMethodModel.MethodNameField, out ordinal))
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

            if (!reader.TryGetOrdinal(ModifierMethodModel.IdField, out ordinal))
                return; //No id field, can't use

            if (reader.IsDBNull(ordinal))
                return; //Null, can't use

            this.Id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(ModifierMethodModel.MethodNameField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.MethodName = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(ModifierMethodModel.MethodDescriptionField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.MethodDescription = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(ModifierMethodModel.LastUpdatedDateField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);

            if (reader.TryGetOrdinal(ModifierMethodModel.LastUpdatedVersionField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedVersion = reader.GetString(ordinal);
            }

        #endregion

        #region Public Members
        public void Initialize(Guid modifierMethodId)
            {
            QueryInformation query;

            if (modifierMethodId == Guid.Empty)
                return;

            query = QueryInformation.Create(ModifierMethodModel.LoadModifierMethodByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ModifierMethodModel.IdField, DbType.Guid, modifierMethodId));

            this.Initialize(query);
            }

        public void Initialize(string methodName)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(methodName))
                return;

            query = QueryInformation.Create(ModifierMethodModel.LoadModifierMethodByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ModifierMethodModel.MethodNameField, DbType.String, methodName));

            this.Initialize(query);
            }
        #endregion

        #region Public Static Methods
        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(ModifierMethodModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, ModifierMethodModel.ReadId);
            }

        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(ModifierMethodModel.GetNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, ModifierMethodModel.ReadName);
            }

        public static Guid GetIdFromMethodName(string methodName)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(ModifierMethodModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ModifierMethodModel.MethodNameField, DbType.String, methodName));

            ids = BaseModel.GetIds(query, ModifierMethodModel.ReadId);
            if (ids == null)
                return Guid.Empty;
            else
                return ids[0]; //there shoudl only be one value!
            }

        public static string GetMethodNameFromId(Guid methodId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(ModifierMethodModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ModifierMethodModel.IdField, DbType.Guid, methodId));

            names = BaseModel.GetNames(query, ModifierMethodModel.ReadName);
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

        #endregion

        }
    }
