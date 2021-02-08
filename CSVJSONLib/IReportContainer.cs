using System;

namespace CSVJSONLib
{
	public interface IReportContainer
	{
		void AddTable(CSVTable table);
		void AddProperty(string cell, string v);
		void AddProperty(string cell);
	}
}