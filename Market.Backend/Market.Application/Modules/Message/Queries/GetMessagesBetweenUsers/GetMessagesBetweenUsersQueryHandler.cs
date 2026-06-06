using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.Message.Queries.GetMessagesBetweenUsers
{
    public class GetMessagesBetweenUsersQueryHandler : IRequestHandler<GetMessagesBetweenUsersQuery, List<MessageDTO>>
    {
        private readonly IAppDbContext _context;

        public GetMessagesBetweenUsersQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MessageDTO>> Handle(GetMessagesBetweenUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Messages
                .Where(m => !m.IsDeleted &&
                    ((m.SenderId == request.UserId1 && m.ReceiverId == request.UserId2) ||
                     (m.SenderId == request.UserId2 && m.ReceiverId == request.UserId1)))
                .OrderBy(m => m.Id)
                .Select(m => new MessageDTO
                {
                    Id = (int)m.Id,
                    SenderId = m.SenderId,
                    ReceiverId = m.ReceiverId,
                    Content = m.Content,
                    IsRead = m.IsRead
                })
                .ToListAsync(cancellationToken);
        }
    }
}
