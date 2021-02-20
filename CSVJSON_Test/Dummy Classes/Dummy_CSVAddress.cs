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
		public int Row { get; private set; }

		private bool _labelLeft;
        private bool _isBlank;
        private string _value;

		string[,] _plane;

        public string Value { get { return _value; } }

        public string[,] Plane { get { return _plane; } }

        public Dummy_CSVAddress(int row, int col, string[,] plane, string value = "", bool labelLeft = false, bool labelTop = false, bool tableHeader = false, bool standAlone = false, bool valid = false, bool blank = false)
		{
			Row = row;
			Column = col;
			_labelLeft = labelLeft;
			_labelTop = labelTop;
			_tableHeader = tableHeader;
			_standAlone = standAlone;
			_valid = valid;
			_isBlank = blank;
			_value = value;
			_plane = plane;
		}

		public bool IsLeftLabel()
		{
			return _labelLeft;
		}

		public bool IsStandAlone()
		{
			return _standAlone;
		}

		public bool IsTableHeader()
		{
			return _tableHeader;
		}

		public bool IsTopLabel()
		{
			return _labelTop;
		}

		public bool IsValid()
		{
			return _valid;
		}

        public bool IsBlank()
        {
            return _isBlank;
        }

        public bool IsZero()
        {
            throw new NotImplementedException();
        }
    }
}
