using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.Shelter.Queries.GetAllShelters
{
    public class GetAllSheltersQueryHandler : IRequestHandler<GetAllSheltersQuery, List<ShelterDTO>>
    {
        private readonly IAppDbContext _context;

        public GetAllSheltersQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShelterDTO>> Handle(GetAllSheltersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Shelters
                .Select(s => new ShelterDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    PhoneNumber = s.PhoneNumber,
                    CityId = s.CityId
                })
                .ToListAsync(cancellationToken);
        }
    }
}