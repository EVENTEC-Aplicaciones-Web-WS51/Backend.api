using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.CenterManagement.Domain.Model.Commands;

namespace backendEventec.CenterManagement.Domain.Services;

public interface IHeadquartersCommandService
{
    Task<Headquarters?> Handle(CreateHeadquartersCommand command);
}