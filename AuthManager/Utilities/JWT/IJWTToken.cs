using AuthManager.Entities;
using AuthManager.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthManager.Utilities.JWT
{
    public interface IJWTToken
    {
        Token CreateToken(User user,Roles roles);
    }
}
