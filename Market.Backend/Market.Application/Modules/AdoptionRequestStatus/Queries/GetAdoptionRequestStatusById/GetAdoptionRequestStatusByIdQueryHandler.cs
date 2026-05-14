using Market.Application.UdomiMe_DTO.Adoptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequestStatus.Queries.GetAdoptionRequestStatusById
{
    public class GetAdoptionRequestStatusByIdQueryHandler : IRequestHandler<GetAdoptionRequestStatusByIdQuery, AdoptionRequestStatusesDTO>
    {
        IAppDbContext _context;

        public GetAdoptionRequestStatusByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<AdoptionRequestStatusesDTO> Handle(GetAdoptionRequestStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.AdoptionRequestStatuses.Where(x => x.Id == request.Id && !x.IsDeleted)
                .Select(x => new AdoptionRequestStatusesDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).FirstOrDefaultAsync(cancellationToken);
            if (result == null)
            {
                throw new Exception ("Adoption request status not found");  
            }
            return result;
        }
    }
}
