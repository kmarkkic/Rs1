using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.VisitRequest.Commands.UpdateVisitRequest
{
    public class UpdateVisitRequestCommandHandler : IRequestHandler<UpdateVisitRequestCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public UpdateVisitRequestCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateVisitRequestCommand request, CancellationToken cancellationToken)
        {
            var visitRequest = await _context.VisitRequests.FindAsync(request.Id);

            if (visitRequest == null)
                throw new Exception($"VisitRequest with ID {request.Id} not found.");

            visitRequest.UserId = request.UserId;
            visitRequest.AnimalId = request.AnimalId;
            visitRequest.VisitDate = request.VisitDate;
            visitRequest.Note = request.Note;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}