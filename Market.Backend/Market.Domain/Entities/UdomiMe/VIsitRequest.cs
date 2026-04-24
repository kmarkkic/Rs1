using Market.Domain.Common;
using Market.Domain.Entities.Identity;
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

        // Zadržavamo verziju s MarketUserEntity jer je to Aminov popravak
        public MarketUserEntity User { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public DateTime VisitDate { get; set; }
    }
}