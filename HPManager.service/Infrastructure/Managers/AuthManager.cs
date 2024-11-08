using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using HPManager.service.Infrastructure.Repositories;

namespace HPManager.service.Infrastructure.Managers
{
    public class AuthManager:IAuthManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthManager(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public string Authenticate(string email, string password)
        {
            var user = _userRepository.GetUserByEmailAndPassword(email, password);
            if (user == null) return null;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UsuarioId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("Nombre", user.Nombre),
                new Claim("Apellido", user.Apellido),
                new Claim("RolId", user.RolID.ToString()),
                new Claim("RolNombre", user.Rol.TipoUsuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpirationMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
