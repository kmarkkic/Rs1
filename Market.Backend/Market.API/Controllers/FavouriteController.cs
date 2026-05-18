using Market.Application.Modules.Favourites.Commands.AddFavourite;
using Market.Application.Modules.Favourites.Commands.DeleteFavourite;
using Market.Application.Modules.Favourites.Queries.GetFavouritesByUser;
using Market.Application.UdomiMe_DTO;

[ApiController]
[Route("api/[controller]")]
public class FavouritesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FavouritesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<FavouritesDTO>>> GetByUser(int userId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetFavouritesByUserQuery(userId), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Add([FromBody] AddFavouriteCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteFavouriteCommand(id), cancellationToken);
        return NoContent();
    }
}