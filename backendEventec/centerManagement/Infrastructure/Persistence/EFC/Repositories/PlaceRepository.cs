using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.CenterManagement.Domain.Repositories;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backendEventec.CenterManagement.Infrastructure.Persistence.EFC.Repositories;

public class PlaceRepository : BaseRepository<Place>, IPlaceRepository
{
    public PlaceRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Place>> FindAllAsync()
    {
        return await Context.Set<Place>().ToListAsync();
    }

    public async Task<Place?> FindByIdAsync(int id)
    {
        return await Context.Set<Place>().FindAsync(id);
    }
}