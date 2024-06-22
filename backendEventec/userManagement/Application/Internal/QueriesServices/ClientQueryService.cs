using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Domain.Model.Queries;
using backendEventec.UserManagement.Domain.Repositories;
using backendEventec.UserManagement.Domain.Services;

namespace backendEventec.UserManagement.Application.Internal.QueriesServices;

public class ClientQueryService(IClientRepository clientRepository): IClientQueryService
{
    public async Task<IEnumerable<Client>> Handle(GetAllClientsQuery query)
    {
        return await clientRepository.FindAllAsync();
    }

    public async Task<Client?> Handle(GetClientByIdQuery query)
    {
        return await clientRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Client>> Handle(GetClientsByUserIdQuery query)
    {
        return await clientRepository.FindByUserIdAsync(query.UserId);
    }
}