using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Interfaces.REST.Resources;

namespace backendEventec.UserManagement.Interfaces.REST.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity) =>
        new UserResource(entity.Id, entity.IdWallet, entity.FirstName, entity.LastName, entity.Address, entity.Email,
            entity.Phone, entity.CreationDate, entity.SuspensionDate);
}