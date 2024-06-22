using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.EventAndTicketing.Domain.Repositories;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backendEventec.EventAndTicketing.Infraestructure.Persistence.EFC.Repositories;

public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
{
    public TicketRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Ticket>> FindByAllEventAsync()
    {
        return await Context.Set<Ticket>().ToListAsync();
    }

    public async Task<Ticket?> FindByTicketsIdAsync(int id)
    {
        return await Context.Set<Ticket>().FindAsync(id);
    }

    public async Task<IEnumerable<Ticket>> FindByEventsAsync(int idEvent)
    {
        return await Context.Set<Ticket>().Where(t => t.EventId == idEvent).ToListAsync();
    }
}