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
    /// Defines the data availability for an Modifier Record
    /// </summary>
    public sealed class ModifierModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "ModifierId";
        private const string TableNamesIdField = "TableNamesId";
        private const string ApplyToIdField = "ApplyToId";
        private const string NameField = "Name";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";
        //Count Queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM Modifier";
        //Load Queries
        private const string LoadModifierByIdQuery = "SELECT * FROM Modifier WHERE ModifierId=@ModifierId";
        private const string LoadModifierByNameQuery = "SELECT * FROM Modifier WHERE Name=@Name";
        private const string LoadModifierByApplyToIdandTableNamesIdQuery = "SELECT * FROM Modifier WHERE ApplyToId=@ApplyToId AND TableNamesId=@TableNamesId";
        //Get Value Queries
        private const string GetIdsQuery = "SELECT ModifierId FROM Modifier";
        private const string GetNamesQuery = "SELECT Name FROM Modifier ORDER BY Name";
        private const string GetIdFromNameQuery = "SELECT ModifierId FROM Modifier WHERE Name=@Name";
        private const string GetNameFromIdQuery = "SELECT Name FROM Modifier WHERE ModifierId=@ModifierId";
        private const string GetIdFromTableIdandApplyToIdQuery = "SELECT ModifierId FROM Modifier WHERE TableNamesId=@TableNamesId AND ApplyToId=@ApplyToId";

        //Change Queries
        private const string DeleteQuery = "DELETE FROM Modifier WHERE ModifierId=@ModifierId";
        //private const string DeleteByModifiedId = "DELETE FROM Modifier WHERE ModifierCategoryId=@ModifierCategoryId AND ModifiedId=@ModifiedId";
        private const string InsertQuery = "INSERT INTO Modifier (ModifierId, TableNamesId, ApplyToId, Name, LastUpdatedDate, LastUpdatedVersion) VALUES (@ModifierId, @TableNamesId, @ApplyToId, @Name, @LastUpdatedDate, @LastUpdatedVersion)";
        private const string UpdateQuery = "UPDATE Modifier SET TableNamesId=@TableNamesId, ApplyToId=@ApplyToId, Name=@Name, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE ModifierId=@ModifierId";
        #endregion

        #region Properties
        public Guid TableNamesId
            {
            get;
            set;
            }

        public Guid ApplyToId
            {
            get;
            set;
            }

        public string Name
            {
            get;
            set;
            }


        #endregion

        #region Private Static Methods
        private static ModifierModel Create(DbDataReader reader)
            {
            ModifierModel model;
            model = new ModifierModel();
            model.Load(reader);

            return model;
            }

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

            if (reader.TryGetOrdinal(ModifierModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(ModifierModel.NameField, out ordinal))
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

            if (!reader.TryGetOrdinal(ModifierModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(ModifierModel.TableNamesIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.TableNamesId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(ModifierModel.ApplyToIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.ApplyToId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(ModifierModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.Name = reader.GetString(ordinal);
                }

            if (reader.TryGetOrdinal(ModifierModel.LastUpdatedDateField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);
                }

            if (reader.TryGetOrdinal(ModifierModel.LastUpdatedVersionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedVersion = reader.GetString(ordinal);
                }
            }
        #endregion

        #region Public Methods
        /// <summary>
        /// Create the specified Modifier Model
        /// </summary>
        /// <param name="modifierId">ModifierId of the Modifier</param>
        public void Initialize(Guid modifierId)
            {
            QueryInformation query;

            if (modifierId == Guid.Empty)
                {
                return;
                }

            query = QueryInformation.Create(ModifierModel.LoadModifierByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.IdField, DbType.Guid, modifierId));

            this.Initialize(query);
            }

        /// <summary>
        /// Creates the specified Modifier Model
        /// </summary>
        /// <param name="feattypeName">Name of the modifier.</param>
        public void Initialize(string modifierName)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(modifierName))
                {
                return;
                }
            query = QueryInformation.Create(ModifierModel.LoadModifierByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.NameField, DbType.String, modifierName));

            this.Initialize(query);
            }

        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can not delete this record, there is no database entry for it. ModifierModel : Delete()");
                return;
                }

            query = QueryInformation.Create(ModifierModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);

            //lets reset the Id to empty so the model knows it is a new record now if the "Save()" is called afterwards for some reason.
            this.Id = Guid.Empty;
            }

        /// <summary>
        /// Saves the currently loaded Modifier
        /// </summary>
        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(ModifierModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                {
                query = QueryInformation.Create(ModifierModel.UpdateQuery);
                }

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.TableNamesIdField, DbType.Guid, this.TableNamesId));
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.ApplyToIdField, DbType.Guid, this.ApplyToId));
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.NameField, DbType.String, this.Name));
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));

            BaseModel.RunCommand(query);

            }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Gets all the Modifier Ids
        /// </summary>
        /// <returns>A list of all the Modifier ids</returns>
        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(ModifierModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, ModifierModel.ReadId);
            }

        public static Guid GetIdFromTableNamesIdandApplyToId(Guid tableNamesId, Guid applyToId)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(ModifierModel.GetIdFromTableIdandApplyToIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.TableNamesIdField, DbType.Guid, tableNamesId));
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.ApplyToIdField, DbType.Guid, applyToId));
            ids = BaseModel.GetIds(query, ModifierModel.ReadId);
            if (ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; //there should only be one value
            }

        /// <summary>
        /// Gets all the modifier names
        /// </summary>
        /// <returns>A list of all the Race names.</return>
        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(ModifierModel.GetNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, ModifierModel.ReadName);
            }

        /// <summary>
        /// Get the Ablity id of the specified Modifier
        /// </summary>
        /// <param name="name">Name of the Modifier</param>
        /// <returns>An Id of the Modifier</returns>
        public static Guid GetIdFromName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(ModifierModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, ModifierModel.ReadId);
            if (ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
            }

        /// <summary>
        /// Get the Modifier Name of the specified Modifier
        /// </summary>
        /// <param name="modifierId">Id of the Modifier</param>
        /// <returns>the Name of the Modifier</returns>
        public static string GetNameFromId(Guid modifierId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(ModifierModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.IdField, DbType.Guid, modifierId));

            names = BaseModel.GetNames(query, ModifierModel.ReadName);
            if (names == null || names.Count == 0)
                return "";
            else
                return names[0];
            }

        public static List<ModifierModel> GetAllByApplyToId(Guid applyToId, Guid tableNamesId)
            {
            QueryInformation query;

            if (applyToId == Guid.Empty || tableNamesId == Guid.Empty)
                return new List<ModifierModel>();

            query = QueryInformation.Create(ModifierModel.LoadModifierByApplyToIdandTableNamesIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.ApplyToIdField, DbType.Guid, applyToId));
            query.Parameters.Add(new QueryParameter("@" + ModifierModel.TableNamesIdField, DbType.Guid, tableNamesId));
            return BaseModel.GetAll<ModifierModel>(query, ModifierModel.Create);
            }

        /// <summary>
        /// Delete all records in the Modifier Table with the provided FeatId
        /// </summary>
        /// <param name="featId">Guid of the Feat</param>
        public static void DeleteAllByFeatId(Guid featId)
            {
            List<ModifierModel> models;

            Guid tableNamesId;

            if (featId == Guid.Empty)
                return;

            tableNamesId = TableNamesModel.GetIdFromTableName("Feat");

            models = GetAllByApplyToId(featId, tableNamesId);
            foreach (ModifierModel model in models)
                model.Delete();
            }

        #endregion
        }
    }

