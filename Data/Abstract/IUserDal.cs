using AuthManager.Entities;
using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
       bool GetCourierWithCounty(int countyId);
        List<User> GetCourierWithCountyId(int countyId);
        bool CheckUserIsUYE(int userId);
    }
}
