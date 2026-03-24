using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.UdomiMe
{
    public class User : BaseEntity
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }  
        string PasswordHash { get; set; }
        string PhoneNumber { get; set; }
        DateTime DateOfBirth { get; set; }
        string Address { get; set; }
        bool IsAdmin { get; set; }

        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}
