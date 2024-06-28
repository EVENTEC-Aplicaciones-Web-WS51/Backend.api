using System.Net.Mime;
using backendEventec.centerManagement.Domain.Model.Queries;
using backendEventec.CenterManagement.Domain.Services;
using backendEventec.CenterManagement.Interfaces.REST.Resources;
using backendEventec.CenterManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backendEventec.CenterManagement.Interfaces.REST;

[ApiController]
[Route("/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PlaceController(IPlaceCommandService placeCommandService, IPlaceQueryService placeQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreatePlace([FromBody] CreatePlaceResource resource)
    {
        var createPlaceCommand = CreatePlaceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await placeCommandService.Handle(createPlaceCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetPlaceById), new { id = result.Id },
            PlaceResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetPlaceById(int id)
    {
        var getPlaceByIdQuery = new GetPlaceByIdQuery(id);
        var result = await placeQueryService.Handle(getPlaceByIdQuery);
        if (result is null) return NotFound();
        var resource = PlaceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllPlaces()
    {
        var getAllPlacesQuery = new GetAllPlacesQuery();
        var place = await placeQueryService.Handle(getAllPlacesQuery);
        var resources = place.Select(PlaceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}