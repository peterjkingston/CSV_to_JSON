using System;

namespace CSVJSONLib
{
	public interface IReportContainer
	{
		void AddTable(CSVTable table);
		void AddProperty(string propertyName, string propertyValue);
		void AddProperty(string propertyValue);
	}
}