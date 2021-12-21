using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthManager.Entities.DTOs
{
    public class UserRegisterDTO
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public string PasswordControl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
