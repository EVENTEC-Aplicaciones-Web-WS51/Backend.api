using backendEventec.userManagement.Interfaces.REST.Resources;
using BDEventecFinal.userManagement.Domain.Model.Commands;

namespace BDEventecFinal.userManagement.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource) =>
        new(resource.FirstName, resource.LastName,resource.Address, resource.Email, resource.Phone, resource.Password,resource.Role);
}