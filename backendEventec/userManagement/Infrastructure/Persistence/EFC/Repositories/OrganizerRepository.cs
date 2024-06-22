using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;
using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backendEventec.UserManagement.Infrastructure.Persistence.EFC.Repositories;

public class OrganizerRepository : BaseRepository<Organizer>, IOrganizerRepository
{
    public OrganizerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Organizer>> FindAllAsync()
    {
        return await Context.Set<Organizer>().ToListAsync();
    }

    public async Task<Organizer?> FindByIdAsync(int id)
    {
        return await Context.Set<Organizer>().FindAsync(id);
    }

    public async Task<IEnumerable<Organizer>> FindByUserIdAsync(int userId)
    {
        return await Context.Set<Organizer>().Where(o => o.UserId == userId).ToListAsync();
    }

    public async Task<IEnumerable<Organizer>> FindByCompanyNameAsync(string companyName)
    {
        return await Context.Set<Organizer>().Where(o => o.CompanyName == companyName).ToListAsync();
    }
}