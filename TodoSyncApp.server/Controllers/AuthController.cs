using Microsoft.AspNetCore.Mvc;
using TodoSyncApp.Server.Services;

namespace TodoSyncApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;

        public AuthController()
        {
            _authenticationService = new AuthenticationService();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (_authenticationService.Authenticate(request.Username, request.Password))
            {
                return Ok("Inicio de sesión exitoso");
            }
            return Unauthorized("Usuario o contraseña incorrectos");
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
