using backendEventec.UserManagement.Domain.Model.Aggregates;
using backendEventec.UserManagement.Domain.Model.Commands;

namespace backendEventec.UserManagement.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
}