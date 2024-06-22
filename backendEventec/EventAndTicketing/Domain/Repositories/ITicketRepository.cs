using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.Shared.Domain.Repositories;

namespace backendEventec.EventAndTicketing.Domain.Repositories;

public interface ITicketRepository : IBaseRepository<Ticket>
{
    Task<IEnumerable<Ticket>> FindByAllEventAsync();
    Task<Ticket?> FindByTicketsIdAsync(int id);
    Task<IEnumerable<Ticket>> FindByEventsAsync(int idEvent); 
    
}