using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Cities.Queries.GetCitites
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, List<CityDTO>>
    {
        private readonly IAppDbContext _context;
        public GetCitiesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CityDTO>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Cities
                .Where(c => !c.IsDeleted)
                .Select(c => new CityDTO
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync(cancellationToken);
        }
    }
}
