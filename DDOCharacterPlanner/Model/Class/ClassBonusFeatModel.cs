using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
    {
    /// <summary>
    ///  Defines data avialability for a Class's Auto-granted feats.
    /// </summary>
    public sealed class ClassBonusFeatModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "ClassBonusFeatId";
        private const string ClassIdField = "ClassId";
        private const string FeatIdField = "FeatId";
        private const string LevelField = "Level";
        private const string HasPreRequirementsField = "HasPreRequirements";

        private const string LoadDetailsByClassQuery = "SELECT * FROM ClassBonusFeat WHERE ClassId=@ClassId ORDER BY Level";

        private const string DeleteQuery = "DELETE FROM ClassBonusFeat WHERE ClassBonusFeatId=@ClassBonusFeatId";
        private const string DeleteByClassIdQuery = "DELETE FROM ClassBonusFeat WHERE ClassId=@ClassId";
        private const string DeleteByFeatIdQuery = "DELETE FROM ClassBonusFeat WHERE FeatId=@FeatId";
        private const string InsertQuery = "INSERT INTO ClassBonusFeat (ClassBonusFeatId, ClassId, FeatId, Level, HasPreRequirements) VALUES (@ClassBonusFeatId, @ClassId, @FeatId, @Level, @HasPreRequirements)";
        private const string UpdateQuery = "UPDATE ClassBonusFeat SET ClassId=@ClassId, FeatId=@FeatId, Level=@Level, HasPreRequirements=@HasPreRequirements WHERE ClassBonusFeatId=@ClassBonusFeatId";

        #endregion

        #region Properties
        public Guid ClassId
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
        private static ClassBonusFeatModel Create(DbDataReader reader)
            {
            ClassBonusFeatModel model;

            model = new ClassBonusFeatModel();
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

            if (!reader.TryGetOrdinal(ClassBonusFeatModel.IdField, out ordinal))
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

            if (reader.TryGetOrdinal(ClassBonusFeatModel.ClassIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.ClassId = reader.GetGuid(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(ClassBonusFeatModel.FeatIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.FeatId = reader.GetGuid(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(ClassBonusFeatModel.HasPreRequirementsField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    this.HasPreRequirements = reader.GetBoolean(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(ClassBonusFeatModel.LevelField, out ordinal))
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
                query = QueryInformation.Create(ClassBonusFeatModel.InsertQuery);
                this.Id = Guid.NewGuid();
                }
            else
                {
                query = QueryInformation.Create(ClassBonusFeatModel.UpdateQuery);
                }

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ClassBonusFeatModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + ClassBonusFeatModel.ClassIdField, DbType.Guid, this.ClassId));
            query.Parameters.Add(new QueryParameter("@" + ClassBonusFeatModel.FeatIdField, DbType.Guid, this.FeatId));
            query.Parameters.Add(new QueryParameter("@" + ClassBonusFeatModel.HasPreRequirementsField, DbType.Boolean, this.HasPreRequirements));
            query.Parameters.Add(new QueryParameter("@" + ClassBonusFeatModel.LevelField, DbType.Byte, this.Level));

            BaseModel.RunCommand(query);
            }

        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can not delete this record as an actual Database entry does not exist. ClassBonusFeatsModel: Delete()");
                return;
                }

            query = QueryInformation.Create(ClassBonusFeatModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + ClassBonusFeatModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);
            //lets reset the ID to empty so the model know it is a new record if the save routine is accessed afterwards for some reason.
            this.Id = Guid.Empty;
            }
        #endregion

        #region Public Static Methods
        public static List<ClassBonusFeatModel> GetAll(Guid classID)
            {
            QueryInformation query;

            if (classID == Guid.Empty)
                {
                return new List<ClassBonusFeatModel>();
                }

            query = QueryInformation.Create(ClassBonusFeatModel.LoadDetailsByClassQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@ClassId", DbType.Guid, classID));

            return BaseModel.GetAll<ClassBonusFeatModel>(query, ClassBonusFeatModel.Create);
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

            query = QueryInformation.Create(ClassBonusFeatModel.DeleteByFeatIdQuery);
            query.Parameters.Add(new QueryParameter("@" + ClassBonusFeatModel.FeatIdField, DbType.Guid, featId));
            BaseModel.RunCommand(query);
            }

        /// <summary>
        /// Deletes all records that have the specified classId
        /// This should only be called if you are deleteing a primary Class record
        /// </summary>
        /// <param name="featId">A guid value representing the class you are deleting</param>
        public static void DeleteAllbyClassId(Guid classId)
            {
            QueryInformation query;

            if (classId == Guid.Empty)
                return;

            query = QueryInformation.Create(ClassBonusFeatModel.DeleteByClassIdQuery);
            query.Parameters.Add(new QueryParameter("@" + ClassBonusFeatModel.ClassIdField, DbType.Guid, classId));
            BaseModel.RunCommand(query);
            }

        #endregion
        }
    }
