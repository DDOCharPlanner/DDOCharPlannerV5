using DDOCharacterPlanner.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DDOCharacterPlanner.Model
	{
	class SpellSchoolModel : BaseModel
		{
		#region Private Constants
		private const string IdField = "SpellSchoolId";
		private const string NameField = "Name";
		private const string LoadNamesQuery = "SELECT Name FROM SpellSchool";
		private const string LoadIDFromNameQuery = "SELECT SpellSchoolId FROM SpellSchool WHERE Name=@Name";
		private const string LoadNameFromIdQuery = "SELECT Name FROM SpellSchool WHERE SpellSchoolId=@SpellSchoolId";
		#endregion

		#region Properties
		public string SchoolName
			{
			get;
			set;
			}
		#endregion

		#region Public Static Methods
		/// <summary>
		/// Gets the names.
		/// </summary>
		/// <returns>A list of all the spell school names.</returns>
		public static List<string> GetNames()
			{
			QueryInformation query;

			query = QueryInformation.Create(LoadNamesQuery);
			query.CommandType = CommandType.Text;

			return BaseModel.GetNames(query, ReadNames);
			}

		public static Guid GetIdFromName(string name)
			{
			QueryInformation query;
			List<Guid> ids;

			query = QueryInformation.Create(LoadIDFromNameQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + NameField, DbType.String, name));

			ids = BaseModel.GetIds(query, ReadIds);
			if (ids == null)
				return Guid.Empty;
			else
				//there should only be one value!
				return ids[0];
			}

		public static string GetNameFromId(Guid id)
			{
			QueryInformation query;
			List<string> names;

			query = QueryInformation.Create(LoadNameFromIdQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + IdField, DbType.Guid, id));

			names = BaseModel.GetNames(query, ReadNames);
			if (names == null)
				return "";
			else
				//there should only be one value!
				return names[0];
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

			if (reader.TryGetOrdinal(NameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					SchoolName = reader.GetString(ordinal);
					}
				}
			}
		#endregion

		#region Private Static Methods
		/// <summary>
		/// Reads the names.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <returns>The read id and name.</returns>
		private static string ReadNames(DbDataReader reader)
			{
			int ordinal;
			string name = null;

			if (reader == null)
				{
				return null;
				}

			if (reader.TryGetOrdinal(NameField, out ordinal))
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

			if (reader.TryGetOrdinal(IdField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					id = reader.GetGuid(ordinal);
					}
				}
			return id;
			}
		#endregion
		}
	}
