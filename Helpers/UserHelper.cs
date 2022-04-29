using CRUD_WEB_API.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRUD_WEB_API.Helpers
{
    public static class UserHelper
    {
        public static string GenerateJwtToken(this IConfiguration configuration, User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["SecretJWT"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string GetUserIdByClaim(IEnumerable<Claim> claims)
        {
            return claims.Where(c => c.Type == "nameid").Select(c => c.Value).SingleOrDefault();
        }

        public static string GetIdClaimFromToken(string tokenText)
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenText);
            var claim = token.Claims.First(c => c.Type == "id").Value;

            return claim;
        }
    }
}