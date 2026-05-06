using Market.Application.UdomiMe_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Cities.Commands.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CityDTO>
    {
        private readonly IAppDbContext _context;
        public CreateCityCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<CityDTO> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = new City
            {
                Name = request.Name,
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow
            };
            _context.Cities.Add(city);
            await _context.SaveChangesAsync(cancellationToken);
            return new CityDTO
            {
                Id = city.Id,
                Name = city.Name
            };
        }
    }
}
