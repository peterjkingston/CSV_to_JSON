using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSONLib
{
    public class UniqueNameProvider : IUniqueNameProvider
    {
        public string FirstNumericTerminator { get; private set; }
        const char NUMERIC_DELIMITER = '-';
        const string DEFAULT_NAME = "Undefined Parameter-1";

        public string GetUniqueName(string[] names, string preferredName)
        {
            if (!names.Contains(preferredName))
            {
                return preferredName;
            }
            else
            {
                string newName = HasNumericTerminator(preferredName) ? NextNumericTerminator(preferredName) : FirstNumericTerminator;
                return newName;
            }
        }

        private string NextNumericTerminator(string preferredName_withNumeric)
        {
            int indexStartNumeric = preferredName_withNumeric.LastIndexOf(NUMERIC_DELIMITER);
            int indexEndNumeric = preferredName_withNumeric.Length - 1;
            int numericLength = indexEndNumeric - indexStartNumeric;

            string preferredOnly = preferredName_withNumeric.Substring(0, indexStartNumeric);
            int numeric = int.Parse(preferredName_withNumeric.Split(NUMERIC_DELIMITER).Last());
            return string.Concat(preferredOnly, NUMERIC_DELIMITER, numeric++);
        }

        private bool HasNumericTerminator(string preferredName)
        {
            return int.TryParse(preferredName.Split(NUMERIC_DELIMITER).Last(), out int dummy);
        }

        public string GetUniqueName(string[] names)
        {
            return GetUniqueName(names, DEFAULT_NAME);
        }
    }
}
