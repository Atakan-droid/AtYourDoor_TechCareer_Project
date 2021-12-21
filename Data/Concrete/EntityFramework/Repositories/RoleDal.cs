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
    public class RoleDal: EfEntityRepository<Roles, EfTechCareer_Final_DBContext>, IRoleDal
    {
    }
}
