using Market.Application.Modules.AdoptionRequestStatus.Commands.CreateAdoptionRequestStatus;
using Market.Application.Modules.AdoptionRequestStatus.Commands.DeleteAdoptionRequestStatus;
using Market.Application.Modules.AdoptionRequestStatus.Queries.GetAdoptionRequest;
using Market.Application.Modules.AdoptionRequestStatus.Queries.GetAdoptionRequestStatusById;
using Market.Application.UdomiMe_DTO.Adoptions;

namespace Market.API.Controllers
{

    [ApiController]
    [Route("api/adoption-request-status")]
    public class AdoptionRequestStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdoptionRequestStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // list of all adoption request statuses
        [HttpGet]
        public async Task<ActionResult<List<AdoptionRequestStatusesDTO>>> GetAdoptionRequestStatuses()
        {
            var query = new GetAdoptionRequestStatusesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // get adoption request status by id
        [HttpGet("{id}")]
        public async Task<ActionResult<AdoptionRequestStatusesDTO>> GetAdoptionRequestStatusById(int id)
        {
            var query = new GetAdoptionRequestStatusByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // create new adoption request status
        [HttpPost]
        public async Task<ActionResult<AdoptionRequestStatusesDTO>> CreateAdoptionRequestStatus([FromBody] CreateAdoptionRequestStatusCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // delete adoption request status
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdoptionRequestStatus(int id)
        {
            var command = new DeleteAdoptionRequestStatusCommand(id);
            await _mediator.Send(command);
            return Ok(command);
        }
    }
}
