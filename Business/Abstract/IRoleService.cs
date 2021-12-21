using AuthManager.Entities;
using Business.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleService
    {
        Result<Roles> AddRole(Roles role);
        Result<Roles> UpdateRole(int roleId, Roles role);
        Result<Roles> DeleteRole(int roleId);
        Result<Roles> HardDeleteRole(int roleId);
        Result<Roles> GetRoleById(int roleId);
        Result<List<Roles>> GetRoles();
    }
}
