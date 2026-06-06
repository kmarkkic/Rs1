using MediatR;
using Market.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.Message.Commands.MarkMessageAsRead
{
    public class MarkMessageAsReadCommandHandler : IRequestHandler<MarkMessageAsReadCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public MarkMessageAsReadCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(MarkMessageAsReadCommand request, CancellationToken cancellationToken)
        {
            var message = await _context.Messages
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);

            if (message == null)
                throw new Exception($"Message with ID {request.Id} not found.");

            message.IsRead = true;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
