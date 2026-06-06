using Market.Application.Modules.AnimalHealthRecord.Commands.CreateAnimalHealthRecord;
using Market.Application.Modules.AnimalHealthRecord.Commands.DeleteAnimalHealthRecord;
using Market.Application.Modules.AnimalHealthRecord.Commands.UpdateAnimalHealthRecord;
using Market.Application.Modules.AnimalHealthRecord.Queries.GetHealthRecordById;
using Market.Application.Modules.AnimalHealthRecord.Queries.GetHealthRecordsByAnimal;
using Market.Application.UdomiMe_DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AnimalHealthRecordController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnimalHealthRecordController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AnimalHealthRecordDTO>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetHealthRecordByIdQuery { Id = id }, cancellationToken);
        return Ok(result);
    }

    [HttpGet("animal/{animalId}")]
    public async Task<ActionResult<List<AnimalHealthRecordDTO>>> GetByAnimal(int animalId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetHealthRecordsByAnimalQuery { AnimalId = animalId }, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateAnimalHealthRecordCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateAnimalHealthRecordCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteAnimalHealthRecordCommand { Id = id }, cancellationToken);
        return NoContent();
    }
}
