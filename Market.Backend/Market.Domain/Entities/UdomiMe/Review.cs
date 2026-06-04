using Market.Domain.Common;
using Market.Domain.Entities.Identity;

namespace Market.Domain.Entities.UdomiMe
{
    public class Review : BaseEntity
    {
        public int UserId { get; set; }
        public MarketUserEntity User { get; set; }
        public int ShelterId { get; set; }
        public Shelter Shelter { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}