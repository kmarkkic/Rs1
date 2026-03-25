using Market.Domain.Common;
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

        public User Owner { get; set; }

        public int AnimalTypeId { get; set; }

        public AnimalType AnimalType { get; set; }


        public int Age { get; set; }
        public string Description { get; set; }
        public int AnimalStatusId { get; set; }
        public AnimalStatus AnimalStatus { get; set; }

        public int shelterId { get; set; }
        public Shelter Shelter { get; set; }

       public int CityId { get; set; }
        public City City { get; set; }

        public Breed BreedId { get; set; }

        public Breed Breed { get; set; }

        public ICollection<AnimalImage> Images { get; set; } = new List<AnimalImage>();

        public ICollection<AdoptionRequest> AdoptionRequests { get; set; } = new List<AdoptionRequest>();

        public ICollection<VisitRequest> VisitRequest { get; set; } = new List<VisitRequest>(); 
        public ICollection<Favourite> Favorites { get; set; } = new List<Favourite>();

    }
}
