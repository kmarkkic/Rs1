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
    public class VisitRequest : BaseEntity
    {
        public int UserId { get; set; }
<<<<<<< HEAD
        public User User { get; set; }
=======
        public MarketUserEntity User { get; set; }
>>>>>>> 74087fd (Initial commit)
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
