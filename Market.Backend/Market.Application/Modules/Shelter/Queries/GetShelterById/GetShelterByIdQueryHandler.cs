using MediatR;
using Market.Application.Abstractions;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.Shelter.Queries.GetShelterById
{
    public class GetShelterByIdQueryHandler : IRequestHandler<GetShelterByIdQuery, ShelterDTO>
    {
        private readonly IAppDbContext _context;

        public GetShelterByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ShelterDTO> Handle(GetShelterByIdQuery request, CancellationToken cancellationToken)
        {
            var shelter = await _context.Shelters
                .Where(s => s.Id == request.Id)
                .Select(s => new ShelterDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    PhoneNumber = s.PhoneNumber,
                    CityId = s.CityId
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (shelter == null)
                throw new Exception($"Shelter with ID {request.Id} not found.");

            return shelter;
        }
    }
}