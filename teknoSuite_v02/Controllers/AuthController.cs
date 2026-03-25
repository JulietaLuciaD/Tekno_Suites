using Microsoft.AspNetCore.Mvc;
using teknoSuite_v02.Services;

namespace teknoSuite_v02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Cambiamos a la validación forzada sin base de datos
            var esValido = _authService.ValidarCredenciales(request.Email, request.Password);

            if (!esValido)
            {
                return Unauthorized(new { mensaje = "Credenciales incorrectas" });
            }

            // Retornamos un OK con un mensaje de éxito
            return Ok(new
            {
                mensaje = "Bienvenido al sistema",
                usuario = request.Email
            });
        }
    }

    public record LoginRequest(string Email, string Password);
}