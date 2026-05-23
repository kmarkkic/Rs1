using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.VisitRequest.Queries.GetAllVisitRequests
{
    public class GetAllVisitRequestsQueryHandler : IRequestHandler<GetAllVisitRequestsQuery, List<VisitRequestDTO>>
    {
        private readonly IAppDbContext _context;

        public GetAllVisitRequestsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<VisitRequestDTO>> Handle(GetAllVisitRequestsQuery request, CancellationToken cancellationToken)
        {
            return await _context.VisitRequests
                .Select(v => new VisitRequestDTO
                {
                    Id = v.Id,
                    UserId = v.UserId,
                    AnimalId = v.AnimalId,
                    VisitDate = v.VisitDate,
                    Note = v.Note
                })
                .ToListAsync(cancellationToken);
        }
    }
}