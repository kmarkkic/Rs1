using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.Shelter.Commands.UpdateShelter
{
    public class UpdateShelterCommandHandler : IRequestHandler<UpdateShelterCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public UpdateShelterCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateShelterCommand request, CancellationToken cancellationToken)
        {
            var shelter = await _context.Shelters.FindAsync(request.Id);

            if (shelter == null)
                throw new Exception($"Shelter with ID {request.Id} not found.");

            shelter.Name = request.Name;
            shelter.Address = request.Address;
            shelter.PhoneNumber = request.PhoneNumber;
            shelter.CityId = request.CityId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}