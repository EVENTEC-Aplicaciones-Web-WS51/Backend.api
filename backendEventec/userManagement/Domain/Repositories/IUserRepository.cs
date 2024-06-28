using backendEventec.Shared.Domain.Repositories;
using BDEventecFinal.userManagement.Domain.Model.Aggregates;

namespace backendEventec.userManagement.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<IEnumerable<User>> FindAllAsync();
    Task<User?> FindByIdAsync(int id);
    Task<User?> FindByEmailAsync(string email);
    
}