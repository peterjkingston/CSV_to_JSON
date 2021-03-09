namespace CSV_to_JSON.Init_Classes
{
    public interface IOutputHandler
    {
        void ToOutputStream(string outputObj);
        void OutputError(string errorMessage);
        void PrintToFile(string outputObj, string toFilePath);
    }
}