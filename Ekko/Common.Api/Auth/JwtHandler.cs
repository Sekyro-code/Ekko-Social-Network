using Common.Api.DTOs.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Common.Api.Auth
{
    public class JwtHandler : IJwtHandler
    {
        private readonly string _jwtSecret;

        public JwtHandler(IConfiguration configuration)
        {
            _jwtSecret = configuration["Jwt:ServiceApiKey"] ?? throw new ArgumentNullException(nameof(configuration), "Jwt:ServiceApiKey est introuvable dans configuration");
        }
        public string GenerateJwtToken(Guid userId, string userEmail)
        {
            // Vous pouvez utiliser la bibliothèque JWT pour générer le token JWT en utilisant l'ID et l'email de l'utilisateur
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, userEmail)
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Durée de validité du token (1 heure dans cet exemple)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
