using Market.Domain.Common;
using Market.Domain.Entities.Identity;

namespace Market.Domain.Entities.UdomiMe
{
    public class Favourite : BaseEntity
    {
        public int UserId { get; set; }

        // Brišemo dupli 'User' i ostavljamo onaj koji Aminov kod koristi
        public MarketUserEntity User { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}