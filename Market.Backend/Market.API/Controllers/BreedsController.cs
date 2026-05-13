using MediatR;
using Market.Application.Modules.Breeds.Queries.GetBreeds;
using Market.Application.Modules.Breeds.Commands.DeleteBreed;
using Market.Application.Modules.Breeds.Commands.CreateBreed;
using Market.Application.Modules.Breeds.Queries.GetBreedsById;
namespace Market.API.Controllers
{
    [ApiController]
    [Route("api/breeds")]
    public class BreedsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BreedsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get Breeds

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetBreedsQuery(), ct);
            return Ok(result);
        }

        // Create Breed

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateBreedCommand command, CancellationToken ct)
        {
            var result = await _mediator.Send(command, ct);
            return Ok(result);
        }

        // delete breed
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id, CancellationToken ct)
            {
                var command = new DeleteBreedCommand(id);
                await _mediator.Send(command, ct);
                return Ok();
          
        
            }

        // get breed by id
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id, CancellationToken ct)
            {
                var result = await _mediator.Send(new GetBreedByIdQuery(id), ct);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        
    }
}