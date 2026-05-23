using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.VisitRequest.Queries.GetVisitRequestById
{
    public class GetVisitRequestByIdQueryHandler : IRequestHandler<GetVisitRequestByIdQuery, VisitRequestDTO>
    {
        private readonly IAppDbContext _context;

        public GetVisitRequestByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<VisitRequestDTO> Handle(GetVisitRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var visitRequest = await _context.VisitRequests
                .Where(v => v.Id == request.Id)
                .Select(v => new VisitRequestDTO
                {
                    Id = v.Id,
                    UserId = v.UserId,
                    AnimalId = v.AnimalId,
                    VisitDate = v.VisitDate,
                    Note = v.Note
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (visitRequest == null)
                throw new Exception($"VisitRequest with ID {request.Id} not found.");

            return visitRequest;
        }
    }
}