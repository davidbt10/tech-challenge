using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PI.Application.Interfaces;
using PI.Domain.Entity;

namespace PI.Application.Services
{
    internal class TokenService : ITokenService
    {
        private readonly byte[]? _key;

        public TokenService(IConfiguration configuration)
        {
            _key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("Secret")); 
        }

        public string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Permission.ToString()),
                    new Claim("Id", user.Id.ToString())
                }),

                Expires = DateTime.Now.AddHours(8),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
