using Market.Domain.Common;
using Market.Domain.Entities.Identity;

namespace Market.Domain.Entities.UdomiMe
{
    public class Message : BaseEntity
    {
        public int SenderId { get; set; }
        public MarketUserEntity Sender { get; set; }
        public int ReceiverId { get; set; }
        public MarketUserEntity Receiver { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
    }
}