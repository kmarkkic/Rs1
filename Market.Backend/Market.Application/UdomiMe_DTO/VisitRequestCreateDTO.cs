using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.UdomiMe_DTO
{
    public class VisitRequestCreateDTO
    {
        public int UserId { get; set; }
        public int AnimalId { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
