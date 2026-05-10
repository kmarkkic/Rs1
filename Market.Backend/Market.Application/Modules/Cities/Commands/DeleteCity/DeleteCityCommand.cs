using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Cities.Commands.DeleteCity
{
    public record DeleteCityCommand(int Id) : IRequest; 
 
}
