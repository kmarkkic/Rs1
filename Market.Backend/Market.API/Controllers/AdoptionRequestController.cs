using MediatR;
using Market.Application.Modules.AdoptionRequest.Queries.GetAdoptionRequests;
using Market.Application.Modules.AdoptionRequest.Queries.GetAdoptionRequestsById;
using Market.Application.Modules.AdoptionRequest.Commands.AdoptionRequestCreate;
using Market.Application.Modules.AdoptionRequest.Commands.AdoptionRequestDelete;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("api/adoption-requests")]
    public class AdoptionRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdoptionRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // list of all adoption requests
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetAdoptionRequestsQuery(), ct);
            return Ok(result);
        }

        // get adoption request by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var result = await _mediator.Send(new GetAdoptionRequestsByIdQuery(id), ct);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // create new adoption request
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdoptionRequestCreateCommand command, CancellationToken ct)
        {
            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

        // delete adoption request
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id, CancellationToken ct)
            {
                var command = new AdoptionRequestDeleteCommand(id);
                await _mediator.Send(command, ct);
                return Ok();
            }

    }
}