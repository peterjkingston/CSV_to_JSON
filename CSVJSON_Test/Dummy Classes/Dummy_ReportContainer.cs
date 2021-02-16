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
        private Dictionary<string, CSVTable> _tables;

        public Dummy_ReportContainer(string[] props, string[] vals)
        {
			_props = new Dictionary<string,string>();
			_tables = new Dictionary<string, CSVTable>();
			for(int i=0; i < props.Length; i++)
            {
				_props.Add(props[i], vals[i]);
            }
        }

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

		public void AddTable(CSVTable table)
		{
			_tables.Add("Table_" + _tables.Count.ToString(), table);
		}
	}
}
