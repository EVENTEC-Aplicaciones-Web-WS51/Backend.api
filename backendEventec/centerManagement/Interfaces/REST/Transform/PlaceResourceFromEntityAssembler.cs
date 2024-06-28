using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.CenterManagement.Interfaces.REST.Resources;

namespace backendEventec.CenterManagement.Interfaces.REST.Transform;

public class PlaceResourceFromEntityAssembler
{
    public static PlaceResource ToResourceFromEntity(Place entity) =>
        new PlaceResource(entity.Id, entity.Name,entity.Address,entity.Capacity,entity.Ruc);
}