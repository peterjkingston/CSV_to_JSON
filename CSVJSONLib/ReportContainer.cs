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
        public Dictionary<string, CSVTable> Tables { get; private set; }

        public ReportContainer(IUniqueNameProvider nameProvider)
        {
            _nameProvider = nameProvider;
        }

        public void AddProperty(string propertyName, string propertyValue)
        {
            string[] existingNames = GetExistingNames();
            Properties.Add(_nameProvider.GetUniqueName(existingNames, propertyName), propertyValue);
        }

        private string[] GetExistingNames()
        {
            return Properties.Keys.ToArray().Append(Tables.Keys.ToArray());
        }

        public void AddProperty(string propertyValue)
        {
            string[] existingNames = GetExistingNames();
            Properties.Add(_nameProvider.GetUniqueName(existingNames), propertyValue);
        }

        public void AddTable(string tableName, CSVTable table)
        {
            string[] existingNames = GetExistingNames();
            Tables.Add(_nameProvider.GetUniqueName(existingNames, tableName), table);
        }

        public void AddTable(CSVTable table)
        {
            string[] existingNames = GetExistingNames();
            Tables.Add(_nameProvider.GetUniqueName(existingNames), table);
        }
    }
}
