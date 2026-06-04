using Market.Domain.Common;
using Market.Domain.Entities.Identity;

namespace Market.Domain.Entities.UdomiMe
{
    public class Notification : BaseEntity
    {
        public int UserId { get; set; }
        public MarketUserEntity User { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}