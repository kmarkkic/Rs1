using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.UdomiMe
{
    public class AnimalImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
