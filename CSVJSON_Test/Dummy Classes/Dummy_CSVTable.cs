using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVJSONLib;

namespace CSVJSON_Test.Dummy_Classes
{
	public class Dummy_CSVTable : ICSVTable
	{
		public IEnumerable<CSVAddress> Addresses { get; private set; }

		public static CSVTable FindTable()
		{
			return new CSVTable();
		}
	}
}
