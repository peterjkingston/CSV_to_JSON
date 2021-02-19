using System.Collections.Generic;

namespace CSVJSONLib
{
    public interface ICSVTable
    {
        IEnumerable<ICSVAddress> Addresses { get; }
        IEnumerable<string> Headers { get; }
        IEnumerable<IEnumerable<string>> Records { get; }
    }
}