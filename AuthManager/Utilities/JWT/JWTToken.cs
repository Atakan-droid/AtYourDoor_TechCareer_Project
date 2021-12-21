using AuthManager.Entities;
using AuthManager.Utilities.Models;
using AuthManager.Utilities.SecurityKeyHelper;
using AuthManager.Utilities.TokenOptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthManager.Utilities.JWT
{
    public class JWTToken : IJWTToken
    {
        public IConfiguration configuration { get; }
        TokenOption tokenOption;
        DateTime accessTokenExpiration;
        DateTime refreshTokenExpiration;
        public JWTToken(IConfiguration configuration)
        {
            this.configuration = configuration;
            tokenOption = configuration.GetSection("TokenOption").Get<TokenOption>();
            accessTokenExpiration = DateTime.Now.AddDays(tokenOption.AccessTokenExpiration);
            refreshTokenExpiration = DateTime.Now.AddDays(tokenOption.RefreshTokenExpiration);
        }

        public Token CreateToken(User user, Roles role)
        {
            var securityKey = SecurityKeyHelper.SecurityKeyHelper.CreateSecurityKey(tokenOption.SecurityKey);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            var Jwt = new JwtSecurityToken(
                issuer: tokenOption.Issuer,
                audience: tokenOption.Audience,
                expires: refreshTokenExpiration,
                claims: SetClaims(user, role),
                signingCredentials: signingCredentials
                );
            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(Jwt);

            return new Token
            {
                RefreshToken = tokenAsString,
                Expiration = refreshTokenExpiration,
                UserId = user.Id,
                isActive=user.isActive
            };
        }
        private IEnumerable<Claim> SetClaims(User user, Roles role)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("id", user.Id.ToString()));
            claims.Add(new Claim("mail",user.Mail));
            claims.Add(new Claim("name", $"{user.Name} {user.Surname}"));
            claims.Add(new Claim("role",role.Role));
            return claims;
        }
    }
}
