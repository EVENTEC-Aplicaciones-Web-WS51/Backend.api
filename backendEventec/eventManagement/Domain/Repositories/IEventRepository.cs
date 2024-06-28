using backendEventec.Shared.Domain.Repositories;
using BDEventecFinal.eventManagement.Domain.Model.Aggregates;

namespace backendEventec.eventManagement.Domain.Repositories;

public interface IEventRepository : IBaseRepository<Event>
{
    Task<IEnumerable<Event>> FindAllAsync();
    Task<Event?> FindByIdAsync(int idEvent);
    Task<Event?> FindByNameAsync(string nameEvent);
    Task<Event?> FindByTypeAsync(string type);
}