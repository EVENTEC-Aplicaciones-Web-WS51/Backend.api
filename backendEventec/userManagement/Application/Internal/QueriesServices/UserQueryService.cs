using backendEventec.userManagement.Domain.Repositories;
using BDEventecFinal.userManagement.Domain.Model.Aggregates;
using BDEventecFinal.userManagement.Domain.Model.Queries;
using BDEventecFinal.userManagement.Domain.Services;

namespace backendEventec.userManagement.Application.Internal.QueriesServices;

public class UserQueryService(IUserRepository userRepository): IUserQueryService
{
    public async Task<IEnumerable<User>> Handle(GetAllUserQuery query)
    {
        return await userRepository.FindAllAsync();
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }
    public async Task<User?> Handle(GetUserByEmailQuery query)
    {
        return await userRepository.FindByEmailAsync(query.Email);
    }
}