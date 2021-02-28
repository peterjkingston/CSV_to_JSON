using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVJSONLib;
using Newtonsoft.Json.Linq;

namespace CSVJSON_Test.Dummy_Classes
{
	public class Dummy_CSVTable : ICSVTable
	{
        private string _json;

        public IEnumerable<ICSVAddress> Addresses { get; private set; }

        public IEnumerable<string> Headers => throw new NotImplementedException();

        public IEnumerable<IEnumerable<string>> Records => throw new NotImplementedException();

        public static CSVTable FindTable()
		{
			return new CSVTable();
		}

        public JToken AsJObject()
        {
            return JArray.Parse(_json);
        }

        public Dummy_CSVTable(string json)
        {
            _json = JArray.Parse(json).ToString();
        }

        public Dummy_CSVTable()
        {

        }
    }
}
