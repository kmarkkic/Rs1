using MediatR;
using Microsoft.AspNetCore.Mvc;
using Market.Application.Modules.Cities.Commands.CreateCity;
using Market.Application.Modules.Cities.Commands.DeleteCity;
using Market.Application.Modules.Cities.Commands.UpdateCity;
using Market.Application.Modules.Cities.Queries.GetCities;
using Market.Application.Modules.Cities.Queries.GetCitiesById;

[ApiController]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/cities
    // vraća sve gradove
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await _mediator.Send(new GetCitiesQuery(), ct);
        return Ok(result);
    }


    
    // dodaje novi grad
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCityCommand command, CancellationToken ct)
    {
        var result = await _mediator.Send(command, ct);
        return Ok(result);
    }


    // DELETE /api/cities/5
    // briše grad s ID=5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var command = new DeleteCityCommand(id);
        await _mediator.Send(command, ct);
        return Ok();
    }

    // update grad

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCityCommand command, CancellationToken ct)
    {
        command.Id = id; // postavljamo ID iz URL-a u command
        var result = await _mediator.Send(command, ct);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct)
    {
        var query = new GetCityByIdQuery(id);
        var result = await _mediator.Send(query, ct);
        return Ok(result);
    }
}