using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.UdomiMe
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Favourite> Favorites { get; set; } = new List<Favourite>();
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
        public ICollection<AdoptionRequest> AdoptionRequests { get; set; } = new List<AdoptionRequest>();
        public ICollection<VisitRequest> VisitRequests { get; set; } = new List<VisitRequest>();
    }
}
