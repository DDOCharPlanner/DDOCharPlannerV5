using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

namespace DDOCharacterPlanner.DataAccess
{
	/// <summary>
	/// A helper class for executing SQL statements.
	/// </summary>
	public class DatabaseCommandExecution
	{
		#region Private Static Methods
		/// <summary>
		/// Copies the parameters.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="sqlCommand">The SQL command.</param>
		private static void CopyParameters(DbCommand command, QueryInformation sqlCommand)
		{
			DbParameter parameter;

			if (!sqlCommand.HasParameters)
			{
				return;
			}

			for (int i = 0; i < sqlCommand.Parameters.Count; i++)
			{
				parameter = command.CreateParameter();
				sqlCommand.Parameters[i].CopyTo(parameter);
				command.Parameters.Add(parameter);
			}
		}
		#endregion
		#region Private Methods
		/// <summary>
		/// Gets or sets the connection string.
		/// </summary>
		/// <value>
		/// The connection string.
		/// </value>
		private string ConnectionString
		{
			get;
			set;
		}

		/// <summary>
		/// Returns an open connection via the SQLDatabaseConnection service.
		/// </summary>
		/// <returns>A <see cref="System.Data.SqlClient.SqlConnection">SqlConnection</see> object.</returns>
		private DbConnection GetConnection()
		{
			SqlCeConnection connection = null;

			connection = new SqlCeConnection(this.ConnectionString);
			connection.Open();

			return connection;
		}

		/// <summary>
		/// Creates the command.
		/// </summary>
		/// <param name="connection">The connection.</param>
		/// <param name="trans">The trans.</param>
		/// <param name="sqlCommand">The SQL command.</param>
		/// <returns>A new command object.</returns>
		private DbCommand CreateCommand(DbConnection connection, DbTransaction trans, QueryInformation sqlCommand)
		{
			DbCommand command;

			if (connection == null)
			{
				throw new ArgumentNullException("connection");
			}

			if (string.IsNullOrEmpty(sqlCommand.CommandText))
			{
				throw new ArgumentException("empty", "sqlCommand");
			}

			command = connection.CreateCommand();
			command.CommandText = sqlCommand.CommandText;
			command.CommandType = sqlCommand.CommandType;

			if (trans != null)
			{
				command.Transaction = trans;
			}

			DatabaseCommandExecution.CopyParameters(command, sqlCommand);

			return command;
		}

		/// <summary>
		/// Runs the query.
		/// </summary>
		/// <param name="connection">The connection.</param>
		/// <param name="trans">The trans.</param>
		/// <param name="sqlCommand">The SQL command.</param>
		/// <param name="behavior">The behavior.</param>
		/// <returns>A data reader with the results.</returns>
		private DbDataReader RunQuery(DbConnection connection, DbTransaction trans, QueryInformation sqlCommand, CommandBehavior behavior)
		{
			using (DbCommand command = this.CreateCommand(connection, trans, sqlCommand))
			{
				return command.ExecuteReader(behavior);
			}
		}

		/// <summary>
		/// Runs the command.
		/// </summary>
		/// <param name="connection">The connection.</param>
		/// <param name="trans">The trans.</param>
		/// <param name="sqlCommand">The SQL command.</param>
		/// <returns>The number of rows that were processed.</returns>
		private int RunCommand(DbConnection connection, DbTransaction trans, QueryInformation sqlCommand)
		{
			using (DbCommand command = this.CreateCommand(connection, trans, sqlCommand))
            {
                    return command.ExecuteNonQuery();
			}
		}
		#endregion

		#region Protected Constructors
		/// <summary>
		/// Initializes a new instance of the DatabaseCommandExecution class.
		/// </summary>
		/// <param name="connectionString">The connection string.</param>
		/// <remarks>
		/// Sending an Empty userGuid will used the default user guid.
		/// </remarks>
		protected DatabaseCommandExecution(string connectionString)
		{
			if (string.IsNullOrWhiteSpace(connectionString))
			{
				throw new ArgumentNullException("connectionString");
			}

			this.ConnectionString = connectionString;
		}
		#endregion

		#region Public Static Methods
		/// <summary>
		/// Initializes a new instance of the DatabaseCommandExecution class.
		/// </summary>
		/// <param name="connectionString">The connection string.</param>
		/// <returns>
		/// A newly created DatabaseCommandExecution object.
		/// </returns>
		public static DatabaseCommandExecution Create(string connectionString)
		{
			return new DatabaseCommandExecution(connectionString);
		}
		#endregion
		#region Public Methods
		/// <summary>
		/// Gets or sets the SQL Command timeout to be used, in seconds.  Defaults to 30 seconds.
		/// </summary>
		/// <value>
		/// The amount of time (in seconds) to wait for the command to complete.
		/// </value>
		public int CommandTimeout
		{
			get;
			set;
		}

		/// <summary>
		/// Opens a connection to the database, executes the SQL command, and returns a DataReader.
		/// </summary>
		/// <param name="sqlCommand">The query information to execute the query.</param>
		/// <returns>
		/// A DataReader, the result of executing the sqlCommand.
		/// </returns>
		/// <remarks>
		/// The database connection's execution behavior is set to close connection.  Once the returned DataReader
		/// is closed, the connection to the database will close.
		/// </remarks>
		public DbDataReader ExecuteQuery(QueryInformation sqlCommand)
		{
			DbDataReader reader;
			DbConnection connection;

			connection = this.GetConnection();
			reader = this.RunQuery(connection, null, sqlCommand, CommandBehavior.CloseConnection);
			return reader;
		}

		/// <summary>
		/// Given a connection to a database, this opens the connection if necessary, executes the SQL command and
		/// returns a DataReader.
		/// </summary>
		/// <param name="sqlCommand">The query information to execute the query.</param>
		/// <param name="connection">A connection to a database.</param>
		/// <returns>
		/// A DataReader, the result of executing the sqlCommand.
		/// </returns>
		public DbDataReader ExecuteQuery(QueryInformation sqlCommand, DbConnection connection)
		{
			return this.RunQuery(connection, null, sqlCommand, CommandBehavior.Default);
		}

		/// <summary>
		/// Given an open transaction, this opens the corresponding connection if necessary, executes the SQL command
		/// and returns a DataReader.
		/// </summary>
		/// <param name="sqlCommand">The query information to execute the query.</param>
		/// <param name="transaction">An open SQL transaction.</param>
		/// <returns>
		/// A DataReader, the result of executing the sqlCommand.
		/// </returns>
		public DbDataReader ExecuteQuery(QueryInformation sqlCommand, DbTransaction transaction)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}

			return this.RunQuery(transaction.Connection, transaction, sqlCommand, CommandBehavior.Default);
		}

		/// <summary>
		/// Given an open transaction, this opens the corresponding connection if necessary, executes the SQL command
		/// and returns a DataReader.
		/// </summary>
		/// <param name="sqlCommand">The query information to execute the query.</param>
		/// <returns>
		/// A DataReader, the result of executing the sqlCommand.
		/// </returns>
		public int ExecuteNonQuery(QueryInformation sqlCommand)
		{
			int numRows;

			using (DbConnection connection = this.GetConnection())
			{
				numRows = this.RunCommand(connection, null, sqlCommand);
				connection.Close();
				return numRows;
			}
		}

		/// <summary>
		/// Executes the SQL command as a "Non-Query" using the provided Connection, and returns the number of rows
		/// and returns a DataReader.
		/// </summary>
		/// <param name="sqlCommand">The query information to execute the query.</param>
		/// <param name="connection">A connection to a database.</param>
		/// <returns>
		/// A DataReader, the result of executing the sqlCommand.
		/// </returns>
		public int ExecuteNonQuery(QueryInformation sqlCommand, DbConnection connection)
		{
			return this.RunCommand(connection, null, sqlCommand);
		}

		/// <summary>
		/// Executes the SQL command as a "Non-Query" using the provided Transaction, and returns the number of rows.
		/// </summary>
		/// <param name="sqlCommand">The query information to execute the query.</param>
		/// <param name="transaction">An open SQL transaction.</param>
		/// <returns>A DataReader, the result of executing the sqlCommand.</returns>
		public int ExecuteNonQuery(QueryInformation sqlCommand, DbTransaction transaction)
		{
			return this.RunCommand(transaction.Connection, transaction, sqlCommand);
		}

		/// <summary>
		/// Starts a new transaction on a connection.
		/// </summary>
		/// <returns>
		/// A SqlTransaction.
		/// </returns>
		public DbTransaction StartTransaction()
		{
			DbConnection connection = this.GetConnection();
			return connection.BeginTransaction();
		}

		/// <summary>
		/// Creates a paramter for use in a query.
		/// </summary>
		/// <param name="name">The name of the parameter.</param>
		/// <param name="type">The database type of the parameter.</param>
		/// <param name="value">The value of the object.</param>
		/// <returns>
		/// A new dbparameter.
		/// </returns>
		public QueryParameter CreateParameter(string name, DbType type, object value)
		{
			return new QueryParameter(name, type, value);
		}
		#endregion
	}
}
