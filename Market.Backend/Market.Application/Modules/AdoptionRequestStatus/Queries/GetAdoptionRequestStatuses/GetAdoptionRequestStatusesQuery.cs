using Market.Application.UdomiMe_DTO.Adoptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequestStatus.Queries.GetAdoptionRequest
{
    public record GetAdoptionRequestStatusesQuery : IRequest<List<AdoptionRequestStatusesDTO>>;
}
