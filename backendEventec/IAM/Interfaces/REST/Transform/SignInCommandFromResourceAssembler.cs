using BDEventecFinal.IAM.Domain.Model.Commands;
using BDEventecFinal.IAM.Interfaces.REST.Resources;

namespace BDEventecFinal.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    } 
}