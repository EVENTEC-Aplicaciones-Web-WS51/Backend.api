using backendEventec.UserManagement.Domain.Model.Commands;
using backendEventec.UserManagement.Interfaces.REST.Resources;

namespace backendEventec.UserManagement.Interfaces.REST.Transform;

public static class CreateClientCommandFromResourceAssembler
{
    public static CreateClientCommand ToCommandFromResource(CreateClientResource resource) =>
        new(resource.UserId);
}