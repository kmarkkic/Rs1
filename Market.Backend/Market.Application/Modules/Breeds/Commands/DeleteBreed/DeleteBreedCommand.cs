
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Breeds.Commands.DeleteBreed
{
     public record DeleteBreedCommand(int Id) : IRequest;

}
