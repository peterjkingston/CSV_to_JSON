using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSONLib
{
    public class CSVReportReader : ICSVReportReader
    {
        public string[,] CsvReport { get; private set; }
        bool[,] _inspected;
        private IReportContainer _reportContainer;

        public CSVReportReader(IReportContainer reportContainer)
        {
            _reportContainer = reportContainer == null ? new ReportContainer(new UniqueNameProvider()): reportContainer ;
        }

        public void Read(string csvText)
        {
            CsvReport = ArrayFromCSV(csvText);
            _inspected = new bool[CsvReport.GetLength(0), CsvReport.GetLength(1)];
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
                int columnCount = rows[0].Trim(new char[] { '\r' }).DoubleQuoteSplit(comma).Length;
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

                        string[] arry = cell.DoubleQuoteSplit(comma);
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
            if(_reportContainer == null)
            {
                return _reportContainer;
            }

            for (int row = 0; row < CsvReport.GetLength(0); row++)
            {
                for (int col = 0; col < this.CsvReport.GetLength(1); col++)
                {
                    if (!IsInspected(row, col))
                    {
                        string cell = this.CsvReport[row, col].Trim(new char[] { '\r', '\n' });
                        ICSVAddress address = new CSVAddress(row, col, CsvReport);


                        //If the cell contains both the property name and the value
                        if (cell.Split(':').Length == 2 && cell.Split(':')[1].Trim() != string.Empty)
                        {
                            string[] parts = cell.Split(':');
                            _reportContainer.AddProperty(parts[0].Trim(), parts[1].Trim());
                            _inspected[row, col] = true;
                            continue;
                        }

                        //If the cell is empty
                        if (cell == string.Empty || cell == "0")
                        {
                            _inspected[row, col] = true;
                            continue;
                        }

                        //If the cell is part of a table
                        if (address.IsTableHeader())
                        {
                            CSVTable table = CSVTable.FindTable(row, col, CsvReport);
                            
                            if(table != null)
                            {
                                _reportContainer.AddTable(table);
                                foreach (ICSVAddress addr in table.Addresses)
                                {
                                    MarkInspected(addr);
                                }
                                continue;
                            }
                        }

                        //If the cell has a numeric value to the right
                        if (address.IsLeftLabel())
                        {
                            _reportContainer.AddProperty(cell, CsvReport[row, col + 1]);
                            _inspected[row, col] = true;
                            _inspected[row, col + 1] = true;
                            continue;
                        }

                        //If the cell has a numeric value beneath
                        if (address.IsTopLabel())
                        {
                            _reportContainer.AddProperty(cell, CsvReport[row + 1, col]);
                            _inspected[row, col] = true;
                            _inspected[row + 1, col] = true;
                            continue;
                        }

                        //If the cell property name and value is separated by a whitepace
                        if (cell.Split(' ').Length == 2)
                        {
                            string[] parts = cell.Split(' ');
                            _reportContainer.AddProperty(parts[0], parts[1]);
                            _inspected[row, col] = true;
                            continue;
                        }

                        //If the cell value is stand-alone
                        if (address.IsStandAlone())
                        {
                            _reportContainer.AddProperty(cell);
                            _inspected[row, col] = true;
                            continue;
                        }
                    }
                }
            }

            return _reportContainer;
        }

        private void MarkInspected(ICSVAddress address)
        {
            _inspected[address.Row, address.Column] = true;
        }

        private bool IsInspected(int row, int col)
        {
            return _inspected[row, col];
        }
    }
}
