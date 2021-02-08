using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSONLib
{
    public class CSVReportReader
    {
		public string[,] CsvReport { get; }
		bool[,] _inspected;
		private IReportContainer _reportContainer;

		public CSVReportReader(string csvText, IReportContainer reportContainer)
		{
			CsvReport = ArrayFromCSV(csvText);
			_reportContainer = reportContainer;
			_inspected = new bool[CsvReport.GetUpperBound(0), CsvReport.GetUpperBound(1)];
			_inspected.Fill(false);
		}

		private string[,] ArrayFromCSV(string csvText)
		{
			if (csvText != string.Empty)
			{
				string doubleQuotes = "\"\"";
				string ddQuotes = doubleQuotes + doubleQuotes;
				char enq = (char)5;
				char esc = (char)27;
				char comma = ',';

				string[] rows = csvText.Trim().Split('\n');
				int rowCount = rows.Length;
				int columnCount = rows[0].DoubleQuoteSplit(", ").Length;
				int c = 0;
				string[,] result = new string[rowCount, columnCount];
				for (int row = 0; row < rowCount; row++)
				{
					string cell = rows[row];
					if (cell != string.Empty)
					{
						if (cell.Contains(ddQuotes)) cell.Replace(ddQuotes, new string(new char[] { enq }));
						for (int characterIndex = 0; characterIndex < cell.Length; characterIndex++)
						{
							char character = cell[characterIndex];
							if (new string(new char[] { character }) == doubleQuotes) c++;
							if (character == comma && c % 2 != 0)
							{
								char[] cellCharacters = cell.ToCharArray();
								cellCharacters[characterIndex] = esc;
								cell = new string(cellCharacters);
							}
						}
						if (cell.Contains(doubleQuotes)) cell.Replace(doubleQuotes, string.Empty);

						string[] arry = cell.DoubleQuoteSplit(new string(new char[] { comma }));
						for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
						{
							cell = arry[columnIndex];
							if (cell.Contains(esc)) cell.Replace(esc, comma);
							if (cell.Contains(enq)) cell.Replace(new string(new char[] { esc }), doubleQuotes);
							result[row, columnIndex] = cell;
						}
					}
					
				}
				return result;
			}
			else
			{
				return new string[0, 0];
			}
		}

		public IReportContainer GetProperties()
		{
			for(int row = 0; row < CsvReport.GetLength(0); row++)
			{
				for (int col = 0; col < this.CsvReport.GetLength(1); col++)
				{
					if (!IsInspected(row, col))
					{
						string cell = this.CsvReport[row, col];
						CSVAddress address = new CSVAddress(row, col);

						//If the cell contains both the property name and the value
						if (cell.Split(':').Length == 2)
						{
							string[] parts = cell.Split(':');
							_reportContainer.AddProperty(parts[0].Trim(), parts[1].Trim());
							_inspected[row, col] = true;
							continue;
						}

						//If the cell is empty
						if(cell == string.Empty)
						{
							_inspected[row, col] = true;
							continue;
						}

						//If the cell is part of a table
						if (address.IsTableHeader(CsvReport))
						{
							CSVTable table = CSVTable.FindTable(row, col, CsvReport);

							foreach(CSVAddress tableAddress in table.Addresses)
							{
								_reportContainer.AddTable(table);
								MarkInspected(tableAddress);
							}
							continue;
						}

						//If the cell has a numeric value to the right
						if (address.IsLeftLabel(CsvReport))
						{
							_reportContainer.AddProperty(cell, CsvReport[row, col + 1]);
							_inspected[row, col] = true;
							_inspected[row, col + 1] = true;
						}

						//If the cell has a numeric value beneath
						if (address.IsTopLabel(CsvReport))
						{
							_reportContainer.AddProperty(cell, CsvReport[row + 1, col]);
							_inspected[row, col] = true;
							_inspected[row + 1, col] = true;
						}

						//If the cell property name and value is separated by a whitepace
						if (cell.Split(' ').Length == 2)
						{
							string[] parts = cell.Split(' ');
							_reportContainer.AddProperty(parts[0], parts[1]);
							_inspected[row, col] = true; ;
						}

						//If the cell value is stand-alone
						if(address.IsStandAlone(CsvReport))
						{
							_reportContainer.AddProperty(cell);
							_inspected[row, col] = true;
						}
					}
				}
			}

			return _reportContainer;
		}

		private void MarkInspected(CSVAddress address)
		{
			_inspected[address.Row, address.Column] = true;
		}

		private bool IsInspected(int row, int col)
		{
			return _inspected[row, col];
		}
	}
}
