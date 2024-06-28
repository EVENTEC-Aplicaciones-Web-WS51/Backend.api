using BDEventecFinal.IAM.Domain.Model.Aggregates;
using BDEventecFinal.IAM.Domain.Model.Commands;


namespace BDEventecFinal.IAM.Domain.Services;

/**
 * Interface for User Command Service
 * <summary>
 * This interface defines the contract for the User Command Service
 * </summary>
 */
public interface IUserIamCommandService
{
    /**
     * Handle the SignUp Command
     * <summary>
     * This method handles the SignUp Command
     * </summary>
     * <param name="command">SignUp Command</param>
     * <returns>Task</returns>
     */
    Task Handle(SignUpCommand command);
    /**
     * Handle the SignIn Command
     * <summary>
     * This method handles the SignIn Command
     * </summary>
     * <param name="command">SignIn Command</param>
     * <returns>Task - the user and generated token on success</returns>
     */
    Task<(UserIAM userIam , string token )> Handle(SignInCommand command);
}