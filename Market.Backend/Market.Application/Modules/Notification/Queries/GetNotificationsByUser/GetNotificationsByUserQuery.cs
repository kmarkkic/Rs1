using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Notification.Queries.GetNotificationsByUser
{
    public class GetNotificationsByUserQuery : IRequest<List<NotificationDTO>>
    {
        public int UserId { get; set; }
    }
}
