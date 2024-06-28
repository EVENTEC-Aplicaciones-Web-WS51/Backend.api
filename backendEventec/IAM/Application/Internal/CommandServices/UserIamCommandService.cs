using backendEventec.IAM.Domain.Repositories;
using backendEventec.Shared.Domain.Repositories;
using BDEventecFinal.IAM.Application.Internal.OutboundServices;
using BDEventecFinal.IAM.Domain.Model.Aggregates;
using BDEventecFinal.IAM.Domain.Model.Commands;
using BDEventecFinal.IAM.Domain.Services;

namespace backendEventec.IAM.Application.Internal.CommandServices;

/**
 * User command service.
 * <summary>
 *    This class is responsible for handling user commands.
 * </summary>
 */
public class UserIamCommandService(IUserIamRepository userIamRepository, ITokenService tokenService, IHashingService hashingService, IUnitOfWork unitOfWork) : IUserIamCommandService
{
    public async Task Handle(SignUpCommand command)
    {
        if (userIamRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} already exists.");
        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new UserIAM(command.Username, hashedPassword);
        try
        {
            await userIamRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        } catch (Exception e)
        {
            throw new Exception("An error occurred while trying to sign up the user.", e);
        }
    }

    public async Task<(UserIAM userIam, string token)> Handle(SignInCommand command)
    {
        var user = await userIamRepository.FindByUsernameAsync(command.Username);
        if (user is null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password.");
        var token = tokenService.GenerateToken(user);
        return (user, token);
    }
}