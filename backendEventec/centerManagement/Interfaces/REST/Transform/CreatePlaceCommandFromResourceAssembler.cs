using backendEventec.CenterManagement.Domain.Model.Commands;
using backendEventec.CenterManagement.Interfaces.REST.Resources;

namespace backendEventec.CenterManagement.Interfaces.REST.Transform;

public static class CreatePlaceCommandFromResourceAssembler
{
    public static CreatePlaceCommand ToCommandFromResource(CreatePlaceResource resource) =>
        new(resource.Name,resource.Address,resource.Capacity,resource.Ruc);
}