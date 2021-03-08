using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVJSON_Test.Resources;
using CSVJSONLib;

namespace CSVJSON_Test.Dummy_Classes
{
	class Dummy_CSVReportReader : ICSVReportReader
	{
		private IReportContainer _properties;

		public string[,] CsvReport { get; private set; }

		public Dummy_CSVReportReader(IReportContainer properties)
		{
			_properties = properties;
		}

        public Dummy_CSVReportReader()
        {
        }

        public IReportContainer GetProperties()
		{
			return _properties;
		}

        public void Read(string csvText)
        {
			CsvReport = TEST_CONSTANTS.DUMMY_CSVSTRING_ARRAY;
        }
    }
}
