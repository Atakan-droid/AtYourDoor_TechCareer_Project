using AuthManager.Entities;
using Data.Abstract;
using Data.Concrete.EntityFramework;
using Data.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework.Repositories
{
    public class UserDal: EfEntityRepository<User, EfTechCareer_Final_DBContext>,IUserDal
    {
        public bool GetCourierWithCounty(int countyId)
        {
            using (EfTechCareer_Final_DBContext context = new EfTechCareer_Final_DBContext())
            {
                var result = from c in context.Counties
                             join a in context.Addresses
                             on
                             c.Id equals a.CountyId
                             join u in context.Users
                             on
                             a.UserId equals u.Id
                             join r in context.Roles
                             on u.RoleID equals r.Id
                             where c.Id == countyId
                             select u;


                return result.Any();
            }
        }
        public List<User> GetCourierWithCountyId(int countyId)
        {
            using (EfTechCareer_Final_DBContext context = new EfTechCareer_Final_DBContext())
            {
                var result = from c in context.Counties
                             join a in context.Addresses
                             on
                             c.Id equals a.CountyId
                             join u in context.Users
                             on
                             a.UserId equals u.Id
                             join r in context.Roles
                             on
                             u.RoleID equals r.Id
                             where a.CountyId == countyId && r.Role=="Kargocu"
                             select u;


                return result.ToList();
            }
        }
        public bool CheckUserIsUYE(int userId)
        {
            using (EfTechCareer_Final_DBContext context = new EfTechCareer_Final_DBContext())
            {
                var result = from c in context.Users
                             join a in context.Roles
                             on
                             c.RoleID equals a.Id
                             where c.Id == userId && a.Role == "Uye"
                             select c;


                return result.Any();
            }
        }


    }
}
