using MediatR;

namespace Market.Application.Modules.Notification.Commands.DeleteNotification
{
    public class DeleteNotificationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
