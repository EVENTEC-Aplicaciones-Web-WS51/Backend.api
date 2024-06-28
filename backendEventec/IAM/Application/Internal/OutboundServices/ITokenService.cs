using BDEventecFinal.IAM.Domain.Model.Aggregates;

namespace BDEventecFinal.IAM.Application.Internal.OutboundServices;

/**
 * Interface for Token Service
 * <summary>
 * This interface is used to generate and validate token
 * </summary>
 */
public interface ITokenService
{
    /**
     * Generate Token
     * <summary>
     * This method is used to generate token
     * </summary>
     * <param name="userIam">User object</param>
     * <returns>Token - the generated token</returns>
     */
    string GenerateToken(UserIAM userIam);
    
    /**
     * Validate Token
     * <summary>
     * This method is used to validate token
     * </summary>
     * <param name="token">Token</param>
     * <returns>int - the user id extracted from token</returns>
     */
    Task<int?> ValidateToken(string token);
}