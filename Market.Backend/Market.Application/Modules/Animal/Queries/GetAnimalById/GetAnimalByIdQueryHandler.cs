using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Animal.Queries.GetAnimalById
{
    public class GetAnimalByIdQueryHandler : IRequestHandler<GetAnimalByIdQuery, AnimalDTO>
    {
        private readonly IAppDbContext _context;

        public GetAnimalByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<AnimalDTO> Handle(GetAnimalByIdQuery request, CancellationToken cancellationToken)
        {
            var animal = await _context.Animals
                .Include(x => x.Breed)
                .Include(x => x.AnimalType)
                .Include(x => x.Shelter)
                .Include(x => x.AnimalStatus)
                .Include(x => x.AnimalImages)
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);

            if (animal == null)
                throw new Exception("Animal not found");

            return new AnimalDTO
            {
                Id = (int)animal.Id,
                Name = animal.Name,
                Description = animal.Description,
                Age = animal.Age,
                Gender = animal.Gender,
                BreedId = (int)animal.BreedId,
                AnimalTypeId = animal.AnimalTypeId,
                ShelterId = (int)animal.ShelterId,
                OwnerId = animal.OwnerId,
                CityId = animal.CityId,
                AnimalStatusId = animal.AnimalStatusId,
                IsVaccinated = animal.IsVaccinated,
                IsSterilized = animal.IsSterilized,
                Breed = animal.Breed == null ? null : new BreedsDTO { Id = (int)animal.Breed.Id, Name = animal.Breed.Name },
                AnimalType = animal.AnimalType == null ? null : new AnimalTypesDTO { Id = (int)animal.AnimalType.Id, Name = animal.AnimalType.Name },
                Shelter = animal.Shelter == null ? null : new ShelterDTO { Id = (int)animal.Shelter.Id, Name = animal.Shelter.Name },
                AnimalStatus = animal.AnimalStatus == null ? null : new AnimalStatusDTO { Id = (int)animal.AnimalStatus.Id, Name = animal.AnimalStatus.Name },
                Images = animal.AnimalImages.Select(img => new AnimalImagesDTO
                {
                    Id = (int)img.Id,
                    ImageUrl = img.ImageUrl
                }).ToList()
            };
        }
    }
}