using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.AdoptionRequest.Commands.AdoptionRequestDelete
{
    public record AdoptionRequestDeleteCommand(int Id) : IRequest;
}
