using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DDOCharacterPlanner.DataAccess
{
	/// <summary>
	/// Contains information about a query parameter.
	/// </summary>
	public sealed class QueryParameter
	{
		#region Internal Methods
		/// <summary>
		/// Copes this parameter to the specified parameter.
		/// </summary>
		/// <param name="parameter">A framework parameter to copy the data into.</param>
		internal void CopyTo(DbParameter parameter)
		{
			parameter.DbType = this.DbType;
			parameter.ParameterName = this.ParameterName;
			if (this.Value == null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = this.Value;
			}
		}
		#endregion

		#region Public Constructors
		/// <summary>
		/// Initializes a new instance of the QueryParameter class, populated with the specified values.
		/// </summary>
		/// <param name="parameterName">The name of the parameter.</param>
		/// <param name="type">The database type of the parameter.</param>
		/// <param name="value">The value of this parameter.</param>
		public QueryParameter(string parameterName, DbType type, object value)
		{
			this.ParameterName = parameterName;
			this.DbType = type;
			this.Value = value;
		}

		#endregion
		#region Public Methods
		/// <summary>
		/// Gets or sets the DbType of the parameter. 
		/// </summary>
		/// <value>One of the DbType values. The default is String.</value>
		public DbType DbType
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name of the DbParameter. 
		/// </summary>
		/// <value>The name of the DbParameter. The default is an empty string ("").</value>
		public string ParameterName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the value of the parameter. 
		/// </summary>
		/// <value>An Object that is the value of the parameter. The default value is null.</value>
		public object Value
		{
			get;
			set;
		}

		#endregion
	}
}
