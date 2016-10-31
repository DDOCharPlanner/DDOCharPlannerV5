using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
    {
    /// <summary>
    ///  Defines data avialability for a Race's Auto-granted feats.
    /// </summary>
    public sealed class RaceBonusFeatModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "RaceBonusFeatId";
        private const string RaceIdField = "RaceId";
        private const string FeatIdField = "FeatId";
        private const string LevelField = "Level";
        private const string HasPreRequirementsField = "HasPrerequisites";

        private const string LoadDetailsByRaceQuery = "SELECT * FROM RaceBonusFeat WHERE RaceId=@RaceId ORDER BY Level";

        private const string DeleteQuery = "DELETE FROM RaceBonusFeat WHERE RaceBonusFeatId=@RaceBonusFeatId";
        private const string DeleteByFeatIdQuery = "DELETE FROM RaceBonusFeat WHERE FeatId=@FeatId";
        private const string DeleteByRaceIdQuery = "DELETE FROM RaceBonusFeat WHERE RaceId=@RaceId";
        private const string InsertQuery = "INSERT INTO RaceBonusFeat (RaceBonusFeatId, RaceId, FeatId, Level, HasPrerequisites) VALUES (@RaceBonusFeatId, @RaceId, @FeatId, @Level, @HasPrerequisites)";
        private const string UpdateQuery = "UPDATE RaceBonusFeat SET RaceId=@RaceId, FeatId=@FeatId, Level=@Level, HasPrerequisites=@HasPrerequisites WHERE RaceBonusFeatId=@RaceBonusFeatId";

        #endregion

        #region Properties
        public Guid RaceId
            {
            get;
            set;
            }

        public Guid FeatId
            {
            get;
            set;
            }

        public int Level
            {
            get;
            set;
            }

        public bool HasPreRequirements
            {
            get;
            set;
            }
        #endregion

        #region Private Static Methods
        private static RaceBonusFeatModel Create(DbDataReader reader)
            {
            RaceBonusFeatModel model;

            model = new RaceBonusFeatModel();
            model.Load(reader);

            return model;
            }

        #endregion

        #region Protected Methods
        /// <summary>
        /// Loads the specified reader
        /// </summary>
        /// <param name="reader">The reader.<param>
        protected override void Load(DbDataReader reader)
            {
            int ordinal;

            if (reader == null)
                {
                return;
                }

            if (!reader.TryGetOrdinal(RaceBonusFeatModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(RaceBonusFeatModel.RaceIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.RaceId = reader.GetGuid(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceBonusFeatModel.FeatIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.FeatId = reader.GetGuid(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(RaceBonusFeatModel.HasPreRequirementsField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.HasPreRequirements = reader.GetBoolean(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceBonusFeatModel.LevelField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.Level = reader.GetInt32(ordinal);
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
                query = QueryInformation.Create(RaceBonusFeatModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                {
                query = QueryInformation.Create(RaceBonusFeatModel.UpdateQuery);
                }

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceBonusFeatModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + RaceBonusFeatModel.RaceIdField, DbType.Guid, this.RaceId));
            query.Parameters.Add(new QueryParameter("@" + RaceBonusFeatModel.FeatIdField, DbType.Guid, this.FeatId));
            query.Parameters.Add(new QueryParameter("@" + RaceBonusFeatModel.HasPreRequirementsField, DbType.Boolean, this.HasPreRequirements));
            query.Parameters.Add(new QueryParameter("@" + RaceBonusFeatModel.LevelField, DbType.Int32, this.Level));

            BaseModel.RunCommand(query);
            }

        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can not delete this record as an actual Database entry does not exist. RaceBonusFeatsModel: Delete()");
                return;
                }

            query = QueryInformation.Create(RaceBonusFeatModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceBonusFeatModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);
            //lets reset the ID to empty so the model know it is a new record if the save routine is accessed afterwards for some reason.
            this.Id = Guid.Empty;
            }
        #endregion

        #region Public Static Methods
        public static void DeleteAllByFeatId(Guid featId)
            {
            QueryInformation query;

            if (featId == Guid.Empty)
                return;

            query = QueryInformation.Create(RaceBonusFeatModel.DeleteByFeatIdQuery);
            query.Parameters.Add(new QueryParameter("@" + RaceBonusFeatModel.FeatIdField, DbType.Guid, featId));
            BaseModel.RunCommand(query);
            }

        public static List<RaceBonusFeatModel> GetAll(Guid raceID)
            {
            QueryInformation query;

            if (raceID == Guid.Empty)
                {
                return new List<RaceBonusFeatModel>();
                }

            query = QueryInformation.Create(RaceBonusFeatModel.LoadDetailsByRaceQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@RaceId", DbType.Guid, raceID));

            return BaseModel.GetAll<RaceBonusFeatModel>(query, RaceBonusFeatModel.Create);
            }

        public static void DeleteAllByRaceId(Guid raceId)
            {
            QueryInformation query;

            if (raceId == Guid.Empty)
                return;

            query = QueryInformation.Create(RaceBonusFeatModel.DeleteByRaceIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceBonusFeatModel.RaceIdField, DbType.Guid, raceId));
            BaseModel.RunCommand(query);
            }
        #endregion
        }
    }
