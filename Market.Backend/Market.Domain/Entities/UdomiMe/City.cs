using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.UdomiMe
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
        public ICollection<Shelter> Shelters { get; set; } = new List<Shelter>();

        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
