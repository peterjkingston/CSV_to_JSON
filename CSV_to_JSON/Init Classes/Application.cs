using CSV_to_JSON.Init_Classes;
using CSVJSONLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_to_JSON
{
	public class Application : IApplication	
	{
        private IOutputHandler _outputHandler;
        private ISwitchArgs _switchArgs;
        private ICSVReportReader _reportReader;

        public Application(IOutputHandler handler, ISwitchArgs switchArgs, ICSVReportReader reportReader)
        {
            _outputHandler = handler;
            _switchArgs = switchArgs;
            _reportReader = reportReader;
        }

		public void Run()
        {
            try
            {
                _reportReader.Read(File.ReadAllText(_switchArgs.TargetFilePath,Encoding.GetEncoding(1252)));
                IReportContainer reportContainer = _reportReader.GetProperties();

                if (_switchArgs.OutputFile != string.Empty)
                    _outputHandler.PrintToFile(reportContainer.ToJSON(), _switchArgs.OutputFile);
                
                _outputHandler.ToOutputStream(reportContainer.ToJSON());
            }
            catch (Exception ex)
            {
                _outputHandler.OutputError($"{ex.Message}\n\n{ex.StackTrace}");
            }
        }
	}
}
