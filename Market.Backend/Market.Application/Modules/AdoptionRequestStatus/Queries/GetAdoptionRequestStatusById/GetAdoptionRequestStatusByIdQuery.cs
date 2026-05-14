using Market.Application.UdomiMe_DTO.Adoptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequestStatus.Queries.GetAdoptionRequestStatusById
{
    public record GetAdoptionRequestStatusByIdQuery(int Id) : IRequest<AdoptionRequestStatusesDTO>;
    
}
