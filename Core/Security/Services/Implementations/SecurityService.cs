using Core.Security.Entities;
using Core.Security.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Services.Implementations
{
    public class SecurityService : ISecurityService
    {
        public string HashPassword(string userName, string hashedPassword)
        {
            var passwordHasher = new PasswordHasher<string>();

            return passwordHasher.HashPassword(userName, hashedPassword);
        }

        public bool VerifyHashedPassword(string userName, string hashedPassword, string providedPassword)
        {
            var passwordHasher = new PasswordHasher<string>();

            var verificationResult = passwordHasher.VerifyHashedPassword(userName, hashedPassword, providedPassword);

            if (verificationResult == PasswordVerificationResult.Success) return true;

            return false;
        }

        public SecurityEntity JwtSecurity(string jwtSecrectKey)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
            };
            var expiredDateTime = utcNow.AddDays(1);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            //Key + credentials
            var key = Encoding.ASCII.GetBytes(jwtSecrectKey);
            var symmetricSecurityKey = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(claims: claims, expires: expiredDateTime, notBefore: utcNow, signingCredentials: signingCredentials);
            string token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new SecurityEntity()
            {
                TokenType = "Bearer",
                AccesToken = token,
                ExpiresOn = expiredDateTime
            };
        }
    }
}
