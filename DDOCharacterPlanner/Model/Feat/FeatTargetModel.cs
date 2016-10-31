using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
    {
    public sealed class FeatTargetModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "FeatTargetId";
        private const string FeatIdField = "FeatId";
        private const string TargetIdField = "TargetId";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        private const string LoadFeatTargetByIdQuery = "SELECT * FROM FeatTarget WHERE FeatTargetId=@FeatTargetId";
        private const string LoadAllByFeatIdQuery = "SELECT * FROM FeatTarget WHERE FeatId=@FeatId";

        private const string GetIdsQuery = "SELECT FeatTargetId FROM FeatTarget";
        private const string GetIdsByFeatIdQuery = "SELECT FeatTargetId FROM FeatTarget WHERE FeatId=@FeatId";

        private const string DeleteQuery = "DELETE FROM FeatTarget WHERE FeatTargetId=@FeatTargetId";
        private const string DeleteByFeatIdQuery = "DELETE FROM FeatTarget WHERE FeatId=@FeatId";
        private const string InsertQuery = "INSERT INTO FeatTarget (FeatTargetID, FeatId, TargetId, LastUpdatedDate, LastUpdatedVersion) VALUES (@FeatTargetId, @FeatId, @TargetId, @LastUpdatedDate, @LastUpdatedVersion)";
        private const string UpdateQuery = "UPDATE FeatTarget SET FeatId=@FeatId, TargetId=@TargetId, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE FeatTargetId=@FeatTargetId";
        #endregion

        #region Properties
        public Guid FeatId
            {
            get;
            set;
            }

        public Guid TargetId
            {
            get;
            set;
            }

        #endregion

        #region Private Static Methods
        private static FeatTargetModel Create(DbDataReader reader)
            {
            FeatTargetModel model;

            model = new FeatTargetModel();
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

            if (reader.TryGetOrdinal(FeatTargetModel.IdField, out ordinal))
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

            if (!reader.TryGetOrdinal(FeatTargetModel.IdField, out ordinal))
                return; //No ID field, cant' use

            if (reader.IsDBNull(ordinal))
                return; //Null, can't use

            this.Id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(FeatTargetModel.FeatIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.FeatId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(FeatTargetModel.TargetIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.TargetId = reader.GetGuid(ordinal);
                }

            if (reader.TryGetOrdinal(FeatTargetModel.LastUpdatedDateField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);
                }

            if (reader.TryGetOrdinal(FeatTargetModel.LastUpdatedVersionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    this.LastUpdatedVersion = reader.GetString(ordinal);
                }
            }
        #endregion

        #region Public Methods
        public void Initialize(Guid featTargetId)
            {
            QueryInformation query;

            if (featTargetId == Guid.Empty)
                return;

            query = QueryInformation.Create(FeatTargetModel.LoadFeatTargetByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatTargetModel.IdField, DbType.Guid, featTargetId));

            this.Initialize(query);
            }

        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can delete a record that doesn't exist. FeatTargetModel: Delete()");
                return;
                }

            query = QueryInformation.Create(FeatTargetModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatTargetModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);

            //lets reset the Id field to empty so the model knows its a new record now if the save() is called for some reason.
            this.Id = Guid.Empty;
            }

        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(FeatTargetModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                {
                query = QueryInformation.Create(FeatTargetModel.UpdateQuery);
                }

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatTargetModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + FeatTargetModel.FeatIdField, DbType.Guid, this.FeatId));
            query.Parameters.Add(new QueryParameter("@" + FeatTargetModel.TargetIdField, DbType.Guid, this.TargetId));
            query.Parameters.Add(new QueryParameter("@" + FeatTargetModel.LastUpdatedDateField, DbType.DateTime, DateTime.Now));
            query.Parameters.Add(new QueryParameter("@" + FeatTargetModel.LastUpdatedVersionField, DbType.String, Constant.PlannerVersion));
            BaseModel.RunCommand(query);
            }

        #endregion

        #region Public Static Methods
        public static void DeleteAllByFeatId(Guid featId)
            {
            QueryInformation query;

            if (featId == Guid.Empty)
                return;

            query = QueryInformation.Create(FeatTargetModel.DeleteByFeatIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatTargetModel.FeatIdField, DbType.Guid, featId));
            BaseModel.RunCommand(query);
            }

        public static List<FeatTargetModel>GetAllByFeatId(Guid featId)
            {
            QueryInformation query;

            if (featId == Guid.Empty)
                return new List<FeatTargetModel>();

            query = QueryInformation.Create(FeatTargetModel.LoadAllByFeatIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatTargetModel.FeatIdField, DbType.Guid, featId));

            return BaseModel.GetAll<FeatTargetModel>(query, FeatTargetModel.Create);
            }

        public static List<Guid> GetIds()
            {
            QueryInformation query;

            query = QueryInformation.Create(FeatTargetModel.GetIdsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetIds(query, FeatTargetModel.ReadId);
            }

        public static List<Guid> GetIdsByFeatId(Guid featId)
            {
            QueryInformation query;

            query = QueryInformation.Create(FeatTargetModel.GetIdsQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + FeatTargetModel.FeatIdField, DbType.Guid, featId));

            return BaseModel.GetIds(query, FeatTargetModel.ReadId);
            }

        #endregion
        }
    }
