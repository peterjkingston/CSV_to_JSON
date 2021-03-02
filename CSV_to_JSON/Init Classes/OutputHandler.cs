using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_to_JSON.Init_Classes
{
    public class OutputHandler : IOutputHandler
    {
        public OutputHandler()
        {

        }

        public void OutputError(string errorMessage)
        {
            throw new NotImplementedException();
        }

        public void ToOutputStream(string outputObj)
        {
            Console.WriteLine(outputObj);
        }
    }
}
