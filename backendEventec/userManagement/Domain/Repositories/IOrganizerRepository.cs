using backendEventec.Shared.Domain.Repositories;
using backendEventec.UserManagement.Domain.Model.Aggregates;

namespace backendEventec.UserManagement.Domain.Repositories;

public interface IOrganizerRepository : IBaseRepository<Organizer>
{
    Task<IEnumerable<Organizer>> FindAllAsync();
    Task<Organizer?> FindByIdAsync(int id);
    Task<IEnumerable<Organizer>> FindByUserIdAsync(int userId);
    Task<IEnumerable<Organizer>> FindByCompanyNameAsync(string companyName);
}