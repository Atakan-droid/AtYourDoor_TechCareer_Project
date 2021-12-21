using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderAddDTO
    {
        public List<ProductToOrderDTO> Products { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
    }
}
