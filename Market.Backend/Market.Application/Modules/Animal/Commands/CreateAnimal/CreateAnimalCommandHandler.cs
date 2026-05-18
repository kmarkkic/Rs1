
namespace Market.Application.Modules.Animal.Commands.CreateAnimal
{
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateAnimalCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            var animal = new Domain.Entities.UdomiMe.Animal
            {
                Name = request.Name,
                Description = request.Description,
                Age = request.Age,
                Gender = request.Gender,
                BreedId = request.BreedId,
                AnimalTypeId = request.AnimalTypeId,
                ShelterId = request.ShelterId,
                OwnerId = request.OwnerId,
                CityId = request.CityId,    
                AnimalStatusId = request.AnimalStatusId,
                IsVaccinated = request.IsVaccinated,
                IsSterilized = request.IsSterilized
            };

            _context.Animals.Add(animal);
            await _context.SaveChangesAsync(cancellationToken);

            return (int)animal.Id;
        }
    }
}