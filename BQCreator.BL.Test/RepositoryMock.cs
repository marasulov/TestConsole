using BQCreator.Data;

namespace BQCreator.BL.Test
{
    public class RepositoryMock:IRepository
    {
        public void Init()
        {
            
        }

        public string GetRandomName()
        {
            return "as";
        }

        public string GetRandomSurname()
        {
            return "Иванов";
        }

        public string GetRandomPatronymic()
        {
            return "Иванович";
        }

        public string GetRandomUniqLogin()
        {
            return "ivan";
        }

        public string GetRandomEmailDomain()
        {
            return "ivan.ru";
        }
    }
}