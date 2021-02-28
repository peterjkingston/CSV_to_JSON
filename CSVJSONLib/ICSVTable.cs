using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CSVJSONLib
{
    public interface ICSVTable: IJSONConvertable
    {
        IEnumerable<ICSVAddress> Addresses { get; }
        IEnumerable<string> Headers { get; }
        IEnumerable<IEnumerable<string>> Records { get; }
    }
}