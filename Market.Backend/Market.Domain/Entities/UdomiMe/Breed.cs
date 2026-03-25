using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.UdomiMe
{
    public class Breed : BaseEntity
    {
        public string Name { get; set; }
        public int AnimalTypeId { get; set; }
        public AnimalType AnimalType { get; set; }
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}
