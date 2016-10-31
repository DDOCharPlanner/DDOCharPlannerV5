using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
    {
    public sealed class RequirementModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "RequirementId";
        private const string TableNamesIdField = "TableNamesId";
        private const string ApplyToIdField = "ApplytoId";
        private const string NameField = "Name";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";
        //Count Queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM Requirement";
        //Get Value Queries
        private const string GetNamesQuery = "SELECT Name FROM Requirement ORDER BY Name";
        private const string GetNameFromIdQuery = "SELECT Name FROM Requirement WHERE RequirementId=@RequirementId";
        private const string GetIdFromNameQuery = "SELECT RequirementId FROM Requirement WHERE Name=@Name";
        private const string GetIdFromTableIdandApplyToIdQuery = "SELECT RequirementId FROM Requirement WHERE TableNamesId=@TableNamesId AND ApplyToId=@ApplyToId";
        
        //Load Queries
        private const string LoadRequirementByIdQuery = "SELECT * FROM Requirement WHERE RequirementId=@RequirementId";
        private const string LoadRequirementByNameQuery = "SELECT * FROM Requirement WHERE Name=@Name";
        private const string LoadRequirementByApplytoIdandTablesNamesIdQuery = "SELECT * FROM Requirement WHERE ApplytoId=@ApplytoId AND TableNamesId=@TableNamesId";
        //Change Queries
        private const string DeleteQuery = "DELETE FROM Requirement WHERE RequirementId=@RequirementId";
        private const string InsertQuery = "INSERT INTO Requirement (RequirementId, TableNamesId, LastUpdatedDate, LastUpdatedVersion, ApplytoId, Name) VALUES (@RequirementId, @TableNamesId, @LastUpdatedDate, @LastUpdatedVersion, @ApplytoId, @Name)";
        private const string UpdateQuery = "UPDATE Requirement SET TableNamesId=@TableNamesId, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion, ApplytoId=@ApplytoId, Name=@Name WHERE RequirementId=@RequirementId";
        #endregion

        #region Properties
        public Guid TableNamesId
            {
            get;
            set;
            }

        public Guid ApplytoId
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
        private static RequirementModel Create(DbDataReader reader)
            {
            RequirementModel model;
            model = new RequirementModel();
            model.Load(reader);

            return model;
            }

        private static Guid ReadId(DbDataReader reader)
            {
            int ordinal;
            Guid id = Guid.Empty;

            if (reader == null)
                return id;

            if (reader.TryGetOrdinal(RequirementModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(RequirementModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    name = reader.GetString(ordinal);
                }
            return name;
            }

        #endregion

        #region Protected Methods
        ///<summary>
        ///Load the specified reader
        ///</summary>
        ///<param name="reader">The reader.<param>
        protected override void Load(DbDataReader reader)
            {
            int ordinal;

            if (reader == null)
                {
                return;
                }

            if (!reader.TryGetOrdinal(RequirementModel.IdField, out ordinal))
                {
                //No Id Field, can't use
                return;
                }

            if (reader.IsDBNull(ordinal))
                {
                //Null, can't use
                return;
                }

            this.Id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(RequirementModel.TableNamesIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.TableNamesId = reader.GetGuid(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RequirementModel.ApplyToIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.ApplytoId = reader.GetGuid(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RequirementModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.Name = reader.GetString(ordinal);
                    }
                }
            }
        #endregion

        #region Public Methods
        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can't delete this record as an actual Database record doesn't exist for it. RequirementModel : Delete()");
                return;
                }

            query = QueryInformation.Create(RequirementModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);
            //lets reset the ID to empty so the model knows its a new record in case someone calls the save() method afterwards for some reason
            this.Id = Guid.Empty;
            }

        public void Initialize(Guid requirementId)
            {
            QueryInformation query;

            if (requirementId == Guid.Empty)
                return;

            query = QueryInformation.Create(RequirementModel.LoadRequirementByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.IdField, DbType.Guid, requirementId));

            this.Initialize(query);
            }

        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(RequirementModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                query = QueryInformation.Create(RequirementModel.UpdateQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.TableNamesIdField, DbType.Guid, this.TableNamesId));
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.ApplyToIdField, DbType.Guid, this.ApplytoId));
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.NameField, DbType.String, this.Name));
            BaseModel.RunCommand(query);
            }
        #endregion

        #region Public Static Methods
        public static void DeleteAllbyFeatId(Guid featId)
            {
            List<RequirementModel> models;
            Guid tableNamesId;

            if (featId == Guid.Empty)
                return;

            tableNamesId = TableNamesModel.GetIdFromTableName("Feat");

            models = GetAllByApplyToId(featId, tableNamesId);
            foreach (RequirementModel model in models)
                model.Delete();
            }

        public static List<RequirementModel> GetAllByApplyToId(Guid applyToId, Guid tableNamesId)
            {
            QueryInformation query;

            if (applyToId == Guid.Empty || tableNamesId == Guid.Empty)
                return new List<RequirementModel>();

            query = QueryInformation.Create(RequirementModel.LoadRequirementByApplytoIdandTablesNamesIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.ApplyToIdField, DbType.Guid, applyToId));
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.TableNamesIdField, DbType.Guid, tableNamesId));
            return BaseModel.GetAll<RequirementModel>(query, RequirementModel.Create);
            }

        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(RequirementModel.GetNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, RequirementModel.ReadName);
            }

        public static string GetNameFromId(Guid requirementTypeId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(RequirementModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.IdField, DbType.Guid, requirementTypeId));

            names = BaseModel.GetNames(query, RequirementModel.ReadName);
            if (names.Count == 0)
                return "";
            else
                return names[0];
            }

        public static Guid GetIdFromName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(RequirementModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, RequirementModel.ReadId);
            if (ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; //there should only be one value
            }

        public static Guid GetIdFromTableNamesIdandApplyToId(Guid tableNamesId, Guid applyToId)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(RequirementModel.GetIdFromTableIdandApplyToIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.TableNamesIdField, DbType.Guid, tableNamesId));
            query.Parameters.Add(new QueryParameter("@" + RequirementModel.ApplyToIdField, DbType.Guid, applyToId));
            ids = BaseModel.GetIds(query, RequirementModel.ReadId);
            if (ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; //there should only be one value
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
