using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.Utility;
using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
    {
    public sealed class RaceLevelDetailModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "RaceLevelDetailId";
        private const string RaceIdField = "RaceId";
        private const string LevelField = "Level";
        private const string FeatTypeIdField = "FeatTypeId";
        private const string BonusSkillPointsField = "BonusSkillPoints";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";

        private const string LoadDetailsByRaceIdQuery = "SELECT * FROM RaceLevelDetail WHERE RaceID=@RaceId ORDER BY Level";

        private const string DeleteQuery = "DELETE FROM RaceLevelDetail WHERE RaceLevelDetailId=@RaceLevelDetailId";
        private const string DeleteByRaceIdQuery = "DELETE FROM RaceLevelDetail WHERE RaceId=@RaceId";
        private const string InsertQuery = "INSERT INTO RaceLevelDetail (RaceLevelDetailId, RaceId, Level, FeatTypeId, BonusSkillPoints, LastUpdatedDate, LastUpdatedVersion) VALUES (@RaceLevelDetailId, @RaceId, @Level, @FeatTypeId, @BonusSkillPoints, @LastUpdatedDate, @LastUpdatedVersion)";
        private const string UpdateQuery = "UPDATE RaceLevelDetail SET RaceId=@RaceId, Level=@Level, FeatTypeId=@FeatTypeId, BonusSkillPoints=@BonusSkillPoints, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE RaceLevelDetailId=@RaceLevelDetailId";

        #endregion

        #region Properties
        public Guid RaceId
            {
            get;
            set;
            }

        public int Level
            {
            get;
            set;
            }

        public Guid FeatTypeId
            {
            get;
            set;
            }

        public int BonusSkillPoints
            {
            get;
            set;
            }

        #endregion

        #region Private Static Methods
        private static RaceLevelDetailModel Create(DbDataReader reader)
            {
            RaceLevelDetailModel model;

            model = new RaceLevelDetailModel();
            model.Load(reader);

            return model;
            }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Loads the specified reader
        /// </summary>
        /// <param name="reader">The reader.</param>
        protected override void Load(DbDataReader reader)
            {
            int ordinal;

            if (reader == null)
                {
                return;
                }

            if (!reader.TryGetOrdinal(RaceLevelDetailModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(RaceLevelDetailModel.RaceIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.RaceId = reader.GetGuid(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceLevelDetailModel.LevelField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.Level = reader.GetInt32(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceLevelDetailModel.FeatTypeIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.FeatTypeId = reader.GetGuid(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceLevelDetailModel.BonusSkillPointsField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.BonusSkillPoints = reader.GetInt32(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(RaceLevelDetailModel.LastUpdatedDateField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.LastUpdatedDate = reader.GetDateTime(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceLevelDetailModel.LastUpdatedVersionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.LastUpdatedVersion = reader.GetString(ordinal);
                    }
                }
            }
        #endregion

        #region Public Methods
        public void Save()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(RaceLevelDetailModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                query = QueryInformation.Create(RaceLevelDetailModel.UpdateQuery);

            //update the last modified fields
            LastUpdatedDate = DateTime.Now;
            LastUpdatedVersion = Constant.PlannerVersion;

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceLevelDetailModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + RaceLevelDetailModel.RaceIdField, DbType.Guid, this.RaceId));
            query.Parameters.Add(new QueryParameter("@" + RaceLevelDetailModel.LevelField, DbType.Int32, this.Level));
            if (FeatTypeId == Guid.Empty)
                query.Parameters.Add(new QueryParameter("@" + RaceLevelDetailModel.FeatTypeIdField, DbType.Guid, null));
            else
                query.Parameters.Add(new QueryParameter("@" + RaceLevelDetailModel.FeatTypeIdField, DbType.Guid, this.FeatTypeId));
            query.Parameters.Add(new QueryParameter("@" + RaceLevelDetailModel.BonusSkillPointsField, DbType.Int32, this.BonusSkillPoints));
            query.Parameters.Add(new QueryParameter("@" + RaceLevelDetailModel.LastUpdatedDateField, DbType.DateTime, this.LastUpdatedDate));
            query.Parameters.Add(new QueryParameter("@" + RaceLevelDetailModel.LastUpdatedVersionField, DbType.String, this.LastUpdatedVersion));
            BaseModel.RunCommand(query);
            }

        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can not delete this record since one does not exist to delete. RaceLevelDetailModel: Delete()");
                return;
                }

            query = QueryInformation.Create(RaceLevelDetailModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceLevelDetailModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);
            //Lets reset the ID to empty so the model will know this is a new record not if the save() member is called.
            this.Id = Guid.Empty;
            }

        #endregion

        #region Public Static Methods
        public static List<RaceLevelDetailModel> GetAll(Guid raceId)
            {
            QueryInformation query;

            if (raceId == Guid.Empty)
                return null;

            query = QueryInformation.Create(RaceLevelDetailModel.LoadDetailsByRaceIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceLevelDetailModel.RaceIdField, DbType.Guid, raceId));

            return BaseModel.GetAll<RaceLevelDetailModel>(query, RaceLevelDetailModel.Create);
            }

        public static void DeleteAllByRaceId(Guid raceId)
            {
            QueryInformation query;

            if (raceId == Guid.Empty)
                return;

            query = QueryInformation.Create(RaceLevelDetailModel.DeleteByRaceIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceLevelDetailModel.RaceIdField, DbType.Guid, raceId));
            BaseModel.RunCommand(query);
            }
        #endregion
        }
    }
