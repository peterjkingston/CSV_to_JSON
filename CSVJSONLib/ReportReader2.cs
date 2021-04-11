using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSONLib
{
    public class ReportReader2 : ICSVReportReader
    {
        private IReportContainer _reportContainer;

        public string[,] CsvReport => throw new NotImplementedException();

        public ReportReader2(IReportContainer reportContainer)
        {
            _reportContainer = reportContainer;
        }

        public IReportContainer GetProperties()
        {
            throw new NotImplementedException();
        }

        public void Read(string csvText)
        {
            string[] lines = csvText.Split('\n');
            foreach(string line in lines)
            {

            }
        }
    }
}
