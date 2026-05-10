using MediatR;
using Market.Application.UdomiMe_DTO;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.Cities.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, CityDTO>
    {
        private readonly IAppDbContext _context;

        public UpdateCityCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<CityDTO> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _context.Cities
                .FirstOrDefaultAsync(c => c.Id == request.Id && !c.IsDeleted, cancellationToken);

            if (city == null)
                throw new Exception("Grad nije pronađen");

            city.Name = request.Name;
            await _context.SaveChangesAsync(cancellationToken);

            return new CityDTO
            {
                Id = city.Id,
                Name = city.Name
            };
        }
    }
}