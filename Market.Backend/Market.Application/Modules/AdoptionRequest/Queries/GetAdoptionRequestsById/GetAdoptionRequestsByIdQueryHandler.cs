using Market.Application.UdomiMe_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequest.Queries.GetAdoptionRequestsById
{
    public class GetAdoptionRequestsByIdQueryHandler : IRequestHandler<GetAdoptionRequestsByIdQuery, AdoptionRequestDTO>
    {
        private readonly IAppDbContext _context;

        public GetAdoptionRequestsByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<AdoptionRequestDTO> Handle(GetAdoptionRequestsByIdQuery request, CancellationToken cancellationToken)
        {
            var adoptionRequest = await _context.AdoptionRequests
                .Where(ar => ar.Id == request.Id && !ar.IsDeleted)
                .Select(ar => new AdoptionRequestDTO
                {
                    Id = ar.Id,
                    UserId = ar.UserId,
                    AnimalId = ar.AnimalId,
                    Message = ar.Message,
                    StatusId = ar.StatusId
                })
                .FirstOrDefaultAsync(cancellationToken);

            return adoptionRequest;
        }
    }
}   