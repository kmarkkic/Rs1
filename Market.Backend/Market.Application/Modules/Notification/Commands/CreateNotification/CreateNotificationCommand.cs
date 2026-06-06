using MediatR;

namespace Market.Application.Modules.Notification.Commands.CreateNotification
{
    public class CreateNotificationCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Message { get; set; }
    }
}
