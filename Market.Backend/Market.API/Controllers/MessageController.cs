using Market.Application.Modules.Message.Commands.DeleteMessage;
using Market.Application.Modules.Message.Commands.MarkMessageAsRead;
using Market.Application.Modules.Message.Commands.SendMessage;
using Market.Application.Modules.Message.Queries.GetMessageById;
using Market.Application.Modules.Message.Queries.GetMessagesBetweenUsers;
using Market.Application.UdomiMe_DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MessageDTO>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetMessageByIdQuery { Id = id }, cancellationToken);
        return Ok(result);
    }

    [HttpGet("conversation")]
    public async Task<ActionResult<List<MessageDTO>>> GetConversation([FromQuery] int userId1, [FromQuery] int userId2, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetMessagesBetweenUsersQuery { UserId1 = userId1, UserId2 = userId2 }, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Send([FromBody] SendMessageCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPatch("{id}/read")]
    public async Task<ActionResult> MarkAsRead(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new MarkMessageAsReadCommand { Id = id }, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteMessageCommand { Id = id }, cancellationToken);
        return NoContent();
    }
}
