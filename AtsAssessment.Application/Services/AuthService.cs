using AtsAssessment.Application.Interfaces;
using AtsAssessment.Domain.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AtsAssessment.Application.Services
{
    public class AuthService : IAuthService
    {
        private const string SecretKey = "THIS_IS_YOUR_SECRET_KEY_1234567890";

        public JwtResult GenerateToken(JwtRequest request)
        {
            if (request.Username != "admin" || request.Password != "1234")
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddHours(2);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                issuer: "ats-api",
                audience: "ats-api-client",
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtResult(new JwtSecurityTokenHandler().WriteToken(token), expires);
        }
    }
}
