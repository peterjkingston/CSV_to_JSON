using System;
using System.Collections.Generic;
using System.IO;
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
            File.AppendAllText("ErrorLog.txt", "<!--START ERROR-->\n" + DateTime.Now.ToString() + " " + errorMessage + "\n<!--END ERROR-->\n");
        }

        public void ToOutputStream(string outputObj)
        {
            Console.WriteLine(outputObj);
        }

        public void PrintToFile(string outputObj, string toFile)
        {
            File.WriteAllText(toFile, outputObj);
        }
    }
}
