using Market.Application.UdomiMe_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequest.Queries.GetAdoptionRequests
{
    public class GetAdoptionRequestsQueryHandler : IRequestHandler<GetAdoptionRequestsQuery, List<AdoptionRequestDTO>>
    {
        private readonly IAppDbContext _context;

        public GetAdoptionRequestsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public Task<List<AdoptionRequestDTO>> Handle(GetAdoptionRequestsQuery request, CancellationToken cancellationToken)
        {
            var result = _context.AdoptionRequests
                .Select(ar => new AdoptionRequestDTO
                {
                    Id = ar.Id,
                    UserId = ar.UserId,
                    AnimalId = ar.AnimalId,
                    Message = ar.Message,
                    StatusId = ar.StatusId
                })
                .ToList();

            return Task.FromResult(result); 
        }
    }
}
