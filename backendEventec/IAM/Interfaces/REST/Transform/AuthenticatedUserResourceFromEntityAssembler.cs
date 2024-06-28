using BDEventecFinal.IAM.Domain.Model.Aggregates;
using BDEventecFinal.IAM.Interfaces.REST.Resources;

namespace BDEventecFinal.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(UserIAM entity, string token)
    {
        return new AuthenticatedUserResource(entity.IdIam, entity.Username, token);
    }
}