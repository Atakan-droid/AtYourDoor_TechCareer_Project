using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthManager.Entities
{
    public class Roles:EntityBase,IEntity
    {
        public string Role { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
