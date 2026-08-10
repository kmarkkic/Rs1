using Market.Application.Modules.AnimalStatus.Queries.GetAllAnimalStatuses;
using Market.Application.UdomiMe_DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("api/animal-statuses")]
    public class AnimalStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnimalStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalStatusDTO>>> GetAll(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetAllAnimalStatusesQuery(), ct);
            return Ok(result);
        }
    }
}
