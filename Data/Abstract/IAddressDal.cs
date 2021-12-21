using AuthManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IAddressDal: IEntityRepository<Address>
    {
        List<Address> GetAddressByCityId(int cityId);
    }
}
