using System.Net.Mime;
using backendEventec.userManagement.Interfaces.REST.Resources;
using BDEventecFinal.userManagement.Domain.Model.Queries;
using BDEventecFinal.userManagement.Domain.Services;
using BDEventecFinal.userManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backendEventec.userManagement.Interfaces.REST;

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
    [HttpGet]
    public async Task<ActionResult> GetAllUser()
    {
        var getAllUsersQuery = new GetAllUserQuery();
        var user = await userQueryService.Handle(getAllUsersQuery);
        var resources = user.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    [HttpGet("Email/{email}")]
    public async Task<ActionResult> GetUserByEmail(string email)
    {
        var getUserByEmailQuery = new GetUserByEmailQuery(email);
        var result = await userQueryService.Handle(getUserByEmailQuery);
        if (result is null) return NotFound();
        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
}