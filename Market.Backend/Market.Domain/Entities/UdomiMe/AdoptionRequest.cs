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
    public class AdoptionRequest : BaseEntity 
    {
        public int UserId { get; set; }
<<<<<<< HEAD
        public User User { get; set; }
=======
        public MarketUserEntity User { get; set; }
>>>>>>> 74087fd (Initial commit)
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public string Message { get; set; }

        public int StatusId { get; set; }
        public AdoptionRequestStatus Status { get; set; }
    }
}
