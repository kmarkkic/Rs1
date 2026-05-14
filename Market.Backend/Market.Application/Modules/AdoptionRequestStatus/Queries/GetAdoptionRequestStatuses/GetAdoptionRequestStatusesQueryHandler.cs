using Market.Application.Modules.AdoptionRequestStatus.Queries.GetAdoptionRequest;
using Market.Application.UdomiMe_DTO.Adoptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequestStatus.Queries.GetAdoptionRequests
{
    public class GetAdoptionRequestStatusesQueryHandler : IRequestHandler<GetAdoptionRequestStatusesQuery, List<AdoptionRequestStatusesDTO>>
    {
        IAppDbContext _context;

        public GetAdoptionRequestStatusesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<AdoptionRequestStatusesDTO>> Handle(GetAdoptionRequestStatusesQuery request, CancellationToken cancellationToken)
        {
            var result = (await _context.AdoptionRequestStatuses.ToListAsync(cancellationToken)).Select(x => new AdoptionRequestStatusesDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return result;
        }
    }
}
