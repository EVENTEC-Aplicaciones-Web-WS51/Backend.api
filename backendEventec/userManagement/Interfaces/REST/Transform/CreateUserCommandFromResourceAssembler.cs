using backendEventec.UserManagement.Domain.Model.Commands;
using backendEventec.UserManagement.Interfaces.REST.Resources;

namespace backendEventec.UserManagement.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource) =>
        new(resource.FirstName, resource.LastName, resource.Address, resource.Email, resource.Phone, resource.Password);
}