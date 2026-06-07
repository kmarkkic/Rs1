using Market.Application.UdomiMe_DTO;
using Market.Application.Common;

namespace Market.Application.Modules.Animal.Queries.GetAnimals
{
    public class GetAnimalsQueryHandler : IRequestHandler<GetAnimalsQuery, PageResult<AnimalDTO>>
    {
        private readonly IAppDbContext _context;

        public GetAnimalsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PageResult<AnimalDTO>> Handle(GetAnimalsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Animals
                .Include(x => x.Breed)
                .Include(x => x.AnimalType)
                .Include(x => x.Shelter)
                .Include(x => x.AnimalStatus)
                .Include(x => x.AnimalImages)
                .Where(x => !x.IsDeleted)
                .Where(x => request.Name == null || x.Name.Contains(request.Name))
                .Where(x => request.AnimalTypeId == null || x.AnimalTypeId == request.AnimalTypeId)
                .Where(x => request.BreedId == null || x.BreedId == request.BreedId)
                .Where(x => request.Age == null || x.Age == request.Age)
                .Where(x => request.AnimalStatusId == null || x.AnimalStatusId == request.AnimalStatusId)
                .Where(x => request.Gender == null || x.Gender == request.Gender)
                .Select(animal => new AnimalDTO
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
                });

            return await PageResult<AnimalDTO>.FromQueryableAsync(query, request.Paging, cancellationToken);
        }
    }
}