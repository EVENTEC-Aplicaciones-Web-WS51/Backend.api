namespace BDEventecFinal.IAM.Interfaces.ACL;

public interface IIamContextFacade
{
    Task<int> CreateUserIam(string username, string password);
    Task<int> FetchUserIamIdByUsername(string username);
    Task<string> FetchUsernameByUserIamId(int userId);
}