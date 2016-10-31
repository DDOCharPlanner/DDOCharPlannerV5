using System.Collections.Generic;
using System.Data;

namespace DDOCharacterPlanner.DataAccess
{
	/// <summary>
	/// Contains the information about the Query Information class.
	/// </summary>
	public sealed class QueryInformation
	{
		#region Private Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="QueryInformation" /> class.
		/// </summary>
		/// <param name="commandString">The command string.</param>
		private QueryInformation(string commandString)
		{
			this.CommandText = commandString;
			this.CommandType = CommandType.Text;
			this.Parameters = new List<QueryParameter>();
		}

		#endregion
		#region Public Static Methods
		/// <summary>
		/// Creates an instance of the query information with the specified command string.
		/// </summary>
		/// <param name="command">The command string.</param>
		/// <returns>A new QueryInformation object.</returns>
		public static QueryInformation Create(string command)
		{
			return new QueryInformation(command);
		}
		#endregion
		#region Public Methods
		/// <summary>
		/// Gets the text command to run against the data source.
		/// </summary>
		/// <value>The text command to execute. The default value is an empty string ("").</value>
		public string CommandText
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the parameters.
		/// </summary>
		/// <remarks>This will always retrieve a list, even if it is empty.</remarks>
		/// <value>The parameters of the SQL statement or stored procedure.</value>
		public List<QueryParameter> Parameters
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets a value indicating whether or not parameters currently exist.
		/// </summary>
		/// <value>True if there are parameters, otherwise false.</value>
		public bool HasParameters
		{
			get
			{
				if (this.Parameters == null || this.Parameters.Count == 0)
				{
					return false;
				}

				return true;
			}
		}

		/// <summary>
		/// Gets or sets how the CommandText property is interpreted.
		/// </summary>
		/// <value>One of the CommandType values. The default is Text.</value>
		public CommandType CommandType
		{
			get;
			set;
		}
		#endregion
	}
}
