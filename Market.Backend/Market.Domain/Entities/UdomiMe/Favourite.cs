using System;
using Market.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.UdomiMe 
{
    public class Favourite : BaseEntity
    {
        int UserId { get; set; }
        public User User { get; set; }
        int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
