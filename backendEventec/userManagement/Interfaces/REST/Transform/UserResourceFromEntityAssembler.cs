using backendEventec.userManagement.Interfaces.REST.Resources;
using BDEventecFinal.userManagement.Domain.Model.Aggregates;


namespace BDEventecFinal.userManagement.Interfaces.REST.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity) =>
        new UserResource(entity.Id, entity.FirstName,entity.LastName,entity.Address,entity.Email,entity.Phone,entity.Password,entity.Role);
}