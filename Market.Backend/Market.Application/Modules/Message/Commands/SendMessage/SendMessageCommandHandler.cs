using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.Message.Commands.SendMessage
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, int>
    {
        private readonly IAppDbContext _context;

        public SendMessageCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Domain.Entities.UdomiMe.Message
            {
                SenderId = request.SenderId,
                ReceiverId = request.ReceiverId,
                Content = request.Content,
                IsRead = false
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync(cancellationToken);

            return (int)message.Id;
        }
    }
}
