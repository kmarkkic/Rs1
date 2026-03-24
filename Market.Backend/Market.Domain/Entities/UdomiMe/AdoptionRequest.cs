using Market.Domain.Common;
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
        public User User { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public string Message { get; set; }

        public int StatusId { get; set; }
        public AdoptionRequestStatus Status { get; set; }
    }
}
