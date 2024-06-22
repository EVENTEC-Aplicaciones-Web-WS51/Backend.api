using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Domain.Model.Commands;

namespace backendEventec.UserManagement.Domain.Services;

public interface IClientCommandService
{
    Task<Client?> Handle(CreateClientCommand command);
}