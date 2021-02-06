using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSONLib
{
    public class ReportContainer : IReportContainer
    {
        public void AddProperty(string v, Func<char[], string> trim)
        {
            throw new NotImplementedException();
        }

        public void AddProperty(string cell, string v)
        {
            throw new NotImplementedException();
        }

        public void AddProperty(string cell)
        {
            throw new NotImplementedException();
        }

        public void AddTable(CSVTable table)
        {
            throw new NotImplementedException();
        }
    }
}
