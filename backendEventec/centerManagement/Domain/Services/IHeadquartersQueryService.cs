using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.centerManagement.Domain.Model.Queries;

namespace backendEventec.CenterManagement.Domain.Services;

public interface IHeadquartersQueryService
{
    Task<IEnumerable<Headquarters>> Handle(GetAllHeadquartersQuery query);
    Task<Headquarters?> Handle(GetHeadquartersByIdQuery query);
    Task<IEnumerable<Headquarters>> Handle(GetHeadquartersByPlaceIdQuery query);
}