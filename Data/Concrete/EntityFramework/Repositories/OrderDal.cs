using Data.Abstract;
using Data.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework.Repositories
{
    public class OrderDal : EfEntityRepository<Order, EfTechCareer_Final_DBContext>, IOrderDal
    {
        public List<Order> GetAllOrdersRelatedToCounty(int countyId)
        {
            using (EfTechCareer_Final_DBContext context = new EfTechCareer_Final_DBContext())
            {
                var result = from c in context.Counties
                             join a in context.Addresses
                             on
                             c.Id equals a.CountyId
                             join u in context.Orders
                             on
                             a.Id equals u.AddressId
                             
                             where c.Id == countyId && u.isDelivered==false
                             select u;


                return result.ToList();
            }
        }
    }
}
