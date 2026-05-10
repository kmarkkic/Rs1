using Market.Application.UdomiMe_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Cities.Queries.GetCitiesById
{
    public class GetCitiesByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDTO>
    {
        private readonly IAppDbContext _context;
        public GetCitiesByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<CityDTO> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await _context.Cities
                .Where(c => c.Id == request.Id && !c.IsDeleted)
                .Select(c => new CityDTO
                {
                    Id = c.Id,
                    Name = c.Name
                }).FirstOrDefaultAsync(cancellationToken);

            if (city == null)
                throw new Exception($"City with ID {request.Id} not found.");

            return city;
        }
    }
}
