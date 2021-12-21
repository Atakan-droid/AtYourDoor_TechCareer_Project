using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthManager.Utilities.TokenOptions
{
    public class TokenOption
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecurityKey { get; set; }
        public double AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
    }
}
