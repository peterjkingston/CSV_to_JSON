using System;
using System.Collections.Generic;
using System.Linq;

namespace CSVJSONLib
{
    public class CSVTable : ICSVTable
    {
        public IEnumerable<ICSVAddress> Addresses 
        {
            get { return _addresses; }
        }

        public IEnumerable<string> Headers
        {
            get { return _headers; }
        }

        public IEnumerable<IEnumerable<string>> Records
        {
            get { return _records; }
        }

        private List<ICSVAddress> _addresses = new List<ICSVAddress>();
        private List<string> _headers = new List<string>();
        private List<string[]> _records = new List<string[]>();

        public static CSVTable FindTable(int row, int col, string[,] csvReport)
        {

            CSVTable table = new CSVTable();
            ICSVAddress topLeftAddess = GoToTopLeftAddress(row, col, csvReport);
            ICSVAddress nextAddress = topLeftAddess;
            while (nextAddress.IsValid() && !nextAddress.IsBlank())
            {
                ICSVAddress address = nextAddress;
                table.AddAddress(address);

                //Add the header while you're at it
                table.AddHeader(address.Value);
              
                nextAddress = new CSVAddress(address.Row, address.Column + 1, csvReport);
            }

            //int columnDepth = table.GetLongestColumn(csvReport, (r, c, report) => { return report[r, c] != string.Empty; });
            int endColumns = GetTopRightAddress(row,col,csvReport).Column + 1;

            int rowWidth = table.Addresses.Count(); //The current count of the addresses is only the header width: g2g
            int endRows = topLeftAddess.Row + table.GetRowCount(topLeftAddess, csvReport, (a)=> { return a.IsValid() && !a.IsBlank() && !a.IsZero(); });

            int currentCol = topLeftAddess.Column;
            int currentRow = topLeftAddess.Row + 1;

            List<string> record = new List<string>();
            while (currentRow < endRows)
            {
                CSVAddress address = new CSVAddress(currentRow, currentCol, csvReport);
                table.AddAddress(address);
                record.Add(address.Value);
                currentCol++;
                if (currentCol >= endColumns)
                {
                    string[] tuple = record.ToArray();
                    if (!tuple.OnlyContains(new string[] { string.Empty, "0"}))
                    {
                        table.AddRecord(record.ToArray());
                        record = new List<string>();
                        currentCol = topLeftAddess.Column;
                        currentRow++;
                    }
                    else break;
                }
            }
            if(table.Headers.Count() < 3 || table.Records.Count() < 1)
            {
                return null;
            }

            return table;
        }

        private void AddRecord(string[] record)
        {
            _records.Add(record);
        }

        private static ICSVAddress GetTopRightAddress(int row, int col, string[,] csvReport)
        {
            ICSVAddress topRow = FindAddress
                (
                    new CSVAddress(row, col, csvReport),
                    (a) => { return a.IsValid() && !a.IsBlank(); },
                    (a) => { return new CSVAddress(a.Row -1, a.Column, a.Plane); }
                );  

            ICSVAddress topRight = FindAddress
                (
                    topRow,
                    (a) => { return a.IsValid() && !a.IsBlank(); },
                    (a) => { return new CSVAddress(a.Row, a.Column + 1, a.Plane); }
                );

            return topRight;
        }

        private static ICSVAddress FindAddress(ICSVAddress address, Func<ICSVAddress, bool> validator, Func<ICSVAddress, ICSVAddress> mover)
        {
            ICSVAddress nextCursor = address;

            while (validator(nextCursor))
            {
                address = nextCursor;
                nextCursor = mover(address);
            }

            return address;
        }

        //private static ICSVAddress ToTableRightCol(ICSVAddress address)
        //{
        //    ICSVAddress nextCursor = address;
        //    int r = address.Row;
        //    int c = address.Column;

        //    while (nextCursor.IsValid() && !nextCursor.IsBlank())
        //    {
        //        address = nextCursor;
        //        nextCursor = new CSVAddress(r, ++c, address.Plane);
        //    }

        //    return address;
        //}

        //private static ICSVAddress ToTableTopRow(ICSVAddress address)
        //{
        //    ICSVAddress nextCursor = address;
        //    int r = address.Row;
        //    int c = address.Column;

        //    while (nextCursor.IsValid() && !nextCursor.IsBlank())
        //    {
        //        address = nextCursor;
        //        nextCursor = new CSVAddress(--r, c,address.Plane);
        //    }

        //    return address;
        //}

        private static ICSVAddress GoToTopLeftAddress(int row, int col, string[,] csvReport)
        {
            ICSVAddress topRow = FindAddress
                (
                    new CSVAddress(row, col, csvReport),
                    (a) => { return a.IsValid() && !a.IsBlank(); },
                    (a) => { return new CSVAddress(a.Row - 1, a.Column, a.Plane); }
                );

            ICSVAddress topLeft = FindAddress
                (
                    topRow,
                    (a) => { return a.IsValid() && !a.IsBlank(); },
                    (a) => { return new CSVAddress(a.Row, a.Column - 1, a.Plane); }
                );

            return topLeft;
        }

        //private static ICSVAddress ToTableLeftCol(ICSVAddress address)
        //{
        //    ICSVAddress nextCursor = address;
        //    int r = address.Row;
        //    int c = address.Column;

        //    while (nextCursor.IsValid() && !nextCursor.IsBlank())
        //    {
        //        address = nextCursor;
        //        nextCursor = new CSVAddress(r, --c, address.Plane);
        //    }

        //    return address;
        //}

        private void AddHeader(string value)
        {
            _headers.Add(value);
        }

        private int GetLongestColumn(string[,] csvReport, Func<int, int, string[,], bool> cellValidator)
        {
            int longestDepth = 0;

            foreach (ICSVAddress address in _addresses)
            {
                int length = 0;
                ICSVAddress nextAddress = new CSVAddress(address.Row, address.Column + 1, csvReport);
                while (cellValidator(nextAddress.Row, nextAddress.Column, csvReport))
                {
                    length++;
                    nextAddress = new CSVAddress(nextAddress.Row, nextAddress.Column + 1, csvReport);
                }
                longestDepth = longestDepth > length ? longestDepth : length;
            }
            return longestDepth;
        }

        private int GetRowCount(ICSVAddress topLeftCorner, string[,] csvReport, Func<ICSVAddress, bool> cellValidator)
        {
            List<int> lengths = new List<int>();
            ICSVAddress checkAddr = new CSVAddress(topLeftCorner.Row, topLeftCorner.Column, csvReport);
            for (int columnIndex = topLeftCorner.Column; cellValidator(checkAddr); columnIndex++)
            {
                int length = 0;
                ICSVAddress nextAddress = new CSVAddress(checkAddr.Row, checkAddr.Column, csvReport);
                while (cellValidator(nextAddress))
                {
                    length++;
                    nextAddress = new CSVAddress(nextAddress.Row + 1, nextAddress.Column, csvReport);
                }
                lengths.Add(length);
                checkAddr = new CSVAddress(topLeftCorner.Row, columnIndex, csvReport);
            }
            return lengths.Count > 0 ? lengths.Max() : 0;
        }

        private void AddAddress(ICSVAddress address)
        {
            _addresses.Add(address);
        }
    }
}