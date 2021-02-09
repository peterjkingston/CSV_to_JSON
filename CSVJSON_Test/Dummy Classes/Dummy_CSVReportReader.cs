using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		public IReportContainer GetProperties()
		{
			return _properties;
		}
	}
}
