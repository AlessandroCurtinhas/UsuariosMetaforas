using MetaforasUserID.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MetaforasUserID.Application.Security
{
    public class JWTService
    {
        public static string secretKey = "d37e1244-ea3c-4a02-b9b2-028951f99c5e";
        public static int expirationsInHours = 6;

        public static string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim("IdUsuario", usuario.Id.ToString()), new Claim("Email", usuario.Email) }),
                Expires = DateTime.UtcNow.AddHours(expirationsInHours),
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
