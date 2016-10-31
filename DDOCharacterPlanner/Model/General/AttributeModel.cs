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
    /// Defines the data availAttribute for an Attribute Record
    /// </summary>
    public sealed class AttributeModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "AttributeId";
        private const string NameField = "Name";
        private const string DescriptionField = "Description";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        private const string LoadAttributeByIdQuery = "SELECT * FROM Attribute WHERE AttributeId=@AttributeId";
        private const string LoadAttributeByNameQuery = "SELECT * FROM Attribute WHERE Name=@Name";

        private const string GetIdsQuery = "SELECT AttributeId FROM Attribute";
        private const string GetNamesQuery = "SELECT Name FROM Attribute";
        private const string GetIdFromNameQuery = "SELECT AttributeId FROM Attribute WHERE Name=@Name";
        private const string GetNameFromIdQuery = "SELECT Name FROM Attribute WHERE AttributeId=@AttributeId";

        //Commented these out for now as this particular table shouldn't ever be manipulated by the end user.
        //private const string DeleteQuery = "DELETE FROM Attribute WHERE AttributeId=@AttributeId";
        //private const string InsertQuery = "INSERT INTO Attribute (AttributeId, Name, Description, LastUpdatedDate, LastUpdatedVersion) VALUES (@AttributeId, @Name, @Description, @LastUpdatedDate, @LastUpdatedVersion)";
        //private const string UpdateQuery = "UPDATE Attribute SET Name=@Name, Description=@Description, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE AttributeId=@AttributeId";
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

            if (reader.TryGetOrdinal(AttributeModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(AttributeModel.NameField, out ordinal))
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

            if (!reader.TryGetOrdinal(AttributeModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(AttributeModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.Name = reader.GetString(ordinal);
                }

            if (reader.TryGetOrdinal(AttributeModel.DescriptionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.Description = reader.GetString(ordinal);
                }

            if (reader.TryGetOrdinal(AttributeModel.LastUpdatedDateField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);
                }

            if (reader.TryGetOrdinal(AttributeModel.LastUpdatedVersionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedVersion = reader.GetString(ordinal);
                }
            }
        #endregion

        #region Public Methods
        /// <summary>
        /// Create the specified Attribute Model
        /// </summary>
        /// <param name="AttributeId">AttributeId of the Attribute</param>
        public void Initialize(Guid attributeId)
            {
            QueryInformation query;

            if (attributeId == Guid.Empty)
                {
                return;
                }

            query = QueryInformation.Create(AttributeModel.LoadAttributeByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + AttributeModel.IdField, DbType.Guid, attributeId));

            this.Initialize(query);
            }

        /// <summary>
        /// Creates the specified Attribute Model
        /// </summary>
        /// <param name="feattypeName">Name of the Attribute.</param>
        public void Initialize(string attributeName)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(attributeName))
                {
                return;
                }
            query = QueryInformation.Create(AttributeModel.LoadAttributeByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + AttributeModel.NameField, DbType.String, attributeName));

            this.Initialize(query);
            }

        #endregion

        #region Public Static Methods
        /// <summary>
        /// Gets all the Attribute Ids
        /// </summary>
        /// <returns>A list of all the Attribute ids</returns>
        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(AttributeModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, AttributeModel.ReadId);
            }

        /// <summary>
        /// Gets all the Attribute names
        /// </summary>
        /// <returns>A list of all the Race names.</return>
        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(AttributeModel.GetNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, AttributeModel.ReadName);
            }

        /// <summary>
        /// Get the Ablity id of the specified Attribute
        /// </summary>
        /// <param name="name">Name of the Attribute</param>
        /// <returns>An Id of the Attribute</returns>
        public static Guid GetIdFromName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(AttributeModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + AttributeModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, AttributeModel.ReadId);
            if (ids == null || ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
            }

        /// <summary>
        /// Get the Attribute Name of the specified Attribute
        /// </summary>
        /// <param name="AttributeId">Id of the Attribute</param>
        /// <returns>the Name of the Attribute</returns>
        public static string GetNameFromId(Guid attributeId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(AttributeModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + AttributeModel.IdField, DbType.Guid, attributeId));

            names = BaseModel.GetNames(query, AttributeModel.ReadName);
            if (names == null)
                return "";
            else
                return names[0];
            }
        #endregion
        }
    }

