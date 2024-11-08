using Microsoft.AspNetCore.Mvc;
using HPManager.service.Infrastructure.Managers;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Dtos;

namespace HPManager.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            var token = _authManager.Authenticate(login.Email, login.Password);
            if (token == null)
                return Unauthorized(new { Message = "Credenciales inválidas" });

            return Ok(new { Token = token });
        }
    }
}
