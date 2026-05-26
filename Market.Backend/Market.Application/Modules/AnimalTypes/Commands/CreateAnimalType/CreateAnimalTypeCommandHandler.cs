using MediatR;
using Market.Application.Abstractions;

namespace Market.Application.Modules.AnimalTypes.Commands.CreateAnimalType
{
    public class CreateAnimalTypeCommandHandler : IRequestHandler<CreateAnimalTypeCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateAnimalTypeCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAnimalTypeCommand request, CancellationToken cancellationToken)
        {
            var animalType = new Domain.Entities.UdomiMe.AnimalType
            {
                Name = request.Name
            };

            _context.AnimalTypes.Add(animalType);
            await _context.SaveChangesAsync(cancellationToken);

            return (int)animalType.Id;
        }
    }
}