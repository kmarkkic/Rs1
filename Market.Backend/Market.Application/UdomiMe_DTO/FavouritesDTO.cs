using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.UdomiMe_DTO
{
    public class FavouritesDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AnimalId { get; set; }
        public AnimalDTO Animal { get; set; }
    }
     public class FavouritesCreateDTO
    {
        public int UserId { get; set; }
        public int AnimalId { get; set; }
    }
}
