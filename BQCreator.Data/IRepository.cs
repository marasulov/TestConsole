namespace BQCreator.Data
{
    public interface IRepository
    {
        void Init();
        string GetRandomName();
        string GetRandomSurname();
        string GetRandomPatronymic();
        string GetRandomUniqLogin();
        string GetRandomEmailDomain();
    }
}