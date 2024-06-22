using backendEventec.UserManagement.Domain.Model.Aggregates;
using pcWeb2.Shared.Domain.Repositories;

namespace backendEventec.UserManagement.Domain.Repositories;

public interface IOrganizerRepository : IBaseRepository<Organizer>
{
    Task<IEnumerable<Organizer>> FindAllAsync();
    Task<Organizer?> FindByIdAsync(int id);
    Task<IEnumerable<Organizer>> FindByUserIdAsync(int userId);
    Task<IEnumerable<Organizer>> FindByCompanyIdAsync(int companyId);
}