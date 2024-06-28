using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.CenterManagement.Interfaces.REST.Resources;

namespace backendEventec.CenterManagement.Interfaces.REST.Transform;

public class HeadquartersResourceFromEntityAssembler
{
    public static HeadquartersResource ToResourceFromEntity(Headquarters entity) =>
        new HeadquartersResource(entity.Id, entity.Name,entity.IdPlace,entity.Capacity);
}