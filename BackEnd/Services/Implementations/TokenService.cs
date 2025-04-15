using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEnd.Services.Implementations
{
    public class TokenService : ITokenService
    {

        IConfiguration _configuration;

        public TokenService(IConfiguration configuration) {
            _configuration = configuration;
        }



        public TokenDTO GenerateToken(UsuarioDTO user, RolDTO rol)
        {
            
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Correo),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, rol?.NombreRol ?? "")
            };


            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                //issuer: _configuration["JWT:ValidIssuer"],
                //audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenDTO
            {
                Token = tokenString,
                Expiration = token.ValidTo
            };
        }
    }
}
