using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.AnimalStatus.Commands.UpdateAnimalStatus
{
    public class UpdateAnimalStatusCommandHandler : IRequestHandler<UpdateAnimalStatusCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public UpdateAnimalStatusCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAnimalStatusCommand request, CancellationToken cancellationToken)
        {
            var animalStatus = await _context.AnimalStatuses.FindAsync(request.Id);

            if (animalStatus == null)
                throw new Exception($"AnimalStatus with ID {request.Id} not found.");

            animalStatus.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}