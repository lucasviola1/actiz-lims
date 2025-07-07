using ActizLims.API.Data;
using ActizLims.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ActizLims.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _key;
        private readonly configDbContext _context;

        public AuthService(IConfiguration configuration, configDbContext context)
        {
            _key = configuration["Jwt:Key"] ?? throw new Exception("Chave não encontrada!");
            _context = context;
        }

        public AuthResponse? Authenticate(string username, string password)
        {
            var usuarioLogin = _context.Users.FirstOrDefault(u => u.usuario == username && u.senha == password);
            if (usuarioLogin is null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var keyBytes = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                { 
                    new Claim(ClaimTypes.Name, usuarioLogin.usuario),
                    new Claim(ClaimTypes.NameIdentifier, usuarioLogin.id.ToString())

                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthResponse
            {
                Id = usuarioLogin.id,
                Nome = usuarioLogin.usuario,
                Token = tokenHandler.WriteToken(token)
            };
        }

        public async Task<User> CadastrarUsuario(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
