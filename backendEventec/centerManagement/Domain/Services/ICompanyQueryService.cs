using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.centerManagement.Domain.Model.Queries;
using backendEventec.CenterManagement.Domain.Model.Queries;

namespace backendEventec.CenterManagement.Domain.Services;

public interface ICompanyQueryService
{
    Task<IEnumerable<Company>> Handle(GetAllCompanysQuery query);
    Task<Company?> Handle(GetCompanyByIdQuery query);
    Task<IEnumerable<Company>> Handle(GetCompanyByPlaceIdQuery query);
}