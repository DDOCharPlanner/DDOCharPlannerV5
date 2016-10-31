using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
    {
    ///<summary>
    ///Defines data availability for the Enhnacement Records
    ///</summary>
    public sealed class EnhancementTreeModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "EnhancementTreeId";
        private const string NameField = "Name";
        private const string BackgroundField = "Background";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";
        private const string RaceTreeField = "RaceTree";
        //Count Queries
        private const string CountQuery = "SELECT COUNT(*) AS Count FROM EnhancementTree";
        private const string CountByNameQuery = "SELECT COUNT(*) AS Count FROM EnhancementTree WHERE Name=@Name";
        //Load Queries
        private const string LoadEnhancementTreeByIdQuery = "SELECT * FROM EnhancementTree WHERE EnhancementTreeId=@EnhancementTreeId";
        private const string LoadEnhancementTreeByNameQuery = "SELECT * FROM EnhancementTree WHERE Name=@Name";
        //Get Value Queries
        private const string GetNamesQuery = "SELECT Name FROM EnhancementTree ORDER BY Name";
        private const string GetIdFromNameQuery = "SELECT EnhancementTreeId FROM EnhancementTree WHERE Name=@Name";
        private const string GetNameFromIdQuery = "SELECT Name FROM EnhancementTree WHERE EnhancementTreeId=@EnhancementTreeId";
        //Change Queries
        private const string DeleteQuery = "DELETE FROM EnhancementTree WHERE EnhancementTreeId=@EnhancementTreeId";
        private const string InsertQuery = "INSERT INTO EnhancementTree (EnhancementTreeId, Name, Background, LastUpdatedDate, LastUpdatedVersion, RaceTree) VALUES (@EnhancementTreeId, @Name, @Background, @LastUpdatedDate, @LastUpdatedVersion, @RaceTree)";
        private const string UpdateQuery = "UPDATE EnhancementTree SET  Name=@Name, Background=@Background, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion, RaceTree=@RaceTree WHERE EnhancementTreeId=@EnhancementTreeId";
        //Defaults
        private const string DefaultName = "Enter Name";
        private const string DefaultBackground = "BackgroundEmpty";
        private const bool DefaultRaceTree = true;

        #endregion

        #region Properties
        public string Name
            {
            get;
            set;
            }

        public string Background
            {
            get;
            set;
            }

        public bool RaceTree
            {
            get;
            set;
            }

        #endregion

        #region Constructor
        public EnhancementTreeModel()
            {
            this.Name = DefaultName;
            this.Background = DefaultBackground;
            this.RaceTree = DefaultRaceTree;
            this.LastUpdatedVersion = Constant.PlannerVersion;
            }
        #endregion
        #region Private Static Members
        private static EnhancementTreeModel Create(DbDataReader reader)
            {
            EnhancementTreeModel model;

            model = new EnhancementTreeModel();
            model.Load(reader);

            return model;
            }

        private static Guid ReadId(DbDataReader reader)
            {
            int ordinal;
            Guid id = Guid.Empty;

            if (reader == null)
                return id;

            if (reader.TryGetOrdinal(EnhancementTreeModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(EnhancementTreeModel.NameField, out ordinal))
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

            if (!reader.TryGetOrdinal(IdField, out ordinal))
                return; // No Id field, can't use

            if (reader.IsDBNull(ordinal))
                return; //Null, can't use

            this.Id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(NameField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    Name = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(BackgroundField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    Background = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(LastUpdatedDateField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    LastUpdatedDate = reader.GetDateTime(ordinal);

            if (reader.TryGetOrdinal(LastUpdatedVersionField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    LastUpdatedVersion = reader.GetString(ordinal);

            if (reader.TryGetOrdinal(RaceTreeField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    RaceTree = reader.GetBoolean(ordinal);
            }

        #endregion

        #region Public Members
        public void ConvertToNewRecord()
            {
            this.Id = Guid.Empty;
            }

        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can delete this record as an actual Database record doesn't exist for it. EnhancementTreeModel : Delete()");
                return;
                }

            //We need to delete any associated records before deleting this one
            EnhancementSlotModel.DeleteAllByEnhancementTreeId(this.Id);

            //we need to remove any Enhancement entries in other tables for this feat

            query = QueryInformation.Create(EnhancementTreeModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);

            //lets rest the id to empty so that the model knows it is now a new record if the save method is called.
            this.Id = Guid.Empty;
            }

        public void Initialize(Guid enhancementTreeId)
            {
            QueryInformation query;

            if (enhancementTreeId == Guid.Empty)
                return;

            query = QueryInformation.Create(LoadEnhancementTreeByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + IdField, DbType.Guid, enhancementTreeId));

            Initialize(query);
            }

        public void Initialize(string treeName)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(treeName))
                {
                return;
                }

            query = QueryInformation.Create(LoadEnhancementTreeByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + NameField, DbType.String, treeName));

            Initialize(query);
            }

        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(EnhancementTreeModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                query = QueryInformation.Create(EnhancementTreeModel.UpdateQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeModel.NameField, DbType.String, this.Name));
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeModel.BackgroundField, DbType.String, this.Background));
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeModel.RaceTreeField, DbType.Boolean, this.RaceTree));

            BaseModel.RunCommand(query);
            }

        #endregion

        #region Public Static Members
        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(GetNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, ReadName);
            }

        public static int GetRecordCount()
            {
            QueryInformation query;

            query = QueryInformation.Create(CountQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetCount(query);
            }

        public static bool DoesNameExist(string name)
            {
            QueryInformation query;

            query = QueryInformation.Create(EnhancementTreeModel.CountByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeModel.NameField, DbType.String, name));

            return BaseModel.GetCount(query) > 0;
            }

        public static Guid GetIdFromTreeName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(EnhancementTreeModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeModel.NameField, DbType.String, name));
            ids = BaseModel.GetIds(query, EnhancementTreeModel.ReadId);
            if (ids == null)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
            }

        public static string GetNameFromId(Guid treeId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(EnhancementTreeModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + EnhancementTreeModel.IdField, DbType.Guid, treeId));

            names = BaseModel.GetNames(query, EnhancementTreeModel.ReadName);
            if (names.Count == 0)
                return "";
            else
                return names[0];
            }
        #endregion
        }
    }

