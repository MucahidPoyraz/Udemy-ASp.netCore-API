using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Udemy.WebAPI
{
    public class JwtTokenGenerator
    {
        public string GenerateToken()
        {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes("Yavuzyavuzyavuz1."));

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new();
            claims.Add(new Claim(ClaimTypes.Role, "Member"));

            JwtSecurityToken token = new(
                issuer: "http://localhost",
                audience: "http://localhost",
                claims:null,
                signingCredentials: credentials,
                notBefore:DateTime.Now,
                expires:DateTime.Now.AddMinutes(1)
                );
            JwtSecurityTokenHandler handler = new();
            return handler.WriteToken(token);
        }
    }
}
