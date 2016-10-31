using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using DDOCharacterPlanner.DataAccess;
using DDOCharacterPlanner.Data;

namespace DDOCharacterPlanner.Model
	{

	/// <summary>
	/// Defines data availability for a destiny.
	/// </summary>
	public sealed class DestinySphereModel : BaseModel
		{
		#region Private Constants
		private const string IdField = "DestinySphereId";
		private const string NameField = "Name";
		private const string LoadSphereByNameQuery = "SELECT * FROM DestinySphere WHERE Name=@Name";
		private const string LoadSphereByIdQuery = "SELECT * FROM DestinySphere WHERE DestinySphereId=@DestinySphereId";
		private const string LoadNamesQuery = "SELECT * FROM DestinySphere";
		private const string InsertQuery = "INSERT INTO DestinySphere (DestinySphereId, Name) VALUES (@DestinySphereId, @Name)";
		private const string UpdateQuery = "UPDATE DestinySphere SET Name=@Name WHERE DestinySphereId=@DestinySphereId";
		#endregion

		#region Properties
		public string Name
			{
			get;
			set;
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
			Guid id;
			string name = null;

			if (reader == null)
				{
				return null;
				}

			if (!reader.TryGetOrdinal(DestinySphereModel.IdField, out ordinal))
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

			if (reader.TryGetOrdinal(DestinySphereModel.NameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					name = reader.GetString(ordinal);
					}
				}

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

			if (!reader.TryGetOrdinal(DestinySphereModel.IdField, out ordinal))
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

			if (reader.TryGetOrdinal(DestinySphereModel.NameField, out ordinal))
				{
				if (!reader.IsDBNull(ordinal))
					{
					this.Name = reader.GetString(ordinal);
					}
				}
			}
		#endregion

		#region Public Methods
		public void Initialize(string sphereName)
			{
			QueryInformation query;

			if (string.IsNullOrWhiteSpace(sphereName))
			{
				return;
			}

			query = QueryInformation.Create(DestinySphereModel.LoadSphereByNameQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + DestinySphereModel.NameField, DbType.String, sphereName));

			this.Initialize(query);
			}

		public void Initialize(Guid sphereId)
		{
			QueryInformation query;

			if (sphereId == Guid.Empty)
			{
				return;
			}

			query = QueryInformation.Create(DestinySphereModel.LoadSphereByIdQuery);
			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + DestinySphereModel.IdField, DbType.Guid, sphereId));

			this.Initialize(query);
		}

		public void Save()
		{
			QueryInformation query;

			if (this.Id == Guid.Empty)
			{
				query = QueryInformation.Create(DestinySphereModel.InsertQuery);
				this.Id = Guid.NewGuid();
			}
			else
			{
				query = QueryInformation.Create(DestinySphereModel.UpdateQuery);
			}

			query.CommandType = CommandType.Text;
			query.Parameters.Add(new QueryParameter("@" + DestinySphereModel.IdField, DbType.Guid, this.Id));
			query.Parameters.Add(new QueryParameter("@" + DestinySphereModel.NameField, DbType.String, this.Name));

			BaseModel.RunCommand(query);
		}
		#endregion

		#region Public Static Methods
		/// <summary>
		/// Gets the names.
		/// </summary>
		/// <returns>A list of all the class names.</returns>
		public static List<string> GetNames()
			{
			QueryInformation query;

			query = QueryInformation.Create(DestinySphereModel.LoadNamesQuery);
			query.CommandType = CommandType.Text;

			return BaseModel.GetNames(query, DestinySphereModel.ReadNames);
			}
		#endregion
		}
	}
