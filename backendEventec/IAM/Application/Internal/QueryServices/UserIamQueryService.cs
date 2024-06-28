using backendEventec.IAM.Domain.Repositories;
using BDEventecFinal.IAM.Domain.Model.Aggregates;
using BDEventecFinal.IAM.Domain.Model.Queries;
using BDEventecFinal.IAM.Domain.Services;

namespace backendEventec.IAM.Application.Internal.QueryServices;

/**
 * User query service.
 * <summary>
 *    This class is responsible for handling user queries.
 * </summary>
 */
public class UserIamQueryService(IUserIamRepository userIamRepository) : IUserIamQueryService
{
    /**
     * Get user by id.
     * <summary>
     *   This method is responsible for getting a user by id.
     * </summary>
     * <param name="query">Get user by id query.</param>
     * <returns>User.</returns>
     */
    public async Task<UserIAM?> Handle(GetUserIamByIdQuery query)
    {
        return await userIamRepository.FindByIdAsync(query.IdIam);
    }

    /**
     * Get user by username.
     * <summary>
     *   This method is responsible for getting a user by username.
     * </summary>
     * <param name="query">Get user by username query.</param>
     * <returns>User.</returns>
     */
    public async Task<UserIAM?> Handle(GetUserIamByUsernameQuery query)
    {
        return await userIamRepository.FindByUsernameAsync(query.Username);
    }

    /**
     * Get all users.
     * <summary>
     *   This method is responsible for getting all users.
     * </summary>
     * <param name="iamQuery">Get all users query.</param>
     * <returns>Users.</returns>
     */
    public async Task<IEnumerable<UserIAM>> Handle(GetAllUsersIamQuery iamQuery)
    {
        return await userIamRepository.ListAsync();
    }
}