namespace Market.Application.Modules.Animal.Commands.UpdateAnimal
{
    public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateAnimalCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
        {
            var animal = await _context.Animals
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);

            if (animal == null)
                throw new Exception("Animal not found");

            animal.Name = request.Name;
            animal.Description = request.Description;
            animal.Age = request.Age;
            animal.Gender = request.Gender;
            animal.BreedId = request.BreedId;
            animal.AnimalTypeId = request.AnimalTypeId;
            animal.ShelterId = request.ShelterId;
            animal.OwnerId = request.OwnerId;
            animal.CityId = request.CityId;
            animal.AnimalStatusId = request.AnimalStatusId;
            animal.IsVaccinated = request.IsVaccinated;
            animal.IsSterilized = request.IsSterilized;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}