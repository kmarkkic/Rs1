using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.UdomiMe_DTO
{
    public class AdoptionRequestCreateDTO
    {
        public int UserId { get; set; }
        public int AnimalId { get; set; }
        public string Message { get; set; }
        // StatusId ne šalješ s fronta, njega fiksno postaviš u Handleru (npr. na status "Pending")
    }
}
