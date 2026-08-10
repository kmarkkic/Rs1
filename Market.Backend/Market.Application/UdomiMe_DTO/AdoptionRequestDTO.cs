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
        public DateTime CreatedAtUtc { get; set; }

        // Podaci za prikaz na frontendu (bez dodatnih poziva)
        public string AnimalName { get; set; }
        public string AnimalImageUrl { get; set; }
        public string StatusName { get; set; }
        public string ApplicantFullName { get; set; }
    }
}
