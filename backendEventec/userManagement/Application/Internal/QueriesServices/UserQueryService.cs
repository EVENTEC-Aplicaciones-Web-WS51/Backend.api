using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Domain.Model.Queries;
using backendEventec.UserManagement.Domain.Repositories;
using backendEventec.UserManagement.Domain.Services;

namespace backendEventec.UserManagement.Application.Internal.QueriesServices;

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

    public async Task<IEnumerable<User>> Handle(GetUserByWalletIdQuery query)
    {
        return await userRepository.FindByWalletIdAsync(query.IdWallet);
    }
}