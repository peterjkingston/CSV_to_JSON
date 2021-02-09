using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVJSONLib;

namespace CSVJSON_Test.Dummy_Classes
{
	public class Dummy_ReportContainer : IReportContainer
	{
		public void AddProperty(string propertyName, string propertyValue)
		{
			throw new NotImplementedException();
		}

		public void AddProperty(string propertyValue)
		{
			throw new NotImplementedException();
		}

		public void AddTable(CSVTable table)
		{
			throw new NotImplementedException();
		}
	}
}
