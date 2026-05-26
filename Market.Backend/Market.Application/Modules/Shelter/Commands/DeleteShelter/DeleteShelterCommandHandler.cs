
using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.Shelter.Commands.DeleteShelter
{
    public class DeleteShelterCommandHandler : IRequestHandler<DeleteShelterCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public DeleteShelterCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteShelterCommand request, CancellationToken cancellationToken)
        {
            var shelter = await _context.Shelters.FindAsync(request.Id);

            if (shelter == null)
                throw new Exception($"Shelter with ID {request.Id} not found.");

            _context.Shelters.Remove(shelter);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}