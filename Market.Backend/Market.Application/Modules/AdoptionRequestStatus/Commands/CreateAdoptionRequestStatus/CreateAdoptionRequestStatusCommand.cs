using Market.Application.UdomiMe_DTO.Adoptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequestStatus.Commands.CreateAdoptionRequestStatus
{
     public record CreateAdoptionRequestStatusCommand(int Id, string Name) : IRequest<AdoptionRequestStatusesDTO>;
 }
