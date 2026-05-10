using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Application.UdomiMe_DTO;
using MediatR;

namespace Market.Application.Modules.Cities.Commands.UpdateCity
{
    public class UpdateCityCommand : IRequest<CityDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
