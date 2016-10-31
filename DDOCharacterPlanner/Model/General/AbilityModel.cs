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
    /// Defines the data availability for an Ability Record
    /// </summary>
    public sealed class AbilityModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "AbilityId";
        private const string NameField = "Name";
        private const string DescriptionField = "Description";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        private const string LoadAbilityByIdQuery = "SELECT * FROM Ability WHERE AbilityId=@AbilityId";
        private const string LoadAbilityByNameQuery = "SELECT * FROM Ability WHERE Name=@Name";

        private const string GetIdsQuery = "SELECT AbilityId FROM Ability";
        private const string GetNamesQuery = "SELECT Name FROM Ability";
        private const string GetIdFromNameQuery = "SELECT AbilityId FROM Ability WHERE Name=@Name";
        private const string GetNameFromIdQuery = "SELECT Name FROM Ability WHERE AbilityId=@AbilityId";

        //Commented these out for now as this particular table shouldn't ever be manipulated by the end user.
        //private const string DeleteQuery = "DELETE FROM Ability WHERE AbilityId=@AbilityId";
        //private const string InsertQuery = "INSERT INTO Ability (AbilityId, Name, Description, LastUpdatedDate, LastUpdatedVersion) VALUES (@AbilityId, @Name, @Description, @LastUpdatedDate, @LastUpdatedVersion)";
        //private const string UpdateQuery = "UPDATE Ability SET Name=@Name, Description=@Description, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE AbilityId=@AbilityId";
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

            if (reader.TryGetOrdinal(AbilityModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(AbilityModel.NameField, out ordinal))
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

            if (!reader.TryGetOrdinal(AbilityModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(AbilityModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.Name = reader.GetString(ordinal);
                }

            if (reader.TryGetOrdinal(AbilityModel.DescriptionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.Description = reader.GetString(ordinal);
                }

            if (reader.TryGetOrdinal(AbilityModel.LastUpdatedDateField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);
                }

            if (reader.TryGetOrdinal(AbilityModel.LastUpdatedVersionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedVersion = reader.GetString(ordinal);
                }
            }
        #endregion

        #region Public Methods
        /// <summary>
        /// Create the specified Ability Model
        /// </summary>
        /// <param name="abilityId">AbilityId of the Ability</param>
        public void Initialize(Guid abilityId)
            {
            QueryInformation query;

            if (abilityId == Guid.Empty)
                {
                return;
                }

            query = QueryInformation.Create(AbilityModel.LoadAbilityByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + AbilityModel.IdField, DbType.Guid, abilityId));

            this.Initialize(query);
            }

        /// <summary>
        /// Creates the specified Ability Model
        /// </summary>
        /// <param name="feattypeName">Name of the ability.</param>
        public void Initialize(string abilityName)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(abilityName))
                {
                return;
                }
            query = QueryInformation.Create(AbilityModel.LoadAbilityByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + AbilityModel.NameField, DbType.String, abilityName));

            this.Initialize(query);
            }

        #endregion

        #region Public Static Methods
        /// <summary>
        /// Gets all the Ability Ids
        /// </summary>
        /// <returns>A list of all the Ability ids</returns>
        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(AbilityModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, AbilityModel.ReadId);
            }

        /// <summary>
        /// Gets all the ability names
        /// </summary>
        /// <returns>A list of all the Race names.</return>
        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(AbilityModel.GetNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, AbilityModel.ReadName);
            }

        /// <summary>
        /// Get the Ablity id of the specified Ability
        /// </summary>
        /// <param name="name">Name of the Ability</param>
        /// <returns>An Id of the Ability</returns>
        public static Guid GetIdFromName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(AbilityModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + AbilityModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, AbilityModel.ReadId);
            if (ids == null)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
            }

        /// <summary>
        /// Get the Ability Name of the specified Ability
        /// </summary>
        /// <param name="abilityId">Id of the Ability</param>
        /// <returns>the Name of the Ability</returns>
        public static string GetNameFromId(Guid abilityId)
            {            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(AbilityModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + AbilityModel.IdField, DbType.Guid, abilityId));

            names = BaseModel.GetNames(query, AbilityModel.ReadName);
            if (names == null)
                return "";
            else
                return names[0];

            }
        #endregion
        }
    }
