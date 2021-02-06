using System;

namespace CSVJSONLib
{
	public struct CSVAddress
	{
		private int col;

		public CSVAddress(int row, int col) : this()
		{
			Row = row;
			this.col = col;
		}

		public int Column { get; internal set; }
		public int Row { get; internal set; }

		public bool IsStandAlone(string[,] csvReport)
		{
			return !IsLeftLabel(csvReport) &&
				   !IsTableHeader(csvReport) &&
				   !IsTopLabel(csvReport);
		}

		public bool IsTopLabel(string[,] csvReport)
		{
			bool result = csvReport.GetLength(0) < this.Row &&
						  csvReport[this.Row + 1, this.Column].IsNumeric();
			return result;
		}

		public bool IsValid(string[,] csvReport)
        {
			return this.Row < csvReport.GetLength(0) && this.Column < csvReport.GetLength(1);
        }

		public bool IsLeftLabel(string[,] csvReport)
		{
			bool result = csvReport.GetLength(1) < this.Column + 1 &&
						  csvReport[this.Row, this.Column + 1].IsNumeric(); 

			return result;
		}

		public bool IsTableHeader(string[,] csvReport)
        {
			bool result = csvReport.GetLength(1) < this.Column + 2 &&
						  csvReport[this.Row, this.Column + 1] != string.Empty &&
						  csvReport[this.Row, this.Column + 2] != string.Empty;
			return result;
        }
	}
}