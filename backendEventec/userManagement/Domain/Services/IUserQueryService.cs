using BDEventecFinal.userManagement.Domain.Model.Aggregates;
using BDEventecFinal.userManagement.Domain.Model.Queries;

namespace BDEventecFinal.userManagement.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUserQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?>Handle(GetUserByEmailQuery query);
}