using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthManager.Entities
{
    public class User:EntityBase,IEntity
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleID { get; set; }
        public Roles Role { get; set; }
        public ICollection<Address> Address { get; set; }
    }
}
