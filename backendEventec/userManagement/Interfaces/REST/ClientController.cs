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
public class ClientController(IClientCommandService clientCommandService, IClientQueryService clientQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateClient([FromBody] CreateClientResource resource)
    {
        var createClientCommand = CreateClientCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await clientCommandService.Handle(createClientCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetClientById), new { id = result.Id },
            ClientResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetClientById(int id)
    {
        var getClientByIdQuery = new GetClientByIdQuery(id);
        var result = await clientQueryService.Handle(getClientByIdQuery);
        if (result is null) return NotFound();
        var resource = ClientResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet("users/{userId}")]
    public async Task<ActionResult> GetClientsByUserId(int userId)
    {
        var getClientsByUserIdQuery = new GetClientsByUserIdQuery(userId);
        var clients = await clientQueryService.Handle(getClientsByUserIdQuery);
        var resources = clients.Select(ClientResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllClients()
    {
        var getAllClientsQuery = new GetAllClientsQuery();
        var clients = await clientQueryService.Handle(getAllClientsQuery);
        var resources = clients.Select(ClientResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
