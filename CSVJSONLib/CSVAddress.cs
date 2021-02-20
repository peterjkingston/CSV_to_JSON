using System;
using System.Collections.Generic;

namespace CSVJSONLib
{
    public struct CSVAddress : ICSVAddress
    {
        string[,] _csvReport;

        public CSVAddress(int row, int col, string[,] csvReport) : this()
        {
            Row = row;
            Column = col;
            _csvReport = csvReport;
        }

        public int Column { get; internal set; }
        public int Row { get; internal set; }

        public string Value 
        {
            get { return this.IsValid()?_csvReport[Row, Column]:string.Empty; }
        }

        public string[,] Plane
        {
            get { return _csvReport; }
        }

        public bool IsStandAlone()
        {
            bool isntLeftLabel = !IsLeftLabel();
            bool isntTableHeader = !IsTableHeader();
            bool isntTopLabel = !IsTopLabel();
            bool doesntContainLabel = !ContainsLabel();

            return isntLeftLabel &&
                   isntTableHeader &&
                   isntTopLabel &&
                   doesntContainLabel;
        }

        public bool ContainsLabel()
        {
            return _csvReport[this.Row, this.Column].Contains(":");
        }

        public bool IsTopLabel()
        {
            bool isntBottomRow = _csvReport.GetUpperBound(0) > this.Row;
            bool hasValueBelow = false;
            if (isntBottomRow) 
            { 
                hasValueBelow = _csvReport[this.Row + 1, this.Column] != string.Empty; 
            }

            return hasValueBelow;
        }

        public bool IsValid()
        {
            bool withinHeight = this.Row < _csvReport.GetLength(0) &&
                                        this.Row >= 0;
            bool withinWidth = this.Column < _csvReport.GetLength(1) &&
                                       this.Column >= 0;
            return withinHeight && withinWidth;  
        }

        public bool IsLeftLabel()
        {
            
            bool isLeftofRightBoundary = _csvReport.GetLength(1) > this.Column + 1;
            bool hasValueToRight = false;
            if (_csvReport.GetLength(1) != this.Column+1)
            {
                hasValueToRight = _csvReport[this.Row, this.Column + 1] != string.Empty;
            }

            return isLeftofRightBoundary &&
                    hasValueToRight; 
        }

        public bool IsTableHeader()
        {
            
            bool tableHasAtLeastOneDataRow = false;
            bool reportHasAtLeastThreeMoreColumns = _csvReport.GetLength(1) > this.Column + 2;
            int tableWidth = GetTableWidth();
            bool tableHasAtLeastThreeColumns = tableWidth >=3;

            if (tableHasAtLeastThreeColumns)
            {         
                int tableHeight = GetTableHeight();
                tableHasAtLeastOneDataRow = GetDataRows(tableWidth,tableHeight) != null;
            }
            
            return tableHasAtLeastThreeColumns &&
                   tableHasAtLeastOneDataRow;
        }

        private int GetTableHeight()
        {
            int maxHeight = 0;
            int tableWidth = GetTableWidth();
            int tableLeftCol = GetTableLeftBound();
            int tableRightCol = tableLeftCol + tableWidth;
            
            for(int tableCol = tableLeftCol; tableCol < tableRightCol; tableCol++)
            {
                int tableRow = 0;
                int reportHeight = _csvReport.GetLength(0);
                Func<CSVAddress, bool> nextDoesNotExceedReport = (address) => { return address.IsValid(); };
                Func<CSVAddress, bool> nextIsNotEmpty = (address) => { return !address.IsBlank(); };

                while (nextDoesNotExceedReport(new CSVAddress(this.Row + tableRow + 1, this.Column, _csvReport)) && 
                       nextIsNotEmpty(new CSVAddress(this.Row + tableRow + 1, this.Column, _csvReport)))
                {
                    tableRow++;
                }
                maxHeight = maxHeight > tableRow ? maxHeight : tableRow;
            }
            return maxHeight;
        }

        private int GetTableLeftBound()
        {
            int currentCol = this.Column;
            while (currentCol > -1 && _csvReport[this.Row,currentCol].Trim() != string.Empty)
            {
                currentCol--;
            }
            return currentCol + 1;
        }

        private string[,] GetDataRows(int tableWidth, int tableHeight)
        {
            List<string[]> records = new List<string[]>();
            int tableLeftCol = GetTableLeftBound();
            int tableRightCol = tableLeftCol + tableWidth;

            for (int tableRow = 0; tableRow < tableHeight; tableRow++)
            {
                string[] record = new string[tableWidth];
                int index = 0;
                for (int tableCol = tableLeftCol; tableCol < tableRightCol; tableCol++)
                {
                    record[index++] = _csvReport[this.Row + tableRow, tableCol];
                }
                bool isEmpty = true;
                foreach (string val in record)
                {
                    if(val != string.Empty && val != "0")
                    {
                        isEmpty = false;
                        break;
                    }
                }
                if (!isEmpty) { records.Add(record); }
            }
            return records.ToArray().To2DArray(tableWidth);
        }

        private int GetTableWidth()
        {
            int leftLimit = this.Column;
            while (leftLimit != 0 && _csvReport[this.Row, leftLimit - 1] != string.Empty)
            {
                leftLimit--;
            }

            int rightBoundry = _csvReport.GetUpperBound(1);
            int rightLimit = this.Column;
            while (rightLimit != rightBoundry && _csvReport[this.Row, rightLimit + 1] != string.Empty)
            {
                rightLimit++;
            }
            return rightLimit - leftLimit + 1;
        }

        public bool IsBlank()
        {
            return _csvReport[Row, Column].Trim() == string.Empty;
        }

        public bool IsZero()
        {
            int val;
            if(int.TryParse(Value, out val))
            {
                return val == 0;
            }
            else
            {
                return false;
            }
        }
    }
}