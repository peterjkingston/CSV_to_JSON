using System;
using System.Collections.Generic;

namespace CSVJSONLib
{
	public interface IReportContainer
	{
		Dictionary<string, ICSVTable> Tables { get; }
		Dictionary<string, string> Properties { get; }

        void AddTable(ICSVTable table);
		void AddProperty(string propertyName, string propertyValue);
		void AddProperty(string propertyValue);
	}
}