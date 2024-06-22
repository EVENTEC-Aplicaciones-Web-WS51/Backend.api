using backendEventec.EventAndTicketing.Domain.Model.Aggregates;
using backendEventec.EventAndTicketing.Domain.Repositories;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backendEventec.EventAndTicketing.Infraestructure.Persistence.EFC.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Event>> FindByAllEventAsync()
    {
        return await Context.Set<Event>().ToListAsync();
    }

    public async Task<Event?> FindByEventIdAsync(int id) 
    {
        return await Context.Set<Event>().FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<Event>> FindByHeadquartersAsync(int headquartersId)
    {
        return await Context.Set<Event>().Where(f => f.IdHeadquarters == headquartersId).ToListAsync();
    }

    public async Task<IEnumerable<Event>> FindByOrganizerIdAsync(int organizerId)
    {
        return await Context.Set<Event>().Where(f => f.IdOrganizer == organizerId).ToListAsync();
    }
}