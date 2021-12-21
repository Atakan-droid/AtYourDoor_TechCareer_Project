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
    public class CategoryDal : EfEntityRepository<Category, EfTechCareer_Final_DBContext>, ICategoryDal
    {
        
    }
}
