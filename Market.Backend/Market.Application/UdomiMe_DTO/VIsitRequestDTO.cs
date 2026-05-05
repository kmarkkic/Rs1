using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.UdomiMe_DTO
{
    public class VisitRequestDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AnimalId { get; set; }
        public DateTime VisitDate { get; set; }

        // Objekti da na listi vidiš tko dolazi i koju životinju posjećuje
        public string UserFullName { get; set; }
        public string AnimalName { get; set; }
    }
}
