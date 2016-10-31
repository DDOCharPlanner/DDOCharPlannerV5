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
    /// Defines data availability for a Race Record.
    /// </summary>
    public sealed class RaceModel : BaseModel
        {
        #region Private Constants
        private const string IdField = "RaceId";
        private const string NameField = "Name";
        private const string DescriptionField = "Description";
        private const string StrengthMinimumField = "StrengthMinimum";
        private const string StrengthMaximumField = "StrengthMaximum";
        private const string DexterityMinimumField = "DexterityMinimum";
        private const string DexterityMaximumField = "DexterityMaximum";
        private const string ConstitutionMinimumField = "ConstitutionMinimum";
        private const string ConstitutionMaximumField = "ConstitutionMaximum";
        private const string IntelligenceMinimumField = "IntelligenceMinimum";
        private const string IntelligenceMaximumField = "IntelligenceMaximum";
        private const string WisdomMinimumField = "WisdomMinimum";
        private const string WisdomMaximumField = "WisdomMaximum";
        private const string CharismaMinimumField = "CharismaMinimum";
        private const string CharismaMaximumField = "CharismaMaximum";
        private const string StartingClassIdField = "StartingClassId";
        private const string MaleImageFileNameField = "MaleImageFileName";
        private const string FemaleImageFileNameField = "FemaleImageFileName";
        private const string AbbreviationField = "Abbreviation";
        private const string LastUpdatedDateField = "LastUpdatedDate";
        private const string LastUpdatedVersionField = "LastUpdatedVersion";
        private const string SequenceField = "Sequence";
        private const string IconicField = "Iconic";
        private const string PastLifeFeatIdField = "PastLifeFeatId";

        private const string CountQuery = "SELECT COUNT(*) AS Count FROM Race";
        private const string CountbyNameQuery = "SELECT COUNT(*) AS Count FROM Race WHERE Name=@Name";
        private const string CountByAbbreviationQuery = "SELECT COUNT(*) AS Count FROM Race WHERE Abbreviation=@Abbreviation";
        private const string CountIconicNumQuery = "SELECT COUNT(*) AS Count FROM Race WHERE Iconic=@Iconic";

        private const string LoadRaceByNameQuery = "SELECT * FROM Race WHERE Name=@Name";
        private const string LoadRaceByIdQuery = "SELECT * FROM Race WHERE RaceId=@RaceId";
        private const string LoadRaceBySequenceQuery = "SELECT * FROM Race WHERE Sequence=@Sequence";
        private const string LoadRaceByAbbreviationQuery = "SELECT * FROM Race WHERE Abbreviation=@Abbreviation";
        private const string LoadNamesQuery = "SELECT RaceId, Name FROM Race ORDER BY Sequence";
        private const string LoadIconicNamesQuery = "SELECT RaceId, Name FROM Race WHERE Iconic=@Iconic ORDER BY Sequence";

        private const string GetIdFromNameQuery = "SELECT RaceId FROM Race WHERE Name=@Name";
        private const string GetNameFromIdQuery = "SELECT Name FROM Race WHERE RaceId=@RaceId";

        private const string DeleteQuery = "DELETE FROM Race WHERE RaceId=@RaceId";
        private const string InsertQuery = "INSERT INTO Race (RaceId, Name, Description, StrengthMinimum, StrengthMaximum, DexterityMinimum, DexterityMaximum, ConstitutionMinimum, ConstitutionMaximum, IntelligenceMinimum, IntelligenceMaximum, WisdomMinimum, WisdomMaximum, CharismaMinimum, CharismaMaximum, StartingClassId, MaleImageFileName, FemaleImageFileName, Abbreviation, LastUpdatedDate, LastUpdatedVersion, Sequence, Iconic, PastLifeFeatId) VALUES (@RaceId, @Name, @Description, @StrengthMinimum, @StrengthMaximum, @DexterityMinimum, @DexterityMaximum, @ConstitutionMinimum, @ConstitutionMaximum, @IntelligenceMinimum, @IntelligenceMaximum, @WisdomMinimum, @WisdomMaximum, @CharismaMinimum, @CharismaMaximum, @StartingClassId, @MaleImageFileName, @FemaleImageFileName, @Abbreviation, @LastUpdatedDate, @LastUpdatedVersion, @Sequence, @Iconic, @PastLifeFeatId)";
        private const string UpdateQuery = "UPDATE Race SET Name=@Name, Description=@Description, StrengthMinimum=@StrengthMinimum, StrengthMaximum=@StrengthMaximum, DexterityMinimum=@DexterityMinimum, DexterityMaximum=@DexterityMaximum, ConstitutionMinimum=@ConstitutionMinimum, ConstitutionMaximum=@ConstitutionMaximum, IntelligenceMinimum=@IntelligenceMinimum, IntelligenceMaximum=@IntelligenceMaximum, WisdomMinimum=@WisdomMinimum, WisdomMaximum=@WisdomMaximum, CharismaMinimum=@CharismaMinimum, CharismaMaximum=@CharismaMaximum, StartingClassId=@StartingClassId, MaleImageFileName=@MaleImageFileName, FemaleImageFileName=@FemaleImageFileName, Abbreviation=@Abbreviation, LastUpdatedDate=@LastUpdatedDate, LastUpdatedVersion=@LastUpdatedVersion, Sequence=@Sequence, Iconic=@Iconic, PastLifeFeatId=@PastLifeFeatId WHERE RaceId=@RaceId";
        private const string UpdateSequenceQuery = "UPDATE Race SET Sequence=@Sequence WHERE RaceId=@RaceId";
        private const string UpdatePastLifeFeatIdByPastLifeFeatIdQuery = "UPDATE Race SET PastLifeFeatId=@NewValue WHERE PastLifeFeatId=@PastLifeFeatId";

        //default value for the constructor
        private const string DefaultImageFileName = "NoImage";
        private const string DefaultDescription = "<HTML><body style=\"background: #000000\"><font color=\"white\"><p><B>Bold Text</b></p><p>Regular Text</p><p>Important stats</p><p>Strength...</p></font></body></HTML>";
        private const int DefaultBaseScore = 8;
        private const int DefaultMaxScore = 18;
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

        public int StrengthMinimum
            {
            get;
            set;
            }

        public int StrengthMaximum
            {
            get;
            set;
            }

        public int DexterityMinimum
            {
            get;
            set;
            }

        public int DexterityMaximum
            {
            get;
            set;
            }

        public int ConstitutionMinimum
            {
            get;
            set;
            }

        public int ConstitutionMaximum
            {
            get;
            set;
            }

        public int IntelligenceMinimum
            {
            get;
            set;
            }

        public int IntelligenceMaximum
            {
            get;
            set;
            }

        public int WisdomMinimum
            {
            get;
            set;
            }

        public int WisdomMaximum
            {
            get;
            set;
            }

        public int CharismaMinimum
            {
            get;
            set;
            }

        public int CharismaMaximum
            {
            get;
            set;
            }

        public Guid StartingClassId
            {
            get;
            set;
            }

        public string MaleImageFileName
            {
            get;
            set;
            }

        public string FemaleImageFileName
            {
            get;
            set;
            }

        public string Abbreviation
            {
            get;
            set;
            }

        public int Sequence
            {
            get;
            set;
            }

        public bool Iconic
            {
            get;
            set;
            }

        public Guid PastLifeFeatId
            {
            get;
            set;
            }

        #endregion

        #region Constructors
        public RaceModel()
            {
            QueryInformation query;

            //set up default values for the properties when needed.
            Description = DefaultDescription;
            MaleImageFileName = DefaultImageFileName;
            FemaleImageFileName = DefaultImageFileName;
            StrengthMinimum = DefaultBaseScore;
            StrengthMaximum = DefaultMaxScore;
            DexterityMinimum = DefaultBaseScore;
            DexterityMaximum = DefaultMaxScore;
            ConstitutionMinimum = DefaultBaseScore;
            ConstitutionMaximum = DefaultMaxScore;
            IntelligenceMinimum = DefaultBaseScore;
            IntelligenceMaximum = DefaultMaxScore;
            WisdomMinimum = DefaultBaseScore;
            WisdomMaximum = DefaultMaxScore;
            CharismaMinimum = DefaultBaseScore;
            CharismaMaximum = DefaultMaxScore;

            //set the default sequence number (default to last record in sequence)
            query = QueryInformation.Create(RaceModel.CountQuery);
            query.CommandType = CommandType.Text;
            Sequence = BaseModel.GetCount(query);
            }
        #endregion

        #region Private Static Methods
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

            if (reader.TryGetOrdinal(RaceModel.IdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    id = reader.GetGuid(ordinal);
                }
            return id;
            }

        /// <summary>
        /// Reads the names.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>The read id and name.</returns>
        private static string ReadNames(DbDataReader reader)
            {
            int ordinal;
            Guid id;
            string name = null;

            if (reader == null)
                {
                return null;
                }

            if (!reader.TryGetOrdinal(RaceModel.IdField, out ordinal))
                {
                // No ID field, can't use
                return null;
                }

            if (reader.IsDBNull(ordinal))
                {
                // Null, can't use
                return null;
                }

            id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(RaceModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    name = reader.GetString(ordinal);
                    }
                }

            return name;
            }

        private static string ReadName(DbDataReader reader)
            {
            int ordinal;
            string name = null;

            if (reader == null)
                return null;

            if (reader.TryGetOrdinal(RaceModel.NameField, out ordinal))
                if (!reader.IsDBNull(ordinal))
                    name = reader.GetString(ordinal);

            return name;
            }

        #endregion

        #region Protected Methods
        /// <summary>
        /// Loads the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        protected override void Load(DbDataReader reader)
            {
            int ordinal;

            if (reader == null)
                {
                return;
                }

            if (!reader.TryGetOrdinal(RaceModel.IdField, out ordinal))
                {
                // No ID field, can't use
                return;
                }

            if (reader.IsDBNull(ordinal))
                {
                // Null, can't use
                return;
                }

            Id = reader.GetGuid(ordinal);

            if (reader.TryGetOrdinal(RaceModel.NameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    Name = reader.GetString(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.DescriptionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    Description = reader.GetString(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.StrengthMinimumField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    StrengthMinimum = reader.GetInt32(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.StrengthMaximumField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    StrengthMaximum = reader.GetInt32(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.DexterityMinimumField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    DexterityMinimum = reader.GetInt32(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.DexterityMaximumField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    DexterityMaximum = reader.GetInt32(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.ConstitutionMinimumField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    ConstitutionMinimum = reader.GetInt32(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.ConstitutionMaximumField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    ConstitutionMaximum = reader.GetInt32(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.IntelligenceMinimumField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    IntelligenceMinimum = reader.GetInt32(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.IntelligenceMaximumField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    IntelligenceMaximum = reader.GetInt32(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.WisdomMinimumField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    WisdomMinimum = reader.GetInt32(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.WisdomMaximumField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    WisdomMaximum = reader.GetInt32(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.CharismaMinimumField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    CharismaMinimum = reader.GetInt32(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.CharismaMaximumField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    CharismaMaximum = reader.GetInt32(ordinal);
                    }
                }
            if (reader.TryGetOrdinal(RaceModel.StartingClassIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    StartingClassId = reader.GetGuid(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.MaleImageFileNameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    MaleImageFileName = reader.GetString(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.FemaleImageFileNameField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    FemaleImageFileName = reader.GetString(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.AbbreviationField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    Abbreviation = reader.GetString(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.LastUpdatedDateField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    LastUpdatedDate = reader.GetDateTime(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.LastUpdatedVersionField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    LastUpdatedVersion = reader.GetString(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.SequenceField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    Sequence = reader.GetByte(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.IconicField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    Iconic = reader.GetBoolean(ordinal);
                    }
                }

            if (reader.TryGetOrdinal(RaceModel.PastLifeFeatIdField, out ordinal))
                {
                if (!reader.IsDBNull(ordinal))
                    {
                    PastLifeFeatId = reader.GetGuid(ordinal);
                    }
                }
            }

        #endregion

        #region Public Methods
        /// <summary>
        /// Creates the specified Race by RaceId
        /// </summary>
        /// <param name="raceId">Id of the Race.</param>
        public void Initialize(Guid raceId)
            {
            QueryInformation query;

            if (raceId == Guid.Empty)
                return;

            query = QueryInformation.Create(RaceModel.LoadRaceByIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceModel.IdField, DbType.Guid, raceId));

            this.Initialize(query);
            }

        /// <summary>
        /// Creates the specified by Name.
        /// </summary>
        /// <param name="raceName">Name of the Race.</param>
        public void Initialize(string raceName)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(raceName))
                return;

            query = QueryInformation.Create(RaceModel.LoadRaceByNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceModel.NameField, DbType.String, raceName));

            this.Initialize(query);
            }

        /// <summary>
        /// Creates the specified Race by Sequence
        /// </summary>
        /// <param name="raceSequence">Sequence Number of the Race</param>
        public void Initialize(int raceSequence)
            {
            QueryInformation query;

            query = QueryInformation.Create(RaceModel.LoadRaceBySequenceQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceModel.SequenceField, DbType.Byte, raceSequence));

            this.Initialize(query);
            }

        /// <summary>
        /// Creates the specified Race by Abbreviation
        /// </summary>
        /// <param name="raceAbbreviation">Abbreviation of the Race name</param>
        public void InitializeByAbbreviation(string raceAbbreviation)
            {
            QueryInformation query;

            if (string.IsNullOrWhiteSpace(raceAbbreviation))
                return;

            query = QueryInformation.Create(RaceModel.LoadRaceByAbbreviationQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceModel.AbbreviationField, DbType.String, raceAbbreviation));

            this.Initialize(query);
            }

        public void Save()
            
            {
            QueryInformation query;
            QueryInformation countquery;

            if (this.Id == Guid.Empty)
                {
                query = QueryInformation.Create(RaceModel.InsertQuery);
                this.Id = Guid.NewGuid();

                //since this is a new record, lets assign the sequence number automatically.
                countquery = QueryInformation.Create(RaceModel.CountQuery);
                countquery.CommandType = CommandType.Text;
                Sequence = BaseModel.GetCount(countquery);
                }
            else
                query = QueryInformation.Create(RaceModel.UpdateQuery);

            //update the last modified fields
            LastUpdatedDate = DateTime.Now;
            LastUpdatedVersion = Constant.PlannerVersion;

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceModel.IdField, DbType.Guid, this.Id));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.NameField, DbType.String, this.Name));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.DescriptionField, DbType.String, this.Description));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.StrengthMinimumField, DbType.Int32, this.StrengthMinimum));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.StrengthMaximumField, DbType.Int32, this.StrengthMaximum));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.DexterityMinimumField, DbType.Int32, this.DexterityMinimum));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.DexterityMaximumField, DbType.Int32, this.DexterityMaximum));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.ConstitutionMinimumField, DbType.Int32, this.ConstitutionMinimum));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.ConstitutionMaximumField, DbType.Int32, this.ConstitutionMaximum));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.IntelligenceMinimumField, DbType.Int32, this.IntelligenceMinimum));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.IntelligenceMaximumField, DbType.Int32, this.IntelligenceMaximum));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.WisdomMinimumField, DbType.Int32, this.WisdomMinimum));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.WisdomMaximumField, DbType.Int32, this.WisdomMaximum));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.CharismaMinimumField, DbType.Int32, this.CharismaMinimum));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.CharismaMaximumField, DbType.Int32, this.CharismaMaximum));
			if (this.StartingClassId == Guid.Empty)
			    {
				query.Parameters.Add(new QueryParameter("@" + RaceModel.StartingClassIdField, DbType.Guid, null));
			    }
			else
			    {
				query.Parameters.Add(new QueryParameter("@" + RaceModel.StartingClassIdField, DbType.Guid, this.StartingClassId));
			    }
            query.Parameters.Add(new QueryParameter("@" + RaceModel.MaleImageFileNameField, DbType.String, this.MaleImageFileName));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.FemaleImageFileNameField, DbType.String, this.FemaleImageFileName));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.AbbreviationField, DbType.String, this.Abbreviation));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.LastUpdatedDateField, DbType.DateTime, this.LastUpdatedDate));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.LastUpdatedVersionField, DbType.String, this.LastUpdatedVersion));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.SequenceField, DbType.Byte, this.Sequence));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.IconicField, DbType.Boolean, this.Iconic));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.PastLifeFeatIdField, DbType.Guid, this.PastLifeFeatId));

            BaseModel.RunCommand(query);
            }

        public void Delete()
            {
            QueryInformation query;

            if (this.Id == Guid.Empty)
                {
                Debug.WriteLine("Error: You can not delete this record, there is no database entry for it. RaceModel: Delete()");
                return;
                }

            //Need to delete associated records first before deleting the Main record.
            RaceLevelDetailModel.DeleteAllByRaceId(this.Id);
            RaceBonusFeatModel.DeleteAllByRaceId(this.Id);

            query = QueryInformation.Create(RaceModel.DeleteQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceModel.IdField, DbType.Guid, this.Id));
            BaseModel.RunCommand(query);

            //lets reset the Id to empty so the model knows it is a new record now if the "Save()" is called afterwards for some reason.
            this.Id = Guid.Empty;
            }

        public void SaveSequence()
            {
            QueryInformation query;

            query = QueryInformation.Create(RaceModel.UpdateSequenceQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceModel.IdField, DbType.Guid, Id));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.SequenceField, DbType.Byte, this.Sequence));
            BaseModel.RunCommand(query);
            }

        #endregion

        #region Public Static Methods
        /// <summary>
        /// Gets all the race names
        /// </summary>
        /// <returns>A list of all the Race names.</return>
        public static List<string> GetNames()
            {
            QueryInformation query;

            query = QueryInformation.Create(RaceModel.LoadNamesQuery);
            query.CommandType = CommandType.Text;

            return BaseModel.GetNames(query, RaceModel.ReadNames);
            }

        public static List<string> GetIconicNames()
        {
            QueryInformation query;

            query = QueryInformation.Create(RaceModel.LoadIconicNamesQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceModel.IconicField, DbType.Boolean, true));

            return BaseModel.GetNames(query, RaceModel.ReadNames);
        }

        public static int GetNumIconic()
        {
            QueryInformation query;

            query = QueryInformation.Create(RaceModel.CountIconicNumQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceModel.IconicField, DbType.Boolean, true));

            return BaseModel.GetCount(query);

        }

        public static bool DoesNameExist(string name)
            {
            QueryInformation query;

            query = QueryInformation.Create(RaceModel.CountbyNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceModel.NameField, DbType.String, name));

            return BaseModel.GetCount(query) > 0;
            }

        public static bool DoesAbbreviationExist(string abbreviation)
            {
            QueryInformation query;

            query = QueryInformation.Create(RaceModel.CountByAbbreviationQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceModel.AbbreviationField, DbType.String, abbreviation));

            return BaseModel.GetCount(query) > 0;
            }

        /// <summary>
        /// Get the Ablity id of the specified Save
        /// </summary>
        /// <param name="name">Name of the Save</param>
        /// <returns>An Id of the Save</returns>
        public static Guid GetIdFromName(string name)
            {
            QueryInformation query;
            List<Guid> ids;

            query = QueryInformation.Create(RaceModel.GetIdFromNameQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceModel.NameField, DbType.String, name));

            ids = BaseModel.GetIds(query, RaceModel.ReadId);
            if (ids.Count == 0)
                return Guid.Empty;
            else
                return ids[0]; // there should only be one value!
            }

        public static string GetNameFromId(Guid raceId)
            {
            QueryInformation query;
            List<string> names;

            query = QueryInformation.Create(RaceModel.GetNameFromIdQuery);
            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@" + RaceModel.IdField, DbType.Guid, raceId));

            names = BaseModel.GetNames(query, RaceModel.ReadName);
            if (names.Count == 0)
                return "";
            else
                return names[0];
            }

        public static void UpdatePastLifeFeatIdWithNull(Guid pastLifeFeatId)
            {
            QueryInformation query;

            if (pastLifeFeatId == Guid.Empty)
                return;

            query = QueryInformation.Create(RaceModel.UpdatePastLifeFeatIdByPastLifeFeatIdQuery);

            query.CommandType = CommandType.Text;
            query.Parameters.Add(new QueryParameter("@NewValue", DbType.Guid, null));
            query.Parameters.Add(new QueryParameter("@" + RaceModel.PastLifeFeatIdField, DbType.Guid, pastLifeFeatId));

            BaseModel.RunCommand(query);

            }
        #endregion
        }
    }
