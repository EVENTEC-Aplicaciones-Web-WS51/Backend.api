using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Domain.Model.Commands;
using backendEventec.UserManagement.Domain.Repositories;
using backendEventec.UserManagement.Domain.Services;
using pcWeb2.Shared.Domain.Repositories;

namespace backendEventec.UserManagement.Application.Internal.CommandServices;

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