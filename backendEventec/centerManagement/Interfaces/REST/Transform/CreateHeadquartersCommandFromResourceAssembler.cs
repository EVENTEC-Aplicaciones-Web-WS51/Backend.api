using backendEventec.CenterManagement.Domain.Model.Commands;
using backendEventec.CenterManagement.Interfaces.REST.Resources;

namespace backendEventec.CenterManagement.Interfaces.REST.Transform;

public static class CreateHeadquartersCommandFromResourceAssembler
{
    public static CreateHeadquartersCommand ToCommandFromResource(CreateHeadquartersResource resource) =>
        new(resource.Name,resource.Capacity);
}