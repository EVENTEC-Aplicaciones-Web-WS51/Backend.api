using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.Shared.Domain.Repositories;

namespace backendEventec.CenterManagement.Domain.Repositories;

public interface ICompanyRepository : IBaseRepository<Company>
{
    Task<IEnumerable<Company>> FindAllAsync();
    Task<Company?> FindByIdAsync(int id);
    Task<IEnumerable<Company>> FindByPlaceIdAsync(int idPlace);
}