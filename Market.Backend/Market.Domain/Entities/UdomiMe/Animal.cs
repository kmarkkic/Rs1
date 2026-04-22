using Market.Domain.Common;
<<<<<<< HEAD
=======
using Market.Domain.Entities.Identity;
>>>>>>> 74087fd (Initial commit)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.UdomiMe
{
    public class Animal : BaseEntity
    {
        public string Name { get; set; }

        public int OwnerId { get; set; }
<<<<<<< HEAD
        public User Owner { get; set; }
=======
        public MarketUserEntity Owner { get; set; }
>>>>>>> 74087fd (Initial commit)

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
