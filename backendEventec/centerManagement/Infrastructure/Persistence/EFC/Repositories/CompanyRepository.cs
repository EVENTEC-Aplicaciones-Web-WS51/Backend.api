using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.CenterManagement.Domain.Repositories;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backendEventec.CenterManagement.Infrastructure.Persistence.EFC.Repositories;

public class CompanyRepository: BaseRepository<Company>, ICompanyRepository
{
    public CompanyRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Company>> FindAllAsync()
    {
        return await Context.Set<Company>().ToListAsync();
    }

    public async Task<Company?> FindByIdAsync(int id)
    {
        return await Context.Set<Company>().FindAsync(id);
    }

    public async Task<IEnumerable<Company>> FindByPlaceIdAsync(int idPlace)
    {
        return await Context.Set<Company>().Where(c=>c.IdPlace== idPlace).ToListAsync();
    }
}