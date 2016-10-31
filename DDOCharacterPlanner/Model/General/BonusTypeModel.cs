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
    /// Defines the data availability for an BonusType Record
    /// </summary>
    public sealed class BonusTypeModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "BonusTypeId";
        private const string NameField = "Name";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        private const string LoadBonusTypeByIdQuery = "SELECT * FROM BonusType WHERE BonusTypeId=@BonusTypeId";
        private const string LoadBonusTypeByNameQuery = "SELECT * FROM BonusType WHERE Name=@Name";

        private const string GetIdsQuery = "SELECT BonusTypeId FROM BonusType";
        private const string GetNamesQuery = "SELECT Name FROM BonusType";
        private const string GetIdFromNameQuery = "SELECT BonusTypeId FROM BonusType WHERE Name=@Name";
        private const string GetNameFromIdQuery = "SELECT Name FROM BonusType WHERE BonusTypeId=@BonusTypeId";

        private const string DeleteQuery = "DELETE FROM BonusType WHERE BonusTypeId=@BonusTypeId";
        private const string InsertQuery = "INSERT INTO BonusType (BonusTypeId, Name, LastUpdatedDate, LastUpdatedVersion) VALUES (@BonusTypeId, @Name, @LastUpdatedDate, @LastUpdatedVersion)";
        private const string UpdateQuery = "UPDATE BonusType SET Name=@Name, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE BonusTypeId=@BonusTypeId";
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

            if (reader.TryGetOrdinal(BonusTypeModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(BonusTypeModel.NameField, out ordinal))
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

            if (!reader.TryGetOrdinal(BonusTypeModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(BonusTypeModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.Name = reader.GetString(ordinal);
                }

            if (reader.TryGetOrdinal(BonusTypeModel.LastUpdatedDateField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);
                }

            if (reader.TryGetOrdinal(BonusTypeModel.LastUpdatedVersionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedVersion = reader.GetString(ordinal);
                }
            }
        #endregion

        #region Public Methods
        /// <summary>
        /// Create the specified BonusType Model
        /// </summary>
        /// <param name="bonusTypeId">BonusTypeId of the BonusType</param>
        public void Initialize(Guid bonusTypeId)
            {
            QueryInformation query;

            if (bonusTypeId == Guid.Empty)
                {
                return;
                }

            query = QueryInformation.Create(BonusTypeModel.LoadBonusTypeByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + BonusTypeModel.IdField, DbType.Guid, bonusTypeId));

            this.Initialize(query);
            }

        /// <summary>
        /// Creates the specified BonusType Model
        /// </summary>
        /// <param name="feattypeName">Name of the bonusType.</param>
        public void Initialize(string bonusTypeName)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(bonusTypeName))
                {
                return;
                }
            query = QueryInformation.Create(BonusTypeModel.LoadBonusTypeByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + BonusTypeModel.NameField, DbType.String, bonusTypeName));

            this.Initialize(query);
            }

        /// <summary>
        /// Deletes the currently loaded BonusType
        /// </summary>
        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can not delete this record, there is no database entry for it. BonusTypeModel : Delete()");
                return;
                }

            //Need to delete associated records first before deleting the Main record.
            //TODO: Delete or change records that use this BonusType.

            query = QueryInformation.Create(BonusTypeModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + BonusTypeModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);

            //lets reset the Id to empty so the model knows it is a new record now if the "Save()" is called afterwards for some reason.
            this.Id = Guid.Empty;
            }

        /// <summary>
        /// Saves the currently loaded BonusType
        /// </summary>
        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(BonusTypeModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                {
                query = QueryInformation.Create(BonusTypeModel.UpdateQuery);
                }

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + BonusTypeModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + BonusTypeModel.NameField, DbType.String, this.Name));
            query.Parameters.Add(new QueryParameter("@" + BonusTypeModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + BonusTypeModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));

            BaseModel.RunCommand(query);

            }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Gets all the BonusType Ids
        /// </summary>
        /// <returns>A list of all the BonusType ids</returns>
        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(BonusTypeModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, BonusTypeModel.ReadId);
            }

        /// <summary>
        /// Gets all the bonusType names
        /// </summary>
        /// <returns>A list of all the Race names.</return>
        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(BonusTypeModel.GetNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, BonusTypeModel.ReadName);
            }

        /// <summary>
        /// Get the Ablity id of the specified BonusType
        /// </summary>
        /// <param name="name">Name of the BonusType</param>
        /// <returns>An Id of the BonusType</returns>
        public static Guid GetIdFromName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(BonusTypeModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + BonusTypeModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, BonusTypeModel.ReadId);
            if (ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
            }

        /// <summary>
        /// Get the BonusType Name of the specified BonusType
        /// </summary>
        /// <param name="bonusTypeId">Id of the BonusType</param>
        /// <returns>the Name of the BonusType</returns>
        public static string GetNameFromId(Guid bonusTypeId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(BonusTypeModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + BonusTypeModel.IdField, DbType.Guid, bonusTypeId));

            names = BaseModel.GetNames(query, BonusTypeModel.ReadName);
            if (names.Count == 0)
                return "";
            else
                return names[0];
            }
        #endregion
        }
    }

