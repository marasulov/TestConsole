using System;
using BQCreator.Data;
using NUnit.Framework;

namespace BQCreator.BL.Test
{
    [TestFixture]
    public class ScriptGeneratorTest
    {
        private IScriptGenerator _generator;

        [SetUp]
        public void Init()
        {
            IRepository repository = new RepositoryMock();
            _generator = new ScriptGenerator(repository);
        }
        
        [Test]
        public void GenerateUser_NameRequired()
        {
            UserEntity entity = _generator.GenerateUser();
            string name = entity.Name;
            Assert.That(name,Is.Not.Empty);
        }
        
        [Test]
        public void GenerateUser_SurnameRequired()
        {
            UserEntity entity = _generator.GenerateUser();
            string surname = entity.Surname;
            Assert.That(surname,Is.Not.Empty);
        }
        
        [Test]
        [Repeat(1000)]
        public void GenerateUser_PasswordRequired()
        {
            UserEntity entity = _generator.GenerateUser();
            string password = entity.Password;
            Assert.That(password,Is.Not.Empty);
        }
        
        [Test]
        
        public void GenerateUser_EmailRequired()
        {
            UserEntity entity = _generator.GenerateUser();
            string email = entity.Email;
            Assert.That(email,Is.Not.Empty);
        }
        
        [Test]
        [Repeat(10000)]
        public void GenerateUser_RegistrationDatePeriod()
        {
            UserEntity entity = _generator.GenerateUser();
            DateTime registrationDate = entity.RegistrationDate;
            Assert.That(registrationDate,Is.InRange(new DateTime(2010,1,1),new DateTime(2016,2,29) ));
        }
        
        [Test]
        public void GenerateUser_GetValueLine()
        {
            UserEntity user = new UserEntity()
            {
                Name = "Петр",
                Surname = "Петров",
                Patronymic = "Петрович",
                Email = "petr@dd.dd",
                Login = "petr",
                Password = "Петр",
                RegistrationDate = new DateTime(2016, 1, 1)
            };
            const string EXPECTED_RESULT = @"VALUES('Петр','Петров','Петрович','petr@dd.dd','petr','Петр','20160101')";
            string result = _generator.GetValueLine(user);
            Assert.That(result,Is.EqualTo(EXPECTED_RESULT));
        }
        
        [Test]
        public void GenerateUser_GetInsertLine()
        {
            const string EXPECTED_RESULT = @"INSERT INTO BlogUser (Name,Surname, Patronomyc, Email)";
            string result = _generator.GetInsertLine();
            Assert.That(result,Is.EqualTo(EXPECTED_RESULT));
        }
    }
}