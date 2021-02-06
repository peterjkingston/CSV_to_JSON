using System;
using System.Collections.Generic;

namespace CSVJSONLib
{
	internal class CSVTable
	{
		public CSVAddress TopLeft { get; internal set; }
		public CSVAddress BottomRight { get; internal set; }
		public IEnumerable<CSVAddress> Addresses { get; internal set; }

		internal static CSVTable FindTable(int row, int col, string[,] csvReport)
		{
			throw new NotImplementedException();
		}
	}
}