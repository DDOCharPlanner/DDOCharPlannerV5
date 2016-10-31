using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using DDOCharacterPlanner.DataAccess;

namespace DDOCharacterPlanner.Model
	{
	/// <summary>
	/// Contains the functionality common to all models.
	/// </summary>
	public abstract class BaseModel
		{
		#region Properties
		public Guid Id
			{
			get;
			protected set;
			}

		public DateTime LastUpdatedDate
			{
			get;
			protected set;
			}

		public string LastUpdatedVersion
			{
			get;
			protected set;
			}
		#endregion

		#region Private Static Methods
		/// <summary>
		/// Creates the command.
		/// </summary>
		/// <returns>
		/// The newly created SQLCommandExecution object.
		/// </returns>
		private static DatabaseCommandExecution CreateCommand()
			{
			DatabaseCommandExecution command;

			command = DatabaseCommandExecution.Create("Data Source=DDOCharacterPlanner.sdf;Persist security Info=true;");

			return command;
			}
		#endregion

		#region Protected Static Methods
		/// <summary>
		/// Deletes the entry.
		/// </summary>
		/// <param name="query">The query.</param>
		protected static void RunCommand(QueryInformation query)
			{
			DatabaseCommandExecution command;
			command = BaseModel.CreateCommand();
			command.ExecuteNonQuery(query);
			}

		protected static List<string> GetNames(QueryInformation query, Func<DbDataReader, string> readName)
			{
			List<string> names;
			string name;
			DatabaseCommandExecution command;

			command = BaseModel.CreateCommand();
			using (DbDataReader dr = command.ExecuteQuery(query))
				{
				names = new List<string>();

				while (dr.Read())
					{
					name = readName(dr);
					if (!string.IsNullOrWhiteSpace(name))
						{
						names.Add(name);
						}
					}
				}

			return names;
			}
        protected static Dictionary<Guid, string> GetNamesByID(QueryInformation query, Func<DbDataReader, Dictionary<Guid, string>> readName)
        {
            Dictionary<Guid, string> names;
            Dictionary<Guid, string> name;
            DatabaseCommandExecution command;
            int ordinal;
            command = BaseModel.CreateCommand();
            using (DbDataReader dr = command.ExecuteQuery(query))
            {
                names = new Dictionary<Guid, string>(); ;

                while (dr.Read())
                {
                    name = readName(dr);
                    if (name.Count == 1)
                    {
                        foreach(KeyValuePair<Guid,string> pair in name)
                            names.Add(pair.Key,pair.Value);

                    }

                }
            }

            return names;


        }
        protected static int GetCount(QueryInformation query)
        {
            DatabaseCommandExecution command;
            int ordinal;

            command = BaseModel.CreateCommand();
            using (DbDataReader dr = command.ExecuteQuery(query))
            {
                if (!dr.Read())
                {
                    return 0;
                }

                if (!dr.TryGetOrdinal("Count", out ordinal))
                {
                    return 0;
                }

                if (dr.IsDBNull(ordinal))
                {
                    return 0;
                }

                return dr.GetInt32(ordinal);
            }
        }
        protected static int GetMax (QueryInformation query, Func<DbDataReader, int> readName)
        {
            int MaxValue = 0;
            int CurrentValue  = 0;
            DatabaseCommandExecution command;

            command = BaseModel.CreateCommand();
            using (DbDataReader dr = command.ExecuteQuery(query))
            {
                while (dr.Read())
                {
                    CurrentValue = readName(dr);
                    if (CurrentValue > MaxValue)
                    {
                        MaxValue = CurrentValue;
                    }
                }
            }

            return MaxValue;
        }

        protected static int GetMin(QueryInformation query, Func<DbDataReader, int> readName)
        {
            int MinLevel = DDOCharacterPlanner.Utility.Constant.MaxLevels;
            int CurrentValue;
            DatabaseCommandExecution command;

            command = BaseModel.CreateCommand();
            using (DbDataReader dr = command.ExecuteQuery(query))
            {
                while (dr.Read())
                {
                    CurrentValue = readName(dr);
                    if (CurrentValue < MinLevel)
                    {
                        MinLevel = CurrentValue;
                    }
                }
            }

            return MinLevel;
        }

		protected static List<Guid> GetIds(QueryInformation query, Func<DbDataReader, Guid> readIds)
			{
			List<Guid> ids;
			Guid id;
			DatabaseCommandExecution command;

			command = BaseModel.CreateCommand();
			using (DbDataReader dr = command.ExecuteQuery(query))
				{
				ids = new List<Guid>();

				while (dr.Read())
					{
					id = readIds(dr);
					if (id != Guid.Empty)
						{
						ids.Add(id);
						}
					}
				}

			return ids;
			}

		protected static List<T> GetAll<T>(QueryInformation query, Func<DbDataReader, T> create) where T : BaseModel
			{
			List<T> models;
			T model;
			DatabaseCommandExecution command;

			command = BaseModel.CreateCommand();
			using (DbDataReader dr = command.ExecuteQuery(query))
				{
				models = new List<T>();

				while (dr.Read())
					{
					model = create(dr);
					if (model != null)
						{
						models.Add(model);
						}
					}
				}

			return models;
			}
        protected static bool GetBoolean(QueryInformation query)
        {

            int ordinal;
            ordinal = 0;
            DatabaseCommandExecution command;

            command = BaseModel.CreateCommand();
            using (DbDataReader dr = command.ExecuteQuery(query))
            {
                dr.Read();
                if(!dr.GetBoolean(ordinal))
                {
                    return false;
                }
                else
                {
                    return dr.GetBoolean(ordinal);
                }

            }
        }

		#endregion

		#region Protected Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="BaseModel" /> class.
		/// </summary>
		protected BaseModel()
			: base()
			{
			}
		#endregion

		#region Protected Methods
		/// <summary>
		/// Loads the specified reader.
		/// </summary>
		/// <param name="reader">The reader.</param>
		protected abstract void Load(DbDataReader reader);

		/// <summary>
		/// Converts the comma separated string into an array of ints.
		/// </summary>
		/// <param name="field">The field.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns>
		/// The array of ints.  If one coulsn't be converted, it is set to the default value.
		/// </returns>
		protected int[] ConvertCommaSeparatedField(string field, int defaultValue = 0)
			{
			string[] parts;
			int[] values;
			int value;

			if (string.IsNullOrWhiteSpace(field))
				{
				return new int[0];
				}

			parts = field.Split(',');
			Array.ForEach(parts, item => item = item.Trim());

			values = new int[parts.Length];

			for (int i = 0; i < parts.Length; i++)
				{
				if (string.IsNullOrWhiteSpace(parts[i]))
					{
					values[i] = defaultValue;
					continue;
					}

				if (!int.TryParse(parts[i], out value))
					{
					values[i] = defaultValue;
					continue;
					}

				values[i] = value;
				}

			return values;
			}

		protected string CreateCommaSeparatedField(int[] values)
			{
			if (values == null)
				{
				return "";
				}

			return string.Join(",", Array.ConvertAll(values, item => item.ToString()));
			}

		protected void Initialize(QueryInformation query)
			{
			DatabaseCommandExecution command;

			command = BaseModel.CreateCommand();
			using (DbDataReader dr = command.ExecuteQuery(query))
				{
				if (!dr.Read())
					{
					return;
					}

				this.Load(dr);
				}
			}

		#endregion
		}
	}
