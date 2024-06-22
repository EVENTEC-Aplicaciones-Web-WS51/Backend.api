using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Interfaces.REST.Resources;

namespace backendEventec.UserManagement.Interfaces.REST.Transform;

public class ClientResourceFromEntityAssembler
{
    public static ClientResource ToResourceFromEntity(Client entity) =>
        new ClientResource(entity.Id, entity.UserId);
}