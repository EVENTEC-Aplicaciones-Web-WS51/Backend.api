using BDEventecFinal.IAM.Domain.Model.Aggregates;
using BDEventecFinal.IAM.Interfaces.REST.Resources;

namespace BDEventecFinal.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserIamResource ToResourceFromEntity(UserIAM entity)
    {
        return new UserIamResource(entity.IdIam, entity.Username);
    }
}