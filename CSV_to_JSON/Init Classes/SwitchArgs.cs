using CSVJSONLib;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CSV_to_JSON
{
	public class SwitchArgs : ISwitchArgs 
	{
		public string TargetFilePath { get; }
		public string OutputFile { get; }

        public Encoding TargetFileEncoding { get; }

        public SwitchArgs(string[] args)
		{
            try
            {
				//TargetFilePath
				FileInfo targetFileInfo = new FileInfo(args[0]);
				TargetFilePath = targetFileInfo.Exists ? targetFileInfo.FullName : "";


				//OutputFile
				if(args.Contains("-o"))
                {
					FileInfo outputInfo = new FileInfo(args[args.IndexAfter("-o")]);
					OutputFile = outputInfo.FullName;
				}

				//TargetFileEncoding
				if (args.Contains("-e"))
				{
					string encodingStr = args[args.IndexAfter("-e")];
					if(int.TryParse(encodingStr,out int encodingNumber))
                    {
						TargetFileEncoding = Encoding.GetEncoding(encodingNumber);
                    }
                    else
                    {
						TargetFileEncoding = Encoding.GetEncoding(encodingStr);
					}
				}
                else
                {
					TargetFileEncoding = Encoding.UTF8;
                }
			}
			catch(Exception ex)
            {
				Console.WriteLine(ex.Message);
            }
		}
	}
}