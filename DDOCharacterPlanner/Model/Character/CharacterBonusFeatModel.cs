using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.DataAccess;
using DDOCharacterPlanner.Utility;

namespace DDOCharacterPlanner.Model
    {
    
    /// <summary>
    /// Defines data availability for a character's bonus feats.
    /// </summary>
    public sealed class CharacterBonusFeatModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "CharacterBonusFeatId";
        private const string FeatIdField = "FeatId";
        private const string LevelField = "Level";
        private const string IgnorePreReqsField = "IgnorePreRequirements";
		private const string LastUpdatedDateField = "LastUpdatedDate";
		private const string LastUpdatedVersionField = "LastUpdatedVersion";

        private const string LoadDetailsQuery = "SELECT * FROM CharacterBonusFeat ORDER BY Level";

        private const string DeleteQuery = "DELETE FROM CharacterBonusFeat WHERE CharacterBonusFeatId=@CharacterBonusFeatId";
        private const string DeleteByFeatIdQuery = "DELETE FROM CharacterBonusFeat WHERE FeatId=@FeatId";
		private const string InsertQuery = "INSERT INTO CharacterBonusFeat (CharacterBonusFeatId, FeatId, Level, IgnorePreRequirements, LastUpdatedDate, LastUpdatedVersion) VALUES (@CharacterBonusFeatId, @FeatId, @Level, @IgnorePreRequirements, @LastUpdatedDate, @LastUpdatedVersion)";
		private const string UpdateQuery = "UPDATE CharacterBonusFeat SET FeatId=@FeatId, IgnorePreRequirements=@IgnorePreRequirements, Level=@Level, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion WHERE CharacterBonusFeatId=@CharacterBonusFeatId";
        #endregion

        #region Properties
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
        public bool IgnorePreRequirements
            {
            get;
            set;
            }
        #endregion

        #region PrivateStatic Methods
        private static CharacterBonusFeatModel Create(DbDataReader reader)
            {
            CharacterBonusFeatModel model;

            model = new CharacterBonusFeatModel();
            model.Load(reader);

            return model;
            }
        #endregion

        #region Protectd Methods
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

            if (!reader.TryGetOrdinal(CharacterBonusFeatModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(CharacterBonusFeatModel.FeatIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.FeatId = reader.GetGuid(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(CharacterBonusFeatModel.IgnorePreReqsField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.IgnorePreRequirements = reader.GetBoolean(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(CharacterBonusFeatModel.LevelField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.Level = reader.GetByte(ordinal);
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
                query = QueryInformation.Create(CharacterBonusFeatModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                {
                query = QueryInformation.Create(CharacterBonusFeatModel.UpdateQuery);
                }

			//update the last modified fields
			LastUpdatedDate = DateTime.Now;
			LastUpdatedVersion = Constant.PlannerVersion;
			
			query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + CharacterBonusFeatModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + CharacterBonusFeatModel.FeatIdField, DbType.Guid, this.FeatId));
            query.Parameters.Add(new QueryParameter("@" + CharacterBonusFeatModel.IgnorePreReqsField, DbType.Boolean, this.IgnorePreRequirements));
            query.Parameters.Add(new QueryParameter("@" + CharacterBonusFeatModel.LevelField, DbType.Byte, this.Level));
			query.Parameters.Add(new QueryParameter("@" + CharacterBonusFeatModel.LastUpdatedDateField, DbType.DateTime, this.LastUpdatedDate));
			query.Parameters.Add(new QueryParameter("@" + CharacterBonusFeatModel.LastUpdatedVersionField, DbType.String, this.LastUpdatedVersion));

            BaseModel.RunCommand(query);
            }

        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can not delete this record as an actual Database entry does not exist. CharacterBonusFeatsModel: Delete()");
                return;
                }

            query = QueryInformation.Create(CharacterBonusFeatModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + CharacterBonusFeatModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);
            //lets reset the ID to empty so the model know it is a new record if the save routine is accessed afterwards for some reason.
            this.Id = Guid.Empty;
            }

        #endregion

        #region Public Static Methods
        /// <summary>
        /// Gets all records associated with the character
        /// </summary>
        /// <returns> A list of all CharacterBonusFeat Records.</return>
        public static List<CharacterBonusFeatModel> GetAll()
            {
            QueryInformation query;

            query = QueryInformation.Create(CharacterBonusFeatModel.LoadDetailsQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetAll<CharacterBonusFeatModel>(query, CharacterBonusFeatModel.Create);
            }

        /// <summary>
        /// Deletes all records that have the specified featId
        /// This should only be called if you are deleteing a primary Feat record
        /// </summary>
        /// <param name="featId">A guid value representing the feat you are deleting</param>
        public static void DeleteAllbyFeatId(Guid featId)
            {
            QueryInformation query;

            if (featId == Guid.Empty)
                return;

            query = QueryInformation.Create(CharacterBonusFeatModel.DeleteByFeatIdQuery);
            query.Parameters.Add(new QueryParameter("@" + CharacterBonusFeatModel.FeatIdField, DbType.Guid, featId));
            BaseModel.RunCommand(query);

            }

        #endregion
        }
    }
