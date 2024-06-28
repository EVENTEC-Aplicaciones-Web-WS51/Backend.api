using backendEventec.CenterManagement.Domain.Model.Commands;
using backendEventec.CenterManagement.Interfaces.REST.Resources;

namespace backendEventec.CenterManagement.Interfaces.REST.Transform;

public static class CreateCompanyCommandFromResourceAssembler
{
    public static CreateCompanyCommand ToCommandFromResource(CreateCompanyResource resource) =>
        new(resource.Name,resource.QuantityOrganizer);
}