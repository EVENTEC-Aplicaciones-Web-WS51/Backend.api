using backendEventec.Shared.Domain.Repositories;
using backendEventec.UserManagement.Domain.Model.Aggregates;

namespace backendEventec.UserManagement.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<IEnumerable<User>> FindAllAsync();
    Task<User?> FindByIdAsync(int id);
    Task<IEnumerable<User>> FindByWalletIdAsync(int idWallet);
}