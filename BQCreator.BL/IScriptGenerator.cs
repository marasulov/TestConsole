using BQCreator.Data;

namespace BQCreator.BL
{
    public interface IScriptGenerator
    {
        UserEntity GenerateUser();
        string GetValueLine(UserEntity entity);
        string GetInsertLine();
        string CreateScript(int entityCount);
    }
}