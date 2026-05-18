using Market.Application.UdomiMe_DTO;

namespace Market.Application.Modules.Favourites.Queries.GetFavouritesByUser
{
    public class GetFavouritesByUserQueryHandler : IRequestHandler<GetFavouritesByUserQuery, List<FavouritesDTO>>
    {
        private readonly IAppDbContext _context;

        public GetFavouritesByUserQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FavouritesDTO>> Handle(GetFavouritesByUserQuery request, CancellationToken cancellationToken)
        {
            return await _context.Favourites
                .Include(x => x.Animal)
                    .ThenInclude(a => a.Breed)
                .Include(x => x.Animal)
                    .ThenInclude(a => a.AnimalType)
                .Include(x => x.Animal)
                    .ThenInclude(a => a.Shelter)
                .Include(x => x.Animal)
                    .ThenInclude(a => a.AnimalStatus)
                .Include(x => x.Animal)
                    .ThenInclude(a => a.AnimalImages)
                .Where(x => x.UserId == request.UserId && !x.IsDeleted)
                .Select(x => new FavouritesDTO
                {
                    Id = (int)x.Id,
                    UserId = x.UserId,
                    AnimalId = x.AnimalId,
                    Animal = new AnimalDTO
                    {
                        Id = (int)x.Animal.Id,
                        Name = x.Animal.Name,
                        Description = x.Animal.Description,
                        Age = x.Animal.Age,
                        Gender = x.Animal.Gender,
                        BreedId = (int)x.Animal.BreedId,
                        AnimalTypeId = x.Animal.AnimalTypeId,
                        ShelterId = (int)x.Animal.ShelterId,
                        OwnerId = x.Animal.OwnerId,
                        AnimalStatusId = x.Animal.AnimalStatusId,
                        IsVaccinated = x.Animal.IsVaccinated,
                        IsSterilized = x.Animal.IsSterilized,
                        Breed = x.Animal.Breed == null ? null : new BreedsDTO { Id = (int)x.Animal.Breed.Id, Name = x.Animal.Breed.Name },
                        AnimalType = x.Animal.AnimalType == null ? null : new AnimalTypesDTO { Id = (int)x.Animal.AnimalType.Id, Name = x.Animal.AnimalType.Name },
                        Shelter = x.Animal.Shelter == null ? null : new ShelterDTO { Id = (int)x.Animal.Shelter.Id, Name = x.Animal.Shelter.Name },
                        AnimalStatus = x.Animal.AnimalStatus == null ? null : new AnimalStatusDTO { Id = (int)x.Animal.AnimalStatus.Id, Name = x.Animal.AnimalStatus.Name },
                        Images = x.Animal.AnimalImages.Select(img => new AnimalImagesDTO
                        {
                            Id = (int)img.Id,
                            ImageUrl = img.ImageUrl
                        }).ToList()
                    }
                })
                .ToListAsync(cancellationToken);
        }
    }
}