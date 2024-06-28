using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.centerManagement.Domain.Model.Queries;

namespace backendEventec.CenterManagement.Domain.Services;

public interface IPlaceQueryService
{
    Task<IEnumerable<Place>> Handle(GetAllPlacesQuery query);
    Task<Place?> Handle(GetPlaceByIdQuery query);
    
}