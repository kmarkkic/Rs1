using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.VisitRequest.Commands.DeleteVisitRequest
{
    public class DeleteVisitRequestCommandHandler : IRequestHandler<DeleteVisitRequestCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public DeleteVisitRequestCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteVisitRequestCommand request, CancellationToken cancellationToken)
        {
            var visitRequest = await _context.VisitRequests.FindAsync(request.Id);

            if (visitRequest == null)
                throw new Exception($"VisitRequest with ID {request.Id} not found.");

            _context.VisitRequests.Remove(visitRequest);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}