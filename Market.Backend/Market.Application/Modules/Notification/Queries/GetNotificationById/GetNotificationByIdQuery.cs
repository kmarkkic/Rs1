using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Notification.Queries.GetNotificationById
{
    public class GetNotificationByIdQuery : IRequest<NotificationDTO>
    {
        public int Id { get; set; }
    }
}
