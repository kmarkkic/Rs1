using Market.Application.UdomiMe_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Breeds.Commands.CreateBreed
{
    public record CreateBreedCommand(int ID, string Name, int AnimalTypeId) : IRequest<BreedsDTO>;
}
