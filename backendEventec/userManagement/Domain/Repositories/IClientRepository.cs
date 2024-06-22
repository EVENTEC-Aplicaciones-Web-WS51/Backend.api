using backendEventec.UserManagement.Domain.Model.Aggregates;
using pcWeb2.Shared.Domain.Repositories;

namespace backendEventec.UserManagement.Domain.Repositories;

public interface IClientRepository : IBaseRepository<Client>
{
    Task<IEnumerable<Client>> FindAllAsync();
    Task<Client?> FindByIdAsync(int id);
    Task<IEnumerable<Client>> FindByUserIdAsync(int userId);
}