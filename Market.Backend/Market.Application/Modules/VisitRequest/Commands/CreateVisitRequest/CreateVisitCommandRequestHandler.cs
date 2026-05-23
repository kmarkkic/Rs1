using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.VisitRequest.Commands.CreateVisitRequest
{
    public class CreateVisitRequestCommandHandler : IRequestHandler<CreateVisitRequestCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateVisitRequestCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateVisitRequestCommand request, CancellationToken cancellationToken)
        {
            var visitRequest = new Domain.Entities.UdomiMe.VisitRequest
            {
                UserId = request.UserId,
                AnimalId = request.AnimalId,
                VisitDate = request.VisitDate,
                Note = request.Note
            };

            _context.VisitRequests.Add(visitRequest);
            await _context.SaveChangesAsync(cancellationToken);

            return (int)visitRequest.Id;
        }
    }
}