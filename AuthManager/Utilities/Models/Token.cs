using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthManager.Utilities.Models
{
    public class Token
    {
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }
        public bool isActive { get; set; }
    }
}
