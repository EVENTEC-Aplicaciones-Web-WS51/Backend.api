using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.centerManagement.Domain.Model.Queries;
using backendEventec.CenterManagement.Domain.Model.Queries;
using backendEventec.CenterManagement.Domain.Repositories;
using backendEventec.CenterManagement.Domain.Services;


namespace backendEventec.CenterManagement.Application.Internal.QueriesServices;

public class CompanyQueryService(ICompanyRepository companyRepository): ICompanyQueryService
{
    public async Task<Company?> Handle(GetCompanyByIdQuery query)
    {
        return await companyRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Company>> Handle(GetCompanyByPlaceIdQuery query)
    {
        return await companyRepository.FindByPlaceIdAsync(query.IdPlace);
    }

    public async Task<IEnumerable<Company>> Handle(GetAllCompanysQuery query)
    {
        return await companyRepository.FindAllAsync();
    }
}