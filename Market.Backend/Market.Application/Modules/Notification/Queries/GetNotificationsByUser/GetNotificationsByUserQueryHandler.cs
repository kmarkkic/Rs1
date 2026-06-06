using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.Notification.Queries.GetNotificationsByUser
{
    public class GetNotificationsByUserQueryHandler : IRequestHandler<GetNotificationsByUserQuery, List<NotificationDTO>>
    {
        private readonly IAppDbContext _context;

        public GetNotificationsByUserQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<NotificationDTO>> Handle(GetNotificationsByUserQuery request, CancellationToken cancellationToken)
        {
            return await _context.Notifications
                .Where(n => n.UserId == request.UserId && !n.IsDeleted)
                .OrderByDescending(n => n.Id)
                .Select(n => new NotificationDTO
                {
                    Id = (int)n.Id,
                    UserId = n.UserId,
                    Message = n.Message,
                    IsRead = n.IsRead
                })
                .ToListAsync(cancellationToken);
        }
    }
}
