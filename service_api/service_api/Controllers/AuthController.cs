using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using service_api.Services;

namespace service_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _auth.LoginAsync(request);
            if (result == null) return Unauthorized("Credenciales inválidas");

            return Ok(result);
        }
    }
}
