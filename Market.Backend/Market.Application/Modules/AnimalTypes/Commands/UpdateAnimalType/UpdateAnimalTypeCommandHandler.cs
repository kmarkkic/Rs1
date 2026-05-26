using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.AnimalTypes.Commands.UpdateAnimalType
{
    public class UpdateAnimalTypeCommandHandler : IRequestHandler<UpdateAnimalTypeCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public UpdateAnimalTypeCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAnimalTypeCommand request, CancellationToken cancellationToken)
        {
            var animalType = await _context.AnimalTypes.FindAsync(request.Id);

            if (animalType == null)
                throw new Exception($"AnimalType with ID {request.Id} not found.");

            animalType.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}