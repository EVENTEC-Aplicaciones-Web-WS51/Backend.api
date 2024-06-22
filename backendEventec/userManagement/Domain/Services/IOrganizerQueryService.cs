using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Domain.Model.Queries;

namespace backendEventec.UserManagement.Domain.Services;

public interface IOrganizerQueryService
{
    Task<Organizer?> Handle(GetOrganizerByIdQuery query);
    Task<IEnumerable<Organizer>> Handle(GetOrganizersByUserIdQuery query);
    Task<IEnumerable<Organizer>> Handle(GetOrganizersByCompanyIdQuery query);
    Task<IEnumerable<Organizer>> Handle(GetAllOrganizersQuery query);
}