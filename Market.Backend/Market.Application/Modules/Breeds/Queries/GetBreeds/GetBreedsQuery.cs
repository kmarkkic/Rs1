using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Breeds.Queries.GetBreeds
{
    public record GetBreedsQuery : IRequest<IReadOnlyList<BreedsDTO>>;

}
