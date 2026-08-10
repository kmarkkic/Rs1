using Market.Application.Modules.AnimalTypes.Queries.GetAllAnimalTypes;
using Market.Application.UdomiMe_DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("api/animal-types")]
    public class AnimalTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnimalTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalTypesDTO>>> GetAll(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetAllAnimalTypesQuery(), ct);
            return Ok(result);
        }
    }
}
