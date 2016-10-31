using DDOCharacterPlanner.DataAccess;
using System.Data.SqlServerCe;
using System.IO;

namespace DDOCharacterPlanner.SaveDataModel
	{
	public abstract class SaveBaseModel
		{
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

			command = DatabaseCommandExecution.Create("Data Source=\\Saves\\DDOCPSaves.sdf;Persist security Info=true;");

			return command;
			}
		#endregion

		#region Protected Methods
		protected void CreateDatabase()
			{
			string connStr = "Data Source = Saves\\DDOCPSave.sdf";
			DirectoryInfo di;
			SqlCeEngine engine;
			SqlCeConnection conn;
			SqlCeCommand cmd;

			if (!File.Exists("Saves\\DDOCPSave.sdf"))
				{
				//create the subdirectory
				di = new DirectoryInfo("Saves");

				// Create the directory only if it does not already exist. 
				if (di.Exists == false)
					di.Create();

				//create the database
				engine = new SqlCeEngine(connStr);
				engine.CreateDatabase();

				//open a connection
				conn = new SqlCeConnection(connStr);
				conn.Open();

				//set up the tables
				cmd = conn.CreateCommand();
				cmd.CommandText = "CREATE TABLE SkinSaves([Name] nvarchar(20) NOT NULL)";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "ALTER TABLE [SkinSaves] ADD [Col] nvarchar(25) NULL";
				cmd.ExecuteNonQuery();

				conn.Close();
				} 
			}
		#endregion
		}
	}
