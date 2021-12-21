using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace AuthManager.Utilities.SecurityKeyHelper
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
