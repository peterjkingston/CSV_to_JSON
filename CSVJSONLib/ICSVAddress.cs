namespace CSVJSONLib
{
    public interface ICSVAddress
    {
        int Column { get; }
        int Row { get; }

        bool IsLeftLabel(string[,] csvReport);
        bool IsStandAlone(string[,] csvReport);
        bool IsTableHeader(string[,] csvReport);
        bool IsTopLabel(string[,] csvReport);
        bool IsValid(string[,] csvReport);
    }
}