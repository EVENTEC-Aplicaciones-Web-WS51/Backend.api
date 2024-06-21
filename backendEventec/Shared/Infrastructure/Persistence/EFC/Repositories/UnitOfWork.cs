using backendEventec.Shared.Infrastructure.Persistence.EFC.Configuration;
using pcWeb2.Shared.Domain.Repositories;

namespace backendEventec.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context) => _context = context;

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}