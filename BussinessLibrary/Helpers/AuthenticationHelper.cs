using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace HawkerCenterFinder.BL.Helpers
{
    public static class AuthenticationHelper
    { /// <summary>
      /// Compute the MD5 Hash for password
      /// </summary>
      /// <param name="input">passowrd for the user</param>
      /// <returns><see cref="string"/> for hashed password</returns>
        public static string ComputePasswordHash(string input)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = new MD5CryptoServiceProvider().ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

        /// <summary>
        /// Generate JSON Web Token
        /// </summary>
        /// <param name="username">username of the employee</param>
        /// <param name="_configuration"><see cref="IConfiguration"/> object</param>
        /// <returns><see cref="JwtSecurityToken"/> Token</returns>
        public static JwtSecurityToken GenerateJSONWebToken(string username, IConfiguration _configuration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_configuration["Jwt:ValidIssuer"],
              _configuration["Jwt:ValidAudience"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            return token;
        }
    }
}
