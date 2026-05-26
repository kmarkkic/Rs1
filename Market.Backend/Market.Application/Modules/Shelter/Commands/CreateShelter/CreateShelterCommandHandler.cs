using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.Shelter.Commands.CreateShelter
{
    public class CreateShelterCommandHandler : IRequestHandler<CreateShelterCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateShelterCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateShelterCommand request, CancellationToken cancellationToken)
        {
            var shelter = new Domain.Entities.UdomiMe.Shelter
            {
                Name = request.Name,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                CityId = request.CityId
            };

            _context.Shelters.Add(shelter);
            await _context.SaveChangesAsync(cancellationToken);

            return (int)shelter.Id;
        }
    }
}