using Market.Application.Modules.Animal.Commands.CreateAnimal;
using Market.Application.Modules.Animal.Commands.DeleteAnimal;
using Market.Application.Modules.Animal.Commands.UpdateAnimal;
using Market.Application.Modules.Animal.Queries.GetAnimalById;
using Market.Application.Modules.Animal.Queries.GetAnimals;
using Market.Application.UdomiMe_DTO;

[ApiController]
[Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnimalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<AnimalDTO>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAnimalsQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AnimalDTO>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAnimalByIdQuery(id), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateAnimalCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateAnimalCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
            return BadRequest("ID mismatch");

        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteAnimalCommand(id), cancellationToken);
        return NoContent();
    }
}