using System.Linq;
using OfficeOpenXml;

namespace BQCreator.BL.Models
{
    public class ExcelModel
    {
        private ExcelWorksheet _worksheet;
        private int _startRow;
        private int _endRow;

        public ExcelWorksheet Worksheet
        {
            get { return _worksheet; }
            set { _worksheet = value; }
        }
        
        public int StartRow { get; } 
        public int EndRow { get; set; } 

        public ExcelModel(ExcelPackage package)
        {
            _worksheet = package.Workbook.Worksheets["Temp"];
            //GetSheetEndRow();
            _endRow= GetLastUsedRow();
        }

        public int GetLastUsedRow() {
            if (_worksheet.Dimension == null) {  return 0; } // In case of a blank sheet
            var row = _worksheet.Dimension.End.Row;
            while(row >= 1) {
                var range = _worksheet.Cells[row, 1, row, _worksheet.Dimension.End.Column];
                if(range.Any(c => !string.IsNullOrEmpty(c.Text))) {
                    break;
                }
                row--;
            }
            return row;
        }
    }
}