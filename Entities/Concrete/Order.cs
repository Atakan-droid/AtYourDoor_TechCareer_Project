using Entities.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order:EntityBase,IEntity
    {
        public List<Product> Products { get; set; }
        public bool isReady { get; set; } = false;
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int CourierId { get; set; }
        public bool isDelivered { get; set; } = false;
        public string DeliveryNote { get; set; }
    }
}
