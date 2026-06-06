using Market.Application.Modules.Notification.Commands.CreateNotification;
using Market.Application.Modules.Notification.Commands.DeleteNotification;
using Market.Application.Modules.Notification.Commands.MarkNotificationAsRead;
using Market.Application.Modules.Notification.Queries.GetNotificationById;
using Market.Application.Modules.Notification.Queries.GetNotificationsByUser;
using Market.Application.UdomiMe_DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NotificationDTO>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetNotificationByIdQuery { Id = id }, cancellationToken);
        return Ok(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<NotificationDTO>>> GetByUser(int userId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetNotificationsByUserQuery { UserId = userId }, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateNotificationCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPatch("{id}/read")]
    public async Task<ActionResult> MarkAsRead(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new MarkNotificationAsReadCommand { Id = id }, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteNotificationCommand { Id = id }, cancellationToken);
        return NoContent();
    }
}
