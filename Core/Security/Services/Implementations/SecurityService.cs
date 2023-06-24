using Core.Security.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
