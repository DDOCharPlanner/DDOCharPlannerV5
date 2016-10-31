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
    /// Defines the data availability for an Target Record
    /// </summary>
    public sealed class TargetModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "TargetId";
        private const string NameField = "Name";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        private const string LoadTargetByIdQuery = "SELECT * FROM Target WHERE TargetId=@TargetId";
        private const string LoadTargetByNameQuery = "SELECT * FROM Target WHERE Name=@Name";

        private const string GetIdsQuery = "SELECT TargetId FROM Target";
        private const string GetNamesQuery = "SELECT Name FROM Target";
        private const string GetIdFromNameQuery = "SELECT TargetId FROM Target WHERE Name=@Name";
        private const string GetNameFromIdQuery = "SELECT Name FROM Target WHERE TargetId=@TargetId";

        //Commented these out for now as this particular table shouldn't ever be manipulated by the end user.
        //private const string DeleteQuery = "DELETE FROM Target WHERE TargetId=@TargetId";
        //private const string InsertQuery = "INSERT INTO Target (TargetId, Name, LastUpdatedDate, LastUpdatedVersion) VALUES (@TargetId, @Name, @LastUpdatedDate, @LastUpdatedVersion)";
        //private const string UpdateQuery = "UPDATE Target SET Name=@Name, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE TargetId=@TargetId";
        #endregion

        #region Properties
        public string Name
            {
            get;
            set;
            }

        #endregion

        #region Private Static Methods
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

            if (reader.TryGetOrdinal(TargetModel.IdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    id = reader.GetGuid(ordinal);
                }
            return id;
            }

        /// <summary>
        /// Reads the Name
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <returns>the name</returns>
        private static string ReadName(DbDataReader reader)
            {
            int ordinal;
            string name = null;

            if (reader == null)
                return null;

            if (reader.TryGetOrdinal(TargetModel.NameField, out ordinal))
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

            if (!reader.TryGetOrdinal(TargetModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(TargetModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.Name = reader.GetString(ordinal);
                }

            if (reader.TryGetOrdinal(TargetModel.LastUpdatedDateField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);
                }

            if (reader.TryGetOrdinal(TargetModel.LastUpdatedVersionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedVersion = reader.GetString(ordinal);
                }
            }
        #endregion

        #region Public Methods
        /// <summary>
        /// Create the specified Target Model
        /// </summary>
        /// <param name="abilityId">TargetId of the Target</param>
        public void Initialize(Guid targetId)
            {
            QueryInformation query;

            if (targetId == Guid.Empty)
                {
                return;
                }

            query = QueryInformation.Create(TargetModel.LoadTargetByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TargetModel.IdField, DbType.Guid, targetId));

            this.Initialize(query);
            }

        /// <summary>
        /// Creates the specified Target Model
        /// </summary>
        /// <param name="feattypeName">Name of the Target.</param>
        public void Initialize(string targetName)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(targetName))
                {
                return;
                }
            query = QueryInformation.Create(TargetModel.LoadTargetByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TargetModel.NameField, DbType.String, targetName));

            this.Initialize(query);
            }

        #endregion

        #region Public Static Methods
        /// <summary>
        /// Gets all the Target Ids
        /// </summary>
        /// <returns>A list of all the Target ids</returns>
        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(TargetModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, TargetModel.ReadId);
            }

        /// <summary>
        /// Gets all the target names
        /// </summary>
        /// <returns>A list of all the Race names.</return>
        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(TargetModel.GetNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, TargetModel.ReadName);
            }

        /// <summary>
        /// Get the Ablity id of the specified Target
        /// </summary>
        /// <param name="name">Name of the Target</param>
        /// <returns>An Id of the Target</returns>
        public static Guid GetIdFromName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(TargetModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TargetModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, TargetModel.ReadId);
            if (ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
            }

        /// <summary>
        /// Get the Target Name of the specified Target
        /// </summary>
        /// <param name="abilityId">Id of the Target</param>
        /// <returns>the Name of the Target</returns>
        public static string GetNameFromId(Guid abilityId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(TargetModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + TargetModel.IdField, DbType.Guid, abilityId));

            names = BaseModel.GetNames(query, TargetModel.ReadName);
            if (names.Count == 0)
                return "";
            else
                return names[0];
            }
        #endregion
        }
    }
