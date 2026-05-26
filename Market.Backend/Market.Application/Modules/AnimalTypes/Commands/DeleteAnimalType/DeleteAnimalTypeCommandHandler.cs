using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.AnimalTypes.Commands.DeleteAnimalType
{
    public class DeleteAnimalTypeCommandHandler : IRequestHandler<DeleteAnimalTypeCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public DeleteAnimalTypeCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAnimalTypeCommand request, CancellationToken cancellationToken)
        {
            var animalType = await _context.AnimalTypes.FindAsync(request.Id);

            if (animalType == null)
                throw new Exception($"AnimalType with ID {request.Id} not found.");

            _context.AnimalTypes.Remove(animalType);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}