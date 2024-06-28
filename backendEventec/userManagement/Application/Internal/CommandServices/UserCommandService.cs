using backendEventec.Shared.Domain.Repositories;
using backendEventec.userManagement.Domain.Repositories;
using BDEventecFinal.userManagement.Domain.Model.Aggregates;
using BDEventecFinal.userManagement.Domain.Model.Commands;
using BDEventecFinal.userManagement.Domain.Services;

namespace backendEventec.userManagement.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository,IUnitOfWork unitOfWork): IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        var user = new User(command);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return user;
    }
}