using System;
using System.IO;
using OfficeOpenXml;

namespace BQCreator.BL.Models
{
    public class ExcelManager:IFileService
    {
        private string _filename;
        private ExcelModel _excelModel;

        public ExcelModel ExcelModel
        {
            get => _excelModel;
            set => _excelModel = value;
        }

        public ExcelManager(string filename)
        {
            
            _filename = filename;
        }


        
        public void Open()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using(var package = new ExcelPackage(new FileInfo(_filename)))
            {
                //get the first worksheet in the workbook
                _excelModel = new ExcelModel(package);
                //Console.WriteLine(package.Workbook.Worksheets[0].Dimension.End.Row);
                
            }
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }


    }
}