namespace CSVJSONLib
{
    public interface ICSVReportReader
    {
        string[,] CsvReport { get; }

        IReportContainer GetProperties();
        void Read(string csvText);
    }
}