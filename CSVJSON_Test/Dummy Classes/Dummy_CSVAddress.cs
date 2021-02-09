using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVJSONLib;

namespace CSVJSON_Test.Dummy_Classes
{
	public struct Dummy_CSVAddress : ICSVAddress
	{
		private bool _labelTop;
		private bool _tableHeader;
		private bool _standAlone;
		private bool _valid;

		public int Column { get; private set; }

		private bool _labelLeft;

		public int Row { get; private set; }

		public Dummy_CSVAddress(int row, int col, bool labelLeft = false, bool labelTop = false, bool tableHeader = false, bool standAlone = false, bool valid = false)
		{
			Row = row;
			Column = col;
			_labelLeft = labelLeft;
			_labelTop = labelTop;
			_tableHeader = tableHeader;
			_standAlone = standAlone;
			_valid = valid;
		}

		public bool IsLeftLabel(string[,] csvReport)
		{
			return _labelLeft;
		}

		public bool IsStandAlone(string[,] csvReport)
		{
			return _standAlone;
		}

		public bool IsTableHeader(string[,] csvReport)
		{
			return _tableHeader;
		}

		public bool IsTopLabel(string[,] csvReport)
		{
			return _labelTop;
		}

		public bool IsValid(string[,] csvReport)
		{
			return _valid;
		}
	}
}
