using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.UdomiMe_DTO
{
    public class AnimalCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int BreedId { get; set; }
        public int AnimalTypeId { get; set; }
        public int ShelterId { get; set; }
        public int AnimalStatusId { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsSterilized { get; set; }
    }

}
