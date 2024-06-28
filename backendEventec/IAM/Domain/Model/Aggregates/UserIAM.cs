using System.Text.Json.Serialization;

namespace BDEventecFinal.IAM.Domain.Model.Aggregates;

/***
 * <summary>
 *    User aggregate root entity
 * </summary>
 * <remarks>
 *   This class is the aggregate root entity for the User aggregate
 * </remarks>
 */
public class UserIAM(string username, string passwordHash)
{
    public int IdIam { get; }

    public string Username { get; private set; } = username;
    
    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;
    
    public UserIAM() : this(string.Empty, string.Empty)
    {
    }
    
    
    /***
     * <summary>
     *    Update the username of the user
     * </summary>
     * <param name="username">The new username</param>
     * <returns>The updated user</returns>
     */
    public UserIAM UpdateUsername(string username)
    {
        Username = username;
        return this;
    }
    
    /***
     * <summary>
     *    Update the password hash of the user
     * </summary>
     * <param name="passwordHash">The new password hash</param>
     * <returns>The updated user</returns>
     */
    public UserIAM UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
    
}