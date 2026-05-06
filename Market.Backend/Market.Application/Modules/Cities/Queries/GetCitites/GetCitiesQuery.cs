using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Application.UdomiMe_DTO;
using MediatR;

namespace Market.Application.Modules.Cities.Queries.GetCitites
{
    public class GetCitiesQuery : IRequest<List<CityDTO>>
    {
    }
}
