using System;

namespace CSVJSONLib
{
	internal struct CSVAddress
	{
		private int col;

		public CSVAddress(int row, int col) : this()
		{
			Row = row;
			this.col = col;
		}

		public int Column { get; internal set; }
		public int Row { get; internal set; }

		internal bool IsStandAlone(string[,] csvReport)
		{
			throw new NotImplementedException();
		}

		internal bool IsTopLabel(string[,] csvReport)
		{
			throw new NotImplementedException();
		}

		internal bool IsLeftLabel(string[,] csvReport)
		{
			throw new NotImplementedException();
		}
	}
}