using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.UdomiMe_DTO
{
    public class BreedsDTO
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnimalTypeId { get; set; }


        public AnimalTypesDTO AnimalType { get; set; }
    }
}
