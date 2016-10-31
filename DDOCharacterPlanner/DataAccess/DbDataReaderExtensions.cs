using System.Collections.Generic;
using System.Runtime.Serialization;

namespace System.Data.Common
{
	/// <summary>
	/// Contains the extension methods for the DbDataReader class.
	/// </summary>
	public static class DbDataReaderExtension
	{
		/// <summary>
		/// Tries the get ordinal, if it can't find it it returns false.
		/// </summary>
		/// <param name="dr">The datareader to look in.</param>
		/// <param name="name">The name of the column.</param>
		/// <param name="ordinal">The location to put the ordinal.</param>
		/// <returns>True if the column is found, otherwise false.</returns>
		public static bool TryGetOrdinal(this DbDataReader dr, string name, out int ordinal)
		{
			ordinal = 0;

			if (dr == null)
			{
				return false;
			}

			if (dr.FieldCount == 0)
			{
				return false;
			}

			// Try first case sensitive
			for (int i = 0; i < dr.FieldCount; i++)
			{
				if (string.Compare(dr.GetName(i), name, StringComparison.Ordinal) == 0)
				{
					ordinal = i;
					return true;
				}
			}

			// Not found, do case insensitive lookup, just like normal GetOrdinal
			for (int i = 0; i < dr.FieldCount; i++)
			{
				if (string.Compare(dr.GetName(i), name, StringComparison.OrdinalIgnoreCase) == 0)
				{
					ordinal = i;
					return true;
				}
			}

			return false;
		}
	}
}
