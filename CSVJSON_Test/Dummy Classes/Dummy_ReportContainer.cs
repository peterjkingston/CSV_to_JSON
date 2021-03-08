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
        private Dictionary<string, string> _props;
        private Dictionary<string, ICSVTable> _tables;

        public Dummy_ReportContainer(string[] props, string[] vals)
        {
			_props = new Dictionary<string,string>();
			_tables = new Dictionary<string, ICSVTable>();
			for(int i=0; i < props.Length; i++)
            {
				_props.Add(props[i], vals[i]);
            }
        }

        public Dictionary<string, ICSVTable> Tables => throw new NotImplementedException();

        public Dictionary<string, string> Properties => throw new NotImplementedException();

        public void AddProperty(string propertyName, string propertyValue)
		{
            if (!_props.ContainsKey(propertyName))
            {
				_props.Add(propertyName, propertyValue);
			}
			else
            {
				AddProperty(propertyName + _props.Count.ToString(), propertyValue);
            }
		}

		public void AddProperty(string propertyValue)
		{
			_props.Add(_props.Count.ToString(), propertyValue);
		}

		public void AddTable(ICSVTable table)
		{
			_tables.Add("Table_" + _tables.Count.ToString(), table);
		}

        public void AddTable(string v, ICSVTable table)
        {
            throw new NotImplementedException();
        }

        public string ToJSON()
        {
            return "{\"className\":\"Dummy_ReportContainer\"}";
        }
    }
}
