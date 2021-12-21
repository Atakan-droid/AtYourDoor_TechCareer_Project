using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthManager.Entities
{
    public class County:IEntity
    {
        public int Id { get; set; }
        public string CountyName { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
