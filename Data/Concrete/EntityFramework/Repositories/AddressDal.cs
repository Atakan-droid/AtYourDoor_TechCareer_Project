using AuthManager.Entities;
using Data.Abstract;
using Data.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework.Repositories
{
    public class AddressDal : EfEntityRepository<Address, EfTechCareer_Final_DBContext>, IAddressDal
    {
        public List<Address> GetAddressByCityId(int cityId)
        {
            using (EfTechCareer_Final_DBContext context = new EfTechCareer_Final_DBContext())
            {
                var result = from c in context.Cities
                             join a in context.Counties
                             on
                             c.Id equals a.CityId
                             join u in context.Addresses
                             on
                             a.Id equals u.CountyId
                             where c.Id == cityId
                             select u;


                return result.ToList();
            }
        }
    }
}
