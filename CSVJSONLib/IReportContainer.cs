using System;

namespace CSVJSONLib
{
	public interface IReportContainer
	{
		void AddProperty(string v, Func<char[], string> trim);
		void AddTable(CSVTable table);
		void AddProperty(string cell, string v);
		void AddProperty(string cell);
	}
}