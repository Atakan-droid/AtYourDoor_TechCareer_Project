using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : EntityBase, IEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
     
        public string Image { get; set; } = "unnamed.jpg";
        public decimal Discount { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal DiscountedUnitPrice { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

    

    }
}
