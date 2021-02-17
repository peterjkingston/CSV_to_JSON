using System;
using System.Collections.Generic;

namespace CSVJSONLib
{
    public struct CSVAddress : ICSVAddress
    {
        public CSVAddress(int row, int col) : this()
        {
            Row = row;
            Column = col;
        }

        public int Column { get; internal set; }
        public int Row { get; internal set; }

        public bool IsStandAlone(string[,] csvReport)
        {
            bool isntLeftLabel = !IsLeftLabel(csvReport);
            bool isntTableHeader = !IsTableHeader(csvReport);
            bool isntTopLabel = !IsTopLabel(csvReport);
            bool doesntContainLabel = !ContainsLabel(csvReport);

            return isntLeftLabel &&
                   isntTableHeader &&
                   isntTopLabel &&
                   doesntContainLabel;
        }

        public bool ContainsLabel(string[,] csvReport)
        {
            return csvReport[this.Row, this.Column].Contains(":");
        }

        public bool IsTopLabel(string[,] csvReport)
        {
            bool isntBottomRow = csvReport.GetUpperBound(0) > this.Row;
            bool hasValueBelow = false;
            if (isntBottomRow) 
            { 
                hasValueBelow = csvReport[this.Row + 1, this.Column] != string.Empty; 
            }

            return hasValueBelow;
        }

        public bool IsValid(string[,] csvReport)
        {
            bool withinHeight = this.Row < csvReport.GetLength(0) &&
                                        this.Row >= 0;
            bool withinWidth = this.Column < csvReport.GetLength(1) &&
                                       this.Column >= 0;
            return withinHeight && withinWidth;  
        }

        public bool IsLeftLabel(string[,] csvReport)
        {
            
            bool isLeftofRightBoundary = csvReport.GetLength(1) > this.Column + 1;
            bool hasValueToRight = false;
            if (csvReport.GetLength(1) != this.Column+1)
            {
                hasValueToRight = csvReport[this.Row, this.Column + 1] != string.Empty;
            }

            return isLeftofRightBoundary &&
                    hasValueToRight; 
        }

        public bool IsTableHeader(string[,] csvReport)
        {
            
            bool tableHasAtLeastOneDataRow = false;
            bool reportHasAtLeastThreeMoreColumns = csvReport.GetLength(1) > this.Column + 2;
            int tableWidth = GetTableWidth(csvReport);
            bool tableHasAtLeastThreeColumns = tableWidth >=3;

            if (tableHasAtLeastThreeColumns)
            {         
                int tableHeight = GetTableHeight(csvReport);
                tableHasAtLeastOneDataRow = GetDataRows(csvReport,tableWidth,tableHeight) != null;
            }
            
            return tableHasAtLeastThreeColumns &&
                   tableHasAtLeastOneDataRow;
        }

        private int GetTableHeight(string[,] csvReport)
        {
            int maxHeight = 0;
            int tableWidth = GetTableWidth(csvReport);
            int tableLeftCol = GetTableLeftBound(csvReport);
            int tableRightCol = tableLeftCol + tableWidth;
            
            for(int tableCol = tableLeftCol; tableCol < tableRightCol; tableCol++)
            {
                int tableRow = 0;
                int reportHeight = csvReport.GetLength(0);
                Func<int, bool> nextDoesNotExceedReport = (nextRow) => { return nextRow < reportHeight; };
                Func<int, int, bool> nextIsNotEmpty = (nextRow, column) => { return csvReport[nextRow, column] != string.Empty; };

                while (nextDoesNotExceedReport(this.Row + tableRow + 1) && 
                       nextIsNotEmpty(this.Row + tableRow + 1, tableCol))
                {
                    tableRow++;
                }
                maxHeight = maxHeight > tableRow ? maxHeight : tableRow;
            }
            return maxHeight;
        }

        private int GetTableLeftBound(string[,] csvReport)
        {
            int currentCol = this.Column;
            while (currentCol > -1 && csvReport[this.Row,currentCol].Trim() != string.Empty)
            {
                currentCol--;
            }
            return currentCol + 1;
        }

        private string[,] GetDataRows(string[,] csvReport, int tableWidth, int tableHeight)
        {
            List<string[]> records = new List<string[]>();
            int tableLeftCol = GetTableLeftBound(csvReport);
            int tableRightCol = tableLeftCol + tableWidth;

            for (int tableRow = 0; tableRow < tableHeight; tableRow++)
            {
                string[] record = new string[tableWidth];
                int index = 0;
                for (int tableCol = tableLeftCol; tableCol < tableRightCol; tableCol++)
                {
                    record[index++] = csvReport[this.Row + tableRow, tableCol];
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

        private int GetTableWidth(string[,] csvReport)
        {
            int leftLimit = this.Column;
            while (leftLimit != 0 && csvReport[this.Row, leftLimit - 1] != string.Empty)
            {
                leftLimit--;
            }

            int rightBoundry = csvReport.GetUpperBound(1);
            int rightLimit = this.Column;
            while (rightLimit != rightBoundry && csvReport[this.Row, rightLimit + 1] != string.Empty)
            {
                rightLimit++;
            }
            return rightLimit - leftLimit + 1;
        }
    }
}