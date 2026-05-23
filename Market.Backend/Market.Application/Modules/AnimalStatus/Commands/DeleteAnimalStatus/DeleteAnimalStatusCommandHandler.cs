using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.AnimalStatus.Commands.DeleteAnimalStatus
{
    public class DeleteAnimalStatusCommandHandler : IRequestHandler<DeleteAnimalStatusCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public DeleteAnimalStatusCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAnimalStatusCommand request, CancellationToken cancellationToken)
        {
            var animalStatus = await _context.AnimalStatuses.FindAsync(request.Id);

            if (animalStatus == null)
                throw new Exception($"AnimalStatus with ID {request.Id} not found.");

            _context.AnimalStatuses.Remove(animalStatus);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}