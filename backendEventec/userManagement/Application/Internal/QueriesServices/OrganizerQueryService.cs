using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Domain.Model.Queries;
using backendEventec.UserManagement.Domain.Repositories;
using backendEventec.UserManagement.Domain.Services;

namespace backendEventec.UserManagement.Application.Internal.QueriesServices;

public class OrganizerQueryService(IOrganizerRepository organizerRepository): IOrganizerQueryService
{
    public async Task<Organizer?> Handle(GetOrganizerByIdQuery query)
    {
        return await organizerRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Organizer>> Handle(GetOrganizersByUserIdQuery query)
    {
        return await organizerRepository.FindByUserIdAsync(query.UserId);
    }

    public async Task<IEnumerable<Organizer>> Handle(GetOrganizersByCompanyIdQuery query)
    {
        return await organizerRepository.FindByCompanyIdAsync(query.CompanyId);
    }

    public async Task<IEnumerable<Organizer>> Handle(GetAllOrganizersQuery query)
    {
        return await organizerRepository.FindAllAsync();
    }
}