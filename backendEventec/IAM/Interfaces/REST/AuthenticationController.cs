using System.Net.Mime;
using BDEventecFinal.IAM.Domain.Services;
using BDEventecFinal.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using BDEventecFinal.IAM.Interfaces.REST.Resources;
using BDEventecFinal.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace BDEventecFinal.IAM.Interfaces.REST
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserIamCommandService userIamCommandService;

        public AuthenticationController(IUserIamCommandService userIamCommandService)
        {
            this.userIamCommandService = userIamCommandService;
        }

        [HttpPost("sign-up")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SignUpResource resource)
        {
            var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(resource);
            await userIamCommandService.Handle(signUpCommand);
            return Ok(new { message = "User created successfully"});
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
        {
            var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
            var authenticatedUser = await userIamCommandService.Handle(signInCommand);
            var authenticatedUserResource = AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser.userIam, authenticatedUser.token);
            return Ok(authenticatedUserResource);
        }
    }
}