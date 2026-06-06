using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.Notification.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateNotificationCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = new Domain.Entities.UdomiMe.Notification
            {
                UserId = request.UserId,
                Message = request.Message,
                IsRead = false
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync(cancellationToken);

            return (int)notification.Id;
        }
    }
}
