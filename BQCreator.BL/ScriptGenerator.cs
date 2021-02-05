using System;
using BQCreator.Data;

namespace BQCreator.BL
{
    public class ScriptGenerator:IScriptGenerator
    {
        private readonly IRepository _repository;
        private Random _random = new Random();
        public ScriptGenerator(IRepository repository)
        {
            _repository = repository;
        }

        public UserEntity GenerateUser()
        {
            
            UserEntity entity = new UserEntity();

            entity.Login = _repository.GetRandomUniqLogin();
            entity.Name = _repository.GetRandomName();
            entity.Surname = _repository.GetRandomSurname();
            entity.Patronymic = _repository.GetRandomPatronymic();

            string randomEmailDomain = _repository.GetRandomEmailDomain();
            entity.Email = string.Format("{0}@{1}", entity.Login, entity.Email);
            entity.Password = _random.Next(1000, 10000).ToString();

            int year = _random.Next(2010, 2017);
            int month = _random.Next(1, 13);
            int day = _random.Next(1, 29);

            if (year == 2016 && month > 2) month = 2;
            entity.RegistrationDate = new DateTime(year,month, day);

            return entity;
        }

        public string GetValueLine(UserEntity entity)
        {
            string regisrationDate = entity.RegistrationDate.ToString("yyyyMMdd");
            string result =
                string.Format(
                    $"VALUES('{entity.Name}','{entity.Surname}','{entity.Patronymic}','{entity.Email}','{entity.Login}'," +
                    $"'{entity.Password}','{regisrationDate}')");
            
            return result;
        }

        public string GetInsertLine()
        {
            return @"INSERT INTO BlogUser (Name,Surname, Patronomyc, Email)";
        }

        public string CreateScript(int entityCount)
        {
            throw new System.NotImplementedException();
        }
    }
}