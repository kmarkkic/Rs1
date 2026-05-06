using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Cities.Commands.CreateCity
{
    public class CreateCityCommand : IRequest<CityDTO>
    {
        public string Name { get; set; }
    }
}
