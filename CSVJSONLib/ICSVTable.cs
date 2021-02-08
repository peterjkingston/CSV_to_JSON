using System.Collections.Generic;

namespace CSVJSONLib
{
    public interface ICSVTable
    {
        IEnumerable<CSVAddress> Addresses { get; }
    }
}