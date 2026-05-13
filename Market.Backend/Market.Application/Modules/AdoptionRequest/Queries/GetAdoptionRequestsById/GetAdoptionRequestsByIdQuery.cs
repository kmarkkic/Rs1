using Market.Application.UdomiMe_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequest.Queries.GetAdoptionRequestsById
{
    public record GetAdoptionRequestsByIdQuery(int Id) : IRequest<AdoptionRequestDTO>;
}
