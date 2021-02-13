using System.IO;
using BQCreator.BL.Models;
using BQCreator.Data;

namespace BQCreator.BL
{
    public class FileManager:IFileManager
    {
        private readonly IFileService _fileService;
        private readonly IRepository _repository;
        
        private string fileName;
        private string fileType;
        
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
            }
        }

        public FileManager(IFileService fileService)
        {
            _fileService = fileService;
            
        }

        public void Open()
        {
            _fileService.Open();
        }

        public void Save()
        {
            _fileService.Save();
        }


        public void CreateModel()
        {
            throw new System.NotImplementedException();
        }

        public FileModel GenEntity()
        {
            FileModel model = new FileModel();
            return model;
        }
    }

    public interface IFileManager
    {
        void CreateModel();
        FileModel GenEntity();
    }
}