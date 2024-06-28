using backendEventec.Shared.Domain.Repositories;
using BDEventecFinal.IAM.Domain.Model.Aggregates;

namespace backendEventec.IAM.Domain.Repositories;
/**
 * The IUserRepository interface defines the contract for the User repository.
 */
public interface IUserIamRepository: IBaseRepository<UserIAM>
{
 /**
* Find a user by username.
* <param name="username"> The user name</param>
* <returns>
* The user if found, otherwise null.
* </returns>
*/
 Task<UserIAM?> FindByUsernameAsync(string username);
 /**
  * Check if a user exists by username.
  * <param name="username"> The user name</param>
  * <returns>
  * True if the user exists, otherwise false.
  * </returns>
  */
 bool ExistsByUsername(string username);
}