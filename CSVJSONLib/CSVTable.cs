using System;
using System.Collections.Generic;
using System.Linq;

namespace CSVJSONLib
{
    public class CSVTable : ICSVTable
    {
        public IEnumerable<CSVAddress> Addresses { get; private set; }

        private List<CSVAddress> _addresses;

        public static CSVTable FindTable(int row, int col, string[,] csvReport)
        {
            int startRow = row;
            int startCol = col;
            CSVTable table = new CSVTable();
            CSVAddress nextAddress = new CSVAddress(row, col);
            while (nextAddress.IsValid(csvReport) && table.IsBlank(nextAddress, csvReport))
            {
                CSVAddress address = nextAddress;
                table.AddAddress(address);
                nextAddress = new CSVAddress(row, ++col);
            }

            int columnDepth = table.GetLongestColumn(csvReport, (r, c, report) => { return report[r, c] != string.Empty; });
            int endColumn = startCol + columnDepth;

            int rowWidth = table.Addresses.Count();
            int endRow = startRow + rowWidth;
            row++;

            while (col < endColumn && row < endRow)
            {
                CSVAddress address = new CSVAddress(row, col);
                table.AddAddress(address);
                col++;
                if (col > endColumn)
                {
                    col = startCol;
                    row++;
                }
            }

            return table;
        }

        private int GetLongestColumn(string[,] csvReport, Func<int, int, string[,], bool> cellValidator)
        {
            int longestDepth = 0;

            foreach (CSVAddress address in Addresses)
            {
                int length = 0;
                CSVAddress nextAddress = new CSVAddress(address.Row, address.Column + 1);
                while (cellValidator(nextAddress.Row, nextAddress.Column, csvReport))
                {
                    length++;
                    nextAddress = new CSVAddress(nextAddress.Row, nextAddress.Column + 1);
                }
                longestDepth = longestDepth > length ? longestDepth : length;
            }
            return longestDepth;
        }

        private bool IsBlank(CSVAddress nextAddress, string[,] csvReport)
        {
            return csvReport[nextAddress.Row, nextAddress.Column] == string.Empty;
        }

        public CSVTable()
        {
            _addresses = new List<CSVAddress>();
        }

        internal void AddAddress(CSVAddress address)
        {
            _addresses.Add(address);
        }
    }
}