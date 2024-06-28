using backendEventec.eventManagement.Domain.Repositories;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using BDEventecFinal.eventManagement.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace backendEventec.eventManagement.Infrastructure.Persistence.EFC.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Event>> FindAllAsync()
    {
        return await Context.Set<Event>().ToListAsync();
    }

    public async Task<Event?> FindByIdAsync(int IdEvent)
    {
        return await Context.Set<Event>().FindAsync(IdEvent);
    }

    public async Task<Event?> FindByNameAsync(string nameEvent)
    {
        return await Context.Set<Event>().FirstOrDefaultAsync(e => e.NameEvent == nameEvent);
    }
    public async Task<Event?> FindByTypeAsync(string type)
    {
        return await Context.Set<Event>().FirstOrDefaultAsync(e => e.Type == type);
    }
    
}