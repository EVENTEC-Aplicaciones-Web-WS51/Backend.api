using BDEventecFinal.IAM.Application.Internal.OutboundServices;
using BDEventecFinal.IAM.Domain.Model.Queries;
using BDEventecFinal.IAM.Domain.Services;
using BDEventecFinal.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace BDEventecFinal.IAM.Infrastructure.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware(RequestDelegate next) 
{
    public async Task InvokeAsync(
        HttpContext context,
        IUserIamQueryService userIamQueryService,
        ITokenService tokenService)
    {
        Console.WriteLine("Entering InvokeAsync");
        var allowAnonymous = context.Request.HttpContext.GetEndpoint()!.Metadata
            .Any(m => m.GetType() == typeof(AllowAnonymousAttribute));
        if (allowAnonymous)
        {
            Console.WriteLine("Skipping authorization");
            await next(context);
            return;
        }
        Console.WriteLine("Entering Authorization");
        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
        if (token == null) throw new Exception("Null or invalid token");
        var userId = await tokenService.ValidateToken(token);
        if (userId == null) throw new Exception("Invalid token");
        var getUserByIdQuery = new GetUserIamByIdQuery(userId.Value);
        var result = await userIamQueryService.Handle(getUserByIdQuery);
        if (result == null) throw new Exception("User not found");
        Console.WriteLine("Successfully authorized user");
        context.Items["User"] = result;
        Console.WriteLine("Continuing to next middleware");
        await next(context);
    }
}