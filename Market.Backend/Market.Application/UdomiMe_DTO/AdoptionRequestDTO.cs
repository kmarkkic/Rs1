using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.UdomiMe_DTO
{
    public class AdoptionRequestDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AnimalId { get; set; }
        public string Message { get; set; }
        public int StatusId { get; set; }

        // Pomoćna polja za prikaz na frontendu
        public string UserFullName { get; set; } // Mapiraš iz Users (Firstname + Lastname)
        public string AnimalName { get; set; }   // Mapiraš iz Animals
        public string StatusName { get; set; }   // Mapiraš iz AdoptionRequestStatuses
    }
}
