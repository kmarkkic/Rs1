using Market.Domain.Common;

namespace Market.Domain.Entities.UdomiMe
{
    public class AnimalHealthRecord : BaseEntity
    {
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string VetName { get; set; }
    }
}