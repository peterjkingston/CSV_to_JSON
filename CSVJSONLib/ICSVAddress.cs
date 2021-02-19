namespace CSVJSONLib
{
    public interface ICSVAddress
    {
        int Column { get; }
        int Row { get; }

        string Value { get; }
        string[,] Plane { get; }

        bool IsLeftLabel();
        bool IsStandAlone();
        bool IsTableHeader();
        bool IsTopLabel();
        bool IsValid();
        bool IsBlank();
        bool IsZero();
    }
}