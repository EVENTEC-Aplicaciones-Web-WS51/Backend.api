using backendEventec.UserManagement.Domain.Model.Commands;
using backendEventec.UserManagement.Interfaces.REST.Resources;

namespace backendEventec.UserManagement.Interfaces.REST.Transform;

public class CreateOrganizerCommandFromResourceAssembler
{
    public static CreateOrganizerCommand ToCommandFromResource(CreateOrganizerResource resource) =>
        new(resource.UserId);
}