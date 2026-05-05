using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.UdomiMe_DTO
{
    public class AnimalUpdateDTO : AnimalCreateDTO
    {
        public int Id { get; set; } // KLJUČNO!
        public bool IsAdopted { get; set; }
        public int AnimalStatusId { get; set; }
    }
}
