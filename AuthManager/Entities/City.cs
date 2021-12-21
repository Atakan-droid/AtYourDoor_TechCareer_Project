using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthManager.Entities
{
    public class City:IEntity
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public ICollection<County> Counties { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
