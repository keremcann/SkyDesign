using Microsoft.IdentityModel.Tokens;
using SkyDesign.Core.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SkyDesign.Core.Auth
{
    public class Authentication : IAuthentication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<AuthenticationType> Authenticate(string username, string password, string role)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(AppSettings.GetSecretKey());
                var descriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = handler.CreateToken(descriptor);

                return Task.FromResult(new AuthenticationType { Success = true, Value = handler.WriteToken(token) });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new AuthenticationType { Success = false, Value = ex.Message });
            }
        }
    }
}
