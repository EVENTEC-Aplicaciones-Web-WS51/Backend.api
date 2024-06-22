using backendEventec.UserManagement.Domain.Model.Aggregates;
using pcWeb2.Shared.Domain.Repositories;

namespace backendEventec.UserManagement.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<IEnumerable<User>> FindAllAsync();
    Task<User?> FindByIdAsync(int id);
    Task<IEnumerable<User>> FindByWalletIdAsync(int idWallet);
}