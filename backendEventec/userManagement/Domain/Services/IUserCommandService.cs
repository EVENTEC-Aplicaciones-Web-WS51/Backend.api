using BDEventecFinal.userManagement.Domain.Model.Aggregates;
using BDEventecFinal.userManagement.Domain.Model.Commands;


namespace BDEventecFinal.userManagement.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
}