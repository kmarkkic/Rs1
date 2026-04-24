using Market.Domain.Common;
using Market.Domain.Entities.Identity;

namespace Market.Domain.Entities.UdomiMe
{
    public class AdoptionRequest : BaseEntity
    {
        public int UserId { get; set; }

       
        public MarketUserEntity User { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public string Message { get; set; }

        public int StatusId { get; set; }
        public AdoptionRequestStatus Status { get; set; }
    }
}