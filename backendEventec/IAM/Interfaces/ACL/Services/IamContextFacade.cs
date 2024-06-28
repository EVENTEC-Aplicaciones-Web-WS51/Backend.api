using BDEventecFinal.IAM.Domain.Model.Commands;
using BDEventecFinal.IAM.Domain.Model.Queries;
using BDEventecFinal.IAM.Domain.Services;

namespace BDEventecFinal.IAM.Interfaces.ACL.Services;

public class IamContextFacade(IUserIamCommandService userIamCommandService, IUserIamQueryService userIamQueryService) : IIamContextFacade
{
    public async Task<int> CreateUserIam(string username, string password)
    {
        var signUpCommand = new SignUpCommand(username, password);
        await userIamCommandService.Handle(signUpCommand);
        var getUserByUsernameQuery = new GetUserIamByUsernameQuery(username);
        var result = await userIamQueryService.Handle(getUserByUsernameQuery);
        return result?.IdIam ?? 0;
    }

    public async Task<int> FetchUserIamIdByUsername(string username)
    {
        var getUserByUsernameQuery = new GetUserIamByUsernameQuery(username);
        var result = await userIamQueryService.Handle(getUserByUsernameQuery);
        return result?.IdIam ?? 0;
    }

    public async Task<string> FetchUsernameByUserIamId(int userId)
    {
        var getUserByIdQuery = new GetUserIamByIdQuery(userId);
        var result = await userIamQueryService.Handle(getUserByIdQuery);
        return result?.Username ?? string.Empty;
    }
}