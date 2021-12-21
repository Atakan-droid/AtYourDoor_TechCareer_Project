using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IOrderDal: IEntityRepository<Order>
    {
        List<Order> GetAllOrdersRelatedToCounty(int countyId);
    }
}
