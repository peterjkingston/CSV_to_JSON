using CSV_to_JSON;

namespace CSV_to_JSON_Tests
{
    internal class Dummy_SwitchArgs : ISwitchArgs
    {
        public Dummy_SwitchArgs(string targetPath) 
        {
            TargetFilePath = targetPath;
        }

        public string TargetFilePath { get; private set; }

        public string OutputFile { get { return "SomeOutputFile.json"; } }
            
    }
}