using backendEventec.CenterManagement.Domain.Model.Aggregates;
using backendEventec.CenterManagement.Domain.Model.Commands;
using backendEventec.CenterManagement.Domain.Repositories;
using backendEventec.CenterManagement.Domain.Services;
using backendEventec.Shared.Domain.Repositories;

namespace backendEventec.CenterManagement.Application.Internal.CommandServices;

public class CompanyCommandService(ICompanyRepository companyRepository,IUnitOfWork unitOfWork): ICompanyCommandService
{
    public async Task<Company?> Handle(CreateCompanyCommand command)
    {
        var company = new Company(command);
        try
        {
            await companyRepository.AddAsync(company);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return company;
    }    
}