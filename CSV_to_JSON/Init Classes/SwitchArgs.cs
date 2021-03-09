using CSVJSONLib;
using System;
using System.IO;
using System.Linq;

namespace CSV_to_JSON
{
	public class SwitchArgs : ISwitchArgs 
	{
		public string TargetFilePath { get; }
		public string OutputFile { get; }

        public SwitchArgs(string[] args)
		{
            try
            {
				FileInfo targetFileInfo = new FileInfo(args[0]);
				TargetFilePath = targetFileInfo.Exists ? targetFileInfo.FullName : "";

				if(args.Contains("-o"))
                {
					FileInfo outputInfo = new FileInfo(args[args.IndexAfter("-o")]);
					OutputFile = outputInfo.FullName;
				}
			}
			catch(Exception ex)
            {
				Console.WriteLine(ex.Message);
            }
		}
	}
}