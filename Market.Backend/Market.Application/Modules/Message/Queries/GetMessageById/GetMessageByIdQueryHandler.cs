using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.Message.Queries.GetMessageById
{
    public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, MessageDTO>
    {
        private readonly IAppDbContext _context;

        public GetMessageByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<MessageDTO> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var message = await _context.Messages
                .Where(m => m.Id == request.Id && !m.IsDeleted)
                .Select(m => new MessageDTO
                {
                    Id = (int)m.Id,
                    SenderId = m.SenderId,
                    ReceiverId = m.ReceiverId,
                    Content = m.Content,
                    IsRead = m.IsRead
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (message == null)
                throw new Exception($"Message with ID {request.Id} not found.");

            return message;
        }
    }
}
