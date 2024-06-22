using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.Shared.Domain.Repositories;

namespace backendEventec.EventAndTicketing.Domain.Repositories;

public interface IEventRepository : IBaseRepository<Event>
{
    Task<IEnumerable<Event>> FindByAllEventAsync();
    Task<Event?> FindByEventIdAsync(int id);
    Task<IEnumerable<Event>> FindByHeadquartersAsync(int idHeadquarters); 
    Task<IEnumerable<Event>> FindByOrganizerIdAsync(int idOrganizer);
}