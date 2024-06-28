using BDEventecFinal.IAM.Domain.Model.Aggregates;
using BDEventecFinal.IAM.Domain.Model.Queries;


namespace BDEventecFinal.IAM.Domain.Services;

/**
 * Interface for User Query Service
 * <summary>
 * This interface defines the contract for the User Query Service
 * </summary>
 */
public interface IUserIamQueryService
{
    /**
     * Handle the GetUserById Query
     * <summary>
     * This method handles the GetUserById Query
     * </summary>
     * <param name="query">GetUserById Query</param>
     * <returns>Task - the user on success</returns>
     */
    Task<UserIAM?> Handle(GetUserIamByIdQuery query);
    /**
     * Handle the GetUserByUsername Query
     * <summary>
     * This method handles the GetUserByUsername Query
     * </summary>
     * <param name="query">GetUserByUsername Query</param>
     * <returns>Task - the user on success</returns>
     */
    Task<UserIAM?> Handle(GetUserIamByUsernameQuery query);
    /**
     * Handle the GetAllUsers Query
     * <summary>
     * This method handles the GetAllUsers Query
     * </summary>
     * <param name="iamQuery">GetAllUsers Query</param>
     * <returns>Task - the list of users on success</returns>
     */
    Task<IEnumerable<UserIAM>> Handle(GetAllUsersIamQuery iamQuery);
}