using MediatR;

namespace Market.Application.Modules.Notification.Commands.MarkNotificationAsRead
{
    public class MarkNotificationAsReadCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
