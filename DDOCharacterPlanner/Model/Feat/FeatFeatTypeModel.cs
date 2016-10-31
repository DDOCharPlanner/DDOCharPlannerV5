using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
    {
    public sealed class FeatFeatTypeModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "FeatFeatTypeId";
        private const string FeatIdField = "FeatId";
        private const string FeatTypeIdField = "FeatTypeId";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        private const string LoadFeatFeatTypeByIdQuery = "SELECT * FROM FeatFeatType WHERE FeatFeatTypeId=@FeatFeatTypeId";
        private const string LoadAllByFeatIdQuery = "SELECT * FROM FeatFeatType WHERE FeatId=@FeatId";

        private const string GetIdsQuery = "SELECT FeatFeatTypeId FROM FeatFeatType";
        private const string GetIdsByFeatIdQuery = "SELECT FeatFeatTypeId FROM FeatFeatType WHERE FeatId=@FeatId";

        private const string DeleteQuery = "DELETE FROM FeatFeatType WHERE FeatFeatTypeId=@FeatFeatTypeId";
        private const string DeleteByFeatIdQuery = "DELETE FROM FeatFeatType WHERE FeatId=@FeatId";
        private const string InsertQuery = "INSERT INTO FeatFeatType (FeatFeatTypeID, FeatId, FeatTypeId, LastUpdatedDate, LastUpdatedVersion) VALUES (@FeatFeatTypeId, @FeatId, @FeatTypeId, @LastUpdatedDate, @LastUpdatedVersion)";
        private const string UpdateQuery = "UPDATE FeatFeatType SET FeatId=@FeatId, FeatTypeId=@FeatTypeID, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE FeatFeatTypeId=@FeatFeatTypeId";
        #endregion

        #region Properties
        public Guid FeatId
            {
            get;
            set;
            }

        public Guid FeatTypeId
            {
            get;
            set;
            }

        #endregion

        #region Private Static Methods
        private static FeatFeatTypeModel Create(DbDataReader reader)
            {
            FeatFeatTypeModel model;

            model = new FeatFeatTypeModel();
            model.Load(reader);

            return model;
            }

        /// <summary>
        /// Reads the id
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <returns>the read id</returns>
        private static Guid ReadId(DbDataReader reader)
            {
            int ordinal;
            Guid id = Guid.Empty;

            if (reader == null)
                return Guid.Empty;

            if (reader.TryGetOrdinal(FeatFeatTypeModel.IdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    id = reader.GetGuid(ordinal);
                }
            return id;
            }

        #endregion

        #region Protected Methods
        protected override void Load(DbDataReader reader)
            {
            int ordinal;

            if (reader == null)
                return;

            if (!reader.TryGetOrdinal(FeatFeatTypeModel.IdField, out ordinal))
                return; //No ID field, cant' use

            if (reader.IsDBNull(ordinal))
                return; //Null, can't use

            this.Id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(FeatFeatTypeModel.FeatIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.FeatId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(FeatFeatTypeModel.FeatTypeIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.FeatTypeId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(FeatFeatTypeModel.LastUpdatedDateField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);
                }

            if (reader.TryGetOrdinal(FeatFeatTypeModel.LastUpdatedVersionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedVersion = reader.GetString(ordinal);
                }
            }
        #endregion

        #region Public Methods
        public void Initialize(Guid featFeatTypeId)
            {
            QueryInformation query;

            if (featFeatTypeId == Guid.Empty)
                return;

            query = QueryInformation.Create(FeatFeatTypeModel.LoadFeatFeatTypeByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatFeatTypeModel.IdField, DbType.Guid, featFeatTypeId));

            this.Initialize(query);
            }

        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can delete a record that doesn't exist. FeatFeatTypeModel: Delete()");
                return;
                }

            query = QueryInformation.Create(FeatFeatTypeModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatFeatTypeModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);

            //lets reset the Id field to empty so the model knows its a new record now if the save() is called for some reason.
            this.Id = Guid.Empty;
            }

        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(FeatFeatTypeModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                {
                query = QueryInformation.Create(FeatFeatTypeModel.UpdateQuery);
                }

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatFeatTypeModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + FeatFeatTypeModel.FeatIdField, DbType.Guid, this.FeatId));
            query.Parameters.Add(new QueryParameter("@" + FeatFeatTypeModel.FeatTypeIdField, DbType.Guid, this.FeatTypeId));
            query.Parameters.Add(new QueryParameter("@" + FeatFeatTypeModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + FeatFeatTypeModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));
            BaseModel.RunCommand(query);
            }

        #endregion

        #region Public Static Methods
        public static void DeleteAllByFeatId(Guid featId)
            {
            QueryInformation query;

            if (featId == Guid.Empty)
                return;

            query = QueryInformation.Create(FeatFeatTypeModel.DeleteByFeatIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatFeatTypeModel.FeatIdField, DbType.Guid, featId));
            BaseModel.RunCommand(query);
            }

        public static List<FeatFeatTypeModel>GetAllByFeatId(Guid featId)
            {
            QueryInformation query;

            if (featId == Guid.Empty)
                return null;

            query = QueryInformation.Create(FeatFeatTypeModel.LoadAllByFeatIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatFeatTypeModel.FeatIdField, DbType.Guid, featId));

            return BaseModel.GetAll<FeatFeatTypeModel>(query, FeatFeatTypeModel.Create);
            }

        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(FeatFeatTypeModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, FeatFeatTypeModel.ReadId);
            }

        public static List<Guid> GetIdsByFeatId(Guid featId)
            {
            QueryInformation query;

            query = QueryInformation.Create(FeatFeatTypeModel.GetIdsQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatFeatTypeModel.FeatIdField, DbType.Guid, featId));

            return BaseModel.GetIds(query, FeatFeatTypeModel.ReadId);
            }

        #endregion
        }
    }
