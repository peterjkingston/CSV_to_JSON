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
                byte[] fileBytes = ReadFile(_switchArgs.TargetFilePath);
                byte[] utf8Bytes =  Encoding.Convert(_switchArgs.TargetFileEncoding, Encoding.UTF8, fileBytes);
               
                string csvReportText = Encoding.UTF8.GetString(utf8Bytes);
                _reportReader.Read(csvReportText);
                IReportContainer reportContainer = _reportReader.GetProperties();

                if (_switchArgs.OutputFile != string.Empty)
                    _outputHandler.PrintToFile(
                        Encoding.UTF8.GetBytes(reportContainer.ToJSON()), 
                        _switchArgs.OutputFile);
                
                _outputHandler.ToOutputStream(
                    reportContainer.ToJSON()
                );
            }
            catch (Exception ex)
            {
                _outputHandler.OutputError($"{ex.Message}\n\n{ex.StackTrace}");
            }
        }

        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length    
                buffer = new byte[length];            // create buffer     
                int count;                            // actual number of bytes read     
                int sum = 0;                          // total number of bytes read    

                // read until Read method returns 0 (end of the stream has been reached)    
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }
    }
}
