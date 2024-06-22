using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.CenterManagement.Domain.Repositories;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backendEventec.CenterManagement.Infrastructure.Persistence.EFC.Repositories;

public class HeadquartersRepository: BaseRepository<Headquarters>, IHeadquartersRepository
{
    public HeadquartersRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Headquarters>> FindAllAsync()
    {
        return await Context.Set<Headquarters>().ToListAsync();
    }

    public async Task<Headquarters?> FindByIdAsync(int id)
    {
        return await Context.Set<Headquarters>().FindAsync(id);
    }

    public async Task<IEnumerable<Headquarters>> FindByPlaceIdAsync(int idPlace)
    {
        return await Context.Set<Headquarters>().Where(h=>h.IdPlace== idPlace).ToListAsync();
    }
}