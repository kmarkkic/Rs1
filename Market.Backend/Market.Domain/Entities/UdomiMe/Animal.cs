using Market.Domain.Common;
using Market.Domain.Entities.Identity;

namespace Market.Domain.Entities.UdomiMe
{
    public class Animal : BaseEntity
    {
        public string Name { get; set; }

        public int OwnerId { get; set; }

        // Ostavljamo samo jedan ispravan Owner property
        public MarketUserEntity Owner { get; set; }

        public string Description { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsSterilized { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public int AnimalTypeId { get; set; }
        public AnimalType AnimalType { get; set; }

        public int? BreedId { get; set; }
        public Breed? Breed { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int? ShelterId { get; set; }
        public Shelter? Shelter { get; set; }

        public int AnimalStatusId { get; set; }
        public AnimalStatus AnimalStatus { get; set; }

        public ICollection<AnimalImage> AnimalImages { get; set; } = new List<AnimalImage>();
        public ICollection<Favourite> Favorites { get; set; } = new List<Favourite>();
        public ICollection<AdoptionRequest> AdoptionRequests { get; set; } = new List<AdoptionRequest>();
        public ICollection<VisitRequest> VisitRequests { get; set; } = new List<VisitRequest>();
    }
}