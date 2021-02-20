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
		public IEnumerable<ICSVAddress> Addresses { get; private set; }

        public IEnumerable<string> Headers => throw new NotImplementedException();

        public IEnumerable<IEnumerable<string>> Records => throw new NotImplementedException();

        public static CSVTable FindTable()
		{
			return new CSVTable();
		}
	}
}
