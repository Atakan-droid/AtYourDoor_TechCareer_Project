using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderDeliveryDTO
    {
        public int OrderId { get; set; }
        public int CourierId { get; set; }
        public string Note { get; set; }
        public bool IsDelivered { get; set; }
    }
}
