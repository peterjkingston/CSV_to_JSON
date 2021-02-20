using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSONLib
{
    public class ReportContainer : IReportContainer
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
            if (propertyName.Trim() != string.Empty && propertyValue.Trim() != string.Empty)
                Properties.Add(_nameProvider.GetUniqueName(existingNames, propertyName), propertyValue);
        }

        private string[] GetExistingNames()
        {
            string[] propNames = Properties.Count > 0? Properties.Keys.ToArray() : new string[0];
            string[] tableNames = Tables.Count > 0 ? Tables.Keys.ToArray() : new string[0];
            propNames.Append(tableNames);
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
    }
}
