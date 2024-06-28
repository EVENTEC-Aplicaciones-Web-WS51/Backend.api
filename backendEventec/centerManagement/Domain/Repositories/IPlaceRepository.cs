using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.Shared.Domain.Repositories;

namespace backendEventec.CenterManagement.Domain.Repositories;

public interface IPlaceRepository : IBaseRepository<Place>
{
    Task<IEnumerable<Place>> FindAllAsync();
    Task<Place?> FindByIdAsync(int id);
}