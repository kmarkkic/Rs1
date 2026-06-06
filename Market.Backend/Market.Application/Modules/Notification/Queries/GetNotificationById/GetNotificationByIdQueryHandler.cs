using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.Notification.Queries.GetNotificationById
{
    public class GetNotificationByIdQueryHandler : IRequestHandler<GetNotificationByIdQuery, NotificationDTO>
    {
        private readonly IAppDbContext _context;

        public GetNotificationByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<NotificationDTO> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            var notification = await _context.Notifications
                .Where(n => n.Id == request.Id && !n.IsDeleted)
                .Select(n => new NotificationDTO
                {
                    Id = (int)n.Id,
                    UserId = n.UserId,
                    Message = n.Message,
                    IsRead = n.IsRead
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (notification == null)
                throw new Exception($"Notification with ID {request.Id} not found.");

            return notification;
        }
    }
}
