using Market.Application.Modules.Review.Commands.CreateReview;
using Market.Application.Modules.Review.Commands.DeleteReview;
using Market.Application.Modules.Review.Commands.UpdateReview;
using Market.Application.Modules.Review.Queries.GetReviewById;
using Market.Application.Modules.Review.Queries.GetReviewsByShelter;
using Market.Application.UdomiMe_DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDTO>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetReviewByIdQuery { Id = id }, cancellationToken);
        return Ok(result);
    }

    [HttpGet("shelter/{shelterId}")]
    public async Task<ActionResult<List<ReviewDTO>>> GetByShelter(int shelterId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetReviewsByShelterQuery { ShelterId = shelterId }, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateReviewCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateReviewCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteReviewCommand { Id = id }, cancellationToken);
        return NoContent();
    }
}
