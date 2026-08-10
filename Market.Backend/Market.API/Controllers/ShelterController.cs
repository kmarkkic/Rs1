using Market.Application.Modules.Shelter.Queries.GetAllShelters;
using Market.Application.Modules.Shelter.Queries.GetShelterById;
using Market.Application.UdomiMe_DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("api/shelters")]
    public class ShelterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShelterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShelterDTO>>> GetAll(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetAllSheltersQuery(), ct);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShelterDTO>> GetById(int id, CancellationToken ct)
        {
            var result = await _mediator.Send(new GetShelterByIdQuery(id), ct);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
