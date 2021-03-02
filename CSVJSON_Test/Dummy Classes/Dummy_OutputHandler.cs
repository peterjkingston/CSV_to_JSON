using CSV_to_JSON.Init_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSON_Test.Dummy_Classes
{
    public class Dummy_OutputHandler : IOutputHandler
    {
        public string Output { get; private set; }
        public string ErrorOutput { get; internal set; }

        public Dummy_OutputHandler()
        {
            Output = "";
            ErrorOutput = "";
        }

        public void ToOutputStream(string outputObj)
        {
            Output = outputObj;
        }

        public void OutputError(string errorMessage)
        {
            ErrorOutput = errorMessage;
        }
    }
}
