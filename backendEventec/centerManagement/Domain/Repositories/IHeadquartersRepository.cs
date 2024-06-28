using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.Shared.Domain.Repositories;

namespace backendEventec.CenterManagement.Domain.Repositories;

public interface IHeadquartersRepository : IBaseRepository<Headquarters>
{
    Task<IEnumerable<Headquarters>> FindAllAsync();
    Task<Headquarters?> FindByIdAsync(int id);
    Task<IEnumerable<Headquarters>> FindByPlaceIdAsync(int idPlace);
}