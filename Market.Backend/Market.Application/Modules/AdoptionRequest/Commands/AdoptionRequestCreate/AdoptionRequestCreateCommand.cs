using Market.Application.UdomiMe_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequest.Commands.AdoptionRequestCreate
{
    public record AdoptionRequestCreateCommand( int Id, int UserId, int AnimalId, string Message, int StatusId ) : IRequest<AdoptionRequestDTO>;
}
