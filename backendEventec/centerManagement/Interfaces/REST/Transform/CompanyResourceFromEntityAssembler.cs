using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.CenterManagement.Interfaces.REST.Resources;

namespace backendEventec.CenterManagement.Interfaces.REST.Transform;

public class CompanyResourceFromEntityAssembler
{
    public static CompanyResource ToResourceFromEntity(Company entity) =>
        new CompanyResource(entity.Id, entity.Name,entity.IdPlace,entity.QuantityOrganizer);
}