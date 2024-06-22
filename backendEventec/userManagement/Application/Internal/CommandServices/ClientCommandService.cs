using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Domain.Model.Commands;
using backendEventec.UserManagement.Domain.Repositories;
using backendEventec.UserManagement.Domain.Services;
using pcWeb2.Shared.Domain.Repositories;

namespace backendEventec.UserManagement.Application.Internal.CommandServices;

public class ClientCommandService(IClientRepository clientRepository,IUnitOfWork unitOfWork): IClientCommandService
{
    public async Task<Client?> Handle(CreateClientCommand command)
    {
        var client = new Client(command);
        try
        {
            await clientRepository.AddAsync(client);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return client;
    }    
}