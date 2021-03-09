using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSVJSONLib
{
    public class ReportContainer : IReportContainer, IJSONConvertable
    {
        private IUniqueNameProvider _nameProvider;

        public Dictionary<string, string> Properties { get; private set; }
        public Dictionary<string, ICSVTable> Tables { get; private set; }

        public ReportContainer(IUniqueNameProvider nameProvider)
        {
            _nameProvider = nameProvider;
            Properties = new Dictionary<string, string>();
            Tables = new Dictionary<string, ICSVTable>();
        }

        public void AddProperty(string propertyName, string propertyValue)
        {
            string[] existingNames = GetExistingNames();
            Properties.Add(_nameProvider.GetUniqueName(existingNames, propertyName), propertyValue);
        }

        private string[] GetExistingNames()
        {
            string[] propNames = Properties.Count > 0? Properties.Keys.ToArray() : new string[0];
            string[] tableNames = Tables.Count > 0 ? Tables.Keys.ToArray() : new string[0];
            propNames = propNames.Append(tableNames);
            return propNames;
        }

        public void AddProperty(string propertyValue)
        {
            string[] existingNames = GetExistingNames();
            if(propertyValue.Trim() != string.Empty) 
            Properties.Add(_nameProvider.GetUniqueName(existingNames), propertyValue);
        }

        public void AddTable(string tableName, ICSVTable table)
        {
            string[] existingNames = GetExistingNames();
            if (table != null)
                Tables.Add(_nameProvider.GetUniqueName(existingNames, tableName), table);
        }

        public void AddTable(ICSVTable table)
        {
            string[] existingNames = GetExistingNames();
            if (table != null)
                Tables.Add(_nameProvider.GetUniqueName(existingNames), table);
        }

        public string ToJSON()
        {
            JObject jo = new JObject();
            foreach (string key in Properties.Keys)
            {
                jo.Add(key,Properties[key]);
            }
            foreach (string key in Tables.Keys)
            {
                jo.Add(key, Tables[key].AsJObject());
            }
            return jo.ToString();
        }

        public JToken AsJObject()
        {
            return JObject.Parse(ToJSON());
        }
    }
}
