using Microsoft.AspNetCore.Mvc;
using HPManager.service.Infrastructure.Managers;
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
            return Ok( new { token= token.Result} );
        }
    }
}
