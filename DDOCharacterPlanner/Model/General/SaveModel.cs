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
    /// Defines the data availSave for an Save Record
    /// </summary>
    public sealed class SaveModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "SaveId";
        private const string NameField = "Name";
        private const string DescriptionField = "Description";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        private const string LoadSaveByIdQuery = "SELECT * FROM SaveTable WHERE SaveId=@SaveId";
        private const string LoadSaveByNameQuery = "SELECT * FROM SaveTable WHERE Name=@Name";

        private const string GetIdsQuery = "SELECT SaveId FROM SaveTable";
        private const string GetNamesQuery = "SELECT Name FROM SaveTable";
        private const string GetIdFromNameQuery = "SELECT SaveId FROM SaveTable WHERE Name=@Name";
        private const string GetNameFromIdQuery = "SELECT Name FROM SaveTable WHERE SaveId=@SaveId";

        //Commented these out for now as this particular table shouldn't ever be manipulated by the end user.
        //private const string DeleteQuery = "DELETE FROM Save WHERE SaveId=@SaveId";
        //private const string InsertQuery = "INSERT INTO Save (SaveId, Name, Description, LastUpdatedDate, LastUpdatedVersion) VALUES (@SaveId, @Name, @Description, @LastUpdatedDate, @LastUpdatedVersion)";
        //private const string UpdateQuery = "UPDATE Save SET Name=@Name, Description=@Description, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE SaveId=@SaveId";
        #endregion

        #region Properties
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

            if (reader.TryGetOrdinal(SaveModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(SaveModel.NameField, out ordinal))
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

            if (!reader.TryGetOrdinal(SaveModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(SaveModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.Name = reader.GetString(ordinal);
                }

            if (reader.TryGetOrdinal(SaveModel.DescriptionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.Description = reader.GetString(ordinal);
                }

            if (reader.TryGetOrdinal(SaveModel.LastUpdatedDateField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);
                }

            if (reader.TryGetOrdinal(SaveModel.LastUpdatedVersionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedVersion = reader.GetString(ordinal);
                }
            }
        #endregion

        #region Public Methods
        /// <summary>
        /// Create the specified Save Model
        /// </summary>
        /// <param name="SaveId">SaveId of the Save</param>
        public void Initialize(Guid saveId)
            {
            QueryInformation query;

            if (saveId == Guid.Empty)
                {
                return;
                }

            query = QueryInformation.Create(SaveModel.LoadSaveByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + SaveModel.IdField, DbType.Guid, saveId));

            this.Initialize(query);
            }

        /// <summary>
        /// Creates the specified Save Model
        /// </summary>
        /// <param name="feattypeName">Name of the Save.</param>
        public void Initialize(string saveName)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(saveName))
                {
                return;
                }
            query = QueryInformation.Create(SaveModel.LoadSaveByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + SaveModel.NameField, DbType.String, saveName));

            this.Initialize(query);
            }

        #endregion

        #region Public Static Methods
        /// <summary>
        /// Gets all the Save Ids
        /// </summary>
        /// <returns>A list of all the Save ids</returns>
        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(SaveModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, SaveModel.ReadId);
            }

        /// <summary>
        /// Gets all the Save names
        /// </summary>
        /// <returns>A list of all the Race names.</return>
        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(SaveModel.GetNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, SaveModel.ReadName);
            }

        /// <summary>
        /// Get the Ablity id of the specified Save
        /// </summary>
        /// <param name="name">Name of the Save</param>
        /// <returns>An Id of the Save</returns>
        public static Guid GetIdFromName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(SaveModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + SaveModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, SaveModel.ReadId);
            if (ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
            }

        /// <summary>
        /// Get the Save Name of the specified Save
        /// </summary>
        /// <param name="SaveId">Id of the Save</param>
        /// <returns>the Name of the Save</returns>
        public static string GetNameFromId(Guid SaveId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(SaveModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + SaveModel.IdField, DbType.Guid, SaveId));

            names = BaseModel.GetNames(query, SaveModel.ReadName);
            if (names.Count == 0)
                return "";
            else
                return names[0];
            }
        #endregion
        }
    }

