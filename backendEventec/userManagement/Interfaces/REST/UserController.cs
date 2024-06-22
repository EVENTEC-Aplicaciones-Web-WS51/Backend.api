using System.Net.Mime;
using backendEventec.UserManagement.Domain.Model.Queries;
using backendEventec.UserManagement.Domain.Services;
using backendEventec.UserManagement.Interfaces.REST.Resources;
using backendEventec.UserManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backendEventec.UserManagement.Interfaces.REST;

[ApiController]
[Route("/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class UserController(IUserCommandService userCommandService, IUserQueryService userQueryService): ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await userCommandService.Handle(createUserCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetUserById), new { id = result.Id },
            UserResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var result = await userQueryService.Handle(getUserByIdQuery);
        if (result is null) return NotFound();
        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    [HttpGet("wallets/{walletId}")]
    public async Task<ActionResult> GetUserByWalletId(int walletId)
    {
        var getUserByWalletIdQuery = new GetUserByWalletIdQuery(walletId);
        var user = await userQueryService.Handle(getUserByWalletIdQuery);
        var resources = user.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllUser()
    {
        var getAllUsersQuery = new GetAllUserQuery();
        var user = await userQueryService.Handle(getAllUsersQuery);
        var resources = user.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    
}