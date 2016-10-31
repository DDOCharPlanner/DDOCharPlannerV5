using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
    {
    public sealed class FeatCategoryModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "FeatCategoryId";
        private const string NameField = "Name";
        private const string DescriptionField = "Description";
        private const string ParentFeatCategoryIdField = "ParentFeatCategoryId";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";
        private const string IconNameField = "IconName";

        private const string CountQuery = "SELECT COUNT(*) AS Count FROM FeatCategory";

        private const string LoadFeatCategoryByIdQuery = "SELECT * FROM FeatCategory WHERE FeatCategoryId=@FeatCategoryId";
        private const string LoadFeatCategoryByNameQuery = "SELECT * FROM FeatCategory WHERE Name=@Name";
        private const string LoadNamesQuery = "SELECT FeatCategoryId, Name FROM FeatCategory ORDER BY Name";

        private const string GetIdsQuery = "SELECT FeatCategoryId FROM FeatCategory";
        private const string GetNameFromIdQuery = "SELECT Name FROM FeatCategory WHERE FeatCategoryId=@FeatCategoryId";
        private const string GetIdFromNameQuery = "SELECT FeatCategoryId FROM FeatCategory WHERE Name=@Name";

        private const string DeleteQuery = "DELETE FROM FeatCategory WHERE FeatCategoryId=@FeatCategoryId";
        private const string InsertQuery = "INSERT INTO FeatCategory (FeatCategoryId, Name, Description, ParentFeatCategoryId, LastUpdatedDate, LastUpdatedVersion, IconName) VALUES (@FeatCategoryId, @Name, @Description, @ParentFeatCategoryId, @LastUpdatedDate, @LastUpdatedVersion, @IconName)";
        private const string UpdateQuery = "UPDATE FeatCategory SET Name=@Name, Description=@Description, ParentFeatCategoryId=@ParentFeatCategoryId, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion, IconName=@IconName WHERE FeatCategoryId=@FeatCategoryId";

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

        public Guid ParentFeatCategoryId
            {
            get;
            set;
            }

        public string IconName
            {
            get;
            set;
            }

        #endregion

        #region Private Static Methods
        private static string ReadNames(DbDataReader reader)
            {
            int ordinal;
            Guid id;
            string name = null;

            if (reader == null)
                {
                return null;
                }

            if (!reader.TryGetOrdinal(IdField, out ordinal))
                {
                // No ID Field, cna't use
                return null;
                }

            if (reader.IsDBNull(ordinal))
                {
                //Null, cant' use
                return null;
                }

            id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    name = reader.GetString(ordinal);
                    }
                }
            return name;
            }

        private static string ReadJustNames(DbDataReader reader)
            {
            int ordinal;
            string name = null;

            if (reader == null)
                return null;

            if (reader.TryGetOrdinal(FeatCategoryModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    name = reader.GetString(ordinal);
                    }
                }
            return name;
            }

        private static Guid ReadIds(DbDataReader reader)
            {
            int ordinal;
            Guid id = Guid.Empty;

            if (reader == null)
                return Guid.Empty;

            if (reader.TryGetOrdinal(FeatCategoryModel.IdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    id = reader.GetGuid(ordinal);
                    }
                }
            return id;
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

            if (!reader.TryGetOrdinal(FeatCategoryModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(FeatCategoryModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.Name = reader.GetString(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(FeatCategoryModel.DescriptionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.Description = reader.GetString(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(FeatCategoryModel.ParentFeatCategoryIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.ParentFeatCategoryId = reader.GetGuid(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(FeatCategoryModel.IconNameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.IconName = reader.GetString(ordinal);
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
                Debug.WriteLine("Error: You can delete this record as an actual Database record doesn't exist for it. FeatCategoryModel : Delete()");
                return;
                }

            query = QueryInformation.Create(FeatCategoryModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatCategoryModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);
            //lets reset the ID to empty so the model knows its a new record in case someone calls the save() method afterwards for some reason
            this.Id = Guid.Empty;
            }

        public void Initialize(Guid featCategoryId)
            {
            QueryInformation query;

            if (featCategoryId == Guid.Empty)
                return;

            query = QueryInformation.Create(FeatCategoryModel.LoadFeatCategoryByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatCategoryModel.IdField, DbType.Guid, featCategoryId));

            this.Initialize(query);
            }

        public void Initialize(string name)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(name))
                return;

            query = QueryInformation.Create(FeatCategoryModel.LoadFeatCategoryByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatCategoryModel.NameField, DbType.String, name));

            this.Initialize(query);
            }

        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(FeatCategoryModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                query = QueryInformation.Create(FeatCategoryModel.UpdateQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatCategoryModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + FeatCategoryModel.NameField, DbType.String, this.Name));
            query.Parameters.Add(new QueryParameter("@" + FeatCategoryModel.DescriptionField, DbType.String, this.Description));
            query.Parameters.Add(new QueryParameter("@" + FeatCategoryModel.ParentFeatCategoryIdField, DbType.Guid, this.ParentFeatCategoryId));
            query.Parameters.Add(new QueryParameter("@" + FeatCategoryModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + FeatCategoryModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));
            query.Parameters.Add(new QueryParameter("@" + FeatCategoryModel.IconNameField, DbType.String, this.IconName));

            BaseModel.RunCommand(query);
            }

        #endregion

        #region Public Static Methods
        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(FeatCategoryModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, FeatCategoryModel.ReadIds);
            }

        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(LoadNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, ReadNames);
            }

        public static string GetNameFromId(Guid featCategoryId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(FeatCategoryModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatCategoryModel.IdField, DbType.Guid, featCategoryId));

            names = BaseModel.GetNames(query, FeatCategoryModel.ReadJustNames);
            if (names.Count == 0)
                return "";
            else
                return names[0]; // there should only be one value!
            }

        public static Guid GetIdFromName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(FeatCategoryModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatCategoryModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, FeatCategoryModel.ReadIds);
            if (ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; //there should only be one value
            }
        #endregion
        }
    }
