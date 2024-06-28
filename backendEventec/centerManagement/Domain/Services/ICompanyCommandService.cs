using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.CenterManagement.Domain.Model.Commands;

namespace backendEventec.CenterManagement.Domain.Services;

public interface ICompanyCommandService
{
    Task<Company?> Handle(CreateCompanyCommand command);
}